using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class MainJoueur
    {
        //Attributs
        public Carte[] cartes { get; set; } = new Carte[2];
        public int Force { get; private set; } = 0;
        public int high { get; private set; } = 0;

        //Constructeur
        public MainJoueur()
        {

        }

        /// <summary>
        /// Calcule la force d'une main(de 1 à 10)
        /// </summary>
        /// <param name="mesCartes"></param>
        /// <returns></returns>
        public int CalculerForce(Carte[] mesCartes)
        {
            if (IsRoyalFlush(mesCartes))
            {
                Force = 10;
                return 10;
            }

            if (IsStraightFlush(mesCartes))
            {
                Force = 9;
                return 9;
            }

            if (IsFourOfAKind(mesCartes))
            {
                Force = 8;
                return 8;
            }

            if (IsFullHouse(mesCartes))
            {
                Force = 7;
                return 7;
            }

            if (IsFlush(mesCartes))
            {
                Force = 6;
                return 6;
            }

            if (IsStraight(mesCartes))
            {
                Force = 5;
                return 5;
            }

            if (IsThreeOfAKind(mesCartes))
            {
                Force = 4;
                return 4;
            }

            if (IsTwoPair(mesCartes))
            {
                Force = 3;
                return 3;
            }

            if (IsPair(mesCartes))
            {
                Force = 2;
                return 2;
            }

            if (IsHighCard(mesCartes))
            {
                Force = 1;
                return 1;
            }

            return 0;
        }

        public bool IsRoyalFlush(Carte[] mesCartes)
        {
            high = 0;
            Carte varTemp;

            // trie la main
            for (int i = 0; i <= mesCartes.Length - 1; i++)
            {
                for (int j = i + 1; j < mesCartes.Length; j++)
                {
                    if (mesCartes[i].MaValeur > mesCartes[j].MaValeur)
                    {
                        varTemp = mesCartes[i];
                        mesCartes[i] = mesCartes[j];
                        mesCartes[j] = varTemp;
                    }
                }
            }

            // détermine si toutes les cartes ont la meme sorte
            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaSorte != (int)mesCartes[i + 1].MaSorte)
                {
                    return false;
                }
            }

            // détermine si les cartes sont en suite
            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaValeur != (int)mesCartes[i + 1].MaValeur - 1)
                {
                    return false;
                }
            }

            // trouve la carte avec la plus haute valeur
            for (int i = 0; i < 5; i++)
            {
                if ((int)mesCartes[i].MaValeur > high)
                {
                    high = (int)mesCartes[i].MaValeur;
                }
            }

            // si la plus grande carte est un As, c'est une Royal flush
            if (high == 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsStraightFlush(Carte[] mesCartes)
        {
            high = 0;
            Carte varTemp;

            // Trie les cartes
            for (int i = 0; i <= mesCartes.Length - 1; i++)
            {
                for (int j = i + 1; j < mesCartes.Length; j++)
                {
                    if (mesCartes[i].MaValeur > mesCartes[j].MaValeur)
                    {
                        varTemp = mesCartes[i];
                        mesCartes[i] = mesCartes[j];
                        mesCartes[j] = varTemp;
                    }
                }
            }

            // détermine si toutes les cartes ont la meme sorte
            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaSorte != (int)mesCartes[i + 1].MaSorte)
                {
                    return false;
                }
            }

            // détermine si les cartes sont en suite
            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaValeur != (int)mesCartes[i + 1].MaValeur + 1)
                {
                    return false;
                }
            }

            // détermine la plus haute carte
            for (int i = 0; i < 5; i++)
            {
                if ((int)mesCartes[i].MaValeur > high)
                {
                    high = (int)mesCartes[i].MaValeur;
                }
            }

            return true;
        }

        private bool IsFourOfAKind(Carte[] mesCartes)
        {
            // pas encore implémenté
            return false;
        }

        private bool IsFullHouse(Carte[] mesCartes)
        {
            // pas encore implémenté
            return false;
        }

        private bool IsFlush(Carte[] mesCartes)
        {
            high = 0;

            // détermine si toutes les cartes ont la meme sorte
            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaSorte != (int)mesCartes[i + 1].MaSorte)
                {
                    return false;
                }
            }

            // trouve la plus haute carte
            for (int i = 0; i < 5; i++)
            {
                if ((int)mesCartes[i].MaValeur > high)
                {
                    high = (int)mesCartes[i].MaValeur;
                }
            }

            return true;
        }

        private bool IsStraight(Carte[] mesCartes)
        {
            high = 0;
            Carte varTemp;

            // trie les cartes
            for (int i = 0; i <= mesCartes.Length - 1; i++)
            {
                for (int j = i + 1; j < mesCartes.Length; j++)
                {
                    if (mesCartes[i].MaValeur > mesCartes[j].MaValeur)
                    {
                        varTemp = mesCartes[i];
                        mesCartes[i] = mesCartes[j];
                        mesCartes[j] = varTemp;
                    }
                }
            }

            // détermine si toutes les cartes sont en ordre
            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaValeur != (int)mesCartes[i + 1].MaValeur + 1)
                {
                    return false;
                }
            }

            // trouve la plus haute carte
            for (int i = 0; i < 5; i++)
            {
                if ((int)mesCartes[i].MaValeur > high)
                {
                    high = (int)mesCartes[i].MaValeur;
                }
            }

            return true;
        }

        private bool IsThreeOfAKind(Carte[] mesCartes)
        {
            // pas encore implémenté
            return false;
        }

        private bool IsTwoPair(Carte[] mesCartes)
        {
            // pas encore implémenté
            return false;
        }

        private bool IsPair(Carte[] mesCartes)
        {
            // pas encore implémenté
            return false;
        }

        private bool IsHighCard(Carte[] mesCartes)
        {
            // trouve la plus haute carte
            for (int i = 0; i < 5; i++)
            {
                if ((int)mesCartes[i].MaValeur > high)
                {
                    high = (int)mesCartes[i].MaValeur;
                }
            }

            return true;
        }
    }
}
