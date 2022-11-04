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

        /// <summary>
        /// incrémente l'état du tour
        /// </summary>
        public void ChangerEtat()
        {
            EtatTour++;
        }

        /// <summary>
        /// incrémente certains attributs et réinitialise d'autres pour commencer un nouveau tour
        /// </summary>
        /// <param name="laPartie"></param>
        public void ResetTour(Partie laPartie)
        {
            debut = true;

            laPartie.LePaquet.Reinitialiser();

            // rend les joueurs qui ont encore de l'argent actifs
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

            // retourne les cartes communes
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

            //  remet le pot a zéro
            Pot = 0;
            SidePot = 0;

            //  incrémente les blinds
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

        /// <summary>
        /// Retourne le nombre de joueurs actifs
        /// </summary>
        /// <param name="joueurs"></param>
        /// <returns></returns>
        public int GetNbJoueursActifs(Joueur[] joueurs)
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

        /// <summary>
        /// détermine si les joueurs ont fini de miser
        /// </summary>
        /// <param name="joueurs"></param>
        /// <param name="joueursAyantJoue"></param>
        /// <returns></returns>
        public bool IsFinMises(Joueur[] joueurs, int joueursAyantJoue)
        {
            bool fin = true;
            int premiereMiseA = 0;
            int nbJoueursActifs = GetNbJoueursActifs(joueurs);

            for (int i = 0; i < 4; i++)
            {
                if (premiereMiseA == 0 && joueurs[i].Actif && !joueurs[i].AllIn)
                {
                    premiereMiseA = joueurs[i].MaMise;
                }

                if ((joueurs[i].MaMise != premiereMiseA && joueurs[i].Actif && !joueurs[i].AllIn) || joueursAyantJoue < nbJoueursActifs)
                {
                    return false;
                }
            }

            return fin;
        }
    }
}
