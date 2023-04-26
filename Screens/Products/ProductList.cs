using Market.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        string imgPass;
        MarketEntities db=new MarketEntities();
        List<DB.Product> products = new List<DB.Product>();
        public ProductList()
        {
            InitializeComponent();
            products=db.Products.ToList();
            dataGridView1.DataSource=products;
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var product = db.Products.Where(p => p.Code == code).FirstOrDefault();
            if (product != null)
            {
                productName.Text = product.Name;
                price.Text = product.Price.ToString();
                barcode.Text = product.Code.ToString();
                count.Text = product.Quantity.ToString();
                notes.Text = product.Notes.ToString();
                if (product.Image != null) { 
                picture.ImageLocation= product.Image;
                }
                else { picture.ImageLocation= null; }

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var product = db.Products.Where(p => p.Code == code).FirstOrDefault();

            if (product != null)
            {
                
                try{
                    product.Name = productName.Text;
                    product.Price = decimal.Parse(price.Text);
                    product.Quantity = int.Parse(count.Text);
                    product.Notes = notes.Text;
                    product.Code = barcode.Text;
                    if (product.Image != null)
                    {
                        File.Delete(product.Image);
                    }
                    string newPass = Environment.CurrentDirectory + $"\\ProductsImages\\{product.Id}.jpg";
                    File.Copy(imgPass, newPass);
                    product.Image = newPass;
                    db.SaveChanges();
                    MessageBox.Show("تم تعديل المنتج بنجاح");
                }
                catch(Exception error) {
                    MessageBox.Show(error.Message);
                }
            }

        }

        private void picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picture.ImageLocation = dialog.FileName;
                imgPass = dialog.FileName;

            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var product = db.Products.Where(p => p.Code == code).FirstOrDefault();
            if (product != null)
            {

                db.Products.Remove(product);
                db.SaveChanges();
                var s = MessageBox.Show("تم حذف المنتج بنجاح", "تم حذف المنتج برجاء اضافه منتجات جديده", MessageBoxButtons.YesNo);

                products.Remove(product);
                dataGridView1.DataSource =db.Products.ToList();

            }




        }
    }
}
