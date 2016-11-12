using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopDTO
    {
        private int _IDLop;

        public int IDLop
        {
            get { return _IDLop; }
            set { _IDLop = value; }
        }

        private int _SoLuong;

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        private int _IDLopTruong;

        public int IDLopTruong
        {
            get { return _IDLopTruong; }
            set { _IDLopTruong = value; }
        }

        private int _IDChuNhiem;

        public int IDChuNhiem
        {
            get { return _IDChuNhiem; }
            set { _IDChuNhiem = value; }
        }

        private string _TenLop;

        public string TenLop
        {
            get { return _TenLop; }
            set { _TenLop = value; }
        }
    }
}
