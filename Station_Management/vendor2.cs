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
    public partial class vendor2 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public vendor2()
        {
            InitializeComponent();
        }

        /*private void Update_Click(object sender, EventArgs e)
        {
            update_income frm = new update_income();
            frm.Show();
            this.Hide();
        }*/

        private void next_Click(object sender, EventArgs e)
        {
            i++;
            if (i >= dt.Rows.Count)
                i = 0;
            dr = dt.Rows[i];
            shid.Text = dr["shop_id"].ToString();
            shpl.Text = dr["plt_no"].ToString();
            shst.Text = dr["st_id"].ToString();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
                i = dt.Rows.Count - 1;
            dr = dt.Rows[i];
            shid.Text = dr["shop_id"].ToString();
            shpl.Text = dr["plt_no"].ToString();
            shst.Text = dr["st_id"].ToString();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You!!");
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Vendor frm = new Vendor();
            frm.Show();
            this.Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddShop frm = new AddShop();
            frm.Show();
            this.Hide();
        }

        private void vendor2_Load(object sender, EventArgs e)
        {
            String oradb = "DATA SOURCE=LAPTOP-V79O8VT9:1521/xe;PERSIST SECURITY INFO=True;USER ID=SYSTEM;Password=nandini";
            conn = new OracleConnection(oradb);
            conn.Open();
            comm = new OracleCommand();
            string vid = Vendor.vid;
            namev.Text = Vendor.vname;
            conv.Text = Vendor.vcon;
            stven.Text = Vendor.vst;
            //inv.Text = Vendor.vinc;
            try
            {
                comm.CommandText = "select * from shop where v_id=" + vid;
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "shop_demo");
                dt = ds.Tables["shop_demo"];
                int t = dt.Rows.Count;
                dr = dt.Rows[i];
                shid.Text = dr["shop_id"].ToString();
                shpl.Text = dr["plt_no"].ToString();
                shst.Text = dr["st_id"].ToString();
                //vendor2 frm = new vendor2();
                //frm.Show();
                //this.Hide();
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
    }
}
