using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iş_takip_formu
{
    public class CompanyClass
    {
        public int id_firma { get; set; }
        public string firma_adi { get; set; }
        public string iletisim { get; set; }



        public CompanyClass(int id_firma, string firma_adi, string iletisim)
        {
            this.id_firma = id_firma;
            this.firma_adi = firma_adi;
            this.iletisim = iletisim;

        }

        public CompanyClass( string firma_adi, string iletisim)
        {
            this.firma_adi = firma_adi;
            this.iletisim = iletisim;

        }
    }
}
