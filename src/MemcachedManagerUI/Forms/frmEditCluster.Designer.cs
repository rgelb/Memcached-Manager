namespace MemcachedManager.UI.Forms;

partial class frmEditCluster {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditCluster));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClusterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvServers = new System.Windows.Forms.DataGridView();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clusterIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDeleteRow = new System.Windows.Forms.DataGridViewButtonColumn();
            this.serverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(265, 409);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(348, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cluster Name";
            // 
            // txtClusterName
            // 
            this.txtClusterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClusterName.Location = new System.Drawing.Point(12, 33);
            this.txtClusterName.Name = "txtClusterName";
            this.txtClusterName.PlaceholderText = "could be anything (e.g. Dev, Stage, Prod, etc...)";
            this.txtClusterName.Size = new System.Drawing.Size(411, 23);
            this.txtClusterName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Servers";
            // 
            // dgvServers
            // 
            this.dgvServers.AutoGenerateColumns = false;
            this.dgvServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.clusterIdDataGridViewTextBoxColumn,
            this.clnDeleteRow});
            this.dgvServers.DataSource = this.serverBindingSource;
            this.dgvServers.Location = new System.Drawing.Point(12, 88);
            this.dgvServers.Name = "dgvServers";
            this.dgvServers.RowTemplate.Height = 25;
            this.dgvServers.Size = new System.Drawing.Size(411, 311);
            this.dgvServers.TabIndex = 1;
            this.dgvServers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServers_CellContentClick);
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Port";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            // 
            // clusterIdDataGridViewTextBoxColumn
            // 
            this.clusterIdDataGridViewTextBoxColumn.DataPropertyName = "ClusterId";
            this.clusterIdDataGridViewTextBoxColumn.HeaderText = "ClusterId";
            this.clusterIdDataGridViewTextBoxColumn.Name = "clusterIdDataGridViewTextBoxColumn";
            this.clusterIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // clnDeleteRow
            // 
            this.clnDeleteRow.HeaderText = "Delete";
            this.clnDeleteRow.Name = "clnDeleteRow";
            this.clnDeleteRow.Text = "Delete";
            this.clnDeleteRow.UseColumnTextForButtonValue = true;
            // 
            // serverBindingSource
            // 
            this.serverBindingSource.DataSource = typeof(MemcachedManager.Entities.Models.Server);
            // 
            // frmEditCluster
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(435, 444);
            this.Controls.Add(this.dgvServers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClusterName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditCluster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Cluster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditCluster_FormClosing);
            this.Load += new System.EventHandler(this.frmEditCluster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button btnOK;
    private Button btnCancel;
    private Label label1;
    private TextBox txtClusterName;
    private Label label2;
    private DataGridView dgvServers;
    private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn clusterIdDataGridViewTextBoxColumn;
    private DataGridViewButtonColumn clnDeleteRow;
    private BindingSource serverBindingSource;
}
