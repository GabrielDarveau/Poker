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
                // Mettre les joueurs actifs
                laPartie.TourActuel.ResetTour();

                // Brasser le paquet
                laPartie.LePaquet.Brasser();

                // Distribuer les cartes aux joueurs
                foreach (Joueur j in laPartie.joueurs)
                {
                    laPartie.LePaquet.Distribuer(j);
                }

                // Placer cartes communes
                laPartie.LePaquet.Distribuer(laPartie.TourActuel);

                // reseter le tour
                laPartie.TourActuel.ResetTour();
                do
                {
                    // Révéler cartes communes 
                    laPartie.TourActuel.ChangerEtat();

                    do
                    {
                        // Afficher les cartes communes
                        laPartie.AfficherJeu();

                        // Prendre mise


                    } while (laPartie.TourActuel.JoueursActifs(laPartie) && ); // Les joueurs misent encore

                } while (laPartie.TourActuel.EtatTour < 5 && laPartie.TourActuel.JoueursActifs(laPartie)); // Toutes les cartes ne sont pas révélés ou deux personnes misent encore

                // Montrer les cartes

                // Déterminer le gagnant

                // Donner argent au gagnant

            } while (true); // Tous les joueurs veulent continuer

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
                    Console.Write("Entrer le nom du joueur "+i);
                    nom = Console.ReadLine();

                    Console.Write("Entrer le pseudo du joueur " + i);
                    pseudo = Console.ReadLine();

                } while (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(pseudo));
                joueurs[i] = new Joueur(nom, pseudo);
            }
            return joueurs;
        }


    }
}
