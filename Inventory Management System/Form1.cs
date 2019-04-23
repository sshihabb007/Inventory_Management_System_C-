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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Password_txt.PasswordChar = '*';
            Password_txt.MaxLength = 8;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            //    Admin ad = new Admin();

            var x = from a in iv.AdminTables
                    where a.Username == Username.Text
                       && a.Password == Password_txt.Text
                    select a;
                try
                {

                if (Username.Text == string.Empty && Password_txt.Text == string.Empty)
                    MessageBox.Show("Username and Password must not be empty");
                else if (Username.Text == string.Empty)
                    MessageBox.Show("Username must not be empty");
                else if (Password_txt.Text == string.Empty)
                    MessageBox.Show("Password must not be empty");
                else if (x.First().Username != Username.Text || x.First().Password != Password_txt.Text)
                    MessageBox.Show("Invalid Username or Password");
                else if (x.First().Username == Username.Text && x.First().Password == Password_txt.Text)
                {
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                }

            } catch
                {
                    MessageBox.Show("Failed to login!!!\nProvide Valid Username & Password\n");
                }
            }
        }
    }
