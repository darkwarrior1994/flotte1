using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace Flotte
{
    public partial class Retrait : System.Web.UI.Page
    {
      

        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataTable dt3 = new DataTable();
        DataTable dt2 = new DataTable();
     


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == ("Agent"))
            {

            }
            else
            {
                Response.Redirect("Authentification.aspx", false);
            }
          /*  if (!IsPostBack)
            {

                Chosir_numéro_police();
            }*/
            if (!IsPostBack)
            {
                Choisir_numéro_plaque();
            

            }
        }
    /*    private void Chosir_numéro_police()
        {
            SqlCommand cmd2 = new SqlCommand("Select NumPolice from Contrat where AgentResponsable=@AgentResponsable", sqlCon);
            cmd2.Parameters.AddWithValue("@AgentResponsable", Convert.ToInt32(Session["ID"]));
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
            sda1.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                contratassocié.DataSource = ds2;
                contratassocié.DataTextField = "NumPolice";
                contratassocié.DataValueField = "NumPolice";
                contratassocié.DataBind();
                contratassocié.Items.Insert(0, new ListItem(" Choisir un numéro du police ", "0"));
                contratassocié.SelectedIndex = 0;
            }
        }*/
        private void Choisir_numéro_plaque()
        {
           
                SqlCommand cmd3 = new SqlCommand("Select NumImmat from Risque where Intermediaire=@Intermediaire AND Etat=@Etat", sqlCon);
                cmd3.Parameters.AddWithValue("@Intermediaire", Convert.ToInt32(Session["ID"]));
            cmd3.Parameters.AddWithValue("@Etat", "C");
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);
                sda2.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    numeroplaque.DataSource = ds;
                    numeroplaque.DataTextField = "NumImmat";
                    numeroplaque.DataValueField = "NumImmat";
                    numeroplaque.DataBind();
                   numeroplaque.Items.Insert(0, new ListItem(" Choisir un numéro de plaque d'immatriculation  ", "0"));
                   numeroplaque.SelectedIndex = 0;

                }
                else numeroplaque.Items.Insert(0, new ListItem(" Aucun rique disponible", "0"));





        }
       
       

        protected void valider(object sender, EventArgs e)
        {
            //Contraintesur le champ numéro du plaque d'immatriculation 

            if (numeroplaque.SelectedItem.ToString().Trim() == "Choisir un numéro de plaque d'immatriculation")
            {
                ErreurNumPlaque.Text = "Le Champ est vide!!!";
            }
            else
                ErreurNumPlaque.Text = "";

            //Contrainte  sur le champ contrat associé

          /*  if (contratassocié.SelectedItem.ToString().Trim() == "Choisir un numéro du police")
            {
                ErreurNumContrat.Text = "Le Champ est vide!!!";

            }
            else
                ErreurNumContrat.Text = "";*/


            if ( (ErreurNumPlaque.Text.ToString() == ""))

            {
                int numContrat = 0;
                sqlCon.Open();
                SqlCommand cmd5 = new SqlCommand("Select * from Risque   where NumImmat=@NumImmat ", sqlCon);
                cmd5.Parameters.AddWithValue("@NumImmat", numeroplaque.SelectedItem.ToString().Trim());
                SqlDataAdapter sda4 = new SqlDataAdapter(cmd5);
                sda4.Fill(dt3);


                if (dt3.Rows.Count > 0)
                {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        numContrat = Convert.ToInt32(dt3.Rows[i]["ContratAssocié"].ToString());
                    }
                }
                    SqlCommand cmd = new SqlCommand("UPDATE Risque SET Etat=@NEtat,DateValiditéFin=@DateValiditéFin,Fait_Le=@Fait_Le , Fait_Par=@Fait_Par WHERE NumImmat=@NumImmat AND Etat=@EtatA ", sqlCon);
                cmd.Parameters.AddWithValue("@DateValiditéFin", DateTime.Now);
                cmd.Parameters.AddWithValue("@NEtat", "R");
                cmd.Parameters.AddWithValue("@NumImmat", numeroplaque.SelectedItem.ToString().Trim());       
                cmd.Parameters.AddWithValue("@EtatA", "C");
                cmd.Parameters.AddWithValue("@Fait_Le", DateTime.Now);
                cmd.Parameters.AddWithValue("@Fait_Par", Session["LOGIN"]);

                SqlCommand cmd4 = new SqlCommand("Select * from Contrat  where NumPolice=@NumPolice AND Etat=@Etat", sqlCon);
                cmd4.Parameters.AddWithValue("@NumPolice", numContrat);
                cmd4.Parameters.AddWithValue("@Etat", "B");
                SqlDataAdapter sda3 = new SqlDataAdapter(cmd4);
                sda3.Fill(dt2);


                if (dt2.Rows.Count > 0)
                {


                    SuccesRetrait.Text = "";
                    ErreurRetrait.Text = "Ce risque appartient a un contrat bloqué , vous ne pouvez pas le retirer  !!! ";
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("Select * from Risque where NumImmat=@NumImmat   AND Etat=@Etat ", sqlCon);
                    cmd1.Parameters.AddWithValue("@NumImmat", numeroplaque.SelectedItem.ToString().Trim());
                    cmd1.Parameters.AddWithValue("@Etat", "R");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {


                        SuccesRetrait.Text = "";
                        ErreurRetrait.Text = "Risque  déja retiré !!!";
                    }
                    else
                    {
                       // SqlCommand cmd2 = new SqlCommand("Select * from Risque where NumImmat=@NumImmat   AND Etat=@Etat ", sqlCon);
                      //  cmd2.Parameters.AddWithValue("@NumImmat", numeroplaque.SelectedItem.ToString().Trim());
                      //  cmd2.Parameters.AddWithValue("@Etat", "C");
                      //  SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
                      //  sda1.Fill(dt1);
                       // for (int i = 0; i < dt1.Rows.Count; i++)
                       // {
                           // numContrat = Convert.ToInt32(dt1.Rows[i]["ContratAssocié"]);
                       // }
                        cmd.ExecuteNonQuery();
                        // SuccesRetrait.Text = "Risque  retiré avec succés";
                        ErreurRetrait.Text = "";
                        Response.Redirect("Risque.aspx", false);
                        SqlCommand cmd3 = new SqlCommand("insert into Historique(Operation) VALUES (@Operation)", sqlCon);
                        cmd3.Parameters.AddWithValue("@Operation", ("L'agent " + Session["ID"] + " a retiré le Risque  " + numeroplaque.SelectedItem + " appartenant au contrat " + numContrat + " le " + DateTime.Now));
                        cmd3.ExecuteNonQuery();
                    }

                }



              





            }
        }


        protected void Annuler(object sender, EventArgs e)
        {
            
            numeroplaque.SelectedItem.Text = "Choisir un numéro de plaque d'immatriculation";
            ErreurRetrait.Text = "";
            SuccesRetrait.Text = "";

        }

       
    }
}