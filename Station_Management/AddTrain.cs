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
    public partial class AddTrain : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        public AddTrain()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            //string vid = Vendor.vid;
            try
            {
                comm.Connection = conn;
                comm.CommandText = "insert into train values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                MessageBox.Show("INSERTED TRAIN DETAILS");
                
            }
            catch
            {
                MessageBox.Show("Error!!");
            }
            finally
            {
                conn.Close();
            }
            admin2 frm = new admin2();
            frm.Show();
            this.Hide();
        }
    }
}
