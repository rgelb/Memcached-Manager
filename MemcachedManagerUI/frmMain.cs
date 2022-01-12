using MemcachedManager.Entities.Models;
using MemcachedManager.Entities.Settings;
using MemcachedManager.UI.Common;
using MemcachedManager.UI.Controls;
using MemcachedManager.UI.Forms;
using MemcachedManagerDB.Data;
using MemcachedManagerDB.Setup;
using Microsoft.Extensions.Configuration;
using ScintillaNET;

namespace MemcachedManager.UI;

public partial class frmMain : Form {

    #region Variables
    private AppSettings appSettings;
    private ConnectionStrings connectionStrings;
    private TextEditor textEditor;
    private CancellationTokenSource appCancellationTokenSource;

    private enum ContentType {
        None,
        Grid,
        TextEditor,
        SplitTextEditor
    }

    #endregion

    #region Constructors

    public frmMain() {
        InitializeComponent();
    }

    #endregion

    #region Events

    private void frmMain_Load(object sender, EventArgs e) {
        InitializeSettings();
        InitializeTextEditor();
        InitializeData();
        InitializeUI();
        InitializeMiscUI();
        InitializeUserSettings();
        DisplayContentControl(ContentType.None);
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
        SaveUserSettings();
    }

    private void cboClusters_SelectedIndexChanged(object sender, EventArgs e) {
        if (cboClusters.SelectedItem is not Cluster cluster) {
            MessageBox.Show("Cluster is not selected!");
            return;
        }

        // clear
        treeServers.Nodes.Clear();
        DisplayContentControl(ContentType.None);

        var parentNode = treeServers.Nodes.Add("Servers");

        // load servers
        foreach (var server in cluster.Servers) {
            var node = parentNode.Nodes.Add($"{server.Address}:{server.Port}");
            node.Tag = server;
            node.EnsureVisible();
        }
    }

    private void treeServers_AfterSelect(object sender, TreeViewEventArgs e) {

        Cluster cluster = this.CurrentCluster;
        if (cluster == null) {
            MessageBox.Show("Cluster is not selected!");
            return;
        }

        if (e.Node.Tag is Server server) {
            MemcachedAccess access = new(cluster);

            try {
                Cursor.Current = Cursors.WaitCursor;
                MemcachedServerStats stats = access.Stats(server);
                PopulateGrid(stats);
                DisplayContentControl(ContentType.Grid);

            } finally {
                Cursor.Current = Cursors.Default;
            }

        }
    }

    private void btnManageClusters_Click(object sender, EventArgs e) {
        frmClustersList frm = new();
        frm.ConnectionStrings = this.connectionStrings;
        frm.ShowDialog();

        if (frm.Changed) {
            PopulateClusters();
        }

    }

    private void btnFlush_Click(object sender, EventArgs e) {
        Cluster cluster = this.CurrentCluster;
        if (cluster == null) {
            MessageBox.Show("Cluster is not selected!");
            return;
        }

        DialogResult dialogResult = MessageBox.Show("This command clears cache on every server in this cluster.  There is no way to undo it.  Are you sure?",
                                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        if (dialogResult == DialogResult.OK) {
            MemcachedAccess access = new(cluster);

            try {
                Cursor.Current = Cursors.WaitCursor;
                access.Flush();
            } finally {
                Cursor.Current = Cursors.Default;
            }            
        }
    }

    private void btnItemsStats_Click(object sender, EventArgs e) {
        Cluster cluster = this.CurrentCluster;
        if (cluster == null) {
            MessageBox.Show("Cluster is not selected!");
            return;
        }

        Server server = this.CurrentServer;
        if (server == null) {
            MessageBox.Show("Server is not selected!");
            return;
        }

        MemcachedAccess access = new(cluster);

        try {
            Cursor.Current = Cursors.WaitCursor;
            string results = access.StatItems(server);

            PopulateTextEditor(results);
            DisplayContentControl(ContentType.TextEditor);

        } finally {
            Cursor.Current = Cursors.Default;
        }
    }

    private void btnCacheDump_Click(object sender, EventArgs e) {
        Cluster cluster = this.CurrentCluster;
        if (cluster == null) {
            MessageBox.Show("Cluster is not selected!");
            return;
        }

        Server server = this.CurrentServer;
        if (server == null) {
            MessageBox.Show("Server is not selected!");
            return;
        }

        this.Cursor = Cursors.AppStarting;

        MemcachedAccess access = new(cluster);
        string statItemsResults = access.StatItems(server);
        List<int> slabs = StatItemsToSlabs(statItemsResults);

        appCancellationTokenSource = new();
        var token = appCancellationTokenSource.Token;

        ToggleCancellableUIVisibility(true);
        ToggleUIEnabled(false);

        // clear out contents panel
        DisplayContentControl(ContentType.None);

        // subscribe to the progress event
        access.Progress += cacheDump_Progress;

        Task tc = Task.Run(() => 
        {
            string cacheDumpResults = access.CacheDump(server, slabs, token);

            this.Invoke((MethodInvoker)delegate {
                PopulateTextEditor(cacheDumpResults);
                DisplayContentControl(ContentType.TextEditor);

                ToggleCancellableUIVisibility(false);
                ToggleUIEnabled(true);

                this.Cursor = Cursors.Default;
            });
        }, token);

    }

    private void btnCancelOperation_Click(object sender, EventArgs e) {
        appCancellationTokenSource.Cancel();
    }

    private void cacheDump_Progress(object sender, ProgressEventArgs e) {
        this.Invoke((MethodInvoker)delegate {
            toolAppProgressBar.Value = e.Percent;
        });
    }

    private void appStatusBar_Resize(object sender, EventArgs e) {
        toolAppProgressBar.Width = appStatusBar.Width - lblAppStatus.Width - 25;
    }

    private void btnSearchByKey_Click(object sender, EventArgs e) {
        SearchByKey();
    }

    private void txtSearchByKey_DoubleClick(object sender, EventArgs e) {
        txtSearchByKey.Clear();
    }

    private void txtSearchByKey_KeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Enter) {
            SearchByKey();
        }
    }

    private void btnNewKey_Click(object sender, EventArgs e) {
        Cluster cluster = this.CurrentCluster;
        if (cluster == null) {
            MessageBox.Show("Cluster is not selected!");
            return;
        }

        var form = new frmNewKey();
        DialogResult dialogResult = form.ShowDialog();
        if (dialogResult == DialogResult.OK) {
            MemcachedAccess access = new(cluster);
            access.SetByKey(form.KeyName, form.KeyValue, form.CacheInSeconds);
        }
    }

    #endregion

    #region User Settings
    private void InitializeUserSettings() {
        this.WindowState = (FormWindowState) Properties.Settings.Default.WindowState;

        switch (this.WindowState) {
            case FormWindowState.Normal:
                this.Location = Properties.Settings.Default.Location;
                this.Size = Properties.Settings.Default.Size;
                break;
            case FormWindowState.Minimized:
                // restore state to normal
                this.WindowState = FormWindowState.Normal;
                this.Location = Properties.Settings.Default.Location;
                this.Size = Properties.Settings.Default.Size;
                break;
            case FormWindowState.Maximized:
                this.Location = Properties.Settings.Default.Location;
                this.Size = Properties.Settings.Default.Size;
                break;
            default:
                break;
        }


        if (Properties.Settings.Default.LastCluster.Length > 0) {
            cboClusters.Text = Properties.Settings.Default.LastCluster;
        }

    }

    private void SaveUserSettings() {
        Properties.Settings.Default.LastCluster = cboClusters.Text;
        Properties.Settings.Default.WindowState = (int)this.WindowState;

        switch (this.WindowState) {
            case FormWindowState.Normal:
                Properties.Settings.Default.Location = this.Location;
                Properties.Settings.Default.Size = this.Size;
                break;
            case FormWindowState.Minimized:
                // don't save location & size
                break;
            case FormWindowState.Maximized:
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                break;
            default:
                break;
        }

        Properties.Settings.Default.Save();
    }
    #endregion

    #region Initialization
    private void InitializeUI() {
        PopulateClusters();
    }

    private void InitializeMiscUI() {
        NativeMethods.SetToolstripTextBoxPlaceHolder(txtSearchByKey, "Search By Key");

        // force a resize of status bar
        appStatusBar_Resize(appStatusBar, EventArgs.Empty);
    }

    private void InitializeTextEditor() {
        var txtContent = new Scintilla();
        appContainer.Panel2.Controls.Add(txtContent);
        txtContent.Dock = DockStyle.None;

        textEditor = new TextEditor(txtContent);
    }

    private void InitializeSettings() {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, false)
            .AddEnvironmentVariables();

        var config = builder.Build();

        // ridiculous insanity needed to get the app settings object
        this.appSettings = config.GetSection(nameof(AppSettings)).Get<AppSettings>();
        this.connectionStrings = config.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();

        if (appSettings == null) {
            MessageBox.Show("Configuration file missing app settings information");
        }
        if (connectionStrings == null) {
            MessageBox.Show("Configuration file missing connection information");
        }
    }

    private void InitializeData() {
        new Bootstrap(connectionStrings.AppDb).BuildDb();
    }
    #endregion

    #region Private Methods

    private void PopulateClusters() {
        cboClusters.Items.Clear();

        var clusters = new AppConnection(connectionStrings.AppDb).GetAll();

        cboClusters.ComboBox.ValueMember = "ClusterId";
        cboClusters.ComboBox.DisplayMember = "Name";

        foreach (var cluster in clusters) {
            cboClusters.Items.Add(cluster);
        }
    }

    private void PopulateGrid(MemcachedServerStats stats) {
        grdEntities.AutoGenerateColumns = true;
        grdEntities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        var source = new SortableBindingList<StatPair>(stats.StatItems);
        grdEntities.DataSource = source;

        // set order of columns
        grdEntities.Columns["Name"].DisplayIndex = 0;
        grdEntities.Columns["Value"].DisplayIndex = 1;
    }

    private void PopulateGrid(byte[] data) {
        // convert byte array to List<StatPair> for convinience so that user can see the index as well
        var listItems = new List<StatPair>();
        int index = 0;
        foreach (var item in data) {
            index++;
            listItems.Add(new StatPair(index.ToString(), item.ToString()));
        }

        grdEntities.AutoGenerateColumns = true;
        grdEntities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        grdEntities.DataSource = listItems;

        // set order of columns
        grdEntities.Columns["Name"].HeaderText = "Index";
        grdEntities.Columns["Value"].DisplayIndex = 1;
        grdEntities.Columns["Notes"].Visible = false;
    }

    private void PopulateTextEditor(string text) {
        this.textEditor.Editor.Text = text;
    }

    private void DisplayContentControl(ContentType contentType) {

        // hide other things
        textEditor.Editor.Dock = DockStyle.None;
        textEditor.Editor.Visible = false;

        grdEntities.Dock = DockStyle.None;
        grdEntities.Visible = false;


        switch (contentType) {
            case ContentType.Grid:
                grdEntities.Dock = DockStyle.Fill;
                grdEntities.Visible = true;
                break;
            case ContentType.TextEditor:
                textEditor.Editor.Dock = DockStyle.Fill;
                textEditor.Editor.Visible = true;
                break;
            case ContentType.SplitTextEditor:
                break;
            case ContentType.None:
                break;
            default:
                MessageBox.Show($"Invalid content type: {contentType}");
                break;
        }
    }

    private void ToggleCancellableUIVisibility(bool toggle) {
        btnCancelOperation.Visible = toggle;
        toolAppProgressBar.Visible = toggle;
    }

    private void ToggleUIEnabled(bool toggle) {
        cboClusters.Enabled = toggle;
        btnManageClusters.Enabled = toggle;
        btnCacheDump.Enabled = toggle;
        btnFlush.Enabled = toggle;
        btnItemStats.Enabled = toggle;
        btnSearchByKey.Enabled = toggle;
        txtSearchByKey.Enabled = toggle;
        btnNewKey.Enabled = toggle;
        appContainer.Enabled = toggle;
    }

    private static List<int> StatItemsToSlabs(string results) {
        List<int> slabs = new();
        List<string> lines = results.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        foreach (string line in lines) {
            string[] elements = line.Split(':');

            if (elements.Length == 3 && elements[0] == "STAT items") {
                int slabId = int.Parse(elements[1]);
                if (slabId > 0 && !slabs.Contains(slabId)) {
                    slabs.Add(slabId);
                }
            }
        }

        return slabs;
    }

    private void SearchByKey() {
        Cluster cluster = this.CurrentCluster;
        if (cluster == null) {
            MessageBox.Show("Cluster is not selected!");
            return;
        }

        string searchKey = txtSearchByKey.Text.Trim();
        if (string.IsNullOrEmpty(searchKey)) {
            MessageBox.Show("Enter a key to search by");
            return;
        }

        MemcachedAccess access = new(cluster);

        try {
            Cursor.Current = Cursors.WaitCursor;
            object obj = access.GetByKey(searchKey);

            if (obj == null) {
                PopulateTextEditor("Not Found");
                DisplayContentControl(ContentType.TextEditor);
                return;
            }

            if (obj is byte[] data) {
                PopulateGrid(data);
                DisplayContentControl(ContentType.Grid);
            } else if (obj is string str) {
                PopulateTextEditor(str);
                DisplayContentControl(ContentType.TextEditor);
            } else {
                PopulateTextEditor($"Type: {obj.GetType().FullName} \n\r{obj}");
                DisplayContentControl(ContentType.TextEditor);
            }
        } finally {
            Cursor.Current = Cursors.Default;
        }
    }
    #endregion

    #region Properties

    private Cluster CurrentCluster => cboClusters.SelectedItem as Cluster;

    private Server CurrentServer {
        get {            
            if (treeServers.SelectedNode?.Tag is Server) {
                return treeServers.SelectedNode.Tag as Server;
            }

            return null;            
        }
    }

    #endregion

}
