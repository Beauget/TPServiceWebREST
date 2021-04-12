using System;
using System.Collections.Generic;
using System.Text;

namespace RESTServiceHotel
{
    public class Client
    {
        public static int idClient = 0;
        public String nomClient;
        public String prenomClient;
        public int numeroCarteBancaire;

        public Client(String newNomClient, String newPrenomClient, int newNumeroCarteBancaire)
        {
            idClient += 1;
            this.nomClient = newNomClient;
            this.prenomClient = newPrenomClient;
            this.numeroCarteBancaire = newNumeroCarteBancaire;
        }

        public Client()
        {

        }



    }
}
