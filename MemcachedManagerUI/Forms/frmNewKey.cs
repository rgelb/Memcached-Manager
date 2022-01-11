namespace MemcachedManager.UI.Forms;

public partial class frmNewKey : Form {
    public frmNewKey() {
        InitializeComponent();
    }

    public string KeyName => txtKeyName.Text;
    public string KeyValue => txtKeyValue.Text;
    public int CacheInSeconds => (int) txtCacheInSeconds.Value;

    private void btnOK_Click(object sender, EventArgs e) {
        if (string.IsNullOrWhiteSpace(txtKeyName.Text)) {
            this.DialogResult = DialogResult.None;
        }

        if (string.IsNullOrWhiteSpace(txtKeyValue.Text)) {
            this.DialogResult = DialogResult.None;
        }

        if (txtCacheInSeconds.Value < 0) {
            this.DialogResult = DialogResult.None;
        }
    }

    private void frmNewKey_FormClosing(object sender, FormClosingEventArgs e) {
        if (this.DialogResult == DialogResult.None) {
            e.Cancel = true;
        }
    }
}
