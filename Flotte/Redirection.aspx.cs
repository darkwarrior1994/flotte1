using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flotte
{
    public partial class Redirection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == "Gestionnaire")
            {
                Response.Redirect("Gestionnaire.aspx", false);
            }
            else if (Session["Role"] == "Agent")
            {
                Response.Redirect("Agent.aspx", false);
            }
            else
            {
                Response.Redirect("Administrateur.aspx", false);
            }


        }
    }
}