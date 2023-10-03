using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.DAL
{
    public class montarGridDao
    {
        public DataTable MontaGridUser(string cpf)
        {
            try
            {
                conexao.Conectar();
                DataTable gridUser = new DataTable();

                string query = "SELECT * FROM LOGIN WHERE CPF = @CPF";                

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexao.sqlConnection))
                {
                   dataAdapter.SelectCommand.Parameters.AddWithValue("@CPF", cpf);
                   dataAdapter.Fill(gridUser);
                }
                return gridUser;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
