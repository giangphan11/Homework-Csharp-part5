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

namespace TruyVanCSDL
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        string strConnection = "Server=GIANGPHAN; Database=QuanLySanPham; User=sa; Password=20061998";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnection);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(*) FROM SanPham";
                command.Connection = conn;
                Object o = command.ExecuteScalar();
                int sl = (int)o;
                lbSoSanPham.Text = "Số lượng =" + sl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (conn == null)
                    conn = new SqlConnection(strConnection);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SanPham where MaSP='"+txtMaTimKiem.Text+"'";
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtTen.Text = reader.GetString(1);
                    txtDonGia.Text = reader.GetInt32(2)+"";
                    txtSoLuong.Text = reader.GetInt32(3) + "";
                }
                else
                {
                    MessageBox.Show("NOT FOUND !");
                }
                reader.Close();
                
            }
            catch(Exception ex)
            {
                txtLoi.Text = ex.Message;
            }
        }

        private void btnXemThongTin2_Click(object sender, EventArgs e)
        {
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
                command.CommandText = "select * from SanPham where masp=@masp";
                command.Connection = conn;

                SqlParameter parameter = new SqlParameter("@masp", SqlDbType.VarChar);
                parameter.Value = txtMaTimKiem.Text;
                command.Parameters.Add(parameter);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtTen.Text = reader.GetString(1);
                    txtDonGia.Text = reader.GetInt32(2) + "";
                    txtSoLuong.Text = reader.GetInt32(3) + "";
                }
                
                else
                {
                    txtLoi.Text = "Không tìm thấy mã " + txtMaTimKiem.Text + " trong CSDL !";
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                txtLoi.Text = ex.Message;
            }
        }

        private void btnXemToanBoSanPham_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnection);
            }
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from SanPham";
            command.Connection = conn;

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

        private void lvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSanPham.SelectedItems[0];
                txtTen.Text = item.SubItems[1].Text;
                txtDonGia.Text = item.SubItems[2].Text;
                txtSoLuong.Text = item.SubItems[3].Text;
            }
        }
    }
    
}
