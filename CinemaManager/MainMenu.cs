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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking bo = new Booking();
            this.Hide();
            bo.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            loginWindow lw = new loginWindow();
            this.Hide();
            lw.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SeatInfo si = new SeatInfo();
            this.Hide();
            si.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            this.Hide();
            cp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MovieList ml = new();
            this.Hide();
            ml.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Book a seat for a movie of your choosing";
            label1.Visible = true;            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Check out the movies that are playing right now!";
            label1.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Check out your seat information";
            label1.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}
