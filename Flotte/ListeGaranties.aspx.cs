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
    public partial class ListeGaranties : System.Web.UI.Page
    {
        string connectionString = @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
        /*  if (Session["Role"] == ("Administrateur"))
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ParamGarantie", sqlCon);
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
                ListeGarantie.Rows[0].Cells[0].Text = "Aucune garantie disponible..!";
               ListeGarantie.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
    
        protected void ListeGarantie_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM ParamGarantie WHERE IdGarantie = @IdGarantie", sqlCon);

                    cmd.Parameters.AddWithValue("@IdGarantie", (ListeGarantie.DataKeys[e.RowIndex].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}