using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Login
{
    public partial class Entrar : System.Web.UI.Page
    {
        #region parâmetros
        string url1 = "/Default";
        string cnn = Properties.Settings.Default.conexao;
        BancoDados bco;
        #endregion

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtLogin.Focus();
            }
            if (Request.QueryString["url"] != null)
            {
                url1 = Request.QueryString["url"];
            }
        }
        protected void ibtnEntrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                entrar(url1);
            }
            catch (Exception ex)
            {
                this.litErro.Text = "ERRO: " + ex.Message.ToString();
            }
        }
        #endregion
        #region métodos
        private void entrar(string url = "")
        {
            string login = "";
            string senha = "";
            try
            {
                //bco = new BancoDados(cnn);
                //bco.Criar();
                login = this.txtLogin.Text.ToUpper().Trim();
                senha = Crypto.EncryptarStrToBase64(this.txtPassword.Text.Trim(), "solucao");
                var bo = new UsuarioBO(cnn);
                var obj = bo.PorEmail(login);
                if (obj == null) { obj = bo.PorLogin(login); }
                if (obj == null) { throw new Exception("Usuário/Email com Senha não localizado"); }
                if (!obj.ativo) { throw new Exception("Usuário bloqueado para acessar o sistema."); }
                if (obj.senha == senha)
                {
                    Session.Add("usuarioLogado", obj.id);
                    Response.Redirect(url);

                }
                throw new Exception("Usuário/Email com Senha não localizado");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}