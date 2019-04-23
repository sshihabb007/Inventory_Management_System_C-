using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Inventory_Management_System
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.CustomerTables;
            //DataGridViewImageColumn ImageColumn = new DataGridViewImageColumn();
            //ImageColumn = (DataGridViewImageColumn)dataGridView1.Columns[5];
            //ImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowTemplate.Height = 30;
            GridViewUpdate();
            CustomerCombo();
        }

        void GridViewUpdate()
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.CustomerTables;
            dataGridView1.RowTemplate.Height = 30;
        }

        void ClearMethod()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Combo select
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in iv.CustomerTables
                    where a.Customer_ID == int.Parse(comboBox1.SelectedItem.ToString())
                    select a;
            try
            {
                foreach (CustomerTable p in x)
                {
                    textBox1.Text = Convert.ToString(p.Customer_ID);
                    textBox2.Text = p.First_Name.ToString();
                    textBox3.Text = p.Last_Name.ToString();
                    textBox4.Text = p.Phone.ToString();
                    textBox5.Text = p.Email.ToString();

                    //byte[] Images = null;
                    //FileStream Stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                    //BinaryReader brs = new BinaryReader(Stream);
                    //Images = brs.ReadBytes((int)Stream.Length);

                    //byte[] Images = Convert.ToByte(p.Image);

                    //MemoryStream mstream = new MemoryStream();
                    //pictureBox1.Image = Image.FromStream(mstream);

                }
                dataGridView1.DataSource = x.ToList();
                CustomerCombo();
                iv.SubmitChanges();
            }catch(Exception ex)
            {
                MessageBox.Show("Failed in combobox\n "+ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearMethod();
            GridViewUpdate();
        }


        void CustomerCombo()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "Select an ID";
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in iv.CustomerTables select a;

            foreach (CustomerTable ct in x)
            {
                comboBox1.Items.Add(ct.Customer_ID);
            }

            iv.SubmitChanges();

        }

        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


     //   public   byte[] images = null;
        private void button2_Click(object sender, EventArgs e) // Add Customer
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            CustomerTable cm = new CustomerTable();
            try
            {
                cm.Customer_ID = int.Parse(textBox1.Text.ToString());
                cm.First_Name = textBox2.Text;
                cm.Last_Name = textBox3.Text;
                cm.Phone = textBox4.Text;
                cm.Email = textBox5.Text;

                //  byte[] images = null;
                //FileStream Stream = new FileStream(imglocation,FileMode.Open, FileAccess.Read);
                //BinaryReader brs = new BinaryReader(Stream);
                //images = brs.ReadBytes((int)Stream.Length);

                //MemoryStream ms = new MemoryStream();
                //button7.Image.Save(ms,button7.Image.RawFormat);
                //byte[] Images = ms.ToArray();
                //cm.Image = Images;

                iv.CustomerTables.InsertOnSubmit(cm);
                iv.SubmitChanges();
                GridViewUpdate();
                CustomerCombo();
                ClearMethod();
                MessageBox.Show("Customer Added");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed To Add Customer\nPlease Try Again \n"+ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e) //Update
        { 
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                var x = from a in iv.CustomerTables
                        where a.Customer_ID == int.Parse(textBox1.Text.ToString())
                        select a;

                x.First().Customer_ID = int.Parse(textBox1.Text.ToString());
                x.First().First_Name = textBox2.Text;
                x.First().Last_Name= textBox3.Text;
                x.First().Phone= textBox4.Text;
                x.First().Email= textBox5.Text;

                iv.SubmitChanges();
                dataGridView1.DataSource = x.ToList();
                CustomerCombo();
                GridViewUpdate();
                ClearMethod();
                MessageBox.Show("Customer Information Update Successful");
            }
            catch
            {
                MessageBox.Show("Failed to Update\nTry Again");
            }
        }


        private void button4_Click(object sender, EventArgs e)  //Delete
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                var x = from a in iv.CustomerTables
                        where a.Customer_ID == int.Parse(textBox1.Text.ToString())
                        select a;

                foreach (CustomerTable p in x)
                    iv.CustomerTables.DeleteOnSubmit(p);

                iv.SubmitChanges();
                CustomerCombo();
                GridViewUpdate();
                ClearMethod();
                MessageBox.Show("Customer Info Deleted");
            }
            catch
            {
                MessageBox.Show("Failed to Delete");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home h2 = new Home();
            h2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f3 = new Form1();
            f3.Show();
            this.Hide();
        }

        public int CustomerCount()
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            int y = 0;
                var x = from a in iv.CustomerTables select a;
            foreach (CustomerTable c in x)
            {
                y++;
            }
            return y;
          }

        //string imglocation = "";
        //private void button7_Click(object sender, EventArgs e)
        //{ 
        //    OpenFileDialog dialog = new OpenFileDialog();
        //    dialog.Filter = "png files(*.png)|*.png| jpg files(*.jpg)|*jpg| All files(*.*)|*.*";
        //    if(dialog.ShowDialog()==DialogResult.OK )
        //    {
        //        imglocation = dialog.FileName.ToString();
        //        pictureBox1.ImageLocation = imglocation;
        //        button7.Image = Image.FromFile(dialog.FileName);
        //    }

        //}




    }
}
