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
    public partial class Passenger : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public static string pnr="";
        public static string tno = "";
        public static string nop = "";
        public static string src = "";
        public static string dest = "";
        public static string tot = "";
        public Passenger()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            try
            {
                comm.CommandText = "select * from pnr where pnr_no= '"+textBox1.Text+"'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "pnr_demo");
                dt = ds.Tables["pnr_demo"];
                int t = dt.Rows.Count;
                if (t == 1)
                {
                    pnr = textBox1.Text;
                    MessageBox.Show("Successful Login!!");
                    dr = dt.Rows[0];
                    tno = dr["train_no"].ToString();
                    nop = dr["no_of_pass"].ToString();
                    src = dr["p_source"].ToString();
                    dest = dr["p_destination"].ToString();
                    tot = dr["total_amt"].ToString();
                    Ticket frm = new Ticket();
                    frm.Show();
                    this.Hide();
                    //MessageBox.Show(tno+" "+nop+" "+src+" "+dest+" "+tot);
                }
            }
            catch
            {
                MessageBox.Show("Error!!");
            }
            finally
            {
                conn.Close();
            }
       
            //Application.Exit();
        }

        private void Passenger_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You!!");
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            book_plt_ticket frm = new book_plt_ticket();
            frm.Show();
            this.Hide();
        }
    }
}
