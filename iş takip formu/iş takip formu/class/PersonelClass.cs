using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iş_takip_formu
{
    public class PersonelClass
    {
            public int id { get; set; }
            public string ad_soyad { get; set; }
            public string bolum { get; set; }
            public string personel_durum { get; set; }
            public string mail { get; set; }



        public PersonelClass(int id,string ad_soyad, string bolum, string personel_durum, string mail)
        {
            this.id = id;
            this.ad_soyad = ad_soyad;
            this.bolum = bolum;
            this.personel_durum = personel_durum;
            this.mail = mail;
            
        }

        public PersonelClass(string ad_soyad, string bolum, string personel_durum, string mail)
        {
            this.ad_soyad = ad_soyad;
            this.bolum = bolum;
            this.personel_durum = personel_durum;
            this.mail = mail;
        }
    }
}
