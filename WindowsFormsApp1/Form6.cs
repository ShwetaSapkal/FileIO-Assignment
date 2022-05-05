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
    public partial class Form6 : Form
    {
        FileStream fs;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int rollno = Convert.ToInt32(txtRollNo.Text);
                string stream = txtStream.Text;
                double perc = Convert.ToDouble(txtPercentage.Text);
                string city = txtCity.Text;
                

                //FileStream
                fs = new FileStream(@"D:\TestFolder1\Student.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(name);
                bw.Write(rollno);
                bw.Write(stream);
                bw.Write(perc);
                bw.Write(city);
                

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

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                //FileStream
                fs = new FileStream(@"D:\TestFolder1\Student.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                txtName.Text = br.ReadString();
                txtRollNo.Text = br.ReadInt32().ToString();
                txtStream.Text = br.ReadString();
                txtPercentage.Text = br.ReadDouble().ToString();
                txtCity.Text = br.ReadString();

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
    }
}
