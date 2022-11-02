﻿using System;
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
        public int smallBlind { get; private set; } = 0;
        public int bigBlind { get; private set; } = 1;
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

            for (int i = 0; i < 4; i++)
            {
                laPartie.joueurs[i].Actif = true;
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

            SidePot = 0;

            if (bigBlind == 3)
            {
                bigBlind = 0;
            }
            else
            {
                bigBlind++;
            }

            if (smallBlind == 3)
            {
                smallBlind = 0;
            }
            else
            {
                smallBlind++;
            }
        }

        public int JoueursActifs(Joueur[] joueurs)
        {
            int nbJoueursA = 0;

            foreach (Joueur j in joueurs)
            {
                if (j.Actif)
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
                if (i == 0)
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
