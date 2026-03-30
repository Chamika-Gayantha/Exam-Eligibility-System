using eligibulitySytem;
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
    public partial class stdDashBoard : Form
    {
        string id;
        public stdDashBoard(string id)
        {
            InitializeComponent();
            this.id = id?.Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewMarks vn=new viewMarks(id);
            this.Hide();
            vn.Show();
        }

        private void btnViewAtd_Click(object sender, EventArgs e)
        {
            viewAttendense vn = new viewAttendense(id);
            this.Hide();
            vn.Show();
        }

        private void btnVieweligi_Click(object sender, EventArgs e)
        {
            checkEligibility cn = new checkEligibility(id);
            this.Hide();
            cn.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}