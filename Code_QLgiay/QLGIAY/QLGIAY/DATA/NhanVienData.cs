using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLGIAY.INFO;
using IBM.Data.DB2;
using System.Data;
namespace QLGIAY.DATA
{
    class NhanVienData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM QLGIAY.NHANVIEN";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
            return data;
        }

        public void Them(NhanVienInfo info)
        {
            string sql = "INSERT INTO QLGIAY.NHANVIEN(MANV, TENNV, NGAYSINH, CMND, GIOITINH, DIACHI, NGAYVAOLAM) VALUES('" + info.MaNV + "', '" + info.TenNV + "', '" + info.NgaySinh + "', '" + info.CMND + "', '" + info.GioiTinh + "', '" + info.DiaChi + "', '" + info.NgayVaoLam + "')";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }

        public void Sua(NhanVienInfo info, string maNV)
        {
			string sql = "UPDATE QLGIAY.NHANVIEN SET MANV = '" + info.MaNV + "', TENNV = '" + info.TenNV + "', NGAYSINH = '" + info.NgaySinh + "', CMND = '" + info.CMND + "', GIOITINH = '" + info.GioiTinh + "', DIACHI = '" + info.DiaChi + "', NGAYVAOLAM = '" + info.NgayVaoLam + "' WHERE MANV = '" + maNV + "'";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }

        public void Xoa(NhanVienInfo info)
        {
			string sql = "DELETE FROM QLGIAY.NHANVIEN WHERE MANV = '" + info.MaNV + "'";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }
    }
}
