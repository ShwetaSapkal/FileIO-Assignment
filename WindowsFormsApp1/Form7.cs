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
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        FileStream fs;
        public Form7()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();
                pro.Id = Convert.ToInt32(txtId.Text);
                pro.Name = txtName.Text;
                pro.Price =Convert.ToDouble(txtPrice.Text);
                pro.Category = txtCategory.Text;


                fs = new FileStream(@"D:\AssignmentFolder\ProductBinary", FileMode.Create, FileAccess.Write);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, pro);
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

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();
                fs = new FileStream(@"D:\AssignmentFolder\ProductBinary", FileMode.Open, FileAccess.Read);
                BinaryFormatter binary = new BinaryFormatter();
                pro = (Product)binary.Deserialize(fs);
                txtId.Text = pro.Id.ToString();
                txtName.Text = pro.Name;
                txtPrice.Text = pro.Price.ToString();
                txtCategory.Text = pro.Category;
                


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

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();
                pro.Id = Convert.ToInt32(txtId.Text);
                pro.Name = txtName.Text;
                pro.Price = Convert.ToDouble(txtPrice.Text);
                pro.Category = txtCategory.Text;

                fs = new FileStream(@"D:\AssignmentFolder\ProductXml", FileMode.Create, FileAccess.Write);
                XmlSerializer xml = new XmlSerializer(typeof(Product));
                xml.Serialize(fs, pro);
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

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();
                fs = new FileStream(@"D:\AssignmentFolder\ProductXml", FileMode.Open, FileAccess.Read);
                XmlSerializer xml = new XmlSerializer(typeof(Product));
                pro = (Product)xml.Deserialize(fs);

                txtId.Text = pro.Id.ToString();
                txtName.Text = pro.Name;
                txtPrice.Text = pro.Price.ToString();
                txtCategory.Text = pro.Category;


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

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();
                pro.Id = Convert.ToInt32(txtId.Text);
                pro.Name = txtName.Text;
                pro.Price = Convert.ToDouble(txtPrice.Text);
                pro.Category = txtCategory.Text;


                fs = new FileStream(@"D:\AssignmentFolder\ProductSoap", FileMode.Create, FileAccess.Write);
                SoapFormatter soap = new SoapFormatter();
                soap.Serialize(fs, pro);
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

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();
                fs = new FileStream(@"D:\AssignmentFolder\ProductSoap", FileMode.Open, FileAccess.Read);
                SoapFormatter soap = new SoapFormatter();
                pro = (Product)soap.Deserialize(fs);

                txtId.Text = pro.Id.ToString();
                txtName.Text = pro.Name;
                txtPrice.Text = pro.Price.ToString();
                txtCategory.Text = pro.Category;
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

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();

                pro.Id = Convert.ToInt32(txtId.Text);
                pro.Name = txtName.Text;
                pro.Price = Convert.ToDouble(txtPrice.Text);
                pro.Category = txtCategory.Text;

                fs = new FileStream(@"D:\AssignmentFolder\ProductJson", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, pro);
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

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                Product pro = new Product();
                fs = new FileStream(@"D:\AssignmentFolder\ProductJson", FileMode.Open, FileAccess.Read);
                pro = JsonSerializer.Deserialize<Product>(fs);
                
                txtId.Text = pro.Id.ToString();
                txtName.Text = pro.Name;
                txtPrice.Text = pro.Price.ToString();
                txtCategory.Text = pro.Category;
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

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\AssignmentFolder";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Folder already exixts");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Folder created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\AssignmentFolder\FirstFile.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File already created");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File Created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                string category = txtCategory.Text;
               // FileStream
               fs = new FileStream(@"D:\AssignmentFolder\FirstFile.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                //bw.Write(Convert.ToInt32(txtId.Text));

                bw.Write(id);
                bw.Write(name);
                bw.Write(price);
                bw.Write(category);
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
                //FileStream
                fs = new FileStream(@"D:\AssignmentFolder\FirstFile.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtPrice.Text = br.ReadDouble().ToString();
                txtCategory.Text = br.ReadString();
                
                // Close the operation reader


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
    }
}
