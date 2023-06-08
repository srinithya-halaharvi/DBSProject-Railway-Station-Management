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
    public partial class admin2 : Form
    {
        OracleConnection oraCon;
        OracleCommand comm, comm1;
        
        public admin2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AddShop frm = new AddShop();
            //frm.Show();
            //this.Hide();
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            oraCon = new OracleConnection(oradb);
            oraCon.Open();
            string query = "SELECT * FROM add_shop";
            OracleCommand oraCmd = new OracleCommand(query, oraCon);
            OracleDataReader reader = oraCmd.ExecuteReader();
            while (reader.Read())
            {
                string shid = reader["shop_id"].ToString();
                string vid = reader["v_id"].ToString();
                string plt = reader["plt_no"].ToString();
                string stid = reader["st_id"].ToString();
                comm = new OracleCommand();
                comm.Connection = oraCon;
                comm.CommandText = "INSERT INTO SHOP VALUES ('" + shid + "','" + vid + "','" + plt + "','" + stid + "')";
                comm.CommandType = CommandType.Text;
                //comm.ExecuteNonQuery();
                MessageBox.Show("Inserted " + shid + " " + vid + " " + plt + " " + stid);
            }
            reader.Close();
            comm1 = new OracleCommand();
            comm1.Connection = oraCon;
            comm1.CommandText = "DELETE FROM add_shop";
            comm1.CommandType = CommandType.Text;
            comm1.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            oraCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTrain frm = new AddTrain();
            frm.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You!!");
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            frm.Show();
            this.Hide();
        }


    }
}
