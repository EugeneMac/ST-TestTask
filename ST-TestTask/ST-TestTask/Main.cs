using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_TestTask
{
   

    class Main
    {
       DB db = new DB();
       public List<Person> personnel = new List<Person>();
       

       public Main()
       {
            //Load users from DB
            foreach (int id in db.getUsersIDs())
            {
                Person person = new Person
                    (id,
                    db.getUserName(id),
                    db.getUserLastName(id),
                    DateTime.Parse(db.getUserStartDate(id)),
                    Int32.Parse(db.getUserGroupID(id)),
                    Int32.Parse(db.getUserWageRate(id))
                    );
                personnel.Add(person);
            }

           //List<int> test = new List<int>();
           //test = GetAllSubordinates(9);
       }

        /// <summary>
        /// Wage calculation method!
        /// </summary>
        /// <param name="id">person's id in database</param>
        /// <param name="startDate">a date when employee started to work</param>
        /// <param name="wageRate">a base wage rate for this employee</param>
        /// <param name="group">a group which can be employee, manager, salesman</param>
        /// <param name="dt">optional paramm of the calculation date, if omitted we use today's date</param>
        /// <returns></returns>
        public double CalculateWage(int id, DateTime startDate, int wageRate, string group, DateTime? dt = null)
        {
            if (!dt.HasValue) dt = DateTime.Today;
            int years = dt.Value.Year - startDate.Year;
            switch (group)
            {
                case "Employee":
                case "1":
                {
                    // if work experience is between 1 and 10 years we pay wagerate + 3% of wagerate per every year but no more than 30%
                    if (years > 0 && years < 11) return (wageRate + years * wageRate * 0.03);
                    // if work experience is more than 10 years we pay wagerate + 30 % of wagerate
                    if (years > 10) return wageRate + wageRate * 0.3;
                    // if work experience is less than  year we pay just wagerate
                    if (years < 1) return wageRate;
                    break;
                }
                case "Manager":
                case "2":
                {
                    double result;
                    double subordinatesTotal = 0;
                    //Countig only first line subordinates
                    foreach (int p_id in db.getSubordinates(id))
                    {
                        subordinatesTotal += CalculateWage
                                (
                                p_id,
                                DateTime.Parse(db.getUserStartDate(p_id)),
                                Int32.Parse(db.getUserWageRate(p_id)),
                                db.getUserGroupID(p_id),
                                dt
                                );
                    }

                    // if work experience is between 1 and 8 years we pay wagerate + 5% of wagerate per every year but no more than 40% (5$ * 8 years)
                    // Plus 0.5% of main subordinates total wage
                    if (years > 0 && years < 9)
                    {
                        result = wageRate + years * wageRate * 0.05;
                        result += subordinatesTotal * 0.005;
                        return result;
                    }
                    // if work experience is more than 8 years we pay wagerate + 40 % (max) of wagerate
                    // Plus 0.5% of main subordinates total wage
                    if (years > 8)
                    {
                        result = wageRate + wageRate * 0.4;
                        result += subordinatesTotal * 0.005;
                        return result;
                    }
                    // if work experience is less than 1 year we pay a wagerate
                    // Plus 0.5% of main subordinates total wage
                    if (years < 1)
                    {
                        return wageRate + subordinatesTotal * 0.005;
                    }
                    break;
                }
                case "Salesman":
                case "3":
                {
                    double result;
                    double subordinatesTotal = 0;
                    //Counting all subordinates
                    foreach (int p_id in GetAllSubordinates(id))
                    {
                        subordinatesTotal += CalculateWage
                                (
                                p_id,
                                DateTime.Parse(db.getUserStartDate(p_id)),
                                Int32.Parse(db.getUserWageRate(p_id)),
                                db.getUserGroupID(p_id),
                                dt
                                );
                    }
                    // if work experience is between 1 and 35 years we pay wagerate + 1% of wagerate per every year but no more than 35% (1$ * 35 years)
                    // Plus 0.3% of ALL subordinates total wage
                    if (years > 0 && years < 36)
                    {
                        result = wageRate + years * wageRate * 0.01;
                        result += subordinatesTotal * 0.003;
                        return result;
                    }
                    // if work experience is more than 35 years we pay wagerate + 35 % (max) of wagerate
                    // Plus 0.3% of ALL subordinates total wage
                    if (years > 35)
                    {
                        result = wageRate + wageRate * 0.35;
                        result += subordinatesTotal * 0.003;
                        return result;
                    }
                    // if work experience is less than 1 year we pay a wagerate
                    // Plus 0.5% of ALL subordinates total wage
                    if (years < 1)
                    {
                        return wageRate + subordinatesTotal * 0.005;
                    }

                    break;
                }
            }
            return 0;
        }

       
        //Returns a list of all subordinates for employee (recursively)
        private List<int> GetAllSubordinates(int id)
        {
            List<int> result = new List<int>();
            foreach (int person_id in db.getSubordinates(id))
            {
                result.Add(person_id);

                if (db.getSubordinates(person_id).Count > 0)
                {
                    //Recursive call to find all the subordinates in database
                    result.AddRange(GetAllSubordinates(person_id));
                }

            }

            return result;
        }

        //Returns an employee's boss name
        public string GetBossName(int id)
        {
            string bossId = db.getBossID(id);
            return bossId==""? "": db.getUserName(Int32.Parse(bossId)) + " " + db.getUserLastName(Int32.Parse(bossId));
        }

        // Returns comma delimited string of employee subordinates names
        public string GetSubordinatesNames(int id)
        {
            List<int> subordinates = db.getSubordinates(id);
            String result =String.Empty;
            if (subordinates.Count > 0)
            {
                foreach (int subId in subordinates)
                {
                    result += db.getUserName(subId) + " " + db.getUserLastName(subId) + ", ";
                }
                return result;
            }
            return "";
        }
    }
  
}
