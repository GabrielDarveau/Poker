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
        Joueur[] joueurs = new Joueur[4];
        int IndiceJoueurCourrant { get; set; }
        Paquet LePaquet { get; set; }
        Tour TourActuel { get; set; }
        int EtatTour { get; set; }

        //Constructeur
        public Partie()
        {

        }

        //Fonctions
        public void JouerTour()
        {

        }

        public int GetGagnant(List<Joueur> joueurs)
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
