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
    public partial class update_income : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        public update_income()
        {
            InitializeComponent();
        }

        private void set_Click(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            string vid = Vendor.vid;
            int v = int.Parse(textBox1.Text);
            int u = int.Parse(vid);
            //try
            //{
                comm.Connection = conn;
                comm.CommandText = "update shop set income=:pb where v_id=:pdn";
                comm.CommandType = CommandType.Text;
                OracleParameter pa1 = new OracleParameter();
                pa1.ParameterName = "pb";
                pa1.DbType = DbType.Int32;
                pa1.Value = v;
                OracleParameter pa2 = new OracleParameter();
                pa2.ParameterName = "pdn";
                pa2.DbType = DbType.Int32;
                pa2.Value = u;
                comm.Parameters.Add(pa1);
                comm.Parameters.Add(pa2);
                comm.ExecuteNonQuery();
                MessageBox.Show("INCOME UPDATED (will reflect on fresh login)"); 
                vendor2 frm = new vendor2();
                frm.Show();
                this.Hide();
            //}
            //catch
            //{
               // MessageBox.Show("Error!!");
            //}
           // finally
           // {
                conn.Close();
           // }
        }
    }
}
