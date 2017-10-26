using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST_TestTask
{
    class DB
    {
        private string _sPath = string.Empty;

        public DB()
        {
            // Every time we run app we should check the existance of sqlite database file. Create it if it doesn't exist!
            _sPath = Path.Combine(Application.UserAppDataPath, "sttest.db");
        }
    }
}
