using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iş_takip_formu
{
    public class WorkOrderClass
    {
        public int id { get; set; }
        public string baslik { get; set; }
        public string ad_soyad { get; set; }
        public string musteri { get; set; }
        public string yapilacak_is { get; set; }
        public string gorev { get; set; }
        public string durum { get; set; }
        public DateTime baslangic_tarihi { get; set; }
        public DateTime bitis_tarih { get; set; }
        public int is_no { get; set; }
        public string aciklama { get; set; }
        public int kalan_gun
        {get;set;
        //    //get
        //   // {
        //        //DateTime bugun = DateTime.Now;
        //        //return (bitis_tarih -bugun ).Days;
        //    //}
        }
        public int personel_id {  get; set; }
        public int musteri_id {  get; set; }
        public int gorev_id {  get; set; }
        public int durum_id { get; set; }





        public WorkOrderClass(int id, string baslik, string ad_soyad, string musteri, string yapilacak_is, string gorev,string durum,DateTime baslangic_tarihi,DateTime bitis_tarih, int is_no, string aciklama,int kalan_gun)
        {
            this.id = id;
            this.baslik = baslik;
            this.ad_soyad = ad_soyad;
            this.musteri = musteri;
            this.yapilacak_is = yapilacak_is;
            this.gorev = gorev;
            this.durum = durum;
            this.baslangic_tarihi = baslangic_tarihi;
            this.bitis_tarih = bitis_tarih;
            this.is_no = is_no;
            this.aciklama = aciklama;
            this.kalan_gun = kalan_gun;
            
        }

        public WorkOrderClass(int id, string baslik, string yapilacak_is, DateTime baslangic_tarihi, DateTime bitis_tarih, int is_no, string aciklama, int kalan_gun,int personel_id, int musteri_id,int gorev_id,int durum_id)
        {

            this.id = id;
            this.baslik = baslik;
            this.yapilacak_is = yapilacak_is;
            this.baslangic_tarihi = baslangic_tarihi;
            this.bitis_tarih = bitis_tarih;
            this.is_no = is_no;
            this.aciklama = aciklama;
            this.kalan_gun = kalan_gun;
            this.personel_id = personel_id;
            this.musteri_id=musteri_id;
            this.gorev_id = gorev_id;
            this.durum_id = durum_id;
        }
    }

    
}
