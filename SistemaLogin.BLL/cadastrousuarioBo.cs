using SistemaLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SistemaLogin.DAL;

namespace SistemaLogin.BLL
{
    public class cadastrousuarioBo
    {
        cadastrousuarioDao _cadastrousuarioDao = new cadastrousuarioDao();
     
        public int cadastrarLoginUsuario(login _loginCadastro)
        {
           return _cadastrousuarioDao.cadastrarLoginUsuario(_loginCadastro);
        }

        public int ExcluirCadastroUsuario(string cpfDelete)
        {
            return _cadastrousuarioDao.ExcluirCadastroUsuario(cpfDelete);
        }
    }
}
