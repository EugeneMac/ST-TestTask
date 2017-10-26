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
        private string _startDate;
        private int _groupId;
        private int _wageRate;

        public Person(int id, string name, string lastname, string startdate, int groupid, int wagerate)
        {
            _id = id;
            _name = name;
            _lastName = lastname;
            _startDate = startdate;
            _groupId = groupid;
            _wageRate = wagerate;
        }
}
}
