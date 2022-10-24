using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Paquet
    {
        //Attributs
        Carte[] cartes = new Carte[52];

        //Constructeur
        public Paquet()
        {
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cartes[index] = new Carte((Couleur)i, (Valeur)j);
                    index++;
                }
            }
        }

        //Fonctions
        public void Distribuer(Joueur j)
        {
            j.MaMain.cartes[];
        }

        public void Distribuer(Tour t)
        {

        }

        public void Reinitialiser()
        {
            cartes = new Carte[52];
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cartes[index] = new Carte((Couleur)i, (Valeur)j);
                    index++;
                }
            }
        }

        public void Brasser()
        {

        }

        public Carte GetTopCarte()
        {
            Carte laCarte = cartes[0];
            cartes = cartes.Skip(1).ToArray();
            return laCarte;
        }
    }
}
