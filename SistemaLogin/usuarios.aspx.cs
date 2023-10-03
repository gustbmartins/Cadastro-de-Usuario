using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaLogin.BLL;
using SistemaLogin.Entities;

namespace SistemaLogin
{
    public partial class usuarios : System.Web.UI.Page
    {
        buscaCpfBo _buscaCpf = new buscaCpfBo();
        loginBo _login = new loginBo();       
        cadastrousuarioBo _cadastrousuario = new cadastrousuarioBo();
        
     
        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["parametro"] != null) { 
                string username = Session["parametro"].ToString();
                var perfilUser = _login.ObtendoPerfil(username);
                if (perfilUser.Rows.Count > 0)
                {
                    foreach (DataRow row in perfilUser.Rows)
                    {

                        lblNome.Text = row["nome"].ToString();

                        if (row["perfil"].ToString().Trim() == "A")
                        {
                           gridUsuarios.Columns[5].Visible = true;
                           radioBtn.Visible = true;
                        }
                    }


                }
            }
            else
            {
                Response.Redirect("login_de_usuario.aspx");
            }

          

        }

        protected void ImageBusca_Click(object sender, ImageClickEventArgs e)
        {
            string cpf = textCpf.Text;
            var cpfUser = _buscaCpf.MontaGridUser(cpf);
            string buscaDeCpf = textCpf.Text.ToString();

            if (buscaDeCpf.Length != 11)
            {
                
                lblBuscaCpf.Text = "CPF deve conter 11 algarismos.";
                lblBuscaCpf.Visible = true;
            }
            if (cpfUser.Rows.Count == 0)
            {
                
                lblBuscaCpf.Text = "Usuário não encontrado.";
                lblBuscaCpf.Visible = true;
            }
            if (cpfUser.Rows.Count > 0)
            {
                lblBuscaCpf.Visible = false;
                gridUsuarios.DataSource = _buscaCpf.MontaGridUser(cpf);
                gridUsuarios.DataBind();
                gridUsuarios.Visible = true;

            }
         
            
        }

        protected void btnFinalizarCadastro_Click(object sender, EventArgs e)
        {

            try
            {
                login _loginCadastro = new login()
                {
                    user = TextLogin.Text.ToString(),
                    senha = TextSenha.Text.ToString(),
                    cpf = TextCpfCadastro.Text.ToString(),
                    nome = TextNomeCadastro.Text.ToString(),
                    rua = TextRuaCadastro.Text.ToString(),
                    cidade = TextCidadeCadastro.Text.ToString(),
                    cep = TextCepCadastro.Text.ToString(),
                    nascimento = Convert.ToDateTime(TextDataCadastro.Text),
                    perfil = radioBtn.SelectedValue


                };

                if(string.IsNullOrEmpty(radioBtn.SelectedValue))
                {
                    _loginCadastro.perfil = "V";
                }
                
               var loginCadastrado = _cadastrousuario.cadastrarLoginUsuario(_loginCadastro);

                
                if(loginCadastrado > 0) 
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cadastro realizado com sucesso.')", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ocorreu um erro ao realizar o cadastro.')", true);


                TextCpfCadastro.Text = string.Empty;
                TextCepCadastro.Text = string.Empty;
                TextCidadeCadastro.Text = string.Empty;
                TextLogin.Text = string.Empty;
                TextNomeCadastro.Text = string.Empty;
                TextRuaCadastro.Text= string.Empty;
                TextSenha.Text = string.Empty;
                TextDataCadastro.Text = "aaa-mm-dd";
                radioVisitante.Selected = false;
                radioAdministrador.Selected = false;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            


         
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            lblBuscaCpf.Enabled = false;
            btnCadastrar.Enabled = false;
            imgBuscarCpf.Enabled = false;
            lblBuscaCpf.Visible = false;
            modalCadastro.Visible = true;
            textCpf.Enabled = false;
            textCpf.Text = string.Empty;
            gridUsuarios.Visible = false;

           
            
          
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            lblBuscaCpf.Enabled = true;
            btnCadastrar.Enabled = true;
            imgBuscarCpf.Enabled = true;
            modalCadastro.Visible = false;
            textCpf.Enabled = true;

            TextCpfCadastro.Text = string.Empty;
            TextCepCadastro.Text = string.Empty;
            TextCidadeCadastro.Text = string.Empty;
            TextLogin.Text = string.Empty;
            TextNomeCadastro.Text = string.Empty;
            TextRuaCadastro.Text = string.Empty;
            TextSenha.Text = string.Empty;
            TextDataCadastro.Text = "aaa-mm-dd";
            radioVisitante.Selected = false;
            radioAdministrador.Selected = false;

        }

        protected void ImageExcluir_Cadastro(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = gridUsuarios.Rows[0];
            string cpfDelete = row.Cells[1].Text;

            var usuarioDelete = _cadastrousuario.ExcluirCadastroUsuario(cpfDelete);
            if( usuarioDelete > 0)
            { 
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuário deletado.')", true);
                gridUsuarios.Visible = false;
                textCpf.Text = string.Empty;
            }
            else ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ocorreu um erro ao deletar o usuário.')", true);


        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Session["parametro"] = null;
            Response.Redirect("login_de_usuario.aspx");

        }
    }
}