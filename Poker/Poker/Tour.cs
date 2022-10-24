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

        public bool JoueursActifs(Partie laPartie)
        {
            bool sontActifs = true;
            int nbJoueursA = 0;


            foreach (Joueur j in laPartie.joueurs)
            {
                if (j.Actif)
                {
                    nbJoueursA++;
                }
            }

            return nbJoueursA > 1;
        }

        public bool FinMises()
        {
            bool fin = 
        }
    }
}
