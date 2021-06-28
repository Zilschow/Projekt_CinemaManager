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
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=dblogin;integrated security = True");
            string query = "INSERT INTO usersAccount (username, password) VALUES ('" + textUsername.Text.Trim() + "', '" + textPassword.Text.Trim() + "')";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DialogResult result = MessageBox.Show("Registration succesfull", "OK");
            if (result == DialogResult.OK)
            {
                loginWindow lw = new loginWindow();
                this.Hide();
                lw.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginWindow lw = new loginWindow();
            this.Hide();
            lw.Show();
        }
    }
}
