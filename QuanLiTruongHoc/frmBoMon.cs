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
    public partial class frmBoMon : Form
    {
        public frmBoMon()
        {
            InitializeComponent();
        }
        int luu = 0;
        private void frmBoMon_Load(object sender, EventArgs e)
        {
            dgvBoMon.DataSource = BoMonDAO.LoadDataBoMon();
            btnLuu.Visible = false;
            SetHeaderColumn();
            an();
        }
        public void SetHeaderColumn()
        {
            dgvBoMon.Columns["IDMon"].HeaderText = "Mã Môn";
            dgvBoMon.Columns["IDMon"].Width = 100;
            dgvBoMon.Columns["TenMon"].HeaderText = "Tên Môn";
            dgvBoMon.Columns["SoLuong"].HeaderText = "Số Lượng Giáo Viên";
            dgvBoMon.Columns["Truong"].HeaderText = "Trưởng Bộ Môn";
        }
        public void an()
        {
            txtIdMon.Enabled = false;
            txtTenMon.Enabled = false;
            txtSoluong.Enabled = false;
            cboTruongBM.Enabled = false;
        }
        public void hien()
        {
            txtSoluong.Enabled = true;
            txtIdMon.Enabled = true;
            txtTenMon.Enabled = true;
            cboTruongBM.Enabled = true;
        }

        private void dgvBoMon_Click(object sender, EventArgs e)
        {
            luu = 0;

            DataGridViewRow dr = dgvBoMon.SelectedRows[0];
            txtIdMon.Text = dr.Cells["IDMon"].Value.ToString();
            txtSoluong.Text = dr.Cells["SoLuong"].Value.ToString();
            txtTenMon.Text = dr.Cells["TenMon"].Value.ToString();
            cboTruongBM.DataSource = GiaoVienDAO.LayThongTinGiaoVienVien((int)dr.Cells["IDMon"].Value);
            cboTruongBM.ValueMember = "IDGiaoVien";
            cboTruongBM.DisplayMember = "HoTen"; //hiển thị ra combobox theo tên giáo viên chứ không phải id!
            cboTruongBM.SelectedValue = (int)dr.Cells["IDMon"].Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hien();
            btnLuu.Visible = true;
            DataTable maxid = new DataTable();
            maxid = BoMonDAO.ID_BMMax();
            int idbm = (int)maxid.Rows[0][0];
            idbm++;
            txtIdMon.Text = idbm.ToString();
            txtTenMon.Focus();
            txtSoluong.Text = "0";
            cboTruongBM.Enabled = false;
            cboTruongBM.ValueMember = "IDGiaoVien";
            cboTruongBM.DisplayMember = "HoTen";
            luu = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            hien();
            DataGridViewRow dr = dgvBoMon.SelectedRows[0];
            btnLuu.Visible = true;
            cboTruongBM.DataSource = GiaoVienDAO.LayThongTinGiaoVienVien((int)dr.Cells["IDMon"].Value);
            cboTruongBM.ValueMember = "IDGiaoVien";
            cboTruongBM.DisplayMember = "HoTen";
            luu = 2;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            BoMonDTO bm = new BoMonDTO();
            bm.IDMon = int.Parse(txtIdMon.Text);
            bm.TenMon = txtTenMon.Text;
            bm.IDTruongBoMon = (int)cboTruongBM.SelectedValue;
            bm.SoLuong = int.Parse(txtSoluong.Text);
            if (luu == 0)
            {
                MessageBox.Show("Bạn chưa thao tác");
            }
            try
            {
                if (luu == 1)
                {
                    if (BoMonDAO.CheckTenMon(txtTenMon.Text) == false)
                    {
                        BoMonDAO.ThemBM(bm);
                        dgvBoMon.DataSource = BoMonDAO.LoadDataBoMon();
                        btnLuu.Visible = false;
                        an();
                        MessageBox.Show("Thêm thành công !");

                    }
                    else
                    {
                        MessageBox.Show("Tên này đã có");
                    }

                }
            }
            catch
            {

                MessageBox.Show("Chưa thêm được !");
            }
            try
            {
                if (luu == 2)
                {
                    BoMonDAO.SuaBM(bm);
                    dgvBoMon.DataSource = BoMonDAO.LoadDataBoMon();
                    btnLuu.Visible = false;
                    an();
                    MessageBox.Show("Sửa thành công !");
                }
            }
            catch
            {
                MessageBox.Show("Chưa sửa được !");
            }

            luu = 0;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtIdMon.Text == "")
                MessageBox.Show("Bạn chưa chọn Bộ Môn");
            else
            {
                BoMonDTO bm = new BoMonDTO();
                bm.IDMon = int.Parse(txtIdMon.Text);
                BoMonDAO.XoaBM(bm);
                MessageBox.Show("Bạn đã xóa bộ môn thành công");
                dgvBoMon.DataSource = BoMonDAO.LoadDataBoMon();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvBoMon.DataSource = BoMonDAO.SearchBM(txttimkiem.Text);
        }

        private void txttimkiem_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvBoMon.DataSource = BoMonDAO.SearchBM(txttimkiem.Text);
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }
    }
}
