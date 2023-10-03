<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_de_usuario.aspx.cs" Inherits="SistemaLogin.login_de_usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
<link href="CSS/login_de_usuario.css" rel="stylesheet"/>

    <title>Cadastro de Cliente</title>
</head>

<body>
    <form id="form1" runat="server">
        
        <div class="formsLogin">
        <div >
            Login:
            <asp:TextBox ID="Textlogin" runat="server" Width="175px" ></asp:TextBox><br /><br />
            Senha:
            <asp:TextBox ID="Textsenha" runat="server" TextMode="Password" Width="175px"></asp:TextBox><br /><br /><br />
            <asp:Label class="alert alert-danger" ID="errorLogin" runat="server" Visible="false"></asp:Label>  
        </div>
            <div class="btnEntrar">
        <asp:Button class="btn btn-primary" runat="server" Text="Entrar" OnClick="btnLogin_Click" Width="150px" />
                </div>
            </div>
        
    </form>
</body>
</html>
