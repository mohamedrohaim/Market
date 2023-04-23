using Market.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class Form1 : Form
    {
        MarketEntities db=new MarketEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (username != null && password != null)
            {
                var user = db.Users.Where(u => u.UserName == username.Text).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("  اسم المستخدم غير صحيح  ");
                }
                else if (user.Password == password.Text)
                {
                    this.Close();
                    Thread thread = new Thread(openForm);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("  كلمه السر غير صحيحه  ");

                }
            }


            
           
        }
        void openForm()
        {
           
            Application.Run(new Layout());
        }
    }
}
