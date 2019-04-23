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
    public partial class Catagory : Form
    {
        public Catagory()
        {
            InitializeComponent();
        }


        void ClearMethod()
        {
            textBox1.Text = textBox2.Text = "";
        }

        private void Catagory_Load(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.CatagoryTables;
            CatagoryCombo();
        }

        private void GridViewUpdate()
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = iv.CatagoryTables;
        }

        void CatagoryCombo()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "Select a Catagory";
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            Catagory c = new Catagory();

            var x = from a in iv.CatagoryTables select a;

            foreach (CatagoryTable ct in x)
            {
                comboBox1.Items.Add(ct.Catagory_Name.ToString());
            }
            iv.SubmitChanges();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClearMethod();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            CatagoryTable ca = new CatagoryTable();

            try
            {
                ca.Catagory_ID = int.Parse(textBox1.Text.ToString());
                ca.Catagory_Name = textBox2.Text;


                iv.CatagoryTables.InsertOnSubmit(ca);
                iv.SubmitChanges();
                GridViewUpdate();
                CatagoryCombo();
                ClearMethod();
                MessageBox.Show("Catagory Inserted");
            }
            catch
            {
                MessageBox.Show("Failed To Insert ☺\nPlease Try Again");
            }
        }



        private void button3_Click(object sender, EventArgs e) //Update
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            Catagory ct = new Catagory();

            try
            {
                var x = from a in iv.CatagoryTables
                        where a.Catagory_ID == int.Parse(textBox1.Text.ToString())
                        select a;

                x.First().Catagory_ID = int.Parse(textBox1.Text.ToString());
                x.First().Catagory_Name = textBox2.Text;

                iv.SubmitChanges();
                dataGridView1.DataSource = x.ToList();
                CatagoryCombo();
                GridViewUpdate();
                ClearMethod();
                MessageBox.Show("Catagory Update Successful");
            }
            catch
            {
                MessageBox.Show("Failed to Update\nTry Again");
            }
        }

        private void Catagory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in iv.CatagoryTables
                    where a.Catagory_Name == comboBox1.SelectedItem.ToString()
                    select a;

            foreach (CatagoryTable p in x)
            {
                textBox1.Text = Convert.ToString(p.Catagory_ID);
                textBox2.Text = p.Catagory_Name.ToString();
            }
            CatagoryCombo();
            iv.SubmitChanges();
        }



        private void button4_Click(object sender, EventArgs e) //Delete
        {

            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                var x = from a in iv.CatagoryTables
                        where a.Catagory_ID == int.Parse(textBox1.Text.ToString())
                        select a;

                foreach(CatagoryTable p in x)
                    iv.CatagoryTables.DeleteOnSubmit(p);

                iv.SubmitChanges();
                CatagoryCombo();
                GridViewUpdate();
                ClearMethod();
                MessageBox.Show("Catagory Deleted");
            }
            catch
            {
                MessageBox.Show("Failed to Delete");
            }

        }

        private void button6_Click(object sender, EventArgs e) //Logout
        {
            Form1 f1 = new Form1();
                f1.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();
            h1.Show();
            this.Hide();
        }


    }
}
