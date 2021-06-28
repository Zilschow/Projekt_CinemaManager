using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CinemaManager
{
    public partial class loginWindow : Form
    {
        public loginWindow()
        {
            InitializeComponent();
        }

        functionsDB fdb = new functionsDB();
        String query;

        private void button3_Click(object sender, EventArgs e)
        {
            SeatSelection ss = new SeatSelection();
            this.Hide();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
        bool isClicked = false;
        private void button1_Click(object sender, EventArgs e)
        {          

            if (isClicked == false)
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                button5.Visible = true;
                isClicked = true;
            }
            else if(isClicked == true)
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                button5.Visible = false;
                isClicked = false;
                textBox3.Clear();
                textBox4.Clear();

            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Username or password was not provided");
            }
            else
            {
                query = "SELECT * FROM [dblogin].[dbo].[usersAccount] WHERE username = '" + textBox1.Text.Trim() + "' AND password = '" + textBox2.Text.Trim() + "'";
                DataSet ds = fdb.GetData(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    MainMenu mm = new MainMenu();
                    this.Hide();
                    mm.Show();

                }
                else
                {
                    MessageBox.Show("Username or password was incorrect.");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserRegistration ur = new UserRegistration();
            this.Hide();
            ur.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Username or password was not provided");
            }
            else
            {
                query = "SELECT * FROM [dblogin].[dbo].[admindb] WHERE username = '" + textBox3.Text.Trim() + "' AND password = '" + textBox4.Text.Trim() + "'";
                DataSet ds = fdb.GetData(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    AdminMenu am = new AdminMenu();
                    this.Hide();
                    am.Show();

                }
                else
                {
                    MessageBox.Show("Bledny login lub haslo");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
    }
}
