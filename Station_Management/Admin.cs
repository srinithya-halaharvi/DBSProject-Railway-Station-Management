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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "aDmiNlogIn2811") {
                MessageBox.Show("Successfull login");
                admin2 frm = new admin2();
                frm.Show();
                this.Hide();
            }
        }
    }
}
