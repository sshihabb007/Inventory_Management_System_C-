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
    public partial class Order : Form
    {
        Product p = new Product();

        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.OrderTables;
            CatagoryCombo();
            ProductIDCombo();
            CustomerIDCombo();
        }

        private void GridViewUpdate()
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.OrderTables;
        }

        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        void CustomerIDCombo()
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

        void ProductIDCombo()
        {

            comboBox3.Items.Clear();
            comboBox3.Text = "Select an ID";
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in iv.ProductTables select a;

            foreach (ProductTable p in x)
            {
                comboBox3.Items.Add(p.Product_ID);
            }

            iv.SubmitChanges();
        }

        void CatagoryCombo()
        {
              comboBox2.Items.Clear();
              comboBox2.Text = "Select a Catagory";
              InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
              Catagory c = new Catagory();

              var x = from a in iv.CatagoryTables select a;

              foreach (CatagoryTable ct in x)
              {
                 comboBox2.Items.Add(ct.Catagory_Name.ToString());
              }
               iv.SubmitChanges();
         }


        private void button4_Click(object sender, EventArgs e)
        {
            Home h7 = new Home();
            h7.Show();
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e) //ADD order
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            OrderTable o = new OrderTable();

            var x = from a in iv.ProductTables
                    where   a.Product_ID == int.Parse(comboBox3.SelectedItem.ToString())
                    select a;


            try
            {
                if (int.Parse(textBox2.Text) > pq)
                    MessageBox.Show(pq+" Products aren't Available. So you Can't order "+int.Parse(textBox2.Text) + " products.");
                else if(int.Parse(textBox2.Text) <= 0)
                    MessageBox.Show(" Sorry !!! This Product isn't Available ");
                else
                {
                    o.Order_ID = int.Parse(textBox1.Text);
                    o.Product_ID = int.Parse(comboBox3.SelectedItem.ToString());
                    o.Customer_ID = int.Parse(comboBox1.SelectedItem.ToString());
                    o.Catagory = comboBox2.SelectedItem.ToString();
                    o.Order_Quantity = int.Parse(textBox2.Text);
                    o.Order_date = dateTimePicker1.Text;
                    o.Bill = pprice * float.Parse(o.Order_Quantity.ToString());

                    x.First().Product_Quantity -= int.Parse(textBox2.Text);

                    iv.OrderTables.InsertOnSubmit(o);
                    iv.SubmitChanges();
                    GridViewUpdate();
                    MessageBox.Show(" Order Placed");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed To Place Order\nPlease Try Again\n"+ex.Message);
            }



        }




        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f8 = new Form1();
            f8.Show();
            this.Hide();
        }

        int pq;
        public float pprice=0;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in iv.ProductTables
                    where a.Product_ID == int.Parse(comboBox3.SelectedItem.ToString())
                    select a;

            foreach (ProductTable p in x)
            {
                pprice = float.Parse(p.Price.ToString());
                pq = int.Parse(p.Product_Quantity.ToString());
                comboBox2.Items.Clear();
                comboBox2.Items.Add(p.Catagory_Name.ToString());
                comboBox2.Text = p.Catagory_Name;
                textBox2.Text = Convert.ToString(p.Product_Quantity);
            }
            iv.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GridViewUpdate();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                var x = from a in iv.OrderTables
                        where a.Order_ID == int.Parse(textBox1.Text.ToString())
                        select a;

                foreach (OrderTable p in x)
                    iv.OrderTables.DeleteOnSubmit(p);

                iv.SubmitChanges();
                GridViewUpdate();
                MessageBox.Show("Order Cancelled");
            }
            catch
            {
                MessageBox.Show("Failed to Cancel");
            }
        }

        public int OrderCount()
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            int y = 0;
            var x = from a in iv.OrderTables select a;
            foreach (OrderTable c in x)
            {
                y++;
            }
            return y;
        }

        public float AmountSum()
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            float y = 0;
            var x = from a in iv.OrderTables select a;
            foreach (OrderTable o  in x)
            {
                y += float.Parse(o.Bill.ToString());
            }
            return y;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
