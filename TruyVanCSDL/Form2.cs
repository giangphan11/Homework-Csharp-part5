using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TruyVanCSDL.models;

namespace TruyVanCSDL
{
    public partial class Form2 : Form
    {
        SqlConnection conn = null;
        string strConnection = "Server=GIANGPHAN; Database=QuanLySanPham; User=sa; Password=20061998";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnection);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from DanhMuc";
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                lbDanhMuc.Items.Clear();
                while (reader.Read())
                {
                    DanhMuc dm = new DanhMuc();
                    dm.Ma = reader.GetString(0);
                    dm.Ten = reader.GetString(1);
                    lbDanhMuc.Items.Add(dm);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vtChon = lbDanhMuc.SelectedIndex;
            if(vtChon!=-1)
            {

                object o = lbDanhMuc.SelectedItem;
                DanhMuc dm = (DanhMuc)o;
                try
                {
                    if (conn == null)
                    {
                        conn = new SqlConnection(strConnection);
                    }
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT*FROM dbo.SanPham WHERE MaDM=@ma";
                    command.Connection = conn;

                    SqlParameter parameter = new SqlParameter("@ma", SqlDbType.VarChar);
                    parameter.Value = dm.Ma;
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    lvSanPham.Items.Clear();
                    while (reader.Read())
                    {
                        string ma = reader.GetString(0);
                        string ten = reader.GetString(1);
                        int gia = reader.GetInt32(2);
                        int sl = reader.GetInt32(3);
                        ListViewItem item = new ListViewItem(ma);
                        item.SubItems.Add(ten);
                        item.SubItems.Add(gia+"");
                        item.SubItems.Add(sl+"");
                        lvSanPham.Items.Add(item);

                    }
                    reader.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnection);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "insert into SanPham values(@masp, @tenSp, @gia,@soluong,@x,@maDm)";
                command.CommandText = sql;
                command.Connection = conn;
                command.Parameters.Add("@masp", SqlDbType.NVarChar).Value = txtMaSP.Text;
                command.Parameters.Add("@x", SqlDbType.NVarChar).Value = "x";
                command.Parameters.Add("@tenSp", SqlDbType.NVarChar).Value = txtTenSP.Text;
                command.Parameters.Add("@gia", SqlDbType.Int).Value = Int32.Parse(txtGiaSP.Text);
                command.Parameters.Add("@soluong", SqlDbType.Int).Value = Int32.Parse(txtSoLuongSp.Text);
                command.Parameters.Add("@maDm", SqlDbType.NVarChar).Value = txtMaDM.Text;


                int ret = command.ExecuteNonQuery();
                if (ret > 0)
                    MessageBox.Show("Thêm sản phẩm thành công !");
                else
                    MessageBox.Show("Thêm sản phẩm thất bại !");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
