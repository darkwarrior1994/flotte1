using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flotte
{
    public partial class Deconnexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Id"] = null;
            Session["LOGIN"] = null;
            Session["MDP"] = null;
            Session["ROLE"] = null;
            Response.Redirect("Authentification.aspx",false);
        }
    }
}