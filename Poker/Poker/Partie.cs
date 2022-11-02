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

            int depart = TourActuel.bigBlind;
            
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
                int joueursAyantJoue = 0;
                do
                {
                    for (int i = depart; i < joueurs.Length; i++)
                    {
                        if (joueurs[i].Actif && !TourActuel.FinMises(this.joueurs, joueursAyantJoue))
                        {
                            // Afficher les cartes communes, les mises et l'argent restant des joueurs
                            AfficherJeu();

                            // Afficher les cartes du joueur
                            joueurs[i].AfficherMain(0);

                            // Prendre mise
                            joueurs[i].ChoisirAction();
                            joueursAyantJoue++;
                        }
                    }
                    depart = 0;

                } while (TourActuel.JoueursActifs(this.joueurs) >= 2 && !TourActuel.FinMises(this.joueurs, joueursAyantJoue)); // Les joueurs misent encore

            } while (TourActuel.EtatTour < 4 && TourActuel.JoueursActifs(this.joueurs) >= 2); // Toutes les cartes ne sont pas révélés ou deux personnes misent encore

            // Montrer les cartes
            AfficherJeu();

            for (int i = 0; i < 4; i++)
            {
                joueurs[i].AfficherMain(i);
                Console.WriteLine();
            }
            

            List<Joueur> joueursActifs = new List<Joueur>();

            foreach (Joueur j in joueurs)
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
            int gagnant;
            bool verif;

            do
            {
                Console.Write("Qui a gagné?: ");
                verif = int.TryParse(Console.ReadLine(), out gagnant);
            } while (!verif || gagnant > joueursActifs.Count() || gagnant < 0);
            
            return joueursActifs[gagnant];
        }

        public void AfficherJeu()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~ Cartes communes ~~~~~~");
            AfficherCarte(TourActuel);
            Console.WriteLine("\n~~~~ Mises actuelles ~~~~");
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Mise de {0}: {1:C}", joueurs[i].Pseudo, joueurs[i].MaMise);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Argent restant de {0}: {1:C}", joueurs[i].Pseudo, joueurs[i].Argent);
            }
            Console.WriteLine();

            Console.WriteLine("Pot: {0:C}", Tour.Pot);
            Console.WriteLine();
        }
        //Récupérer l'argent, sert à donner l'argent au gagnant
        public void UpdateGagnant(Joueur j)
        {
            j.Argent = j.Argent + Tour.Pot;
        }

        public bool FinPartie()
        {
            bool verif = false;
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous continuer ? O/N");
                rep = Console.ReadLine().ToUpper();
                if(rep == "O")
                {
                    return true;
                }
                else if(rep == "N")
                {
                    return false;
                }
            } while (!(rep == "O" && rep == "N"));
            return verif;
        }

        public void AfficherCarte(Tour leTour)
        {
            for(int i = 0; i < 5; i++)
            {
                leTour.carteCommunes[i].AfficherCarte(i, 2);

            }
        }
        //Modifie le tour pour dire si nous sommes rendu à l'étape distribuer les cartes, de retourner les cartes, de déterminer qui est le gagnant
        public void UpdateEtatTour()
        {

        }
    }
}
