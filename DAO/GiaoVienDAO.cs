using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class GiaoVienDAO
    {
        public static SqlConnection con;
        // load dữ liệu, hiển thị theo yêu cầu, thêm sửa xóa
        // Load dữ liệu
        public static DataTable LoadDataGiaoVien()
        {
            string sTruyVan = "select * from tblGiaoVien";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        
        // hiển thị theo yêu cầu
        public static DataTable HienThiYeuCau(GiaoVienDTO gv)
        {
            string sTruyVan = string.Format("select * from tblGiaoVien where IDGIaoVien={0}", gv.IDGiaoVien);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
       
        //thêm giáo viên
        public static bool ThemGV(GiaoVienDTO gv)
        {
            try
            {
                string sTruyVan = string.Format("insert into tblGiaoVien values({0},N'{1}',{2},N'{3}',{4}, N'{5}', {6})", gv.IDGiaoVien,
                                                                                                                        gv.HoTen, 
                                                                                                                        gv.NgaySinh,
                                                                                                                        gv.GioiTinh,
                                                                                                                        gv.IDMon,
                                                                                                                        gv.DiaChi, 
                                                                                                                        gv.SDT);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                string s = string.Format("update tblBoMon set SoLuong=(select COUNT(IDGiaoVien) from tblGiaoVien where IDMon={0}) where IDMon={0}", gv.IDMon);
                DataProvider.ThucThiTruyVan(s, con);
                DataProvider.DongKetNoi(con);
                return true;
            }

            catch
            {
                return false;
            }
        }

        //sửa giáo viên
        public static bool SuaGiaoVien(GiaoVienDTO gv)
        {
            try
            {
                string sTruyVan = string.Format("update tblGiaoVien set HoTen=N'{0}', NgaySinh={1}, GioiTinh=N'{2}', IDMon={3}, DiaChi=N'{4}', SDT= {5} where IDGiaoVien={6}",gv.HoTen,
                                                                                                                                                                              gv.NgaySinh,
                                                                                                                                                                              gv.GioiTinh,
                                                                                                                                                                              gv.IDMon,
                                                                                                                                                                              gv.DiaChi,
                                                                                                                                                                              gv.SDT,
                                                                                                                                                                              gv.IDGiaoVien);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                string s = string.Format("update tblBoMon set SoLuong=(select COUNT(IDGiaoVien) from tblGiaoVien where IDMon={0}) where IDMon={0}", gv.IDMon);
                DataProvider.ThucThiTruyVan(s, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }

        }
        
        //xóa giáo viên
        public static bool XoaGV( GiaoVienDTO gv)
        {
            try
            {
                string sTruyVan = string.Format("delete from tblGiaoVien where IDGiaoVien = {0}", gv.IDGiaoVien);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // lấy thông tin bộ môn của giáo viên đang dạy có mã cho trước
        public static DataTable Lay_ThongtinMonhoc(int IDMon)
        {
         
            string sTruyVan = string.Format("select * from tblBoMon where IDMon={0}", IDMon);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        //check xem có dữ liệu?
        public static string GetValue(string strsql)
        {
            string temp = null;
            con = DataProvider.KetNoi();
            SqlCommand sqlcmd = new SqlCommand(strsql, con);
            SqlDataReader sqldr = sqlcmd.ExecuteReader();
            while (sqldr.Read())
            {
                temp = sqldr[0].ToString();
            }
            DataProvider.DongKetNoi(con);
            return temp;
        }
     /*Code cho phần sinh ra ID*/
        public static DataTable getIDmax() 
        {
            string sTruyVan = "select max(IDGiaoVien) as IDMax from tblGiaoVien";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static DataTable getIDmin()
        {
            string sTruyVan = "select min(IDGiaoVien) as IDMin from tblGiaoVien";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable getID()
        {
            string sTruyVan = "select IDGiaoVien as ID from tblGiaoVien";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable countID()
        {
            string sTruyVan = "select count(IDGiaoVien) as numID from tblGiaoVien";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        // dem so dong cua IDGiaovien
        // rows[0] -> row[n-1]
        // neu ma so dang truoc kem so dang sau !=1 donvi thi tao cai ma so do +1
        // vong lap for chay tu 0-> n-2;

        public static DataTable Search(string gv)
        {
            string sTruyVan = string.Format("select * from tblGiaoVien where HoTen like N'%{0}%'", gv); ;
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static DataTable LayThongTinGiaoVienVien(int IDMon)
        {
            string sTruyVan = string.Format("Select * From tblGiaoVien a, tblBoMon b where b.IDMon= '{0}' and a.IDMon = b.IDMon ", IDMon);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
