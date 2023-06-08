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
    public partial class AddShop : Form
    {
        OracleConnection conn;
        OracleCommand comm,comm1;
        public AddShop()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            //comm1 = new OracleCommand();
            string vid = Vendor.vid;
            try
            {
                comm.Connection = conn;
                comm.CommandText = "insert into add_shop values('" + textBox1.Text + "','" + vid + "','" + textBox2.Text + "','" + textBox2.Text + "')";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                MessageBox.Show("INSERTED TEMPORARILY (will be shortly added permanently after varification)");
                //comm1.Connection = conn;
                //comm1.CommandText = "insert into shop values('" + textBox1.Text + "','" + vid + "','" + textBox2.Text + "','" + textBox2.Text + "')";
                //comm1.CommandType = CommandType.Text;
                //comm1.ExecuteNonQuery();
                
            }
            catch
            {
                MessageBox.Show("Error!!");
            }
            finally
            {
                conn.Close();
            }
            vendor2 frm = new vendor2();
            frm.Show();
            this.Hide();
        }
    }
}
