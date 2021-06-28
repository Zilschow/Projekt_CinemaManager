using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManager
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loginWindow lw = new loginWindow();
            this.Hide();
            lw.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageUserAccs macc = new();
            this.Hide();
            macc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSeatInfo si = new AdminSeatInfo();
            this.Hide();
            si.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageAdminAccs mac = new();
            this.Hide();
            mac.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Manage Admin accounts";
            label2.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Manage User accounts";
            label2.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Manage seats information";
            label2.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

    }
}
