using Market.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.Screens.Products
{
    public partial class Product : Form
    {
        MarketEntities db =new MarketEntities();
        string imgPass;
        public Product()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(productName.Text==""&& barcode.Text == "" && count.Text == "" && price.Text == "")
            {
                MessageBox.Show("يرجي اكمال البيانات المطلوبه");
            }
            else
            {
                
                Market.DB.Product product = new Market.DB.Product()
                {
                    Name = productName.Text,
                    Code = barcode.Text,
                    Price = decimal.Parse(price.Text),
                    Notes = notes.Text,
                    Quantity = int.Parse(count.Text),

                };

                try {
                    db.Products.Add(product);
                    db.SaveChanges();
                    if (picture != null) { 
                    string newPass = Environment.CurrentDirectory + $"\\ProductsImages\\{product.Id}.jpg";
                    File.Copy(imgPass, newPass);
                    product.Image = newPass;
                    db.SaveChanges();
                    }
                    
                    MessageBox.Show("تم اضافه المنتج ");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                barcode.Text =string.Empty;
                productName.Text = string.Empty;
                price.Text= string.Empty;
                count.Text = string.Empty;
                notes.Text = string.Empty;
                picture.ImageLocation = string.Empty;                  
                    

                
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
    }
}
