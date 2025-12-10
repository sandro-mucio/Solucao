using Negocio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Install
{
    public partial class Default : System.Web.UI.Page
    {
        #region propriedades
        string cnn = Properties.Settings.Default.conexao;
        BancoDados bco;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCriarBco_Click(object sender, EventArgs e)
        {
            try
            {
                bco = new BancoDados(cnn);
                bco.Criar();
                throw new Exception("Banco de Dados Criado com Sucesso. <a href='/'>Início</a>");
            }
            catch (Exception ex)
            {
                this.litErro.Text = ex.Message;
            }
        }
    }
}