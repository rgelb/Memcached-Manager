using MemcachedManager.Entities.Models;
using MemcachedManager.Entities.Settings;
using MemcachedManager.UI.Common;
using MemcachedManager.UI.Controls;
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
        InitializeUserSettings();
        DisplayContentControl(ContentType.None);
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
        SaveUserSettings();
    }

    private void cboConnections_SelectedIndexChanged(object sender, EventArgs e) {
        if (cboConnections.SelectedItem is not Connection connection) {
            MessageBox.Show("Connection is not selected!");
            return;
        }

        // clear
        treeServers.Nodes.Clear();
        DisplayContentControl(ContentType.None);

        var parentNode = treeServers.Nodes.Add("Servers");

        // load servers
        foreach (var server in connection.Servers) {
            var node = parentNode.Nodes.Add($"{server.Address}:{server.Port}");
            node.Tag = server;
            node.EnsureVisible();
        }
    }

    private void treeServers_AfterSelect(object sender, TreeViewEventArgs e) {

        Connection connection = this.CurrentConnection;
        if (connection == null) {
            MessageBox.Show("Connection is not selected!");
            return;
        }

        if (e.Node.Tag is Server) {
            MemcachedAccess access = new(connection);

            try {
                Cursor.Current = Cursors.WaitCursor;
                MemcachedServerStats stats = access.Stats((Server)e.Node.Tag);
                PopulateStatsGrid(stats);
                DisplayContentControl(ContentType.Grid);

            } finally {
                Cursor.Current = Cursors.Default;
            }

        }
    }

    private void toolBtnManageConnections_Click(object sender, EventArgs e) {
        // bring up the manager for connections

    }

    private void toolBtnFlush_Click(object sender, EventArgs e) {
        Connection connection = this.CurrentConnection;
        if (connection == null) {
            MessageBox.Show("Connection is not selected!");
            return;
        }

        DialogResult dialogResult = MessageBox.Show("This command clears cache on every server in this cluster.  There is no way to undo it.  Are you sure?",
                                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        if (dialogResult == DialogResult.OK) {
            MemcachedAccess access = new(connection);

            try {
                Cursor.Current = Cursors.WaitCursor;
                access.Flush();
            } finally {
                Cursor.Current = Cursors.Default;
            }            
        }
    }

    private void toolBtnItemsStats_Click(object sender, EventArgs e) {
        Connection connection = this.CurrentConnection;
        if (connection == null) {
            MessageBox.Show("Connection is not selected!");
            return;
        }

        Server server = this.CurrentServer;
        if (server == null) {
            MessageBox.Show("Server is not selected!");
            return;
        }

        MemcachedAccess access = new(connection);

        try {
            Cursor.Current = Cursors.WaitCursor;
            string results = access.StatItems(server);

            this.textEditor.Editor.Text = results;
            DisplayContentControl(ContentType.TextEditor);

        } finally {
            Cursor.Current = Cursors.Default;
        }
    }

    private void toolBtnCacheDump_Click(object sender, EventArgs e) {
        Connection connection = this.CurrentConnection;
        if (connection == null) {
            MessageBox.Show("Connection is not selected!");
            return;
        }

        Server server = this.CurrentServer;
        if (server == null) {
            MessageBox.Show("Server is not selected!");
            return;
        }

        this.Cursor = Cursors.AppStarting;

        MemcachedAccess access = new(connection);
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
                this.textEditor.Editor.Text = cacheDumpResults;
                DisplayContentControl(ContentType.TextEditor);

                ToggleCancellableUIVisibility(false);
                ToggleUIEnabled(true);

                this.Cursor = Cursors.Default;
            });
        }, token);

    }

    private void toolBtnCancelOperation_Click(object sender, EventArgs e) {
        appCancellationTokenSource.Cancel();
    }

    private void cacheDump_Progress(object sender, ProgressEventArgs e) {
        this.Invoke((MethodInvoker)delegate {
            toolAppProgressBar.Value = e.Percent;
        });
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


        if (Properties.Settings.Default.LastConnection.Length > 0) {
            cboConnections.Text = Properties.Settings.Default.LastConnection;
        }

    }

    private void SaveUserSettings() {
        Properties.Settings.Default.LastConnection = cboConnections.Text;
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
        PopulateConnections();
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

    private void PopulateConnections() {
        var appConnections = new AppConnection(connectionStrings.AppDb).GetAll();

        cboConnections.ComboBox.ValueMember = "ConnectionId";
        cboConnections.ComboBox.DisplayMember = "Name";

        foreach (var item in appConnections) {
            cboConnections.Items.Add(item);
        }
    }

    private void PopulateStatsGrid(MemcachedServerStats stats) {

        grdEntities.AutoGenerateColumns = true;
        grdEntities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        var source = new SortableBindingList<StatPair>(stats.StatItems);
        grdEntities.DataSource = source;

        // set order of columns
        grdEntities.Columns["Name"].DisplayIndex = 0;
        grdEntities.Columns["Value"].DisplayIndex = 1;

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
        toolBtnCancelOperation.Visible = toggle;
        toolAppProgressBar.Visible = toggle;
    }

    private void ToggleUIEnabled(bool toggle) {
        cboConnections.Enabled = toggle;
        toolButtonManageConnections.Enabled = toggle;
        toolBtnCacheDump.Enabled = toggle;
        toolBtnFlush.Enabled = toggle;
        toolBtnItemsStats.Enabled = toggle;
        appContainer.Enabled = toggle;
    }

    private List<int> StatItemsToSlabs(string results) {
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

    #endregion

    #region Properties

    private Connection CurrentConnection => cboConnections.SelectedItem as Connection;

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
