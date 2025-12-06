//using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Usuario
{
    public partial class Novo : System.Web.UI.Page
    {
        #region parâmetros
        string cnn = Properties.Settings.Default.conexao;
        #endregion
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

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
        private void salvar()
        {
            try
            {
                string email = this.txtEmail.Text.Trim();
                string login = this.txtLogin.Text.Trim();
                Negocio.UsuarioBO bo = new Negocio.UsuarioBO(cnn);
                var obj = bo.PorLogin(login);
                if (obj == null)
                {
                    obj = bo.PorEmail(email);
                    if (obj == null)
                    {
                        bo.inserir(this.txtNome.Text.Trim(),login,this.txtPassword.Text.Trim(),email, "",1);
                    }
                    else
                    {
                        throw new Exception("Um usuário com esse login/email já cadastrado no sistema.");
                    }
                }
                else
                {
                    throw new Exception("Um usuário com esse login/email já cadastrado no sistema.");
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