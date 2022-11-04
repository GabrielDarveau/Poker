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
        public Paquet LePaquet { get; private set; }
        public Tour TourActuel { get; private set; } = new Tour();
        public Joueur LeGagnant { get; private set; }

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

            // Distribuer les cartes aux joueurs
            foreach (Joueur j in this.joueurs)
            {
                LePaquet.Distribuer(j);
            }

            // Placer cartes communes
            LePaquet.Distribuer(TourActuel);

            // reseter le tour
            TourActuel.ResetTour(this);

            //distribuer les blinds
            joueurs[TourActuel.smallBlind - 1].Blind(2);
            joueurs[TourActuel.bigBlind - 1].Blind(4);

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
                        if (joueurs[i].Actif && !TourActuel.IsFinMises(this.joueurs, joueursAyantJoue) && !joueurs[i].AllIn)
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

                } while (TourActuel.GetNbJoueursActifs(this.joueurs) >= 2 && !TourActuel.IsFinMises(this.joueurs, joueursAyantJoue)); // Les joueurs misent encore

            } while (TourActuel.EtatTour < 4 && TourActuel.GetNbJoueursActifs(this.joueurs) >= 2); // Toutes les cartes ne sont pas révélés ou deux personnes misent encore

            if (joueurs[0].AllIn && joueurs[1].AllIn && joueurs[2].AllIn && joueurs[2].AllIn)
            {
                TourActuel.carteCommunes[3].Visible = true;
                TourActuel.carteCommunes[4].Visible = true;
            }

            // Montrer les cartes
            AfficherJeu();

            // afficher les main des joueurs
            for (int i = 0; i < 4; i++)
            {
                joueurs[i].AfficherMain(i);
                Console.WriteLine();
            }
            
            // faire une liste de tous les joueurs acrifs (qui peuvent donc gagner)
            List<Joueur> joueursActifs = new List<Joueur>();

            foreach (Joueur j in joueurs)
            {
                if (j.Actif)
                {
                    joueursActifs.Add(j);
                }
            }

            // Déterminer le gagnant
            LeGagnant = GetGagnant(joueursActifs);
            UpdateGagnant(LeGagnant);

            LePaquet.Reinitialiser();
        }

        /// <summary>
        /// Détermine le gagnant parmi  une liste de joueurs
        /// </summary>
        /// <param name="joueursActifs"></param>
        /// <returns></returns>
        public Joueur GetGagnant(List<Joueur> joueursActifs)
        {
            int gagnant;
            int force;
            int meilleureForce = 0; //index du joueur
            int meilleureForceEgale = 0; //index du joueur
            string rep;
            bool verif;


            if (joueursActifs.Count() > 1) // Déterminer le gagnant
            {
                do
                {
                    Console.Write("Voulez-vous choisir le gagnant manuellement ? O/N: ");
                    rep = Console.ReadLine().ToUpper();
                } while (!(rep == "O" || rep == "N"));
                Console.WriteLine();

                if (rep == "O") //  Choisir le gagnant manuellement
                {
                    do
                    {
                        for (int i = 0; i < joueursActifs.Count(); i++)
                        {
                            Console.Write((i + 1)+") " + joueursActifs[i].Pseudo+"\t");
                        }
                        Console.WriteLine();

                        Console.Write("Qui a gagné?: ");
                        verif = int.TryParse(Console.ReadLine(), out gagnant);
                    } while (!verif || gagnant > joueursActifs.Count() || gagnant < 1);
                    gagnant--;
                }
                else
                {
                    for (int i = 0; i < joueursActifs.Count(); i++)
                    {
                        force = joueursActifs[i].MaMain.CalculerForce(joueursActifs[i].ChoisirCartes(TourActuel.carteCommunes));
                        if (force > joueursActifs[meilleureForce].MaMain.Force)
                        {
                            meilleureForce = i;
                        }
                        else
                        {
                            if (force == joueursActifs[meilleureForce].MaMain.Force && i > 0)
                            {
                                meilleureForceEgale = i;
                            }
                        }
                    }

                    if (meilleureForceEgale > 0)
                    {
                        if (joueursActifs[meilleureForce].MaMain.high > joueursActifs[meilleureForceEgale].MaMain.high)
                        {
                            gagnant = meilleureForce;
                        }
                        else
                        {
                            gagnant = meilleureForceEgale;
                        }
                    }
                    else
                    {
                        gagnant = meilleureForce;
                    }


                }
            }
            else
            {
                gagnant = 0;
            }
                

            return joueursActifs[gagnant];
        }

        /// <summary>
        /// Affiche le jeu
        /// </summary>
        public void AfficherJeu()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~ Cartes communes ~~~~~~");
            AfficherCarte(TourActuel);
            Console.WriteLine("\n~~~~ Mises actuelles ~~~~");
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Mise de {0}: {1:C} {2} {3}", joueurs[i].Pseudo, joueurs[i].MaMise, joueurs[i].Actif ? "" : "\tCouché", joueurs[i].AllIn ? "\tAll in" : "");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Argent restant de {0}: {1:C}", joueurs[i].Pseudo, joueurs[i].Argent);
            }
            Console.WriteLine();

            Console.WriteLine("Pot: {0:C}", Tour.Pot);
            if (Tour.SidePot >0)
            {
                Console.WriteLine("Side Pot: {0:C}", Tour.SidePot);
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Distibue l'argent au gagnant
        /// </summary>
        /// <param name="j"></param>
        public void UpdateGagnant(Joueur j)
        {
            bool side = false;
            int joueursActifs = TourActuel.GetNbJoueursActifs(this.joueurs);
            if (joueursActifs > 0)
            {
                if (side = j.MaMise > Tour.Pot / TourActuel.GetNbJoueursActifs(this.joueurs))
                {
                    j.Argent = j.Argent + Tour.Pot + Tour.SidePot;
                }
                else
                {
                    j.Argent = j.Argent + Tour.Pot;
                }
            }
            else if(joueursActifs == 0 && j.AllIn)
            {
                j.Argent = j.Argent + Tour.Pot + Tour.SidePot;
            }
            else
            {
                j.Argent = j.Argent + Tour.Pot;
            }

        }

        /// <summary>
        /// Affichage de fin de partie
        /// </summary>
        /// <param name="leGagnant"></param>
        /// <returns></returns>
        public bool FinPartie(Joueur leGagnant)
        {
            // faire condition de fin partie si tout le monde a 0$ sinon boucle infinie
            bool verif = false;
            bool isFin = false;
            string rep;

            do
            {
                Console.WriteLine("Voulez-vous continuer ? O/N");
                rep = Console.ReadLine().ToUpper();
            } while (rep != "O" && rep != "N");

            foreach (Joueur j in joueurs)
            {
                if (j.Argent == 400)
                {
                    isFin = true;
                }
            }

            if (rep == "O" && !isFin)
            {
                return true;
            }
            else if (rep == "N" || isFin)
            {
                Console.Clear();
                Console.WriteLine("Félicitations "+leGagnant.Pseudo+", vous avez remporté la partie!!!");
                Console.WriteLine("Votre montant final est de {0:C}",leGagnant.Argent);
                Console.WriteLine();
                Console.Write("Appuyer sur une touche pour arrêter le jeu...");
                Console.ReadKey();

                return false;
            }

            return verif;
        }

        /// <summary>
        /// Afficher les cartes communes
        /// </summary>
        /// <param name="leTour"></param>
        public void AfficherCarte(Tour leTour)
        {
            for(int i = 0; i < 5; i++)
            {
                leTour.carteCommunes[i].AfficherCarte(i, 2);

            }
        }
    }
}
