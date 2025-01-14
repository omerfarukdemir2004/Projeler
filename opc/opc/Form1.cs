using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace opc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {

            string opcUrl = "opc.tcp://192.168.0.112:4840/";
            var tagName = "ns=3;s=\"demoblock\".\"tag2\"";
            var client = new OpcClient(opcUrl);
            client.Connect();

            var deger = client.ReadNode(tagName);
            textBox1.Text = deger.ToString();
            client.Disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string opcUrl = "opc.tcp://192.168.0.112:4840/";
            var tagName = "ns=3;s=\"demoblock\".\"tag2\"";
            var client = new OpcClient(opcUrl);
            client.Connect();
            short yaz = Convert.ToInt16(textBox2.Text);
            
            client.WriteNode(tagName, yaz);
            MessageBox.Show("Değer başarıyla yazıldı!");
        }


    }
}
