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
    public partial class SeatInfo : Form
    {       

        public SeatInfo()
        {
            InitializeComponent();
        }

        private void cbSeats_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int seatnum = cbSeats.SelectedIndex + 1;

            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=Cinemadb;integrated security = True");
            sqlcon.Open();
            if (cbSeats.SelectedIndex > 0 )
            {

                SqlCommand cmd = new SqlCommand("SELECT FirstName,LastName,Email,PhoneNr,SeatNr,MovieTitle FROM kInfo WHERE SeatNr = @SeatNr", sqlcon);
                cmd.Parameters.AddWithValue("@SeatNr", seatnum);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textFirstname.Text = dr.GetValue(0).ToString();
                    textLastname.Text = dr.GetValue(1).ToString();
                    textEmail.Text = dr.GetValue(2).ToString();
                    textNumber.Text = dr.GetValue(3).ToString();
                    textSeatNum.Text = dr.GetValue(4).ToString();
                    textMovieTitle.Text = dr.GetValue(5).ToString();
                }
                sqlcon.Close();
            }
            else MessageBox.Show("This seat is not taken");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }
    }
    
}
