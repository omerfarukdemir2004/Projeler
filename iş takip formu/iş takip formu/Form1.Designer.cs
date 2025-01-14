namespace iş_takip_formu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_baslik = new System.Windows.Forms.TextBox();
            this.txt_yapilacak_is = new System.Windows.Forms.TextBox();
            this.dateTime_baslangic = new System.Windows.Forms.DateTimePicker();
            this.dateTimebitis = new System.Windows.Forms.DateTimePicker();
            this.txt_iskodu = new System.Windows.Forms.TextBox();
            this.richtext_aciklama = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox_durum = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.firma_adi_comboBox = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combo_ad = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new ADGV.AdvancedDataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.combobox_status = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ımageList3 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(658, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "İş Takip Formu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(68, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Başlık";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(68, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "İşi Yapacak Kişi";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(68, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Müşteri";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(68, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Yapılcak iş";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(68, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Görev";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(605, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Başlangıç Tarihi";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(605, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "Biriş Tarihi";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(605, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 29);
            this.label9.TabIndex = 8;
            this.label9.Text = "İş no(kodu)";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(605, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 29);
            this.label10.TabIndex = 9;
            this.label10.Text = "Açıklama";
            // 
            // txt_baslik
            // 
            this.txt_baslik.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_baslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_baslik.Location = new System.Drawing.Point(267, 84);
            this.txt_baslik.Name = "txt_baslik";
            this.txt_baslik.Size = new System.Drawing.Size(246, 30);
            this.txt_baslik.TabIndex = 11;
            // 
            // txt_yapilacak_is
            // 
            this.txt_yapilacak_is.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_yapilacak_is.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_yapilacak_is.Location = new System.Drawing.Point(267, 234);
            this.txt_yapilacak_is.Name = "txt_yapilacak_is";
            this.txt_yapilacak_is.Size = new System.Drawing.Size(246, 30);
            this.txt_yapilacak_is.TabIndex = 14;
            // 
            // dateTime_baslangic
            // 
            this.dateTime_baslangic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTime_baslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTime_baslangic.Location = new System.Drawing.Point(810, 82);
            this.dateTime_baslangic.Name = "dateTime_baslangic";
            this.dateTime_baslangic.Size = new System.Drawing.Size(325, 30);
            this.dateTime_baslangic.TabIndex = 16;
            // 
            // dateTimebitis
            // 
            this.dateTimebitis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimebitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimebitis.Location = new System.Drawing.Point(810, 133);
            this.dateTimebitis.Name = "dateTimebitis";
            this.dateTimebitis.Size = new System.Drawing.Size(325, 30);
            this.dateTimebitis.TabIndex = 16;
            // 
            // txt_iskodu
            // 
            this.txt_iskodu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_iskodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_iskodu.Location = new System.Drawing.Point(810, 184);
            this.txt_iskodu.Name = "txt_iskodu";
            this.txt_iskodu.Size = new System.Drawing.Size(246, 30);
            this.txt_iskodu.TabIndex = 17;
            this.txt_iskodu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_iskodu_KeyPress);
            // 
            // richtext_aciklama
            // 
            this.richtext_aciklama.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.richtext_aciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richtext_aciklama.Location = new System.Drawing.Point(810, 236);
            this.richtext_aciklama.Name = "richtext_aciklama";
            this.richtext_aciklama.Size = new System.Drawing.Size(325, 129);
            this.richtext_aciklama.TabIndex = 18;
            this.richtext_aciklama.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageKey = "2550289.png";
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(1212, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 77);
            this.button1.TabIndex = 19;
            this.button1.Text = "Kaydet";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "3807871.png");
            this.ımageList1.Images.SetKeyName(1, "2550289.png");
            this.ımageList1.Images.SetKeyName(2, "png-transparent-computer-icons-update-button-miscellaneous-angle-logo-thumbnail.p" +
        "ng");
            this.ımageList1.Images.SetKeyName(3, "9703596.png");
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageKey = "3807871.png";
            this.button3.ImageList = this.ımageList1;
            this.button3.Location = new System.Drawing.Point(1212, 222);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 77);
            this.button3.TabIndex = 21;
            this.button3.Text = "Sil";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox_durum
            // 
            this.comboBox_durum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_durum.BackColor = System.Drawing.Color.White;
            this.comboBox_durum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_durum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_durum.FormattingEnabled = true;
            this.comboBox_durum.Location = new System.Drawing.Point(267, 282);
            this.comboBox_durum.Name = "comboBox_durum";
            this.comboBox_durum.Size = new System.Drawing.Size(246, 33);
            this.comboBox_durum.TabIndex = 23;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageKey = "9703596.png";
            this.button4.ImageList = this.ımageList1;
            this.button4.Location = new System.Drawing.Point(1345, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(147, 73);
            this.button4.TabIndex = 25;
            this.button4.Text = "admin";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // firma_adi_comboBox
            // 
            this.firma_adi_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.firma_adi_comboBox.BackColor = System.Drawing.Color.White;
            this.firma_adi_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firma_adi_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.firma_adi_comboBox.FormattingEnabled = true;
            this.firma_adi_comboBox.Location = new System.Drawing.Point(267, 179);
            this.firma_adi_comboBox.Name = "firma_adi_comboBox";
            this.firma_adi_comboBox.Size = new System.Drawing.Size(246, 33);
            this.firma_adi_comboBox.TabIndex = 26;
            this.firma_adi_comboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.firma_adi_comboBox_DrawItem);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.Color.AliceBlue;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ImageKey = "clear-icon-15.png";
            this.button5.ImageList = this.ımageList2;
            this.button5.Location = new System.Drawing.Point(1091, 368);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(44, 40);
            this.button5.TabIndex = 27;
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "clear-icon-15.png");
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.Location = new System.Drawing.Point(106, 405);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 30);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(19, 408);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 25);
            this.label11.TabIndex = 29;
            this.label11.Text = "Search:";
            // 
            // combo_ad
            // 
            this.combo_ad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_ad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.combo_ad.FormattingEnabled = true;
            this.combo_ad.Location = new System.Drawing.Point(267, 132);
            this.combo_ad.Name = "combo_ad";
            this.combo_ad.Size = new System.Drawing.Size(246, 33);
            this.combo_ad.TabIndex = 32;
            this.combo_ad.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.combo_ad_DrawItem_1);
            this.combo_ad.SelectedIndexChanged += new System.EventHandler(this.combo_ad_SelectedIndexChanged_1);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoGenerateContextFilters = true;
            this.dataGridView2.ColumnHeadersHeight = 50;
            this.dataGridView2.DateWithTime = false;
            this.dataGridView2.Location = new System.Drawing.Point(12, 441);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1480, 268);
            this.dataGridView2.TabIndex = 31;
            this.dataGridView2.TimeFilter = false;
            this.dataGridView2.SortStringChanged += new System.EventHandler(this.dataGridView2_SortStringChanged);
            this.dataGridView2.FilterStringChanged += new System.EventHandler(this.dataGridView2_FilterStringChanged);
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView2.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView2_SortCompare);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label12.Location = new System.Drawing.Point(68, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 29);
            this.label12.TabIndex = 34;
            this.label12.Text = "İş Durumu";
            // 
            // combobox_status
            // 
            this.combobox_status.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combobox_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.combobox_status.FormattingEnabled = true;
            this.combobox_status.Location = new System.Drawing.Point(267, 332);
            this.combobox_status.Name = "combobox_status";
            this.combobox_status.Size = new System.Drawing.Size(246, 33);
            this.combobox_status.TabIndex = 35;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.ImageKey = "732220.png";
            this.button2.ImageList = this.ımageList3;
            this.button2.Location = new System.Drawing.Point(1312, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 88);
            this.button2.TabIndex = 36;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.AliceBlue;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.ImageKey = "free-pdf-icon-3385-thumb.png";
            this.button6.ImageList = this.ımageList3;
            this.button6.Location = new System.Drawing.Point(1405, 347);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 88);
            this.button6.TabIndex = 37;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ımageList3
            // 
            this.ımageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList3.ImageStream")));
            this.ımageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList3.Images.SetKeyName(0, "732220.png");
            this.ımageList3.Images.SetKeyName(1, "free-pdf-icon-3385-thumb.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1504, 699);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.combobox_status);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.combo_ad);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.firma_adi_comboBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox_durum);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richtext_aciklama);
            this.Controls.Add(this.txt_iskodu);
            this.Controls.Add(this.dateTimebitis);
            this.Controls.Add(this.dateTime_baslangic);
            this.Controls.Add(this.txt_yapilacak_is);
            this.Controls.Add(this.txt_baslik);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_baslik;
        private System.Windows.Forms.TextBox txt_yapilacak_is;
        private System.Windows.Forms.DateTimePicker dateTime_baslangic;
        private System.Windows.Forms.DateTimePicker dateTimebitis;
        private System.Windows.Forms.TextBox txt_iskodu;
        private System.Windows.Forms.RichTextBox richtext_aciklama;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ComboBox comboBox_durum;
        
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baslikDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adsoyadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musteriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yapilacakisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baslangictarihDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitistarihDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklamaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kalangunDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox firma_adi_comboBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox combo_ad;
        private ADGV.AdvancedDataGridView dataGridView2;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox combobox_status;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList ımageList3;
        private System.Windows.Forms.Button button6;
    }
}

