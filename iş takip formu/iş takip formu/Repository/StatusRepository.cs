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
    public class StatusRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["is_takipConnectionString"].ConnectionString;

        public static List<StatusClass> statusList()
        {
            List<StatusClass> status = new List<StatusClass>();
            string query = "SELECT [durum_id],[durum] FROM [is_takip].[dbo].[durum]";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())  // Okunacak veri var mı kontrol ediliyor
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("durum_id"));
                                string durum = reader["durum"].ToString();

                                StatusClass statusitem = new StatusClass(id, durum);
                                status.Add(statusitem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            return status;
        }

        public static void AddStatus(StatusClass statusClass)
        {
            string query = "insert into durum (durum) values (@durum)";

            try
            {
                using (SqlConnection conn=new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("durum", statusClass.durum);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }


        public static void DeleteStatus(StatusClass statusClass)
        {
            string query = "delete from durum where durum=@durum";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                { 
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@durum", statusClass.durum);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex);
            }
        }

        public static void UpdateStatus(StatusClass statusClass)
        {
            string query = "update durum set durum=@durum where durum_id=@durum_id";

            try
            {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("durum_id", statusClass.id);
                    cmd.Parameters.AddWithValue("durum", statusClass.durum);

                    cmd.ExecuteNonQuery();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }


        public static int GetStatusIdByName(string durum)
        {
            int status_id = -1;
            string query = "select durum_id from durum where durum=@durum";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@durum", durum);
                        object result = cmd.ExecuteScalar();
                        if(result!=null&& int.TryParse(result.ToString(),out status_id))
                        {
                            return status_id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
            return status_id;

        }
    }
}
