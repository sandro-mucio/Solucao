using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Usuario
{
    public partial class Excluir : System.Web.UI.Page
    {
        #region parâmetros
        string cnn = Properties.Settings.Default.conexao;
        //DCBancoDataContext bco;
        #endregion
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string id = "";
                    try
                    {
                        id = Request.QueryString["id"];
                    }
                    catch (Exception) { }
                    if (!string.IsNullOrEmpty(id))
                    {
                        popularFormulario(int.Parse(id));
                    }
                    else
                    {
                        Response.Redirect("/usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                this.litErro.Text = "<span class='btn btn-danger col-md-4'>" + ex.Message + "</span>";
            }
        }

        protected void ibtnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                excluir();
                Response.Redirect("/Usuario");
            }
            catch (Exception ex)
            {
                this.litErro.Text = "<span class='btn btn-danger col-md-4'>" + ex.Message + "</span>";
            }
        }
        #endregion

        #region métodos
        private void popularFormulario(int id)
        {
            try
            {
                this.lblID.Text = id.ToString();
                UsuarioBO bo = new UsuarioBO(cnn);
                var obj = bo.PorId(id);
                if (obj != null)
                {
                    string t = "";
                    t += "ID: " + obj.id.ToString();
                    t += "<br/>Nome: " + obj.nome;
                    t += "<br/>Email: " + obj.email;
                    t += "<br/>Login: " + obj.login;
                    this.litUsuario.Text = t;
                }
                else
                {
                    throw new Exception("Usuário Não Localizado!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void excluir()
        {
            try
            {
                UsuarioBO bo = new UsuarioBO(cnn);
                Persistencia.Usuario obj = bo.PorId(int.Parse(this.lblID.Text.Trim()));
                if (obj != null)
                {
                    bo.excluir(obj.id);
                }
                else
                {
                    throw new Exception("Usuário não localizado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}