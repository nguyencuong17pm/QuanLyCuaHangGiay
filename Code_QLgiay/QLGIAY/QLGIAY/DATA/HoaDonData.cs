using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLGIAY.INFO;
using IBM.Data.DB2;
namespace QLGIAY.DATA
{
    class HoaDonData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {

            string sql = "SELECT N.*, P.TENKH FROM QLGIAY.HOADON N, QLGIAY.KHACHHANG P WHERE N.MAKH = P.MAKH";
            DB2Command cmd = new DB2Command(sql);
            // string sql1 = "SELECT T.*, N.MANV FROM QLGIAY.HOADON T, QLGIAY.NHANVIEN A WHERE T.MANV = A.MANV";
           //  DB2Command cmd1 = new DB2Command(sql1);
            data.ExecuteSQL(cmd);
            return data;
        }
        public DataTable DanhSach(string tuKhoa)
        {

            string sql = "SELECT N.*, P.TENKH FROM QLGIAY.HOADON N, QLGIAY.KHACHHANG P WHERE N.MAKH = P.MAKH AND N.MAHD LIKE '%" + tuKhoa + "%'";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
            return data;
        }
        
        public void Them(HoaDonInfo info)
        {
            string sql = "INSERT INTO QLGIAY.HOADON(MAHD, MANV, MAKH, MAGIAY, GIOITINH, DIACHI, SOTIEN, SODIENTHOAI) VALUES( '" + info.MaHD + "','" + info.NV.MaNV + "', '" + info.KH.MaKH+ "', '" + info.Giay.MaGiay + "', '" + info.GioiTinh + "' , '" + info.DiaChi + "','" + info.SoTien + "' , '" + info.SoDienThoai + "')";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }

        public void Sua(HoaDonInfo info, string maHD)
        {
            string sql = "UPDATE QLGIAY.HOADON SET MAHD = '" + info.MaHD + "', MANV = '" + info.NV.MaNV + "', MAKH = '" + info.KH.MaKH + "',MAGIAY = '" + info.Giay.MaGiay + "', GIOITINH = '" + info.GioiTinh + "', DIACHI = '" + info.DiaChi + "',SOTIEN = '" + info.SoTien + "',SODIENTHOAI = '" + info.SoDienThoai  + "' WHERE MAHD = '" + maHD + "'";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }

        public void Xoa(HoaDonInfo info)
        {
            string sql = "DELETE FROM QLGIAY.HOADON WHERE MAHD = '" + info.MaHD + "'";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }
    }
}
