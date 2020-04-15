using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HocListView.model
{
    public class DanhMuc
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public DanhMuc()
        {
            sanPhams = new List<SanPham>();
        }
        public void ThemSanPham(SanPham sanPham)
        {
            sanPhams.Add(sanPham);
            sanPham.Nhom = this;
        }
    }
}
