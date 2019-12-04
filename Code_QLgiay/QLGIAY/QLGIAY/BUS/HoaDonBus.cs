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
    class HoaDonBus
    {
        HoaDonData data = new HoaDonData();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtDiaChi,
                                  TextBox txtMaHoaDon,
                                  TextBox txtSoDienThoai,
                                  TextBox txtSoTien,
                                  ComboBox cboKhachHang,
                                  ComboBox cboMaNhanVien,
                                  CheckBox chkGioiTinh,
                                  ComboBox cboMaGiay,
                                  string tuKhoa
                                  )
        {
            BindingSource bS = new BindingSource();
            //bS.DataSource = data.DanhSach();
          if (tuKhoa == "")
              bS.DataSource = data.DanhSach();
           else
               bS.DataSource = data.DanhSach(tuKhoa);
            txtMaHoaDon.DataBindings.Clear();
            txtMaHoaDon.DataBindings.Add("Text", bS, "MAHD", false, DataSourceUpdateMode.Never);

            txtSoDienThoai.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Add("Text", bS, "SODIENTHOAI", false, DataSourceUpdateMode.Never);

            txtSoTien.DataBindings.Clear();
            txtSoTien.DataBindings.Add("Text", bS, "SOTIEN", false, DataSourceUpdateMode.Never);

            cboKhachHang.DataBindings.Clear();
            cboKhachHang.DataBindings.Add("SelectedValue", bS, "MAKH", false, DataSourceUpdateMode.Never);
            chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "GIOITINH", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "F";
            };
            //chkGioiTinh.DataBindings.Add(gt);
            cboMaGiay.DataBindings.Clear();
            cboMaGiay.DataBindings.Add("SelectedValue", bS, "MAGIAY", false, DataSourceUpdateMode.Never);
       
          
            cboMaNhanVien.DataBindings.Clear();
            cboMaNhanVien.DataBindings.Add("SelectedValue", bS, "MANV", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "DIACHI", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }
        public void Them(HoaDonInfo info)
        {
            data.Them(info);
        }

        public void Sua(HoaDonInfo info, string maHD)
        {
            data.Sua(info, maHD);
        }

        public void Xoa(HoaDonInfo info)
        {
            data.Xoa(info);
        }
    }
}
