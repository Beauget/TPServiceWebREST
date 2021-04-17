using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comparateur
{
    public class Agence
    {
        public int idAgence;
        public string nomAgence;
        public string adresse;
        public float commissionAgence;

        private string login;
        private string password;

        private List<Hotel> hotelPartenaire;
        private List<Client> clientAgence;


        public Agence(int id, string nom, string adresse, float com,string login, string password)
        {
            this.hotelPartenaire = new List<Hotel>();
            this.clientAgence = new List<Client>();
            this.idAgence = id;
            this.nomAgence = nom;
            this.adresse = adresse;
            this.commissionAgence = com;
            this.login = login;
            this.password = password;
        }

        public Agence()
        {

        }


        public List<Hotel> HotelPartenaire { get => hotelPartenaire; set => hotelPartenaire = value; }
        public List<Client> ClientAgence { get => clientAgence; set => clientAgence = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
    }
}