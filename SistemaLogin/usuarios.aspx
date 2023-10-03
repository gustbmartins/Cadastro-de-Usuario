<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="SistemaLogin.usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <link href="CSS/login_de_usuario.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg">
            <asp:Label ID="lblNome" runat="server"></asp:Label>
            <asp:LinkButton ID="lnkSair" runat="server" OnClick="lnkSair_Click">Sair</asp:LinkButton>
        </nav>
        <div class="bodyConsulta">
            <div>
                <h3 style="font-weight: 700">Consulta de Usuário</h3>
            </div>
            <div class="mainConsulta">
                <h5>Informe o CPF para busca:</h5>
                <div class="buscarCpf">
                    <asp:TextBox ID="textCpf" runat="server" MaxLength="11" TextMode="Phone"></asp:TextBox>
                    <asp:ImageButton ID="imgBuscarCpf" runat="server" ImageUrl="~/image/buscaruser.png" OnClick="ImageBusca_Click" />
                </div>
                <asp:Label ID="lblBuscaCpf" class="alert alert-danger" runat="server" Visible="false"></asp:Label>
            </div>
            <asp:Button ID="btnCadastrar" runat="server" class="btn btn-primary" Text="Cadastrar novo usuário" OnClick="btnCadastrar_Click" />
        </div>

        <div id="modalCadastro" visible="false" runat="server">
            <asp:RadioButtonList ID="radioBtn" runat="server" Visible="false">
                <asp:ListItem ID="radioVisitante" Value="V">Visitante</asp:ListItem>
                <asp:ListItem ID="radioAdministrador" Value="A">Administrador</asp:ListItem>
            </asp:RadioButtonList>
            
            <div id="modalBody">
                <asp:TextBox ID="TextNomeCadastro" runat="server" placeholder="Nome" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencher o campo nome" ValidationGroup="CadastrarUsuario" ControlToValidate="TextNomeCadastro" Display="None"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextCpfCadastro" runat="server" placeholder="CPF" TextMode="phone" MaxLength="11" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencher o campo CPF" ValidationGroup="CadastrarUsuario" ControlToValidate="TextCpfCadastro" Display="None"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextDataCadastro" runat="server" TextMode="Date" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Preencher o campo data" ValidationGroup="CadastrarUsuario" ControlToValidate="TextDataCadastro" Display="None"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextRuaCadastro" runat="server" placeholder="Rua" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencher o campo rua" ValidationGroup="CadastrarUsuario" ControlToValidate="TextRuaCadastro" Display="None"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextCidadeCadastro" runat="server" placeholder="Cidade" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Preencher o campo cidade" ValidationGroup="CadastrarUsuario" ControlToValidate="TextCidadeCadastro" Display="None"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextCepCadastro" runat="server" placeholder="CEP" TextMode="phone" MaxLength="8" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Preencher o campo CEP" ValidationGroup="CadastrarUsuario" ControlToValidate="TextCepCadastro" Display="None"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextLogin" runat="server" placeholder="Login" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Preencher o campo login" ValidationGroup="CadastrarUsuario" ControlToValidate="TextLogin" Display="None"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextSenha" runat="server" placeholder="Senha" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Preencher o campo senha" ValidationGroup="CadastrarUsuario" ControlToValidate="TextSenha" Display="None"></asp:RequiredFieldValidator>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" CssClass="alert alert-danger" ValidationGroup="CadastrarUsuario" Font-Size="Small"/>
            <div>
                <asp:Button ID="btnFechar" class="btn btn-secondary" runat="server" Text="Fechar" OnClick="btnFechar_Click" />
                <asp:Button ID="btnCadastrarUsuario" class="btn btn-primary" runat="server" Text="Finalizar Cadastro" OnClick="btnFinalizarCadastro_Click" ValidationGroup="CadastrarUsuario" />
            </div>
        </div>

        <asp:GridView ID="gridUsuarios" runat="server" AutoGenerateColumns="false" Visible="false">
            <Columns>
                <asp:BoundField DataField="nome" HeaderText="Nome" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="cpf" HeaderText="CPF" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="nascimento" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="rua" HeaderText="Rua" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="Cidade" HeaderText="Cidade" HeaderStyle-Width="200px" />
                <asp:TemplateField HeaderText="Excluir" Visible="false" HeaderStyle-Width="70px">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageExcluir" runat="server" ImageUrl="~/image/excluir.png" OnClick="ImageExcluir_Cadastro" />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
