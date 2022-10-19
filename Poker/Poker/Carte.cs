using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    enum Valeur
    {
        As,
        Roi,
        Dame,
        Valet,
        dix,
        neuf,
        huit,
        sept,
        six,
        cinq,
        quatre,
        trois,
        deux 
    }

    enum Couleur
    {
        Coeur,
        Pique,
        Carreau,
        Treffle
    }

    internal class Carte
    {
        //Variables
        Valeur MaValeur;
        Couleur MaCouleur;
        bool visible;

        //Constructeur
        Carte()
        {

        }

        //Fonctions
        public int  ComparerCarte()
        {

        }

        public void Retourner()
        {

        }


    }
}
