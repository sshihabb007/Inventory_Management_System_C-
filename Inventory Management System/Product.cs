using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.ProductTables;
            CatagoryCombo();
        }

        private void GridViewUpdate()
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.ProductTables;
        }


        private void button1_Click(object sender, EventArgs e) //Add product
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            ProductTable p = new ProductTable();
            try
            {
                p.Product_ID = int.Parse(textBox1.Text.ToString());
                p.Product_Name = textBox2.Text;
                p.Product_Quantity = int.Parse(textBox3.Text.ToString());
                p.Price = float.Parse(textBox4.Text.ToString());
                p.Description = textBox5.Text;
                p.Catagory_Name = comboBox1.SelectedItem.ToString();

                iv.ProductTables.InsertOnSubmit(p);
                iv.SubmitChanges();
                GridViewUpdate();
                CatagoryCombo();
                ClearMethod();
                MessageBox.Show("Product Added");
            }catch(Exception ex)
            {
                MessageBox.Show("Failed To Insert ☺\nPlease Try Again\n"+ex.Message);
            }
        }

        void CatagoryCombo()
        {

            comboBox1.Items.Clear();
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");


            var x = from a in iv.CatagoryTables select a;

            foreach (CatagoryTable ct in x)
            {
                comboBox1.Items.Add(ct.Catagory_Name.ToString());
            }

            iv.SubmitChanges();

        }

        private void Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) //UPdate
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                var x = from a in iv.ProductTables
                        where a.Product_ID == int.Parse(textBox1.Text.ToString())
                        select a;

                x.First().Product_ID = int.Parse(textBox1.Text.ToString());
                x.First().Product_Name = textBox2.Text;
                x.First().Product_Quantity = int.Parse(textBox3.Text.ToString());
                x.First().Price = float.Parse(textBox4.Text.ToString());
                x.First().Description = textBox5.Text;
                x.First().Catagory_Name = comboBox1.SelectedItem.ToString();

                iv.SubmitChanges();
                dataGridView1.DataSource = x.ToList();
                CatagoryCombo();
                GridViewUpdate();
                ClearMethod();
                MessageBox.Show("Product Update Successful");
            }catch
            {
                MessageBox.Show("Failed to Update\nTry Again");
            }
        }

        private void button4_Click(object sender, EventArgs e) //Search
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                var x = from a in iv.ProductTables
                        where a.Product_ID == int.Parse(textBox6.Text.ToString())
                        select a;

                textBox1.Text = Convert.ToString(x.First().Product_ID);
                textBox2.Text = x.First().Product_Name;
                textBox3.Text = Convert.ToString(x.First().Product_Quantity);
                textBox4.Text = Convert.ToString(x.First().Price);
                textBox5.Text = x.First().Description;
                label8.Text = x.First().Catagory_Name;
       //       comboBox1.Text = x.First().Catagory_Name;
                dataGridView1.DataSource = x.ToList();
           //   GridViewUpdate();
                MessageBox.Show("Product Found");
            } catch
            {
                MessageBox.Show("Product not Found\nSearching Failed");
             }
        

        }

        private void button2_Click(object sender, EventArgs e) //Remove product
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                var x = from a in iv.ProductTables
                        where a.Product_ID == int.Parse(textBox1.Text.ToString())
                        select a;

                foreach (ProductTable p in x)
                    iv.ProductTables.DeleteOnSubmit(p);

                iv.SubmitChanges();
                CatagoryCombo();
                GridViewUpdate();
                ClearMethod();
                MessageBox.Show("Product Deleted");
            }
            catch
            {
                MessageBox.Show("Failed to Delete");
            }
        }


        void ClearMethod()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = ""; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home h5 = new Home();
            h5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f6 = new Form1();
            f6.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            GridViewUpdate();
        }
    }
}
