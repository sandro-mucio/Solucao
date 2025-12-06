using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Logado : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["usuarioLogado"] == null)
            {
                string url = HttpContext.Current.Request.Url.PathAndQuery;
                if (url.Contains("?url="))
                {
                    url = url.Split('?')[0];
                }
                Response.Redirect("/Login/Entrar?url=" + url);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}