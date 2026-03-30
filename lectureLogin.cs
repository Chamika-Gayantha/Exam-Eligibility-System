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
    public partial class lectureLogin : Form
    {
        public lectureLogin()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db=new DataClasses1DataContext();
        private void button3_Click(object sender, EventArgs e)
        {
            String username = uname.Text.Trim();
            String password = pw.Text.Trim();
            try
            {
                var result = db.lecterDetails.FirstOrDefault(u => u.UserName == username && u.Pasword == password);
                if (result != null)
                {
                    MessageBox.Show("Login successfully!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lecDashBoard lB = new lecDashBoard();
                    this.Hide();
                    lB.Show();
                }
                else
                {
                    MessageBox.Show("Login Failture..Plz XCantact the Adminstration", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }


                private void button1_Click(object sender, EventArgs e)
                {
                    Login l2 = new Login();
                    this.Hide();
                     l2.Show();
                }
    }
}
