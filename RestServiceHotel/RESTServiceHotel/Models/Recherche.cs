using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTServiceHotel
{
    public class Recherche
    {
        public static int idRecherche = 0;
        public String villeDeSejour;
        public DateTime DateArrivee;
        public DateTime DateDepart;
        public int intervallePrixBas;
        public int intervallePrixHaut;
        public int nbEtoilesVoulu;
        public int nbPersonnes;

        public Recherche(String newVilleDeSejour, DateTime newDateArrivee, DateTime newDateDepart, int newIntervalleBas, int newIntervalleHaut, int nbEtoiles, int nbPersonnes)
        {
            idRecherche += 1;
            this.villeDeSejour = newVilleDeSejour;
            this.DateArrivee = newDateArrivee;
            this.DateDepart = newDateDepart;
            this.intervallePrixBas = newIntervalleBas;
            this.intervallePrixHaut = newIntervalleHaut;
            this.nbEtoilesVoulu = nbEtoiles;
            this.nbPersonnes = nbPersonnes;

        }

        public Recherche()
        {

        }

        public void ToStringList(List<Hotel> x)
        {
            foreach (Hotel z in x)
            {
                Console.WriteLine(z.ToString());
            }
        }


        public List<Hotel> rechercheHotel(List<Hotel> research)
        {
            String pays;
            int nbEtoiles;
            int intervalleBas;
            int intervalleHaut;
            int nbPersonnes;
            DateTime dateArrivee;
            DateTime dateDepart;
            List<Hotel> res = research;

            Console.WriteLine("Veuillez saisir le pays de destination, le nombre d'étoiles, intervallePrixHaut, intervallePrixBas, le nombre de personnes, dateArrivee et dateDepart : ");
            pays = Console.ReadLine();
            nbEtoiles = Convert.ToInt32(Console.ReadLine());
            intervalleHaut = Convert.ToInt32(Console.ReadLine());
            intervalleBas = Convert.ToInt32(Console.ReadLine());
            nbPersonnes = Convert.ToInt32(Console.ReadLine());
            dateArrivee = Convert.ToDateTime(Console.ReadLine());
            dateDepart = Convert.ToDateTime(Console.ReadLine());


            //Gestion pays

            foreach(Hotel x in res.ToList())
            {
                if(!(x.paysHotel.Equals(pays)))
                {
                    research.Remove(x);
                   // Console.WriteLine(x.ToString());
                }
            }

            res = research;

            //Gestion nbEtoiles
            foreach (Hotel x in res.ToList())
            {
                if (x.nbEtoiles < nbEtoiles)
                {
                    research.Remove(x);
                   // Console.WriteLine(x.ToString());
                }
            }

            res = research;

            //Gestion intervalle
            foreach (Hotel x in res.ToList())
            {
                if (x.prixNuit > intervalleHaut || x.prixNuit < intervalleBas)
                {
                    research.Remove(x);
                    Console.WriteLine(x.ToString());
                }
            }

            res = research;

            //Gestion date
            foreach (Hotel x in res.ToList())
            {
                TypeChambre z = null;
                if(x.chambreDisponible(dateArrivee,dateDepart,nbPersonnes).Equals(z)) {
                    research.Remove(x);
                }
            }

            res = research;

            Console.WriteLine("j'affiche");
            ToStringList(research);

            return research;
        }

    }
}
