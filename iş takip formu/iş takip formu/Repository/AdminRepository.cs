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
    public class AdminRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["is_takipConnectionString"].ConnectionString;

        public static bool AdminCheck(AdminClass adminClass)
        {
            string query = "select count(1) from admin where k_adi=@k_adi and sifre=@sifre";

            try
            {
                using(SqlConnection conn=new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("k_adi", adminClass.k_adi);
                        cmd.Parameters.AddWithValue("sifre", adminClass.sifre);

                        int result = (int)cmd.ExecuteScalar();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
                return false;
            }
        }
    }
}
