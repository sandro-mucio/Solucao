<%@ Page Title="Listagem de Usuários" Language="C#" MasterPageFile="~/Logado.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Usuario.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Logado2" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Cadastro de Usuários</h1>
            <p class="lead">
                <asp:Literal ID="litErro" runat="server"></asp:Literal>
            </p>
            <p>
                <asp:LinkButton ID="lbtnNovo" runat="server" CssClass="btn btn-primary" PostBackUrl="~/Usuario/Novo.aspx">Novo</asp:LinkButton>
            </p>
        </section>

        <div class="row">
            <section class="col-md-12" aria-labelledby="gettingStartedTitle">
                <asp:GridView ID="gv" runat="server" CssClass="table-primary col-md-12" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gv_SelectedIndexChanged" OnRowDataBound="gv_RowDataBound" OnRowDeleting="gv_RowDeleting">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" HeaderText=" &nbsp; Ações" SelectImageUrl="~/Images/editar1.png" SelectText="Alterar" ShowSelectButton="True" ShowDeleteButton="True" DeleteImageUrl="~/Images/excluir.png" DeleteText="Excluir" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </section>
        </div>
    </main>
</asp:Content>
