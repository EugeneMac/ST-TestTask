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

        }
    }
  
}
