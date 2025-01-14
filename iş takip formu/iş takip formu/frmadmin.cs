using DevExpress.XtraPrinting.Native.Navigation;
//using iş_takip_formu.DataRepo;
using iş_takip_formu.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iş_takip_formu
{
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }
        private void frmadmin_Load(object sender, EventArgs e)
        {
            this.dataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);


            yükle();

            #region designdatagrid1
            // Arka plan ve ızgara ayarları
            dataGridView1.BackgroundColor = Color.AliceBlue; // Arka plan rengini beyaz yap
            dataGridView1.GridColor = Color.LightGreen; // Izgara çizgilerinin rengini açık yeşil yap
            dataGridView1.BorderStyle = BorderStyle.None; // Sınır stilini kaldır

            // Sütun başlıklarının stilini ayarla
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34); // Koyu yeşil arka plan
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Sütun başlık metnini beyaz yap
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Daha büyük ve kalın font
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false; // Satır başlıklarını gizle

            // Alternatif satır rengini ayarla
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144); // Açık yeşil

            // Hücre stilini ayarla
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 179, 113); // Orta yeşil seçili arka plan
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White; // Seçili hücre metnini beyaz yap
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 11); // Daha büyük varsayılan font

            // Sütun ve satır ayarları
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları formun genişliğine göre doldur
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırları hücre içeriğine göre ayarla
            dataGridView1.RowTemplate.Height = 30; // Sabit satır yüksekliği ayarla

            // Hücre kenarlıkları ve çizgileri kaldırma
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Genel font ayarları
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 11); // Daha büyük varsayılan font
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Daha büyük ve kalın font

            // Alternatif satır rengini tekrar ayarla
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240); // Çok açık yeşil

            // Seçimi temizle
            dataGridView1.ClearSelection();

            #endregion

            #region designdatagrid2
            // Arka plan ve ızgara ayarları
            dataGridView2.BackgroundColor = Color.AliceBlue; // Arka plan rengini beyaz yap
            dataGridView2.GridColor = Color.LightGreen; // Izgara çizgilerinin rengini açık yeşil yap
            dataGridView2.BorderStyle = BorderStyle.None; // Sınır stilini kaldır

            // Sütun başlıklarının stilini ayarla
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34); // Koyu yeşil arka plan
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Sütun başlık metnini beyaz yap
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Daha büyük ve kalın font
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView2.RowHeadersVisible = false; // Satır başlıklarını gizle

            // Alternatif satır rengini ayarla
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144); // Açık yeşil

            // Hücre stilini ayarla
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 179, 113); // Orta yeşil seçili arka plan
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White; // Seçili hücre metnini beyaz yap
            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 11); // Daha büyük varsayılan font

            // Sütun ve satır ayarları
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları formun genişliğine göre doldur
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırları hücre içeriğine göre ayarla
            dataGridView2.RowTemplate.Height = 30; // Sabit satır yüksekliği ayarla

            // Hücre kenarlıkları ve çizgileri kaldırma
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Genel font ayarları
            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 11); // Daha büyük varsayılan font
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Daha büyük ve kalın font

            // Alternatif satır rengini tekrar ayarla
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240); // Çok açık yeşil

            // Seçimi temizle
            dataGridView2.ClearSelection();

            #endregion

            // ComboBox'ın DrawMode özelliğini OwnerDrawFixed olarak ayarla
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += new DrawItemEventHandler(CustomComboBox_DrawItem);


            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DrawItem += new DrawItemEventHandler(CustomComboBox_DrawItem);

        }

        private void CustomComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Hiçbir öğe yoksa geri dön
            if (e.Index < 0)
            {
                return;
            }

            // ComboBox'un arka plan rengini beyaz olarak ayarla
            e.DrawBackground();
            Brush brush = Brushes.Black;

            // Seçili öğenin arka plan rengini belirle
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = Brushes.White;
                e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            // Metni çiz
            string text = comboBox.GetItemText(comboBox.Items[e.Index]);
            e.Graphics.DrawString(text, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        void yükle()
        {
            List<PersonelClass> personel_Classes = new List<PersonelClass>();
            personel_Classes = PersonelRepositroy.GetAllPersonels();
            dataGridView2.DataSource = personel_Classes;

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView2.Columns[2].HeaderText = "Bölümü";
            dataGridView2.Columns[3].HeaderText = "Gorevi";
            dataGridView2.Columns[4].HeaderText = "Mail";


            List<CompanyClass> firmalar_Classes = new List<CompanyClass>();
            firmalar_Classes = CompanyRepository.GetAllCompanys();
            dataGridView1.DataSource = firmalar_Classes;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Firma Adı";
            dataGridView1.Columns[2].HeaderText = "İletişim";


            // GorevleriGetir metodunun doğru sınıfı döndürüp döndürmediğini kontrol edin
            List<TaskClass> gorevlerList = new List<TaskClass>();
            gorevlerList = TaskRepository.GorevleriGetir(); // Eğer metod List<gorevler> döndürüyor ise

            // ListBox'a veri ekle
            listBox1.DataSource = gorevlerList;

            List<StatusClass> statusList = new List<StatusClass>();
            statusList = StatusRepository.statusList();

            listBox2.DataSource = statusList;

        }

        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void frmadmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (alankontrol.TextBoxlariKontrolEt((textBox1, "Ad Soyad"), (textBox2, "Mail")) ||
                alankontrol.ComboBoxBosMu(comboBox1, "Bölüm") ||
                alankontrol.ComboBoxBosMu(comboBox2, "Durum"))

            {
                return;
            }
            int id = 0;
            
            
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                id = Convert.ToInt32(textBox5.Text);
            }


            bool kontrol = WorkOrderRepository.check(id);

            if(!kontrol && id == 0)
            {
                    string ad_soyad = textBox1.Text;
                    string bolum = comboBox1.Text;
                    string personel_durum = comboBox2.Text;
                    string mail = textBox2.Text;
                    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(textBox2.Text, emailPattern))
                {
                    MessageBox.Show("Lütfen geçerli bir mail adresi giriniz.");
                    textBox2.Focus();  // Kullanıcıdan tekrar mail adresini girmesini isteyebiliriz.
                }
                else
                {
                    PersonelClass personel_Class = new PersonelClass(ad_soyad, bolum, personel_durum, mail);
                    PersonelRepositroy.AddPersonel(personel_Class);
                    yükle();
                    MessageBox.Show("Personel Eklendi");
                    temizle();
                }
            }
            else 
            { 
            if (string.IsNullOrEmpty(textBox5.Text))
            { MessageBox.Show("Lütfen güncellemek istediğiniz personeli seçiniz"); }
            else
            {
                    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                    if (!Regex.IsMatch(textBox2.Text, emailPattern))
                    {
                        MessageBox.Show("Lütfen geçerli bir mail adresi giriniz.");
                        textBox2.Focus();  // Kullanıcıdan tekrar mail adresini girmesini isteyebiliriz.
                    }
                    else
                    {
                        id = Convert.ToInt32(textBox5.Text);
                        string ad_soyad = textBox1.Text;
                        string bolum = comboBox1.Text;
                        string personel_durum = comboBox2.Text;
                        string mail = textBox2.Text;
                        
                        PersonelClass personel_guncelle = new PersonelClass(id, ad_soyad, bolum, personel_durum, mail);
                        PersonelRepositroy.UpdatePersonel(personel_guncelle);
                        yükle();
                        MessageBox.Show("Personel Güncellendi");
                        temizle();
                    }
            }
            }
            

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int durumuColumnIndex = 3;

            if (e.ColumnIndex == durumuColumnIndex)
            {
                if (e.Value != null && e.Value.ToString().ToLower() == "pasif")
                {
                    e.CellStyle.BackColor = Color.Gray;
                    e.CellStyle.ForeColor = Color.White;
  
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    comboBox1.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    comboBox2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                    textBox2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("hata" + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try { 
                textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("hata" + ex);
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Silmek istediğiniz firmayı seçin");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Firmayı silmek istediğinizden emin misiniz?", "Silme onayı", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    CompanyRepository.DeleteCompany(int.Parse(textBox6.Text));
                    yükle();
                    MessageBox.Show("Firma silindi");

                }
            }
            temizle();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Silmek istediğiniz personeli seçiniz");
            }
            else
            {
                //int id = int.Parse(textBox5.Text);
                DialogResult dr = MessageBox.Show("Personeli silmek istediğinizden emin misiniz?", "Silme onayı", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    PersonelRepositroy.DeletePersonel(int.Parse(textBox5.Text));
                    yükle();
                    MessageBox.Show("Personel silindi");
                    temizle();
                }
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            //string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            //if (!Regex.IsMatch(textBox2.Text, emailPattern))
            //{
            //    MessageBox.Show("Lütfen geçerli bir mail adresi giriniz.");
            //    textBox2.Focus();  // Kullanıcıdan tekrar mail adresini girmesini isteyebiliriz.
            //}
        }

        private void button8_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (alankontrol.TextBoxlariKontrolEt((textBox3, "Firma Adı"), (textBox4, "İletişim")))

            {
                return;
            }
            int id = 0;
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                id = Convert.ToInt32(textBox6.Text);
            }

            bool kontrol = WorkOrderRepository.check(id);

            if (!kontrol && id == 0)
            {
                

                string firma_ad = textBox3.Text;
                string iletisim = textBox4.Text;

                CompanyClass firmalar_ = new CompanyClass(firma_ad, iletisim);
                CompanyRepository.AddCompany(firmalar_);
                yükle();
                MessageBox.Show("Fİrma Eklendi");
                temizle();
            }
            else
            {
                    int id_firma = int.Parse(textBox6.Text);
                    string firma_adi = textBox3.Text;
                    string iletisim = textBox4.Text;

                    CompanyClass firma_guncelle = new CompanyClass(id_firma, firma_adi, iletisim);
                CompanyRepository.UpdateCompany(firma_guncelle);
                    yükle();
                    MessageBox.Show("Firma Güncellendi");
                    temizle();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            

            int id = 0;
            string yeni_gorev = textBox7.Text;
            if (!string.IsNullOrEmpty(yeni_gorev))
            {
                int mevcutGorevId = TaskRepository.GetTaskIdByName(yeni_gorev);

                if(mevcutGorevId!=-1)
                {
                    MessageBox.Show("Aynı isimde bir görev mevcut");
                }
                else
                { 
                TaskClass gorevler_ = new TaskClass(id,yeni_gorev);
                TaskRepository.AddGorev(gorevler_);
                MessageBox.Show("Görev Eklendi");
                List<TaskClass> gorevlerList = new List<TaskClass>();
                gorevlerList = TaskRepository.GorevleriGetir(); // Eğer metod List<gorevler> döndürüyor ise
                
                    
                    // ListBox'a veri ekle
                listBox1.DataSource = gorevlerList;
                textBox7.Clear();
                }
            }
            else
            {
                MessageBox.Show("Lütfen yeni görev girin");
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string seciliGorev = listBox1.SelectedItems[0].ToString();

            if (!string.IsNullOrEmpty(seciliGorev))
            {
                TaskRepository.DeleteGorev(seciliGorev);

                List<TaskClass> gorevlerList = TaskRepository.GorevleriGetir();

                listBox1.DataSource = null;
                listBox1.DataSource = gorevlerList;
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz görevi seçin.");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox8.Text.Trim().ToLower();

            // Tüm iş emirlerini getir
            List<PersonelClass> personelList = PersonelRepositroy.GetAllPersonels();

            // İş emirlerini DataTable'a dönüştür
            DataTable searchDt = new DataTable();
            searchDt.Columns.Add("personel_id", typeof(int));
            searchDt.Columns.Add("ad_soyad", typeof(string));
            searchDt.Columns.Add("bolum", typeof(string));
            searchDt.Columns.Add("durum", typeof(string));
            searchDt.Columns.Add("mail", typeof(string));

            foreach (var personel in personelList)
            {
                DataRow row = searchDt.NewRow();
                row["personel_id"] = personel.id;
                row["ad_soyad"] = personel.ad_soyad;
                row["bolum"] = personel.bolum;
                row["durum"] = personel.personel_durum;
                row["mail"] = personel.mail;
                

                searchDt.Rows.Add(row);
            }

            // Filtreleme ifadesini oluştur
            string filterExpression = string.Empty;
            foreach (DataColumn column in searchDt.Columns)
            {
                if (column.DataType == typeof(string))
                {
                    if (filterExpression.Length > 0)
                        filterExpression += " OR ";

                    filterExpression += string.Format("CONVERT([{0}], System.String) LIKE '%{1}%'", column.ColumnName, searchValue);
                }
            }

            // DataTable'ı bir DataView'e dönüştür ve filtre uygula
            DataView dv = searchDt.DefaultView;
            dv.RowFilter = filterExpression;

            // DataGridView'ın veri kaynağını güncelle
            dataGridView2.DataSource = dv.ToTable();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox9.Text.Trim().ToLower();

            // Tüm iş emirlerini getir
            List<CompanyClass> firmalarList = CompanyRepository.GetAllCompanys();

            // İş emirlerini DataTable'a dönüştür
            DataTable searchDt = new DataTable();
            searchDt.Columns.Add("firma_id", typeof(int));
            searchDt.Columns.Add("firma_adi", typeof(string));
            searchDt.Columns.Add("iletisim", typeof(string));


            foreach (var firma in firmalarList)
            {
                DataRow row = searchDt.NewRow();
                row["firma_id"] =firma.id_firma ;
                row["firma_adi"] = firma.firma_adi;
                row["iletisim"] = firma.iletisim;



                searchDt.Rows.Add(row);
            }

            // Filtreleme ifadesini oluştur
            string filterExpression = string.Empty;
            foreach (DataColumn column in searchDt.Columns)
            {
                if (column.DataType == typeof(string))
                {
                    if (filterExpression.Length > 0)
                        filterExpression += " OR ";

                    filterExpression += string.Format("CONVERT([{0}], System.String) LIKE '%{1}%'", column.ColumnName, searchValue);
                }
            }

            // DataTable'ı bir DataView'e dönüştür ve filtre uygula
            DataView dv = searchDt.DefaultView;
            dv.RowFilter = filterExpression;

            // DataGridView'ın veri kaynağını güncelle
            dataGridView1.DataSource = dv.ToTable();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Görev adını güncellemek için textboxa yeni görev adı giriniz");
                return;
            }
            if (listBox1.SelectedItem is TaskClass selectedTask)
            {
                int id = selectedTask.id;
                string gorev = textBox7.Text;

                TaskClass taskClass = new TaskClass(id, gorev);
                TaskRepository.UpdateTask(taskClass);

                MessageBox.Show("Görev Güncellendi");

                List<TaskClass> gorevlerList = TaskRepository.GorevleriGetir();

                listBox1.DataSource = gorevlerList;
                listBox1.DisplayMember = "gorev";  // ListBox'ta hangi sütunun gösterileceğini belirtin
                textBox7.Clear();
            }

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = listBox1.SelectedItem.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int id = 0;
            string yeni_durum = textBox10.Text;

            if(!string.IsNullOrEmpty(yeni_durum))
            {
                int mevcutDurumID = StatusRepository.GetStatusIdByName(yeni_durum);

                if(mevcutDurumID!=-1)
                {
                    MessageBox.Show("Aynı isimde bir durum mevcut");
                }
                else
                {
                    StatusClass status = new StatusClass(id, yeni_durum);
                    StatusRepository.AddStatus(status);

                    List<StatusClass> statusList = new List<StatusClass>();
                    statusList = StatusRepository.statusList();

                    listBox2.DataSource = statusList;
                    textBox10.Clear();
                }
            }
            else
            {
                MessageBox.Show("Lütfen yeni durum giriniz");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                // Seçili öğeyi StatusClass tipine dönüştür
                StatusClass seciliDurum = (StatusClass)listBox2.SelectedItems[0];

                if (seciliDurum != null)
                {
                    StatusRepository.DeleteStatus(seciliDurum);

                    List<StatusClass> status = StatusRepository.statusList();

                    listBox2.DataSource = null;
                    listBox2.DataSource = status;
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz durumu seçin.");
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Görev adını güncellemek için textboxa yeni görev adı giriniz");
                return;
            }
            if (listBox2.SelectedItem is StatusClass selectedStatus)
            {
                int id = selectedStatus.id;
                string durum = textBox10.Text;

                StatusClass statusClass = new StatusClass(id, durum);
                StatusRepository.UpdateStatus(statusClass);

                MessageBox.Show("Görev Güncellendi");

                List<StatusClass> statusList = StatusRepository.statusList();

                listBox2.DataSource = statusList;
                listBox2.DisplayMember = "durum";  // ListBox'ta hangi sütunun gösterileceğini belirtin
                textBox10.Clear();
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox10.Text = listBox2.SelectedItem.ToString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
