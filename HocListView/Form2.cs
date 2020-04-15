using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HocListView.model;
namespace HocListView
{
    public partial class Form2 : Form
    {
        List<DanhMuc> Kho = new List<DanhMuc>();
        public Form2()
        {
            InitializeComponent();
        }

        private void lvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DanhMuc dmBia = new DanhMuc();
            dmBia.Ma = "dm1";
            dmBia.Ten = "Danh mục Bia";
            Kho.Add(dmBia);

            SanPham sp1 = new SanPham();
            sp1.Ma = "sp1";
            sp1.Ten = "Bia 333";
            sp1.Gia = 150;
            dmBia.ThemSanPham(sp1);

            SanPham sp2 = new SanPham();
            sp2.Ma = "sp2";
            sp2.Ten = "Bia Heniken";
            sp2.Gia = 250;
            dmBia.ThemSanPham(sp2);

            SanPham sp3 = new SanPham();
            sp3.Ma = "sp3";
            sp3.Ten = "Bia Hà Nội";
            sp3.Gia = 50;
            dmBia.ThemSanPham(sp3);

            DanhMuc dmRuou = new DanhMuc();
            dmRuou.Ma = "dm2";
            dmRuou.Ten = "Danh mục Rượu";
            Kho.Add(dmRuou);

            SanPham sp4 = new SanPham();
            sp4.Ma = "sp4";
            sp4.Ten = "Rượu Vodka";
            sp4.Gia = 80;
            dmRuou.ThemSanPham(sp4);

            SanPham sp5 = new SanPham();
            sp5.Ma = "sp5";
            sp5.Ten = "Rượu Strongbow";
            sp5.Gia = 1450;
            dmRuou.ThemSanPham(sp5);

            foreach(DanhMuc danhMuc in Kho)
            {
                ListViewGroup group = new ListViewGroup(danhMuc.Ten);
                lvSanPham.Groups.Add(group);

                foreach(SanPham sp in danhMuc.sanPhams)
                {
                    ListViewItem item = new ListViewItem(sp.Ma);
                    item.SubItems.Add(sp.Ten);
                    item.SubItems.Add(sp.Gia+"");
                    item.Group = group;
                    lvSanPham.Items.Add(item);
                    if(danhMuc== dmRuou)
                    {
                        item.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}
