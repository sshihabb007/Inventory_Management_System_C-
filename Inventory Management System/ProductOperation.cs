using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    class ProductOperation
    {
        Product p = new Product();


        public void AddProduct(int a,string b,int c,float d,string e,string f)
        {
            InventoryDBDataContext iv = new InventoryDBDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\documents\visual studio 2015\Projects\Inventory Management System\Inventory Management System\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
            ProductTable p = new ProductTable();
            try
            {
                p.Product_ID = a; // int.Parse(textBox1.Text.ToString());
                p.Product_Name = b;  // textBox2.Text;
                p.Product_Quantity = c; // int.Parse(textBox3.Text.ToString());
                p.Price = d; // float.Parse(textBox4.Text.ToString());
                p.Description = e; // textBox5.Text;
                p.Catagory_Name = f;  // comboBox1.SelectedItem.ToString();

                iv.ProductTables.InsertOnSubmit(p);
                iv.SubmitChanges();
               GridViewUpdate();
                CatagoryCombo();
               ClearMethod();
                MessageBox.Show("Product Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Insert ☺\nPlease Try Again\n" + ex.Message);
            }

        }



    }
}
