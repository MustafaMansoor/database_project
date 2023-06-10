using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace finalproject
{
    public  class connectionclass
    {
    
        private static readonly
            string connectionString = "Data Source=localhost:1521/xe;User Id=FINALPROJECT;Password=finalproject;";

        public static OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }
    }


}


