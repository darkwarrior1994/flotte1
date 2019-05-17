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
    public partial class AjouterAssuré : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");

       
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
          if (Session["Role"] == ("Agent"))
            {

            }
            else
            {
                Response.Redirect("Authentification.aspx", false);
            }
            if (!IsPostBack)
            {
                GetVille();
                gouvernorat.Items.Insert(0, " Aucune gouvernorat diponible ");
            }
        }
        private void GetVille()
        {
            query = "Select * from Ville";
            SqlDataAdapter da1 = new SqlDataAdapter(query, sqlCon);

            da1.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ville.DataSource = ds;
                ville.DataTextField = "NomVille";
                ville.DataValueField = "Id";
                ville.DataBind();
                ville.Items.Insert(0, new ListItem(" Choisir ville ", "0"));
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
        protected void Ajouter(object sender, EventArgs e)
        {   // Contarinte sur le champ CIN 
            Regex cinrx = new Regex("^[0-9]{8}$");
            if (!cinrx.IsMatch(cin.Text) & (cin.Text.ToString() != ""))
            {

                ErreurCin.Text = "Le Numéro de CIN Saisi est Invalide!!!";

            }
            else if (cin.Text.ToString() == "")
            {
                ErreurCin.Text = "Le Champ est vide!!!";

            }
            else
                ErreurCin.Text = "";
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
            if ((ErreurCin.Text.ToString() == "") & (Erreurnom.Text.ToString() == "") & (Erreurprenom.Text.ToString() == "") & (ErreurCin.Text.ToString() == "") & (Erreuradresse.Text.ToString() == "") & (Erreurtel.Text.ToString() == "") & (Erreurcodepostal.Text.ToString() == ""))
            {

               
                    SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Assure(CIN,Nom,Prenom,Adresse,Telephone,Ville,Gouvernorat,CodePostal,Fait_le,Fait_Par) VALUES(@CIN,@Nom,@Prenom,@Adresse,@Telephone,@Ville,@Gouvernorat,@CodePostal,@Fait_le,@Fait_Par)", sqlCon);
                    cmd.Parameters.AddWithValue("@CIN", cin.Text);
                    cmd.Parameters.AddWithValue("@Nom", nom.Text);
                    cmd.Parameters.AddWithValue("@Prenom", prenom.Text);
                    cmd.Parameters.AddWithValue("@Adresse", adresse.Text);
                    cmd.Parameters.AddWithValue("@Telephone", tel.Text);
                    cmd.Parameters.AddWithValue("@Ville", ville.SelectedItem.ToString().Trim());
                    cmd.Parameters.AddWithValue("@Gouvernorat", gouvernorat.SelectedItem.ToString().Trim());
                    cmd.Parameters.AddWithValue("@CodePostal", codepostal.Text);
                    cmd.Parameters.AddWithValue("@Fait_le", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Fait_Par", Session["LOGIN"]);
                SqlCommand cmd1 = new SqlCommand("Select * from Assure where CIN=@CIN ", sqlCon);
                    cmd1.Parameters.AddWithValue("@CIN", cin.Text.ToString().Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {

                    
                                SuccesAjout.Text = "";
                                ErreurAjout.Text = "Assuré existant!!!";
                          
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        ErreurAjout.Text = "";
                    // SuccesAjout.Text = "Assuré ajouté avec succes!!!";
                    Response.Redirect("Assurés.aspx", false);
                }




            
            }
        }

        protected void choisircin(object sender, EventArgs e)
        {

        }

        protected void Annuler(object sender, EventArgs e)
        {
            cin.Text = "";
            nom.Text = "";
            prenom.Text = "";
            adresse.Text = "";
            tel.Text = "";
            codepostal.Text = "";
            ErreurCin.Text = "";
            Erreurnom.Text = "";
            Erreurprenom.Text = "";
            Erreuradresse.Text = "";
            Erreurtel.Text = "";
            Erreurcodepostal.Text = "";

        }
    }
}