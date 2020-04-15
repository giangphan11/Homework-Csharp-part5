using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HocListView
{
    public class Contact
    {
        public int Ma { get; set; }
        public string Ten { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return this.Ten+" - "+this.Phone;
        }
    }
}
