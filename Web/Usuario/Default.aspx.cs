using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Usuario
{
    public partial class Default : System.Web.UI.Page
    {
        #region propriedades
        string cnn = Properties.Settings.Default.conexao;
        DCBancoDataContext bco;
        #endregion

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    criarBanco();
                    listarUsuarios();
                }
            }
            catch (Exception ex)
            {
                this.litErro.Text ="<span class='btn btn-danger col-md-4'>" + ex.Message + "</span>";

            }
        }
        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = gv.SelectedRow.Cells[1].Text;
                Response.Redirect("Alterar?id=" + id);
            }
            catch (Exception ex)
            {
                this.litErro.Text = "<span class='btn btn-danger col-md-4'>" + ex.Message + "</span>";

            }
        }
        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = e.Values[0].ToString();
                Response.Redirect("Excluir?id=" + id);
            }
            catch (Exception ex)
            {
                this.litErro.Text = "<span class='btn btn-danger col-md-4'>" + ex.Message + "</span>";

            }
        }
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.litErro.Text = "<span class='btn btn-danger col-md-4'>" + ex.Message + "</span>";

            }
        }
        #endregion

        #region métodos
        private void popularFormulario()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void listarUsuarios()
        {
            try
            {
                bco = new DCBancoDataContext(cnn);
                IQueryable<Persistencia.Usuario> objs1 = bco.Usuarios;
                this.gv.DataSource = from u in objs1
                                     orderby u.nome
                                     select new { Cod = u.id, Nome = u.nome, Email = u.email };
                this.gv.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        //TODO arrumar o local correto para criar o banco de dados
        private void criarBanco()
        {
            bco = new DCBancoDataContext(cnn);
            if (!bco.DatabaseExists())
            {
                bco.CreateDatabase();
            }
        }

    }
}