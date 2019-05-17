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
    public partial class MiseEnCirculation1 : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
     
        DataSet ds = new DataSet();////table de recuperation des lites des raisons sociales des clients 
      
        DataSet ds1 = new DataSet();//table de recuperation des numéros des agents responsables
       
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt = new DataTable();// table de verification si un contrat existe ou pas
       
      
        string query;

        string imageLocation = "";
      

        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session["Role"]=="Agent" )
                    {

                    }
                    else
                    {
                        Response.Redirect("Authentification.aspx", false);
                    }
            if (!IsPostBack)
            {
                Choisir_CIN_Assuré();

            }
            if (!IsPostBack)
            {
                Choisir_Usage();

            }
          if (!IsPostBack)
            {

                Choisir_numéro_police();
            }
          
        }
        private void Choisir_CIN_Assuré()
        {
            query = "Select CIN  from Assure";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cinassure.DataSource = ds;
                cinassure.DataTextField = "CIN";
                cinassure.DataValueField = "CIN";
                cinassure.DataBind();
                cinassure.Items.Insert(0, new ListItem(" Choisir un Assuré ", "0"));
                cinassure.SelectedIndex = 0;
            }
        }
        private void Choisir_Usage()
        {
            query = "Select Id,LibelleUsage from ParamUsage ";
            SqlDataAdapter da1 = new SqlDataAdapter(query, sqlCon);

            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                usage.DataSource = ds1;
                usage.DataTextField = "LibelleUsage";
                usage.DataValueField = "Id";
                usage.DataBind();
                usage.Items.Insert(0, new ListItem(" Choisir un Usage ", "0"));
                usage.SelectedIndex = 0;
            }
        }
    
        private void Choisir_numéro_police()
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
        }
      
        protected void verifier(object sender, EventArgs e)
        {
 //Contraintesur le champ numéro du plaque d'immatriculation 

Regex numplaquerx = new Regex("^(1|2)?[0-9]?[0-9]TU[1-9]?[0-9]?[0-9]?[0-9]$");
           if (!numplaquerx.IsMatch(numplaque.Text) & (numplaque.Text.ToString() != ""))
             {

                ErreurNumPlaque.Text = "Données Invalide!!!";


            }
            else if (numplaque.Text.ToString() == "")
            {
                ErreurNumPlaque.Text = "Le Champ est vide!!!";
            }
            else
                ErreurNumPlaque.Text = "";
      
//Contrainte  sur le champ contrat associé
           
            if (contratassocié.SelectedItem.ToString().Trim() == "Choisir un numéro du police")
            {
                Erreurcontratasocie.Text = "Le Champ est vide!!!";

            }
            else
                Erreurcontratasocie.Text = "";
         
          
     
// Contarinte sur le champ CIN de l'assuré

         
            if (cinassure.SelectedItem.ToString().Trim() == "Choisir un Assuré")
            {
                ErreurCinassure.Text = "Le Champ est vide!!!";

            }
            else
                ErreurCinassure.Text = "";
// Contarinte sur le champ Usage


            if (usage.SelectedItem.ToString().Trim() == "Choisir un Usage")
            {
                Erreurusage.Text = "Le Champ est vide!!!";

            }
            else
                Erreurusage.Text = "";


            // Contarinte sur le champ date de validité debut

            if (datevaldebut.Text.ToString() == "")
            {
                Erreurdatevaldebut.Text = "Le Champ est vide!!!";

            }
            else
                Erreurdatevaldebut.Text = "";

// Contarinte sur le champ date de validité fin 
            if ((datevalfin.Text.ToString() == datevaldebut.Text.ToString()) & datevalfin.Text.ToString() != "")
            {
                Erreurdatevalfin.Text = "Donnée invalide!!!";

            }
            else if (datevalfin.Text.ToString() == "")
            {
                Erreurdatevalfin.Text = "Le Champ est vide!!!";
            }
            else
                Erreurdatevalfin.Text = "";
// Contarinte sur le champ Classe

            Regex classerx = new Regex("^[1-9][0-9]*$");
            if (!classerx.IsMatch(classe.Text) & (classe.Text.ToString() != ""))
            {

                Erreurclasse.Text = "Données Invalide!!!";

            }
            else if (classe.Text.ToString() == "")
            {
                Erreurclasse.Text = "Le Champ est vide!!!";

            }
            else
                Erreurclasse.Text = "";
// Contarinte sur le champ Nombre de place

            Regex nbplacerx = new Regex("^[1-9][0-9]*$");
            if (!nbplacerx.IsMatch(nbplace.Text) & (nbplace.Text.ToString() != ""))
            {

                Erreurnombreplace.Text = "Données Invalide!!!";

            }
            else if (nbplace.Text.ToString() == "")
            {
                Erreurnombreplace.Text = "Le Champ est vide!!!";

            }
            else
                Erreurnombreplace.Text = "";
// Contarinte sur le champ puissance fiscale 

            Regex puissancefiscalerx = new Regex("^[1-9][0-9]*$");
            if (!puissancefiscalerx.IsMatch(puissancefiscale.Text) & (puissancefiscale.Text.ToString() != ""))
            {

                Erreurpuissancefiscale.Text = "Données Invalide!!!";

            }
            else if (puissancefiscale.Text.ToString() == "")
            {
                Erreurpuissancefiscale.Text = "Le Champ est vide!!!";

            }
            else
                Erreurpuissancefiscale.Text = "";
// Contarinte sur le champ Valeur a neuf 

            Regex valeurneufrx = new Regex("^[1-9][0-9][0-9][0-9][0-9][0-9]*$");
            if (!valeurneufrx.IsMatch(valeurneuf.Text) & (valeurneuf.Text.ToString() != ""))
            {

                Erreurvaleurneuf.Text = "Données Invalide!!!";

            }
            else if (valeurneuf.Text.ToString() == "")
            {
                Erreurvaleurneuf.Text = "Le Champ est vide!!!";

            }
            else
                Erreurvaleurneuf.Text = "";
// Contarinte sur le champ valeur venale

            Regex valeurvenalerx = new Regex("^[1-9][0-9][0-9][0-9][0-9]*$");
            if (!valeurvenalerx.IsMatch(valeurvenale.Text) & (valeurvenale.Text.ToString() != ""))
            {

                Erreurvaleurvenale.Text = "Données Invalide!!!";

            }
            else if (valeurvenale.Text.ToString() == "")
            {
                Erreurvaleurvenale.Text = "Le Champ est vide!!!";

            }
            else
                Erreurvaleurvenale.Text = "";
// Contarinte sur le champ Poids vide

            Regex poidsviderx = new Regex("^[0-9][0-9]*$");
            if (!poidsviderx.IsMatch(poidsvide.Text) & (poidsvide.Text.ToString() != ""))
            {

                Erreurpoidsvide.Text = "Données Invalide!!!";

            }
            else if (poidsvide.Text.ToString() == "")
            {
                Erreurpoidsvide.Text = "Le Champ est vide!!!";

            }
            else
                Erreurpoidsvide.Text = "";
// Contarinte sur le champ poids totale

            Regex poidstotalrx = new Regex("^[0-9][0-9]*$");
            if (!poidstotalrx.IsMatch(poidstotal.Text) & (poidstotal.Text.ToString() != ""))
            {

                Erreurpoidstotal.Text = "Données Invalide!!!";

            }
            else if (poidstotal.Text.ToString() == "")
            {
                Erreurpoidstotal.Text = "Le Champ est vide!!!";

            }
            else
                Erreurpoidstotal.Text = "";
            if ((ErreurNumPlaque.Text.ToString() == "")  &  (Erreurcontratasocie.Text.ToString() == "") & (ErreurCinassure.Text.ToString() == "") & (Erreurdatevaldebut.Text.ToString() == "") & (Erreurdatevalfin.Text.ToString() == "") & (Erreurclasse.Text.ToString() == "")& (Erreurvaleurvenale.Text.ToString() == "") & (Erreurvaleurneuf.Text.ToString() == "") & (Erreurpuissancefiscale.Text.ToString() == "") & (Erreurpoidsvide.Text.ToString() == "") & (Erreurpoidstotal.Text.ToString() == "") &(Erreurnombreplace.Text.ToString() == "")  )
            {
               
                    sqlCon.Open();
                    string OrdreC = "";
                    string EtatC = "";
                   
                    SqlCommand cmd2 = new SqlCommand("Select Etat , Ordre from Contrat where NumPolice =@NumPolice ", sqlCon);
                    cmd2.Parameters.AddWithValue("@NumPolice", contratassocié.SelectedItem.ToString().Trim());
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
                    sda1.Fill(dt1);


                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            OrdreC = dt1.Rows[i]["Ordre"].ToString();
                            EtatC = dt1.Rows[i]["Etat"].ToString();
                        }
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO Risque(NumImmat,Etat,ContratAssocié,OrdreContrat,Intermediaire,IdAssuré,DateValiditéDebut,DateValiditéFin,Usage,Marque,Type,NumSerie,PuissanceFiscale,NbPlace,ValeurNeuf,ValeurVenale,PoidsVide,PoidsTotal,Classe,Fait_Le,Fait_Par) VALUES(@NumImmat,@Etat,@ContratAssocié,@OrdreContrat,@Intermediaire,@IdAssuré,@DateValiditéDebut,@DateValiditéFin,@Usage,@Marque,@Type,@NumSerie,@PuissanceFiscale,@NbPlace,@ValeurNeuf,@ValeurVenale,@PoidsVide,@PoidsTotal,@Classe,@Fait_le,@Fait_Par)", sqlCon);
                    cmd.Parameters.AddWithValue("@NumImmat", numplaque.Text);
                    cmd.Parameters.AddWithValue("@Etat", "C");
                    cmd.Parameters.AddWithValue("@ContratAssocié", contratassocié.SelectedItem.ToString());       
                    cmd.Parameters.AddWithValue("@OrdreContrat", OrdreC);
                    cmd.Parameters.AddWithValue("@Intermediaire", Convert.ToInt32(Session["ID"]));
                    cmd.Parameters.AddWithValue("@IdAssuré", cinassure.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DateValiditéDebut", datevaldebut.Text);
                    cmd.Parameters.AddWithValue("@DateValiditéFin", datevalfin.Text);
                    cmd.Parameters.AddWithValue("@Usage", usage.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Marque", marque.Text);
                    cmd.Parameters.AddWithValue("@NumSerie", numserie.Text);
                    cmd.Parameters.AddWithValue("@PuissanceFiscale", puissancefiscale.Text);
                    cmd.Parameters.AddWithValue("@NbPlace", nbplace.Text);
                    cmd.Parameters.AddWithValue("@Type", type.Text);
                    cmd.Parameters.AddWithValue("@ValeurNeuf", valeurneuf.Text);
                    cmd.Parameters.AddWithValue("@ValeurVenale", valeurvenale.Text);
                    cmd.Parameters.AddWithValue("@PoidsVide", poidsvide.Text);
                    cmd.Parameters.AddWithValue("@PoidsTotal", poidstotal.Text);
                    cmd.Parameters.AddWithValue("@Classe", classe.Text);
                    cmd.Parameters.AddWithValue("@Fait_le", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Fait_Par", Session["LOGIN"]);

                SqlCommand cmd4 = new SqlCommand("Select * from Contrat  where NumPolice=@NumPolice AND Etat=@Etat", sqlCon);
                cmd4.Parameters.AddWithValue("@NumPolice", contratassocié.SelectedItem.ToString());
                cmd4.Parameters.AddWithValue("@Etat", "B");
                SqlDataAdapter sda3 = new SqlDataAdapter(cmd4);
                sda3.Fill(dt2);


                if (dt2.Rows.Count > 0)
                {


                    SuccesAjout.Text = "";
                    ErreurAjout.Text = "Ce risque appartient a un contrat bloqué , vous ne pouvez pas ajouter un risque temporairement !!! ";
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("Select * from Risque where NumImmat=@NumImmat AND Etat=@Etat", sqlCon);
                    cmd1.Parameters.AddWithValue("@NumImmat", numplaque.Text.ToString().Trim());
                    cmd1.Parameters.AddWithValue("@Etat", "C");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {


                        SuccesAjout.Text = "";
                        ErreurAjout.Text = "Risque existant !!!";
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        ErreurAjout.Text = "";
                        // SuccesAjout.Text = "Risque créé avec succes!!!";
                        Response.Redirect("Risque.aspx", false);
                        SqlCommand cmd3 = new SqlCommand("insert into Historique(Operation) VALUES (@Operation)", sqlCon);
                        cmd3.Parameters.AddWithValue("@Operation", ("L'agent " + Session["ID"] + " a mis en circulation le Risque  " + numplaque.Text + " appartenant au contrat " + contratassocié.SelectedItem + " le " + DateTime.Now));
                        cmd3.ExecuteNonQuery();

                    }

                }
              



                    

            }
            
        }
              
        
      protected void ChoisirCarteGrise(object sender, EventArgs e)
        {
            {


                OpenFileDialog fd = new OpenFileDialog();

                fd.Filter = "JPG Files(*.jpg)|*.jbg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = fd.FileName.ToString();
                    cartegriseimage.ImageUrl = imageLocation;
                }






            }
        }

        protected void Annuler(object sender, EventArgs e)
        {
          
            numplaque.Text = "";
            contratassocié.SelectedItem.Text = "Choisir un numéro du police";
            cinassure.SelectedItem.Text = " Choisir un Assuré ";
            usage.SelectedItem.Text = "Choisir un usage";
            datevalfin.Text = "";
            datevalfin.Text = "";
            marque.Text = "";
            type.Text = "";
            classe.Text = "";
            numserie.Text = "";
            valeurneuf.Text = "";
            valeurvenale.Text = "";
            poidstotal.Text = "";
            poidsvide.Text = "";
            nbplace.Text = "";
            puissancefiscale.Text = "";


            ErreurAjout.Text = "";
            SuccesAjout.Text = "";
         
        }
    }

       
}
