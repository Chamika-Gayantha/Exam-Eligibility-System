
using Eligibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eligibulitySytem
{
    public partial class viewMarks : Form
    {
        string id;
        public viewMarks(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

        private void button2_Click(object sender, EventArgs e)
        {
            stdDashBoard sd = new stdDashBoard(id);
            sd.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var key = id.PadRight(10);

                var marks = db.updateMarks
                    .Where(m => m.StudentId == key)
                    .Select(m => new
                    {
                        Subject = (m.Subject ?? "").Trim(),
                        ICA1 = m.ICA1 ?? 0,
                        ICA2 = m.ICA2 ?? 0,
                        ICA3 = m.ICA3 ?? 0
                    })
                    .ToList();
                //foreach (var item in marks)
                //    System.Diagnostics.Debug.WriteLine($"Subject:'{item.Subject}' ICA1:{item.ICA1} ICA2:{item.ICA2} ICA3:{item.ICA3}");

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = marks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewMark_Load(object sender, EventArgs e)
        {

        }
    }
}