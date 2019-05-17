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
    public partial class Attestation1 : System.Web.UI.Page
    {

        string connectionString = @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*   if (Session["Role"] == ("Agent"))
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

            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {



                sqlCon.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Attestation", sqlCon);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                ListeAttestation.DataSource = dt;
                ListeAttestation.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                ListeAttestation.DataSource = dt;
                ListeAttestation.DataBind();
                ListeAttestation.Rows[0].Cells.Clear();
                ListeAttestation.Rows[0].Cells.Add(new TableCell());
                ListeAttestation.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                ListeAttestation.Rows[0].Cells[0].Text = "Aucune atttestation disponible ..!";
                ListeAttestation.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
    }
}