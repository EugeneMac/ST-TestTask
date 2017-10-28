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

        public string getUserWageRate(int id)
        {
            _sSql = @"SELECT wagerate FROM employees WHERE id = @a";
            object tempobject = FindInDB(_sSql, id.ToString());
            return tempobject == null ? "" : tempobject.ToString();
        }

        public string getUserGroupID(int id)
        {
            _sSql = @"SELECT groupid FROM employees WHERE id = @a";
            object tempobject = FindInDB(_sSql, id.ToString());
            return tempobject == null ? "" : tempobject.ToString();
        }

        public string getUserStartDate(int id)
        {
            _sSql = @"SELECT startdate FROM employees WHERE id = @a";
            object tempobject = FindInDB(_sSql, id.ToString());
            return tempobject == null ? "" : tempobject.ToString();
        }

        public string getUserLastName(int id)
        {
            _sSql = @"SELECT lastname FROM employees WHERE id = @a";
            object tempobject = FindInDB(_sSql, id.ToString());
            return tempobject == null ? "" : tempobject.ToString();
        }

        public string getUserName(int id)
        {
            _sSql = @"SELECT name FROM employees WHERE id = @a";
            object tempobject = FindInDB(_sSql, id.ToString());
            return tempobject == null ? "" : tempobject.ToString();
        }

        public List<int> getUsersIDs()
        {
            _sSql = @"SELECT id FROM employees";
            return SelectSQL(_sSql).Select(int.Parse).ToList();
        }

        public DB()
        {
            // Every time we run app we should check the existance of sqlite database file. Create it if it doesn't exist!
            _sPath = Path.Combine(Application.UserAppDataPath, "sttest.db");

            if (!File.Exists(_sPath))
            {
                _sSql = @"CREATE TABLE employees ([id] INTEGER PRIMARY KEY AUTOINCREMENT, [name] TEXT, [lastname] TEXT, [startdate] TEXT, [wagerate] INTEGER, [groupid] INTEGER);";
                _sSql += " CREATE TABLE subordinates ([id] INTEGER, [subordinate_id] INTEGER, FOREIGN KEY (id) REFERENCES employees(id), FOREIGN KEY (subordinate_id) REFERENCES employees(id));";
                //Let's add some fake users
                _sSql += " INSERT INTO employees VALUES(1, 'John', 'Smith', '2008-05-01', '1000', 1);";
                _sSql += " INSERT INTO employees VALUES(3, 'Mary', 'Green', '2017-06-06', '1500', 2);";
                _sSql += " INSERT INTO employees VALUES(5, 'Peter', 'Black', '2016-01-01', '1300', 3);";
                _sSql += " INSERT INTO employees VALUES(7, 'Jane', 'Doe', '2015-02-03', '1000', 1);";
                _sSql += " INSERT INTO employees VALUES(9, 'Berry', 'Gray', '2010-05-05', '1500', 2);";
                _sSql += " INSERT INTO subordinates VALUES(3, 1);";
                _sSql += " INSERT INTO subordinates VALUES(3, 5);";
                _sSql += " INSERT INTO subordinates VALUES(9, 7);";

                ExecuteSQL(_sSql, "True", "");
            }
            

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

        public object FindInDB(string sSql, string par)
        {
            object result = null;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection())
                {
                    con.ConnectionString = @"Data Source=" + _sPath + ";New=False;Version=3";
                    con.Open();
                    SQLiteCommand sqlCommand = new SQLiteCommand(sSql, con);
                    if (par != "") sqlCommand.Parameters.AddWithValue("@a", par);

                    using (sqlCommand)
                    {

                        SQLiteDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            result = reader.GetValue(0);
                        }



                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;


        }

        private List<string> SelectSQL(string sSql)
        {
            List<string> result = new List<string>();
          
            try
            {
                using (SQLiteConnection con = new SQLiteConnection())
                {
                    con.ConnectionString = @"Data Source=" + _sPath + ";New=False;Version=3";
                    con.Open();
                    using (SQLiteCommand sqlCommand = con.CreateCommand())
                    {
                        sqlCommand.CommandText = sSql;
                        SQLiteDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            result.Add(reader.GetValue(0).ToString());
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;

        }
    }
}
