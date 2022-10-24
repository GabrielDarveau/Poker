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
        int EtatTour;
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
    }
}
