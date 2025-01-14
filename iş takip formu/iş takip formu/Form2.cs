using iş_takip_formu.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iş_takip_formu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminClass admin = new AdminClass
            (
                0,
                textBox1.Text,
                textBox2.Text

            );
            bool isValidAdmin = AdminRepository.AdminCheck(admin);

                if (isValidAdmin)
                {
                    MessageBox.Show("Giriş Başarılı");
                    frmadmin frma = new frmadmin();

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Form1)
                        {
                            form.Hide();  // Form1'i gizle
                            break;
                        }
                    }
                    this.Hide();
                    frma.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                }
              
        }
    }
}
