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
    public partial class ModificationMotDePasse : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {

            }
            else
            {
                Response.Redirect("Authentification.aspx", false);
            }
        }

        protected void valider(object sender, EventArgs e)
        {
            // Contarinte sur le champ nouveau mot de passe

            Regex nouveaumdprx = new Regex("^([a-z]|[A-Z]|[0-9]){8}$");
            if (!nouveaumdprx.IsMatch(nouveaumdp.Text) & (nouveaumdp.Text.ToString() != ""))
            {

                Erreurnouveaumdp.Text = "Données Invalide!!!";

            }
            else if (nouveaumdp.Text.ToString() == "")
            {
                Erreurnouveaumdp.Text = "Le Champ est vide!!!";

            }
            else
                Erreurnouveaumdp.Text = "";
            // Contarinte sur le champ ancien mot de passe
            if (ancienmdp.Text.ToString() == "")
            {
                Erreurancienmdp.Text = "Le Champ est vide!!!";

            }
            else
                Erreurancienmdp.Text = "";
            // Contarinte sur le champ verification de  mot de passe
            if (verificationnouveaumdp.Text.ToString() == "")
            {
                Erreurvnmdp.Text = "Le Champ est vide!!!";

            }
            else
                Erreurvnmdp.Text = "";






            if ((Erreurnouveaumdp.Text.ToString() == "")& (Erreurancienmdp.Text.ToString() == "")& (Erreurvnmdp.Text.ToString() == ""))
            {


                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Utilisateur SET MotDePasse=@NMdp WHERE    Login=@Login AND MotDePasse=@Mdp AND  @VNMdp=@NMdp  ", sqlCon);

                cmd.Parameters.AddWithValue("@NMdp", nouveaumdp.Text);
                cmd.Parameters.AddWithValue("@Login", (string)(Session["LOGIN"]));
                cmd.Parameters.AddWithValue("@Mdp", ancienmdp.Text);
                cmd.Parameters.AddWithValue("@VNMdp", verificationnouveaumdp.Text);

                SqlCommand cmd1 = new SqlCommand("select * from Utilisateur where Login=@Login ", sqlCon);
                cmd1.Parameters.AddWithValue("@Login", (string)(Session["LOGIN"]));
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
               

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((ancienmdp.Text.ToString() == dt.Rows[i]["MotDePasse"].ToString()) & (verificationnouveaumdp.Text.ToString() == nouveaumdp.Text.ToString()))
                        {
                            Erreurancienmdp.Text = "";
                            Erreurvnmdp.Text = "";
                            cmd.ExecuteNonQuery();
                            Succes.Text = "Mot de passe modifié avec succes ";
                        }
                        if ((ancienmdp.Text.ToString() != dt.Rows[i]["MotDePasse"].ToString()))
                        {
                            Erreurancienmdp.Text = "Mot de passe incorrect !!!";
                        }
                        if ( (verificationnouveaumdp.Text.ToString() != nouveaumdp.Text.ToString()))
                        {
                            Erreurvnmdp.Text = "Mot de passe de confirmation incorrect";

                        }
                      
                    }

                }
            }

        

        protected void Annuler(object sender, EventArgs e)
        {
            ancienmdp.Text = "";
            nouveaumdp.Text = "";
            verificationnouveaumdp.Text = "";
            Erreurnouveaumdp.Text= "";
            Erreurancienmdp.Text = "";
            Erreurvnmdp.Text = "";
            Erreur.Text = "";
            Succes.Text = "";
         

        }
    }
}

