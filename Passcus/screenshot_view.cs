using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Passcus
{
    public partial class screenshot_view : Form
    {
        public screenshot_view()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog kyd = new SaveFileDialog();
            kyd.Title="Kaydet";
            kyd.Filter = "Jpeg Dosyaları|*.jpg|Png Dosyları|*.png|Bmp Dosyaları|*.bmp";
            if (kyd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(kyd.FileName);
                MessageBox.Show("Görüntü kaydedildi.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
