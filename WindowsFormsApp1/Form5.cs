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
    public partial class Form5 : Form
    {
        FileStream fs;
        public Form5()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;
                double salary =Convert.ToDouble(txtSalary.Text);
                string dsign = txtDesig.Text;
                string dept = txtDept.Text;

               // FileStream
               fs = new FileStream(@"D:\TestFolder1\Emp.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                //bw.Write(Convert.ToInt32(txtId.Text));

                bw.Write(id);
                bw.Write(name);
                bw.Write(salary);
                bw.Write(dsign);
                bw.Write(dept);
                bw.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                fs.Close(); // Free the source
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
             //   FileStream
             fs = new FileStream(@"D:\TestFolder1\Emp.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtSalary.Text = br.ReadDouble().ToString();
                txtDesig.Text = br.ReadString();
                txtDept.Text = br.ReadString();
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
