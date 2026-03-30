using System;
using System.Linq;
using System.Windows.Forms;

namespace Eligibility
{
    public partial class stdLogin : Form
    {
        public stdLogin()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            string studentId = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();

            try
            {

                // Pad inputs so equality matches the stored values reliably.
                var keyId = studentId.PadRight(10);
                var keyPwd = password.PadRight(10);

                var result = db.studentDetails.FirstOrDefault(s => s.StudentID == keyId && s.Password == keyPwd);
                if (result != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    stdDashBoard sd = new stdDashBoard(textBox2.Text);
                    this.Hide();
                    sd.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Login failed. Please contact the administration.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}