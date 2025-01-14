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
    public class TaskRepository
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["is_takipConnectionString"].ConnectionString;

        public static List<TaskClass> GorevleriGetir(string sortOrder = "")
        {
            List<TaskClass> gorevlers = new List<TaskClass>();

            string query = "SELECT [gorev_id],[gorev] FROM [is_takip].[dbo].[gorevler]";
            if (!string.IsNullOrEmpty(sortOrder))
            {
                query += $" ORDER BY {sortOrder}";
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
                                int id = reader.GetInt32(reader.GetOrdinal("gorev_id"));
                                string gorev = reader["gorev"].ToString();

                                TaskClass gorevItem = new TaskClass(id,gorev);
                                gorevlers.Add(gorevItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata" + ex);
            }
            return gorevlers;
        }



        public static int GetTaskIdByName(string gorev)
        {
            int gorev_id = -1; // Geçersiz ID
            string query = "SELECT gorev_id FROM [dbo].[gorevler] WHERE gorev = @gorev";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gorev", gorev);
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out gorev_id))
                        {
                            //MessageBox.Show("Firma ID: " + firma_id); // ID'yi göster
                            return gorev_id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            return gorev_id;
        }

        public static void AddGorev(TaskClass gorevler)
        {
            string query = "insert into gorevler (gorev) values (@gorev)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("gorev", gorevler.gorev);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex);

            }
        }


        public static void UpdateTask(TaskClass task)
        {
            string query = "update gorevler set gorev=@gorev where gorev_id=@gorev_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gorev_id", task.id);
                        cmd.Parameters.AddWithValue("@gorev", task.gorev);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex);

            }
        }


        public static void DeleteGorev(string gorev)
        {
            string query = "delete from gorevler where gorev=@gorev";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gorev", gorev);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: Görev mevcut olarak kullanıldığı için silinemiyor. \n " + ex.Message);
            }
        }
    }
}
