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
    public partial class AjouterUtilisateur : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if (Session["Role"] == "Administrateur")
            {

            }
            else
            {
                Response.Redirect("Authentification.aspx", false);
            }*/
            
        }

        protected void Ajouter(object sender, EventArgs e)
        {
            //contrainte sur le champ code
            Regex coderx = new Regex("^[1-9][0-9]{2}$");
            if (!coderx.IsMatch(code.Text) & (code.Text.ToString() != ""))
            {

                Erreurcode.Text = "Le Code  Saisi est Invalide!!!";

            }
            else if (code.Text.ToString() == "")
            {
                Erreurcode.Text = "Le Champ est vide!!!";

            }
            else
                Erreurcode.Text = "";
            // Contarinte sur le champ Nom 
            Regex nomrx = new Regex("^[a-zA-Z]+$");
            if (!nomrx.IsMatch(nom.Text) & (nom.Text.ToString() != ""))
            {

                Erreurnom.Text = "Le Nom Saisi est Invalide!!!";

            }
            else if (nom.Text.ToString() == "")
            {
                Erreurnom.Text = "Le Champ est vide!!!";

            }
            else
                Erreurnom.Text = "";
            // Contarinte sur le champ Prenom 
            Regex prenomrx = new Regex("^[a-zA-Z]+$");
            if (!prenomrx.IsMatch(prenom.Text) & (prenom.Text.ToString() != ""))
            {

                Erreurprenom.Text = "Le Prénom Saisi est Invalide!!!";

            }
            else if (prenom.Text.ToString() == "")
            {
                Erreurprenom.Text = "Le Champ est vide!!!";

            }
            else
                Erreurprenom.Text = "";
            // Contarinte sur le champ Telephone
            Regex telrx = new Regex("^(20|21|22|23|24|25|26|27|28|29|50|51|52|53|54|55|56|57|58|90|91|92|93|94|95|96|97|98|99)[0-9]{6}$");
            if (!telrx.IsMatch(tel.Text) & (tel.Text.ToString() != ""))
            {

                Erreurtel.Text = "Le Numéro du Telephone Saisi est Invalide!!!";

            }
            else if (tel.Text.ToString() == "")
            {
                Erreurtel.Text = "Le Champ est vide!!!";

            }
            else
                Erreurtel.Text = "";
            // Contarinte sur le champ login
            Regex loginrx = new Regex("^[a-zA-Z]+$");
            if (!loginrx.IsMatch(login.Text) & (login.Text.ToString() != ""))
            {

                Erreurlogin.Text = "Le Login Saisi est Invalide!!!";

            }
            else if (login.Text.ToString() == "")
            {
                Erreurlogin.Text = "Le Champ est vide!!!";

            }
            else
                Erreurlogin.Text = "";
            // Contarinte sur le champ mdp
            Regex mdprx = new Regex("^([a-z]|[A-Z]|[0-9]){8}$");
            if (!mdprx.IsMatch(mdp.Text) & (mdp.Text.ToString() != ""))
            {

                Erreurmdp.Text = "Le Mot de passe Saisi est Invalide!!!";

            }
            else if (mdp.Text.ToString() == "")
            {
                Erreurmdp.Text = "Le Champ est vide!!!";

            }
            else
                Erreurmdp.Text = "";
            // Contarinte sur le champ role
           if  (role.SelectedItem.ToString().Trim() == "Choisir un role")
            {
                Erreurrole.Text = "Le Champ est vide!!!";

            }
            else
                Erreurrole.Text = "";


            if ((Erreurcode.Text.ToString() == "")& (Erreurrole.Text.ToString() == "") & (Erreurnom.Text.ToString() == "") & (Erreurprenom.Text.ToString() == "") & (Erreurtel.Text.ToString() == "") & (Erreurlogin.Text.ToString() == "") & (Erreurmdp.Text.ToString() == ""))
            {

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Utilisateur(Code, Nom,Prenom, Login, MotDePasse, Telephone, Role,Etat) VALUES(@Code, @Nom, @Prenom, @Login, @MotDePasse, @Telephone, @Role,@Etat)", sqlCon);
                cmd.Parameters.AddWithValue("@Code", code.Text);
                cmd.Parameters.AddWithValue("@Nom", nom.Text);
                cmd.Parameters.AddWithValue("@Prenom", prenom.Text);
                cmd.Parameters.AddWithValue("@Login", login.Text);
                cmd.Parameters.AddWithValue("@MotDePasse", mdp.Text);
                cmd.Parameters.AddWithValue("@Telephone", tel.Text);
                cmd.Parameters.AddWithValue("@Role", role.Text);
                cmd.Parameters.AddWithValue("@Etat", "Actif");
                SqlCommand cmd1 = new SqlCommand("select * from Utilisateur where Login=@Login OR Telephone=@Telephone ", sqlCon);
                cmd1.Parameters.AddWithValue("@Login", login.Text);
                cmd1.Parameters.AddWithValue("@Telephone", tel.Text);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((dt.Rows[i]["Login"].ToString() == login.Text.ToString()) )
                        {
                            SuccesAjout.Text = "";
                            ErreurAjout.Text = "";
                            Erreurlogin.Text = "Login existant !!!";
                           

                        }
                         if ( (dt.Rows[i]["Telephone"].ToString() == tel.Text.ToString()))

                        {
                            ErreurAjout.Text = "";
                            SuccesAjout.Text = "";
                            Erreurtel.Text = "Numéro de telephone existant!!!";
                        }
                         if((dt.Rows[i]["Login"].ToString() == login.Text.ToString()) & (dt.Rows[i]["Telephone"].ToString() == tel.Text.ToString()) & (dt.Rows[i]["Nom"].ToString() == nom.Text.ToString()) & (dt.Rows[i]["Prenom"].ToString() == prenom.Text.ToString()) & (dt.Rows[i]["MotDePasse"].ToString() == mdp.Text.ToString()) & (dt.Rows[i]["Role"].ToString() == role.SelectedItem.ToString()))
                            {
                            Erreurtel.Text = "";
                            Erreurlogin.Text = "";
                            SuccesAjout.Text = "";
                            ErreurAjout.Text = "Utilisateur existant !!!";
                            }
                        
                    }
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    Erreurlogin.Text = "";
                    Erreurtel.Text = "";
                    SuccesAjout.Text = "Utilisateur ajouté avec succes ";
                }
                    }
                }
            
        
          
            
     protected void Annuler(object sender, EventArgs e)
        {
            Erreurrole.Text = "";
            Erreurlogin.Text = "";
            Erreurtel.Text = "";
            Erreurnom.Text = "";
            Erreurcode.Text = "";
            Erreurmdp.Text = "";
            Erreurprenom.Text = "";

            role.SelectedItem.Text = "Choisir un role";
             login.Text = "";
           tel.Text = "";
            nom.Text = "";
            code.Text = "";
            mdp.Text = "";
            prenom.Text = "";

            SuccesAjout.Text = "";
            ErreurAjout.Text = "";

        }

    }
}