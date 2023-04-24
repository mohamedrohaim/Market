using Market.DB;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Market.Screens.Products
{
    public partial class ProductList : Form
    {
        MarketEntities db=new MarketEntities();
        List<Product> products = new List<Product>();
        public ProductList()
        {
            InitializeComponent();
            dataGridView1.DataSource=db.Products.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchCode.Text == "" && searchName.Text == "")
            {
                dataGridView1.DataSource = db.Products.ToList();
            }
            else if (searchName.Text == "" && searchCode.Text != null) { 
            var products= db.Products.Where(p=>p.Code==searchCode.Text).ToList();
                if (products.Count >= 1)
                {
                    dataGridView1.DataSource = products;
                }
                else
                {
                    MessageBox.Show("المنتج غير موجود");
                    searchCode.Text = "";
                    dataGridView1.DataSource = db.Products.ToList();
                }

            }
            else
            {
                var products = db.Products.Where(p => p.Name.Contains(searchName.Text)).ToList();
                if(products.Count >= 1)
                {
                    dataGridView1.DataSource = products;
                }
                else
                {
                    MessageBox.Show("المنتج غير موجود ");
                    searchCode.Text = "";
                }

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.ToList();

        }
    }
}
