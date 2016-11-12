using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BoMonDTO
    {
        private int _IDMon;

        public int IDMon
        {
            get { return _IDMon; }
            set { _IDMon = value; }
        }

        private string _TenMon;

        public string TenMon
        {
            get { return _TenMon; }
            set { _TenMon = value; }
        }

        private int _SoLuong;

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private int _IDTruongBoMon;

        public int IDTruongBoMon
        {
            get { return _IDTruongBoMon; }
            set { _IDTruongBoMon = value; }
        }
    }
}
