using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using DAO;
namespace QuanLiTruongHoc
{
    public partial class frmGiaoVien : Form
    {
        public static SqlConnection con;
        static int choice_save;// =1 voi THEM
        // =2 voi sua
        static int choice_return;// =1 modieukhien
        //=2 thoat;
        // static int choice_click;
        public frmGiaoVien()
        {
            InitializeComponent();
            antext();
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            dgvGiaoVien.DataSource = GiaoVienDAO.LoadDataGiaoVien();
            SetHeaderColumn();
            txtHienthi.Enabled = false;
            btnLưu.Enabled = false;
            LoadComboBox();
        }
        public void SetHeaderColumn()
        {
            dgvGiaoVien.Columns["IDGiaoVien"].HeaderText = "Mã giáo viên";
            dgvGiaoVien.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvGiaoVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvGiaoVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvGiaoVien.Columns["IDMon"].HeaderText = "Đang giảng dạy";
            dgvGiaoVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvGiaoVien.Columns["SDT"].HeaderText = "SĐT";
        }
        public void antext()
        {
            txtMaGV.Enabled = false;
            txtHoTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtSDT.Enabled = false;
            cboGioiTinh.Enabled = false;
            cboIDMon.Enabled = false;
            txtDiachi.Enabled = false;
        }
        public void hientext()
        {
            txtMaGV.Enabled = true;
            txtHoTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            cboGioiTinh.Enabled = true;
            cboIDMon.Enabled = true;
            txtDiachi.Enabled = true;
        }
        public void ResetText()
        {
            txtDiachi.ResetText();
            txtHienthi.ResetText();
            txtHoTen.ResetText();
            txtMaGV.ResetText();
            txtSDT.ResetText();
            LoadComboBox();

        }
        // mở khóa điều khiển
        public void MoDieuKhien()
        {
            txtMaGV.Enabled = true;
            cboIDMon.Enabled = true;
            btnLưu.Enabled = true;
            btnRefresh.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }

        public void LoadComboBox()
        {
            cboIDMon.DataSource = BoMonDAO.LoadDataBoMon();
            cboIDMon.ValueMember = "IDMon";
            cboIDMon.DisplayMember = "TenMon";
            cboGioiTinh.Text = "Nam";
        }
        private void dgvGiaoVien_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow dr = dgvGiaoVien.SelectedRows[0];
                txtMaGV.Text = dr.Cells["IDGiaoVien"].Value.ToString();
                txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
                // txtNgaySinh.Text = dr.Cells["IDGiaoVien"].Value.ToString();
                cboGioiTinh.Text = dr.Cells["GioiTinh"].Value.ToString();
                // txtMaMonHoc.Text = dr.Cells["IDMon"].Value.ToString();
                txtDiachi.Text = dr.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = "0" + dr.Cells["SDT"].Value.ToString();
                DateTime dt;
                DateTime.TryParse(dr.Cells["NgaySinh"].Value.ToString(), out dt);
                if (dt.Year > 1995)
                {
                    dtpNgaySinh.Value = DateTimePicker.MinimumDateTime;
                }
                else
                {
                    dtpNgaySinh.Value = dt;
                }
                //txtMaMonHoc.DataBindings.Clear();
                //txtMaMonHoc.DataBindings.Add("Text", GiaoVienDAO.Lay_ThongtinMonhoc((int)dr.Cells["IDMon"].Value), "TenMon");
                // lay cot [tenmon
                cboIDMon.DataSource = GiaoVienDAO.Lay_ThongtinMonhoc((int)dr.Cells["IDMon"].Value);
                cboIDMon.ValueMember = "IDMon";
                cboIDMon.DisplayMember = "TenMon";
                //cboIDMon.SelectedValue = (int)dr.Cells["
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // lưu, thêm active
            hientext();
            btnLưu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnRefresh.Enabled = false;
            choice_save = 1;
            choice_return = 1;
            txtMaGV.Focus();
            //
            //if((int)GiaoVienDAO.getIDmin().Rows[0]["IDMin"]+1 <0)
            // dong 0 cot IDMax;

            // dem so dong cua IDGiaovien
            // rows[0] -> row[n-2]
            // neu ma so dang truoc kem so dang sau !=1 donvi thi tao cai ma so do +1
            // vong lap for chay tu 0-> n-2;
            if ((int)GiaoVienDAO.countID().Rows[0]["numID"] == (int)GiaoVienDAO.getIDmax().Rows[0]["IDMax"])
                txtMaGV.Text = ((int)GiaoVienDAO.getIDmax().Rows[0]["IDMax"] + 1).ToString();

            if ((int)GiaoVienDAO.countID().Rows[0]["numID"] != (int)GiaoVienDAO.getIDmax().Rows[0]["IDMax"])
            {
                for (int i = 1; i < (int)GiaoVienDAO.countID().Rows[0]["numID"]; i++)
                {
                    if ((int)GiaoVienDAO.getID().Rows[0]["ID"] > 1)
                    {
                        txtMaGV.Text = ((int)GiaoVienDAO.getID().Rows[0]["ID"] - 1).ToString();
                        break;
                    }
                    if (((int)GiaoVienDAO.getID().Rows[i]["ID"] - (int)GiaoVienDAO.getID().Rows[i - 1]["ID"]) != 1)
                    {
                        txtMaGV.Text = ((int)GiaoVienDAO.getID().Rows[i - 1]["ID"] + 1).ToString();
                        break;
                    }
                }
            }
            txtMaGV.Enabled = false;
            // txtMaMonHoc.Enabled = false;
            LoadComboBox();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvGiaoVien.DataSource = GiaoVienDAO.LoadDataGiaoVien();
            ResetText();
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
            GiaoVienDTO gv = new GiaoVienDTO();
            antext();
            gv.IDGiaoVien = int.Parse(txtMaGV.Text);
            gv.HoTen = txtHoTen.Text;
            gv.NgaySinh = dtpNgaySinh.Value.ToShortDateString();
            gv.GioiTinh = cboGioiTinh.Text;
            gv.DiaChi = txtDiachi.Text;
            gv.SDT = txtSDT.Text;
            gv.IDMon = (int)(cboIDMon.SelectedValue);
            if (choice_save == 1)
            {
                try
                {
                    GiaoVienDAO.ThemGV(gv);
                    dgvGiaoVien.DataSource = GiaoVienDAO.HienThiYeuCau(gv);
                    MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Bạn lưu chưa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (choice_save == 2)
            {
                if (txtMaGV.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        GiaoVienDAO.SuaGiaoVien(gv);
                        dgvGiaoVien.DataSource = GiaoVienDAO.HienThiYeuCau(gv);
                        MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Bạn sửa bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            MoDieuKhien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            hientext();
            btnRefresh.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLưu.Enabled = true;
            btnSua.Enabled = true;
            choice_save = 2;
            choice_return = 1;
            txtMaGV.Enabled = false;
            dgvGiaoVien.Enabled = false;
            LoadComboBox();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn giáo viên");
            }
            else
            {
                GiaoVienDTO gv = new GiaoVienDTO();
                gv.IDGiaoVien = int.Parse(txtMaGV.Text);
                GiaoVienDAO.XoaGV(gv);
                MessageBox.Show("Bạn đã xóa giáo viên thành công");
                dgvGiaoVien.DataSource = GiaoVienDAO.LoadDataGiaoVien();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvGiaoVien.DataSource = GiaoVienDAO.Search(txtTimkiem.Text);
        }


        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
    }
}
