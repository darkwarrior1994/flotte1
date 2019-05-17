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
using System.Text.RegularExpressions;
namespace Flotte
{
    public partial class CreerContrat : System.Web.UI.Page
    {
        int ordre = 1;
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
      
        DataSet ds = new DataSet();////table de recuperation des lites des raisons sociales des clients 
        DataSet ds1 = new DataSet();//table de recuperation des numéros des agents responsables
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();// table de verification si un contrat existe ou pas
        string query;
      
        protected void Page_Load(object sender, EventArgs e)
        {
         if (Session["Role"] == ("Gestionnaire"))
                {

                }
                else
                {
                    Response.Redirect("Authentification.aspx", false);
                }
            if (!IsPostBack)
            {
                Choisir_Raison_Social_Client();
               
            }
            if (!IsPostBack)
            {
                Choisir_Agent_Responsable();
                
            }
        }
        private void Choisir_Raison_Social_Client()
        {
            query = "Select RaisonSocial,CodeClient from Client";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                raisonsocialclient.DataSource = ds;
                raisonsocialclient.DataTextField = "RaisonSocial";
                raisonsocialclient.DataValueField = "CodeClient";
                raisonsocialclient.DataBind();
                raisonsocialclient.Items.Insert(0, new ListItem(" Choisir un Client ", "0"));
                raisonsocialclient.SelectedIndex = 0;
            }
        }
       
        private void Choisir_Agent_Responsable()
        {
            query = "Select Code from Utilisateur where Role='Agent'";
            SqlDataAdapter da1 = new SqlDataAdapter(query, sqlCon);

            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                agentresponsable.DataSource = ds1;
                agentresponsable.DataTextField = "Code";
                agentresponsable.DataValueField = "Code";
                agentresponsable.DataBind();
                agentresponsable.Items.Insert(0, new ListItem(" Choisir un Agent ", "0"));
                agentresponsable.SelectedIndex = 0;
            }
        }


        protected void ajouter(object sender, EventArgs e)
        {
           
         
// Contarinte sur le champ Date d"effet debut
           

            
            if (dateeffetdebut.Text.ToString() == "")
            {
                Erreurdateeffetdebut.Text = "Le Champ est vide!!!";

            }
            else
                Erreurdateeffetdebut.Text = "";
// Contarinte sur le champ Date d'effet fin 

            if ((dateeffetfin.Text.ToString() == dateeffetdebut.Text.ToString()) & dateeffetfin.Text.ToString() != "")
            {
                Erreurdateffetfin.Text = "Donnée invalide!!!";

            }

            else if (dateeffetfin.Text.ToString() == "")
            {
                Erreurdateffetfin.Text = "Le Champ est vide!!!";

            }
            else
                Erreurdateffetfin.Text = "";
// Contarinte sur le champ Agent responsable
                    
            if (agentresponsable.SelectedItem.ToString().Trim() == "Choisir un Agent")
            {
                Erreuragentresponsable.Text = "Le Champ est vide!!!";

            }
            else
                Erreuragentresponsable.Text = "";
           

// Contarinte sur le champ Raison social du client

            if (raisonsocialclient.SelectedItem.ToString().Trim() == "Choisir un Client")
            {
                Erreurraisonsocialclient.Text = "Le Champ est vide!!!";

            }
            else
                Erreurraisonsocialclient.Text = "";
// Contarinte sur le champ Prime provisoir 
            Regex primeprovisoirrx = new Regex("^[1-9][0-9]+$");
            if (!primeprovisoirrx.IsMatch(primeprovisionnelle.Text) & (primeprovisionnelle.Text.ToString() != ""))
            {

                Erreurprimeprovisoir.Text = "Le Montant du Prime Saisi est Invalide!!!";

            }
            else if (primeprovisionnelle.Text.ToString() == "")
            {
                Erreurprimeprovisoir.Text = "Le Champ est vide!!!";

            }
            else
                Erreurprimeprovisoir.Text = "";
            if ((Erreurraisonsocialclient.Text.ToString() == "") & (Erreurdateeffetdebut.Text.ToString() == "") &  (Erreuragentresponsable.Text.ToString() == "") & (Erreurprimeprovisoir.Text.ToString() == ""))
            {

               
                    string code = "";
                    sqlCon.Open();
                    SqlCommand cmd2 = new SqlCommand("Select * from Client where RaisonSocial =@RaisonSocial ", sqlCon);
                    cmd2.Parameters.AddWithValue("@RaisonSocial", raisonsocialclient.SelectedItem.ToString().Trim());
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
                    sda1.Fill(dt1);


                    if (dt1.Rows.Count > 0)
                    {
                      
                         for (int i = 0; i < dt1.Rows.Count; i++)
                         {
                          code = dt1.Rows[i]["CodeClient"].ToString();
                         }
                    }

                   
                    SqlCommand cmd = new SqlCommand("INSERT INTO Contrat(RaisonSocialClient,Etat,Ordre,CodeClient,DateEffetDebut,DateEffetFin,AgentResponsable,PrimeProvisionnelle,Fait_Le,Fait_Par) VALUES (@RaisonSocialClient,@Etat,@Ordre,@CodeClient,@DateEffetDebut,@DateEffetFin,@AgentResponsable,@PrimeProvisionnelle,@Fait_Le,@Fait_Par)", sqlCon);
                        cmd.Parameters.AddWithValue("@Etat", "C");
                        cmd.Parameters.AddWithValue("@Ordre", ordre);
                        cmd.Parameters.AddWithValue("@RaisonSocialClient", raisonsocialclient.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@CodeClient", code);
                        cmd.Parameters.AddWithValue("@DateEffetDebut", dateeffetdebut.Text);
                        cmd.Parameters.AddWithValue("@DateEffetFin", dateeffetfin.Text);
                        cmd.Parameters.AddWithValue("@AgentResponsable", agentresponsable.Text);
                        cmd.Parameters.AddWithValue("@PrimeProvisionnelle", primeprovisionnelle.Text);
                        cmd.Parameters.AddWithValue("@Fait_Le", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Fait_Par", Session["LOGIN"]);
                SqlCommand cmd1 = new SqlCommand("Select * from Contrat where RaisonSocialClient=@RaisonSocialClient AND Ordre=@Ordre", sqlCon);
                cmd1.Parameters.AddWithValue("@RaisonSocialClient", raisonsocialclient.SelectedItem.ToString().Trim());
                cmd1.Parameters.AddWithValue("@Ordre", ordre);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {

              
                    SuccesAjout.Text = "";
                    ErreurAjout.Text = "Vous avez déja ajouter ce contrat!!!";
                }
                else
                    {
                        cmd.ExecuteNonQuery();
                        ErreurAjout.Text = "";
                    //SuccesAjout.Text = "Contrat créé avec succes!!!";
                    Response.Redirect("Contrats.aspx", false);
                }
                       
                                                                                    
               

            }
        }

        protected void Annuler(object sender, EventArgs e)
        {
           
           
            dateeffetdebut.Text = "";
            dateeffetfin.Text = "";
            primeprovisionnelle.Text = "";
            agentresponsable.SelectedItem.Text = "Choisir un Agent";
            raisonsocialclient.SelectedItem.Text = "Choisir un client";

        

            Erreuragentresponsable.Text = "";
            Erreurdateeffetdebut.Text = "";
            Erreurdateffetfin.Text = "";
            Erreurprimeprovisoir.Text = "";
            Erreurraisonsocialclient.Text = "";
          
            ErreurAjout.Text = "";
            SuccesAjout.Text = "";





        }
    }

   
    }
