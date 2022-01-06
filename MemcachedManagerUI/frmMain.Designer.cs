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
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cboConnections = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolBtnItemsStats = new System.Windows.Forms.ToolStripButton();
            this.appToolbar = new System.Windows.Forms.ToolStrip();
            this.toolButtonManageConnections = new System.Windows.Forms.ToolStripButton();
            this.toolBtnFlush = new System.Windows.Forms.ToolStripButton();
            this.toolBtnCacheDump = new System.Windows.Forms.ToolStripButton();
            this.toolBtnCancelOperation = new System.Windows.Forms.ToolStripButton();
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
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatus.Text = "Idle";
            // 
            // appStatusBar
            // 
            this.appStatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.appStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus,
            this.toolAppProgressBar});
            this.appStatusBar.Location = new System.Drawing.Point(0, 700);
            this.appStatusBar.Name = "appStatusBar";
            this.appStatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.appStatusBar.Size = new System.Drawing.Size(1137, 22);
            this.appStatusBar.TabIndex = 6;
            this.appStatusBar.Text = "Idle";
            // 
            // toolAppProgressBar
            // 
            this.toolAppProgressBar.Name = "toolAppProgressBar";
            this.toolAppProgressBar.Size = new System.Drawing.Size(100, 16);
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
            this.toolStripSeparator6.Visible = false;
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
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(55, 24);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // cboConnections
            // 
            this.cboConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConnections.Name = "cboConnections";
            this.cboConnections.Size = new System.Drawing.Size(106, 27);
            this.cboConnections.SelectedIndexChanged += new System.EventHandler(this.cboConnections_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(103, 24);
            this.toolStripLabel2.Text = "Select Connection";
            // 
            // toolBtnItemsStats
            // 
            this.toolBtnItemsStats.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnItemsStats.Image")));
            this.toolBtnItemsStats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnItemsStats.Name = "toolBtnItemsStats";
            this.toolBtnItemsStats.Size = new System.Drawing.Size(83, 24);
            this.toolBtnItemsStats.Text = "&Item Stats";
            this.toolBtnItemsStats.Click += new System.EventHandler(this.toolBtnItemsStats_Click);
            // 
            // appToolbar
            // 
            this.appToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.appToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cboConnections,
            this.toolButtonManageConnections,
            this.toolStripSeparator2,
            this.toolBtnFlush,
            this.toolBtnItemsStats,
            this.toolBtnCacheDump,
            this.toolBtnCancelOperation,
            this.toolStripSeparator6,
            this.newToolStripButton,
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
            // toolButtonManageConnections
            // 
            this.toolButtonManageConnections.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolButtonManageConnections.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonManageConnections.Image")));
            this.toolButtonManageConnections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonManageConnections.Name = "toolButtonManageConnections";
            this.toolButtonManageConnections.Size = new System.Drawing.Size(23, 24);
            this.toolButtonManageConnections.Text = "...";
            this.toolButtonManageConnections.Click += new System.EventHandler(this.toolBtnManageConnections_Click);
            // 
            // toolBtnFlush
            // 
            this.toolBtnFlush.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnFlush.Image")));
            this.toolBtnFlush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnFlush.Name = "toolBtnFlush";
            this.toolBtnFlush.Size = new System.Drawing.Size(68, 24);
            this.toolBtnFlush.Text = "Flush...";
            this.toolBtnFlush.Click += new System.EventHandler(this.toolBtnFlush_Click);
            // 
            // toolBtnCacheDump
            // 
            this.toolBtnCacheDump.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnCacheDump.Image")));
            this.toolBtnCacheDump.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnCacheDump.Name = "toolBtnCacheDump";
            this.toolBtnCacheDump.Size = new System.Drawing.Size(100, 24);
            this.toolBtnCacheDump.Text = "Cache Dump";
            this.toolBtnCacheDump.Click += new System.EventHandler(this.toolBtnCacheDump_Click);
            // 
            // toolBtnCancelOperation
            // 
            this.toolBtnCancelOperation.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnCancelOperation.Image")));
            this.toolBtnCancelOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnCancelOperation.Name = "toolBtnCancelOperation";
            this.toolBtnCancelOperation.Size = new System.Drawing.Size(123, 24);
            this.toolBtnCancelOperation.Text = "Cancel Operation";
            this.toolBtnCancelOperation.Visible = false;
            this.toolBtnCancelOperation.Click += new System.EventHandler(this.toolBtnCancelOperation_Click);
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
    private ToolStripStatusLabel toolStripStatus;
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
    private ToolStripButton newToolStripButton;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripComboBox cboConnections;
    private ToolStripLabel toolStripLabel2;
    private ToolStripButton toolBtnItemsStats;
    private ToolStrip appToolbar;
    private DataGridView grdEntities;
    private ToolStripButton toolButtonManageConnections;
    private ToolStripButton toolBtnFlush;
    private ToolStripButton toolBtnCacheDump;
    private ToolStripButton toolBtnCancelOperation;
    private ToolStripProgressBar toolAppProgressBar;
}
