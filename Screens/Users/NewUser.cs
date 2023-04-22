using Market.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.Screens.Users
{
    public partial class NewUser : Form
    {
        MarketEntities db=new MarketEntities();
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
                Password= password.Text,
               
            };
            try
            {

                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("added succesfully");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
