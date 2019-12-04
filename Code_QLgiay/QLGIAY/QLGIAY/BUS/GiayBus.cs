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
    class GiayBus
    {
        GiayData data = new GiayData();

        public void HienThiVaoDGV(BindingNavigator bN, DataGridView dGV, TextBox txtMaGiay, TextBox txtTenGiay, TextBox txtLoaiGiay)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaGiay.DataBindings.Clear();
            txtMaGiay.DataBindings.Add("Text", bS, "MAGIAY", false, DataSourceUpdateMode.Never);

            txtTenGiay.DataBindings.Clear();
            txtTenGiay.DataBindings.Add("Text", bS, "TENGIAY", false, DataSourceUpdateMode.Never);

            txtLoaiGiay.DataBindings.Clear();
            txtLoaiGiay.DataBindings.Add("Text", bS, "LOAIGIAY", false, DataSourceUpdateMode.Never);
            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

       public void HienThiVaoComboBox1(ComboBox cboMaGiay)
        {
            cboMaGiay.DataSource = data.DanhSach();
            cboMaGiay.ValueMember = "MAGIAY";
            cboMaGiay.DisplayMember = "TENGIAY";
        }

        public void Them(GiayInfo info)
        {
            data.Them(info);
        }

        public void Sua(GiayInfo info, string maGiay)
        {
            data.Sua(info, maGiay);
        }

        public void Xoa(GiayInfo info)
        {
            data.Xoa(info);
        }
    }
}
