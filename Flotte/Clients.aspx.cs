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
    public partial class Clients : System.Web.UI.Page
    {
        string connectionString = @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
         /*   if (Session["Role"] == "Gestionnaire")
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Client", sqlCon);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                ListeClient.DataSource = dt;
                ListeClient.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                ListeClient.DataSource = dt;
                ListeClient.DataBind();
                ListeClient.Rows[0].Cells.Clear();
                ListeClient.Rows[0].Cells.Add(new TableCell());
                ListeClient.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                ListeClient.Rows[0].Cells[0].Text = "No Data Found ..!";
                ListeClient.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }


       
    }
}