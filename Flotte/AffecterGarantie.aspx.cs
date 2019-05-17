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

namespace Flotte
{
    public partial class AffecterGarantie : System.Web.UI.Page
    {
        string connectionString = @"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True";
        float primeRC = 0;
        float primeINCENDIE = 0;
        float primeVOL = 0;
        float primeCAS = 0;
        float primeTIERCESF = 0;
        float primeTIERCEAF = 0;
        float primeTOTALE = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           /*  if (Session["Role"] == "Agent")
           {

           }
           else
           {
               Response.Redirect("Authentification.aspx", false);
           }*/
        }
        protected void Calculer(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-7MGA5NT\SQLEXPRESS; Initial Catalog = Flotte; Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Risque where NumImmat=@NumImmat AND ContratAssocie=@ContratAssocie AND Etat=@Etat AND Ordre=@Ordre AND EtatContrat=@EtatContrat AND OrdreContrat=@OrdreContrat AND Intermediaire=@Intermediaire ", con);
            cmd.Parameters.AddWithValue("@NumImmat", numplaque.Text);
            cmd.Parameters.AddWithValue("@ContratAssocie", numcontrat.Text);
            cmd.Parameters.AddWithValue("@Etat", etatr.Text);
            cmd.Parameters.AddWithValue("@Ordre", ordrer.Text);
            cmd.Parameters.AddWithValue("@EtatContrat", etatc.Text);
            cmd.Parameters.AddWithValue("@OrdreContrat", ordrec.Text);
            cmd.Parameters.AddWithValue("@Intermediaire", intermediaire.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((dt.Rows[i]["Usage"].ToString() == "AFFAIRE"))
                    {
                        if (RC.Text.ToString() == "RC")
                        {
                            if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "2"))
                            {
                                primeRC = 94000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "3") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "4"))
                            {
                                primeRC = 110000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "5") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "6"))
                            {
                                primeRC = 140000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "7") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "8") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "9") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "10"))
                            {
                                primeRC = 170000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "11") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "12") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "13") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "14"))
                            {
                                primeRC = 222000;
                            }
                            else
                            {
                                primeRC = 264000;
                            }
                        }
                        if (INCENDIE.Text.ToString() == "INCENDIE")
                        {

                        }
                        if (VOL.Text.ToString() == "VOL")
                        {

                        }
                        if (CAS.Text.ToString() == "CAS")
                        {
                            primeCAS = 30000;
                        }
                        if (TIERCESANSFRANCHISE.Text.ToString() == "TIERCE SANS FRANCHISE")
                        {

                        }
                        if (TIERCEAVECFRANCHISE.Text.ToString() == "TIERCE AVEC FRANCHISE")
                        {

                        }

                    }
                    else if ((dt.Rows[i]["Usage"].ToString() == "UTILITAIRE I < 3.5 T"))
                    {
                        if (RC.Text.ToString() == "RC")
                        {
                            if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "2"))
                            {
                                primeRC = 145000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "3") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "4"))
                            {
                                primeRC = 171000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "5") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "6"))
                            {
                                primeRC = 214000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "7") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "8") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "9") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "10"))
                            {
                                primeRC = 262000;
                            }
                            else if ((dt.Rows[i]["PuissanceFiscale"].ToString() == "11") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "12") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "13") | (dt.Rows[i]["PuissanceFiscale"].ToString() == "14"))
                            {
                                primeRC = 338000;
                            }
                            else
                            {
                                primeRC = 405000;
                            }
                        }
                        if (INCENDIE.Text.ToString() == "INCENDIE")
                        {

                        }
                        if (VOL.Text.ToString() == "VOL")
                        {

                        }
                        if (CAS.Text.ToString() == "CAS")
                        {
                            primeCAS = 50000;
                        }
                        if (TIERCESANSFRANCHISE.Text.ToString() == "TIERCE SANS FRANCHISE")
                        {

                        }
                        if (TIERCEAVECFRANCHISE.Text.ToString() == "TIERCE AVEC FRANCHISE")
                        {

                        }


                    }
                }

                primeTOTALE = primeRC + primeINCENDIE + primeVOL + primeCAS + primeTIERCEAF + primeTIERCESF;
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Garantie(LibelleGar1,LibelleGar2,LibelleGar3,LibelleGar4,LibelleGar5,LibelleGar6,PrimeRC,PrimeIncendie,PrimeVol,PrimeCas,PrimeTierceSf,PrimeTierceAf,PrimeTotale,IdRisque,EtatRisque,OrdreRisque,IdContrat,EtatContrat,OrdreContrat) VALUES(@LibelleGar1,@LibelleGar2,@LibelleGar3,@LibelleGar4,@LibelleGar5,@LibelleGar6,@PrimeRC,@PrimeIncendie,@PrimeVol,@PrimeCas,@PrimeTierceSf,@PrimeTierceAf,@PrimeTotale,@IdRisque,@EtatRisque,@OrdreRisque,@IdContrat,@EtatContrat,@OrdreContrat)", con);
                cmd1.Parameters.AddWithValue("@LibelleGar1", RC.Text);
                cmd1.Parameters.AddWithValue("@LibelleGar2", INCENDIE.Text);
                cmd1.Parameters.AddWithValue("@LibelleGar3", VOL.Text);
                cmd1.Parameters.AddWithValue("@LibelleGar4", CAS.Text);
                cmd1.Parameters.AddWithValue("@LibelleGar5", TIERCESANSFRANCHISE.Text);
                cmd1.Parameters.AddWithValue("@LibelleGar6", TIERCEAVECFRANCHISE.Text);
                cmd1.Parameters.AddWithValue("@PrimeRC", primeRC);
                cmd1.Parameters.AddWithValue("@PrimeIncendie", primeINCENDIE);
                cmd1.Parameters.AddWithValue("@PrimeVol", primeVOL);
                cmd1.Parameters.AddWithValue("@PrimeCas", primeCAS);
                cmd1.Parameters.AddWithValue("@PrimeTierceSf", primeTIERCESF);
                cmd1.Parameters.AddWithValue("@PrimeTierceAf", primeTIERCEAF);
                cmd1.Parameters.AddWithValue("@PrimeTotale", primeTOTALE);
                cmd1.Parameters.AddWithValue("@IdRisque", numplaque.Text);
                cmd1.Parameters.AddWithValue("@EtatRisque", etatr.Text);
                cmd1.Parameters.AddWithValue("@OrdreRisque", ordrer.Text);
                cmd1.Parameters.AddWithValue("@IdContrat", numcontrat.Text);
                cmd1.Parameters.AddWithValue("@EtatContrat", etatc.Text);
                cmd1.Parameters.AddWithValue("@OrdreContrat", ordrec.Text);
                cmd1.ExecuteNonQuery();
            }
        }
    }
}





    
