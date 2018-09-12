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
    public partial class bakups : Form
    {
        public bakups()
        {
            InitializeComponent();
        }
        int i = 0;
        string backup_base64 = null;
        bool base64_read = false;
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        private void bakups_Load(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.Gold;
            if (Directory.Exists(Application.StartupPath + "/data") == true) label1.Text = Application.StartupPath + "/data";
            if (Directory.Exists(Application.StartupPath + "/data/screenshot") == true) label1.Text = Application.StartupPath + "/data/screenshot";
            if (Directory.Exists(Application.StartupPath + "/backups") == true) label1.Text = Application.StartupPath + "/backups";
            if (File.Exists(Application.StartupPath + "/data/data.pcdb") == true) label1.Text = Application.StartupPath + "/data/data.pcdb";
            label1.Text = "Database connecting...";
            try
            {
                baglan.Open();
                baglan.Close();
                label1.Text = "Database connected";
            }
            catch { }
            read();
            timer1.Start();
        }
        private void encrypt()
        {
            if (backup_base64 != null && base64_read == true)
            {
                label1.Text = "Database encrypting...";
                string backups_wat = Application.StartupPath + "/backups/" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + ".bpcdb";
                File.Create(backups_wat).Close();
                string enc_base64 = null;
                for (int i = 0; i < backup_base64.Length - 1; i++)
                {
                    char ch = backup_base64[i];
                    int ascii = (int)ch;
                    int encrypt = (ascii * 10) / 4;
                    enc_base64 += encrypt.ToString();
                }
                label1.Text = "Database writing...";
                StreamWriter wrt = new StreamWriter(backups_wat);
                wrt.Write(enc_base64);
                wrt.Close();
                label1.Text = "Database written";
            }
        }
        private void read()
        {
            string data_wat = Application.StartupPath + "/data/data.pcdb";
            if (backup_base64 == null)
            {
                label1.Text = "Database reading...";
                byte[] bytes = null;
                bytes = File.ReadAllBytes(data_wat);
                backup_base64 = Convert.ToBase64String(bytes);
                label1.Text = "Database read";
                base64_read = true;
               // encrypt();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region eski
             progressBar1.Increment(1);
            i += 1;
            FileInfo filesize = new FileInfo(Application.StartupPath + "/data/data.pcdb");
            label1.Text ="Yedekleniyor : " +
            Convert.ToInt32((100 - i) * filesize.Length / (1024 * 1024 * 100)).ToString() + " Mb / " +
            Convert.ToInt32(i * filesize.Length / (1024 * 1024 * 100)).ToString() + " Mb";
            label2.Text = "% "+i.ToString();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                try
                {
                    File.Copy(Application.StartupPath + "/data/data.pcdb", Application.StartupPath + "/backups/" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + ".bpcdb", true);
                    label1.Text = "Veritabanı yedeklendi.";
                    i = 0;
                    timer1.Stop();
                    this.Text = "Yedekleme";
                    this.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
            /*string data_wat=Application.StartupPath + "/data/data.pcdb";
            if (backup_base64 == null)
            {
                label1.Text = "Database reading...";
                byte[] bytes = null;
                bytes = File.ReadAllBytes(data_wat);
                backup_base64 = Convert.ToBase64String(bytes);
                label1.Text = "Database read...";
                base64_read=true;
            }
            if (backup_base64 != null && base64_read == true)
            {
                label1.Text = "Database encrypting...";
                string backups_wat= Application.StartupPath + "/backups/" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + ".bpcdb";
                File.Create(backups_wat).Close();
                string enc_base64 = null;
                for (int i = 0; i < backup_base64.Length - 1; i++)
                {
                    char ch = backup_base64[i];
                    int ascii = (int)ch;
                    int encrypt = (ascii * 10) / 4;
                    enc_base64 += encrypt.ToString();
                }
                label1.Text = "Database writing...";
                StreamWriter wrt = new StreamWriter(backups_wat);
                wrt.Write(enc_base64);
                wrt.Close();
                label1.Text = "Database written...";
            }*/

        }
    }
}
