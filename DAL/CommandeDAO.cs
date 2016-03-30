using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CommandeDAO
    {
        string SQL_String = "server = .; database = village_green; integrated security = true";

        SqlConnection Connect;

        public CommandeDAO()
        {

            Connect = new SqlConnection(SQL_String);

        }

        public void Insert(Commande Com)
        {

            Connect.Open();

            SqlCommand Inserer = new SqlCommand(@"insert into gratte.Commande(PTTC, Info_Paiement, Etat_Commande, Date_Commande, PTHT, Reduc_Sup) 
                                                values (@PTTC, @Info_Paiement, @Etat_Commande, @Date_Commande, @PTHT, @Reduc_Sup)", Connect);
            Inserer.Parameters.AddWithValue("@PTTC", Com.PTTC);
            Inserer.Parameters.AddWithValue("@Info_Paiement", Com.InfoPaiement);
            Inserer.Parameters.AddWithValue("@Etat_Commande", Com.EtatCommande);
            Inserer.Parameters.AddWithValue("@Date_Commande", Com.DateCommande);
            Inserer.Parameters.AddWithValue("@PTHT", Com.PTHT);
            Inserer.Parameters.AddWithValue("@Reduc_Sup", Com.ReducSup);

            Inserer.ExecuteNonQuery();

            Connect.Close();

        }

        public void Update(Commande Com)
        {

            Connect.Open();

            SqlCommand Update = new SqlCommand(@"update gratte.Commande set PTTC = @PTTC, Info_Paiement = @Info_Paiement, Etat_Commande = @Etat_Commande,
                                               Date_Commande = @Date_Commande, PTHT = @PTHT, Reduc_Sup = @Reduc_Sup where ID_Commande = @ID_Commande", Connect);

            Update.Parameters.AddWithValue("@ID_Commande", Com.IDCommande);
            Update.Parameters.AddWithValue("@PTTC", Com.PTTC);
            Update.Parameters.AddWithValue("@Info_Paiement", Com.InfoPaiement);
            Update.Parameters.AddWithValue("@Etat_Commande", Com.EtatCommande);
            Update.Parameters.AddWithValue("@Date_Commande", Com.DateCommande);
            Update.Parameters.AddWithValue("@PTHT", Com.PTHT);
            Update.Parameters.AddWithValue("@Reduc_Sup", Com.ReducSup);



            Update.ExecuteNonQuery();

            Connect.Close();

        }

        public void Delete(Commande Com)
        {
            Connect.Open();

            SqlCommand Delete = new SqlCommand("delete from gratte.Commande where ID_Commande = @ID_Commande", Connect);
            Delete.Parameters.AddWithValue("@ID_Commande", Com.IDCommande);
           
            Delete.ExecuteNonQuery();
           
            Connect.Close();

        }

        public Commande FindCommande(int ID)
        {

            Commande Com = new Commande();

            Connect.Open();

            SqlCommand Trouver = new SqlCommand("select * from gratte.Commande where ID_Commande = @ID_Commande", Connect);
            Trouver.Parameters.AddWithValue("@ID_Commande", ID);

            SqlDataReader Resultat = Trouver.ExecuteReader();

            if (Resultat.Read())
            {

                Com.IDCommande = Convert.ToInt32(Resultat["ID_Commande"]);
                Com.PTTC = Convert.ToString(Resultat["PTTC"]);
                Com.InfoPaiement = Convert.ToString(Resultat["Info_Paiement"]);
                Com.EtatCommande = Convert.ToString(Resultat["Etat_Commande"]);
                Com.DateCommande = Convert.ToString(Resultat["Date_Commande"]);
                Com.DatePaiement = Convert.ToString(Resultat["Date_Paiement"]);
                Com.PTHT = Convert.ToString(Resultat["PTHT"]);
                Com.ReducSup = Convert.ToString(Resultat["Reduc_Sup"]);

                if (Resultat["ID_Client"] == DBNull.Value)
                {
                    Com.IDClient = 0;
                }
                else
                {
                    Com.IDClient = Convert.ToInt32(Resultat["ID_Client"]);
                }

            }

            return Com;

        }

        public Commande FindClient(int IDClient)
        {

            Commande Com = new Commande();

            Connect.Open();

            SqlCommand Trouver = new SqlCommand("select * from gratte.Commande where ID_Client = @ID_Client", Connect);
            Trouver.Parameters.AddWithValue("@ID_Client", IDClient);

            SqlDataReader Resultat = Trouver.ExecuteReader();

            if (Resultat.Read())
            {

                Com.IDCommande = Convert.ToInt32(Resultat["ID_Commande"]);
                Com.PTTC = Convert.ToString(Resultat["PTTC"]);
                Com.InfoPaiement = Convert.ToString(Resultat["Info_Paiement"]);
                Com.EtatCommande = Convert.ToString(Resultat["Etat_Commande"]);
                Com.DateCommande = Convert.ToString(Resultat["Date_Commande"]);
                Com.DatePaiement = Convert.ToString(Resultat["Date_Paiement"]);
                Com.PTHT = Convert.ToString(Resultat["PTHT"]);
                Com.ReducSup = Convert.ToString(Resultat["Reduc_Sup"]);

                if (Resultat["ID_Client"] == DBNull.Value)
                {

                    Com.IDClient = 0;

                }

                else
                {

                    Com.IDClient = Convert.ToInt32(Resultat["ID_Client"]);

                }

            }

            return Com;

        }


        public List<Commande> List()
        {

            List<Commande> Liste = new List<Commande>();

            Connect.Open();

            SqlCommand Lister = new SqlCommand("select * from gratte.Commande", Connect);

            SqlDataReader Resultat = Lister.ExecuteReader();

            while (Resultat.Read())
            {

                Commande Com = new Commande();

                Com.IDCommande = Convert.ToInt32(Resultat["ID_Commande"]);
                Com.PTTC = Convert.ToString(Resultat["PTTC"]);
                Com.InfoPaiement = Convert.ToString(Resultat["Info_Paiement"]);
                Com.EtatCommande = Convert.ToString(Resultat["Etat_Commande"]);
                Com.DateCommande = Convert.ToString(Resultat["Date_Commande"]);
                Com.DatePaiement = Convert.ToString(Resultat["Date_Paiement"]);
                Com.PTHT = Convert.ToString(Resultat["PTHT"]);
                Com.ReducSup = Convert.ToString(Resultat["Reduc_Sup"]);

                if (Resultat["ID_Client"] == DBNull.Value)
                {

                    Com.IDClient = 0;

                }

                else
                {

                    Com.IDClient = Convert.ToInt32(Resultat["ID_Client"]);

                }

                Liste.Add(Com);

            }

            Connect.Close();

            return Liste;

        }


        public List<Commande> ListByClient(int IDClient)
        {

            List<Commande> Liste = new List<Commande>();

            Connect.Open();

            SqlCommand Lister = new SqlCommand("select * from gratte.Commande where ID_Client=@idc", Connect);
            Lister.Parameters.AddWithValue("@idc", IDClient);

            SqlDataReader Resultat = Lister.ExecuteReader();

            while (Resultat.Read())
            {

                Commande Com = new Commande();

                Com.IDCommande = Convert.ToInt32(Resultat["ID_Commande"]);
                Com.PTTC = Convert.ToString(Resultat["PTTC"]);
                Com.InfoPaiement = Convert.ToString(Resultat["Info_Paiement"]);
                Com.EtatCommande = Convert.ToString(Resultat["Etat_Commande"]);
                Com.DateCommande = Convert.ToString(Resultat["Date_Commande"]);
                Com.DatePaiement = Convert.ToString(Resultat["Date_Paiement"]);
                Com.PTHT = Convert.ToString(Resultat["PTHT"]);
                Com.ReducSup = Convert.ToString(Resultat["Reduc_Sup"]);

                if (Resultat["ID_Client"] == DBNull.Value)
                {

                    Com.IDClient = 0;

                }

                else
                {

                    Com.IDClient = Convert.ToInt32(Resultat["ID_Client"]);

                }

                Liste.Add(Com);

            }

            Connect.Close();

            return Liste;

        }
    }
}
