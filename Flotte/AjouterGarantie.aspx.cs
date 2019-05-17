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
    public partial class AjouterGarantie : System.Web.UI.Page
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
//contrainte sur le champ Libelle  garantie

            Regex libellegarantierx = new Regex("^[a-zA-Z0-9]+$");
            if (!libellegarantierx.IsMatch(libellegarantie.Text) & (libellegarantie.Text.ToString() != ""))
            {

                Erreurlibellegarantie.Text = "Le Libelle  Saisi est Invalide!!!";

            }
            else if (libellegarantie.Text.ToString() == "")
            {
                Erreurlibellegarantie.Text = "Le Champ est vide!!!";

            }
            else
                Erreurlibellegarantie.Text = "";
// Contarinte sur le champ Id garantie 
            Regex idgarantierx = new Regex("^[A-Z]{3}$");
            if (!idgarantierx.IsMatch(idgarantie.Text) & (idgarantie.Text.ToString() != ""))
            {

                Erreuridgarantie.Text = "L'id Saisi est Invalide!!!";

            }
            else if (idgarantie.Text.ToString() == "")
            {
                Erreuridgarantie.Text = "Le Champ est vide!!!";

            }
            else
                Erreuridgarantie.Text = "";

            if ((Erreuridgarantie.Text.ToString() == "") & (Erreurlibellegarantie.Text.ToString() == ""))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ParamGarantie(LibelleGarantie, IdGarantie) VALUES(@LibelleGarantie, @IdGarantie)", sqlCon);
                cmd.Parameters.AddWithValue("@LibelleGarantie", libellegarantie.Text);
                cmd.Parameters.AddWithValue("@IdGarantie", idgarantie.Text);
              
                SqlCommand cmd1 = new SqlCommand("select * from ParamGarantie where LibelleGarantie=@LibelleGarantie OR IdGarantie=@IdGarantie ", sqlCon);
                cmd1.Parameters.AddWithValue("@LibelleGarantie", libellegarantie.Text);
                cmd1.Parameters.AddWithValue("@IdGarantie", idgarantie.Text);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((dt.Rows[i]["LibelleGarantie"].ToString() == libellegarantie.Text.ToString()))
                        {
                            SuccesAjout.Text = "";
                            ErreurAjout.Text = "";
                        Erreurlibellegarantie.Text = "Libelle usage existant !!!";


                        }
                        if ((dt.Rows[i]["IdGarantie"].ToString() == idgarantie.Text.ToString()))

                        {
                            ErreurAjout.Text = "";
                            SuccesAjout.Text = "";
                            Erreuridgarantie.Text = "Id usage existant!!!";
                        }
                        if ((dt.Rows[i]["LibelleGarantie"].ToString() == libellegarantie.Text.ToString()) & (dt.Rows[i]["IdGarantie"].ToString() == idgarantie.Text.ToString()) )
                        {
                            Erreurlibellegarantie.Text = "";
                            Erreuridgarantie.Text = "";
                            SuccesAjout.Text = "";
                            ErreurAjout.Text = "Usage existant !!!";
                        }

                    }
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    Erreuridgarantie.Text = "";
                    ErreurAjout.Text = "";
                    Erreurlibellegarantie.Text = "";
                    SuccesAjout.Text = "Usage ajouté avec succes ";
                }
            }
        }
    
       
        
            

        protected void Annuler(object sender, EventArgs e)
        {
            idgarantie.Text="";
            libellegarantie.Text = "";


            Erreuridgarantie.Text = "";
            Erreurlibellegarantie.Text = "";

            SuccesAjout.Text = "";
            ErreurAjout.Text = "";

        }
    }
}