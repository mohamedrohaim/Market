using Market.Screens.Products;
using Market.Screens.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class Layout : Form
    {
        public Layout()
        {
            InitializeComponent();
        }

       

       
        

       

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser newUser= new NewUser();
            newUser.Show();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product product =new Product();  
            product.Show();

            
        }

        private void listProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList productList=new ProductList();
            productList.Show();
        }

        private void showProducts(object sender, EventArgs e)
        {
            ProductList productList=new ProductList();
            productList.Show();
        }
    }
}
