using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace QuanLiTruongHoc
{
    public partial class frmMain : Form
    {
        TabPage tabPage6 = new TabPage();
        TabPage tabPage2 = new TabPage();
        TabPage tabPage3 = new TabPage();
        TabPage tabPage4 = new TabPage();
        TabPage tabPage5 = new TabPage();
        public frmMain()
        {
            InitializeComponent();
            an();
        }
        public void romove()
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
        }
        private void btnhocsinh_Click(object sender, EventArgs e)
        {
            romove();
            frmHocSinh f = new frmHocSinh();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(f);
            f.Visible = true;
            tabPage2.Text = "Học Sinh";
            tabControl1.TabPages.Add(tabPage2);
        }

        private void btngiaovien_Click(object sender, EventArgs e)
        {
            romove();
            frmGiaoVien f = new frmGiaoVien();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(f);
            f.Visible = true;
            tabPage3.Text = "Giáo Viên";
            tabControl1.TabPages.Add(tabPage3);
        }

        private void btnlop_Click(object sender, EventArgs e)
        {
            romove();
            frmLop f = new frmLop();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(f);
            f.Visible = true;
            tabPage4.Text = "Lớp";
            tabControl1.TabPages.Add(tabPage4);
        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoan f = new frmThemTaiKhoan();
            f.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.ShowDialog();
        }

        private void btnbomon_Click(object sender, EventArgs e)
        {
            romove();
            frmBoMon f = new frmBoMon();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage5.Controls.Add(f);
            f.Visible = true;
            tabPage5.Text = "Bộ Môn";
            tabControl1.TabPages.Add(tabPage5);
        }
        private void ckhienthi_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = ckhienthi.Checked ? false : true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (TaiKhoanDAO.DangNhap(txtTaiKhoan.Text, txtMK.Text) == true)
            {
                tabControl1.TabPages.Remove(tabPage1);
                hien();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
            }
        }
        public void an()
        {
            btnhocsinh.Enabled = false;
            btnlop.Enabled = false;
            btngiaovien.Enabled = false;
            btnbomon.Enabled = false;
            btntaikhoan.Enabled = false;
            btntrogiup.Enabled = false;
        }
        public void hien()
        {
            btnhocsinh.Enabled = true;
            btnlop.Enabled = true;
            btngiaovien.Enabled = true;
            btnbomon.Enabled = true;
            btntaikhoan.Enabled = true;
            btntrogiup.Enabled = true;
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            romove();
            frmTroGiup f = new frmTroGiup();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabPage6.Controls.Add(f);
            f.Visible = true;
            tabPage6.Text = "Trợ Giúp";
            tabControl1.TabPages.Add(tabPage6);
        }
    }
}
