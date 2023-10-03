using SistemaLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaLogin.DAL;
using System.Data;

namespace SistemaLogin.BLL
{
    public class loginBo
    {
        loginDao _obtendoUsurario = new loginDao();
        public login ObtendoUsuario(string username, string password) 
        {
            return _obtendoUsurario.ObtendoUsuario(username, password);
                }

        public DataTable ObtendoPerfil(string username)
        {
            return _obtendoUsurario.ObtendoPerfil(username);
        }
       

    }
}
