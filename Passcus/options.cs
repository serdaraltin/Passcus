using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Passcus
{
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
        }

        private void options_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = data.Default.idremember;
            checkBox2.Checked = data.Default.otodata;
            checkBox3.Checked = data.Default.otobackup;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.Default.idremember = checkBox1.Checked;
            data.Default.otodata = checkBox2.Checked;
            data.Default.otobackup = checkBox3.Checked;
            data.Default.Save();
            MessageBox.Show("Ayarlar kaydedildi.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.Default.idremember =false;
            data.Default.otodata =true;
            data.Default.otobackup =true;
            data.Default.Save();
            MessageBox.Show("Ayarlar sıfırlandı.", "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
