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
    public partial class new_password : Form
    {
        public new_password()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        string base64 = "";
        string password;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label2.Visible = false;
                textBox2.Visible = false;
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                label2.Visible = true;
                textBox2.Visible = true;
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 7)
            {
                if (checkBox1.Checked == false&&textBox1.Text==textBox2.Text)
                {
                    try
                    {
                        baglan.Open();
                       // screenshot();
                        OleDbCommand komut = new OleDbCommand("update security set pass=@pass,where=@degis", baglan);
                        komut.Parameters.AddWithValue("@pass", textBox1.Text);
                        komut.Parameters.AddWithValue("@degis", password);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Parolanız değiştirildi 'Admin' kullanıcı adıyla giriş yapınız.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                        gunce.Parameters.AddWithValue("@olay", "Şifre değişikliği.");
                        gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                        gunce.Parameters.AddWithValue("@ekranalıntısı",base64);
                        gunce.ExecuteNonQuery();
                        baglan.Close();
                        Application.Restart();
                     //   MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglan.Close();
                    }
                
                    this.Close();
                }
                if (checkBox1.Checked == false && textBox1.Text != textBox2.Text)
                {
                    MessageBox.Show("Parolalar uyuşmuyor.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (checkBox1.Checked == true)
                {
                    try
                    {
                        baglan.Open();
                        //screenshot();
                        OleDbCommand komut = new OleDbCommand("update security set pass=@pass where pass=@degis", baglan);
                        komut.Parameters.AddWithValue("@pass", textBox1.Text);
                        komut.Parameters.AddWithValue("@degis", password);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Parolanız değiştirildi 'Admin' kullanıcı adıyla giriş yapınız.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                        gunce.Parameters.AddWithValue("@olay", "Şifre değişikliği.");
                        gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                        gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                        gunce.ExecuteNonQuery();
                        baglan.Close();
                        Application.Restart();
                        //   MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglan.Close();
                    } 
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Parola çok kısa en az 8 haneli olmalıdır.","PassCus",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void new_password_Load(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                //screenshot();
                OleDbCommand komut = new OleDbCommand("Select *from security", baglan);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    password = oku["pass"].ToString();
                   
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            }
        }
    }
}
