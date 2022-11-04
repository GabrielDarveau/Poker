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

        public bool IsStraightFlush(Carte[] mesCartes)
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
                if ((int)mesCartes[i].MaValeur != (int)mesCartes[i + 1].MaValeur - 1)
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

        public bool IsFourOfAKind(Carte[] mesCartes)
        {
            bool fourOAK = true;
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

            for (int i = 0; i < 3; i++)
            {
                if (mesCartes[i].MaValeur != mesCartes[i + 1].MaValeur)
                {
                    fourOAK = false;
                }
                else
                {
                    high = (int)mesCartes[i].MaValeur;
                }
            }

            if (!fourOAK)
            {
                fourOAK = true;
                for (int i = 1; i < 4; i++)
                {
                    if (mesCartes[i].MaValeur != mesCartes[i + 1].MaValeur)
                    {
                        fourOAK = false;
                    }
                    else
                    {
                        high = (int)mesCartes[i].MaValeur;
                    }
                }
            }

            if (!fourOAK)
            {
                high = 0;
            }
            return fourOAK;
        }

        public bool IsFullHouse(Carte[] mesCartes)
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

            List<Carte> pair = new List<Carte>();
            pair = mesCartes.ToList();

            for (int i = 1; i < 3; i++)
            {
                if (mesCartes[i].MaValeur == mesCartes[i - 1].MaValeur && mesCartes[i].MaValeur == mesCartes[i + 1].MaValeur)
                {
                    high = (int)mesCartes[i].MaValeur;

                    pair.RemoveAll(c => (int)c.MaValeur == high);

                    if (pair[0].MaValeur == pair[1].MaValeur)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsFlush(Carte[] mesCartes)
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

        public bool IsStraight(Carte[] mesCartes)
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
                if ((int)mesCartes[i].MaValeur != (int)mesCartes[i + 1].MaValeur - 1)
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

        public bool IsThreeOfAKind(Carte[] mesCartes)
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

            for (int i = 1; i < 3; i++)
            {
                if (mesCartes[i].MaValeur == mesCartes[i - 1].MaValeur && mesCartes[i].MaValeur == mesCartes[i + 1].MaValeur)
                {
                    high = (int)mesCartes[i].MaValeur;
                    return true;
                }
            }

            return false;
        }

        public bool IsTwoPair(Carte[] mesCartes)
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

            List<Carte> pair = new List<Carte>();
            pair = mesCartes.ToList();

            for (int i = 0; i < 4; i++)
            {
                if (mesCartes[i].MaValeur == mesCartes[i + 1].MaValeur)
                {
                    high = (int)mesCartes[i].MaValeur;

                    pair.RemoveAll(c => (int)c.MaValeur == high);

                    for (int j = 0; j < 2; j++)
                    {
                        if (pair[j].MaValeur == pair[j + 1].MaValeur)
                        {
                            if ((int)pair[j].MaValeur > high)
                            {
                                high = (int)pair[j].MaValeur;
                            }
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsPair(Carte[] mesCartes)
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

            for (int i = 0; i < 4; i++)
            {
                if (mesCartes[i].MaValeur == mesCartes[i + 1].MaValeur)
                {
                    high = (int)mesCartes[i].MaValeur;
                    return true;
                }
            }

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
