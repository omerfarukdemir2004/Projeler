using ADGV;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.Filtering.Internal;
using iş_takip_formu.Repository;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace iş_takip_formu
{
    public partial class Form1 : Form
    {

        private BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<WorkOrderClass> workOrders = WorkOrderRepository.GetAllisemri();
            bindingSource.DataSource = workOrders;
            dataGridView2.DataSource = bindingSource;

            // AdvancedDataGridView ayarları
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AutoGenerateColumns = true;

            // Olayları bağlama
            dataGridView2.SortStringChanged += dataGridView2_SortStringChanged;
            dataGridView2.FilterStringChanged += dataGridView2_FilterStringChanged;

            griddoldur();
            List<PersonelClass> PersonelsList = new List<PersonelClass>();
            PersonelsList = PersonelRepositroy.GetAllPersonels();

            if (PersonelsList != null)
            {
                combo_ad.DataSource = PersonelsList;
                combo_ad.ValueMember = "id";
                combo_ad.DisplayMember = "ad_soyad";

                combo_ad.DrawMode = DrawMode.OwnerDrawFixed;
                combo_ad.DrawItem += new DrawItemEventHandler(combo_ad_DrawItem);
            }

            List<StatusClass> statusList = new List<StatusClass>();
            statusList = StatusRepository.statusList();


            combobox_status.DataSource = statusList;
            combobox_status.DisplayMember = "durum";

            SetupComboBox(firma_adi_comboBox, "firma_adi", "firma_id", CompanyRepository.GetAllCompanys());
            SetupComboBox(comboBox_durum, "gorev", "gorev_id", TaskRepository.GorevleriGetir());
            SetupComboBox(combobox_status, "durum", "durum_id", StatusRepository.statusList());

            temizle();

            #region designdatagrid
            // Arka plan ve ızgara ayarları
            dataGridView2.BackgroundColor = Color.AliceBlue; // Arka plan rengini beyaz yap
            dataGridView2.GridColor = Color.LightGreen; // Izgara çizgilerinin rengini açık yeşil yap
            dataGridView2.BorderStyle = BorderStyle.None; // Sınır stilini kaldır

            // Sütun başlıklarının stilini ayarla
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34); // Koyu yeşil arka plan
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Sütun başlık metnini beyaz yap
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold); // Daha büyük ve kalın font
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView2.RowHeadersVisible = false; // Satır başlıklarını gizle

            // Alternatif satır rengini ayarla
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144); // Açık yeşil

            // Hücre stilini ayarla
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 179, 113); // Orta yeşil seçili arka plan
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White; // Seçili hücre metnini beyaz yap
            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11); // Daha büyük varsayılan font

            // Sütun ve satır ayarları
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları formun genişliğine göre doldur
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırları hücre içeriğine göre ayarla
            dataGridView2.RowTemplate.Height = 30; // Sabit satır yüksekliği ayarla

            // Hücre kenarlıkları ve çizgileri kaldırma
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Genel font ayarları
            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11); // Daha büyük varsayılan font
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold); // Daha büyük ve kalın font

            // Alternatif satır rengini tekrar ayarla
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240); // Çok açık yeşil

            // Seçimi temizle
            dataGridView2.ClearSelection();
            #endregion



        }


        private void SetupComboBox(ComboBox comboBox, string displayMember, string valueMember, object dataSource)
        {
            // ComboBox'u DropDownList olarak ayarla
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // ComboBox'un DrawMode özelliğini OwnerDrawFixed olarak ayarla
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;

            // ComboBox'un DrawItem olayını işleyiciye bağla
            comboBox.DrawItem += new DrawItemEventHandler(CustomComboBox_DrawItem);

            // Veritabanından verileri çek ve ComboBox'a ekle
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember; // Görüntülenecek alan
            //comboBox.ValueMember = valueMember; // Değer alanı (veritabanındaki anahtar)
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

        void griddoldur()
        {
            dataGridView2.AutoGenerateColumns = true;
            List<WorkOrderClass> is_takipList = new List<WorkOrderClass>();
            is_takipList = WorkOrderRepository.GetAllisemri();
            dataGridView2.DataSource = is_takipList;

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Başlık";
            dataGridView2.Columns[2].HeaderText = "Adı Soyadı";
            dataGridView2.Columns[3].HeaderText = "Müşteri";
            dataGridView2.Columns[4].HeaderText = "Yapılacak İş";
            dataGridView2.Columns[5].HeaderText = "Görevi";
            dataGridView2.Columns[6].HeaderText = "İş Durumu";
            dataGridView2.Columns[7].HeaderText = "Başlangıç Tarihi";
            dataGridView2.Columns[8].HeaderText = "Bitiş Tarihi";
            dataGridView2.Columns[9].HeaderText = "İş No(Kodu)";
            dataGridView2.Columns[10].HeaderText = "Açıklama";
            dataGridView2.Columns[11].HeaderText = "Kalan Gün";


            dataGridView2.Columns["personel_id"].Visible = false;
            dataGridView2.Columns["musteri_id"].Visible = false;
            dataGridView2.Columns["gorev_id"].Visible = false;
            dataGridView2.Columns["durum_id"].Visible = false;


            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView2.Rows[i].Cells[11].Value) < 0)
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.OrangeRed;
                }
                else if (Convert.ToInt32(dataGridView2.Rows[i].Cells[11].Value) <= 1)
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.Orange;
                }
                else if (Convert.ToInt32(dataGridView2.Rows[i].Cells[11].Value) <= 3)
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.LawnGreen;
                }
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[6].Value.ToString() =="İptal" || dataGridView2.Rows[i].Cells[6].Value.ToString() == "İptal Edildi")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        void temizle()
        {
            txt_baslik.Clear();
            txt_iskodu.Clear();
            txt_yapilacak_is.Clear();
            combo_ad.SelectedIndex = -1;
            comboBox_durum.SelectedIndex = -1;
            firma_adi_comboBox.SelectedIndex = -1;
            combobox_status.SelectedIndex = -1;
            richtext_aciklama.Clear();
            dateTime_baslangic.Value = DateTime.Now;
            dateTimebitis.Value = DateTime.Now;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (alankontrol.TextBoxlariKontrolEt((txt_baslik, "Başlık"), (txt_yapilacak_is, "Yapılacak İş"), (txt_iskodu, "İş Kodu")) ||
                alankontrol.ComboBoxBosMu(combo_ad, "Ad Soyad") ||
                alankontrol.ComboBoxBosMu(firma_adi_comboBox, "Firma Adı") ||
                alankontrol.ComboBoxBosMu(comboBox_durum, "Görev") ||
                alankontrol.ComboBoxBosMu(combobox_status, "İş durumu") ||
                 alankontrol.RichTextBoxBosMu(richtext_aciklama, "Açıklama"))
            {
                return;
            }
            int isNo = Convert.ToInt32(txt_iskodu.Text);

            bool kontrol = WorkOrderRepository.check(isNo);

            if (!kontrol)
            {
                int id = 0;
                string baslik = txt_baslik.Text;
                string yapilacak_is = txt_yapilacak_is.Text;

                DateTime baslangic_tarihi = dateTime_baslangic.Value.Date;
                DateTime bitis_tarih = dateTimebitis.Value;
                int is_no = int.Parse(txt_iskodu.Text);
                string aciklama = richtext_aciklama.Text;
                //DateTime bugun = DateTime.Now.Date;
                int kalan_gun = (bitis_tarih - DateTime.Now.Date).Days;

                int result = DateTime.Compare(baslangic_tarihi, bitis_tarih);

                string ad_soyad = combo_ad.Text;
                int personel_id = PersonelRepositroy.GetPersonelIdByName(ad_soyad);

                string musteri = firma_adi_comboBox.Text;
                int musteri_id = CompanyRepository.GetFirmaIdByName(musteri);

                string gorev = comboBox_durum.Text;
                int gorev_id = TaskRepository.GetTaskIdByName(gorev);

                string durum = combobox_status.Text;
                int durum_id = StatusRepository.GetStatusIdByName(durum);
                //if(baslangic_tarihi<bugun)
                //{
                //    MessageBox.Show("Başlangıç tarihi günümüzden daha eski olamaz.");
                //    return;
                //}
                if (result > 0)
                {
                    MessageBox.Show("Başlangıç tarihi bitiş tarihinden daha eski olamaz.");
                    return;
                }
                else
                {
                    WorkOrderClass is_Takip = new WorkOrderClass(id, baslik, yapilacak_is, baslangic_tarihi, bitis_tarih, is_no, aciklama, kalan_gun, personel_id, musteri_id, gorev_id, durum_id);

                    WorkOrderRepository.AddWorkOrder(is_Takip);
                    griddoldur();
                    temizle();
                }
            }
            else
            {
                int id = 0;
                string baslik = txt_baslik.Text;

                string yapilacak_is = txt_yapilacak_is.Text;
                DateTime baslangic_tarihi = dateTime_baslangic.Value;
                DateTime bitis_tarih = dateTimebitis.Value;
                int is_no = int.Parse(txt_iskodu.Text);
                string aciklama = richtext_aciklama.Text;
                int kalan_gun = (bitis_tarih - DateTime.Now.Date).Days;

                string ad_soyad = combo_ad.Text;
                int personel_id = PersonelRepositroy.GetPersonelIdByName(ad_soyad);

                string musteri = firma_adi_comboBox.Text;
                int musteri_id = CompanyRepository.GetFirmaIdByName(musteri);

                string gorev = comboBox_durum.Text;
                int gorev_id = TaskRepository.GetTaskIdByName(gorev);

                string durum = combobox_status.Text;
                int durum_id = StatusRepository.GetStatusIdByName(durum);

                WorkOrderClass is_Takip = new WorkOrderClass(id, baslik, yapilacak_is, baslangic_tarihi, bitis_tarih, is_no, aciklama, kalan_gun, personel_id, musteri_id, gorev_id, durum_id);

                WorkOrderRepository.UpdateWorkOrder(is_Takip);
                griddoldur();
                MessageBox.Show("İş Emri Güncellendi");
                temizle();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_iskodu.Text))
            {
                MessageBox.Show("Silmek istediğiniz iş kodunu giriniz");
                txt_iskodu.Focus();
            }
            else
            {
                int is_no = int.Parse(txt_iskodu.Text);
                DialogResult dr = MessageBox.Show("İş emrini silmek istediğinizden emin misiniz?", "Silme onayı", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    WorkOrderRepository.DeleteWorkOrder(is_no);
                    griddoldur();
                    MessageBox.Show("İş emri silindi");
                }
                temizle();
            }
        }

        private void txt_iskodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim().ToLower();

            // Tüm iş emirlerini getir
            List<WorkOrderClass> isemriList = WorkOrderRepository.GetAllisemri();

            // İş emirlerini DataTable'a dönüştür
            DataTable searchDt = new DataTable();
            searchDt.Columns.Add("id", typeof(int));
            searchDt.Columns.Add("baslik", typeof(string));
            searchDt.Columns.Add("ad_soyad", typeof(string));
            searchDt.Columns.Add("musteri", typeof(string));
            searchDt.Columns.Add("yapilacak_is", typeof(string));
            searchDt.Columns.Add("gorev", typeof(string));
            searchDt.Columns.Add("durum", typeof(string));
            searchDt.Columns.Add("baslangic_tarih", typeof(DateTime));
            searchDt.Columns.Add("bitis_tarih", typeof(DateTime));
            searchDt.Columns.Add("is_no", typeof(int));
            searchDt.Columns.Add("aciklama", typeof(string));
            searchDt.Columns.Add("kalan_gun", typeof(int));

            foreach (var isemri in isemriList)
            {
                DataRow row = searchDt.NewRow();
                row["id"] = isemri.id;
                row["baslik"] = isemri.baslik;
                row["ad_soyad"] = isemri.ad_soyad;
                row["musteri"] = isemri.musteri;
                row["yapilacak_is"] = isemri.yapilacak_is;
                row["gorev"] = isemri.gorev;
                row["durum"] = isemri.durum;
                row["baslangic_tarih"] = isemri.baslangic_tarihi;
                row["bitis_tarih"] = isemri.bitis_tarih;
                row["is_no"] = isemri.is_no;
                row["aciklama"] = isemri.aciklama;
                row["kalan_gun"] = isemri.kalan_gun;

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
            renk();
        }

        void renk()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView2.Rows[i].Cells[11].Value) < 0)
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.OrangeRed;
                }
                else if (Convert.ToInt32(dataGridView2.Rows[i].Cells[11].Value) <= 1)
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.Orange;
                }
                else if (Convert.ToInt32(dataGridView2.Rows[i].Cells[11].Value) <= 3)
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    dataGridView2.Rows[i].Cells[11].Style.BackColor = Color.LawnGreen;
                }
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[6].Value.ToString() == "İptal" || dataGridView2.Rows[i].Cells[6].Value.ToString() == "İptal Edildi")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void combo_ad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_ad_DrawItem(object sender, DrawItemEventArgs e)
        {

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                    txt_baslik.Text = row.Cells[1].Value.ToString();
                    combo_ad.Text = row.Cells[2].Value.ToString();
                    firma_adi_comboBox.Text = row.Cells[3].Value.ToString();
                    txt_yapilacak_is.Text = row.Cells[4].Value.ToString();
                    comboBox_durum.Text = row.Cells[5].Value.ToString();
                    combobox_status.Text = row.Cells[6].Value.ToString();
                    dateTime_baslangic.Value = Convert.ToDateTime(row.Cells[7].Value);
                    dateTimebitis.Value = Convert.ToDateTime(row.Cells[8].Value);
                    txt_iskodu.Text = row.Cells[9].Value.ToString();
                    richtext_aciklama.Text = row.Cells[10].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void combo_ad_DrawItem_1(object sender, DrawItemEventArgs e)
        {

            ComboBox combo = (ComboBox)sender;
            if (e.Index < 0) return;

            // ComboBox'tan ilgili öğeyi alın
            PersonelClass person = (PersonelClass)combo.Items[e.Index];
            if (person == null) return;

            // Personel adını ve durumunu alın
            string name = person.ad_soyad;
            bool isActive = person.personel_durum.ToLower().Trim() == "aktif";

            // Arka plan rengini ve metin rengini belirleyin
            e.DrawBackground();

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
                e.Graphics.DrawString(name, e.Font, Brushes.White, e.Bounds);
            }
            else
            {
                if (!isActive)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                    e.Graphics.DrawString(name, e.Font, Brushes.DarkGray, e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    e.Graphics.DrawString(name, e.Font, Brushes.Black, e.Bounds);
                }

                e.DrawFocusRectangle();
            }
        }

        private void combo_ad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (combo_ad.SelectedItem is PersonelClass selectedPerson)
            {
                // "durum" özelliğini kontrol edin
                string durum = selectedPerson.personel_durum.ToLower().Trim();
                bool isActive = durum == "aktif";

                // Eğer pasifse, uyarı gösterin ve seçimi kaldırın
                if (!isActive)
                {
                    MessageBox.Show("Bu personel pasiftir ve seçilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_ad.SelectedIndex = -1; // Seçimi kaldır
                }
            }
        }

        private void firma_adi_comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private DataTable ConvertToDataTable(List<WorkOrderClass> list)
        {
            DataTable table = new DataTable();

            // Kolonları ekleyin
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("baslik", typeof(string));
            table.Columns.Add("ad_soyad", typeof(string));
            table.Columns.Add("firma_adi", typeof(string));
            table.Columns.Add("yapilacak_is", typeof(string));
            table.Columns.Add("gorev", typeof(string));
            table.Columns.Add("durum", typeof(string));
            table.Columns.Add("baslangic_tarih", typeof(DateTime));
            table.Columns.Add("bitis_tarih", typeof(DateTime));
            table.Columns.Add("is_no", typeof(int));
            table.Columns.Add("aciklama", typeof(string));
            table.Columns.Add("kalan_gun", typeof(int));

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Başlık";
            dataGridView2.Columns[2].HeaderText = "Adı Soyadı";
            dataGridView2.Columns[3].HeaderText = "Müşteri";
            dataGridView2.Columns[4].HeaderText = "Yapılacak İş";
            dataGridView2.Columns[5].HeaderText = "Görevi";
            dataGridView2.Columns[6].HeaderText = "İş Durumu";
            dataGridView2.Columns[7].HeaderText = "Başlangıç Tarihi";
            dataGridView2.Columns[8].HeaderText = "Bitiş Tarihi";
            dataGridView2.Columns[9].HeaderText = "İş No(Kodu)";
            dataGridView2.Columns[10].HeaderText = "Açıklama";
            dataGridView2.Columns[11].HeaderText = "Kalan Gün";

            // Satırları ekleyin
            foreach (var item in list)
            {
                table.Rows.Add(item.id, item.baslik, item.ad_soyad, item.musteri, item.yapilacak_is, item.gorev, item.durum, item.baslangic_tarihi, item.bitis_tarih, item.is_no, item.aciklama, item.kalan_gun);
            }

            return table;
        }
        private void dataGridView2_FilterStringChanged(object sender, EventArgs e)
        {


            List<WorkOrderClass> isEmriListesi = WorkOrderRepository.GetAllisemri();
            DataTable dataTable = ConvertToDataTable(isEmriListesi);
            dataGridView2.DataSource = dataTable;


            dataGridView2.AutoGenerateColumns = true;

            dataTable.DefaultView.RowFilter = dataGridView2.FilterString;
            renk();
        }

        private void dataGridView2_SortStringChanged(object sender, EventArgs e)
        {


            List<WorkOrderClass> isEmriListesi = WorkOrderRepository.GetAllisemri();
            DataTable dataTable = ConvertToDataTable(isEmriListesi);
            dataGridView2.DataSource = dataTable;


            dataGridView2.AutoGenerateColumns = true;
            dataTable.DefaultView.Sort = dataGridView2.SortString;


            renk();

        }

        private void dataGridView2_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "PDF Dosyaları";
            save.DefaultExt = "pdf";
            save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                PdfPTable pdfTable = new PdfPTable(dataGridView2.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).Count());

                // Font ayarları
                string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OpenSans-Regular.ttf"); // Font dosyasının yolu
                BaseFont baseFont;
                try
                {
                    baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Font dosyası yüklenemedi: {ex.Message}");
                    return;
                }
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10); // Font büyüklüğü ayarı

                // Bu alanlarla oynayarak tasarımı iyileştirebilirsiniz.
                pdfTable.DefaultCell.Padding = 5; // hücre duvarı ve veri arasında mesafe

                pdfTable.WidthPercentage = 100; // hücre genişliği
                pdfTable.HorizontalAlignment = Element.ALIGN_CENTER; // yazı hizalaması
                pdfTable.DefaultCell.BorderWidth = 1; // kenarlık kalınlığı

                // Sadece görünür sütunların başlıklarını ekle
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    if (column.Visible)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(144, 238, 144); // hücre arka plan rengi
                        pdfTable.AddCell(cell);
                    }
                }

                try
                {
                    // Sadece görünür sütunların verilerini ekle
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (dataGridView2.Columns[cell.ColumnIndex].Visible)
                            {
                                string cellValue = cell.Value?.ToString();
                                if (cell.Value is DateTime dateTime)
                                {
                                    cellValue = dateTime.ToString("yyyy-MM-dd"); // sadece tarih formatı
                                }
                                pdfTable.AddCell(new Phrase(cellValue, font));
                            }
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    // Handle exception if needed
                }

                try
                {
                    using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f); // Sayfa boyutu yatay olarak ayarlandı
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                    }

                    // Success message
                    MessageBox.Show("PDF dosyası başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Handle exception if needed
                    MessageBox.Show($"PDF dosyası kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Yeni bir Excel uygulaması oluşturulur
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Yeni bir Excel çalışma kitabı (workbook) oluşturulur
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);

            // Yeni bir çalışma sayfası (worksheet) oluşturulur ve ad verilir
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Name = "DataGridViewExport";

            try
            {
                // DataGridView sütun başlıklarını Excel'e aktar
                int columnIndex = 1; // Excel sütun indeksleri 1'den başlar
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    if (column.Visible) // Sadece görünür sütunları aktar
                    {
                        Microsoft.Office.Interop.Excel.Range headerCell = worksheet.Cells[1, columnIndex];
                        headerCell.Font.Bold = true; // Kalın yazı
                        headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen); // Yeşil arka plan
                        worksheet.Cells[1, columnIndex] = column.HeaderText;
                        columnIndex++;
                    }
                }

                // DataGridView hücre verilerini Excel'e aktar
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    // Boş satırları atla
                    if (!dataGridView2.Rows[i].IsNewRow)
                    {
                        columnIndex = 1; // Excel sütun indeksleri 1'den başlar
                        foreach (DataGridViewColumn column in dataGridView2.Columns)
                        {
                            if (column.Visible) // Sadece görünür sütunları aktar
                            {
                                object cellValue = dataGridView2.Rows[i].Cells[column.Index].Value;

                                // Eğer hücre değeri DateTime ise, sadece tarihi yazdır
                                if (cellValue is DateTime)
                                {
                                    worksheet.Cells[i + 2, columnIndex] = ((DateTime)cellValue).ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, columnIndex] = cellValue?.ToString();
                                }
                                columnIndex++;
                            }
                        }
                    }
                }

                // Sütun genişliklerini otomatik ayarla
                worksheet.Columns.AutoFit();

                // Satır yüksekliklerini otomatik ayarla
                worksheet.Rows.AutoFit();

                // Excel dosyasını kaydet
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Dosyası|*.xlsx",
                    Title = "Excel Dosyası Kaydet",
                    FileName = "DataGridViewExport"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Excel dosyası başarıyla kaydedildi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Excel işlemi temizlenir
                workbook.Close(false, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(workbook);
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}
