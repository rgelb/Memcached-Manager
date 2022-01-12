using MemcachedManager.Entities.Models;

namespace MemcachedManager.UI.Forms;

public partial class frmEditCluster : Form {

    private const int COL_DELETE = 2;

    public frmEditCluster() {
        InitializeComponent();
    }

    public Cluster Cluster { get; set; }

    private void frmEditCluster_Load(object sender, EventArgs e) {
        if (this.Cluster == null) {
            this.Cluster = new Cluster();
        }

        txtClusterName.Text = this.Cluster.Name;
        serverBindingSource.DataSource = this.Cluster.Servers;
    }

    private void btnOK_Click(object sender, EventArgs e) {
        if (string.IsNullOrWhiteSpace(txtClusterName.Text)) {
            this.DialogResult = DialogResult.None;
            MessageBox.Show("Enter cluster name");
            return;
        }

        if (this.Cluster.Servers.Count == 0) {
            this.DialogResult = DialogResult.None;
            MessageBox.Show("Enter at least one server");
            return;
        }

        this.Cluster.Name = txtClusterName.Text.Trim();
    }

    private void frmEditCluster_FormClosing(object sender, FormClosingEventArgs e) {
        if (this.DialogResult == DialogResult.None) {
            e.Cancel = true;
        }
    }

    private void dgvServers_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        if (e.ColumnIndex == COL_DELETE) {
            dgvServers.Rows.RemoveAt(e.RowIndex);
        }
    }
}
