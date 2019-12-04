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
    class KhachHangData
    {


        Connect db = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM QLGIAY.KHACHHANG";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
            return db;
        }

        public void Them(KhachHangInfo info)
        {
            string sql = "INSERT INTO QLGIAY.KHACHHANG(MAKH, TENKH) VALUES('" + info.MaKH + "', '" + info.TenKH + "')";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
        }

        public void Sua(KhachHangInfo info, string maKH)
        {
            string sql = "UPDATE QLGIAY.KHACHHANG SET TENKH = '" + info.MaKH + "', TENKH = '" + info.TenKH + "' WHERE MAKH = '" + maKH + "'";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
        }

        public void Xoa(KhachHangInfo info)
        {
            string sql = "DELETE FROM QLGIAY.KHACHHANG WHERE MAKH = '" + info.MaKH + "'";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
        }
    }
}

