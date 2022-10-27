using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Tour
    {
        //Attributs
        public Carte[] carteCommunes { get; set; } = new Carte[5];
        public int EtatTour { get; private set; }
        static public int Pot{ get; set; }
        static public int SidePot { get; set; }
        static public int derniereMise; 

        //Constructeur
        public Tour()
        {

        }

        //Fonctions
        public void ChangerEtat()
        {
            EtatTour++;
        }

        public void ResetTour(Partie laPartie)
        {
            laPartie.joueurs[0].Actif = true;
            laPartie.joueurs[1].Actif = true;
            laPartie.joueurs[2].Actif = true;
            laPartie.joueurs[3].Actif = true;
            EtatTour = 0;

            carteCommunes[0].Visible = false;
            carteCommunes[1].Visible = false;
            carteCommunes[2].Visible = false;
            carteCommunes[3].Visible = false;
            carteCommunes[4].Visible = false;

            derniereMise = 0;
            SidePot = 0;

        }

        public bool JoueursActifs(Joueur[] joueurs)
        {
            bool sontActifs = true;
            int nbJoueursA = 0;


            foreach (Joueur j in joueurs)
            {
                if (j.Actif)
                {
                    nbJoueursA++;
                }
            }

            return nbJoueursA > 1;
        }

        public bool FinMises(Joueur[] joueurs)
        {
            bool fin = true;
            int premiereMiseA = 0;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    premiereMiseA = joueurs[i].MaMise;
                }

                if (joueurs[i].MaMise != premiereMiseA && joueurs[i].Actif)
                {
                    return false;
                }
            }

            return fin;
        }
    }
}
