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
    public class BoMonDAO
    {
        public static SqlConnection con;
        //  load data, hien thi theo yeu cau, them sua xoa

        // Load dữ liệu
        public static DataTable LoadDataBoMon()
        {
            string sTruyVan = "select a.IDMon , a.TenMon , b.HoTen 'Truong', a.SoLuong   from tblBoMon a , tblGiaoVien b where a.IDTruongBoMon=b.IDGiaoVien ";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemBM(BoMonDTO boMon)
        {
            try
            {
                string sTruyVan = string.Format(@"insert into tblBoMon values({0}, N'{1}',{2}, {3})", boMon.IDMon,
                                                                                                      boMon.TenMon,
                                                                                                      boMon.SoLuong,
                                                                                                      boMon.IDTruongBoMon);
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
        // sửa bộ môn
        public static bool SuaBM(BoMonDTO boMon)
        {
            try
            {
                string sTruyVan = string.Format("update tblBoMon set TenMon=N'{0}', SoLuong={1}, IDTruongBoMon={2} where IDMon={3}", boMon.TenMon,
                                                                                                                                    boMon.SoLuong,
                                                                                                                                    boMon.IDTruongBoMon,
                                                                                                                                    boMon.IDMon);
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
        // xóa bộ môn
        public static bool XoaBM(BoMonDTO boMon)
        {
            try
            {
                string sTruyVan = string.Format("delete from tblGiaoVien where IDMon = {0}", boMon.IDMon);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan, con);

                string sTruyVan1 = string.Format("delete from tblBoMon where IDMon = {0}", boMon.IDMon);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan1, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable ID_BMMax()
        {
            string sTruyVan = "select max(IDMon) from tblBoMon";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable SearchBM(string tim)
        {
            //string sTruyVan = "select a.IDMon , a.TenMon , b.HoTen 'Truong', a.SoLuong   from tblBoMon a , tblGiaoVien b where a.IDTruongBoMon=b.IDGiaoVien and (a.TenMon like N'%" + tim + "%' or a.IDMon =" + tim + " or b.HoTen like N'%" + tim + "%' )";
            //con = DataProvider.KetNoi();
            //DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            //DataProvider.DongKetNoi(con);
            //return dt;


            string sTruyVan = "select a.IDMon , a.TenMon , b.HoTen 'Truong', a.SoLuong   from tblBoMon a , tblGiaoVien b where a.IDTruongBoMon=b.IDGiaoVien and (a.TenMon like N'%" + tim + "%' or a.IDMon like '%" + tim + "%' or b.HoTen like N'%" + tim + "%')";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool CheckTenMon(string ten)
        {
            string sql = "Select * from tblBoMon WHERE TenMon = N'" + ten + "'";
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
