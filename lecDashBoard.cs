using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eligibility
{
    public partial class lecDashBoard : Form
    {
        public lecDashBoard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manageStd m1=new manageStd();
            this.Hide();
            m1.Show();
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addMarks am=new addMarks();
            this.Hide();
            am.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateAtd up=new updateAtd();
            this.Hide();
            up.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }
    }
}
