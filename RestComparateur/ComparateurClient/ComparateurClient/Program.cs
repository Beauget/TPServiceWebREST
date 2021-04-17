using System;
using System.IO;
using System.Net;


namespace ComparateurClient
{
    class Program
    {
        public static String GetReleases(String url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            String resultat = content.ToString();
            return resultat.Replace("\"", "");
        }
        static void Main(string[] args)
        {
            string cmd = "100";
            while (cmd != "0")
            {
                Console.WriteLine("\n               |||||||||||| Bienvenue dans notre application TrivaGogo ! ||||||||||||             \n ");
                Console.WriteLine("Notre seul objectif : vous proposez les meilleurs offres, pour cela nous avons besoin de quelques informations");
                Console.WriteLine("\n");
                Console.WriteLine("Veuillez choisir un mode : \n" + "1 : Comparateur (Avec GUI) \n" + "2 : Comparateur (Sans GUI) \n" + "0 : Quittez");
                cmd = Console.ReadLine();
                switch (cmd) 
                {
               
                case "0":
                    Console.WriteLine("Merci de votre visite");
                break;
                case "1":
                Form1 form = new Form1();
                form.ShowDialog();
                break;
                case "2":
              
                Console.WriteLine("Veuillez indiquez : la ville, la date de d'arrivée, de départ, le nombre de personnes et le nombre d'étoile minimum");

                string ville = Console.ReadLine();
                string dateD = Console.ReadLine();
                string dateF = Console.ReadLine();
                int nbPersonnes = Convert.ToInt32(Console.ReadLine());
                int nbEtoiles = Convert.ToInt32(Console.ReadLine());

                String url = "https://localhost:44350/";
                string list = GetReleases(url + "Trivago/Comparateur?ville=" + ville + "&dateDebut=" + dateD + "&dateFin=" + dateF + "&nombrePersonne=" + nbPersonnes + "&nombreEtoile=" + nbEtoiles);
                string[] resList = list.Split('$');

                for (int i = 0; i < resList.Length - 1; i++)
                {
                    Console.WriteLine("\n");
                    string[] offreCourant = resList[i].Split('=');
                    Console.WriteLine("Identifiant de l'offre : " + offreCourant[0]);
                    Console.WriteLine("Agence partenaire : " + offreCourant[11]);
                    Console.WriteLine("Nom de l'hôtel : " + offreCourant[9]);
                    Console.WriteLine("Adresse de l'hôtel : " + offreCourant[10]);
                    Console.WriteLine("Ville : " + offreCourant[1]);
                    Console.WriteLine("Date de d'arrivée : " + offreCourant[7]);
                    Console.WriteLine("Date de départ : " + offreCourant[8]);
                    Console.WriteLine("Nombre de lits  : " + offreCourant[2]);
                    string[] prix = offreCourant[4].Split(',');
                    Console.WriteLine("Prix total du séjour : " + prix[0]);
                    Console.WriteLine("\n");
                    Console.WriteLine("-----------------------------------");
                }

                Console.WriteLine("Pour réserver veuillez vous connectez à notre service d'agence en ligne");
                Console.ReadKey();
                break;
            }
            }
        }
    }
}
