using SimpleTCP;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace receiver
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;

        public Form1()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source=DESKTOP-KDVHNG8\\SQLEXPRESS;Initial Catalog=randomsayi;Integrated Security=True;Encrypt=False");
        SqlConnection baglan = new SqlConnection(constring);
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            server = new SimpleTcpServer();
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

            server.Start(System.Net.IPAddress.Parse("127.0.0.1"), 9000);
            
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                string tarih = DateTime.Now.Date.ToString("yyyy-MM-dd");
                Convert.ToDateTime(tarih);
                //label1.Text = tarih.ToString();
                string receivedData = e.MessageString;
                if(dataGridView1.Columns.Count==0)
                {
                    // Eğer tek bir hücreye eklemek istiyorsan:
                    dataGridView1.Columns.Add(" ", " ");
                }
                int x = Convert.ToInt32(receivedData);
                dataGridView1.Rows.Add(receivedData);
                // Eğer gelen veri virgülle ayrılmış bir formatta ise (örneğin "value1,value2"):
                // string[] dataParts = receivedData.Split(',');
                // dataGridView1.Rows.Add(dataParts);
                

                if (baglan.State==ConnectionState.Closed)
                {
                    //int lastRow = 0;
                    //lastRow = dt.
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("insert into randomsayi (sayi,tarih) values ('" + x +"','" + tarih +"')",baglan);
                    //SqlDataReader reader;
                    komut.ExecuteReader();
                    baglan.Close();
                    //string kayit = "insert into randomsayi (sayi,tarih) values ('"+receivedData+"','"+tarih+"')",baglan;
                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form kapanırken sunucuyu durdur
            if (server.IsStarted)
            {
                server.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
