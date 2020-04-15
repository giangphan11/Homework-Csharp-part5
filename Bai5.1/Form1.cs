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

namespace Bai5._1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        string strConnect = "Server=GIANGPHAN; Database=QuanLySanPham; User=sa; Password=20061998";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnect);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select TenSP from SanPham";
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                List<string> dsSP = new List<string>();
                while (reader.Read())
                {
                    string ten = reader.GetString(0);
                    //dsSP.Add(ten);
                    cboSanPham.Items.Add(ten);
                }
                reader.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
                this.Close();
            }
        }
    }
}
