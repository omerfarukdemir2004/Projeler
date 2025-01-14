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
    public class CompanyRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["is_takipConnectionString"].ConnectionString;
        public static List<CompanyClass> GetAllCompanys()
        {
            List<CompanyClass> CompanyList = new List<CompanyClass>();

            string query = "SELECT [firma_id],[firma_adi],[iletisim] FROM [dbo].[firmalar]";

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
                                int id_firma = reader.GetInt32(reader.GetOrdinal("firma_id"));
                                string firma_ad = reader["firma_adi"].ToString();
                                string iletisim = reader["iletisim"].ToString();

                                CompanyClass firmalar_class = new CompanyClass(id_firma, firma_ad, iletisim);

                                CompanyList.Add(firmalar_class);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            return CompanyList;
        }

        public static int GetFirmaIdByName(string firma_adi)
        {
            int firma_id = -1; // Geçersiz ID
            string query = "SELECT firma_id FROM [dbo].[firmalar] WHERE firma_adi = @firma_adi";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firma_adi", firma_adi);
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out firma_id))
                        {
                            //MessageBox.Show("Firma ID: " + firma_id); // ID'yi göster
                            return firma_id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            return firma_id;
        }

        public static void AddCompany(CompanyClass firmalar_class)
        {
            string query = "INSERT INTO firmalar ( firma_adi , iletisim) " +
                  "VALUES (@firma_adi, @iletisim)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firma_adi", firmalar_class.firma_adi);
                        cmd.Parameters.AddWithValue("@iletisim", firmalar_class.iletisim);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        public static void UpdateCompany(CompanyClass firmalar_class)
        {
            string query = ("UPDATE firmalar SET firma_adi=@firma_adi, iletisim=@iletisim  where firma_id=@firma_id");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firma_id", firmalar_class.id_firma);
                        cmd.Parameters.AddWithValue("@firma_adi", firmalar_class.firma_adi);
                        cmd.Parameters.AddWithValue("@iletisim", firmalar_class.iletisim);


                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata" + ex);
            }
        }

        public static bool checkCompany(int id)
        {
            bool exists = false;

            string query = "select count(*) from firmalar where firma_id=@firma_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@firma_id", id);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    exists = (count > 0);
                }
            }
            return exists; // Burada exists değişkenini döndürüyoruz 
        }
            public static void DeleteCompany(int id)
        {
            string query = "delete from firmalar where firma_id=@firma_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("firma_id", id);
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
