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
    public partial class Employee : Form
    {
        OracleConnection conn;
        OracleCommand comm,comm1,comm2;
        OracleDataAdapter da,da1,da2;
        DataSet ds,ds1,ds2;
        DataTable dt,dt1,dt2;
        DataRow dr,dr1,dr2;
        public static string eid = "";
        public static string ename = "";
        public static string eadd = "";
        public static string egen = "";
        public static string esal = "";
        public static string ebday = "";
        public static string edepid = "";
        public static string edepna = "";
        public static string estid = "";
        public static string estna = "";
        int v;
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
           
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            comm1 = new OracleCommand();
            comm2 = new OracleCommand();
           try
           {
                comm.CommandText = "select * from employee where e_id= '" + textBox1.Text + "' AND e_paswrd= '" + textBox2.Text + "'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "emp_demo");
                dt = ds.Tables["emp_demo"];
                int t = dt.Rows.Count;
                
                if (t == 1)
                {
                    eid = textBox1.Text;
                    MessageBox.Show("Successful Login!!");
                    dr = dt.Rows[0];
                    
                    ename = dr["e_name"].ToString();
                    eadd = dr["address"].ToString();
                    egen = dr["gender"].ToString();
                    
                    esal = dr["salary"].ToString();
                    ebday = dr["b_date"].ToString();
                    edepid = dr["dep_id"].ToString();
                    estid = dr["st_id"].ToString();


                    v = int.Parse(edepid);  
                    
                }

                comm1.CommandText = "select * from department where dep_id=" + edepid;
                comm1.CommandType = CommandType.Text;
                ds1 = new DataSet();
                da1 = new OracleDataAdapter(comm1.CommandText, conn);
                da1.Fill(ds1, "dep_demo");
                dt1 = ds1.Tables["dep_demo"];
                dr1 = dt1.Rows[0];
                edepna = dr1["d_name"].ToString();
                

                comm2.CommandText = "select * from station where st_id=" + estid;
                comm2.CommandType = CommandType.Text;
                ds2 = new DataSet();
                da2 = new OracleDataAdapter(comm2.CommandText, conn);
                da2.Fill(ds2, "st_demo");
                dt2 = ds2.Tables["st_demo"];
                dr2 = dt2.Rows[0];
                estna = dr2["s_name"].ToString();
                //MessageBox.Show(estna);
                if (v == 3)
                {
                    genEmp frm = new genEmp();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    employee2 frm = new employee2();
                    frm.Show();
                    this.Hide();
                }
            }
            catch (OracleException ex)
           {
                MessageBox.Show("Oracle Error: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Argument Error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Format Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error: " + ex.Message);
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
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
