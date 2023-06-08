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
    public partial class Vendor : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public static string vid = "";
        public static string vname = "";
        public static string vcon = "";
        //public static string vinc = "";
        public static string vst = "";
        public Vendor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            try
            {
                comm.CommandText = "select * from vendor where v_id= '" + textBox1.Text + "'AND password= '" + textBox2.Text + "'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "vendor_demo");
                dt = ds.Tables["vendor_demo"];
                int t = dt.Rows.Count;
                if (t == 1)
                {
                    vid = textBox1.Text;
                    MessageBox.Show("Successful Login!!");
                    dr = dt.Rows[0];
                    vname = dr["name"].ToString();
                    vcon = dr["contact_no"].ToString();
                    //vinc = dr["income"].ToString();
                    vst = dr["st_id"].ToString();
                    vendor2 frm = new vendor2();
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

        }

        private void Vendor_Load(object sender, EventArgs e)
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

    }
}
