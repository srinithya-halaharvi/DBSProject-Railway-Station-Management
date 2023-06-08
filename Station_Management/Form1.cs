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
    public partial class Form1 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form1()
        {
            InitializeComponent();
        }
        public void DB_Connect()
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Passenger frm = new Passenger();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vendor frm = new Vendor();
            frm.Show();
            this.Hide();
        }

       

        private void button5_Click_1(object sender, EventArgs e)
        {
            /*String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            string tno = "4095";
            comm.CommandText = "select * from train where train_no="+tno;
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "train1");
            dt = ds.Tables["train1"];
            int t = dt.Rows.Count;
            //MessageBox.Show(t.ToString());
            dr = dt.Rows[0];
            textBox1.Text = dr["train_no"].ToString();
            //textBox2.Text = dr["st_id"].ToString();
            //textBox3.Text = dr["deptname"].ToString();
            //textBox4.Text = dr["salary"].ToString();
            conn.Close();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            frm.Show();
            this.Hide();
        }

     
    }
}
