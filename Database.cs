using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Database
    {
        static string connectionString;
        static Database()
        {
            connectionString = "data source=DESKTOP-5EFM0GN;initial catalog=CabGoDB;integrated security=true";
        }
        public Database(string conStr)
        {
            connectionString = conStr;
        }
        public static string ConnectionString
        {
            get { return connectionString; }
        }
    }
}
