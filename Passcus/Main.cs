using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.OleDb;
using System.Security;
using System.Security.Cryptography;
namespace Passcus
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        string fullpath="";
        string data_control = "";
        OleDbConnection baglan=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Application.StartupPath+"/data/data.mdb");
        string buildwat = Application.StartupPath + @"/data/build.hs";
        string datawat = Application.StartupPath + @"/data/data.mdb";
        private void build_save()
        {
            StreamWriter yaz = new StreamWriter(buildwat);
            string build = "";
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                build += treeView1.Nodes[i].Text + ">>";
                TreeNode tn = treeView1.Nodes[i];
                for (int a = 0; a < tn.Nodes.Count; a++)
                {
                    build += tn.Nodes[a].Text + @"\";
                }
                build += Environment.NewLine;
            }
            yaz.Write(build);
            yaz.Close();
        }
        private void buil_import()
        {
            treeView1.Nodes.Clear();
            StreamReader read = new StreamReader(Application.StartupPath + @"/data/build.hs");
            string satır = read.ReadLine();
            int i = 0;
            while (satır != null)
            {
                string kok = satır;
                kok = kok.Substring(0, kok.IndexOf(">>"));
                treeView1.Nodes.Add(kok);
                string item = satır;
                item = item.Remove(0, item.IndexOf(">>") + 2);
                string additem = item;
                int index = 0;
                index = additem.IndexOf(@"\");
                string alt = additem.Substring(0, index);
                TreeNode tn = treeView1.Nodes[i];
                tn.Nodes.Add(alt);
                additem = additem.Remove(0, index + 1);
                while (additem != "")
                {
                    if (additem.IndexOf(@"\") <= 0)
                    {
                        tn.Nodes.Add(additem);
                        additem = "";
                    }
                    else
                    {
                        alt = additem.Substring(0, additem.IndexOf(@"\"));
                        index = additem.IndexOf(@"\");
                        tn.Nodes.Add(alt);
                        additem = additem.Remove(0, index + 1);
                    }
                }
                satır = read.ReadLine();
                i += 1;
            }
        }
        private void data_list()
        {
            text_site.Text ="";
            text_mail.Text = "";
            combo_host.Text = "";
            text_id.Text = "";
            text_nick.Text = "";
            text_pass.Text ="";
            text_md5.Text = "";
            datetime_create.Text ="";
            datetime_last.Text = "";

            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Select *From Alanlar where path like'"+treeView1.SelectedNode.FullPath.ToString()+ "%'", baglan);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                text_site.Text = oku["site"].ToString();
                text_mail.Text = oku["mail"].ToString();
                combo_host.Text= oku["host"].ToString();
                text_id.Text = oku["id"].ToString();
                text_nick.Text = oku["nick"].ToString();
                text_pass.Text = oku["pass"].ToString();
                text_md5.Text = oku["md5"].ToString();
                datetime_create.Text = oku["olusturma"].ToString();
                datetime_last.Text = oku["son"].ToString();
            }
            baglan.Close();
            label12.Text = "Yol : " + treeView1.SelectedNode.FullPath.ToString();
        }
        private void data_add()
        {
            if (fullpath != "")
            {
                try
                {
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("Insert into Alanlar (path,site,mail,host,id,nick,pass,md5,olusturma,son) values(@path,@site,@mail,@host,@id,@nick,@pass,@md5,@olusturma,@son)", baglan);
                    komut.Parameters.AddWithValue("@path", fullpath);
                    komut.Parameters.AddWithValue("@site", text_site.Text);
                    komut.Parameters.AddWithValue("@mail", text_mail.Text);
                    komut.Parameters.AddWithValue("@host", combo_host.Text);
                    komut.Parameters.AddWithValue("@id", text_id.Text);
                    komut.Parameters.AddWithValue("@nick", text_nick.Text);
                    komut.Parameters.AddWithValue("@pass", text_pass.Text);
                    komut.Parameters.AddWithValue("@md5", text_md5.Text);
                    komut.Parameters.AddWithValue("@olusturma", datetime_create.Text);
                    komut.Parameters.AddWithValue("@son", datetime_last.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Kayıt yapıldı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bir kategoride seçim yapınız.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void Form1_Load(object sender, EventArgs e)
        {
            /*if (File.Exists(datawat) == false)
            {
                MessageBox.Show("Veritabanı silinmiş veya taşınmış.PassCus Kapatılacak.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }*/
            //buil_import();
        }
        private void dalEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel2.Location == new Point(-106, panel2.Location.Y))
            {
                panel2.Visible = true;
                for (int i = -106; i <= 223; i++)
                {
                    panel2.Location = new Point(i, panel2.Location.Y);
                }
            }
        }
        private void kökDüğümToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Location == new Point(-106, panel1.Location.Y))
            {
                panel1.Visible = true;
                for (int i = -106; i <= 223; i++)
                {
                    panel1.Location = new Point(i, panel1.Location.Y);
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (panel1.Location == new Point(223, panel1.Location.Y))
            {
                    panel1.Location = new Point(-106, panel1.Location.Y);
                
                panel1.Visible = false;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (panel2.Location == new Point(223, panel2.Location.Y))
            {
               
                    panel2.Location = new Point(-106, panel2.Location.Y);
                
                panel2.Visible = false;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int index = treeView1.SelectedNode.FullPath.IndexOf(@"\");
                int index2 = treeView1.SelectedNode.FullPath.IndexOf(@"\") + 1;
                if (index != 0 && index2 != 0)
                {
                    MessageBox.Show("Bir alanda yalnız bir dallanma yapılabilir.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TreeNode tr = treeView1.SelectedNode;
                    tr.Nodes.Add(textBox8.Text);
                    build_save();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(textBox7.Text);
            
        }
        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult del = MessageBox.Show("Silmek istediğinize emin misiniz ?", "PassCus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (del == DialogResult.Yes)
            {
                TreeNode tr = treeView1.SelectedNode;
                tr.Remove();
                build_save();
            }
        }
        private void içeAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Title = "İçe Aktar";
            ac.Filter = "Hs Dosyaları|*.hs|Tüm Dosyalar|*.*";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                StreamReader read = new StreamReader(ac.FileName);
                string satır = read.ReadLine();
                int i = 0;
                while (satır != null)
                {
                    string kok = satır;
                    kok = kok.Substring(0, kok.IndexOf(">>"));
                    treeView1.Nodes.Add(kok);

                    string item = satır;
                    item = item.Remove(0, item.IndexOf(">>") + 2);


                    string additem = item;
                    int index = 0;
                    index = additem.IndexOf(@"\");
                    string alt = additem.Substring(0, index);
                    TreeNode tn = treeView1.Nodes[i];
                    tn.Nodes.Add(alt);
                    additem = additem.Remove(0, index + 1);
                    while (additem != "")
                    {
                        if (additem.IndexOf(@"\") <= 0)
                        {
                            tn.Nodes.Add(additem);
                            additem = "";
                        }
                        else
                        {
                            alt = additem.Substring(0, additem.IndexOf(@"\"));
                            index = additem.IndexOf(@"\");
                            tn.Nodes.Add(alt);
                            additem = additem.Remove(0, index + 1);
                        }
                    }
                    satır = read.ReadLine();
                    i += 1;
                }

            }
        }
        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            build_save();
        }
        private void dışaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Dışa Aktar";
            kaydet.Filter = "Hs Dosyaları|*.hs|Tüm Dosyalar|*.*";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                File.CreateText(kaydet.FileName).Close();
                StreamWriter yaz = new StreamWriter(kaydet.FileName);
                string build = "";
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    build += treeView1.Nodes[i].Text + ">>";
                    TreeNode tn = treeView1.Nodes[i];
                    for (int a = 0; a < tn.Nodes.Count; a++)
                    {
                        build += tn.Nodes[a].Text + @"\";
                    }
                    build += Environment.NewLine;
                }
                yaz.Write(build);
                yaz.Close();
            }
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buil_import();
        }
        private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                fullpath = treeView1.SelectedNode.FullPath.ToString();
                data_list();
            }
            catch { }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            data_add();
        }
        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                int index = treeView1.SelectedNode.FullPath.IndexOf(@"\");
                int index2 = treeView1.SelectedNode.FullPath.IndexOf(@"\") + 1;
                if (index != 0 && index2 != 0)
                {
                    dalEkleToolStripMenuItem.Enabled = false;
                }
                else
                {
                    dalEkleToolStripMenuItem.Enabled = true;
                }
            }
            catch { }
        }
        private void değiştirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (panel3.Location == new Point(-106, panel3.Location.Y))
            {
                panel3.Visible = true;
                for (int i = -106; i <= 223; i++)
                {
                    panel3.Location = new Point(i, panel3.Location.Y);
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (panel3.Location == new Point(223, panel3.Location.Y))
            {

                panel3.Location = new Point(-106, panel3.Location.Y);

                panel3.Visible = false;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            tn.Text = textBox1.Text;
            build_save();
        }
        private void check_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pass.Checked == true) text_pass.UseSystemPasswordChar = false;
            else text_pass.UseSystemPasswordChar = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          string hash = md5(text_pass.Text);
          hash = hash.ToLower();
          text_md5.Text = hash;
        }

     
    }
}
