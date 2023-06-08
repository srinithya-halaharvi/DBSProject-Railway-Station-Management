using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Station_Management
{
    public partial class book_plt_ticket : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        
        public book_plt_ticket()
        {
            InitializeComponent();
        }

        private void book_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            
            int f = int.Parse(textBox2.Text);
            int fare = f * 10;
            try
            {
                comm.Connection = conn;
                comm.CommandText = "insert into platform_ticket values('" + textBox1.Text + "','" + textBox2.Text + "','" + fare.ToString() + "')";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                MessageBox.Show("Platform Ticket Generated, Fare="+ fare);
                
            }
            catch
            {
                MessageBox.Show("Error!!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You!!");
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Passenger frm = new Passenger();
            frm.Show();
            this.Hide();
        }
    }
}
