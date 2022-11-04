using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Joueur
    {
        // Attributs
        string Nom; 
        public string Pseudo { get; private set; }
        public int Argent { get; set; }
        public int MaMise { get; set; }
        public bool Actif { get; set; }
        public MainJoueur MaMain { get; private set; } = new MainJoueur();
        public bool AllIn { get; private set; } = false;

        //Constructeur
        public Joueur(string monNom, string monPseudo)
        {
            Nom = monNom;
            Pseudo = monPseudo;
            Argent = 100;
        }

        // Fonctions

        /// <summary>
        /// Permet au joueur de choisir les cartes à utiliser pour déterminer le gagnant et retourne 5 cartes
        /// </summary>
        /// <param name="cartesCommunes"></param>
        /// <returns></returns>
        public Carte[] ChoisirCartes(Carte[] cartesCommunes)
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

            Console.WriteLine("\n~~~~ Cartes de " + Pseudo + " ~~~~");
            MaMain.cartes[0].AfficherCarte(0, 13);
            MaMain.cartes[1].AfficherCarte(1, 13);

            //  Choisir 3 cartes communes
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    Console.Write("Choisir une " + (i + 1) + "eme carte commune(1-5) pour composer une main(5 cartes) avec vos deux cartes: ");
                    verif = int.TryParse(Console.ReadLine(), out carte);
                    carte--;
                } while (!verif || carte < 0 || carte > 4 || !cartesCommunes[carte].Visible);

                cartesChoisies[i] = cartesCommunes[carte];
                cartesCommunes[carte].Visible = false;
            }

            cartesChoisies[3] = MaMain.cartes[0];
            cartesChoisies[4] = MaMain.cartes[1];

            return cartesChoisies;
        }

        /// <summary>
        /// Call
        /// </summary>
        public void Call()
        {
            if (Argent < Tour.derniereMise)
            {
                MaMise = MaMise + Argent;
                Tour.SidePot = Tour.derniereMise - MaMise;
                Tour.Pot = Tour.Pot + Argent - Tour.SidePot;
                Argent = 0;
                AllIn = true;
            }
            else
            {
                Argent = Argent - (Tour.derniereMise - MaMise);
                Tour.Pot = Tour.Pot + (Tour.derniereMise - MaMise);
                MaMise = Tour.derniereMise;
            }
        }


        /// <summary>
        /// Se coucher
        /// </summary>
        public void Coucher()
        {
            Actif = false;
        }

        /// <summary>
        /// Raise
        /// </summary>
        public void Raise()
        {
            bool verif = false;
            int montant;

            if (Argent < Tour.derniereMise - MaMise)
            {
                Console.WriteLine("Vous ne pouvez pas relancer");
                ChoisirAction();
            }
            else
            {
                do
                {
                    Console.WriteLine("Entrer le montant à relancer");
                    verif = int.TryParse(Console.ReadLine() , out montant);

                } while (!verif || montant+MaMise < Tour.derniereMise || montant > Argent);

                MaMise = MaMise + montant;
                Tour.derniereMise = MaMise;
                Argent = Argent - montant;
                Tour.Pot = Tour.Pot + montant;
                AllIn = Argent == 0;
            }
        }

        /// <summary>
        /// Choisir une action valide
        /// </summary>
        public void ChoisirAction()
        {
            bool verif;
            char choix;
            do
            {
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~ Choisissez une action ~~~~~~~~");
                // Si le dernier joueur a augmenter la mise il  aura l'option de call
                if (Tour.derniereMise == MaMise)
                {
                    Console.WriteLine("A) Fold \t B) Raise \t C) Check");
                }
                else
                {
                    Console.WriteLine("A) Fold \t B) Raise \t C) Call");
                }

                verif = char.TryParse(Console.ReadLine().ToUpper(), out choix);

            } while (!verif || choix < 'A' || choix > 'E');

            switch (choix)
            {
                default:
                    break;
                case 'A':
                    Coucher();
                    break;
                case 'B':
                    Raise();
                    break;
                case 'C':
                    // check fait simplement passer au suivant sans miser
                    if (Tour.derniereMise > MaMise)
                    {
                        Call();
                    }
                    break;
            }
        }

        /// <summary>
        /// Affiche la main du joueur
        /// </summary>
        /// <param name="j"></param>
        public void AfficherMain(int j)
        {
            int pos;
            pos =  (12 * j) + 28;
            Console.WriteLine("~~~ Cartes de " + Pseudo +" ~~~");
            MaMain.cartes[0].AfficherCarte(0, pos);
            MaMain.cartes[1].AfficherCarte(1, pos);
        }

        /// <summary>
        /// Assigne une mise forcée de 2$ ou 4$ au  joueur
        /// </summary>
        /// <param name="blind"></param>
        public void Blind(int blind)
        {
            if (Argent < blind)
            {
                Tour.Pot = Tour.Pot + Argent;
                Tour.SidePot = Argent;
                MaMise = Argent;
                Argent = 0;
                AllIn = true;
                Tour.derniereMise = MaMise;
            }
            else
            {
                MaMise = blind;
                Argent = Argent - blind;
                Tour.Pot = Tour.Pot + blind;
                Tour.derniereMise = MaMise;
            }
        }

        /// <summary>
        /// Reset la mise du joueur et enlève le status all in
        /// </summary>
        public void ResetJoueur()
        {
            MaMise = 0;
            AllIn = false;
        }
    }
}
