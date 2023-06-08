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
    public partial class Ticket : Form
    {
        OracleConnection conn;
        OracleCommand comm,comm1;
        OracleDataAdapter da,da1;
        DataSet ds,ds1;
        DataTable dt,dt1;
        DataRow dr,dr1;
        int i = 0;
        public Ticket()
        {
            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            comm1 = new OracleCommand();
            string pnr = Passenger.pnr;
            string tno = Passenger.tno;
            pnr_label.Text = Passenger.pnr;
            trainNo_Label.Text = Passenger.tno;
            src_label.Text = Passenger.src;
            dst_label.Text = Passenger.dest;
            pass_label.Text = Passenger.nop;
            amnt.Text = Passenger.tot;
            try
            {
                comm.CommandText = "select * from stops_at where train_no=" + tno;
                comm1.CommandText = "select * from passenger where pnr_no=" + pnr;
                comm.CommandType = CommandType.Text;
                comm1.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "demo");
                dt = ds.Tables["demo"];
                dr = dt.Rows[0];
                arrt.Text = dr["arr_h"].ToString() + " hours " + dr["arr_min"].ToString() +" min ";
                dept.Text = dr["dep_h"].ToString() + " hours " + dr["dep_min"].ToString() + " min ";
                ds1 = new DataSet();
                da1 = new OracleDataAdapter(comm1.CommandText, conn);
                da1.Fill(ds1, "demo1");
                dt1 = ds1.Tables["demo1"];
                dr1 = dt1.Rows[i];
                passn.Text = dr1["p_name"].ToString();
                passa.Text = dr1["age"].ToString();
                passc.Text = dr1["coach"].ToString();
                passs.Text = dr1["seat"].ToString();
                passg.Text = dr1["gender"].ToString();
            }
            catch
            {
                MessageBox.Show("Error2!!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void next_Click(object sender, EventArgs e)
        {
            i++;
            if (i >= dt1.Rows.Count)
                i = 0;
            dr1 = dt1.Rows[i];
            passn.Text = dr1["p_name"].ToString();
            passa.Text = dr1["age"].ToString();
            passc.Text = dr1["coach"].ToString();
            passs.Text = dr1["seat"].ToString();
            passg.Text = dr1["gender"].ToString();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
                i = dt1.Rows.Count-1;
            dr1 = dt1.Rows[i];
            passn.Text = dr1["p_name"].ToString();
            passa.Text = dr1["age"].ToString();
            passc.Text = dr1["coach"].ToString();
            passs.Text = dr1["seat"].ToString();
            passg.Text = dr1["gender"].ToString();
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
