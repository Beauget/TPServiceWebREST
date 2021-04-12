using System;
using System.Collections.Generic;
using System.Text;

namespace RESTServiceHotel
{
    public class Hotel
    {
        public static int idHotel = 0;
        public List<TypeChambre> ListChambres;
        public String nomHotel;
        public String adresseHotel;
        public String ville;
        public String paysHotel;
        public int nbEtoiles;
        public float prixNuit;

        public Hotel(String newNomHotel, String newAdresse, String newVille, String newPays, int nbEtoiles, float prix)
        {
            idHotel += 1;
            this.ListChambres = new List<TypeChambre>();
            this.nomHotel = newNomHotel;
            this.adresseHotel = newAdresse;
            this.ville = newVille;
            this.paysHotel = newPays;
            this.nbEtoiles = nbEtoiles;
            this.prixNuit = prix;
        }

        public Hotel()
        {

        }


        public void InitChambre()
        {
            var rand = new Random();
            int numChambre = 0;
            int x = rand.Next(10, 40);
            for(int i = 0; i < x; i++)
            {
                int lits = rand.Next(1, 4);
                TypeChambre chambre = new TypeChambre(numChambre, lits);
                numChambre += 1;
                this.ListChambres.Add(chambre);

            }
        }

        public void afficherChambre()
        {
            foreach(TypeChambre x in this.ListChambres)
            {
                Console.WriteLine(x.ToString());
            }
        }

     /*   public Chambre chambreDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            foreach(Chambre x in this.ListChambres)
            {
                if(x.nbLits >= nbLits)
                {
                    return x;
                }
            }
          
            return null;
        }*/

        public TypeChambre chambreDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            TypeChambre z = null;
                foreach (TypeChambre x in this.ListChambres)
            {   
                //vérifie si la chambre est disponible
                if (x.estDisponible(debut, fin, nbLits))
                {
                    return x;
                }

            }
            //l'hotel n'as pas de chambre (vide) ou elles sont toute occupé pendant la période
            return z; 
        }

        public TypeChambre Reserver(Reservation r)
        {
            TypeChambre chambre = this.chambreDisponible(r.dateArrivee, r.dateDepart, r.nbPersonne);
            TypeChambre z = null;
            if (chambre.Equals(z))
            {   //pas de chambre disponible
                return z;
            }
            else
            {
                chambre.ajoutReservation(r);
            }
            return chambre;

        }

        public override string ToString()
        {
            return base.ToString() + "\n - " + this.nomHotel + "\n - " + this.adresseHotel + "\n - " + this.ville + "\n - " + this.paysHotel + "\n - " + this.nbEtoiles + "\n - " + this.prixNuit;
        }


      
    }
}
