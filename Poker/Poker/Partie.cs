using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Partie
    {
        //Attributs
        public Joueur[] joueurs { get;  private set; } = new Joueur[4];
        int IndiceJoueurCourrant { get; set; }
        public Paquet LePaquet { get; private set; }
        public Tour TourActuel { get; private set; } = new Tour();
        int EtatTour { get; set; }

        //Constructeur
        public Partie(Joueur[] lesJoueurs)
        {
            joueurs = lesJoueurs;
            LePaquet = new Paquet();
        }

        //Fonctions
        public void JouerTour()
        {
            // Brasser le paquet
            LePaquet.Brasser();

            for (int i = 0; i < joueurs.Length; i++)
            {
                joueurs[i].ResetJoueur();
            }

            joueurs[TourActuel.smallBlind].Blind(2);
            joueurs[TourActuel.bigBlind].Blind(4);

            // Distribuer les cartes aux joueurs
            foreach (Joueur j in this.joueurs)
            {
                LePaquet.Distribuer(j);
            }

            // Placer cartes communes
            LePaquet.Distribuer(TourActuel);

            // reseter le tour
            TourActuel.ResetTour(this);

            do
            {
                // Révéler les cartes communes
                if (TourActuel.EtatTour == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        TourActuel.carteCommunes[i].Visible = true;
                    }
                }

                if (TourActuel.EtatTour == 2)
                {
                    TourActuel.carteCommunes[3].Visible = true;
                }

                if (TourActuel.EtatTour == 3)
                {
                    TourActuel.carteCommunes[4].Visible = true;
                }

                TourActuel.ChangerEtat();

                do
                {
                    foreach (Joueur j in this.joueurs)
                    {
                        if (j.Actif)
                        {
                            // Afficher les cartes communes, les mises et l'argent restant des joueurs
                            AfficherJeu();

                            // Afficher les cartes du joueur
                            j.AfficherMain();

                            // Prendre mise
                            j.ChoisirAction();

                        }
                    }


                } while (TourActuel.JoueursActifs(this.joueurs) && TourActuel.FinMises(this.joueurs)); // Les joueurs misent encore

            } while (TourActuel.EtatTour < 4 && TourActuel.JoueursActifs(this.joueurs)); // Toutes les cartes ne sont pas révélés ou deux personnes misent encore

            // Montrer les cartes
            AfficherJeu();

            foreach (Joueur j in this.joueurs)
            {
                j.AfficherMain();
                Console.WriteLine();
            }

            List<Joueur> joueursActifs = new List<Joueur>();

            foreach (Joueur j in joueursActifs)
            {
                if (j.Actif)
                {
                    joueursActifs.Add(j);
                }
            }

            // Déterminer le gagnant
            UpdateGagnant(GetGagnant(joueursActifs));

        }

        public Joueur GetGagnant(List<Joueur> joueursActifs)
        {
            Random rnd = new Random();
            return joueursActifs[rnd.Next(joueursActifs.Count)];
        }

        public void AfficherJeu()
        {
            Console.Clear();
            Console.WriteLine("*** État de la partie ***");
            AfficherCarte(TourActuel);
            Console.WriteLine("\n\nLes mises actuelles:");
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Mise joueur {0}: {1:C}", joueurs[i].Pseudo, joueurs[i].MaMise);
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Argent restant du joueur {0}: {1:C}", joueurs[i].Pseudo, joueurs[i].Argent);
            }
            Console.WriteLine();
        }
        //Récupérer l'argent, sert à donner l'argent au gagnant
        public void UpdateGagnant(Joueur j)
        {
            j.Argent = Tour.Pot;
        }

        public bool FinPartie()
        {
            
        }

        public void AfficherCarte(Tour leTour)
        {
            for(int i = 0; i < 5; i++)
            {
                if (leTour.carteCommunes[i].Visible)
                {
                    Console.Write(leTour.carteCommunes[i].AfficherCarte()+" ");
                }
                else
                {
                    Console.Write("Carte non visible ");
                }
            }
        }
        //Modifie le tour pour dire si nous sommes rendu à l'étape distribuer les cartes, de retourner les cartes, de déterminer qui est le gagnant
        public void UpdateEtatTour()
        {

        }
    }
}
