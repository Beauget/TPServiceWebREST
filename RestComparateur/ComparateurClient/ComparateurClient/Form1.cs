using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparateurClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Visible = false;
            this.button2.Visible = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string ville = Convert.ToString(this.textBox1.Text);
            string dateD = Convert.ToString(this.dateTimePicker1);
            string dateF = Convert.ToString(this.dateTimePicker2);
            int nbPersonnes = Convert.ToInt32(this.textBox4.Text);
            int nbEtoile = Convert.ToInt32(this.textBox5.Text);

            String url = "https://localhost:44350/";
            string list = Program.GetReleases(url + "Trivago/Comparateur?ville=" + ville + "&dateDebut=" + dateD + "&dateFin=" + dateF + "&nombrePersonne=" + nbPersonnes + "&nombreEtoile=" + nbEtoile);
            string[] resList = list.Split('$');
            string item = "";

            for (int i = 0; i < resList.Length - 1; i++)
            {
                string[] offreCourant = resList[i].Split('=');
                string[] prix = offreCourant[4].Split(',');
                string id = "Id pour la réservation : " + offreCourant[0];
                string agence = "Agence partenaire : " + offreCourant[11];
                string nom = "Nom de l'hôtel : " + offreCourant[9];
                string adr = "Adresse de l'hôtel : " + offreCourant[10];
                string ville2 = "Ville : " + offreCourant[1];
                string dd = "Date d'arrivée : " + offreCourant[7].ToString();
                string df = "Date de départ : " + offreCourant[8].ToString();
                string lits = "Nombre de lits  : " + offreCourant[2];
                string prix2 = "Prix total du séjour : " + offreCourant[4];
                item = item + "Identifiant de l'offre : " + offreCourant[0] +
                   "\n" +
                    "Agence partenaire : " + offreCourant[11] +
                    "\n" +
                    "Nom de l'hôtel : " + offreCourant[9] +
                    "\n" +
                    "Adresse de l'hôtel : " + offreCourant[10] +
                    "\n" +
                    "Ville : " + offreCourant[1] +
                    "\n" +
                    "Date d'arrivée : " + offreCourant[7].ToString() +
                    "\n" +
                    "Date de départ : " + offreCourant[8].ToString() +
                    "\n" +
                    "Nombre de lits  : " + offreCourant[2] +
                    "\n" +
                    "Prix total du séjour : " + offreCourant[4] +
                    "\n";
                listBox1.Items.Add(id);
                listBox1.Items.Add(agence);
                listBox1.Items.Add(nom);
                listBox1.Items.Add(adr);
                listBox1.Items.Add(ville2);
                listBox1.Items.Add(dd);
                listBox1.Items.Add(df);
                listBox1.Items.Add(lits);
                listBox1.Items.Add(prix2);
                listBox1.Items.Add("\n");
            }

            //  MessageBox.Show(item);
            this.groupBox1.Visible = false;
            this.listBox1.Visible = true;
            this.button2.Visible = true;
        }

        private void button2_Click(object sender,EventArgs e)
        {
            this.button2.Visible = false;
            this.listBox1.Visible = false;
            this.groupBox1.Visible = true;
        }

   
    }
}
