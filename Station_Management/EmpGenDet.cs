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
    public partial class EmpGenDet : Form
    {
        OracleConnection conn;
        OracleCommand comm, comm1, comm2, comm3;
        OracleDataAdapter da, da1, da2, da3;
        DataSet ds, ds1, ds2, ds3;
        DataTable dt, dt1, dt2, dt3;
        DataRow dr, dr1, dr2, dr3;
        public static string stid = "";
        public static string stna = "";
        public static string eadd = "";
        public static string egen = "";
        public static string esal = "";
        public static string ebday = "";
        public static string edepid = "";
        public static string edepna = "";
        public static string estid = "";
        public static string estna = "";
        int i0 = 0;
        int i1 = 0;
        int i2 = 0;
        public EmpGenDet()
        {
            InitializeComponent();
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void EmpGenDet_Load(object sender, EventArgs e)
        {

            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            comm1 = new OracleCommand();
            comm2 = new OracleCommand();
            stid = Employee.estid;
            stna = Employee.estna;
            sname.Text = stna;
            sname1.Text = stna;
            sname2.Text = stna;
            sname3.Text = stna;
            //MessageBox.Show(stid);
            try
            {
            comm.CommandText = "select * from stops_at where st_id=" + stid;
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "new_demo");
                dt = ds.Tables["new_demo"];
                dr = dt.Rows[i0];
                label7.Text = dr["train_no"].ToString();
                //label8.Text = dr["t_name"].ToString();
                //label6.Text = dr["origin"].ToString();
                //label5.Text = dr["destination"].ToString();
                label39.Text = dr["arr_h"].ToString() + " hours " + dr["arr_min"].ToString() + " min ";
                label40.Text = dr["dep_h"].ToString() + " hours " + dr["dep_min"].ToString() + " min ";


                comm1.CommandText = "select * from pnr where p_source='" + stna + "'";
                //comm1.CommandText = "select * from passenger natural join pnr where p_source='" + stna + "'";
                comm1.CommandType = CommandType.Text;
                ds1 = new DataSet();
                da1 = new OracleDataAdapter(comm1.CommandText, conn);
                da1.Fill(ds1, "new1_demo");
                dt1 = ds1.Tables["new1_demo"];
                dr1 = dt1.Rows[i1];
                label9.Text = dr1["no_of_pass"].ToString();
                label10.Text = dr1["pnr_no"].ToString();
                label44.Text = dr1["train_no"].ToString();
                label43.Text = dr1["p_destination"].ToString();
                //label12.Text = dr1["gender"].ToString();
                //label13.Text = dr1["coach"].ToString();
                //label36.Text = dr1["seat"].ToString();
                //label11.Text = dr1["age"].ToString();

                comm2.CommandText = "select * from pnr where p_destination='" + stna + "'";
                comm2.CommandType = CommandType.Text;
                ds2 = new DataSet();
                da2 = new OracleDataAdapter(comm2.CommandText, conn);
                da2.Fill(ds2, "new2_demo");
                dt2 = ds2.Tables["new2_demo"];
                dr2 = dt2.Rows[i2];
                label14.Text = dr2["no_of_pass"].ToString();
                label15.Text = dr2["pnr_no"].ToString();
                label46.Text = dr2["train_no"].ToString();
                label45.Text = dr2["p_source"].ToString();
                //label17.Text = dr2["gender"].ToString();
                //label18.Text = dr2["coach"].ToString();
                //label38.Text = dr2["seat"].ToString();
                //label16.Text = dr2["age"].ToString();
            }
            catch
            {
                MessageBox.Show("Error111!!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void next1_Click(object sender, EventArgs e)
        {
            i0++;
            if (i0 >= dt.Rows.Count)
                i0 = 0;
            dr = dt.Rows[i0];
            label7.Text = dr["train_no"].ToString();
            //label8.Text = dr["t_name"].ToString();
            //label6.Text = dr["origin"].ToString();
            //label5.Text = dr["destination"].ToString();
            label39.Text = dr["arr_h"].ToString() + " hours " + dr["arr_min"].ToString() + " min ";
            label40.Text = dr["dep_h"].ToString() + " hours " + dr["dep_min"].ToString() + " min ";
        }

        private void previous1_Click(object sender, EventArgs e)
        {
            i0--;
            if (i0 < 0)
                i0 = dt.Rows.Count - 1;
            dr = dt.Rows[i0];
            label7.Text = dr["train_no"].ToString();
            //label8.Text = dr["t_name"].ToString();
            //label6.Text = dr["origin"].ToString();
            //label5.Text = dr["destination"].ToString();
            label39.Text = dr["arr_h"].ToString() + " hours " + dr["arr_min"].ToString() + " min ";
            label40.Text = dr["dep_h"].ToString() + " hours " + dr["dep_min"].ToString() + " min ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i1++;
            if (i1 >= dt1.Rows.Count)
                i1 = 0;
            dr1 = dt1.Rows[i1];
            label9.Text = dr1["no_of_pass"].ToString();
            label10.Text = dr1["pnr_no"].ToString();
            label44.Text = dr1["train_no"].ToString();
            label43.Text = dr1["p_destination"].ToString();
            //label12.Text = dr1["gender"].ToString();
            //label13.Text = dr1["coach"].ToString();
            //label36.Text = dr1["seat"].ToString();
            //label11.Text = dr1["age"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i1--;
            if (i1 < 0)
                i1 = dt1.Rows.Count - 1;
            dr1 = dt1.Rows[i1];
            label9.Text = dr1["no_of_pass"].ToString();
            label10.Text = dr1["pnr_no"].ToString();
            label44.Text = dr1["train_no"].ToString();
            label43.Text = dr1["p_destination"].ToString();
            //label12.Text = dr1["gender"].ToString();
            //label13.Text = dr1["coach"].ToString();
            //label36.Text = dr1["seat"].ToString();
            //label11.Text = dr1["age"].ToString();
        }

        private void next3_Click(object sender, EventArgs e)
        {
            i2++;
            if (i2 >= dt2.Rows.Count)
                i2 = 0;
            dr2 = dt2.Rows[i2];
            label14.Text = dr2["no_of_pass"].ToString();
            label15.Text = dr2["pnr_no"].ToString();
            label46.Text = dr2["train_no"].ToString();
            label45.Text = dr2["p_source"].ToString();
           // label17.Text = dr2["gender"].ToString();
           // label18.Text = dr2["coach"].ToString();
           // label38.Text = dr2["seat"].ToString();
           // label16.Text = dr2["age"].ToString();
        }

        private void prev3_Click(object sender, EventArgs e)
        {
            i2--;
            if (i2 < 0)
                i2 = dt2.Rows.Count - 1;
            dr2 = dt2.Rows[i2];
            label14.Text = dr2["no_of_pass"].ToString();
            label15.Text = dr2["pnr_no"].ToString();
            label46.Text = dr2["train_no"].ToString();
            label45.Text = dr2["p_source"].ToString();
            //label17.Text = dr2["gender"].ToString();
            //label18.Text = dr2["coach"].ToString();
            //label38.Text = dr2["seat"].ToString();
            //label16.Text = dr2["age"].ToString();

        }

        private void sname_Click(object sender, EventArgs e)
        {

        }

        private void view_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            
            string query = "select sum(qty) from platform_ticket where st_id=" + stid;
            //comm3.CommandType = CommandType.Text;
            comm3 = new OracleCommand(query, conn);
            object result = comm3.ExecuteScalar();
            if (result != null)
            {
                int sum = Convert.ToInt32(result);
                view.Text = sum.ToString();
            }
            else
            {
                view.Text = "NULL";
            }
            //ds3 = new DataSet();
            //da3 = new OracleDataAdapter(comm3.CommandText, conn);
            //da3.Fill(ds3, "new_demo");
            //dt3 = ds3.Tables["new_demo"];
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You!!");
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            genEmp frm = new genEmp();
            frm.Show();
            this.Hide();
        }
    }
}
