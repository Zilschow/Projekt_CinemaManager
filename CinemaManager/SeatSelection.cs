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
    public partial class SeatSelection : Form
    {       
        public SeatSelection()
        {
            InitializeComponent();
                    
        }

        int i = 0;
        private void ToggleSeat(Button button)
        {

            if (i == 0)
            {
                button.BackColor = Color.Red;
                testbox.Text = button.Text;
                i++;
            }
            else if (i == 1 && button.BackColor == Color.Red)
            {
                button.BackColor = SystemColors.ButtonFace;
                button.UseVisualStyleBackColor = true ;
                testbox.Text = "Nie wybrano miejsca";
                i--;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button1);           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button2);           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button6);         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.ToggleSeat(button16);
        }
        private void confirmbut_Click(object sender, EventArgs e)
        {       
            Booking bo = (Booking)Application.OpenForms["Booking"];
            this.Hide();
            bo.Show();
            bo.ButtonText = "Your seat number: " + this.testbox.Text;
            bo.LabelText = this.testbox.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Booking bo = new Booking();
            this.Hide();
            bo.Show();
        }
    }
}
