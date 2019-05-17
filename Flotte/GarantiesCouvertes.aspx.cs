using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace Flotte
{
    public partial class GarantiesCouvertes : System.Web.UI.Page
    {
        string connectionString = @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
       

        protected void Page_Load(object sender, EventArgs e)
        {
         if (Session["Role"] == ("Agent"))
            {

            }
            else
            {
                Response.Redirect("Authentification.aspx", false);
            }
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Garantie", sqlCon);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                ListeGarantie.DataSource = dt;
                ListeGarantie.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                ListeGarantie.DataSource = dt;
                ListeGarantie.DataBind();
                ListeGarantie.Rows[0].Cells.Clear();
                ListeGarantie.Rows[0].Cells.Add(new TableCell());
                ListeGarantie.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                ListeGarantie.Rows[0].Cells[0].Text = "No Data Found ..!";
                ListeGarantie.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void Affecter(object sender, EventArgs e)
        {
            Response.Redirect("AffecterGarantie.aspx", false);
        }
    }
}