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
    public partial class Contrats : System.Web.UI.Page
    {
        string connectionString = @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
        DataTable dt=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if (Session["Role"] == "Gestionnaire")
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Contrat ORDER BY NumPolice DESC", sqlCon);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                ListeContrat.DataSource = dt;
                ListeContrat.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                ListeContrat.DataSource = dt;
                ListeContrat.DataBind();
                ListeContrat.Rows[0].Cells.Clear();
                ListeContrat.Rows[0].Cells.Add(new TableCell());
                ListeContrat.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                ListeContrat.Rows[0].Cells[0].Text = "Aucun contrat disponible ..!";
                ListeContrat.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void ListeContrat_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand cmd1 = new SqlCommand("Select * from Contrat where Etat='B'  AND NumPolice = @NumPolice", sqlCon);
                cmd1.Parameters.AddWithValue("@NumPolice", ListeContrat.DataKeys[e.RowIndex].Value.ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE Contrat SET Etat='C'  WHERE NumPolice = @NumPolice", sqlCon);
                    cmd2.Parameters.AddWithValue("@NumPolice", Convert.ToInt32(ListeContrat.DataKeys[e.RowIndex].Value.ToString()));
                    cmd2.ExecuteNonQuery();
                    PopulateGridview();
                    Succes.Text = "Contart Débloqué";
                    Erreur.Text = "";
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("UPDATE Contrat SET Etat='B'  WHERE NumPolice = @NumPolice", sqlCon);
                    cmd3.Parameters.AddWithValue("@NumPolice", Convert.ToInt32(ListeContrat.DataKeys[e.RowIndex].Value.ToString()));
                    cmd3.ExecuteNonQuery();
                    PopulateGridview();
                    Succes.Text = "Contrat Bloqué";
                    Erreur.Text = "";

                }
            }
        }



    }
}