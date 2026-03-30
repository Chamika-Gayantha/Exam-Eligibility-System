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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lectureLogin l1 =new lectureLogin();
            this.Hide();
            l1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stdLogin stdLogin =new stdLogin();
            this.Hide();
            stdLogin.Show();

        }
    }
}
