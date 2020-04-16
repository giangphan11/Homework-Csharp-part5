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

namespace DataAdapter
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        string strConnection = "Server=GIANGPHAN; Database=QuanLySanPham; User=sa; Password=20061998";
        SqlDataAdapter adapter = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(strConnection);
            adapter = new SqlDataAdapter("select * from SanPham", conn);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet,"tblSanPham");
            gvSanPham.DataSource = dataSet.Tables["tblSanPham"];
        }
    }
}
