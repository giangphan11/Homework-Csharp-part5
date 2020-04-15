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

namespace CSDL_Connection
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        string strConnection = "SERVER= GIANGPHAN; DATABASE=QuanLySanPham; User=sa; Password=20061998";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConnection);
                conn.Open();
                MessageBox.Show("Kết nối CSDL thành công !");
                    }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(conn!=null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                MessageBox.Show("Ngắt kết nối CSDL thành công !");
            }
        }
    }
}
