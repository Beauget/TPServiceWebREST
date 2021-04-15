using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
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

        [Obsolete]
        static void Main(string[] args)
        {
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
            String url = "https://localhost:44388/";


            while (true)
            {

                string choix;
                string login = "loginAgence1";
                string password = "admin1";
                DateTime dt;
                DateTime dD;
                DateTime dF;

                do
                {
                    Console.WriteLine("\n ===== Bienvenue dans notre application agence, veuillez choisir un hôtel partenaire =====\n");
                    Console.WriteLine("   1 - Hôtel PasCher");
                    Console.WriteLine("   2 - Hôtel PlusCher");
                    Console.WriteLine("   3 - Se déconnecter");
                    Console.WriteLine("\n Vous voulez accéder à quel serveur d'hôtel ?");
                    Console.Write("\n ===> Votre choix : ");
                    choix = Console.ReadLine();

                    if (!choix.Equals("1") && !choix.Equals("2") && !choix.Equals("3"))
                    {
                        Console.Clear();
                        Console.WriteLine("\n Erreur : Choisir entre '1', '2' ou '3'");
                    }
                } while (!choix.Equals("1") && !choix.Equals("2") && !choix.Equals("3"));

                if (choix.Equals("1"))
                {
                    string choixOption;

                    while (true)
                    {
                       Console.Clear();

                        do
                        {
                            Console.WriteLine("\n ===== Bienvenue dans le service web de l'hôtel PasCher =====\n");
                            Console.WriteLine("   1 - Consulter les offres ");
                            Console.WriteLine("   2 - Consulter les offres (avec GUI et images) ");
                            Console.WriteLine("   3 - Effectuer une réservation");
                            Console.WriteLine("   0 - Se déconnecter");

                            Console.Write("\n ===> Votre choix : ");
                            choixOption = Console.ReadLine();

                            if (!choixOption.Equals("0") && !choixOption.Equals("1") && !choixOption.Equals("2"))
                            {
                                Console.Clear();
                                Console.WriteLine("\n Erreur : Choisir entre '0', '1' ou '2'");
                            }
                        } while (!choixOption.Equals("0") && !choixOption.Equals("1") && !choixOption.Equals("2"));

                        if (choixOption.Equals("0"))
                        {
                            Console.Clear();
                            break;
                        }

                        else if(choixOption.Equals("1"))
                        {
                            Console.Clear();
                            Console.WriteLine("\n ===== Service : Consultation des offres =====\n");
                            Console.WriteLine("Veuillez entrez les informations suivantes : login de l'agence, mot de passe de l'agence, date d'arrivée et de départ et nombre de personnes");
                            login = Console.ReadLine();
                            password = Console.ReadLine();
                            Console.WriteLine("Entrez la date de debut au format dd/mm/yyyy : ");
                            string dateD = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateD, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateD = Convert.ToString(Console.ReadLine());
                            }
                            Console.WriteLine("Entrez la date de fin au format dd/mm/yyyy : ");
                            string dateF = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateF, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateF = Convert.ToString(Console.ReadLine());
                            }
                            dD = DateTime.ParseExact(dateD, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            dF = DateTime.ParseExact(dateF, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            if (dD > dF)
                            {
                                Console.WriteLine("Inversion des dates");
                                DateTime tmp = dD;
                                dD = dF;
                                dF = tmp;
                            }
                            int nbPersonnes  =  Convert.ToInt32(Console.ReadLine());

                            string offres = GetReleases(url + "HotelPasCher/AfficherOffreDisponible?login="+login+"&password="+password+"&dateArrive="+dateD+"&dateDepart="+dateF+"&nbPersonne="+nbPersonnes);
                            string[] resOffres = offres.Split('$');

                            if (offres == null)
                            {
                                Console.WriteLine("liste vide : problème requête");
                            }

                            for (int i = 0; i < resOffres.Length -1; i++)
                            {
                                string[] offreCourant = resOffres[i].Split('=');
                                Console.WriteLine("      - Identifiant           : " + offreCourant[0]);
                                Console.WriteLine("      - Numéro de chambre     : " + offreCourant[1]);
                                Console.WriteLine("      - Nombre de lit         : " + offreCourant[2]);
                                Console.WriteLine("      - Prix de l'offre       : " + offreCourant[3] + "\n");
                            }

                            Console.Write("\n Appuyer sur une touche pour revenir en arrière...");
                            Console.ReadKey();
                            //AJOUTEZ SUITE OPTION HOTEL1
                        }
                        else if (choixOption.Equals("2"))
                        {
                            Console.Clear();
                            Console.WriteLine("\n ===== Service : Consultation des offres =====\n");
                            Console.WriteLine("Veuillez entrez les informations suivantes : login de l'agence, mot de passe de l'agence, date d'arrivée et de départ et nombre de personnes");
                            login = Console.ReadLine();
                            password = Console.ReadLine();
                            Console.WriteLine("Entrez la date de debut au format dd/mm/yyyy : ");
                            string dateD = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateD, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateD = Convert.ToString(Console.ReadLine());
                            }
                            Console.WriteLine("Entrez la date de fin au format dd/mm/yyyy : ");
                            string dateF = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateF, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateF = Convert.ToString(Console.ReadLine());
                            }
                            dD = DateTime.ParseExact(dateD, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            dF = DateTime.ParseExact(dateF, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            if (dD > dF)
                            {
                                Console.WriteLine("Inversion des dates");
                                DateTime tmp = dD;
                                dD = dF;
                                dF = tmp;
                            }
                            int nbPersonnes = Convert.ToInt32(Console.ReadLine());

                            string offres = GetReleases(url + "HotelPasCher/AfficherOffreDisponible?login=" + login + "&password=" + password + "&dateArrive=" + dateD + "&dateDepart=" + dateF + "&nbPersonne=" + nbPersonnes);
                            string[] resOffres = offres.Split('$');

                            if (offres == null)
                            {
                                Console.WriteLine("liste vide : problème requête");
                            }

                            for (int i = 0; i < resOffres.Length - 1; i++)
                            {
                                string[] offreCourant = resOffres[i].Split('=');
                                Form1 form = new Form1(login,password,resOffres[i], offreCourant[4], resOffres[i],"HotelPasCher");
                                form.ShowDialog();
                              /*  Console.WriteLine("      - Identifiant           : " + offreCourant[0]);
                                Console.WriteLine("      - Numéro de chambre     : " + offreCourant[1]);
                                Console.WriteLine("      - Nombre de lit         : " + offreCourant[2]);
                                Console.WriteLine("      - Prix de l'offre       : " + offreCourant[3] + "\n");*/
                            }

                            Console.Write("\n Appuyer sur une touche pour revenir en arrière...");
                            Console.ReadKey();
                            //AJOUTEZ SUITE OPTION HOTEL1
                        }
                        else if (choixOption.Equals("3"))
                        {
                            Console.Clear();
                            Console.WriteLine("\n ===== Service : Réservation d'une offre partenaire =====\n");
                            Console.WriteLine("Veuillez entrez le login de l'agence et son mot de passe, l'ID de l'offre choisis, votre nom, votre prénom, le nombre de personne et votre numéro de carte bancaire pour la réservation");
                            login = Console.ReadLine();
                            password = Console.ReadLine();
                            string idOffre = Console.ReadLine();
                            string nom = Console.ReadLine();
                            string prenom = Console.ReadLine();
                            int nbPersonnes = Convert.ToInt32(Console.ReadLine());
                            int numeroCarte = Convert.ToInt32(Console.ReadLine());
                            string reserv = GetReleases(url + "HotelPasCher/Reservation?login=" + login + "&password=" + password + "&idOffre=" + idOffre + "&nomPersonne=" + nom + "&prenom=" + prenom + "&numeroCB=" + numeroCarte + "&nbPersonne+" + nbPersonnes);
                            string[] parcours = reserv.Split('$');

                            if (reserv == null)
                            {
                                Console.WriteLine("Reservation vide : problème requête");
                            }

                            string[] resultat = parcours[0].Split('=');
                            Console.WriteLine("      - Nom Client        : " + resultat[0]);
                            Console.WriteLine("      - Prenom Client        : " + resultat[1]);
                            Console.WriteLine("      - Prix total        : " + resultat[2]);
                            Console.WriteLine("      - Référence carte        : " + resultat[3]);


                            Console.WriteLine("RESERVATION PRISE EN COMPTE, MERCI DE VOTRE VISITE");
                            Console.Write("\n Appuyer sur une touche pour revenir en arrière...");
                            Console.ReadKey();
                        }
                    }
                }
                else if(choix.Equals("2"))
                {
                    string choixOption;

                    while (true)
                    {
                        Console.Clear();

                        do
                        {
                            Console.WriteLine("\n ===== Bienvenue dans le service web de l'hôtel PlusCher =====\n");
                            Console.WriteLine("   1 - Consulter les offres (sans distinction)");
                            Console.WriteLine("   2 - Consulter les offres (avec GUI et images) ");
                            Console.WriteLine("   3 - Effectuer une réservation");
                            Console.WriteLine("   0 - Se déconnecter");

                            Console.Write("\n ===> Votre choix : ");
                            choixOption = Console.ReadLine();

                            if (!choixOption.Equals("0") && !choixOption.Equals("1") && !choixOption.Equals("2"))
                            {
                                Console.Clear();
                                Console.WriteLine("\n Erreur : Choisir entre '0', '1' ou '2'");
                            }
                        } while (!choixOption.Equals("0") && !choixOption.Equals("1") && !choixOption.Equals("2"));

                        if (choixOption.Equals("0"))
                        {
                            Console.Clear();
                            break;
                        }

                        else if (choixOption.Equals("1"))
                        {
                            Console.Clear();
                            Console.WriteLine("\n ===== Service : Consultation des offres =====\n");
                            Console.WriteLine("Veuillez entrez les informations suivantes : login de l'agence, mot de passe de l'agence, date d'arrivée et de départ et nombre de personnes");
                             login = Console.ReadLine();
                             password = Console.ReadLine();
                            Console.WriteLine("Entrez la date de debut au format dd/mm/yyyy : ");
                            string dateD = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateD, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateD = Convert.ToString(Console.ReadLine());
                            }
                            Console.WriteLine("Entrez la date de fin au format dd/mm/yyyy : ");
                            string dateF = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateF, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateF = Convert.ToString(Console.ReadLine());
                            }
                            dD = DateTime.ParseExact(dateD, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            dF = DateTime.ParseExact(dateF, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            if (dD > dF)
                            {
                                Console.WriteLine("Inversion des dates");
                                DateTime tmp = dD;
                                dD = dF;
                                dF = tmp;
                            }
                            int nbPersonnes = Convert.ToInt32(Console.ReadLine());

                            string offres = GetReleases(url + "HotelPlusCher/AfficherOffreDisponible?login=" + login + "&password=" + password + "&dateArrive=" + dateD + "&dateDepart=" + dateF + "&nbPersonne=" + nbPersonnes);
                            string[] resOffres = offres.Split('$');

                            if(offres == null)
                            {
                                Console.WriteLine("liste vide : problème requête");
                            }

                            for (int i = 0; i < resOffres.Length - 1; i++)
                            {
                                string[] offreCourante = resOffres[i].Split('=');
                                Console.WriteLine("      - Identifiant           : " + offreCourante[0]);
                                Console.WriteLine("      - Numéro de chambre     : " + offreCourante[1]);
                                Console.WriteLine("      - Nombre de lit         : " + offreCourante[2]);
                                Console.WriteLine("      - Prix de l'offre       : " + offreCourante[3] + "\n");
                            }

                            Console.Write("\n Appuyer sur une touche pour revenir en arrière...");
                            Console.ReadKey();
                            //AJOUTEZ SUITE OPTION HOTEL2
                        }
                        else if (choixOption.Equals("2"))
                        {
                            Console.Clear();
                            Console.WriteLine("\n ===== Service : Consultation des offres =====\n");
                            Console.WriteLine("Veuillez entrez les informations suivantes : login de l'agence, mot de passe de l'agence, date d'arrivée et de départ et nombre de personnes");
                            login = Console.ReadLine();
                            password = Console.ReadLine();
                            Console.WriteLine("Entrez la date de debut au format dd/mm/yyyy : ");
                            string dateD = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateD, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateD = Convert.ToString(Console.ReadLine());
                            }
                            Console.WriteLine("Entrez la date de fin au format dd/mm/yyyy : ");
                            string dateF = Convert.ToString(Console.ReadLine());
                            while (!DateTime.TryParseExact(dateF, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Console.WriteLine("Réessayez");
                                dateF = Convert.ToString(Console.ReadLine());
                            }
                            dD = DateTime.ParseExact(dateD, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            dF = DateTime.ParseExact(dateF, "dd/MM/yyyy", new CultureInfo("en-US", false));
                            if (dD > dF)
                            {
                                Console.WriteLine("Inversion des dates");
                                DateTime tmp = dD;
                                dD = dF;
                                dF = tmp;
                            }
                            int nbPersonnes = Convert.ToInt32(Console.ReadLine());

                            string offres = GetReleases(url + "HotelPlusCher/AfficherOffreDisponible?login=" + login + "&password=" + password + "&dateArrive=" + dateD + "&dateDepart=" + dateF + "&nbPersonne=" + nbPersonnes);
                            string[] resOffres = offres.Split('$');

                            if (offres == null)
                            {
                                Console.WriteLine("liste vide : problème requête");
                            }

                            for (int i = 0; i < resOffres.Length - 1; i++)
                            {
                                string[] offreCourant = resOffres[i].Split('=');
                                Form1 form = new Form1(login, password, resOffres[i], offreCourant[4], resOffres[i], "HotelPasCher");
                                form.ShowDialog();
                                /*  Console.WriteLine("      - Identifiant           : " + offreCourant[0]);
                                  Console.WriteLine("      - Numéro de chambre     : " + offreCourant[1]);
                                  Console.WriteLine("      - Nombre de lit         : " + offreCourant[2]);
                                  Console.WriteLine("      - Prix de l'offre       : " + offreCourant[3] + "\n");*/
                            }

                            Console.Write("\n Appuyer sur une touche pour revenir en arrière...");
                            Console.ReadKey();
                            //AJOUTEZ SUITE OPTION HOTEL2
                        }
                        else if(choixOption.Equals("2"))
                        {
                            Console.Clear();
                            Console.WriteLine("\n ===== Service : Réservation d'une offre partenaire =====\n");
                            Console.WriteLine("Veuillez entrez le login de l'agence et le mot de passse, l'ID de l'offre choisis, votre nom, votre prénom, le nombre de personne et votre numéro de carte bancaire pour la réservation");
                            login = Console.ReadLine();
                            password = Console.ReadLine();
                            string idOffre = Console.ReadLine();
                            string nom = Console.ReadLine();
                            string prenom = Console.ReadLine();
                            int nbPersonnes = Convert.ToInt32(Console.ReadLine());
                            int numeroCarte = Convert.ToInt32(Console.ReadLine());
                            string reserv = GetReleases(url + "HotelPlusCher/Reservation?login=" + login + "&password=" + password + "&idOffre=" + idOffre + "&nomPersonne=" + nom + "&prenom=" + prenom + "&numeroCB=" + numeroCarte + "&nbPersonne+" + nbPersonnes);
                            string[] parcours = reserv.Split('$');

                            if(reserv == null)
                            {
                                Console.WriteLine("Reservation vide : problème requête");
                            }

                            string[] resultat = parcours[0].Split('=');
                            Console.WriteLine("      - Nom Client        : " + resultat[0]);
                            Console.WriteLine("      - Prenom Client        : " + resultat[1]);
                            Console.WriteLine("      - Prix total        : " + resultat[2]);
                            Console.WriteLine("      - Référence carte        : " + resultat[3]);


                            Console.WriteLine("RESERVATION PRISE EN COMPTE, MERCI DE VOTRE VISITE");
                            Console.Write("\n Appuyer sur une touche pour revenir en arrière...");
                            Console.ReadKey();
                        }
                    }

                }
                else if(choix.Equals("3"))
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}

