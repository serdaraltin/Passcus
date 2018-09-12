using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security;
using System.Security.Cryptography;
namespace Passcus
{
    public partial class new_save : Form
    {
        public new_save()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        string base64 = "";
        private void data_Save()
        {
            try
            {
               // screenshot();
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("insert into liste (Alan,Site,Mail,Id,Nick,Parola,Md5,Olusturma,Son,Ek,Ekran_Alıntısı) values(@alan,@site,@mail,@id,@nick,@parola,@md5,@olusturma,@son,@ek,@ekranalıntısı)", baglan);
                komut.Parameters.AddWithValue("@alan", text_alan.Text);
                komut.Parameters.AddWithValue("@site", text_site.Text);
                komut.Parameters.AddWithValue("@mail", text_mail.Text);
                komut.Parameters.AddWithValue("@id", text_id.Text);
                komut.Parameters.AddWithValue("@nick", text_nick.Text);
                komut.Parameters.AddWithValue("@parola", text_parola.Text);
                komut.Parameters.AddWithValue("@md5", text_md5.Text);
                komut.Parameters.AddWithValue("@olusturma", DateTime.Now.ToString());
                komut.Parameters.AddWithValue("@son", text_son.Text);
                komut.Parameters.AddWithValue("@ek", text_ek.Text);
                komut.Parameters.AddWithValue("@ekranalıntısı", base64);
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Yeni kayıt.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                gunce.ExecuteNonQuery();
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt yapıldı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textclear();
                Form1 main = new Form1();
                Button yenile = main.Controls["button_yenile"] as Button;
                yenile.PerformClick();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            }
        }

        public string md5(string sifre)
        {
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider sifreleme = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sifre);
                byte[] hash = sifreleme.ComputeHash(bytes);
                int kapasite = (hash.Length * 2 + (hash.Length / 8));
                System.Text.StringBuilder sb = new System.Text.StringBuilder(kapasite);
                int I = 0;
                for (I = 0; I <= hash.Length - 1; I++)
                {
                    sb.Append(BitConverter.ToString(hash, I, 1));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        private void textclear()
        {
            text_alan.Text = "";
            text_ek.Text = "";
            text_id.Text = "";
            text_mail.Text = "";
            text_md5.Text = "";
            text_nick.Text = "";
            text_olusturma.Text = "";
            text_parola.Text = "";
            text_site.Text = "";
            text_son.Text = "";
            
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

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            if (text_alan.Text != "" && text_id.Text != "" && text_mail.Text != "" && text_parola.Text != "") data_Save();
            else MessageBox.Show("Gerekli alanları doldurunuz !", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
        }

        private void text_parola_TextChanged(object sender, EventArgs e)
        {
            string parolamd5 = md5(text_parola.Text);
            text_md5.Text = parolamd5.ToLower();
        }

        private void new_save_Load(object sender, EventArgs e)
        {
            
        }

        private void button_güncelle_Click(object sender, EventArgs e)
        {//(Alan,Site,Mail,Id,Nick,Parola,Md5,Olusturma,Son,Ek,Ekran_Alıntısı)
            if (text_olusturma.Text != "")
            {
                DialogResult silmek = MessageBox.Show("Kaydı güncellemek istediğinizden emin misiniz ?", "PassCus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (silmek == DialogResult.Yes)
                {
                    try
                    {
                       // screenshot();
                        baglan.Open();
                        OleDbCommand komut = new OleDbCommand("update Liste set Alan=@alan,Site=@site,Mail=@mail,Id=@id,Nick=@nick,Parola=@parola,Md5=@md5,Olusturma=@olusturma,Son=@son,Ek=@ek,Ekran_Alıntısı=@ekranalıntısı Where Olusturma=@tayin",baglan);
                        komut.Parameters.AddWithValue("@alan", text_alan.Text);
                        komut.Parameters.AddWithValue("@site", text_site.Text);
                        komut.Parameters.AddWithValue("@mail", text_mail.Text);
                        komut.Parameters.AddWithValue("@id", text_id.Text);
                        komut.Parameters.AddWithValue("@nick", text_nick.Text);
                        komut.Parameters.AddWithValue("@parola", text_parola.Text);
                        komut.Parameters.AddWithValue("@md5", text_md5.Text);
                        komut.Parameters.AddWithValue("@olusturma", text_olusturma.Text);
                        komut.Parameters.AddWithValue("@son", DateTime.Now.ToString());
                        komut.Parameters.AddWithValue("@ek", text_ek.Text);
                        komut.Parameters.AddWithValue("@ekranalıntısı", base64);
                        komut.Parameters.AddWithValue("@tayin", text_olusturma.Text);
                        OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                        gunce.Parameters.AddWithValue("@olay", "Kayıt güncelleme.");
                        gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                        gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                        gunce.ExecuteNonQuery();;
                        komut.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("Güncellendi.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglan.Close();
                    }
                }
            }
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            if (text_olusturma.Text != "")
            {
                 DialogResult silmek = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz ?", "PassCus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (silmek == DialogResult.Yes)
                 {
                     try
                     {
                         baglan.Open();
                         OleDbCommand komut = new OleDbCommand("Delete From Liste Where Olusturma='" + text_olusturma.Text + "'", baglan);
                        // screenshot();
                         OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                         gunce.Parameters.AddWithValue("@olay", "Kayıt silme.");
                         gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                         gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                         gunce.ExecuteNonQuery();
                         komut.ExecuteNonQuery();
                         komut.Dispose();
                         baglan.Close();
                         MessageBox.Show("Kayıt silindi.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         this.Close();
                     }
                     catch (Exception hata)
                     {
                         MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         baglan.Close();
                     }
                 }
            }
            else MessageBox.Show("Kayıt bulunamadı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
