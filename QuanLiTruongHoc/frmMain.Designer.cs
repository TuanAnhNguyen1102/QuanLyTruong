namespace QuanLiTruongHoc
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnhocsinh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnlop = new System.Windows.Forms.ToolStripMenuItem();
            this.btngiaovien = new System.Windows.Forms.ToolStripMenuItem();
            this.btnbomon = new System.Windows.Forms.ToolStripMenuItem();
            this.btntaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnthemtaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.btndoitaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckhienthi = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btntrogiup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnhocsinh,
            this.btnlop,
            this.btngiaovien,
            this.btnbomon,
            this.btntaikhoan,
            this.btntrogiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1054, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnhocsinh
            // 
            this.btnhocsinh.Name = "btnhocsinh";
            this.btnhocsinh.Size = new System.Drawing.Size(67, 20);
            this.btnhocsinh.Text = "Học Sinh";
            this.btnhocsinh.Click += new System.EventHandler(this.btnhocsinh_Click);
            // 
            // btnlop
            // 
            this.btnlop.Name = "btnlop";
            this.btnlop.Size = new System.Drawing.Size(39, 20);
            this.btnlop.Text = "Lớp";
            this.btnlop.Click += new System.EventHandler(this.btnlop_Click);
            // 
            // btngiaovien
            // 
            this.btngiaovien.Name = "btngiaovien";
            this.btngiaovien.Size = new System.Drawing.Size(69, 20);
            this.btngiaovien.Text = "Giáo Viên";
            this.btngiaovien.Click += new System.EventHandler(this.btngiaovien_Click);
            // 
            // btnbomon
            // 
            this.btnbomon.Name = "btnbomon";
            this.btnbomon.Size = new System.Drawing.Size(61, 20);
            this.btnbomon.Text = "Bộ Môn";
            this.btnbomon.Click += new System.EventHandler(this.btnbomon_Click);
            // 
            // btntaikhoan
            // 
            this.btntaikhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnthemtaikhoan,
            this.btndoitaikhoan});
            this.btntaikhoan.Name = "btntaikhoan";
            this.btntaikhoan.Size = new System.Drawing.Size(71, 20);
            this.btntaikhoan.Text = "Tài Khoản";
            // 
            // btnthemtaikhoan
            // 
            this.btnthemtaikhoan.Name = "btnthemtaikhoan";
            this.btnthemtaikhoan.Size = new System.Drawing.Size(160, 22);
            this.btnthemtaikhoan.Text = "Thêm Tài Khoản";
            this.btnthemtaikhoan.Click += new System.EventHandler(this.thêmTàiKhoảnToolStripMenuItem_Click);
            // 
            // btndoitaikhoan
            // 
            this.btndoitaikhoan.Name = "btndoitaikhoan";
            this.btndoitaikhoan.Size = new System.Drawing.Size(160, 22);
            this.btndoitaikhoan.Text = "Đổi Mật Khẩu";
            this.btndoitaikhoan.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1054, 553);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1046, 527);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.ckhienthi);
            this.groupBox1.Controls.Add(this.btnDangNhap);
            this.groupBox1.Controls.Add(this.txtMK);
            this.groupBox1.Controls.Add(this.txtTaiKhoan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(391, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 163);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // ckhienthi
            // 
            this.ckhienthi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckhienthi.AutoSize = true;
            this.ckhienthi.Location = new System.Drawing.Point(28, 118);
            this.ckhienthi.Name = "ckhienthi";
            this.ckhienthi.Size = new System.Drawing.Size(66, 17);
            this.ckhienthi.TabIndex = 16;
            this.ckhienthi.Text = "Hiển Thị";
            this.ckhienthi.UseVisualStyleBackColor = true;
            this.ckhienthi.CheckedChanged += new System.EventHandler(this.ckhienthi_CheckedChanged_1);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.Location = new System.Drawing.Point(143, 110);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(70, 30);
            this.btnDangNhap.TabIndex = 15;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtMK
            // 
            this.txtMK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMK.Location = new System.Drawing.Point(120, 68);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(135, 20);
            this.txtMK.TabIndex = 14;
            this.txtMK.UseSystemPasswordChar = true;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTaiKhoan.Location = new System.Drawing.Point(120, 24);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(135, 20);
            this.txtTaiKhoan.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mật Khẩu";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tài Khoản";
            // 
            // btntrogiup
            // 
            this.btntrogiup.Name = "btntrogiup";
            this.btntrogiup.Size = new System.Drawing.Size(64, 20);
            this.btntrogiup.Text = "Trợ Giúp";
            this.btntrogiup.Click += new System.EventHandler(this.trợGiúpToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 577);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem btnthemtaikhoan;
        private System.Windows.Forms.ToolStripMenuItem btndoitaikhoan;
        public System.Windows.Forms.ToolStripMenuItem btnhocsinh;
        public System.Windows.Forms.ToolStripMenuItem btngiaovien;
        public System.Windows.Forms.ToolStripMenuItem btnlop;
        public System.Windows.Forms.ToolStripMenuItem btnbomon;
        public System.Windows.Forms.ToolStripMenuItem btntaikhoan;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckhienthi;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem btntrogiup;

    }
}

