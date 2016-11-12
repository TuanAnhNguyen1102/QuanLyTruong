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
    public partial class frmLop : Form
    {
        int ktluu = 0;
        public frmLop()
        {
            InitializeComponent();
            btnLuu.Visible = false;
            an();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            dgvLopHoc.DataSource = LopDAO.LoadDataLop();
            SetHeaderColumn();
            LoadComboBox();
        }
        public void SetHeaderColumn()
        {

            dgvLopHoc.Columns["TenLop"].HeaderText = "Tên Lớp";
            dgvLopHoc.Columns["SoLuong"].HeaderText = "Số lượng";
        }

        public void LoadComboBox()
        {
            cboTenLopTruong.DataSource = HocSinhDAO.LoadDataHocSinh();
            cboTenLopTruong.ValueMember = "IDHocSinh";
            cboTenLopTruong.DisplayMember = "HoTen";
            cboTenGiaoVien.DataSource = GiaoVienDAO.LoadDataGiaoVien();
            cboTenGiaoVien.ValueMember = "IDGiaoVien";
            cboTenGiaoVien.DisplayMember = "HoTen";
        }

        private void dgvLopHoc_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvLopHoc.SelectedRows[0];
            txtIDLop.Text = dr.Cells["IDLop"].Value.ToString();
            txtSoLuongHS.Text = dr.Cells["SoLuong"].Value.ToString();
            txtTenLop.Text = dr.Cells["TenLop"].Value.ToString();
            cboTenGiaoVien.SelectedValue = dr.Cells["IDChuNhiem"].Value;
            cboTenLopTruong.SelectedValue = dr.Cells["IDLopTruong"].Value;
        }
        void hien()
        {
            txtSoLuongHS.ReadOnly = false;
            txtTenLop.ReadOnly = false;
            cboTenGiaoVien.Enabled = true;
            cboTenLopTruong.Enabled = true;
            txtSoLuongHS.Enabled = true;
        }
        void an()
        {
            txtIDLop.ReadOnly = true;
            txtSoLuongHS.ReadOnly = true;
            txtTenLop.ReadOnly = true;
            cboTenGiaoVien.Enabled = false;
            cboTenLopTruong.Enabled = false;
            btnhuy.Visible = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenLop.Text == "") { MessageBox.Show("Bạn chưa chọn lớp cần sửa"); return; }
            btnLuu.Visible = true;
            btnhuy.Visible = true;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            hien();
            ktluu = 1;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            btnhuy.Visible = true;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            hien();
            txtSoLuongHS.ReadOnly = true;
            ktluu = 2;
            DataTable maxid = new DataTable();
            maxid = LopDAO.MaxIDLop();
            int idlop;
            try
            {
                idlop = (int)maxid.Rows[0][0];
            }
            catch
            {
                idlop = 0;
            }
            idlop++;
            txtIDLop.Text = idlop.ToString();
            int soluong = 0;
            txtSoLuongHS.Text = soluong.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = false;
            LopDTO l = new LopDTO();
            int id = 0;
            int.TryParse(txtIDLop.Text.ToString(), out id);
            l.IDLop = id;
            int sl = 0;
            int.TryParse(txtSoLuongHS.Text.ToString(), out sl);
            l.SoLuong = sl;
            l.TenLop = txtTenLop.Text.ToString();
            try { l.IDChuNhiem = (int)cboTenGiaoVien.SelectedValue; }
            catch { }
            try { l.IDLopTruong = (int)cboTenLopTruong.SelectedValue; }
            catch { }
            // khi bấm phím sửa 
            if (ktluu == 1)
            {
                try
                {
                    LopDAO.SuaLop(l);
                    MessageBox.Show("Đã sửa thành công");
                    dgvLopHoc.DataSource = LopDAO.LoadDataLop();
                }
                catch
                {
                    MessageBox.Show("Chưa sửa được!");
                }
             }
             // khi bấm phím lưu
             if (ktluu == 2)
             {
                 try
                 {
                     LopDAO.ThemLop(l);
                     MessageBox.Show("Đã thêm thành công");
                     dgvLopHoc.DataSource = LopDAO.LoadDataLop();
                 }
                 catch
                 {
                     MessageBox.Show("Có lỗi chưa thêm được!");
                 }
              }
              an();
              ktluu = 0;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            LopDTO l = new LopDTO();
            int id = 0;
            try
            {
                int.TryParse(txtIDLop.Text.ToString(), out id);
                l.IDLop = id;
                LopDAO.XoaLop(l);
                MessageBox.Show("Đã xóa thành công");
                dgvLopHoc.DataSource = LopDAO.LoadDataLop();
            }
            catch
            {
                MessageBox.Show("Có lỗi , làm lại !");
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string strtim = txtTimKiem.Text.ToString();
            dgvLopHoc.DataSource = LopDAO.TimKiem(strtim);
            DataTable test = new DataTable();
            test = LopDAO.TimKiem(strtim);
            try
            {
                int kt = (int)test.Rows[0][0];
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu !");
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strtim = txtTimKiem.Text.ToString();
                dgvLopHoc.DataSource = LopDAO.TimKiem(strtim);
                DataTable test = new DataTable();
                test = LopDAO.TimKiem(strtim);
                try
                {
                    int kt = (int)test.Rows[0][0];
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu !");
                }
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = false;
            btnhuy.Visible = false;
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            txtIDLop.Text = "";
            txtSoLuongHS.Text = "";
            txtTenLop.Text = "";
            cboTenGiaoVien.Text = "";
            cboTenLopTruong.Text = "";
        }
    }
}
