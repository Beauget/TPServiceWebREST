using System;
using System.Collections.Generic;
using System.Text;

namespace RESTServiceHotel
{
    public class Reservation
    {
        public static int idReservation = 0;
        public String nomClient;
        public String prenomClient;
        public DateTime dateArrivee;
        public DateTime dateDepart;
        public int numCarteBancaire;
        public int nbPersonne;
        public int dureeSejour;
        public double prixTotal;

        public Reservation(String newNomClient, String newPrenomClient, int newNumCarteBancaire, DateTime newDateArrivee, DateTime newDateDepart, int newNbPersonne, double PrixTotal)
        {
            idReservation += 1;
            this.nomClient = newNomClient;
            this.prenomClient = newPrenomClient;
            this.dateArrivee = newDateArrivee;
            this.dateDepart = newDateDepart;
            this.numCarteBancaire = newNumCarteBancaire;
            this.nbPersonne = newNbPersonne;
            this.dureeSejour = (dateDepart - dateArrivee).Days;
            this.prixTotal = PrixTotal;
        }

        public Reservation()
        {

        }

        public override string ToString()
        {
            return  "Nom : " + this.nomClient + "\n - " + "Prénom : " + this.prenomClient + "\n - " + this.dateArrivee + "\n - " + this.dateDepart + "\n - " + "Prix total de votre réservation : " + this.prixTotal;
        }

        public void reservationHotel(List<Hotel> resList, List<Hotel> baseList)
        {
            String nom;
            String nomPersonne;
            String prenom;
            int numeroCarte;
            int nbPersonne;
            DateTime dateArrivee;
            DateTime dateDepart;
            Console.WriteLine("Veuillez indiquer le nom de l'hotel que vous voulez sélectionnez");
            nom = Console.ReadLine();

            Console.WriteLine("Veuillez indiquez les informations suivantes pour que votre réservation soit prise en compte : Nom, Prénom, Numéro de carte bancaire, Nombre de personnes, Date d'arrivé et de départ");
            nomPersonne = Console.ReadLine();
            prenom = Console.ReadLine();
            numeroCarte = Convert.ToInt32(Console.ReadLine());
            nbPersonne = Convert.ToInt32(Console.ReadLine());
            dateArrivee = Convert.ToDateTime(Console.ReadLine());
            dateDepart = Convert.ToDateTime(Console.ReadLine());

            TypeChambre z = null;

            foreach (Hotel x in baseList)
            {
                if (x.nomHotel.Equals(nom))
                {
                    TimeSpan total = (dateDepart - dateArrivee);
                    double temp = total.TotalDays;
                    Console.WriteLine(temp);
                    double prixTotal = (int)(x.prixNuit * nbPersonne) * temp;
                    Reservation res = new Reservation(nomPersonne, prenom, numeroCarte, dateArrivee, dateDepart, nbPersonne, prixTotal);
                    //recherche la premiere chambre libre et fais la reservation 
                    //si elle n'existe pas/la reservation n'a pas pu etre effectuer renvoie null
                    TypeChambre chambre = x.Reserver(res);

                    if (chambre.Equals(z)==false)
                    {
                        //info hotel
                        Console.WriteLine(x.ToString());
                        //info chambre
                        Console.WriteLine(chambre.ToString());
                        //info reservation
                        chambre.ToStringListReservation();
                        Console.WriteLine("Votre réservation a été effectué");
                    }
                    else
                    {
                        Console.WriteLine("Désoler il n'y a pas de chambre disponible dans cet hotel pour vous");
                    }


                }
            }


        }

       

    }
}
