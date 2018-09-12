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
    public partial class opening : Form
    {
        public opening()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        private void opening_Load(object sender, EventArgs e)
        {
           
            timer1.Enabled = true;
            progressBar1.Value = 0;
            progressBar1.ForeColor = Color.Gold;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "/data") == true) label1.Text = Application.StartupPath + "/data";
            timer1.Enabled = false;
            timer2.Enabled = true;
            progressBar1.Value += 20;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "/data/screenshot") == true) label1.Text = Application.StartupPath + "/data/screenshot";
            timer2.Enabled = false;
            timer3.Enabled = true;
            progressBar1.Value += 20;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "/backups") == true) label1.Text = Application.StartupPath + "/backups";
            timer3.Enabled = false;
            timer4.Enabled = true;
            progressBar1.Value += 20;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/data/data.pcdb") == true) label1.Text = Application.StartupPath + "/data/data.pcdb";
            timer4.Enabled = false;
            timer5.Enabled = true;
            progressBar1.Value += 20;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            label1.Text = "Database connecting...";
            timer5.Enabled = false;
            timer6.Enabled = true;
            progressBar1.Value += 20;
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                baglan.Close();
                label1.Text = "Database connected";
            }
            catch { }
            timer6.Enabled = false;
            timer7.Enabled = true;
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            timer7.Enabled=false;
            this.Close();
                
        }
    }
}
