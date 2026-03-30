using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Eligibility
{
    public partial class updateAtd : Form
    {
        public updateAtd()
        {
            InitializeComponent();
        }

       
        private DataClasses1DataContext db = new DataClasses1DataContext();

        private void button2_Click(object sender, EventArgs e)
        {
            lecDashBoard l1 = new lecDashBoard();
            this.Hide();
            l1.Show();
        }

        public void ClearInputs()
        {
            txtSid.Clear();
           
            comboBoxSub.SelectedIndex = -1;
            radioButtonP.Checked = false;
            radioButtonA.Checked = false;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate student id
                var studentId = txtSid.Text.Trim();
                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Please enter Student ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate status
                string statusCheck = "";

                if (radioButtonP.Checked)
                {
                    statusCheck = "Present";
                }
                else if (radioButtonA.Checked)
                {
                    statusCheck = "Absent";
                }
                else
                {
                    MessageBox.Show("Please select Present or Absent", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxSub.SelectedIndex == -1 && string.IsNullOrWhiteSpace(comboBoxSub.Text))
                {
                    MessageBox.Show("Please select subject", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                updateAttendense ua = new updateAttendense();
                ua.studentId = studentId;
                ua.subject = comboBoxSub.Text.Trim();
                ua.date = dateTimePicker2.Value;
                ua.status = statusCheck.Trim();

                db.updateAttendenses.InsertOnSubmit(ua);
                db.SubmitChanges();
                ClearInputs();
                MessageBox.Show("Successfully updated the attendance!", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.OnFormClosed(e);
        }
    }
}