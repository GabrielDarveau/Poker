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
        bool Actif;
        MainJoueur MaMain;

        //Constructeur
        public Joueur(string monNom, string monPseudo)
        {
            Nom = monNom;
            Pseudo = monPseudo;
            Argent = 100;
            Actif = false;
        }

        public void Miser(int montant)
        {
            Argent = Argent - montant;
            Tour.Pot = Tour.Pot + montant;
        }

        public void Check(int derniereMise)
        {
            
        }

        public void Call()
        {

        }

        public void Coucher()
        {

        }

        public void Raise(int montant)
        {

        }

        public void ResetMain()
        {

        }
    }
}
