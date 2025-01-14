using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iş_takip_formu
{
    public class StatusClass
    {
        public int id { get; set; }
        public string durum { get; set; }

        public StatusClass(int id,string durum)
        {
            this.id = id;
            this.durum = durum;
        }
        public override string ToString()
        {
            return durum; // ListBox'ta sadece görev adını göstermek için
        }
    }
}
