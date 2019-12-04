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
    class GiayData
    {
        Connect db = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM QLGIAY.GIAY";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
            return db;
        }
        
        public void Them(GiayInfo info)
        {
            string sql = "INSERT INTO QLGIAY.GIAY(MAGIAY, TENGIAY, LOAIGIAY) VALUES('" + info.MaGiay + "', '" + info.TenGiay + "','" + info.LoaiGiay + "')";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
        }

        public void Sua(GiayInfo info, string maGiay)
        {
            string sql = "UPDATE QLGIAY.GIAY SET MAGIAY = '" + info.MaGiay + "', TENGIAY = '" + info.TenGiay + "', LOAIGIAY = '" + info.LoaiGiay + "' WHERE MAGIAY = '" + maGiay + "'";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
        }

        public void Xoa(GiayInfo info)
        {
            string sql = "DELETE FROM QLGIAY.GIAY WHERE MAGIAY = '" + info.MaGiay + "'";
            DB2Command cmd = new DB2Command(sql);
            db.ExecuteSQL(cmd);
        }
    }
}
