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
    public partial class frmHocSinh : Form
    {
        enum LuaChon
        {
            Them,
            Sua,
            Xoa,
            Luu
        }
        LuaChon lc;
        public frmHocSinh()
        {
            InitializeComponent();
            btnLuu.Visible = false;
            btnHuy.Visible = false;
        }


        private void SuaHeaderText()
        {
            dgvHocSinh.Columns["IDHocSinh"].HeaderText = "Mã học sinh";
            dgvHocSinh.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvHocSinh.Columns["IDLop"].Visible = false;
            dgvHocSinh.Columns["SDT"].HeaderText = "Điện thoại";
            dgvHocSinh.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvHocSinh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvHocSinh.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvHocSinh.Columns["TenLop"].HeaderText = "Tên Lớp";
        }

        private void LoadDuLieu()
        {
            dgvHocSinh.DataSource = HocSinhDAO.LoadDataHocSinh();
            cboLop.DataSource = LopDAO.LoadDataLop1();
            cboLop.ValueMember = "IDLop";
            cboLop.DisplayMember = "TenLop";
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            DataTable dt = (DataTable)dgvHocSinh.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ac.Add(dt.Rows[i][1].ToString());
            }
            txtTimKiem.AutoCompleteCustomSource = ac;
            ReadOnly();
        }

        private void dgvHocSinh_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvHocSinh.SelectedRows[0];
            txtIDHocSinh.Text = dr.Cells["IDHocSinh"].Value.ToString();
            txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            DateTime dt;
            DateTime.TryParse(dr.Cells["NgaySinh"].Value.ToString(), out dt);
            try
            {
                dtpNgaySinh.Value = dt;
                cboLop.SelectedValue = (int)dr.Cells["IDLop"].Value;
                rdbNam.Checked = dr.Cells["GioiTinh"].Value.ToString().Equals("Nam") ? true : false;
                rdbNu.Checked = dr.Cells["GioiTinh"].Value.ToString().Equals("Nữ") ? true : false;
            }
            catch
            {
                dtpNgaySinh.Value = DateTimePicker.MinimumDateTime;
                rdbNam.Checked = false;
                rdbNu.Checked = false;
                cboLop.SelectedValue = 1;
            }
        }

        private void AnButton()
        {
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThem.Visible = false;
            btnXoa.Visible = false;
            btnSua.Visible = false;
        }

        private void HienButton()
        {
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnThem.Visible = true;
            btnXoa.Visible = true;
            btnSua.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtIDHocSinh.Text = (HocSinhDAO.IDMax() + 1).ToString();
            lc = LuaChon.Them;
            AnButton();
            UnReadOnly();
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }

        private void ThemHocSinh()
        {
            HocSinhDTO hs = new HocSinhDTO();
            hs.HoTen = txtHoTen.Text;
            hs.GioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
            hs.SDT = txtSDT.Text;
            hs.NgaySinh = dtpNgaySinh.Value.ToShortDateString();
            hs.IDLop = (int)cboLop.SelectedValue;
            hs.DiaChi = txtDiaChi.Text;
            hs.IDHocSinh = HocSinhDAO.IDMax() + 1;
            HocSinhDAO.ThemHS(hs);
        }

        private void SuaHocSinh()
        {
            HocSinhDTO hs = new HocSinhDTO();
            hs.IDHocSinh = int.Parse(txtIDHocSinh.Text);
            hs.HoTen = txtHoTen.Text;
            hs.IDLop = (int)cboLop.SelectedValue;
            hs.GioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
            hs.NgaySinh = dtpNgaySinh.Value.ToShortDateString();
            hs.SDT = txtSDT.Text;
            hs.DiaChi = txtDiaChi.Text;
            HocSinhDAO.SuaHS(hs);
        }

        private void XoaHocSinh()
        {
            HocSinhDTO hs = new HocSinhDTO();
            hs.IDHocSinh = int.Parse(txtIDHocSinh.Text);
            HocSinhDAO.XoaHS(hs);
        }

        private void UnReadOnly()
        {
            txtHoTen.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtSDT.ReadOnly = false;
            cboLop.Enabled = true;
            dtpNgaySinh.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
        }

        private void ReadOnly()
        {
            txtHoTen.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            cboLop.Enabled = false;
            dtpNgaySinh.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool kt = true;
            if (txtHoTen.Text == "") kt = false;
            else if (txtDiaChi.Text == "") kt = false;
            else if (rdbNam.Checked == false && rdbNu.Checked == false) kt = false;
            else if (txtSDT.Text == "") kt = false;
            if (kt == false)
            {
                MessageBox.Show("Bạn cần nhập đủ thông tin");
                return;
            }
            switch (lc)
            {
                case LuaChon.Them:
                    ThemHocSinh();
                    LoadDuLieu();
                    break;
                case LuaChon.Sua:
                    SuaHocSinh();
                    LoadDuLieu();
                    break;
                case LuaChon.Xoa:
                    XoaHocSinh();
                    LoadDuLieu();
                    break;

            }
            HienButton();
            ReadOnly();
            Xoatxt();
        }

        private void Xoatxt()
        {
            txtIDHocSinh.Text = "";
            txtIDHocSinh.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtIDHocSinh.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xoatxt();
            HienButton();
            ReadOnly();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtIDHocSinh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn học sinh");
                return;
            }
            lc = LuaChon.Sua;
            AnButton();
            UnReadOnly();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn học sinh");
                return;
            }
            lc = LuaChon.Xoa;
            AnButton();
            ReadOnly();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvHocSinh.DataSource = HocSinhDAO.TimKiemHocSinh(txtTimKiem.Text);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            SuaHeaderText();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSDT_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rdbNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtIDHocSinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
