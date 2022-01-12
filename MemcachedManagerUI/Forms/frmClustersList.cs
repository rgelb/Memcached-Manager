using MemcachedManager.Entities.Models;
using MemcachedManager.Entities.Settings;
using MemcachedManagerDB.Data;

namespace MemcachedManager.UI.Forms;
public partial class frmClustersList : Form {
    public frmClustersList() {
        InitializeComponent();
    }

    public ConnectionStrings ConnectionStrings { get; set; }
    public bool Changed { get; internal set; } = false;

    private void btnClose_Click(object sender, EventArgs e) {
        this.Close();
    }

    private void btnAddNew_Click(object sender, EventArgs e) {
        frmEditCluster frm = new();
        if (frm.ShowDialog() == DialogResult.OK) {

            AppConnection appConnection = new(ConnectionStrings.AppDb);
            appConnection.Save(frm.Cluster);

            PopulateClusters();

            Changed = true;
        }
    }

    private void btnEdit_Click(object sender, EventArgs e) {
        Cluster selectedCluster = this.SelectedCluster;
        if (selectedCluster == null) {
            MessageBox.Show("Select a cluster");
            return;
        }

        frmEditCluster frm = new() { Cluster = selectedCluster };
        if (frm.ShowDialog() == DialogResult.OK) {

            // update all clusterIds
            foreach (var server in frm.Cluster.Servers) {
                server.ClusterId = selectedCluster.ClusterId;
            }

            AppConnection appConnection = new(ConnectionStrings.AppDb);
            appConnection.Save(frm.Cluster);

            PopulateClusters();

            Changed = true;
        }
    }

    private void btnDelete_Click(object sender, EventArgs e) {
        Cluster selectedCluster = this.SelectedCluster;
        if (selectedCluster == null) {
            MessageBox.Show("Select a cluster");
            return;
        }

        if (MessageBox.Show("Are you sure?", "Delete connection", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {

            AppConnection appConnection = new(ConnectionStrings.AppDb);
            appConnection.DeleteCluster(selectedCluster);

            Changed = true;
        }
    }

    private void frmConnectionList_Load(object sender, EventArgs e) {
        PopulateClusters();
    }


    private Cluster SelectedCluster {
        get {
            if (lvClusters.SelectedItems.Count > 0) {
                return lvClusters.SelectedItems[0].Tag as Cluster;
            }
            return null;
        }
    }

    private void PopulateClusters() {

        lvClusters.Items.Clear();

        var clusters = new AppConnection(ConnectionStrings.AppDb).GetAll();

        foreach (var cluster in clusters) {

            ListViewItem lvItem = new(cluster.Name);

            string serversDescription = string.Join(", ", cluster.Servers.Select(f => $"{f.Address}:{f.Port}"));
            lvItem.SubItems.Add(serversDescription);
            lvItem.Tag = cluster;

            lvClusters.Items.Add(lvItem);
        }
    }
}
