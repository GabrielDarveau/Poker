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
        public int EtatTour { get; private set; } = 0;
        static public int Pot{ get; set; }
        static public int SidePot { get; set; }
        static public int derniereMise;
        public int smallBlind { get; private set; } = 1;
        public int bigBlind { get; private set; } = 2;
        public bool debut { get; set; } = true;
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
            debut = true;

            laPartie.LePaquet.Reinitialiser();

            for (int i = 0; i < 4; i++)
            {
                if (laPartie.joueurs[i].Argent <= 0)
                {
                    laPartie.joueurs[i].Actif = false;
                }
                else
                {
                    laPartie.joueurs[i].Actif = true;
                }
            }

            EtatTour = 0;

            for (int i = 0; i < 5; i++)
            {
                carteCommunes[i].Visible = false;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    laPartie.joueurs[i].MaMain.cartes[j].Visible = true;
                }
            }

            Pot = 0;
            SidePot = 0;

            do
            {
                smallBlind++;
                if (smallBlind == 5)
                {
                    smallBlind = 1;
                }
            } while (!laPartie.joueurs[smallBlind - 1].Actif );

            do
            {
                bigBlind++;
                if (bigBlind == 5)
                {
                    bigBlind = 1;
                }
            } while (!laPartie.joueurs[bigBlind - 1].Actif || smallBlind == bigBlind);

        }

        public int JoueursActifs(Joueur[] joueurs)
        {
            int nbJoueursA = 0;

            foreach (Joueur j in joueurs)
            {
                if (j.Actif && !j.AllIn)
                {
                    nbJoueursA++;
                }
            }

            return nbJoueursA;
        }

        public bool FinMises(Joueur[] joueurs, int joueursAyantJoue)
        {
            bool fin = true;
            int premiereMiseA = 0;

            for (int i = 0; i < 4; i++)
            {
                if (premiereMiseA == 0 && joueurs[i].Actif)
                {
                    premiereMiseA = joueurs[i].MaMise;
                }

                if ((joueurs[i].MaMise != premiereMiseA && joueurs[i].Actif) || joueursAyantJoue < JoueursActifs(joueurs))
                {
                    return false;
                }
            }

            return fin;
        }
    }
}
