using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ST_TestTask
{
    public partial class Form1 : Form
    {
        private Main main = new Main();
        private DateTime? _dt;
        private double _total;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           FillTable();
           CountTotal();
        }

		private void FillTable()
		{
			foreach (Person person in main.personnel)
			{
				Employees.Rows.Add
					(
					person.ID,
					person.NAME,
					person.LASTNAME,
					person.STARTDATE.ToString("d"),
					person.WAGERATE,
					String.Format("{0,12:000.00}", main.CalculateWage(person.ID, person.STARTDATE, person.WAGERATE, person.GROUP, _dt)),
					person.GROUP,
					main.GetBossName(person.ID),
					main.GetSubordinatesNames(person.ID)
					);
			}

		}

        private void CountTotal()
        {
            try
            {
                foreach (DataGridViewRow dgvr in Employees.Rows)
                {
                    _total += Double.Parse(dgvr.Cells[5].Value.ToString());
                }
                
            }
            catch (Exception e)
            {

            }
            finally
            {
                label4.Text = _total.ToString();
            }
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Employees.Rows.Clear();
            Employees.Refresh();
            _dt = dateTimePicker1.Value;
            FillTable();
        }
    }
}
