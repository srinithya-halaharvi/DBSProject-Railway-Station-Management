using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Station_Management
{
    public partial class employee2 : Form
    {
        //public static string estn = "";
        public employee2()
        {
            InitializeComponent();
        }

        private void employee2_Load(object sender, EventArgs e)
        {
            //estn = Employee.estna;
            //MessageBox.Show(estn);
            name.Text = Employee.ename;
            id.Text = Employee.eid;
            addr.Text = Employee.eadd;
            gen.Text = Employee.egen;
            sal.Text = Employee.esal;
            dob.Text = Employee.ebday;
            stid.Text = Employee.estid;
            string abc = Employee.estna;
            stna.Text = Employee.estna;
            did.Text = Employee.edepid;
            dna.Text = Employee.edepna;
            //MessageBox.Show("HELLO");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You!!");
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.Show();
            this.Hide();
        }

    }
}
