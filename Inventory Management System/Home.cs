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
    public partial class Home : Form
    {
        Customer c = new Customer();
        Order o = new Order();
        Product p = new Product();

        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product pr = new Product();
            pr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Catagory c = new Catagory();
            c.Show();
            this.Hide();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Customer cs = new Customer();
                cs.Show();
                this.Hide();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Order o3 = new Order();
            o3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            label2.Text = c.CustomerCount().ToString();
            label3.Text = o.OrderCount().ToString();
            label5.Text = o.AmountSum().ToString()+"TK";
            label7.Text += dateTimePicker1.Text;
            dateTimePicker1.Hide();
        }


    }
}
