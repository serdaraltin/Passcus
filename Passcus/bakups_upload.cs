using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace Passcus
{
    public partial class bakups_upload : Form
    {
        public bakups_upload()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        string base64 = "";
        private void screenshot()
        {
            try
            {
                Size boyut = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Bitmap goruntu = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics grp = System.Drawing.Graphics.FromImage(goruntu);
                grp.CopyFromScreen(new Point(0, 0), new Point(0, 0), boyut);
                Bitmap ekranalıntısı = new Bitmap(goruntu);
                Byte[] resim = null;
                ImageConverter imgConverter = new ImageConverter();
                resim = (System.Byte[])imgConverter.ConvertTo(ekranalıntısı, Type.GetType("System.Byte[]"));
                base64 = Convert.ToBase64String(resim);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttun_sec_Click(object sender, EventArgs e)
        {
            OpenFileDialog sec = new OpenFileDialog();
            sec.Filter = "PassCus Veritabanı|*.bpcdb";
            sec.Title = "VeriTabanı Seç";
            if (sec.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = sec.FileName;
            }
        }
        private void button_test_Click(object sender, EventArgs e)
        {  OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +textBox1.Text + ";Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        try
        {
            baglan.Open();
            baglan.Close();
            MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception hata)
        {
            MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            baglan.Close();
        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             DialogResult yukle = MessageBox.Show("Yedeği yüklemek istediğinize emin misiniz ?", "PassCus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (yukle == DialogResult.Yes)
             {
                 try
                 {
                     File.Move(Application.StartupPath + "/data/data.pcdb", Application.StartupPath + "/backups/" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + ".bpcdb");
                     File.Copy(textBox1.Text, Application.StartupPath + "/data/data.pcdb");
                     try
                     {
                         baglan.Open();
                         //screenshot();
                         OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                         gunce.Parameters.AddWithValue("@olay", "Veritabanı yükleme.");
                         gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                         gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                         gunce.ExecuteNonQuery();
                         baglan.Close();
                     //    MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     catch (Exception hata)
                     {
                         MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                     OleDbConnection baglant = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";Persist Security Info=False;Jet OLEDB:Database Password=passcus");
                     try
                     {
                         baglant.Open();
                         baglant.Close();
                         MessageBox.Show("Veritabanı başarıyla yüklendi.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     catch (Exception hata)
                     {
                         MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         baglant.Close();
                     }
                 }
                 catch (Exception hata)
                 {
                     MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
        }

        private void bakups_upload_Load(object sender, EventArgs e)
        {

        }
    }
}
