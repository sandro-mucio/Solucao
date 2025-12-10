using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Usuario
{
    public partial class Alterar : System.Web.UI.Page
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
                    catch (Exception){}
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

        protected void ibtnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                salvar();
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
                UsuarioBO bo = new UsuarioBO(cnn);
                var obj = bo.PorId(id);
                if (obj != null)
                {
                    this.lblID.Text = obj.id.ToString();
                    this.txtEmail.Text = obj.email;
                    this.txtLogin.Text = obj.login;
                    this.txtNome.Text = obj.nome;
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
        private void salvar()
        {
            try
            {
                string email = this.txtEmail.Text.Trim();
                string login = this.txtLogin.Text.Trim();
                UsuarioBO bo = new UsuarioBO(cnn);
                var obj = bo.PorId(int.Parse(this.lblID.Text.Trim()));
                if (obj != null)
                {
                    bo.alterar(obj.id,
                    this.txtNome.Text.Trim(),
                    login,
                    this.txtPassword.Text.Trim(),
                    email,
                    "",
                    true,
                    1);//todo: verificar o nível do usuário que está salvando essa alteração
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