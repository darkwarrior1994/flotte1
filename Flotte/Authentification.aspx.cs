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
using System.Text.RegularExpressions;

namespace Flotte
{
    public partial class Authentification : System.Web.UI.Page
    {
       
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
        DataTable dt = new DataTable();
        /*  public string EncryptPassword(string mdp)
          {
              //Crypter le mot de passe         
              byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(this.mdp.Text);
              string encryptPass = Convert.ToBase64String(passBytes);
              return encryptPass;
          }*/
        protected void Page_Load(object sender, EventArgs e)
        {
           
           Session["Id"] = null;
           Session["LOGIN"] = null;
            Session["MDP"] = null;
            Session["ROLE"] = null;
        }
        protected void Verifier(object sender, EventArgs e)
        {
           
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("select * from Utilisateur ", sqlCon);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)

                {
                    if ((dt.Rows[i]["Login"].ToString() == Login.Text) & (dt.Rows[i]["MotDePasse"].ToString() == mdp.Text) & (dt.Rows[i]["Etat"].ToString() == "B"))
                    {
                        Erreur.Text = "Vous êtes bloqué ,vous n'avez pas le droit de se connecter temporairement !!!";
                    }

                     else  if ((dt.Rows[i]["Login"].ToString() == Login.Text) & (dt.Rows[i]["MotDePasse"].ToString() == mdp.Text) & (dt.Rows[i]["Etat"].ToString() == "A"))
                    {

                        Session["Id"] = dt.Rows[i]["Code"];
                        Session["LOGIN"] = Login.Text;
                        Session["MDP"] = mdp.Text;


                        if ((dt.Rows[i]["Role"].ToString() == "Agent"))
                        {
                            Session["ROLE"] = "Agent";
                            Response.Redirect("Agent.aspx", false);
                        }
                         if ((dt.Rows[i]["Role"].ToString() == "Gestionnaire"))
                        {
                            Session["ROLE"] = "Gestionnaire";
                            Response.Redirect("Gestionnaire.aspx", false);
                        }

                        if ((dt.Rows[i]["Role"].ToString() == "Administrateur"))
                        {
                            Session["ROLE"] = "Administrateur";
                            Response.Redirect("Administrateur.aspx", false);
                        }
                    }

                  else  if ((dt.Rows[i]["Login"].ToString() == Login.Text) | (dt.Rows[i]["MotDePasse"].ToString() == mdp.Text))
                     { Erreur.Text = "Vérifier les données saisi !!!";
                     }
                       



                }
                
            }
        }

        protected void Annuler(object sender, EventArgs e)
        {
            Login.Text = "";
            mdp.Text = "";
            Erreur.Text = "";


        }

       
    }
}
