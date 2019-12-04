using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLGIAY.DATA;
using QLGIAY.INFO;
namespace QLGIAY.BUS
{
    class TaiKhoanBus
    {
         TaiKhoanData data = new TaiKhoanData();

         public void HienThiVaoDGV(DataGridView dGV,
                                   BindingNavigator bN,
                                   ComboBox cboNhanVien,
                                   ComboBox cboQuyen,
                                   TextBox txtMatKhau)
         {
             BindingSource bS = new BindingSource();
             bS.DataSource = data.DanhSach();
             bS.DataSource = data.DanhSach();
             txtMatKhau.DataBindings.Clear();
             txtMatKhau.DataBindings.Add("Text", bS, "MATKHAU", false, DataSourceUpdateMode.Never);

             cboNhanVien.DataBindings.Clear();
             cboNhanVien.DataBindings.Add("SelectedValue", bS, "MANV", false, DataSourceUpdateMode.Never);

             cboQuyen.DataBindings.Clear();
             cboQuyen.DataBindings.Add("SelectedIndex", bS, "QUYEN", false, DataSourceUpdateMode.Never);

             bN.BindingSource = bS;
             dGV.DataSource = bS;
         }
         public bool dangnhap(string maNV, string matKhau)
         {
             var TK = data.ChiTiet(maNV, matKhau);
             if (TK.Rows.Count <= 0)
                 return false;
             else
             {
                 QLGIAY.GUI.frmChinh.HoVaTen = TK.Rows[0]["TENNV"].ToString();
                 QLGIAY.GUI.frmChinh.quyenHan = Convert.ToInt32(TK.Rows[0]["QUYEN"]);
                 return true;
             }
         }
        public void Them(TaiKhoanInfo info)
        {
            data.Them(info);
        }

        public void Sua(TaiKhoanInfo info)
        {
            data.Sua(info);
        }

        public void Xoa(TaiKhoanInfo info)
        {
            data.Xoa(info);
        }
    }
}
