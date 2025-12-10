<%@ Page Title="Configurações do Sistema" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Install.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Configurações do Sistema</h1>
            <p class="lead">
                <asp:Literal ID="litErro" runat="server"></asp:Literal>
            </p>
            <p>
                <asp:Button ID="btnCriarBco" runat="server" CssClass="btn btn-primary" Text="Criar Banco de Dados de Usuários" OnClick="btnCriarBco_Click" />
                <asp:Button ID="btnCriarAplicacao" runat="server" CssClass="btn btn-primary" Text="Criar Banco de Dados da Aplicação" OnClick="btnCriarAplicacao_Click" />
            </p>
        </section>

        <div class="row">
            <section class="col-md-12" aria-labelledby="gettingStartedTitle">
                
            </section>
        </div>
    </main>
</asp:Content>
