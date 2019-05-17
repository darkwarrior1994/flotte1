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
    public partial class Attestation : System.Web.UI.Page
    {
        SqlCommand cmd2 = new SqlCommand();
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
       
        DataTable dt1 = new DataTable();// table contient les attribut de la table Assure pour recuperer ses valeurs
        DataTable dt = new DataTable();// table contient les attribut de la table Risque pour recuperer ses valeurs
        DataSet ds = new DataSet();
        DataTable dt2 = new DataTable(); // table contient les attribut de la table attestaion pour verifier si l'attestation existe ou non
        DataTable dt3 = new DataTable();
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
                Choisir_numéro_plaque();


            }
        }
        private void Choisir_numéro_plaque()
        {

            SqlCommand cmd3 = new SqlCommand("Select NumImmat from Risque where Intermediaire=@Intermediaire AND Etat=@Etat", sqlCon);
            cmd3.Parameters.AddWithValue("@Intermediaire", Convert.ToInt32(Session["ID"]));
            cmd3.Parameters.AddWithValue("@Etat", "C");
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);
            sda2.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Numimmat.DataSource = ds;
                Numimmat.DataTextField = "NumImmat";
                Numimmat.DataValueField = "NumImmat";
                Numimmat.DataBind();
                Numimmat.Items.Insert(0, new ListItem(" Choisir un numéro de plaque d'immatriculation  ", "0"));
                Numimmat.SelectedIndex = 0;

            }
            else Numimmat.Items.Insert(0, new ListItem(" Aucun rique disponible", "0"));





        }


        protected void ajouter(object sender, EventArgs e)
        {
            if (Numimmat.SelectedItem.ToString().Trim() == "Choisir un numéro de plaque d'immatriculation")
            {
                Numimmat.Text = "Le Champ est vide!!!";
            }
            else
                Erreurnumimmat.Text = "";
            if ((Erreurnumimmat.Text.ToString() == ""))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Risque where NumImmat=@NumImmat  ", sqlCon);
                cmd.Parameters.AddWithValue("@NumImmat", Numimmat.SelectedItem.ToString().Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)

                {
                    SqlCommand cmd1 = new SqlCommand("Select * from Assure where CIN=@CIN  ", sqlCon);
                    cmd1.Parameters.AddWithValue("@CIN", dt.Rows[i]["IdAssuré"].ToString());
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    sda1.Fill(dt1);
                    for (int j = 0; j < dt1.Rows.Count; j++)

                    { // insertion d'une attestation dans la base
                        cmd2 = new SqlCommand("INSERT INTO Attestation (EntrepriseAssurance,NumContrat,Intermediaire,NumImmat,Usage,Marque,Type,NumSerie,PuissanceFiscale,DateValiditéDebut,DateValiditéFin,Classe,NomAssuré,PrenomAssuré,AdresseAssuré,FaitLe,TypeAttestation) values (@EntrepriseAssurance,@NumContrat,@Intermediaire,@NumImmat,@Usage,@Marque,@Type,@NumSerie,@PuissanceFiscale,@DateValiditéDebut,@DateValiditéFin,@Classe,@NomAssuré,@PrenomAssuré,@AdresseAssuré,@FaitLe,@TypeAttestation)", sqlCon);
                        cmd2.Parameters.AddWithValue("@EntrepriseAssurance", "ASTREE");
                        cmd2.Parameters.AddWithValue("@NumContrat", dt.Rows[i]["ContratAssocié"].ToString());
                        cmd2.Parameters.AddWithValue("@Intermediaire", Convert.ToInt32(Session["ID"]));
                        cmd2.Parameters.AddWithValue("@NumImmat", Numimmat.SelectedItem.ToString().Trim());
                        cmd2.Parameters.AddWithValue("@Usage", dt.Rows[i]["Usage"].ToString());
                        cmd2.Parameters.AddWithValue("@Marque", dt.Rows[i]["Marque"].ToString());
                        cmd2.Parameters.AddWithValue("@Type", dt.Rows[i]["Type"].ToString());
                        cmd2.Parameters.AddWithValue("@NumSerie", dt.Rows[i]["NumSerie"].ToString());
                        cmd2.Parameters.AddWithValue("@PuissanceFiscale", dt.Rows[i]["PuissanceFiscale"].ToString());
                        cmd2.Parameters.AddWithValue("@DateValiditéDebut", dt.Rows[i]["DateValiditéDebut"].ToString());
                        cmd2.Parameters.AddWithValue("@DateValiditéFin", dt.Rows[i]["DateValiditéFin"].ToString());
                        cmd2.Parameters.AddWithValue("@Classe", dt.Rows[i]["Classe"].ToString());
                        cmd2.Parameters.AddWithValue("@NomAssuré", dt1.Rows[j]["Nom"].ToString());
                        cmd2.Parameters.AddWithValue("@PrenomAssuré", dt1.Rows[j]["Prenom"].ToString());
                        cmd2.Parameters.AddWithValue("@AdresseAssuré", dt1.Rows[j]["Adresse"].ToString());
                        cmd2.Parameters.AddWithValue("@FaitLe", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@TypeAttestation", Typeattestation.SelectedItem.ToString().Trim());
                        // verification si l'attetation exite ou non
                        SqlCommand cmd3 = new SqlCommand("Select * from Attestation where NumImmat=@NumImmat AND TypeAttestation=@TypeAttestation", sqlCon);
                        cmd3.Parameters.AddWithValue("@NumImmat", Numimmat.SelectedItem.ToString().Trim());
                        cmd3.Parameters.AddWithValue("@TypeAttestation", Typeattestation.SelectedItem.ToString().Trim());
                        SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);
                        sda2.Fill(dt2);


                        if (dt2.Rows.Count > 0)
                        {
                            SuccesAjout.Text = "";
                            ErreurAjout.Text = "Attestation existante !!!";
                        }
                        else
                        {
                            if (Typeattestation.SelectedItem.ToString().Trim() == "Nouvelle")
                            {
                                cmd2.ExecuteNonQuery();
                                Response.Redirect("Attestation.aspx", false);
                            }
                            else if (Typeattestation.SelectedItem.ToString().Trim() == "Duplicata")
                            {   // Verifier si l'attestation de type nouvelle existe ou non 
                                SqlCommand cmd6 = new SqlCommand("Select * from Attestation where NumImmat=@NumImmat AND TypeAttestation=@TypeAttestation  ", sqlCon);
                                cmd6.Parameters.AddWithValue("@NumImmat", Numimmat.SelectedItem.ToString().Trim());
                                cmd6.Parameters.AddWithValue("@TypeAttestation", "Nouvelle");
                                SqlDataAdapter sda5 = new SqlDataAdapter(cmd6);
                                sda5.Fill(dt3);
                                if (dt3.Rows.Count > 0)
                                {   // chnagement du date validité fin de l'attestation de type 'Nouvelle'
                                    SqlCommand cmd4 = new SqlCommand("Update  Attestation set  DateValiditéFin=@DateValiditéFin where NumImmat=@NumImmat AND TypeAttestation='Nouvelle'", sqlCon);
                                    cmd4.Parameters.AddWithValue("@DateValiditéFin", DateTime.Today.ToShortDateString());
                                    cmd4.Parameters.AddWithValue("@NumImmat", Numimmat.SelectedItem.ToString().Trim());
                                    cmd4.ExecuteNonQuery();
                                    // ajout de l'attestation de type duplicata a la base de donnée
                                    SqlCommand cmd5 = new SqlCommand("INSERT INTO Attestation (EntrepriseAssurance,NumContrat,Intermediaire,NumImmat,Usage,Marque,Type,NumSerie,PuissanceFiscale,DateValiditéDebut,DateValiditéFin,Classe,NomAssuré,PrenomAssuré,AdresseAssuré,FaitLe,TypeAttestation) values (@EntrepriseAssurance,@NumContrat,@Intermediaire,@NumImmat,@Usage,@Marque,@Type,@NumSerie,@PuissanceFiscale,@DateValiditéDebut,@DateValiditéFin,@Classe,@NomAssuré,@PrenomAssuré,@AdresseAssuré,@FaitLe,@TypeAttestation)", sqlCon);
                                    cmd5.Parameters.AddWithValue("@EntrepriseAssurance", "ASTREE");
                                    cmd5.Parameters.AddWithValue("@NumContrat", dt.Rows[i]["ContratAssocié"].ToString());
                                    cmd5.Parameters.AddWithValue("@Intermediaire", Convert.ToInt32(Session["ID"]));
                                    cmd5.Parameters.AddWithValue("@NumImmat", Numimmat.SelectedItem.ToString().Trim());
                                    cmd5.Parameters.AddWithValue("@Usage", dt.Rows[i]["Usage"].ToString());
                                    cmd5.Parameters.AddWithValue("@Marque", dt.Rows[i]["Marque"].ToString());
                                    cmd5.Parameters.AddWithValue("@Type", dt.Rows[i]["Type"].ToString());
                                    cmd5.Parameters.AddWithValue("@NumSerie", dt.Rows[i]["NumSerie"].ToString());
                                    cmd5.Parameters.AddWithValue("@PuissanceFiscale", dt.Rows[i]["PuissanceFiscale"].ToString());
                                    cmd5.Parameters.AddWithValue("@DateValiditéDebut", DateTime.Today.ToShortDateString());
                                    cmd5.Parameters.AddWithValue("@DateValiditéFin", dt.Rows[i]["DateValiditéFin"].ToString());
                                    cmd5.Parameters.AddWithValue("@Classe", dt.Rows[i]["Classe"].ToString());
                                    cmd5.Parameters.AddWithValue("@NomAssuré", dt1.Rows[j]["Nom"].ToString());
                                    cmd5.Parameters.AddWithValue("@PrenomAssuré", dt1.Rows[j]["Prenom"].ToString());
                                    cmd5.Parameters.AddWithValue("@AdresseAssuré", dt1.Rows[j]["Adresse"].ToString());
                                    cmd5.Parameters.AddWithValue("@FaitLe", DateTime.Now);
                                    cmd5.Parameters.AddWithValue("@TypeAttestation", Typeattestation.SelectedItem.ToString().Trim());
                                    cmd5.ExecuteNonQuery();
                                    Response.Redirect("Attestation.aspx", false);
                                }else
                                {
                                    ErreurAjout.Text = "Attestation de type 'Nouvelle' inexistante !!!";
                                }
                              

                            }

                        }



                    }

                }
                
            }

        }

        protected void Annuler(object sender, EventArgs e)
        {

        }
    }
}