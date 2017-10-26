using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace ST_TestTask
{
    class DB
    {
        private string _sPath;
        private string _sSql;

        public DB()
        {
            // Every time we run app we should check the existance of sqlite database file. Create it if it doesn't exist!
            _sPath = Path.Combine(Application.UserAppDataPath, "sttest.db");

            if (!File.Exists(_sPath))
            {
                _sSql = @"CREATE TABLE employees ([id] INTEGER PRIMARY KEY AUTOINCREMENT, [name] TEXT, [lastname] TEXT, [startdate] UNSIGNED BIG INT, [wagerate] UNSIGNED INT, [groupid] INTEGER);";
                _sSql += " CREATE TABLE subordinates ([id] INTEGER, [subordinate_id] INTEGER, FOREIGN KEY (id) REFERENCES employees(id), FOREIGN KEY (subordinate_id) REFERENCES employees(id));";
            }
            ExecuteSQL(_sSql, "True", "");

        }

        private int ExecuteSQL(string sSql, string newbase, string par)
        {
            int n = 0;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection())
                {
                    con.ConnectionString = @"Data Source=" + _sPath + ";New=" + newbase + ";Version=3";
                    con.Open();
                    SQLiteCommand sqlCommand = new SQLiteCommand(_sSql, con);
                    if (par != "") sqlCommand.Parameters.AddWithValue("@a", par);
                    using (sqlCommand)
                    {
                        n = sqlCommand.ExecuteNonQuery();
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                n = 0;
                MessageBox.Show(ex.Message);
            }

            return n;
        }
    }
}
