using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Passcus
{
    public partial class security_data : Form
    {
        public security_data()
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
               // screenshot();
                OleDbCommand komut = new OleDbCommand("insert into mail (mail) values(@mail)", baglan);
                komut.Parameters.AddWithValue("@mail", text_mail.Text);
                komut.ExecuteNonQuery();
                OleDbCommand komut2 = new OleDbCommand("insert into question (question,reply) values(@question,@reply)", baglan);
                komut2.Parameters.AddWithValue("@question", combo_question.Text);
                komut2.Parameters.AddWithValue("@reply", text_reply.Text);
                komut2.ExecuteNonQuery();
                OleDbCommand komut3 = new OleDbCommand("insert into phone (phone) values(@phone)", baglan);
                komut3.Parameters.AddWithValue("@phone", text_phone.Text);
                komut3.ExecuteNonQuery();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "güvenlik bilgileri girişi.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                gunce.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kurtarma verileriniz kaydedildi./" + Environment.NewLine + "Varsayılan Kullanıcı Adı : admin" + Environment.NewLine + "Varsayılan Parola : admin" + Environment.NewLine + "Güvenlik gerekçesiyle şifrenizi değştirin. ", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            }
        }

        private void security_data_Load(object sender, EventArgs e)
        {
            combo_question.Text = combo_question.Items[0].ToString();
        }
    }
}
