using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comparateur
{
    public class Offre
    {
        public string idOffre;
        public TypeChambre numChambre;
        public DateTime deb;
        public DateTime fin;
        public double prixTotalOffre;


        public Offre()
        {

        }

        public Offre(string id, TypeChambre chambre,DateTime deb, DateTime fin, double prix)
        {
            this.idOffre = id;
            this.numChambre = chambre;
            this.deb = deb;
            this.fin = fin;
            this.prixTotalOffre = prix;

        }

        public override string ToString()
        {
            return "Référence de l'offre : " +  this.idOffre + "\n -" + "Nombre de lits présent : " + this.numChambre.nbLits + "\n -" + this.deb + "\n -" + this.fin + "\n -" + this.prixTotalOffre;
        }
    }
}