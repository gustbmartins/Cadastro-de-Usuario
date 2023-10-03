using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.DAL
{
    public class conexao
    {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SistemaLogin"].ConnectionString;
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static void Conectar()
        {
            
            if(sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
            sqlConnection.Open();
            }
        }

        public static void Desconectar()
        {
            
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        
        

    }
}
