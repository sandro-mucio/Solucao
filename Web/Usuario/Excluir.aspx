<%@ Page Title="Excluir Usuário" Language="C#" MasterPageFile="~/Logado.master" AutoEventWireup="true" CodeBehind="Excluir.aspx.cs" Inherits="Web.Usuario.Excluir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Logado2" runat="server">
    <section class="row">
        <p class="lead text-danger" style="font-weight: bold;">
            <asp:Literal runat="server" ID="litErro" />
            <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
        </p>
    </section>
    <h2>&nbsp; Confirma Exclusão Do Usuário ?</h2>
    <section class="col-md-8" style="margin-bottom: 20px; float: left; position: relative; margin-left: 20px; border: 4px solid #0d6efd; border-radius: 30px; min-height: 350px !important;">
        <div class="col-md-8" style="display: block; float: left; clear: right;">
            <div class="col-md-12" style="text-align: left; padding-left: 20px; padding-bottom: 20px; padding-top: 40px; min-height: 150px;">
                <h3><asp:Literal ID="litUsuario" runat="server"></asp:Literal></h3>
            </div>
        </div>
        <div style="clear: both;" />
        <div class="col-md-6 offset-2" style="text-align: center; padding: 10px;">
            <asp:ImageButton ID="ibtnExcluir" CssClass="btn btn-danger btn-block botao_menor" ImageUrl="/Images/excluir.png" runat="server" AlternateText="Confirmar Exclusão" ToolTip="Confirmar Exclusão" OnClick="ibtnExcluir_Click" />
        </div>
    </section>
    <div style="clear: both;" />
</asp:Content>
