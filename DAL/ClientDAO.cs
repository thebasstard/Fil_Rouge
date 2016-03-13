using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ClientDAO
    {
        string SQL_String = "server = .; database = village_green; integrated security = true";

        SqlConnection Connect;

        public ClientDAO()
        {

            Connect = new SqlConnection(SQL_String);

        }

        public void Insert(Client Cli)
        {

            Connect.Open();

            SqlCommand Inserer = new SqlCommand(@"insert into gratte.Client(ID_Client, Adr_Factur, Adr_Livr, Categorie, Coeff, ID_Commercial) 
                                                values (@ID_Client, @Adr_Factur, @Adr_Livr, @Categorie, @Coeff, @ID_Commercial)", Connect);
            
            Inserer.Parameters.AddWithValue("@Adr_Factur", Cli.AdrFactur);
            Inserer.Parameters.AddWithValue("@Adr_Livr", Cli.AdrLivr);
            Inserer.Parameters.AddWithValue("@Categorie", Cli.Categorie);
            Inserer.Parameters.AddWithValue("@Coeff", Cli.Coeff);            

            Inserer.ExecuteNonQuery();

            Connect.Close();
        }

        public void Update(Client Cli)
        {

            Connect.Open();

            SqlCommand Update = new SqlCommand(@"update gratte.Client set ID_Client = @ID_Client, Adr_Factur = @Adr_Factur, Adr_Livr = @Adr_Livr,
                                                Categorie = @ Categorie, Coeff = @Coeff, ID_Commercial = @ID_Commercial where ID_Client = @ID_Client", Connect);

            Update.Parameters.AddWithValue("@ID_Client", Cli.IDClient);
            Update.Parameters.AddWithValue("@Adr_Factur", Cli.AdrFactur);
            Update.Parameters.AddWithValue("@Adr_Livr", Cli.AdrLivr);
            Update.Parameters.AddWithValue("@Categorie", Cli.Categorie);
            Update.Parameters.AddWithValue("@Coeff", Cli.Coeff);
            Update.Parameters.AddWithValue("@ID_Commercial", Cli.IDCommercial);

            Update.ExecuteNonQuery();

            Connect.Close();

        }

        public void Delete(Client Cli)
        {
            Connect.Open();

            SqlCommand Delete = new SqlCommand("delete from gratte.Client where ID_Client = @ID_Client", Connect);
            Delete.Parameters.AddWithValue("@ID_Client", Cli.IDClient);

            Delete.ExecuteNonQuery();

            Connect.Close();

        }

        public Client Find(int ID)
        {

            Client Cli = new Client();

            Connect.Open();

            SqlCommand Trouver = new SqlCommand("select * from gratte.Client where ID_Client = @ID_Client", Connect);
            Trouver.Parameters.AddWithValue("@ID_Client", ID);

            SqlDataReader Resultat = Trouver.ExecuteReader();

            if (Resultat.Read())
            {

                Cli.IDClient = Convert.ToInt32(Resultat["ID_Client"]);
                Cli.AdrFactur = Convert.ToString(Resultat["Adr_Factur"]);
                Cli.AdrLivr = Convert.ToString(Resultat["Adr_Livr"]);
                Cli.Categorie = Convert.ToBoolean(Resultat["Categorie"]);
                Cli.Coeff = Convert.ToInt32(Resultat["Coeff"]);
                Cli.IDCommercial = Convert.ToInt32(Resultat["ID_Commercial"]);              

            }

            return Cli;

        }

        public List<Client> List()
        {

            List<Client> Liste = new List<Client>();

            Connect.Open();

            SqlCommand Lister = new SqlCommand("select * from gratte.Client", Connect);

            SqlDataReader Resultat = Lister.ExecuteReader();

            while (Resultat.Read())
            {

                Client Cli = new Client();

                Cli.IDClient = Convert.ToInt32(Resultat["ID_Client"]);
                Cli.AdrFactur = Convert.ToString(Resultat["Adr_Factur"]);
                Cli.AdrLivr = Convert.ToString(Resultat["Adr_Livr"]);
                Cli.Categorie = Convert.ToBoolean(Resultat["Categorie"]);
                Cli.Coeff = Convert.ToInt32(Resultat["Coeff"]);

                if (Resultat["ID_Commercial"] == DBNull.Value)
                {
                    Cli.IDCommercial = 0;
                }
                else
                {
                    Cli.IDCommercial = Convert.ToInt32(Resultat["ID_Commercial"]);
                }

                Liste.Add(Cli);

            }

            return Liste;

        }
    }
}
