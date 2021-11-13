
namespace V4mp1r3
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.监听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务端生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.免责声明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v4mp1r3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.作者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.远程终端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务端管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.卸载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.监听ToolStripMenuItem,
            this.服务端生成ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 监听ToolStripMenuItem
            // 
            this.监听ToolStripMenuItem.Name = "监听ToolStripMenuItem";
            this.监听ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.监听ToolStripMenuItem.Text = "监听";
            this.监听ToolStripMenuItem.Click += new System.EventHandler(this.监听ToolStripMenuItem_Click);
            // 
            // 服务端生成ToolStripMenuItem
            // 
            this.服务端生成ToolStripMenuItem.Name = "服务端生成ToolStripMenuItem";
            this.服务端生成ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.服务端生成ToolStripMenuItem.Text = "服务端生成";
            this.服务端生成ToolStripMenuItem.Click += new System.EventHandler(this.服务端生成ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.免责声明ToolStripMenuItem,
            this.v4mp1r3ToolStripMenuItem,
            this.作者ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 免责声明ToolStripMenuItem
            // 
            this.免责声明ToolStripMenuItem.Name = "免责声明ToolStripMenuItem";
            this.免责声明ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.免责声明ToolStripMenuItem.Text = "免责声明";
            this.免责声明ToolStripMenuItem.Click += new System.EventHandler(this.免责声明ToolStripMenuItem_Click);
            // 
            // v4mp1r3ToolStripMenuItem
            // 
            this.v4mp1r3ToolStripMenuItem.Name = "v4mp1r3ToolStripMenuItem";
            this.v4mp1r3ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.v4mp1r3ToolStripMenuItem.Text = "V4mp1r3";
            this.v4mp1r3ToolStripMenuItem.Click += new System.EventHandler(this.v4mp1r3ToolStripMenuItem_Click);
            // 
            // 作者ToolStripMenuItem
            // 
            this.作者ToolStripMenuItem.Name = "作者ToolStripMenuItem";
            this.作者ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.作者ToolStripMenuItem.Text = "作者";
            this.作者ToolStripMenuItem.Click += new System.EventHandler(this.作者ToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 423);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IP";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.远程终端ToolStripMenuItem,
            this.服务端管理ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // 远程终端ToolStripMenuItem
            // 
            this.远程终端ToolStripMenuItem.Name = "远程终端ToolStripMenuItem";
            this.远程终端ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.远程终端ToolStripMenuItem.Text = "远程终端";
            this.远程终端ToolStripMenuItem.Click += new System.EventHandler(this.远程终端ToolStripMenuItem_Click);
            // 
            // 服务端管理ToolStripMenuItem
            // 
            this.服务端管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.断开连接ToolStripMenuItem,
            this.卸载ToolStripMenuItem});
            this.服务端管理ToolStripMenuItem.Name = "服务端管理ToolStripMenuItem";
            this.服务端管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.服务端管理ToolStripMenuItem.Text = "服务端管理";
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // 卸载ToolStripMenuItem
            // 
            this.卸载ToolStripMenuItem.Name = "卸载ToolStripMenuItem";
            this.卸载ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.卸载ToolStripMenuItem.Text = "卸载";
            this.卸载ToolStripMenuItem.Click += new System.EventHandler(this.卸载ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "V4mp1r3 V0.1 测试版[20211112]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 监听ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 服务端生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 免责声明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v4mp1r3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 作者ToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 远程终端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 服务端管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 卸载ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

