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
    public partial class genEmp : Form
    {
        public genEmp()
        {
            InitializeComponent();
        }

        private void genEmp_Load(object sender, EventArgs e)
        {
            name.Text = Employee.ename;
            id.Text = Employee.eid;
            addr.Text = Employee.eadd;
            gen.Text = Employee.egen;
            sal.Text = Employee.esal;
            dob.Text = Employee.ebday;
            stid.Text = Employee.estid;
            stna.Text = Employee.estna;
            did.Text = Employee.edepid;
            dna.Text = Employee.edepna;
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

        private void button1_Click(object sender, EventArgs e)
        {
            EmpGenDet frm = new EmpGenDet();
            frm.Show();
            this.Hide();
        }
    }
}
