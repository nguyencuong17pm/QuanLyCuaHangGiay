using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLGIAY.DATA
{
       class Connect : DataTable
    {
            private static SqlConnection db2Conn;
            private static string connString = "Server=127.0.0.1:50000;Database=QLYGIAY;UserID=db2admin;Password=db2admin";
            private SqlCommand db2Cmd;
            private SqlCommand db2DataAdapter;

            public Connect()
            {

            }

            public static bool OpenConnect()
            {
                try
                {
                    if (db2Conn == null)
                        db2Conn = new SqlConnection(connString);
                    if (db2Conn.State == ConnectionState.Closed)
                        db2Conn.Open();
                    return true;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Không thể kết nối tới server!\nLỗi: " + e.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db2Conn.Close();
                    return false;
                }
            }

            public void ExecuteSQL(SqlCommand cmd)
            {
                if (db2Conn == null || db2Conn.State == ConnectionState.Closed)
                {
                    db2Conn = new SqlConnection(connString);
                    db2Conn.Open();
                }
                db2Cmd = cmd;
                try
                {
                    db2Cmd.Connection = db2Conn;

                    SqlDataAdapter = new SqlDataReader();
                    SqlDataAdapter.SelectCommand = db2Cmd;

                    this.Clear();
                    SqlDataAdapter.Fill(this);
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Không thể thực thi câu lệnh SQL này!\nLỗi: " + e.Message, "Lỗi truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
