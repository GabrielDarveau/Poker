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
        Couleur MaCouleur;
        Valeur MaValeur;
        bool Visible;

        //Constructeur
        Carte(Couleur couleur, Valeur valeur)
        {
            MaCouleur = couleur;
            MaValeur = valeur;
            Visible = false;
        }

        //Fonctions
        //public int  ComparerCarte(Carte carteAComparer)
        //{

        //}

        public void Retourner()
        {
            Visible = !Visible;
        }


    }
}
