using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
namespace Passcus
{
    public partial class security : Form
    {
        public security()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        string base64 = "";
        string id;
        string pass;
        string mail;
        string question;
        public void acces_renewal()
        {
            access_renewal secref = new access_renewal();
            secref.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (usertext.Text != "" && passtext.Text != "")
            {
                if (usertext.Text == id && passtext.Text == pass)
                {
                    Form1 main = new Form1();
                    main.Show();
                    this.Hide();
                 
                }
                else
                {
                    try
                    {
                       baglan.Open();
                        //screenshot();
                        OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                        gunce.Parameters.AddWithValue("@olay", "Giriş denemesi.");
                        gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                        gunce.Parameters.AddWithValue("@ekranalıntısı",base64);
                        gunce.ExecuteNonQuery();
                        baglan.Close(); 
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show("Kullanıcı adı veya parola yanlış !", "Passcus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                baglan.Open();
                //screenshot();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Şifremi unuttum.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                gunce.ExecuteNonQuery();
                baglan.Close();
               // MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            password_refresh pass_ref = new password_refresh();
            pass_ref.ShowDialog();
        }

        private void security_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                baglan.Open();
                //screenshot();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Giriş kapama.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                gunce.Parameters.AddWithValue("@ekranalıntısı",base64);
                gunce.ExecuteNonQuery();
                baglan.Close();
               // MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }

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
        private void security_Load(object sender, EventArgs e)
        {
            if (data.Default.otobackup == true)
            {
                bakups yedekle = new bakups();
                yedekle.ShowDialog();
            }

            if (data.Default.otodata == true)
            {
                if(File.Exists(Application.StartupPath+"/backups")==false)
                    Directory.CreateDirectory(Application.StartupPath+"/backups");
            }
          
            if (File.Exists(Application.StartupPath+"/data/data.pcdb") == false)
            {
                MessageBox.Show("Veritabanı bulunamadı.PassCus Kapatılacak.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            try
            {
                baglan.Open();
                //screenshot();
                OleDbCommand komut = new OleDbCommand("Select *from security", baglan);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    id = oku["id"].ToString();
                    pass = oku["pass"].ToString();
                }
                OleDbCommand komut2 = new OleDbCommand("Select *from mail", baglan);
                OleDbDataReader oku2 = komut2.ExecuteReader();
                while (oku2.Read())
                {
                    mail = oku2["mail"].ToString(); 
                }
                OleDbCommand komut3 = new OleDbCommand("Select *from question", baglan);
                OleDbDataReader oku3 = komut3.ExecuteReader();
                while (oku3.Read())
                {
                    question = oku3["question"].ToString();
                }
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Giriş açılış.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                gunce.ExecuteNonQuery();
                baglan.Close();
              
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            }
            if (mail == "" || question == "")
            {
                security_data sd = new security_data();
                sd.ShowDialog();
            }
            if (data.Default.idremember == true) usertext.Text = id;
        }

        private void passtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) button1.PerformClick();
        }
    }
}
