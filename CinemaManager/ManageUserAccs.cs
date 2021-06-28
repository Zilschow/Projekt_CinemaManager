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
    public partial class ManageUserAccs : Form
    {
        public ManageUserAccs()
        {
            InitializeComponent();
            cbFill();
        }
        void cbFill()
        {
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
            string query = "SELECT username FROM usersAccount";
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

        int i = 0;
        functionsDB fdb = new();
        String query;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
            string query = "INSERT INTO usersAccount (username, password) VALUES ('" + textUsername.Text.Trim() + "', '" + textPassword.Text.Trim() + "')";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DialogResult result = MessageBox.Show("Succesfully added " + textUsername.Text, "OK");
            if (result == DialogResult.OK)
            {
                ManageUserAccs macc = new();
                this.Hide();
                macc.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                label6.Visible = true;
                textnewPass.Visible = true;
                i++;
            }
            else if (i == 1 && textnewPass.Text != "" )
            {
                query = "SELECT * FROM [dblogin].[dbo].[usersAccount] WHERE username = '" + textUsername.Text.Trim() + "' AND password = '" + textPassword.Text.Trim() + "'";
                DataSet ds = fdb.GetData(query);
                DialogResult res = MessageBox.Show("Are you sure you want to change this users password?", "Confirmation", MessageBoxButtons.YesNo);

                if (ds.Tables[0].Rows.Count == 1 && res == DialogResult.Yes)
                {
                    SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
                    string query = "UPDATE usersAccount SET username = '" + textUsername.Text.Trim() + "', password = '" + textnewPass.Text.Trim() + "' WHERE username = '" + textUsername.Text.Trim() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DialogResult result = MessageBox.Show("Password Changed", "OK");
                    if (result == DialogResult.OK)
                    {
                        ManageUserAccs macc = new();
                        this.Hide();
                        macc.Show();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Try Again", "Error", MessageBoxButtons.OK);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedacc = cbAccs.Text;
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
            string query = "DELETE FROM usersAccount WHERE username = '" + selectedacc + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DialogResult res = MessageBox.Show("Do you want to remove " + selectedacc + "? ", "Confirmation", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show("Succesfully removed " + selectedacc, "OK");
                if (result == DialogResult.OK)
                {
                    ManageUserAccs macc = new();
                    this.Hide();
                    macc.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminMenu am = new();
            this.Hide();
            am.Show();
        }
    }
}
