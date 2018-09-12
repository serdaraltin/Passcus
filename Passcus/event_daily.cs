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
namespace Passcus
{
    public partial class event_daily : Form
    {
        public event_daily()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/data/data.pcdb;Persist Security Info=False;Jet OLEDB:Database Password=passcus");
        DataSet dtst = new DataSet();
        private void data_view()
        {
            try
            {
            dataGridView1.Columns.Clear();
            dtst.Tables.Clear();
            dataGridView1.Refresh();
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from gunce", baglan);
            adtr.Fill(dtst, "gunce");
            dataGridView1.DataSource = dtst.Tables["gunce"];
            adtr.Dispose();
            baglan.Close();
               }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "PassCus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            }
        }
        private void event_daily_Load(object sender, EventArgs e)
        {
            data_view();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data_view();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

                if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() != "")
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
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
    }
}
