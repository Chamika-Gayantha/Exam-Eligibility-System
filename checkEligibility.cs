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
    public partial class checkEligibility : Form
    {
        String id;
        public checkEligibility(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        DataClasses1DataContext db=new DataClasses1DataContext();

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stdDashBoard sD = new stdDashBoard(id);
            this.Hide();
            sD.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Get marks grouped by subject
                var marksData = db.updateMarks
                    .Where(m => m.StudentId == id)
                    .Select(m => new
                    {
                        m.Subject,
                        m.ICA1,
                        m.ICA2,
                        m.ICA3
                    }).ToList();

                // Get attendance grouped by subject
                var attendanceData = db.updateAttendenses
                    .Where(a => a.studentId == id)
                    .GroupBy(a => a.subject)
                    .Select(g => new
                    {
                        Subject = g.Key,
                        TotalClasses = g.Count(),
                        AttendedClasses = g.Count(x => x.status == "Present"),
                        AttendancePercentage = g.Count(x => x.status == "Present") * 100.0 / g.Count()
                    }).ToList();

                // Combine marks and attendance to calculate eligibility
                var eligibility = marksData
                    .Select(m =>
                    {
                        // Calculate highest 2 ICA marks average
                        int[] icas = { (int)m.ICA1, (int)m.ICA2, (int)m.ICA3 };
                        ;
                        var topTwo = icas.OrderByDescending(x => x).Take(2).ToArray();
                        double averageICA = topTwo.Average();

                        // Find attendance for this subject
                        var att = attendanceData.FirstOrDefault(a => a.Subject == m.Subject);
                        double attPercent = att != null ? att.AttendancePercentage : 0;

                        // Check eligibility
                        bool isEligible = averageICA >= 40 && attPercent >= 80;

                        return new
                        {
                            m.Subject,
                            ICA_Average = Math.Round(averageICA, 2),
                            Attendance = Math.Round(attPercent, 2),
                            Eligible = isEligible ? "Eligibale" : "Not Eligibale"
                        };
                    }).ToList();

                dataGridView1.DataSource = eligibility;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
