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
        public int EtatTour { get; private set; }
        static public int Pot{ get; set; }

        //Constructeur
        public Tour()
        {

        }

        //Fonctions
        public void ChangerEtat()
        {

        }

        public void ResetTour()
        {

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
                    premiereMiseA = joueurs[i].mise;
                }

                if (joueurs[i].mise != premiereMiseA && joueurs[i].Actif)
                {
                    return false;
                }
            }

            return fin;
        }
    }
}
