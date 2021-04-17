using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comparateur
{
    [Route("api/[controller]")]
    [ApiController]


    public class ServiceHotel1Controller : ControllerBase   {

        public ServiceHotel1Controller()
        {

        }

        IFormatProvider culture = new CultureInfo("en-US", false);
        Agence agenceChoisis = null;
        Agence agencePartenaire1;
        Agence agencePartenaire2;
        List<Offre> listTemp = new List<Offre>();
        List<Offre> listTempGUI = new List<Offre>();
        Hotel hotelPasCher = null;


        [HttpGet]
        [Route("/HotelPasCher/CreateAndGenerate")]
        public void Create()

        {

            string path = "assets\\";

            this.hotelPasCher = new Hotel("IbisBudget", "230 Avenue des roses", "Montpellier", "France", 2, 35);

            this.agencePartenaire1 = new Agence(1, "Agence des Oliviers", "87 Route des eaux, Montpellier", (float)0.2, "loginAgence1", "admin1");
            this.agencePartenaire2 = new Agence(2, "Agence des Roses", "187 Avenue des eaux, Anger", (float)0.1, "loginAgence2", "admin2");


         TypeChambre chambre1 = new TypeChambre(0, 2);
         TypeChambre chambre2 = new TypeChambre(1, 1);
         TypeChambre chambre3 = new TypeChambre(2, 3);
         TypeChambre chambre4 = new TypeChambre(3, 4);
         TypeChambre chambre5 = new TypeChambre(4, 2);

         DateTime deb1 = DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));
         DateTime fin1 = DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));

         DateTime deb2 = DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));
         DateTime fin2 = DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));

         Offre offreTest1 = new Offre("IbisBudget-1", new TypeChambre(0, 2, path + "chambre1.png"), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
         Offre offreTest2 = new Offre("IbisBudget-2", new TypeChambre(1, 1, path + "chambre2.png"), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
         Offre offreTest3 = new Offre("IbisBudget-3", new TypeChambre(2, 3, path + "chambre2.png"), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 90);
         Offre offreTest4 = new Offre("IbisBudget-4", new TypeChambre(3, 4, path + "chambre1.png"), DateTime.ParseExact("09/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 200);


         Offre offreGUI1 = new Offre("IbisBudget-1", new TypeChambre(0, 2, "https://lemistral.eu/wp-content/uploads/quintuple/chambre-quintuple-chambre-3-lits-768x432.jpg", ""), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
         Offre offreGUI2 = new Offre("IbisBudget-2", new TypeChambre(1, 1, "https://www.usine-digitale.fr/mediatheque/3/9/8/000493893_homePageUne/hotel-c-o-q-paris.jpg", ""), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
         Offre offreGUI3 = new Offre("IbisBudget-3", new TypeChambre(2, 3, "https://media-cdn.tripadvisor.com/media/photo-s/09/75/9f/d5/mariafe-inn.jpg", ""), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 90);
         Offre offreGUI4 = new Offre("IbisBudget-4", new TypeChambre(3, 4, "https://www.vendee-hotel-restaurant.com/wp-content/uploads/2014/10/IMG_9063-700x467.jpg", ""), DateTime.ParseExact("09/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 200);

            agencePartenaire1.HotelPartenaire.Add(hotelPasCher);
            agencePartenaire2.HotelPartenaire.Add(hotelPasCher);
            hotelPasCher.ListChambres.Add(chambre1);
            hotelPasCher.ListChambres.Add(chambre2);
            hotelPasCher.ListChambres.Add(chambre3);
            hotelPasCher.ListChambres.Add(chambre4);
            hotelPasCher.ListChambres.Add(chambre5);

            listTemp.Add(offreTest1);
            listTemp.Add(offreTest2);
            listTemp.Add(offreTest3);
            listTemp.Add(offreTest4);


            offreGUI1.prixTotalOffre = Convert.ToInt32((offreGUI1.fin - offreGUI1.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreGUI2.prixTotalOffre = Convert.ToInt32((offreGUI2.fin - offreGUI2.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreGUI3.prixTotalOffre = Convert.ToInt32((offreGUI3.fin - offreGUI3.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreGUI4.prixTotalOffre = Convert.ToInt32((offreGUI4.fin - offreGUI4.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));

            listTempGUI.Add(offreGUI1);
            listTempGUI.Add(offreGUI2);
            listTempGUI.Add(offreGUI3);
            listTempGUI.Add(offreGUI4);
        }

        // GET: api/<ServiceHotel>
        [HttpGet]
        [Route("/HotelPasCher/ChoixAgence")]
        public bool ChoixAgence(string login, string password)
        {
            Create();
            bool res = true;

            agenceChoisis = checkConnexion(login, password);
            if(agenceChoisis == null)
            {
                res = false;
                return res;
            }

            return res;
        }

        // GET: api/<ServiceHotel>
        [HttpGet]
        [Route("/HotelPasCher/AfficherOffreDisponible")]
        public string AfficherOffreDisponible(string login, string password, string dateArrive, string dateDepart, int nbPersonne)
        {
            Create();
            ServiceHotel1Controller luncher = new ServiceHotel1Controller();
            DateTime dt1 = DateTime.ParseExact(dateArrive, "dd/MM/yyyy", culture);
            DateTime dt2 = DateTime.ParseExact(dateDepart, "dd/MM/yyyy", culture);
            this.agenceChoisis = checkConnexion(login, password);
            List<Offre> Listres = new List<Offre>();
            String listRes = "";
            if (this.agenceChoisis != null)
            {
               foreach(Offre i in listTempGUI)
                {
                    listRes = listRes + i.idOffre +
                        "=" + i.numChambre.nbLits +
                        "=" + i.numChambre.numChambre +
                        "=" + i.prixTotalOffre +
                        "=" + i.numChambre.imageURL +
                        "=" + i.deb +
                        "=" + i.fin +
                        "$";
                }
                Listres = listTemp;

            }
            else
            {
                Console.WriteLine("Désoler votre identification a échoué ! ");
            }

            return listRes;
        }

        [HttpGet]
        public Agence checkConnexion(string log, string mdp)
        {
            if (log.Equals("loginAgence1") && mdp.Equals("admin1"))
            {
                Console.WriteLine("Agence 1 bien connecté ! ");
                this.agenceChoisis = this.agencePartenaire1;
                return agenceChoisis;
            }
            else if (log.Equals("loginAgence2") && mdp.Equals("admin2"))
            {
                Console.WriteLine("Agence 2 bien connecté ! ");
                this.agenceChoisis = this.agencePartenaire2;
                return agenceChoisis;
            }
            else
            {
                Console.WriteLine("Echec connexion ! ");
                this.agenceChoisis = null;
                return null;
            }
        }
        [HttpGet]
        [Route("/HotelPasCher/Reservation")]
        public string faireReservation(string login, string password, string idOffre, string nomPersonne, string prenom, int numeroCB, int nbPersonne)
        {

            if(this.hotelPasCher == null)
            {
                Create();
            }
            checkConnexion(login, password);
            Reservation resFinal = new Reservation();
            String reserv = "";
            foreach (Offre x in listTemp)
            {
                

                if (x.idOffre == idOffre)
                {

                    Reservation res = new Reservation(nomPersonne, prenom, numeroCB, x.deb, x.fin, nbPersonne, x.prixTotalOffre);
                    resFinal = res;
                    Client temp = new Client(nomPersonne, prenom, numeroCB);
                    agenceChoisis.ClientAgence.Add(temp);
                    //recherche la premiere chambre libre et fais la reservation 
                    //si elle n'existe pas/la reservation n'a pas pu etre effectuer renvoie null
                    TypeChambre chambre = hotelPasCher.Reserver(res);
                    hotelPasCher.ListChambres.Add(chambre);
                    reserv = reserv + res.nomClient +
                        "=" + res.prenomClient +
                        "=" + res.prixTotal +
                        "=" + res.numCarteBancaire;
                }
            }
            return reserv;
        }

        [HttpGet]
        [Route("/HotelPasCher/getHotel")]
        public string getHotel()
        {
            Create();
            string i = "";
            i = i + hotelPasCher.nomHotel +
               "=" + hotelPasCher.adresseHotel +
               "=" + hotelPasCher.nbEtoiles +
               "=" + hotelPasCher.prixNuit;
            return i;
        }

        [HttpGet]
        [Route("/HotelPasCher/getOffreComparateur")]
        public string getOffre(string ville, string dateDebut, string dateFin, int nombrePersonne, int nombreEtoile)
        {
            Create();
            String listRes = "";
            foreach (Offre i in listTempGUI)
            {
                listRes = listRes + i.idOffre +
                    "=" + ville +
                    "=" + i.numChambre.nbLits +
                    "=" + i.numChambre.numChambre +
                    "=" + i.prixTotalOffre * (1 + agencePartenaire1.commissionAgence) +
                    "=" + nombrePersonne +
                    "=" + i.numChambre.imageURL +
                    "=" + dateDebut +
                    "=" + dateFin +
                    "=" + hotelPasCher.nomHotel +
                    "=" + hotelPasCher.adresseHotel + 
                    "=" + agencePartenaire1.nomAgence +
                    "$";
            }

            return listRes;

        }

        /*  // GET api/<ServiceHotel>/5
          [HttpGet("{id}")]
          public string Get(int id)
          {
              return "value";
          }

          // POST api/<ServiceHotel>
          [HttpPost]
          public void Post([FromBody] string value)
          {
          }

          // PUT api/<ServiceHotel>/5
          [HttpPut("{id}")]
          public void Put(int id, [FromBody] string value)
          {
          }

          // DELETE api/<ServiceHotel>/5
          [HttpDelete("{id}")]
          public void Delete(int id)
          {
          }*/
    }
}
