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
    public partial class AjouterClient : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");      
        SqlDataAdapter sda;
        DataTable dt = new DataTable();// table de verification si un client existe ou pas

        DataSet ds = new DataSet();
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
         /*   if (Session["Role"] == "Gestionnaire")
                       {

                       }
                       else
                       {
                           Response.Redirect("Authentification.aspx", false);
                       }*/
            if (!IsPostBack)
            {
                GetVille();
                gouvernorat.Items.Insert(0, "Choisir une gouvernorat");
            }
        }
        private void GetVille()
        {
            query = "Select * from Ville";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ville.DataSource = ds;
                ville.DataTextField = "NomVille";
                ville.DataValueField = "Id";
                ville.DataBind();
                ville.Items.Insert(0, new ListItem(" Choisir une ville ", "0"));
                ville.SelectedIndex = 0;
            }
        }
        protected void gouvernoratselectioné(object sender, EventArgs e)
        {
            ds.Clear();
            string get_countryname, NomVille;
            NomVille = ville.SelectedItem.Text;
            get_countryname = ville.SelectedValue.ToString();

            if (get_countryname != "0")
            {
                query = "Select IdG, NomDelegation from Gouvernorat where IdG='" + get_countryname.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gouvernorat.DataSource = ds;
                    gouvernorat.DataTextField = "NomDelegation";
                    gouvernorat.DataValueField = "IdG";
                    gouvernorat.DataBind();
                    gouvernorat.Items.Insert(0, new ListItem("Choisir une Gouvernorat " + NomVille.ToString(), "0"));
                    gouvernorat.SelectedIndex = 0;

                }


            }
        }

        protected void ajouter(object sender, EventArgs e)
        {

          
            // Contarinte sur le champ Raison Social
            Regex nomrx = new Regex("^[a-zA-Z]+$");
            if (!nomrx.IsMatch(raisonsocial.Text) & (raisonsocial.Text.ToString() != ""))
            {

                Erreurraisonsocial.Text = "Le Nom Saisi est Invalide!!!";

            }
            else if (raisonsocial.Text.ToString() == "")
            {
                Erreurraisonsocial.Text = "Le Champ est vide!!!";

            }
            else
                Erreurraisonsocial.Text = "";
            
            // Contarinte sur le champ Adresse
            Regex adresserx = new Regex("^[0-9]{1,3}(?:(?:[,.-/ ]){1}[-a-zA-Zàâäéèêëïîôöùûüç]+)*$");
           if (!adresserx.IsMatch(adresse.Text) & (adresse.Text.ToString() != ""))
           {

                Erreuradresse.Text = "L'adresse Saisi est Invalide!!!";

            }
            else if (adresse.Text.ToString() == "")
            {
                Erreuradresse.Text = "Le Champ est vide!!!";

            }
            else
              Erreuradresse.Text = "";
             //Contarinte sur le champ Telephone
            Regex telrx = new Regex("^(30|33|31|36|70|71|72|73|74|76|78)[0-9]{6}$");
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
            // Contarinte sur le champ fax
            Regex faxrx = new Regex("^(30|33|31|36|70|71|72|73|74|76|78)[0-9]{6}$");
            if (!faxrx.IsMatch(fax.Text) & (fax.Text.ToString() != ""))
            {

                Erreurfax.Text = "Le numéro du Fax Saisi est Invalide!!!";

            }
            else if (fax.Text.ToString() == "")
            {
                Erreurfax.Text = "Le Champ est vide!!!";

            }
            else
                Erreurfax.Text = "";
            // Contarinte sur le champ Code postal
            Regex codepostalrx = new Regex("^[1-9][0-9]{3}$");
            if (!codepostalrx.IsMatch(codepostal.Text) & (codepostal.Text.ToString() != ""))
            {

                Erreurcodepostal.Text = "Le Code Postal Saisi est Invalide!!!";

            }
            else if (codepostal.Text.ToString() == "")
            {
                Erreurcodepostal.Text = "Le Champ est vide!!!";

            }
            else
                Erreurcodepostal.Text = "";
            // Contarinte sur le champ ville
          
            
            if (ville.SelectedItem.ToString().Trim() == "Choisir une ville")
            {
                Erreurville.Text = "Le Champ est vide!!!";

            }
            else
                Erreurville.Text = "";
            // Contarinte sur le champ gouvernorat
          
             if (gouvernorat.SelectedItem.ToString().Trim() == "Choisir une gouvernorat")
            {
                Erreurgouvernorat.Text = "Le Champ est vide!!!";

            }
            else
                Erreurgouvernorat.Text = "";
            if ( (Erreurraisonsocial.Text.ToString() == "") & (Erreurfax.Text.ToString() == "")  & (Erreuradresse.Text.ToString() == "") & (Erreurtel.Text.ToString() == "") & (Erreurcodepostal.Text.ToString() == "") & (Erreurville.Text.ToString() == "") & (Erreurgouvernorat.Text.ToString() == ""))
            {
              
              
                 
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Client (RaisonSocial,Adresse,Telephone,Fax,Ville,Gouvernorat,CodePostal,Fait_Le,Fait_Par) VALUES(@RaisonSocial,@Adresse,@Telephone,@Fax,@Ville,@Gouvernorat,@CodePostal,@Fait_Le,@Fait_Par)", sqlCon);
                 
                    cmd.Parameters.AddWithValue("@RaisonSocial", raisonsocial.Text);
                    cmd.Parameters.AddWithValue("@fax", fax.Text);
                    cmd.Parameters.AddWithValue("@Adresse",adresse.Text);
                    cmd.Parameters.AddWithValue("@Telephone", tel.Text);
                    cmd.Parameters.AddWithValue("@Ville", ville.SelectedItem.ToString().Trim());
                    cmd.Parameters.AddWithValue("@Gouvernorat", gouvernorat.SelectedItem.ToString().Trim());
                    cmd.Parameters.AddWithValue("@CodePostal", codepostal.Text);
                    cmd.Parameters.AddWithValue("@Fait_le", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Fait_Par", Session["LOGIN"]);
                SqlCommand cmd1 = new SqlCommand("Select * from Client where RaisonSocial=@RaisonSocial ", sqlCon);
                cmd1.Parameters.AddWithValue("@RaisonSocial", raisonsocial.Text.ToString().Trim());                
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);


                if (dt.Rows.Count > 0)
                {


                    SuccesAjout.Text = "";
                    ErreurAjout.Text = "Vous avez déja ajouter ce client!!!";
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    ErreurAjout.Text = "";
                    //SuccesAjout.Text = "Client ajouté avec succes!!!";
                    Response.Redirect("Clients.aspx", false);
                }





            }
        }

        protected void annuler(object sender, EventArgs e)
        {
           
            raisonsocial.Text = "";
            tel.Text = "";
            fax.Text = "";
            codepostal.Text = "";
            gouvernorat.SelectedItem.Text = "Choisir une gouvernorat";
            ville.SelectedItem.Text = "Choisir une ville";
            adresse.Text = "";

            Erreurcodepostal.Text = "";
            Erreurfax.Text = "";
            Erreurgouvernorat.Text = "";
            Erreurraisonsocial.Text = "";
            Erreurville.Text = "";
            Erreurtel.Text = "";
            Erreuradresse.Text = "";

            ErreurAjout.Text = "";
            SuccesAjout.Text = "";
            



        }
    }
    }

   

   

