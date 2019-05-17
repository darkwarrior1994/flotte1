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
    public partial class AjouterUsage : System.Web.UI.Page
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
//contrainte sur le champ Libelle Usage
            Regex libelleusagerx = new Regex("^[a-zA-Z0-9]+$");
            if (!libelleusagerx.IsMatch(libelleusage.Text) & (libelleusage.Text.ToString() != ""))
            {

                Erreurlibelleusage.Text = "Le Libelle  Saisi est Invalide!!!";

            }
            else if (libelleusage.Text.ToString() == "")
            {
                Erreurlibelleusage.Text = "Le Champ est vide!!!";

            }
            else
                Erreurlibelleusage.Text = "";
            // Contarinte sur le champ Id Usage
          /*  Regex idusagerx = new Regex("^[A-Z]{3}$");
            if (!idusagerx.IsMatch(idusage.Text) & (idusage.Text.ToString() != ""))
            {

                Erreuridusage.Text = "L'id  Saisi est Invalide!!!";

            }
            else if (idusage.Text.ToString() == "")
            {
                Erreuridusage.Text = "Le Champ est vide!!!";

            }
            else
                Erreuridusage.Text = "";*/
            if ( (Erreurlibelleusage.Text.ToString() == ""))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ParamUsage(LibelleUsage) VALUES(@LibelleUsage)", sqlCon);
                cmd.Parameters.AddWithValue("@LibelleUsage", libelleusage.Text);
                //cmd.Parameters.AddWithValue("@IdUsage", idusage.Text);
                SqlCommand cmd1 = new SqlCommand("select * from ParamUsage where LibelleUsage=@LibelleUsage ", sqlCon);
                cmd1.Parameters.AddWithValue("@LibelleUsage", libelleusage.Text);
               // cmd1.Parameters.AddWithValue("@IdUsage", idusage.Text);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((dt.Rows[i]["LibelleUsage"].ToString() == libelleusage.Text.ToString()))
                        {
                            SuccesAjout.Text = "";
                            ErreurAjout.Text = "Usage existant !!!";


                        }
                      
                    
                    }
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    Erreurlibelleusage.Text = "";
                    //Erreuridusage.Text = "";
                    ErreurAjout.Text = "";
                    SuccesAjout.Text = "Usage ajouté avec succes ";
                }
            }
        }

        protected void Annuler(object sender, EventArgs e)
        {
           // Erreuridusage.Text = "";
            Erreurlibelleusage.Text = "";

            ErreurAjout.Text = "";
            SuccesAjout.Text = "";

           // idusage.Text = "";
            libelleusage.Text = "";
        }
    }
}