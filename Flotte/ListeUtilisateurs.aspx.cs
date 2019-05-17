using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace Flotte
{
    public partial class ListeUtilisateurs : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
    

        string connectionString = @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)

        {
           if (Session["Role"] == ("Administrateur"))
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Utilisateur", sqlCon);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                ListeUtilisateur.DataSource = dt;
               ListeUtilisateur.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                ListeUtilisateur.DataSource = dt;
                ListeUtilisateur.DataBind();
                ListeUtilisateur.Rows[0].Cells.Clear();
                ListeUtilisateur.Rows[0].Cells.Add(new TableCell());
                ListeUtilisateur.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                ListeUtilisateur.Rows[0].Cells[0].Text = "No Data Found ..!";
                ListeUtilisateur.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
       
     /*   protected void ListeUtilisateur_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString)) 
                {
                   sqlCon.Open();
                    SqlCommand cmd = new SqlCommand ("DELETE FROM Utilisateur WHERE Login = @Login", sqlCon);

                    cmd.Parameters.AddWithValue("@Login", ListeUtilisateur.DataKeys[e.RowIndex].Value.ToString());
                    cmd.ExecuteNonQuery();
                    PopulateGridview();
                    Succes.Text = "Selected Record Deleted";
                  
                }
            }
            catch (Exception ex)
            {
              
               Erreur.Text = ex.Message;
            }
        }*/

      
        protected void ListeUtilisateur_RowUpdating(object sender, GridViewUpdateEventArgs  e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand cmd1 = new SqlCommand("Select* from Utilisateur where Etat='B'  AND Login = @Login", sqlCon);
                cmd1.Parameters.AddWithValue("@Login", ListeUtilisateur.DataKeys[e.RowIndex].Value.ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE Utilisateur SET Etat='A'  WHERE Login = @Login", sqlCon);
                    cmd2.Parameters.AddWithValue("@Login", ListeUtilisateur.DataKeys[e.RowIndex].Value.ToString());
                    cmd2.ExecuteNonQuery();
                    PopulateGridview();
                    Succes.Text = "Utlisateur Débloqué";
                    Erreur.Text = "";
                } else
                {
                    SqlCommand cmd3 = new SqlCommand("UPDATE Utilisateur SET Etat='Bloqué'  WHERE Login = @Login", sqlCon);
                    cmd3.Parameters.AddWithValue("@Login", ListeUtilisateur.DataKeys[e.RowIndex].Value.ToString());
                    cmd3.ExecuteNonQuery();
                    PopulateGridview();
                    Succes.Text = "Utlisateur Bloqué";
                    Erreur.Text = "";

                }
            }
        }
      
        }
}
    