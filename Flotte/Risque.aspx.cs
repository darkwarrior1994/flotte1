using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Flotte
{
    public partial class MiseEnCirculation : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if (Session["Role"] == ("Agent"))
            {

            }
            else
            {
                Response.Redirect("Authentification.aspx", false);
            }*/
            if (!IsPostBack)
            {
                PopulateGridview();
            }

        }
        void PopulateGridview()
        {
           
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("select * from Risque ORDER BY Id DESC ", sqlCon);
          
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                ListeRisque.DataSource = dt;
                ListeRisque.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                ListeRisque.DataSource = dt;
                ListeRisque.DataBind();
                ListeRisque.Rows[0].Cells.Clear();
               ListeRisque.Rows[0].Cells.Add(new TableCell());
               ListeRisque.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
               ListeRisque.Rows[0].Cells[0].Text = "No Data Found ..!";
                ListeRisque.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void RemettreEnVigeur(object sender, EventArgs e)
        {

        }

        protected void Retirer(object sender, EventArgs e)
        {
            Response.Redirect("Retrait.aspx", false);
        }

        protected void Rechercher(object sender, EventArgs e)
        {

        }

        protected void Ajouter(object sender, EventArgs e)
        {
            Response.Redirect("MiseEnCirculation.aspx", false);
        }

        protected void Assure(object sender, EventArgs e)
        {
            Response.Redirect("Assurés.aspx", false);
        }

        protected void GarantiesCouvertes(object sender, EventArgs e)
        {
            Response.Redirect("GarantiesCouvertes.aspx", false);
        }
    }
}