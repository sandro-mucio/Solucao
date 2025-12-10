<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entrar.aspx.cs" Inherits="Web.Login.Entrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="row" style="text-align: right;">
    <h1>Entrar o Sistema</h1>
    <p class="lead text-danger" style="font-weight: bold;">
        <asp:Literal runat="server" ID="litErro" />
        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
    </p>
    <p>&nbsp;</p>
</section>
<div class="row">
    <section class="col-md-6" style="margin-left: 100px; border: 4px solid #0d6efd; border-radius: 30px;">
    <h2>&nbsp; Informar seus dados:</h2>
        <div class="col-md-12" style="text-align: left; padding-left: 20px; padding-bottom: 20px; padding-top: 40px; min-height: 150px;">
            <asp:Label runat="server" AssociatedControlID="txtLogin" CssClass="col-md-6 control-label">Email / Login:</asp:Label>
            <div class="col-md-12">
                <asp:TextBox runat="server" ID="txtLogin" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLogin"
                    CssClass="text-danger" ErrorMessage="O login é obrigatório." />
            </div>
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Senha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-12" style="padding: 10px 10px 10px 120px;">
            <asp:ImageButton ID="ibtnEntrar" CssClass="btn btn-primary btn-block botao_menor" ImageUrl="/Images/entrar.png" runat="server" AlternateText="Entrar" ToolTip="Entrar" OnClick="ibtnEntrar_Click" />
        </div>
    </section>
</div>
</asp:Content>
