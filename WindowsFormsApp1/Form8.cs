using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        FileStream fs;
        public Form8()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;
                string author = txtAuthor.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                
               
                fs = new FileStream(@"D:\AssignmentFolder\BookFile.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
               
                bw.Write(id);
                bw.Write(name);
                bw.Write(author);
                bw.Write(price);
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
                
                fs = new FileStream(@"D:\AssignmentFolder\BookFile.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtAuthor.Text = br.ReadString();
                txtPrice.Text = br.ReadDouble().ToString();
               
               


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

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.Id = Convert.ToInt32(txtId.Text);
                book.Name = txtName.Text;
                book.Author = txtAuthor.Text;
                book.Price = Convert.ToDouble(txtPrice.Text);
                


                fs = new FileStream(@"D:\AssignmentFolder\BookBinary", FileMode.Create, FileAccess.Write);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, book);
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

        private void btnBinaryReader_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                fs = new FileStream(@"D:\AssignmentFolder\BookBinary", FileMode.Open, FileAccess.Read);
                BinaryFormatter binary = new BinaryFormatter();
                book = (Book)binary.Deserialize(fs);
                txtId.Text = book.Id.ToString();
                txtName.Text = book.Name;
                txtAuthor.Text = book.Author;
                txtPrice.Text = book.Price.ToString();
                



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
                Book book = new Book();
                book.Id = Convert.ToInt32(txtId.Text);
                book.Name = txtName.Text;
                book.Author = txtAuthor.Text;
                book.Price = Convert.ToDouble(txtPrice.Text);

                fs = new FileStream(@"D:\AssignmentFolder\BookXml", FileMode.Create, FileAccess.Write);
                XmlSerializer xml = new XmlSerializer(typeof(Book));
                xml.Serialize(fs, book);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                fs = new FileStream(@"D:\AssignmentFolder\BookXml", FileMode.Open, FileAccess.Read);
                XmlSerializer xml = new XmlSerializer(typeof(Book));
                book = (Book)xml.Deserialize(fs);

                txtId.Text = book.Id.ToString();
                txtName.Text = book.Name;
                txtAuthor.Text = book.Author;
                txtPrice.Text = book.Price.ToString();

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
                Book book = new Book();
                book.Id= Convert.ToInt32(txtId.Text);
                book.Name = txtId.Text;
                book.Author = txtAuthor.Text;
                book.Price = Convert.ToDouble(txtPrice.Text);

                fs = new FileStream(@"D:\AssignmentFolder\BookSoap",FileMode.Create,FileAccess.Write);
                SoapFormatter soap = new SoapFormatter();
                soap.Serialize(fs,book);
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
                Book book = new Book();
                fs = new FileStream(@"D:\AssignmentFolder\BookSoap", FileMode.Open, FileAccess.Read);
                SoapFormatter soap = new SoapFormatter();
                book = (Book)soap.Deserialize(fs);


                txtId.Text = book.Id.ToString();
                txtName.Text = book.Name;
                txtAuthor.Text = book.Author;
                txtPrice.Text = book.Price.ToString();
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
                Book book = new Book();
                book.Id = Convert.ToInt32(txtId.Text);
                book.Name = txtName.Text;
                book.Author = txtAuthor.Text;
                book.Price = Convert.ToDouble(txtPrice.Text);

                fs = new FileStream(@"D:\AssignmentFolder\BookJson", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, book);

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
                Book book = new Book();
                fs = new FileStream(@"D:\AssignmentFolder\BookJson", FileMode.Open, FileAccess.Read);
                book = JsonSerializer.Deserialize<Book>(fs);



                txtId.Text = book.Id.ToString();
                txtName.Text = book.Name;
                txtAuthor.Text = book.Author;
                txtPrice.Text = book.Price.ToString();
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
