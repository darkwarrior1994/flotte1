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
    public partial class Historique : System.Web.UI.Page
    {
        string connectionString= @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }
        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Historique ORDER BY Id DESC", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                HitoriqueAgents.DataSource = dtbl;
                HitoriqueAgents.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                HitoriqueAgents.DataSource = dtbl;
                HitoriqueAgents.DataBind();
                HitoriqueAgents.Rows[0].Cells.Clear();
                HitoriqueAgents.Rows[0].Cells.Add(new TableCell());
                HitoriqueAgents.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                HitoriqueAgents.Rows[0].Cells[0].Text = "Aucune opération n'a été effectuée ..!";
                HitoriqueAgents.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void HistoriqueAgents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Historique WHERE Id = @Id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(HitoriqueAgents.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Operation supprimée";
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