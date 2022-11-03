﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class MainJoueur
    {
        //Attributs
        public Carte[] cartes { get; set; } = new Carte[2];
        public int Force { get; private set; } = 0;
        public int high { get; private set; } = 0;

        //Constructeur
        public MainJoueur()
        {

        }

        private Carte[] ChoisirCartes(Carte[] cartesCommunes)
        {
            bool verif;
            int carte;
            Carte[] cartesChoisies = new Carte[5];

            Console.Clear();

            foreach (Carte c in cartesCommunes)
            {
                c.Visible = true;
            }

            Console.WriteLine("~~~~ Cartes communes ~~~~");
            for (int i = 0; i < 5; i++)
            {
                cartesCommunes[i].AfficherCarte(i, 2);
            }

            Console.WriteLine("\n~~~~ Vos cartes ~~~~");
            cartes[0].AfficherCarte(0, 10);
            cartes[1].AfficherCarte(1, 10);

            for (int i = 0; i < 3; i++)
            {
                do
                {
                    Console.Write("Choisir une carte commune(1-5) pour composer une main(5 cartes) avec vos cartes: ");
                    verif = int.TryParse(Console.ReadLine(), out carte);
                    carte--;
                } while (!verif || carte < 0 || carte > 6 || !cartesCommunes[carte].Visible);
                cartesChoisies[i] = cartesCommunes[carte];
            }

            cartesChoisies[3] = cartes[0];
            cartesChoisies[4] = cartes[1];

            return cartesChoisies;
        }

        public int CalculerForce(Carte[] cartesCommunes)
        {
            Carte[] mesCartes = ChoisirCartes(cartesCommunes);

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

        private bool IsRoyalFlush(Carte[] mesCartes)
        {
            return false;
        }

        private bool IsStraightFlush(Carte[] mesCartes)
        {
            high = 0;
            Sorte PremiereSorte = Sorte.Carreau;
            bool isStraightFlush = true;
            Array.Sort(mesCartes);

            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaSorte != (int)mesCartes[i + 1].MaSorte)
                {
                    return false;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if ((int)mesCartes[i].MaValeur != (int)mesCartes[i + 1].MaValeur + 1)
                {
                    return false;
                }
            }


            if (isStraightFlush)
            {
                for (int i = 0; i < 5; i++)
                {
                    if ((int)mesCartes[i].MaValeur > high)
                    {
                        high = (int)mesCartes[i].MaValeur;
                    }
                }
            }

            return isStraightFlush;
        }

        private bool IsFourOfAKind(Carte[] mesCartes)
        {
            int pareils;

            for (int i = 0; i < 5; i++)
            {

            }
            return false;
        }

        private bool IsFullHouse(Carte[] mesCartes)
        {
            return false;
        }

        private bool IsFlush(Carte[] mesCartes)
        {
            high = 0;
            Sorte PremiereSorte = Sorte.Carreau;
            bool isFlush = true;

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    PremiereSorte = mesCartes[i].MaSorte;
                }

                if (PremiereSorte != mesCartes[i].MaSorte)
                {
                    return false;
                } 
            }

            if (isFlush)
            {
                for (int i = 0; i < 5; i++)
                {
                    if ((int)mesCartes[i].MaValeur > high)
                    {
                        high = (int)mesCartes[i].MaValeur;
                    }
                }
            }

            return isFlush;
        }

        private bool IsStraight(Carte[] mesCartes)
        {
            return false;
        }

        private bool IsThreeOfAKind(Carte[] mesCartes)
        {
            return false;
        }

        private bool IsTwoPair(Carte[] mesCartes)
        {
            return false;
        }

        private bool IsPair(Carte[] mesCartes)
        {
            return false;
        }

        private bool IsHighCard(Carte[] mesCartes)
        {
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
