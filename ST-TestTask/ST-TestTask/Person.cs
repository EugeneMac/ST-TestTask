using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_TestTask
{
    class Person
    {
        private string _name;
        private string _lastName;
        private int _id;
        private DateTime _startDate;
        private EmpType _groupId;
        private int _wageRate;
        

        enum EmpType : byte
        {
            Employee = 1,
            Manager,
            Salesman
        }

        public Person(int id, string name, string lastname, string startdate, int groupid, int wagerate)
        {
            _id = id;
            _name = name;
            _lastName = lastname;
            _startDate = DateTime.Parse(startdate);
            _groupId = (EmpType)groupid;
            _wageRate = wagerate;
        }

        
}
}
