using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGIAY.INFO
{
    class TaiKhoanInfo
    {
        
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private NhanVienInfo nhanVien = new NhanVienInfo();
        internal NhanVienInfo NhanVien
        {
            get { return nhanVien; }
            set { nhanVien = value; }
        }

        private string matKhau;
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        private int quyen;
        public int Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }
    }
}
