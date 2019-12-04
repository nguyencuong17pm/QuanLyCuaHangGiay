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
    class KhachHangBus
    {
        KhachHangData data = new KhachHangData();

        public void HienThiVaoDGV(BindingNavigator bN, DataGridView dGV, TextBox txtMaKhachHang, TextBox txtTenKhachHang)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaKhachHang.DataBindings.Clear();
            txtMaKhachHang.DataBindings.Add("Text", bS, "MAKH", false, DataSourceUpdateMode.Never);

            txtTenKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Add("Text", bS, "TENKH", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox2(ComboBox cboKhachHang)
        {
            cboKhachHang.DataSource = data.DanhSach();
            cboKhachHang.ValueMember = "MAKH";
            cboKhachHang.DisplayMember = "TENKH";
        }

        public void Them(KhachHangInfo info)
        {
            data.Them(info);
        }

        public void Sua(KhachHangInfo info, string maKH)
        {
            data.Sua(info, maKH);
        }

        public void Xoa(KhachHangInfo info)
        {
            data.Xoa(info);
        }
    }
}

