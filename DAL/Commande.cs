using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Commande
    {
        public int IDCommande { get; set; }
        public string PTTC { get; set; }
        public string InfoPaiement { get; set; }
        public string EtatCommande { get; set; }
        public string DateCommande { get; set; }
        public string DatePaiement { get; set; }
        public string PTHT { get; set; }
        public string ReducSup { get; set; }
        public int IDClient { get; set; }

        public string TotalInfoCommande
        {

            get
            {
                return "N° " + IDCommande + " -- Prix : " + PTTC + " -- Info : " + InfoPaiement + " -- Etat : " + EtatCommande + " -- Date : " + DateCommande + " -- Paiement : " + DatePaiement + " -- Prix HT : " + PTHT + " -- Réduc : " + ReducSup + " -- Client : " + IDClient; 
            }

            set { }
  
        }
        public string TotalInfoClient
        {

            get
            {
                return " Date : " + DateCommande + " -- Référence client : " + IDClient + " -- Montant :" + PTTC; 
            }
            set { }

        }
    }
}
