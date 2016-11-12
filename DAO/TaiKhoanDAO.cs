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
    public class TaiKhoanDAO
    {
        public static SqlConnection con;
        // thêm tài khoản, xóa tài khoản

        public static DataTable LoadDataTaiKhoan()
        {
            string sTruyVan = "select TaiKhoan N'Tài Khoản', MatKhau N'Mật Khẩu' from tblTaiKhoan";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemTK(TaiKhoanDTO tk)
        {
            try
            {
                string sTruyVan = string.Format("insert into tblTaiKhoan values({0},{1})", tk.TaiKhoan, tk.MatKhau);
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

        public static bool DoiMK(TaiKhoanDTO tk)
        {
            try
            {
                string sTruyVan = string.Format("update tblTaiKhoan set TaiKhoan='{0}', MatKhau='{1}' where TaiKhoan='{2}'", tk.TaiKhoan,
                                                                                                                             tk.MatKhau,
                                                                                                                             tk.TaiKhoan);
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
        public static bool XoaTk(TaiKhoanDTO tk)
        {
            try
            {
                string sTruyVan = string.Format("Delete from tblTaiKhoan where TaiKhoan={0}", tk.TaiKhoan);
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

        public static bool DangNhap(string Username, string Pass)
        {
            string sql = "Select * from tblTaiKhoan WHERE TaiKhoan = '" + Username + "'and MatKhau = '" + Pass + "'";
            con = DataProvider.KetNoi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
