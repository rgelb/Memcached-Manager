namespace MemcachedManager.UI;

partial class frmMain {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.treeServers = new System.Windows.Forms.TreeView();
            this.lblAppStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.appStatusBar = new System.Windows.Forms.StatusStrip();
            this.toolAppProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.appContainer = new System.Windows.Forms.SplitContainer();
            this.grdEntities = new System.Windows.Forms.DataGridView();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btnNewKey = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cboClusters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnItemStats = new System.Windows.Forms.ToolStripButton();
            this.appToolbar = new System.Windows.Forms.ToolStrip();
            this.btnManageClusters = new System.Windows.Forms.ToolStripButton();
            this.btnFlush = new System.Windows.Forms.ToolStripButton();
            this.btnCacheDump = new System.Windows.Forms.ToolStripButton();
            this.btnCancelOperation = new System.Windows.Forms.ToolStripButton();
            this.txtSearchByKey = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearchByKey = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.appStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appContainer)).BeginInit();
            this.appContainer.Panel1.SuspendLayout();
            this.appContainer.Panel2.SuspendLayout();
            this.appContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntities)).BeginInit();
            this.appToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeServers
            // 
            this.treeServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeServers.HideSelection = false;
            this.treeServers.Location = new System.Drawing.Point(0, 0);
            this.treeServers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeServers.Name = "treeServers";
            this.treeServers.Size = new System.Drawing.Size(379, 673);
            this.treeServers.TabIndex = 0;
            this.treeServers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeServers_AfterSelect);
            // 
            // lblAppStatus
            // 
            this.lblAppStatus.Name = "lblAppStatus";
            this.lblAppStatus.Size = new System.Drawing.Size(26, 17);
            this.lblAppStatus.Text = "Idle";
            // 
            // appStatusBar
            // 
            this.appStatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.appStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAppStatus,
            this.toolAppProgressBar});
            this.appStatusBar.Location = new System.Drawing.Point(0, 700);
            this.appStatusBar.Name = "appStatusBar";
            this.appStatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.appStatusBar.Size = new System.Drawing.Size(1137, 22);
            this.appStatusBar.TabIndex = 6;
            this.appStatusBar.Text = "Idle";
            this.appStatusBar.Resize += new System.EventHandler(this.appStatusBar_Resize);
            // 
            // toolAppProgressBar
            // 
            this.toolAppProgressBar.AutoSize = false;
            this.toolAppProgressBar.Name = "toolAppProgressBar";
            this.toolAppProgressBar.Size = new System.Drawing.Size(500, 16);
            this.toolAppProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolAppProgressBar.Visible = false;
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Visible = false;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            this.toolStripSeparator7.Visible = false;
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Visible = false;
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Visible = false;
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cutToolStripButton.Text = "C&ut";
            this.cutToolStripButton.Visible = false;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // appContainer
            // 
            this.appContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appContainer.Location = new System.Drawing.Point(0, 27);
            this.appContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.appContainer.Name = "appContainer";
            // 
            // appContainer.Panel1
            // 
            this.appContainer.Panel1.Controls.Add(this.treeServers);
            // 
            // appContainer.Panel2
            // 
            this.appContainer.Panel2.Controls.Add(this.grdEntities);
            this.appContainer.Size = new System.Drawing.Size(1137, 673);
            this.appContainer.SplitterDistance = 379;
            this.appContainer.TabIndex = 7;
            // 
            // grdEntities
            // 
            this.grdEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEntities.Location = new System.Drawing.Point(80, 77);
            this.grdEntities.Name = "grdEntities";
            this.grdEntities.RowTemplate.Height = 25;
            this.grdEntities.Size = new System.Drawing.Size(240, 150);
            this.grdEntities.TabIndex = 0;
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Visible = false;
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Visible = false;
            // 
            // btnNewKey
            // 
            this.btnNewKey.Image = ((System.Drawing.Image)(resources.GetObject("btnNewKey.Image")));
            this.btnNewKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewKey.Name = "btnNewKey";
            this.btnNewKey.Size = new System.Drawing.Size(86, 24);
            this.btnNewKey.Text = "&New Key...";
            this.btnNewKey.Click += new System.EventHandler(this.btnNewKey_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // cboClusters
            // 
            this.cboClusters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClusters.Name = "cboClusters";
            this.cboClusters.Size = new System.Drawing.Size(106, 27);
            this.cboClusters.SelectedIndexChanged += new System.EventHandler(this.cboClusters_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(78, 24);
            this.toolStripLabel2.Text = "Select Cluster";
            // 
            // btnItemStats
            // 
            this.btnItemStats.Image = ((System.Drawing.Image)(resources.GetObject("btnItemStats.Image")));
            this.btnItemStats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItemStats.Name = "btnItemStats";
            this.btnItemStats.Size = new System.Drawing.Size(83, 24);
            this.btnItemStats.Text = "&Item Stats";
            this.btnItemStats.Click += new System.EventHandler(this.btnItemsStats_Click);
            // 
            // appToolbar
            // 
            this.appToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.appToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cboClusters,
            this.btnManageClusters,
            this.toolStripSeparator2,
            this.btnFlush,
            this.btnItemStats,
            this.btnCacheDump,
            this.btnCancelOperation,
            this.toolStripSeparator6,
            this.txtSearchByKey,
            this.btnSearchByKey,
            this.toolStripSeparator1,
            this.btnNewKey,
            this.openToolStripButton,
            this.printToolStripButton,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator7,
            this.helpToolStripButton});
            this.appToolbar.Location = new System.Drawing.Point(0, 0);
            this.appToolbar.Name = "appToolbar";
            this.appToolbar.Size = new System.Drawing.Size(1137, 27);
            this.appToolbar.TabIndex = 5;
            this.appToolbar.Text = "toolStrip1";
            // 
            // btnManageClusters
            // 
            this.btnManageClusters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnManageClusters.Image = ((System.Drawing.Image)(resources.GetObject("btnManageClusters.Image")));
            this.btnManageClusters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageClusters.Name = "btnManageClusters";
            this.btnManageClusters.Size = new System.Drawing.Size(23, 24);
            this.btnManageClusters.Text = "...";
            this.btnManageClusters.Click += new System.EventHandler(this.btnManageClusters_Click);
            // 
            // btnFlush
            // 
            this.btnFlush.Image = ((System.Drawing.Image)(resources.GetObject("btnFlush.Image")));
            this.btnFlush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.Size = new System.Drawing.Size(68, 24);
            this.btnFlush.Text = "Flush...";
            this.btnFlush.Click += new System.EventHandler(this.btnFlush_Click);
            // 
            // btnCacheDump
            // 
            this.btnCacheDump.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheDump.Image")));
            this.btnCacheDump.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCacheDump.Name = "btnCacheDump";
            this.btnCacheDump.Size = new System.Drawing.Size(100, 24);
            this.btnCacheDump.Text = "Cache Dump";
            this.btnCacheDump.Click += new System.EventHandler(this.btnCacheDump_Click);
            // 
            // btnCancelOperation
            // 
            this.btnCancelOperation.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelOperation.Image")));
            this.btnCancelOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelOperation.Name = "btnCancelOperation";
            this.btnCancelOperation.Size = new System.Drawing.Size(123, 24);
            this.btnCancelOperation.Text = "Cancel Operation";
            this.btnCancelOperation.Visible = false;
            this.btnCancelOperation.Click += new System.EventHandler(this.btnCancelOperation_Click);
            // 
            // txtSearchByKey
            // 
            this.txtSearchByKey.Name = "txtSearchByKey";
            this.txtSearchByKey.Size = new System.Drawing.Size(200, 27);
            this.txtSearchByKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchByKey_KeyDown);
            this.txtSearchByKey.DoubleClick += new System.EventHandler(this.txtSearchByKey_DoubleClick);
            // 
            // btnSearchByKey
            // 
            this.btnSearchByKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchByKey.Image = global::MemcachedManager.UI.Properties.Resources.if_search_298865;
            this.btnSearchByKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchByKey.Name = "btnSearchByKey";
            this.btnSearchByKey.Size = new System.Drawing.Size(24, 24);
            this.btnSearchByKey.Text = "toolStripButton1";
            this.btnSearchByKey.Click += new System.EventHandler(this.btnSearchByKey_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 722);
            this.Controls.Add(this.appContainer);
            this.Controls.Add(this.appStatusBar);
            this.Controls.Add(this.appToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Memcached Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.appStatusBar.ResumeLayout(false);
            this.appStatusBar.PerformLayout();
            this.appContainer.Panel1.ResumeLayout(false);
            this.appContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appContainer)).EndInit();
            this.appContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntities)).EndInit();
            this.appToolbar.ResumeLayout(false);
            this.appToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TreeView treeServers;
    private ToolStripStatusLabel lblAppStatus;
    private StatusStrip appStatusBar;
    private ToolStripButton helpToolStripButton;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripButton pasteToolStripButton;
    private ToolStripButton copyToolStripButton;
    private ToolStripButton cutToolStripButton;
    private ToolStripSeparator toolStripSeparator6;
    private SplitContainer appContainer;
    private ToolStripButton printToolStripButton;
    private ToolStripButton openToolStripButton;
    private ToolStripButton btnNewKey;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripComboBox cboClusters;
    private ToolStripLabel toolStripLabel2;
    private ToolStripButton btnItemStats;
    private ToolStrip appToolbar;
    private DataGridView grdEntities;
    private ToolStripButton btnManageClusters;
    private ToolStripButton btnFlush;
    private ToolStripButton btnCacheDump;
    private ToolStripButton btnCancelOperation;
    private ToolStripProgressBar toolAppProgressBar;
    private ToolStripTextBox txtSearchByKey;
    private ToolStripButton btnSearchByKey;
    private ToolStripSeparator toolStripSeparator1;
}
