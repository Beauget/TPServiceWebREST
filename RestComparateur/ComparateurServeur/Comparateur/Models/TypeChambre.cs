using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Comparateur
{
    public class TypeChambre
    {
        public int numChambre;
        public int nbLits;
        public string imageURL;
        public byte[] image;
        public List<Reservation> ListReservations = new List<Reservation>();

        public TypeChambre() { }
        public TypeChambre(int num, int nbLits)
        {
            this.numChambre = num;
            this.nbLits = nbLits;
            this.ListReservations = new List<Reservation>();
        }

        public TypeChambre(int num, int nbLits,string imageUrl)
        {
            this.numChambre = num;
            this.nbLits = nbLits;
            this.imageURL = imageUrl;
            image = StreamToByteArray(imageURL);
            this.ListReservations = new List<Reservation>();
        }

        public TypeChambre(int num, int nbLits,string imageUrl,string gui)
        {
            this.numChambre = num;
            this.nbLits = nbLits;
            this.imageURL = imageUrl;
            this.ListReservations = new List<Reservation>();
        }

        public void ajoutReservation(Reservation r)
        {
            this.ListReservations.Add(r);
        }

        public void retraitReservation(Reservation r)
        {
            if (DateTime.Now > r.dateDepart)
            {
                this.ListReservations.Remove(r);
            }
        }

        public void ToStringListReservation()
        {
            foreach (Reservation z in this.ListReservations)
            {
                Console.WriteLine(z.ToString());
            }
        }

        public bool estDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            //ne rentre pas dans le critère
            if (this.nbLits <= nbLits)
            {
                return false;
            }

            //pas de réservation donc libre
            if (ListReservations.Count == 0)
            {
                return true;
            }

            else
            {
                foreach (Reservation r in this.ListReservations)
                {
                    DateTime dateDebut = r.dateArrivee;
                    DateTime dateFin = r.dateDepart;

                     bool occupee =((debut.CompareTo(dateDebut) >= 0 & fin.CompareTo(dateFin) <= 0)//cas 1 de reservation dans la période 
                                   | (debut.CompareTo(dateDebut) < 0 & fin.CompareTo(dateFin) > 0)//cas 2 de reservation avant et et après la période 
                                   | (debut.CompareTo(dateDebut) < 0 & fin.CompareTo(dateFin) <= 0)//cas 3 de reservation avant la période et qui se termine pendant
                                   | (debut.CompareTo(dateDebut) >= 0 & fin.CompareTo(dateFin) < 0)//cas 4 de reservation pendant la période mais que se termine avant
                                   );
                    //La chambre est occuper pendant la période
                    if (occupee)
                    {
                        return false;
                    }
                }
            }

            //le foreach n'a jamais trouvé de reservation qui gene;
            return true;
        }

        public byte[] StreamToByteArray(string fileName)
        {
            //File.SetAttributes(fileName, FileAttributes.Normal);
            byte[] totalStream = new byte[0];
            using (Stream input = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] streamArray = new byte[0];
                byte[] buffer = new byte[32]; //*1024
                int read = 0;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    streamArray = new byte[totalStream.Length + read];
                    totalStream.CopyTo(streamArray, 0);
                    Array.Copy(buffer, 0, streamArray, totalStream.Length, read);
                    totalStream = streamArray;

                }
            }
            return totalStream;
        }




        public override string ToString()
        {
            return "Numéro : " + this.numChambre + " | " + "Nombre de lits : " + this.nbLits;
        }
    }
}
