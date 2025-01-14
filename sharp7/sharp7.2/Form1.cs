using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharp7;

namespace sharp7._2
{
    public partial class Form1 : Form
    {
        private S7Client client;
        public Form1()
        {
            InitializeComponent();
            client = new S7Client();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int result = client.ConnectTo("192.168.0.112", 0, 1); // IP adresini ve bağlantı parametrelerini PLC'nize göre ayarlayın
            
            if (result == 0)
            {
                label1.Text = "baglantı başarılı";
            }
            else
            {
                label1.Text = "baglantı başarısız";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /**byte[] buffer = new byte[4]; // 4 byte'lık bir buffer, int32 veri türü için

            int result = client.ReadArea(S7Consts.S7AreaDB, 8, 0, 1, S7Consts.S7WLDWord, buffer);

                   // client.RecvPacket(S7Consts.S7AreaDB, 8, 0, 1, S7Consts.S7WLDWord, buffer);

            if (result == 0)
            {
                // int value = S7.GetDIntAt(buffer, 0); // int32 veriyi okumak için S7.GetDIntAt kullanıyoruz
                //int value = S7.GetIntAt(buffer, 0);
                int value=buffer[0];    
                textBox1.Text = value.ToString();
            }
            else
            {
                MessageBox.Show("int32 veri okuma başarısız!");
            }**/
            /**byte[] buffer = new byte[4];  // 2 byte'lık bir buffer oluşturulur

            // DB8, offset 0, 2 byte okuma
            int result = client.DBRead(8, 0, 2, buffer);

            if (result == 0)
            {
                // ushort veri türünde veri okumak için S7.GetUIntAt kullanıyoruz
                int value1 = S7.GetSIntAt(buffer, 0);
                textBox1.Text = value1.ToString();
            }
            else
            {
                MessageBox.Show("Veri okuma başarısız!");
            }**/
            byte[] buffer = new byte[2];  // 2 byte'lık bir buffer oluşturulur

            // DB8, offset 0, 2 byte okuma
            int result = client.DBRead(8, 0, 2, buffer);

            if (result == 0)
            {
                // ushort veri türünde veri okumak için S7.GetUIntAt kullanıyoruz
                ushort value1 = S7.GetByteAt(buffer, 0);
                textBox1.Text = value1.ToString();
            }
            else
            {
                MessageBox.Show("Veri okuma başarısız!");
            }


            //
            byte[] buffer2 = new byte[4]; // 4 baytlık bir buffer, int32 veri türü için

            int result2 = client.ReadArea(S7Consts.S7AreaDB, 8, 1, 1, S7Consts.S7WLWord, buffer2);

            if (result2 == 0)
            {
                // Veriyi manuel olarak dönüştür
                /** int value2 = (buffer2[0] & 0xFF) |
                             ((buffer2[1] & 0xFF) << 8) |
                             ((buffer2[2] & 0xFF) << 16) |
                             ((buffer2[3] & 0xFF) << 24);**/
                int value2 = BitConverter.ToInt32(buffer2, 0);

                textBox3.Text = value2.ToString();
            }
            else
            {
                MessageBox.Show(" veri okuma başarısız!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int valueToWrite;
            if (int.TryParse(textBox2.Text, out valueToWrite))
            {
                byte[] buffer = new byte[4];

                // `int` değeri `byte[]` dizisine dönüştür
                buffer[0] = (byte)(valueToWrite & 0xFF);           // Düşük bayt
                buffer[1] = (byte)((valueToWrite >> 8) & 0xFF);    // 2. bayt
                buffer[2] = (byte)((valueToWrite >> 16) & 0xFF);   // 3. bayt
                buffer[3] = (byte)((valueToWrite >> 24) & 0xFF);   // Yüksek bayt
     
                int result = client.WriteArea(S7Consts.S7AreaDB, 8, 0, 1, S7Consts.S7WLDWord, buffer);

                if (result == 0)
                {
                    MessageBox.Show("Veri yazma başarılı!");
                }
                else
                {
                    MessageBox.Show("Veri yazma başarısız!");
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir değer girin!");
            }
            
            int valueToWrite2;
            if (int.TryParse(textBox4.Text, out valueToWrite2))
            {
                byte[] buffer2 = new byte[4];

                // `int` değeri `byte[]` dizisine dönüştür
                buffer2[0] = (byte)(valueToWrite2 & 0xFF);           // Düşük bayt
                buffer2[1] = (byte)((valueToWrite2 >> 8) & 0xFF);    // 2. bayt
                buffer2[2] = (byte)((valueToWrite2 >> 16) & 0xFF);   // 3. bayt
                buffer2[3] = (byte)((valueToWrite2 >> 24) & 0xFF);   // Yüksek bayt


                int result2 = client.WriteArea(S7Consts.S7AreaDB, 8, 1, 1, S7Consts.S7WLWord, buffer2);

                if (result2 == 0)
                {
                    MessageBox.Show("Veri yazma başarılı!");
                }
                else
                {
                    MessageBox.Show("Veri yazma başarısız!");
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir değer girin!");
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
        }
    }
}