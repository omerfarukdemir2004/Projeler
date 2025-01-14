using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iş_takip_formu.Repository
{
    public class PersonelRepositroy
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["is_takipConnectionString"].ConnectionString;

        public static List<PersonelClass> GetAllPersonels()
        {
            List<PersonelClass> PersonelsList = new List<PersonelClass>();

            string query = "SELECT [personel_id],[ad_soyad],[bolum],[durum],[mail] FROM [dbo].[personel]";

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
                                int id = reader.GetInt32(reader.GetOrdinal("personel_id"));
                                string adSoyad = reader["ad_soyad"].ToString();
                                string bolum = reader["bolum"].ToString();
                                string per_status = reader["durum"].ToString();
                                string mail = reader["mail"].ToString();

                                PersonelClass personel = new PersonelClass(id, adSoyad, bolum, per_status, mail);

                                PersonelsList.Add(personel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            return PersonelsList;
        }

        public static int GetPersonelIdByName(string ad_soyad)
        {
            int personel_id = -1; // Geçersiz ID
            string query = "SELECT personel_id FROM [dbo].[personel] WHERE ad_soyad = @ad_soyad";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad_soyad", ad_soyad);
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out personel_id))
                        {
                           // MessageBox.Show("Personel ID: " + personel_id); // ID'yi göster
                            return personel_id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            return personel_id;
        }
        public static void AddPersonel(PersonelClass personel_class)
        {
            string query = "INSERT INTO personel ( ad_soyad , bolum , durum , mail) " +
                  "VALUES (@ad_soyad, @bolum, @personel_durum, @mail)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad_soyad", personel_class.ad_soyad);
                        cmd.Parameters.AddWithValue("@bolum", personel_class.bolum);
                        cmd.Parameters.AddWithValue("@personel_durum", personel_class.personel_durum);
                        cmd.Parameters.AddWithValue("@mail", personel_class.mail);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }


        public static void UpdatePersonel(PersonelClass personel_class)
        {
            string query = ("UPDATE personel SET ad_soyad=@ad_soyad , bolum=@bolum , durum=@personel_durum , mail=@mail where personel_id=@personel_id");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@personel_id", personel_class.id);
                        cmd.Parameters.AddWithValue("@ad_soyad", personel_class.ad_soyad);
                        cmd.Parameters.AddWithValue("@bolum", personel_class.bolum);
                        cmd.Parameters.AddWithValue("@personel_durum", personel_class.personel_durum);
                        cmd.Parameters.AddWithValue("@mail", personel_class.mail);

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata" + ex);
            }
        }
        public static bool checkPersonel(int id)
        {
            bool exists = false;

            string query = "select count(*) from personel where personel_id=@personel_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@personel_id", id);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    exists = (count > 0);
                }
            }

            return exists; // Burada exists değişkenini döndürüyoruz
        }

        public static void DeletePersonel(int id)
        {
            string query = "delete from personel where personel_id=@personel_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("personel_id", id);
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
