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
    public partial class manageStd : Form
    {
        public manageStd()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db= new DataClasses1DataContext();

        public void ClearInputs()
        {
            txtSname.Clear();
            txtSid.Clear();
            txtSage.Clear();
            txtAddress.Clear();
            txtSphone.Clear();
            txtSpw.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lecDashBoard ld=new lecDashBoard();
            this.Hide();
            ld.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                studentDetail sd = new studentDetail();
                sd.StudentID = txtSid.Text.Trim();
                sd.Name = txtSname.Text.Trim();
                sd.Age = int.Parse(txtSage.Text.Trim());
                sd.Address = txtAddress.Text.Trim();
                sd.Phone_no = txtSphone.Text.Trim();
                sd.Password = txtSpw.Text.Trim();

                db.studentDetails.InsertOnSubmit(sd);
                db.SubmitChanges();
                ClearInputs();

                MessageBox.Show("Successfully Added The Student Details", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
             }
        }
    }
}
