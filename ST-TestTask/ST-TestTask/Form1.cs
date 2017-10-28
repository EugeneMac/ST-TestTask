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
        
        Main main = new Main();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           FillTable();
        }

        private void FillTable()
        {
            DateTime? dt = null;

            foreach (Person person in main.personnel)
            {
                Employees.Rows.Add
                    (
                    person.ID,
                    person.NAME,
                    person.LASTNAME,
                    person.STARTDATE.ToString("d"),
                    person.WAGERATE,
                    String.Format("{0,12:000.00}", main.CalculateWage(person.ID, person.STARTDATE, person.WAGERATE, person.GROUP, dt)),
                    person.GROUP,
                    main.GetBossName(person.ID),
                    main.GetSubordinatesNames(person.ID)
                    );

            }

        }
    }
}
