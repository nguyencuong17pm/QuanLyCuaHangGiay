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
    class TaiKhoanData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT T.*, N.TENNV FROM QLGIAY.TAIKHOAN T, QLGIAY.NHANVIEN N WHERE T.MANV = N.MANV";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
            return data;
        }
        public DataTable ChiTiet(string maNV, string matKhau)
        {
            string sql = "SELECT T.*, N.TENNV FROM QLGIAY.TAIKHOAN T, QLGIAY.NHANVIEN N WHERE T.MANV = N.MANV AND T.MANV = '" + maNV + "' AND T.MATKHAU = '" + matKhau + "'";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
            return data;
        }

        public void Them(TaiKhoanInfo info)
        {
            string sql = "INSERT INTO QLGIAY.TAIKHOAN(MANV, MATKHAU, QUYEN) VALUES('" + info.NhanVien.MaNV + "', '" + info.MatKhau + "', " + info.Quyen + ")";
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }

        public void Sua(TaiKhoanInfo info)
        {
            string sql = "UPDATE QLGIAY.TAIKHOAN SET MANV = '" + info.NhanVien.MaNV + "', MATKHAU = '" + info.MatKhau + "', QUYEN = " + info.Quyen + " WHERE ID = " + info.ID;
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }

        public void Xoa(TaiKhoanInfo info)
        {
            string sql = "DELETE FROM QLGIAY.TAIKHOAN WHERE ID = " + info.ID;
            DB2Command cmd = new DB2Command(sql);
            data.ExecuteSQL(cmd);
        }
    }
}
