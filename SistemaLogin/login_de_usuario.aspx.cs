using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaLogin.BLL;
using SistemaLogin.Entities;

namespace SistemaLogin
{
    public partial class login_de_usuario : System.Web.UI.Page
    {
        loginBo _loginBo = new loginBo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = Textlogin.Text;
            string password = Textsenha.Text;

            if(_loginBo.ObtendoUsuario(username, password) != null)
            {

                Session["parametro"] = username;
                FormsAuthentication.RedirectFromLoginPage(username, false);
                
            }
            else
            {
                errorLogin.Text = "Usuário e/ou senha inválidos.";
                errorLogin.Visible = true;
                
            }

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errorLogin.Text = "Preencher usuário e senha.";
                errorLogin.Visible = true;
            }

        }
    }
}