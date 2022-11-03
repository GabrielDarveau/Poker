using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Executer();
        }

        static void Executer()
        {
            Partie laPartie = new Partie(CreerJoueur());

            do
            {
                laPartie.JouerTour();
            } while (laPartie.FinPartie(laPartie.LeGagnant)); // Tous les joueurs veulent continuer

            // Partie terminée afficher résultats

        }

        static Joueur[] CreerJoueur()
        {
            Joueur[] joueurs = new Joueur[4];
            string nom, pseudo;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.Clear();
                    Console.Write("Entrer le nom du joueur "+(i + 1)+": ");
                    nom = Console.ReadLine();

                    Console.Write("Entrer le pseudo du joueur " + (i + 1) + ": ");
                    pseudo = Console.ReadLine();

                } while (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(pseudo));
                joueurs[i] = new Joueur(nom, pseudo);
            }
            return joueurs;
        }


    }
}
