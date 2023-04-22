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

namespace Market.Screens.Users
{
    public partial class NewUser : Form
    {
        MarketEntities db=new MarketEntities();
        string ImagePass;
        public NewUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User() {
                UserName = username.Text,
                Password = password.Text,            
               
            };
            try
            {

                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("   تــــم الحــفــظ بنجــــأح   ");
                string newPass = Environment.CurrentDirectory + $"\\UsersImages\\{user.Id}.jpg";
                File.Copy(ImagePass,newPass);
                user.Image = newPass;
                db.SaveChanges() ;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picture.ImageLocation= dialog.FileName;
                ImagePass= dialog.FileName;
            }


        }
    }
}
