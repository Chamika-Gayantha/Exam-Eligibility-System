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
    public partial class addMarks : Form
    {
        public addMarks()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        public void clearInputs()
        {
            txtSid.Clear();
            cbsubject.Text = "";
            txtIca1.Clear();
            txtIca2.Clear();
            txtIca3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lecDashBoard lb = new lecDashBoard();
            this.Hide();
            lb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var studentId = txtSid.Text.Trim();
                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Please enter Student ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbsubject.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cbsubject.Text))
                {
                    MessageBox.Show("Please select subject", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                updateMark um = new updateMark();
                um.StudentId = txtSid.Text.Trim();
                um.Subject = cbsubject.SelectedText.Trim();
                um.ICA1 = Convert.ToInt32(txtIca1.Text.Trim());
                um.ICA2 = Convert.ToInt32(txtIca2.Text.Trim());
                um.ICA3 = Convert.ToInt32(txtIca3.Text.Trim());

                db.updateMarks.InsertOnSubmit(um);
                db.SubmitChanges();
                clearInputs();

                MessageBox.Show("Successfully add the Marks!", "AddMarks", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    } }
    
