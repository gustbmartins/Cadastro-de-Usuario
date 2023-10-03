using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaLogin.Entities;

namespace SistemaLogin.DAL
{
    public class cadastrousuarioDao
    {
   
        public int cadastrarLoginUsuario(login _loginCadastro)
        {
            try
            {
                conexao.Conectar();
                string query = "INSERT INTO LOGIN([USER], SENHA, PERFIL, CPF, NOME, RUA, CIDADE, CEP, NASCIMENTO) VALUES (@USER, @SENHA, @PERFIL, @CPF, @NOME, @RUA, @CIDADE, @CEP, @NASCIMENTO)";
                using (SqlCommand cmd = new SqlCommand(query, conexao.sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@USER", _loginCadastro.user);
                    cmd.Parameters.AddWithValue("@SENHA", _loginCadastro.senha);
                    cmd.Parameters.AddWithValue("@PERFIL", _loginCadastro.perfil);
                    cmd.Parameters.AddWithValue("@CPF", _loginCadastro.cpf);
                    cmd.Parameters.AddWithValue("@NOME", _loginCadastro.nome);
                    cmd.Parameters.AddWithValue("@RUA", _loginCadastro.rua);
                    cmd.Parameters.AddWithValue("@CIDADE", _loginCadastro.cidade);
                    cmd.Parameters.AddWithValue("@CEP", _loginCadastro.cep);
                    cmd.Parameters.AddWithValue("@NASCIMENTO", _loginCadastro.nascimento);


                    int rowsAffected = cmd.ExecuteNonQuery() ;

                    return rowsAffected;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conexao.Desconectar(); }
        }

        public int ExcluirCadastroUsuario(string cpfDelete)
        {
            try
            {
                conexao.Conectar();
                string query = "DELETE FROM login WHERE CPF = @CPF";
                
                using (SqlCommand cmd = new SqlCommand(query, conexao.sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@CPF", cpfDelete);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conexao.Desconectar(); }
        }
    }
}
