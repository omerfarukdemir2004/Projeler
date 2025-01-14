using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpClient client; 
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            //client.Delimiter = 0x13;
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Server_DataReceived;
            client.Delimiter = 0;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            listBox1.Invoke((MethodInvoker)delegate ()
            {
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(listBox1.Text);
            });
                
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect("127.0.0.1", 9000);
                Random rnd = new Random();
                int sayi = rnd.Next(0, 100);
                listBox1.Items.Add(sayi);

                client.WriteLine(sayi.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("hata"+ex);
            }
        }
    }
}
