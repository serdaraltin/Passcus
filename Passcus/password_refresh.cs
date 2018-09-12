using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Data.OleDb;
namespace Passcus
{
    public partial class password_refresh : Form
    {
        public password_refresh()
        {
            InitializeComponent();
        }
        int sec_code;
        int watchsecond = 300;
        int senmailcount = 0;
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
       string base64 = "";
        string persmail;
        string perspass;
        string question;
        string reply;
        string mail;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel3.Visible = true;
                panel2.Visible = false;
                panel1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                panel2.Visible = true;
                panel3.Visible = false;
                panel1.Visible = false;
            }
        }

        private void password_refresh_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Restart();
           /* security sec = new security();
            sec.Show();*/
        }
        private void mail_text()
        {
            try
            {
                string textmail = mail;
                int server = textmail.IndexOf("@");
                string servername = mail.Remove(0, server - 1);
                label_mail.Text = "E-Posta Adresi : " + mail.Substring(0, 1).ToString() + "*****" + servername;
            }
            catch { }
        }
        private void password_refresh_Load(object sender, EventArgs e)
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

                OleDbCommand komut2 = new OleDbCommand("Select *from question", baglan);
                OleDbDataReader oku2 = komut2.ExecuteReader();
                while (oku2.Read())
                {
                    question = oku2["question"].ToString();
                    reply = oku2["reply"].ToString();
                }

                OleDbCommand komut3 = new OleDbCommand("Select *from mail", baglan);
                OleDbDataReader oku3 = komut3.ExecuteReader();
                while (oku3.Read())
                {
                    mail = oku3["mail"].ToString();
                   
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            mail_text();
            if (radioButton1.Checked == true) panel3.Visible = true;
            if (radioButton2.Checked == true) panel1.Visible = true;
            if (radioButton3.Checked == true) panel2.Visible = true;
            label_ques_sec.Text = question;
         }
        private void sec_mail()
        {
            if (text_mail.Text != mail)
            {
                try
                {
                    baglan.Open();
                    //screenshot();
                    OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                    gunce.Parameters.AddWithValue("@olay", "E-posta denemesi.");
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
                MessageBox.Show("E-posta adresi uyuşmuyor !", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                Random random = new Random();
                int code = random.Next(10000000, 99999999);
                sec_code = code;
                MailMessage eposta = new MailMessage();
                eposta.From = new MailAddress(persmail);
                eposta.To.Add(mail);
                eposta.Subject = "PassCus Doğrulama Kodu";
                eposta.Body = "Sayın PassCus Kullanıcısı" + Environment.NewLine +
                "Bu e-posta adresi PassCus Hesabınızı kurtarmak için kullanılmaktadır." + Environment.NewLine +
                "Hesabınızı kurtarmak için aşağıdaki kodu ilgili alana yazınız." + Environment.NewLine + Environment.NewLine +
                "Güvenlik Kodu : " + code.ToString() + Environment.NewLine + Environment.NewLine +
                "Saygılarımla," + Environment.NewLine +
                "PassCus Hesapları Ekibi";
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential(persmail, perspass);
                smtp.Port = 587;
                smtp.Host = "smtp.yandex.com";
                smtp.EnableSsl = true;
                //smtp.SendAsync(eposta, (object)eposta);
                try
                {
                    smtp.Send(eposta);
                    text_mailcode.Enabled = true;
                    button_mail.Enabled = false;
                    button_mailcode.Enabled = true;
                    watchsecond = 300;
                    timer_watch.Enabled = true;
                    label_wath.ForeColor = Color.Black;
                    linklabel_mail.Enabled = true;
                    MessageBox.Show("Güvenlik Kodu başarıyla gönderildi." + Environment.NewLine + "Mail kutunuzu kontrol ediniz.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void button_mail_Click(object sender, EventArgs e)
        {
            sec_mail();
        }

        private void button_mailcode_Click(object sender, EventArgs e)
        {
            if (text_mailcode.Text == sec_code.ToString())
            {
                linklabel_mail.Enabled = false;
                timer_watch.Enabled = false;
                label_wath.Text = "";
                label_wath.ForeColor = Color.Black;
                label_mail_newpass.Text = "Yönlendiriliyorsunuz...";
                label_mail_newpass.ForeColor = Color.DodgerBlue;

                new_password pass = new new_password();
                pass.ShowDialog();
                this.Close();
            }
            else
            {
                try
                {
                    baglan.Open();
                    //screenshot();
                    OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                    gunce.Parameters.AddWithValue("@olay", "E-posta kod denemesi.");
                    gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                    gunce.ExecuteNonQuery();
                    baglan.Close();
                  //  MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Kod hatalı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void text_mailcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer_watch_Tick(object sender, EventArgs e)
        {
            if (watchsecond <= 1)
            {
            
                timer_watch.Enabled = false;
                sec_code = 0;
                label_wath.Text = "";
                label_wath.ForeColor = Color.Black;
                text_mailcode.Enabled = false;
                button_mailcode.Enabled = false;
         
            }
            if (watchsecond <= 50) label_wath.ForeColor = Color.Orange;
            if (watchsecond <= 30) label_wath.ForeColor = Color.Brown;
            if (watchsecond <= 10) label_wath.ForeColor = Color.Red;
            watchsecond -=1;
            label_wath.Text = watchsecond.ToString() + " sn";

        }

        private void linklabel_mail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sec_mail();
            /*else
            {
                MessageBox.Show("Çok fazla istekde bulundunuz.5 dk sonra tekrar deneyiniz.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                data.Default.retention = (DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + 5).ToString();
                data.Default.Save();
                MessageBox.Show(data.Default.retention);
            }*/
        }

        private void button_sec_Click(object sender, EventArgs e)
        {
            if (text_reply_sec.Text != "")
            {
                if (text_reply_sec.Text == reply)
                {
                    new_password pass = new new_password();
                    pass.ShowDialog();
                    this.Close();
                }
                else
                {
                    try
                    {
                        baglan.Open();
                       // screenshot();
                        OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                        gunce.Parameters.AddWithValue("@olay", "Güvenlik sorusu denemesi.");
                        gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                        gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                        gunce.ExecuteNonQuery();
                        baglan.Close();
                      //  MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show("Cevap Yanlış.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            access_renewal ar = new access_renewal();
            ar.ShowDialog();
        }

    
    }
}
