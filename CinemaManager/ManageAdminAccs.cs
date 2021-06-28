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
    public partial class ManageAdminAccs : Form
    {
        public ManageAdminAccs()
        {
            InitializeComponent();
            cbFill();
        }


        void cbFill()
        {
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
            string query = "SELECT username FROM admindb";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader myReader;
            try
            {
                sqlcon.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string name = myReader["username"].ToString();                  
                    cbAccs.Items.Add(name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }


        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            string selectedacc = cbAccs.Text;
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
            string query = "DELETE FROM admindb WHERE username = '" + selectedacc + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DialogResult res = MessageBox.Show("Do you want to remove " + selectedacc +"? ", "Confirmation", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show("Succesfully removed " + selectedacc, "OK");
                if (result == DialogResult.OK)
                {
                    ManageAdminAccs sm = new ManageAdminAccs();
                    this.Hide();
                    sm.Show();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
            string query = "INSERT INTO admindb (username, password) VALUES ('" + textUsername.Text.Trim() + "', '" + textPassword.Text.Trim() + "')";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DialogResult result = MessageBox.Show("Succesfully added " + textUsername.Text, "OK");
            if (result == DialogResult.OK)
            {
                ManageAdminAccs sm = new ManageAdminAccs();
                this.Hide();
                sm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminMenu am = new();
            this.Hide();
            am.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
