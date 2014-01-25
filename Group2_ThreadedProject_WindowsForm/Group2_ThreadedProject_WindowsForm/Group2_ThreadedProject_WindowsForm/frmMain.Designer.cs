namespace Group2_ThreadedProject_WindowsForm
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExitToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSupplierToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditSupplierToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAboutDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxTimer = new System.Windows.Forms.Timer(this.components);
            this.tsToolStip = new System.Windows.Forms.ToolStrip();
            this.btnackagesToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packageReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.btnReportsToolStrip,
            this.btnAboutDialog,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExitToolStripMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // btnExitToolStripMenu
            // 
            this.btnExitToolStripMenu.Name = "btnExitToolStripMenu";
            this.btnExitToolStripMenu.Size = new System.Drawing.Size(92, 22);
            this.btnExitToolStripMenu.Text = "&Exit";
            this.btnExitToolStripMenu.Click += new System.EventHandler(this.btnExitToolStripMenu_Click);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSupplierToolStripMenu,
            this.btnEditSupplierToolStripMenu,
            this.btnackagesToolStrip});
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.supplierToolStripMenuItem.Text = "&DataBase";
            // 
            // btnAddSupplierToolStripMenu
            // 
            this.btnAddSupplierToolStripMenu.Name = "btnAddSupplierToolStripMenu";
            this.btnAddSupplierToolStripMenu.Size = new System.Drawing.Size(152, 22);
            this.btnAddSupplierToolStripMenu.Text = "Supplier";
            this.btnAddSupplierToolStripMenu.Click += new System.EventHandler(this.btnAddSupplierToolStripMenu_Click);
            // 
            // btnEditSupplierToolStripMenu
            // 
            this.btnEditSupplierToolStripMenu.Name = "btnEditSupplierToolStripMenu";
            this.btnEditSupplierToolStripMenu.Size = new System.Drawing.Size(152, 22);
            this.btnEditSupplierToolStripMenu.Text = "Product";
            this.btnEditSupplierToolStripMenu.Click += new System.EventHandler(this.btnEditSupplierToolStripMenu_Click);
            // 
            // btnReportsToolStrip
            // 
            this.btnReportsToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packageReportToolStripMenuItem});
            this.btnReportsToolStrip.Name = "btnReportsToolStrip";
            this.btnReportsToolStrip.Size = new System.Drawing.Size(57, 20);
            this.btnReportsToolStrip.Text = "&Reports";
            // 
            // btnAboutDialog
            // 
            this.btnAboutDialog.Name = "btnAboutDialog";
            this.btnAboutDialog.Size = new System.Drawing.Size(48, 20);
            this.btnAboutDialog.Text = "&About";
            this.btnAboutDialog.Click += new System.EventHandler(this.btnAboutDialog_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMessage,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(69, 17);
            this.lblStatusMessage.Text = "Ready .......";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // uxTimer
            // 
            this.uxTimer.Enabled = true;
            this.uxTimer.Interval = 1750;
            this.uxTimer.Tick += new System.EventHandler(this.uxTimer_Tick);
            // 
            // tsToolStip
            // 
            this.tsToolStip.Enabled = false;
            this.tsToolStip.Location = new System.Drawing.Point(0, 24);
            this.tsToolStip.Name = "tsToolStip";
            this.tsToolStip.Size = new System.Drawing.Size(916, 25);
            this.tsToolStip.TabIndex = 4;
            this.tsToolStip.Text = "toolStrip1";
            this.tsToolStip.Visible = false;
            // 
            // btnackagesToolStrip
            // 
            this.btnackagesToolStrip.Name = "btnackagesToolStrip";
            this.btnackagesToolStrip.Size = new System.Drawing.Size(152, 22);
            this.btnackagesToolStrip.Text = "Packages";
            this.btnackagesToolStrip.Click += new System.EventHandler(this.btnackagesToolStrip_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.toolStripSeparator1,
            this.layoutToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toolBarToolStripMenuItem.Text = "&ToolBar";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.toolBarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // layoutToolStripMenuItem
            // 
            this.layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.cascadeToolStripMenuItem});
            this.layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            this.layoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.layoutToolStripMenuItem.Text = "Layout";
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.horizontalToolStripMenuItem.Text = "&Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verticalToolStripMenuItem.Text = "&Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // packageReportToolStripMenuItem
            // 
            this.packageReportToolStripMenuItem.Name = "packageReportToolStripMenuItem";
            this.packageReportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.packageReportToolStripMenuItem.Text = "Package Report";
            this.packageReportToolStripMenuItem.Click += new System.EventHandler(this.packageReportToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 541);
            this.Controls.Add(this.tsToolStip);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Travel Experts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExitToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnAddSupplierToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem btnEditSupplierToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem btnReportsToolStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMessage;
        private System.Windows.Forms.Timer uxTimer;
        private System.Windows.Forms.ToolStripMenuItem btnAboutDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStrip tsToolStip;
        private System.Windows.Forms.ToolStripMenuItem btnackagesToolStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem layoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packageReportToolStripMenuItem;
    }
}

