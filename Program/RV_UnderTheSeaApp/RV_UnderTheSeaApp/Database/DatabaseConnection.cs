using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RV_UnderTheSeaApp
{
    class DatabaseConnection
    {
        private static DatabaseConnection __instance__ = null;
        private static readonly object padlock = new object();
        private SqlConnection CON;
        private DatabaseConnection()
        {
            CON = new SqlConnection(@"Data Source = DESKTOP-99AAD7R\REICHSQL; Initial Catalog = UnderTheSeaDB; Integrated Security = True");
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if(__instance__ == null)
                    {
                        __instance__ = new DatabaseConnection();
                    }
                    return __instance__;
                }
            }
        }

        public SqlConnection getConnection()
        {
            return CON;
        }
    }
}
