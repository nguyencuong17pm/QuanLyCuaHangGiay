using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGIAY.INFO
{
    class HoaDonInfo
    {
        private string maG;
        public string MaG
        {
            get { return maG; }
            set { maG = value; }
        }
        
        private string maHD;
        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }

        private string maKH;
        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string maNV;
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        private string soDienThoai;
        public string SoDienThoai
        {
            get { return soDienThoai; }
            set {soDienThoai = value; }
        }

        private string gioiTinh;
        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private string soTien;
        public string SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }

        private GiayInfo giay = new GiayInfo();
        internal GiayInfo Giay
        {
            get { return giay; }
            set { giay = value; }
        }
        private NhanVienInfo nv = new NhanVienInfo();
        internal NhanVienInfo NV
        {
            get { return nv; }
            set { nv = value; }
        }
        private KhachHangInfo kh = new KhachHangInfo();
        internal KhachHangInfo KH
        {
            get { return kh; }
            set { kh = value; }
        }
        }
    }

