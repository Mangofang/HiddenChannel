namespace HiddenChannel
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ListViewEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Join = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PublicRoomPage = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JoinedRoomPage = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MyRoomPage = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JoinedListViewEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateRoomButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.MyCreateLiewEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RoomEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.DelRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.ListViewEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.PublicRoomPage.SuspendLayout();
            this.JoinedRoomPage.SuspendLayout();
            this.MyRoomPage.SuspendLayout();
            this.JoinedListViewEdit.SuspendLayout();
            this.MyCreateLiewEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListViewEdit
            // 
            this.ListViewEdit.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ListViewEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Join,
            this.Info});
            this.ListViewEdit.Name = "Join";
            this.ListViewEdit.Size = new System.Drawing.Size(137, 80);
            // 
            // Join
            // 
            this.Join.Name = "Join";
            this.Join.Size = new System.Drawing.Size(136, 38);
            this.Join.Text = "加入";
            this.Join.Click += new System.EventHandler(this.Join_Click);
            // 
            // Info
            // 
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(136, 38);
            this.Info.Text = "详细";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "点击登录";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PublicRoomPage);
            this.tabControl1.Controls.Add(this.JoinedRoomPage);
            this.tabControl1.Controls.Add(this.MyRoomPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1304, 758);
            this.tabControl1.TabIndex = 4;
            // 
            // PublicRoomPage
            // 
            this.PublicRoomPage.Controls.Add(this.listView1);
            this.PublicRoomPage.Location = new System.Drawing.Point(8, 39);
            this.PublicRoomPage.Margin = new System.Windows.Forms.Padding(4);
            this.PublicRoomPage.Name = "PublicRoomPage";
            this.PublicRoomPage.Padding = new System.Windows.Forms.Padding(4);
            this.PublicRoomPage.Size = new System.Drawing.Size(1288, 711);
            this.PublicRoomPage.TabIndex = 0;
            this.PublicRoomPage.Text = "公共房间";
            this.PublicRoomPage.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 15);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1276, 681);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "序号";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "房间ID";
            this.columnHeader10.Width = 112;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "所有者";
            this.columnHeader11.Width = 167;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "介绍";
            this.columnHeader12.Width = 298;
            // 
            // JoinedRoomPage
            // 
            this.JoinedRoomPage.Controls.Add(this.listView2);
            this.JoinedRoomPage.Location = new System.Drawing.Point(8, 39);
            this.JoinedRoomPage.Margin = new System.Windows.Forms.Padding(4);
            this.JoinedRoomPage.Name = "JoinedRoomPage";
            this.JoinedRoomPage.Padding = new System.Windows.Forms.Padding(4);
            this.JoinedRoomPage.Size = new System.Drawing.Size(1288, 711);
            this.JoinedRoomPage.TabIndex = 1;
            this.JoinedRoomPage.Text = "加入的房间";
            this.JoinedRoomPage.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(6, 15);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1276, 681);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "房间ID";
            this.columnHeader2.Width = 112;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "所有者";
            this.columnHeader3.Width = 167;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "介绍";
            this.columnHeader4.Width = 298;
            // 
            // MyRoomPage
            // 
            this.MyRoomPage.Controls.Add(this.listView3);
            this.MyRoomPage.Location = new System.Drawing.Point(8, 39);
            this.MyRoomPage.Margin = new System.Windows.Forms.Padding(4);
            this.MyRoomPage.Name = "MyRoomPage";
            this.MyRoomPage.Size = new System.Drawing.Size(1288, 711);
            this.MyRoomPage.TabIndex = 2;
            this.MyRoomPage.Text = "我创建的房间";
            this.MyRoomPage.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(6, 15);
            this.listView3.Margin = new System.Windows.Forms.Padding(4);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(1276, 681);
            this.listView3.TabIndex = 3;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView3_MouseClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "序号";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "房间ID";
            this.columnHeader6.Width = 112;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "所有者";
            this.columnHeader7.Width = 167;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "介绍";
            this.columnHeader8.Width = 298;
            // 
            // JoinedListViewEdit
            // 
            this.JoinedListViewEdit.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.JoinedListViewEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRoom,
            this.QuitRoom});
            this.JoinedListViewEdit.Name = "JoinedListViewEdit";
            this.JoinedListViewEdit.Size = new System.Drawing.Size(301, 124);
            // 
            // OpenRoom
            // 
            this.OpenRoom.Name = "OpenRoom";
            this.OpenRoom.Size = new System.Drawing.Size(300, 38);
            this.OpenRoom.Text = "进入";
            this.OpenRoom.Click += new System.EventHandler(this.OpenRoom_Click);
            // 
            // QuitRoom
            // 
            this.QuitRoom.Name = "QuitRoom";
            this.QuitRoom.Size = new System.Drawing.Size(300, 38);
            this.QuitRoom.Text = "退出房间";
            this.QuitRoom.Click += new System.EventHandler(this.QuitRoom_Click);
            // 
            // CreateRoomButton
            // 
            this.CreateRoomButton.Location = new System.Drawing.Point(425, 13);
            this.CreateRoomButton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateRoomButton.Name = "CreateRoomButton";
            this.CreateRoomButton.Size = new System.Drawing.Size(144, 43);
            this.CreateRoomButton.TabIndex = 6;
            this.CreateRoomButton.Text = "创建房间";
            this.CreateRoomButton.UseVisualStyleBackColor = true;
            this.CreateRoomButton.Click += new System.EventHandler(this.CreateRoomButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(273, 13);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(4);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(144, 43);
            this.LogoutButton.TabIndex = 7;
            this.LogoutButton.Text = "注销登录";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // MyCreateLiewEdit
            // 
            this.MyCreateLiewEdit.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MyCreateLiewEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RoomEdit,
            this.DelRoom});
            this.MyCreateLiewEdit.Name = "contextMenuStrip1";
            this.MyCreateLiewEdit.Size = new System.Drawing.Size(185, 80);
            // 
            // RoomEdit
            // 
            this.RoomEdit.Name = "RoomEdit";
            this.RoomEdit.Size = new System.Drawing.Size(184, 38);
            this.RoomEdit.Text = "编辑";
            // 
            // DelRoom
            // 
            this.DelRoom.Name = "DelRoom";
            this.DelRoom.Size = new System.Drawing.Size(184, 38);
            this.DelRoom.Text = "删除房间";
            this.DelRoom.Click += new System.EventHandler(this.DelRoom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 837);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.CreateRoomButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HiddenChannel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ListViewEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.PublicRoomPage.ResumeLayout(false);
            this.JoinedRoomPage.ResumeLayout(false);
            this.MyRoomPage.ResumeLayout(false);
            this.JoinedListViewEdit.ResumeLayout(false);
            this.MyCreateLiewEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip ListViewEdit;
        private System.Windows.Forms.ToolStripMenuItem Join;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PublicRoomPage;
        private System.Windows.Forms.TabPage JoinedRoomPage;
        private System.Windows.Forms.TabPage MyRoomPage;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        protected System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        protected System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        protected System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ContextMenuStrip JoinedListViewEdit;
        private System.Windows.Forms.ToolStripMenuItem OpenRoom;
        private System.Windows.Forms.ToolStripMenuItem QuitRoom;
        private System.Windows.Forms.Button CreateRoomButton;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.ContextMenuStrip MyCreateLiewEdit;
        private System.Windows.Forms.ToolStripMenuItem RoomEdit;
        private System.Windows.Forms.ToolStripMenuItem DelRoom;
    }
}

