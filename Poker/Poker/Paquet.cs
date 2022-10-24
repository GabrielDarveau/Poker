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
            j.MaMain.cartes[0] = GetTopCarte();
            j.MaMain.cartes[1] = GetTopCarte();
        }

        public void Distribuer(Tour t)
        {
            /*  Pour toutes les cartes communes
             *      Obtenir la carte du dessus
             */
            for(int i = 0; i < 5; i++)
            {
                t.carteCommunes[i] = GetTopCarte();
            }
        }

        public void Reinitialiser()
        {
            //Instancier un nouveau paquet de 52 cartes
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
            //Variable aléatoire pour obtenir carte aléatoire
            //Pour toute la longueur du paquet
            //  Obtenir un chiffre aléatoire disponible
            //  Stocker une carte dans une variable temporaire
            //  Changer la carte pour la carte obtenue aléatoirement
            //  Mettre l'ancienne carte à la place de la carte obtenue aléatoirement
            Random random = new Random();
            for (int i = 0; i < cartes.Length; i++)
            {
                int j = random.Next(i, cartes.Length); 
                var temp = cartes[i];
                cartes[i] = cartes[j];
                cartes[j] = temp;
            }
        }

        public Carte GetTopCarte()
        {
            Carte laCarte = cartes[0];
            cartes = cartes.Skip(1).ToArray();
            return laCarte;
        }
    }
}
