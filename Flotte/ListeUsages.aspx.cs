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
    public partial class ListeUsages : System.Web.UI.Page
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ParamUsage", sqlCon);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                ListeUsage.DataSource = dt;
                ListeUsage.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                ListeUsage.DataSource = dt;
                ListeUsage.DataBind();
                ListeUsage.Rows[0].Cells.Clear();
                ListeUsage.Rows[0].Cells.Add(new TableCell());
                ListeUsage.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                ListeUsage.Rows[0].Cells[0].Text = "Aucun usage disponible..!";
                ListeUsage.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
          
        protected void ListeUsage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM ParamUsage WHERE IdUsage= @LibelleUsage", sqlCon);

                    cmd.Parameters.AddWithValue("@LibelleUsage", (ListeUsage.DataKeys[e.RowIndex].Value.ToString()));
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