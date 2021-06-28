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
    public partial class AdminSeatInfo : Form
    {
        functionsDB fdb = new functionsDB();
        String query;
        public AdminSeatInfo()
        {
            InitializeComponent();
            //cbFill();
        }
        void cbFill()
        {
            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=Cinemadb;integrated security = True");
            string query = "SELECT SeatNr FROM kInfo";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlcon);
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader myReader;
            try
            {
                sqlcon.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string seatnum = myReader["SeatNr"].ToString();
                    cbSeats.Items.Add(seatnum);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {


            int seatnum = cbSeats.SelectedIndex + 1;

            SqlConnection sqlcon = new SqlConnection(@"data source = (LocalDb)\MSSqllocalDB;database=Cinemadb;integrated security = True");
            sqlcon.Open();
            if (cbSeats.SelectedIndex >= 0)
            {

                SqlCommand cmd = new SqlCommand("SELECT FirstName,LastName,Email,PhoneNr,SeatNr,MovieTitle,kID FROM kInfo WHERE SeatNr = @SeatNr", sqlcon);
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
                    textBox1.Text = dr.GetValue(6).ToString();
                }
                sqlcon.Close();
            }
            else MessageBox.Show("This seat is not taken");
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string FirstName = textFirstname.Text;
            string LastName = textLastname.Text;
            string Email = textEmail.Text;
            string MovieTitle = textMovieTitle.Text;
            int Number = int.Parse(textNumber.Text);
            int SeatNr = int.Parse(textSeatNum.Text);
            string kID = textBox1.Text;

            query = "UPDATE kInfo SET Firstname = '" + FirstName + "', LastName = '" + LastName + "', Email = '" + Email + "', PhoneNr = " + Number + ", SeatNr = " + SeatNr + ", MovieTitle = '" + MovieTitle + "'" +
                "WHERE kID = " + kID;
            fdb.setData(query, "Information was edited succesfully");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Hide();
            am.Show();
        }
    }
}
