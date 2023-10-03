using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SistemaLogin.Entities;
using Dapper;


namespace SistemaLogin.DAL
{
    public class loginDao
    {

      
            public login ObtendoUsuario(string username, string password)

        {
           
            try
            {
                login usuario = null;
                conexao.Conectar();

                string query = "SELECT * FROM LOGIN WHERE [USER] = @USER AND SENHA = @SENHA";
                
                using (SqlCommand cmd = new SqlCommand(query, conexao.sqlConnection))
                {
                    cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = username; 
                    cmd.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = password;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new login();
                            usuario.user = reader["user"].ToString();
                            usuario.senha = reader["senha"].ToString();
                            usuario.perfil = reader["perfil"].ToString();
                        }
                    }



                    return usuario;


                }
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


        public DataTable ObtendoPerfil(string username)

        {
            try
            {
                
                DataTable dt = new DataTable();
                conexao.Conectar();

                string query = "SELECT * FROM LOGIN  WHERE [USER] = @USER";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexao.sqlConnection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@USER", username);
                    adapter.Fill(dt);


                }


                return dt;


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
