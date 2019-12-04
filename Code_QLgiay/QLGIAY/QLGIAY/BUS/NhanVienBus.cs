using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLGIAY.DATA;
using QLGIAY.INFO;
using System.Windows.Forms;
namespace QLGIAY.BUS
{
    class NhanVienBus
    {
            NhanVienData data = new NhanVienData();

        public void HienThiVaoDGV(BindingNavigator bN, 
                                  DataGridView dGV, 
                                  TextBox txtMaNV, 
                                  TextBox txtTenNV,
                                  CheckBox chkGioiTinh,
                                  DateTimePicker dtpNgaySinh,
                                  TextBox txtCMND,
                                  DateTimePicker dtpNgayVaoLam,
                                  TextBox txtDiaChi
                              )
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bS, "MANV", false, DataSourceUpdateMode.Never);

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", bS, "TENNV", false, DataSourceUpdateMode.Never);

            chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "GIOITINH", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "F";
            };
          //  chkGioiTinh.DataBindings.Add(gt);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", bS, "NGAYSINH", false, DataSourceUpdateMode.Never);

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", bS, "CMND", false, DataSourceUpdateMode.Never);

            dtpNgayVaoLam.DataBindings.Clear();
            dtpNgayVaoLam.DataBindings.Add("Value", bS, "NGAYVAOLAM", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "DIACHI", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboMaNhanVien)
        {
            cboMaNhanVien.DataSource = data.DanhSach();
            cboMaNhanVien.ValueMember = "MANV";
            cboMaNhanVien.DisplayMember = "TENNV";
        }

        public void Them(NhanVienInfo info)
        {
            data.Them(info);
        }

        public void Sua(NhanVienInfo info, string maNV)
        {
            data.Sua(info, maNV);
        }

        public void Xoa(NhanVienInfo info)
        {
            data.Xoa(info);
        }
    }
}
