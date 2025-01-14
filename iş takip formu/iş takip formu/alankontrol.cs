using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iş_takip_formu
{
    internal class alankontrol
    {
        public static bool TextBoxBosMu(TextBox textBox, string alanAdi)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"{alanAdi} alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus(); // Boş alanın odaklanmasını sağlar
                return true;
            }
            return false;
        }

        // Birden fazla TextBox alanını kontrol eder
        public static bool TextBoxlariKontrolEt(params (TextBox, string)[] textBoxes)
        {
            foreach (var (textBox, alanAdi) in textBoxes)
            {
                if (TextBoxBosMu(textBox, alanAdi))
                    return true;
            }
            return false;
        }

        // ComboBox alanının boş olup olmadığını kontrol eder
        public static bool ComboBoxBosMu(ComboBox comboBox, string alanAdi)
        {
            if (comboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox.Text))
            {
                MessageBox.Show($"{alanAdi} alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox.Focus(); // Boş alanın odaklanmasını sağlar
                return true;
            }
            return false;
        }

        // RichTextBox alanının boş olup olmadığını kontrol eder
        public static bool RichTextBoxBosMu(RichTextBox richTextBox, string alanAdi)
        {
            if (string.IsNullOrWhiteSpace(richTextBox.Text))
            {
                MessageBox.Show($"{alanAdi} alanını boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox.Focus(); // Boş alanın odaklanmasını sağlar
                return true;
            }
            return false;
        }
    }
}
