using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iş_takip_formu
{
    public class AdminClass
    {
        public int id { get; set; }
        public string k_adi {  get; set; }  
        public string sifre { get; set; }

        public AdminClass(int id,string k_adi,string sifre)
        {
            this.id = id;
            this.k_adi = k_adi;
            this.sifre = sifre;
        }

    }
}
