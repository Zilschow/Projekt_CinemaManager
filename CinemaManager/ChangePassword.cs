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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        functionsDB fdb = new functionsDB();
        String query;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textUsername.Text != "" || textcurPassword.Text != "")
            {
                query = "SELECT * FROM [dblogin].[dbo].[usersAccount] WHERE username = '" + textUsername.Text.Trim() + "' AND password = '" + textcurPassword.Text.Trim() + "'";
                DataSet ds = fdb.GetData(query);
                DialogResult res = MessageBox.Show("Are you sure you want to change your password?", "Confirmation", MessageBoxButtons.YesNo);

                if (ds.Tables[0].Rows.Count == 1 && res == DialogResult.Yes)
                {
                    SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
                    string query = "UPDATE usersAccount SET username = '" + textUsername.Text.Trim() + "', password = '" + textnewPassword.Text.Trim() + "' WHERE username = '" + textUsername.Text.Trim() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DialogResult result = MessageBox.Show("Password Changed", "OK");
                    if (result == DialogResult.OK)
                    {
                        MainMenu mm = new();
                        this.Hide();
                        mm.Show();
                    }

                }
            }
            else MessageBox.Show("Provide your username and password", "OK");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }
    }
}
