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
        string Pseudo;
        int Argent;
        public int MaMise { get; set; }
        public bool Actif { get; set; }
        public MainJoueur MaMain { get; private set; }
        public bool AllIn { get; private set; } = false;

        //Constructeur
        public Joueur(string monNom, string monPseudo)
        {
            Nom = monNom;
            Pseudo = monPseudo;
            Argent = 100;
        }

        public void Call()
        {
            if (Argent < Tour.derniereMise)
            {
                Tour.Pot = Tour.Pot + Argent;
                Tour.SidePot = Argent;
                MaMise = Argent;
                Argent = 0;
                AllIn = true;
            }
            else
            {
                Argent = Argent - (Tour.derniereMise - MaMise);
                MaMise = Tour.derniereMise;
                Tour.Pot = Tour.Pot + Tour.derniereMise;
            }
        }

        public void Coucher()
        {
            Actif = false;
        }

        public void Raise()
        {
            bool verif = false;
            int montant;

            if (Argent <= Tour.derniereMise)
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

                } while (!verif || montant < Tour.derniereMise || montant > Argent);

                Tour.derniereMise = montant;
                MaMise = montant;
                Argent = Argent - montant;
                Tour.Pot = Tour.Pot + montant;
                AllIn = Argent == 0;
            }
        }

        public void ResetMain()
        {

        }

        public void ChoisirAction()
        {
            bool verif;
            char choix;
            do
            {
                Console.WriteLine("~~~~ Choisissez une action ~~~~");
                if (Tour.derniereMise > MaMise && Argent > 0)
                {
                    Console.WriteLine("A) Fold \t B) Raise \t C) Call");
                }
                else
                {
                    Console.WriteLine("A) Fold \t B) Raise \t C) Check");
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
                    if (Tour.derniereMise > MaMise)
                    {
                        Call();
                    }
                    break;
            }
        }

        public void AfficherMain()
        {
            Console.WriteLine("Cartes de " + Pseudo + ": " + MaMain.cartes[0].AfficherCarte() + " et " + MaMain.cartes[1].AfficherCarte());
        }
    }
}
