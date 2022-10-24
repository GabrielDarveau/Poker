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
            // Mettre les joueurs actifs
            TourActuel.ResetTour();

            // Brasser le paquet
            LePaquet.Brasser();

            // Distribuer les cartes aux joueurs
            foreach (Joueur j in this.joueurs)
            {
                LePaquet.Distribuer(j);
            }

            // Placer cartes communes
            LePaquet.Distribuer(TourActuel);

            // reseter le tour
            TourActuel.ResetTour();
            do
            {
                // Révéler cartes communes 
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

            } while (TourActuel.EtatTour < 5 && TourActuel.JoueursActifs(this.joueurs)); // Toutes les cartes ne sont pas révélés ou deux personnes misent encore

            // Montrer les cartes
            AfficherJeu();

            foreach (Joueur j in this.joueurs)
            {
                // Afficher la main du joueur
            }

            List<Joueur> joueurs = new List<Joueur>();

            foreach (Joueur j in joueurs)
            {
                if (j.Actif)
                {
                    joueurs.Add(j);
                }
            }

            // Déterminer le gagnant
            UpdateGagnant(GetGagnant(joueurs));

        }

        public Joueur GetGagnant(List<Joueur> joueurs)
        {

        }

        public void AfficherJeu()
        {

        }
        //Récupérer l'argent, sert à donner l'argent au gagnant
        public void UpdateGagnant(Joueur j)
        {

        }

        public bool FinPartie()
        {

        }

        public void AfficherCarte(Tour leTour)
        {

        }
        //Modifie le tour pour dire si nous sommes rendu à l'étape distribuer les cartes, de retourner les cartes, de déterminer qui est le gagnant
        public void UpdateEtatTour()
        {

        }
    }
}
