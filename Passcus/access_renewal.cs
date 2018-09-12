using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.OleDb;
using System.IO;
namespace Passcus
{
    public partial class access_renewal : Form
    {
        public access_renewal()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        string base64 = "";
        string persmail;
        string perspass;
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
        private void button1_Click(object sender, EventArgs e)
        {
           
            MailMessage eposta = new MailMessage();
            eposta.From = new MailAddress(persmail);
            eposta.To.Add(persmail);
            eposta.Subject="Erişim Yenileme";
            eposta.Body = textBox3.Text;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential(persmail, perspass);
            smtp.Host = "smtp.yandex.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(eposta);
                try
                {
                    baglan.Open();
                    //screenshot();
                    OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                    gunce.Parameters.AddWithValue("@olay", "Şifre yenileme isteği.");
                    gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    gunce.Parameters.AddWithValue("@ekranalıntısı",base64);
                    gunce.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("İsteğiniz başarıyla alınmıştır en yakın zamanda belirtilen \n e-posta adresi üzerinden iletişime geçilecektir.Teşekkürler.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void access_renewal_Load(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Select *from personel", baglan);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    persmail = oku["mail"].ToString();
                    perspass = oku["pass"].ToString();
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = persmail;
        }

        private void access_renewal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
