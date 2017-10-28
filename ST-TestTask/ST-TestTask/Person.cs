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


        public int ID
        {
            get { return _id; }
        }

        public string NAME
        {
            get { return _name; }
        }

        public string LASTNAME
        {
            get { return _lastName; }
        }

        public DateTime STARTDATE
        {
            get { return _startDate; }
        }

        public string GROUP
        {
            get { return _groupId.ToString(); }
        }

        public int WAGERATE
        {
            get { return _wageRate; }
        }

        enum EmpType : byte
        {
            Employee = 1,
            Manager,
            Salesman
        }

        public Person(int id, string name, string lastname, DateTime startdate, int groupid, int wagerate)
        {
            _id = id;
            _name = name;
            _lastName = lastname;
            _startDate = startdate;
            _groupId = (EmpType)groupid;
            _wageRate = wagerate;
        }

        
}
}
