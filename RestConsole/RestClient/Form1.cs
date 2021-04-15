using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestClient
{
    public partial class Form1 : Form
    {
        private int prix = 0;
        private string hotelCourant ="";
        private  static string loginS = "";
        private  static string mdpS = "";
        public Form1(string login, string password,string offre, String url, String info,string hotel)
        {

            InitializeComponent();
            hotelCourant = hotel;
            loginS = login;
            mdpS = password;
            string[] offreCourant = offre.Split('=');
            label1.Text = "Id de l'offre : " + offreCourant[0];
            label2.Text = "Photo de la chambre (ci-dessous) et nombre de lits" + offreCourant[1];
            pictureBox1.Load(url);
            textBox1.Text = offreCourant[0];
            label3.Text = "Prix total de l'offre : " + Convert.ToString(offreCourant[3]) + "€";
            prix = Convert.ToInt32(offreCourant[3]);
            label10.Text = "Date de disponibilité : " + "\n" + "Arriver : " + offreCourant[5] + "\n" + "Départ : " + offreCourant[6];
            string i = Program.GetReleases("https://localhost:44388/" + hotel + "/getHotel");
            string[] infoHotel = i.Split('=');
            label11.Text = "Nom de l'hotel : " + infoHotel[0] + "\n" + "Adresse : " + infoHotel[1] + "\n" + "Etoiles : " + infoHotel[2] + "\n" + "Prix nuit/personne : " + infoHotel[3];
            label12.Text = "Cette offre vous plaît ?  " + "\n" + "Remplissez notre formulaire" + "\n" + "de réservation : ";

        }

        public Form1()
        {

            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string id = this.textBox1.Text;
            string nom = this.textBox2.Text;
            string prenom = this.textBox4.Text;
            int NbPersonnes = Convert.ToInt32(this.textBox3.Text);
            int cb = Convert.ToInt32(this.textBox5.Text);
            string reserv = Program.GetReleases("https://localhost:44388/" + hotelCourant + "/Reservation?login="+loginS+"&password="+mdpS+"&idOffre=" + id + "&nomPersonne=" + nom + "&prenom=" + prenom + "&numeroCB=" + cb + "&nbPersonne+" + NbPersonnes);
            string[] parcours = reserv.Split('=');

            MessageBox.Show("Nom de réservation : " + parcours[0] + " " + parcours[1] + "\n - "  + "Prix total de votre réservation : " + parcours[2]);
            this.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
        }
    }
}
