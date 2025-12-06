<%@ Page Title="Novo Usuário" Language="C#" MasterPageFile="~/Logado.master" AutoEventWireup="true" CodeBehind="Novo.aspx.cs" Inherits="Web.Usuario.Novo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Logado2" runat="server">
    <section class="row">
        <p class="lead text-danger" style="font-weight: bold;">
            <asp:Literal runat="server" ID="litErro" />
            <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
        </p>
    </section>
    <h2>&nbsp; Novo Usuário</h2>
    <section class="col-md-8" style="margin-bottom: 20px; float: left; position: relative; margin-left: 20px; border: 4px solid #0d6efd; border-radius: 30px; min-height:350px !important;">
        <div class="col-md-6" style="display: block; float: left; clear: right;">
            <div class="col-md-12" style="text-align: left; padding-left: 20px; padding-bottom: 20px; padding-top: 40px; min-height: 150px;">
                <asp:Label runat="server" AssociatedControlID="txtNome" CssClass="col-md-2 control-label">Nome:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNome"
                        CssClass="text-danger" ErrorMessage="O nome é obrigatório." />
                </div>
                <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                        CssClass="text-danger" ErrorMessage="O email é obrigatório." />
                </div>
            </div>
        </div>
        <div class="col-md-6" style="display: block; float: left; clear: right;">
            <div class="col-md-12" style="text-align: left; padding-left: 20px; padding-bottom: 20px; padding-top: 40px; min-height: 200px;">
                <asp:Label runat="server" AssociatedControlID="txtLogin" CssClass="col-md-2 control-label">Login:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtLogin" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLogin"
                        CssClass="text-danger" ErrorMessage="O login é obrigatório." />
                </div>
                <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Senha</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="col-md-8 form-control" />
                </div>
            </div>
        </div>
        <div class="col-md-4 offset-2" style="text-align: center; padding: 10px;">
            <asp:ImageButton ID="ibtnSalvar" CssClass="btn btn-primary btn-block botao_menor" ImageUrl="/Images/salvar1.png" runat="server" AlternateText="Salvar" ToolTip="Salvar" OnClick="ibtnSalvar_Click" />
        </div>
    </section>
    <div style="clear:both;" />
</asp:Content>
