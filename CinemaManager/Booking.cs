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
    public partial class Booking : Form
    {

        functionsDB fdb = new functionsDB();
        String query;

        public Booking()
        {
            InitializeComponent();          
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            SeatSelection ss = new SeatSelection();
            ss.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }

        public string ButtonText
        {
            get
            {
                return this.button2.Text;
            }
            set
            {
                this.button2.Text = value;
            }
        }

        public string LabelText
        {
            get
            {
                return this.seatNR.Text;
            }
            set
            {
                this.seatNR.Text = value;
            }
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            //create a list for data items
            List<MyComboBoxItem> cb1Items = new List<MyComboBoxItem>();

            //assign sub items
            cb1Items.Add(new MyComboBoxItem("GODZILLA vs. KONG")
            {
                SubItems = { new MyComboBoxItem("11:30"), new MyComboBoxItem("16:30") }
            });

            cb1Items.Add(new MyComboBoxItem("CRUELLA")
            {
                SubItems = { new MyComboBoxItem("19:45"),  }
            });

            cb1Items.Add(new MyComboBoxItem("SZYBCY I WŚCIEKLI 9")
            {
                SubItems = { new MyComboBoxItem("15:50"), new MyComboBoxItem("19:00") }
            });

            cb1Items.Add(new MyComboBoxItem("Miasto")
            {
                SubItems = { new MyComboBoxItem("17:45"), new MyComboBoxItem("21:20") }
            });

            cb1Items.Add(new MyComboBoxItem("Luca")
            {
                SubItems = { new MyComboBoxItem("10:20"), new MyComboBoxItem("13:30") }
            });

            //load data items into combobox 1
            cbMovie.Items.AddRange(cb1Items.ToArray());
        }

        private void cbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the combobox item
             MyComboBoxItem item = (sender as ComboBox).SelectedItem as MyComboBoxItem;

            
            if (item == null)
                return;

            //clear out combobox 2
            cbTime.Items.Clear();

            //add sub items
            cbTime.Items.AddRange(item.SubItems.ToArray());
           
            
        }

        public class MyComboBoxItem
        {
            public string Name;
            public List<MyComboBoxItem> SubItems = new List<MyComboBoxItem>();

            public MyComboBoxItem(string name)
            {
                this.Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {

            if (textFirstname.Text != "" && textLastname.Text != "" && textEmail.Text != "" && cbMovie.Text != "" && int.Parse(textNumber.Text) > 1 && int.Parse(seatNR.Text) > 0)
            {
                string FirstName = textFirstname.Text;
                string LastName = textLastname.Text;
                string Email = textEmail.Text;
                int Number = int.Parse(textNumber.Text);
                int SeatNr = int.Parse(seatNR.Text);
                string MovieTitle = cbMovie.Text;

                var confirmResult = MessageBox.Show("Confirm booking?",
                                     "Confirmation",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    query = "INSERT INTO [Cinemadb].[dbo].[kInfo] (FirstName, LastName, Email, PhoneNr, SeatNR, MovieTitle) VALUES ('" + FirstName + "','" + LastName + "','" + Email + "'," + Number + "," + SeatNr + ",'" + MovieTitle + "')";
                    fdb.setData(query, "You have booked seat number: "+ SeatNr);
                    MainMenu mm = new MainMenu();
                    this.Hide();
                    mm.Show();
                }
                else
                {
                    // If 'No', do something here.
                }
            }
            else MessageBox.Show("Provided information was incorrect. Make sure to fill in all the boxes and choose your seat", "Error");

           

        }
    }
}
