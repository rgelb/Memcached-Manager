using MemcachedManager.Entities.Settings;
using MemcachedManagerDB.Data;

namespace MemcachedManager.UI.Forms;
public partial class frmConnectionList : Form {
    public frmConnectionList() {
        InitializeComponent();
    }

    public ConnectionStrings ConnectionStrings { get; set; }
    public bool Changed { get; internal set; }

    private void btnClose_Click(object sender, EventArgs e) {
        this.Close();
    }

    private void btnAddNew_Click(object sender, EventArgs e) {
        frmEditConnection frm = new();
        if (frm.ShowDialog() == DialogResult.OK) {

        }
    }

    private void btnEdit_Click(object sender, EventArgs e) {
        frmEditConnection frm = new();
        if (frm.ShowDialog() == DialogResult.OK) {

        }
    }

    private void btnDelete_Click(object sender, EventArgs e) {
        if (MessageBox.Show("Are you sure?", "Delete connection", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {

        }
    }

    private void frmConnectionList_Load(object sender, EventArgs e) {
        PopulateConnections();
    }
    
    
    private void PopulateConnections() {
        var appConnections = new AppConnection(ConnectionStrings.AppDb).GetAll();

        foreach (var connection in appConnections) {

            ListViewItem lvItem = new(connection.Name);

            string serversDescription = string.Join(", ", connection.Servers.Select(f => $"{f.Address}:{f.Port}"));
            lvItem.SubItems.Add(serversDescription);
            lvItem.Tag = connection;

            lvConnections.Items.Add(lvItem);
        }
    }
}
