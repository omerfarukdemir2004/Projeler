using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iş_takip_formu.Repository
{
    public class WorkOrderRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["is_takipConnectionString"].ConnectionString;

        public static List<WorkOrderClass> GetAllisemri(string sortString = null, string filterString = null)
        {

            List<WorkOrderClass> is_takipList = new List<WorkOrderClass>();
            
            string query = @"
                SELECT 
                    i.[id],
                    i.[baslik],
                    p.[ad_soyad], 
                    f.[firma_adi] ,
                    i.[yapilacak_is],
                    g.[gorev], 
                    d.[durum],
                    i.[baslangic_tarih],
                    i.[bitis_tarih],
                    i.[is_no],
                    i.[aciklama]
                        FROM 
                            [is_takip].[dbo].[isemri] i
                        JOIN 
                            [is_takip].[dbo].[personel] p ON i.personel_id = p.personel_id
                        JOIN 
                            [is_takip].[dbo].[firmalar] f ON i.firma_id = f.firma_id
                        JOIN 
                            [is_takip].[dbo].[gorevler] g ON i.gorev_id = g.gorev_id
                        JOIN
                            [is_takip].[dbo].[durum] d ON i.durum_id = d.durum_id;";
            // Filtreleme koşulu varsa WHERE ekle
            if (!string.IsNullOrEmpty(filterString))
            {
                query += " WHERE " + filterString;
            }

            // Sıralama koşulu varsa ORDER BY ekle
            if (!string.IsNullOrEmpty(sortString))
            {
                query += " ORDER BY " + sortString;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string baslik = reader["baslik"].ToString();
                                string ad_soyad = reader["ad_soyad"].ToString();
                                string musteri = reader["firma_adi"].ToString();
                                string gorev = reader["gorev"].ToString();
                                string yapilacak_is = reader["yapilacak_is"].ToString();
                                string durum = reader["durum"].ToString();
                                
                                DateTime baslangic_tarih = reader.GetDateTime(reader.GetOrdinal("baslangic_tarih"));
                                DateTime bitis_tarih = reader.GetDateTime(reader.GetOrdinal("bitis_tarih"));
                                int is_no = reader.GetInt32(reader.GetOrdinal("is_no"));
                                string aciklama = reader["aciklama"].ToString();

                                int kalan_gun = (bitis_tarih - DateTime.Now).Days;

                                WorkOrderClass is_takip = new WorkOrderClass(id, baslik, ad_soyad, musteri, yapilacak_is, gorev, durum, baslangic_tarih, bitis_tarih, is_no, aciklama, kalan_gun);
                                is_takipList.Add(is_takip);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            return is_takipList;
        }


        public static void AddWorkOrder(WorkOrderClass is_Takip)
        {
            string query = "INSERT INTO isemri (baslik, yapilacak_is, baslangic_tarih, bitis_tarih, is_no, aciklama,personel_id,firma_id,gorev_id,durum_id) " +
                  "VALUES (@baslik, @yapilacak_is, @baslangic_tarih, @bitis_tarih, @is_no, @aciklama,@personel_id,@firma_id,@gorev_id,@durum_id)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("baslik", is_Takip.baslik);
                        
                        
                        cmd.Parameters.AddWithValue("@yapilacak_is", is_Takip.yapilacak_is);
                        cmd.Parameters.AddWithValue("@baslangic_tarih", is_Takip.baslangic_tarihi);
                        cmd.Parameters.AddWithValue("@bitis_tarih", is_Takip.bitis_tarih);
                        cmd.Parameters.AddWithValue("@is_no", is_Takip.is_no);
                        cmd.Parameters.AddWithValue("@aciklama", is_Takip.aciklama);
                        cmd.Parameters.AddWithValue("@personel_id", is_Takip.personel_id);
                        cmd.Parameters.AddWithValue("@firma_id", is_Takip.musteri_id);
                        cmd.Parameters.AddWithValue("@gorev_id", is_Takip.gorev_id);
                        cmd.Parameters.AddWithValue("@durum_id", is_Takip.durum_id);
                        //cmd.Parameters.AddWithValue("@kalan_gun", is_Takip.kalan_gun);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("İş Emri eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }

        public static void UpdateWorkOrder(WorkOrderClass is_Takip)
        {
            string query = "UPDATE isemri SET baslik = @baslik, yapilacak_is = @yapilacak_is, baslangic_tarih = @baslangic_tarih, bitis_tarih = @bitis_tarih, aciklama = @aciklama,personel_id=@personel_id,firma_id=@firma_id,gorev_id=@gorev_id,durum_id=@durum_id WHERE is_no = @is_no";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@baslik", is_Takip.baslik);
                        //cmd.Parameters.AddWithValue("@ad_soyad", is_Takip.ad_soyad);
                        cmd.Parameters.AddWithValue("@yapilacak_is", is_Takip.yapilacak_is);
                        cmd.Parameters.AddWithValue("@baslangic_tarih", is_Takip.baslangic_tarihi);
                        cmd.Parameters.AddWithValue("@bitis_tarih", is_Takip.bitis_tarih);
                        cmd.Parameters.AddWithValue("@aciklama", is_Takip.aciklama);
                        //cmd.Parameters.AddWithValue("@kalan_gun", is_Takip.kalan_gun);
                        cmd.Parameters.AddWithValue("@is_no", is_Takip.is_no);
                        cmd.Parameters.AddWithValue("@personel_id", is_Takip.personel_id);
                        cmd.Parameters.AddWithValue("@firma_id", is_Takip.musteri_id);
                        cmd.Parameters.AddWithValue("@gorev_id", is_Takip.gorev_id);
                        cmd.Parameters.AddWithValue("@durum_id", is_Takip.durum_id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        public static bool check(int isNo)
        {
            bool exists = false;

            string query = "select count(*) from isemri where is_no=@is_no";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@is_no", isNo);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    exists = (count > 0);
                }
            }

            return exists; // Burada exists değişkenini döndürüyoruz
        }


        public static void DeleteWorkOrder(int is_no)
        {
            string query = "delete from isemri where is_no=@is_no";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("is_no", is_no);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex);
            }
        }
    }
}
