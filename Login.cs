using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Global_Expertise
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            usernameTb.Text = "";
            passwordTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(usernameTb.Text=="" || passwordTb.Text == "")
            {
                MessageBox.Show("Enter username and password");
            }
            else
            {
                if (RoleCb.SelectedItem.ToString() == "Admin")
                {
                    if (usernameTb.Text == "Admin" && passwordTb.Text == "Admin")
                    {
                        ProductForm prod = new ProductForm();
                        prod.Show();
                        this.Hide();
                    }else
                    {
                        MessageBox.Show("enter the correct id and password");
                    }
                }
                else if(RoleCb.SelectedItem.ToString()=="Seller")
                {
                    MessageBox.Show("you are a seller");
                }
                else
                {
                    MessageBox.Show("select a role");
                }
            }
        }

        private void usernameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
