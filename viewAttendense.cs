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
    public partial class viewAttendense : Form
    {
        string id;
        public viewAttendense(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stdDashBoard sd=new stdDashBoard(id);
            this.Hide();
            sd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Student ID not provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Pad to match NChar(10) storage if necessary
                var key = id.PadRight(10);

                var groups = db.updateAttendenses
                              .Where(m => m.studentId == key)
                              .GroupBy(m => (m.subject ?? string.Empty).Trim())
                              .Select(g => new
                              {
                                  Subject = g.Key,
                                  TotalClasses = g.Count(),
                                  AttendedClasses = g.Count(x => (x.status ?? string.Empty).Trim() == "Present")
                              })
                              .ToList();

                if (!groups.Any())
                {
                    MessageBox.Show("No attendance records found for this student.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                    return;
                }
                var result = groups.Select(g => new
                {
                    Subject = g.Subject,
                    TotalClasses = g.TotalClasses,
                    AttendedClasses = g.AttendedClasses,
                    AttendancePercentage = g.TotalClasses == 0 ? 0.0 : (g.AttendedClasses * 100.0 / g.TotalClasses)
                }).ToList();

                dataGridView1.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
