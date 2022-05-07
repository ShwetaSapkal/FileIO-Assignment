using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
    

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        FileStream fs;
        public Form9()
        {
            InitializeComponent();
        }

        private void btnWriter_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string batchname = txtName.Text;
                //DateTime startdate = Convert.ToDateTime(txtStart.Text);
                //DateTime enddate = Convert.ToDateTime(txtEnd.Text);
                string startdate = txtStart.Text;
                string enddate = txtEnd.Text;
                string location = txtLocation.Text;
                string trainer = txtTrainer.Text;

                 fs = new FileStream(@"D:\AssignmentFolder\BatchDetails.txt",FileMode.Create,FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(id);
                bw.Write(batchname);
                bw.Write(startdate);
                bw.Write(enddate);
                bw.Write(location);
                bw.Write(trainer);
                bw.Close();

                MessageBox.Show("Done");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\AssignmentFolder\BatchDetails.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtStart.Text = br.ReadString();
                txtEnd.Text = br.ReadString();
                txtLocation.Text = br.ReadString();
                txtTrainer.Text = br.ReadString();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
