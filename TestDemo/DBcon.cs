using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public class DBcon
    { 

        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-01A825I;Initial Catalog=Diplomdb;Integrated Security=True");

        public void OpenCon()
        {
            sqlConnection.Open();
        }

        public void CloseCon()
        {
            sqlConnection.Close();
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;

        }
    }
}
