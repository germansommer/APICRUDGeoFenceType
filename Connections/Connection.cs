using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudGFType.Connections
{
    public class Connection
    {
        private string ConnectionString = "data source =104.217.253.86; initial catalog = tracking; user id=alumno;password=12345678";
        public SqlConnection connection = new SqlConnection();

        public Connection()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        ~Connection()
        {
            connection.Close();
        }
    }
}
