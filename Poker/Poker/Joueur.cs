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
        public int mise { get; set; }
        public bool Actif { get; set; }
        public MainJoueur MaMain { get; private set; }

        //Constructeur
        public Joueur(string monNom, string monPseudo)
        {
            Nom = monNom;
            Pseudo = monPseudo;
            Argent = 100;
        }

        public void Miser(int montant)
        {
            Argent = Argent - montant;
            Tour.Pot = Tour.Pot + montant;
        }

        public void Check()
        {
            
        }

        public void Call()
        {

        }

        public void Coucher()
        {
            Actif = false;
        }

        public void Raise(int montant)
        {

        }

        public void ResetMain()
        {

        }

        public void GetAction()
        {
            
        }

        public void AfficherMain()
        {
            Console.WriteLine("Cartes de "+ Pseudo + ": "+ MaMain.cartes[0].AfficherCarte()+" et "+ MaMain.cartes[1].AfficherCarte());
        }
    }
}
