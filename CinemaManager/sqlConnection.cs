using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Formats;
using System.Windows.Forms;

namespace CinemaManager
{
    class functionsDB
    {
        protected SqlConnection GetConnection() // płączenie z bazą 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source = (LocalDb)\MSSqllocalDB;database=Cinemadb;integrated security = True";
            return con;
        }

        public DataSet GetData(String query) // pobieranie danych z bazy 
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query, String message) // dodawanie usuwanie updateowanie
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'" + message + "'", "done", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public SqlDataReader getForComboBox(String query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
