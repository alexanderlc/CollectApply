namespace CollectApply
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewLog = new Utils.DoubleBufferListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(656, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSystem,
            this.查看ToolStripMenuItem,
            this.ToolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemSystem
            // 
            this.ToolStripMenuItemSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemConfig,
            this.ToolStripMenuItemLog,
            this.ToolStripMenuItemExit});
            this.ToolStripMenuItemSystem.Name = "ToolStripMenuItemSystem";
            this.ToolStripMenuItemSystem.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItemSystem.Text = "系统";
            // 
            // ToolStripMenuItemConfig
            // 
            this.ToolStripMenuItemConfig.Name = "ToolStripMenuItemConfig";
            this.ToolStripMenuItemConfig.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemConfig.Text = "系统配置";
            this.ToolStripMenuItemConfig.Click += new System.EventHandler(this.ToolStripMenuItemConfig_Click);
            // 
            // ToolStripMenuItemLog
            // 
            this.ToolStripMenuItemLog.Name = "ToolStripMenuItemLog";
            this.ToolStripMenuItemLog.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemLog.Text = "查看日志";
            this.ToolStripMenuItemLog.Click += new System.EventHandler(this.ToolStripMenuItemLog_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemExit.Text = "退出";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpenFolder});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // ToolStripMenuItemOpenFolder
            // 
            this.ToolStripMenuItemOpenFolder.Name = "ToolStripMenuItemOpenFolder";
            this.ToolStripMenuItemOpenFolder.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItemOpenFolder.Text = "打开Excel目录";
            this.ToolStripMenuItemOpenFolder.Click += new System.EventHandler(this.ToolStripMenuItemOpenFolder_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItemHelp.Text = "帮助";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemAbout.Text = "关于";
            // 
            // listViewLog
            // 
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderEvent});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.GridLines = true;
            this.listViewLog.Location = new System.Drawing.Point(0, 25);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(656, 273);
            this.listViewLog.TabIndex = 2;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "时间";
            this.columnHeaderTime.Width = 150;
            // 
            // columnHeaderEvent
            // 
            this.columnHeaderEvent.Text = "事件";
            this.columnHeaderEvent.Width = 514;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 320);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "在线融资申请邮件收集器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSystem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLog;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private Utils.DoubleBufferListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeaderEvent;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
    }
}

