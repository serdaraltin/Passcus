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
using System.Net;
namespace Passcus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        DataSet dtst = new DataSet();
        string data_yol = Application.StartupPath + @"/data/data.pcdb";
        string alan = "";
        string site = "";
        string mail = "";
        string id = "";
        string nick = "";
        string parola = "";
        string md5_pass = "";
        string olusturma = "";
        string son = "";
        string ek = "";
        string base64 = "";
        private void data_view()
        {
            progressbar_islem.Value = 0;
            
                try
                {
                dataGridView1.Columns.Clear();
                dtst.Tables.Clear();
                dataGridView1.Refresh();
                baglan.Open();
                OleDbCommand kayıtlar = new OleDbCommand("select count(*) from liste",baglan);
                OleDbCommand liste = new OleDbCommand("select *from liste", baglan);
                OleDbDataReader oku = liste.ExecuteReader();
                string database = null;
                while (oku.Read())
                {
                    database +=
                    "Alan : " + oku["Alan"].ToString() + Environment.NewLine +
                    "Site : " + oku["Site"].ToString() + Environment.NewLine +
                    "Mail : " + oku["Mail"].ToString() + Environment.NewLine +
                    "Id : " + oku["Id"].ToString() + Environment.NewLine +
                    "Nick : " + oku["Nick"].ToString() + Environment.NewLine +
                    "Parola : " + oku["Parola"].ToString() + Environment.NewLine +
                    "Md5 : " + oku["Md5"].ToString() + Environment.NewLine +
                    "Olusturma : " + oku["Olusturma"].ToString() + Environment.NewLine +
                    "Son : " + oku["Son"].ToString() + Environment.NewLine +
                    "Ek : " + oku["Ek"].ToString() + Environment.NewLine + Environment.NewLine + 
                    "============================================================================================" + Environment.NewLine + Environment.NewLine;
                }
                liste.Dispose();
                label_kayıt.Text ="Kayıt Sayısı : "+ kayıtlar.ExecuteScalar().ToString();
                OleDbDataAdapter adtr = new OleDbDataAdapter("select *from Liste", baglan);
                adtr.Fill(dtst, "Liste");
                dataGridView1.DataSource = dtst.Tables["Liste"];
                adtr.Dispose();
                baglan.Close();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Application.DoEvents();
                    DataGridViewCellStyle renk = new DataGridViewCellStyle();
                    if (i % 2 == 0)
                        renk.BackColor = Color.MediumAquamarine;
                    else
                        renk.BackColor = Color.PowderBlue;
                    dataGridView1.Rows[i].DefaultCellStyle=renk;
                }
               /* this.Text = "Ftp Sekronizasyonu...";
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(data.Default.ftpuser, data.Default.ftppass);
                client.UploadString(@"ftp:\\" + data.Default.ftphost + "/htdocs/database/passcus/data.txt", database);
                this.Text = "PassCus";*/
               // dataGridView1.BackgroundColor = Color.MediumAquamarine;
           }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            }
            progressbar_islem.Value = 100;
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


        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(data_yol) == false)
            {
                MessageBox.Show("Veritabanı bulunamadı.PassCus Kapatılacak.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else data_view();
            progressbar_islem.ForeColor = Color.Gold;
            try
            {
              /*  screenshot();
                baglan.Open();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih) values(@olay,@tarih)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Açılış.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                //gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                gunce.ExecuteNonQuery();
                baglan.Close();*/
            }
            catch { }

           
            try
            {
                label_alan.Text = "ALAN : " + dataGridView1.Rows[0].Cells[0].Value.ToString();
                
                label_site.Text = "SITE : " + dataGridView1.Rows[0].Cells[1].Value.ToString();
                label_mail.Text = "MAIL : " + dataGridView1.Rows[0].Cells[2].Value.ToString();
                label_id.Text = "ID : " + dataGridView1.Rows[0].Cells[3].Value.ToString();
                label_nick.Text = "NICK : " + dataGridView1.Rows[0].Cells[4].Value.ToString();
                label_parola.Text = "PAROLA : " + dataGridView1.Rows[0].Cells[5].Value.ToString();
                label_md5.Text = "MD5 : " + dataGridView1.Rows[0].Cells[6].Value.ToString();
                label_olusturma.Text = "OLUSTURMA : " + dataGridView1.Rows[0].Cells[7].Value.ToString();
                label_son.Text = "SON : " + dataGridView1.Rows[0].Cells[8].Value.ToString();
                label_ek.Text = "EK : " + dataGridView1.Rows[0].Cells[9].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() != "")
                {
                    byte[] imageBytes = Convert.FromBase64String(dataGridView1.Rows[0].Cells[10].Value.ToString());
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    pictureBox1.Image = Image.FromStream(ms, true);
                }

                alan = dataGridView1.Rows[0].Cells[0].Value.ToString();
                site = dataGridView1.Rows[0].Cells[1].Value.ToString();
                mail = dataGridView1.Rows[0].Cells[2].Value.ToString();
                id = dataGridView1.Rows[0].Cells[3].Value.ToString();
                nick = dataGridView1.Rows[0].Cells[4].Value.ToString();
                parola = dataGridView1.Rows[0].Cells[5].Value.ToString();
                md5_pass = dataGridView1.Rows[0].Cells[6].Value.ToString();
                olusturma = dataGridView1.Rows[0].Cells[7].Value.ToString();
                son = dataGridView1.Rows[0].Cells[8].Value.ToString();
                ek = dataGridView1.Rows[0].Cells[9].Value.ToString();
            }
            catch { }
            }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                alan = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                site = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                mail = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                id = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                nick = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                parola = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                md5_pass = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                olusturma = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                son = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                ek = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();


                if (alan != "" || site != "" || id != "" || mail != "")
                {
                    new_save yeni = new new_save();
                    TextBox talan = yeni.Controls["text_alan"] as TextBox;
                    talan.Text = alan;
                    TextBox tsite = yeni.Controls["text_site"] as TextBox;
                    tsite.Text = site;
                    TextBox tmail = yeni.Controls["text_mail"] as TextBox;
                    tmail.Text = mail;
                    TextBox tid = yeni.Controls["text_id"] as TextBox;
                    tid.Text = id;
                    TextBox tnick = yeni.Controls["text_nick"] as TextBox;
                    tnick.Text = nick;
                    TextBox tparola = yeni.Controls["text_parola"] as TextBox;
                    tparola.Text = parola;
                    TextBox tmd5 = yeni.Controls["text_md5"] as TextBox;
                    tmd5.Text = md5_pass;
                    TextBox tolusturma = yeni.Controls["text_olusturma"] as TextBox;
                    tolusturma.Text = olusturma;
                    TextBox tson = yeni.Controls["text_son"] as TextBox;
                    tson.Text = son;
                    TextBox tek = yeni.Controls["text_ek"] as TextBox;
                    tek.Text = ek;
                    Button güncelle = yeni.Controls["button_güncelle"] as Button;
                    güncelle.Enabled = true;
                    Button sil = yeni.Controls["button_sil"] as Button;
                    sil.Enabled = true;
                    yeni.ShowDialog();
                }
            }
            catch { }
        }

        private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kontrolEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
               // screenshot();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih) values(@olay,@tarih)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Veritabanı kontrol.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                //gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                gunce.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Veritabanı bağlantısı başarılı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void yedekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog yedek = new FolderBrowserDialog();
            if (yedek.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Application.StartupPath + "/data/data.pcdb", yedek.SelectedPath + "/"+ DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + ".bpcdb");
                baglan.Open();
               // screenshot();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Yedekleme.");
                gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                gunce.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Yedeklem başarılı.","PassCus",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data_view();
            try
            {
                label_alan.Text = "ALAN : " + dataGridView1.Rows[0].Cells[0].Value.ToString();
                label_site.Text = "SITE : " + dataGridView1.Rows[0].Cells[1].Value.ToString();
                label_mail.Text = "MAIL : " + dataGridView1.Rows[0].Cells[2].Value.ToString();
                label_id.Text = "ID : " + dataGridView1.Rows[0].Cells[3].Value.ToString();
                label_nick.Text = "NICK : " + dataGridView1.Rows[0].Cells[4].Value.ToString();
                label_parola.Text = "PAROLA : " + dataGridView1.Rows[0].Cells[5].Value.ToString();
                label_md5.Text = "MD5 : " + dataGridView1.Rows[0].Cells[6].Value.ToString();
                label_olusturma.Text = "OLUSTURMA : " + dataGridView1.Rows[0].Cells[7].Value.ToString();
                label_son.Text = "SON : " + dataGridView1.Rows[0].Cells[8].Value.ToString();
                label_ek.Text = "EK : " + dataGridView1.Rows[0].Cells[9].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() != "")
                {
                    byte[] imageBytes = Convert.FromBase64String(dataGridView1.Rows[0].Cells[10].Value.ToString());
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    pictureBox1.Image = Image.FromStream(ms, true);
                }

                alan = dataGridView1.Rows[0].Cells[0].Value.ToString();
                site = dataGridView1.Rows[0].Cells[1].Value.ToString();
                mail = dataGridView1.Rows[0].Cells[2].Value.ToString();
                id = dataGridView1.Rows[0].Cells[3].Value.ToString();
                nick = dataGridView1.Rows[0].Cells[4].Value.ToString();
                parola = dataGridView1.Rows[0].Cells[5].Value.ToString();
                md5_pass = dataGridView1.Rows[0].Cells[6].Value.ToString();
                olusturma = dataGridView1.Rows[0].Cells[7].Value.ToString();
                son = dataGridView1.Rows[0].Cells[8].Value.ToString();
                ek = dataGridView1.Rows[0].Cells[9].Value.ToString();
            }
            catch { }
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new_save ac = new new_save();
            Button kaydet = ac.Controls["button_kaydet"] as Button;
            TextBox olusturma = ac.Controls["text_olusturma"] as TextBox;
            TextBox md5text = ac.Controls["text_md5"] as TextBox;
            olusturma.Text = DateTime.Now.ToString();
            md5text.Text = "d41d8cd98f00b204e9800998ecf8427e";
            kaydet.Enabled = true;
            ac.ShowDialog();
        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_yenikayıt.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (alan != "" || site != "" || id != "" || mail != "")
            {
                new_save yeni = new new_save();
                TextBox talan = yeni.Controls["text_alan"] as TextBox;
                talan.Text = alan;
                TextBox tsite = yeni.Controls["text_site"] as TextBox;
                tsite.Text = site;
                TextBox tmail = yeni.Controls["text_mail"] as TextBox;
                tmail.Text = mail;
                TextBox tid = yeni.Controls["text_id"] as TextBox;
                tid.Text = id;
                TextBox tnick = yeni.Controls["text_nick"] as TextBox;
                tnick.Text = nick;
                TextBox tparola = yeni.Controls["text_parola"] as TextBox;
                tparola.Text = parola;
                TextBox tmd5 = yeni.Controls["text_md5"] as TextBox;
                tmd5.Text = md5_pass;
                TextBox tolusturma = yeni.Controls["text_olusturma"] as TextBox;
                tolusturma.Text = olusturma;
                TextBox tson = yeni.Controls["text_son"] as TextBox;
                tson.Text = son;
                TextBox tek = yeni.Controls["text_ek"] as TextBox;
                tek.Text = ek;
                Button güncelle = yeni.Controls["button_güncelle"] as Button;
                güncelle.Enabled = true;
                Button sil = yeni.Controls["button_sil"] as Button;
                sil.Enabled = true;
                yeni.ShowDialog();
            }
            else MessageBox.Show("Götüntülemek için kayıt seçin.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void yenidenBaştToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Restart();
        }

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label_alan.Text = "ALAN : " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                label_site.Text = "SITE : " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                label_mail.Text = "MAIL : " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                label_id.Text = "ID : " + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                label_nick.Text = "NICK : " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                label_parola.Text = "PAROLA : " + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                label_md5.Text = "MD5 : " + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                label_olusturma.Text = "OLUSTURMA : " + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                label_son.Text = "SON : " + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                label_ek.Text = "EK : " + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() != "")
                {
                    byte[] imageBytes = Convert.FromBase64String(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    pictureBox1.Image = Image.FromStream(ms, true);
                }

                alan = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                site = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                mail = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                id = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                nick = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                parola = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                md5_pass = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                olusturma = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                son = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                ek = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            }
            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() != "")
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(dataGridView1.SelectedRows[0].Cells[10].Value.ToString());
                        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                        ms.Write(imageBytes, 0, imageBytes.Length);
                        screenshot_view sv = new screenshot_view();
                        PictureBox svp = sv.Controls["pictureBox1"] as PictureBox;
                        svp.Image = Image.FromStream(ms, true);
                        sv.ShowDialog();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void button_goruntule_Click(object sender, EventArgs e)
        {
            if (alan != "" || site != "" || id != "" || mail != "")
            {
                new_save yeni = new new_save();
                TextBox talan = yeni.Controls["text_alan"] as TextBox;
                talan.Text = alan;
                TextBox tsite = yeni.Controls["text_site"] as TextBox;
                tsite.Text = site;
                TextBox tmail = yeni.Controls["text_mail"] as TextBox;
                tmail.Text = mail;
                TextBox tid = yeni.Controls["text_id"] as TextBox;
                tid.Text = id;
                TextBox tnick = yeni.Controls["text_nick"] as TextBox;
                tnick.Text = nick;
                TextBox tparola = yeni.Controls["text_parola"] as TextBox;
                tparola.Text = parola;
                TextBox tmd5 = yeni.Controls["text_md5"] as TextBox;
                tmd5.Text = md5_pass;
                TextBox tolusturma = yeni.Controls["text_olusturma"] as TextBox;
                tolusturma.Text = olusturma;
                TextBox tson = yeni.Controls["text_son"] as TextBox;
                tson.Text = son;
                TextBox tek = yeni.Controls["text_ek"] as TextBox;
                tek.Text = ek;
                Button güncelle = yeni.Controls["button_güncelle"] as Button;
                güncelle.Enabled = true;
                yeni.ShowDialog();
            }
            else MessageBox.Show("Güncellemek için kayıt seçin.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
        
            if (olusturma != "")
            {
                DialogResult silmek = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz ?", "PassCus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (silmek == DialogResult.Yes)
                {
                    progressbar_islem.Value = 0;
                    try
                    {
                        baglan.Open();
                        OleDbCommand komut = new OleDbCommand("Delete From Liste Where Olusturma='" + olusturma + "'", baglan);
                        //screenshot();
                        OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                        gunce.Parameters.AddWithValue("@olay", "Kayıt silme.");
                        gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                        gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                        gunce.ExecuteNonQuery();
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        baglan.Close();
                        MessageBox.Show("Kayıt silindi.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglan.Close();
                    }
                    button_yenile.PerformClick();
                    progressbar_islem.Value = 100;
                }
            }
            else MessageBox.Show("Silmek için kayıt seçin.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button_disaaktar_Click(object sender, EventArgs e)
        {
            if (olusturma != "")
            {
                SaveFileDialog aktar = new SaveFileDialog();
                aktar.Filter = "PassCus Dosyaları|*.pss|Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
                aktar.Title = "Dışa Aktar";
                if (aktar.ShowDialog() == DialogResult.OK)
                {
                    File.CreateText(aktar.FileName).Close();
                    StreamWriter yaz = new StreamWriter(aktar.FileName);
                    yaz.Write("ALAN : " + alan + Environment.NewLine +
                        "SİTE : " + site + Environment.NewLine +
                         "MAIL : " + mail + Environment.NewLine +
                          "ID : " + id + Environment.NewLine +
                           "NICK : " + nick + Environment.NewLine +
                            "PAROLA : " + parola + Environment.NewLine +
                             "MD5 : " + md5_pass + Environment.NewLine +
                              "OLUSTURMA : " + olusturma + Environment.NewLine +
                               "SON : " + son + Environment.NewLine +
                                "EK : " + ek + Environment.NewLine);
                    yaz.Close();
                    baglan.Open();
                    //screenshot();
                    OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                    gunce.Parameters.AddWithValue("@olay", "Dışa aktarma.");
                    gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                    gunce.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Dışa aktarıldı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Dışa aktarmak için kayıt seçin.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog iceaktar = new OpenFileDialog();
            iceaktar.Filter = "PassCus Dosyaları|*.pss";
            iceaktar.Title = "İçe Aktar";
            if (iceaktar.ShowDialog() == DialogResult.OK)
            {
                StreamReader oku = new StreamReader(iceaktar.FileName);
                RichTextBox rich = new RichTextBox();
                rich.Text = oku.ReadToEnd();
                if (rich.Lines[0].Substring(0, 7).ToString() == "ALAN : ")
                {
                    try
                    {
                       // screenshot();
                        baglan.Open();
                        OleDbCommand komut = new OleDbCommand("insert into liste (Alan,Site,Mail,Id,Nick,Parola,Md5,Olusturma,Son,Ek,Ekran_Alıntısı) values(@alan,@site,@mail,@id,@nick,@parola,@md5,@olusturma,@son,@ek,@ekranalıntısı)", baglan);
                        string str0 = rich.Lines[0].ToString(); str0 = str0.Remove(0, 7);
                        komut.Parameters.AddWithValue("@alan", str0);
                        string str1 = rich.Lines[1].ToString(); str1 = str1.Remove(0, 7);
                        komut.Parameters.AddWithValue("@site", str1);
                        string str2 = rich.Lines[2].ToString(); str2 = str2.Remove(0, 7);
                        komut.Parameters.AddWithValue("@mail", str2);
                        string str3 = rich.Lines[3].ToString(); str3 = str3.Remove(0, 5);
                        komut.Parameters.AddWithValue("@id", str3);
                        string str4 = rich.Lines[4].ToString(); str4 = str4.Remove(0, 7);
                        komut.Parameters.AddWithValue("@nick", str4);
                        string str5 = rich.Lines[5].ToString(); str5 = str5.Remove(0, 9);
                        komut.Parameters.AddWithValue("@parola", str5);
                        string str6 = rich.Lines[6].ToString(); str6 = str6.Remove(0, 6);
                        komut.Parameters.AddWithValue("@md5", str6);

                        komut.Parameters.AddWithValue("@olusturma", DateTime.Now.ToString());
                        string str8 = rich.Lines[8].ToString(); str8 = str8.Remove(0, 6);
                        komut.Parameters.AddWithValue("@son", str8);
                        string str9 = rich.Lines[9].ToString(); str9 = str9.Remove(0, 5);
                        komut.Parameters.AddWithValue("@ek", str9);

                        komut.Parameters.AddWithValue("@ekranalıntısı", base64);
                        komut.ExecuteNonQuery();
                       // screenshot();
                        OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                        gunce.Parameters.AddWithValue("@olay", "İçe aktarma.");
                        gunce.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                        gunce.Parameters.AddWithValue("@ekranalıntısı", base64);
                        gunce.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("Bir kayıt içeri aktarıldı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button_yenile.PerformClick();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglan.Close();
                    }
                }
                else MessageBox.Show("Dosyada karekter uyuşmazlığı var.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void text_ara_TextChanged(object sender, EventArgs e)
        {   string aranan;
        if (checkBox1.Checked == true)
            aranan = text_ara.Text.Trim().ToUpper();
        else aranan = text_ara.Text;
            button_yenile.PerformClick();
            if (text_ara.Text != "")
            {
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (checkBox1.Checked == false)
                            {
                                if (cell.Value.ToString() == text_ara.Text)
                                {
                                    cell.Style.BackColor = Color.Yellow;
                                }
                            }
                            else
                            {
                                if (cell.Value.ToString().ToUpper() == aranan)
                                {
                                    cell.Style.BackColor = Color.Yellow;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button_yenile.PerformClick();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_yenile.PerformClick();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_guncelle.PerformClick();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_sil.PerformClick();
        }

        private void dışaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_disaaktar.PerformClick();
        }

        private void yedekYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bakups_upload yedek = new bakups_upload();
            yedek.ShowDialog();
        }

        private void olayGünlüğüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            event_daily gunce = new event_daily();
            gunce.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //screenshot();
                baglan.Open();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Kapatma.");
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
            Application.Exit();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            security oturum = new security();
            oturum.Show();
            this.Close();
            
            try
            {
                baglan.Open();
                //screenshot();
                OleDbCommand gunce = new OleDbCommand("insert into gunce (olay,tarih,ekran_alıntısı) values(@olay,@tarih,@ekranalıntısı)", baglan);
                gunce.Parameters.AddWithValue("@olay", "Oturum kapama.");
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
        }

        private void biçimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog bicim = new FontDialog();
            bicim.MinSize = 7;
            bicim.MaxSize = 13;
            if (bicim.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Font = bicim.Font;
            }
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_password pass = new new_password();
            pass.ShowDialog();
        }

        private void gelişmişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options op = new options();
            op.ShowDialog();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.ShowDialog();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() != "")
            {
                byte[] imageBytes = Convert.FromBase64String(dataGridView1.SelectedRows[0].Cells[10].Value.ToString());
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                screenshot_view sv = new screenshot_view();
                PictureBox svp = sv.Controls["pictureBox1"] as PictureBox;
                svp.Image = Image.FromStream(ms, true);
                sv.ShowDialog();
            }
        }
    }
}
