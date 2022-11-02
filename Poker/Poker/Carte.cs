using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Poker
{
    enum Valeur
    {
        deux,
        trois,
        quatre,
        cinq,
        six,
        sept,
        huit,
        neuf,
        dix,
        J,
        Q,
        K,
        A
    }

    enum Sorte
    {
        Coeur,
        Pique,
        Carreau,
        Treffle
    }

    internal class Carte
    {
        //Variables
        Sorte MaSorte;
        Valeur MaValeur;
        public bool Visible { get; set; }

        //Constructeur
        public Carte(Sorte Sorte, Valeur valeur)
        {
            MaSorte = Sorte;
            MaValeur = valeur;
            Visible = false;
        }

        //Fonctions
        //public int  ComparerCarte(Carte carteAComparer)
        //{

        //}

        public void AfficherCarte(int positionX, int positionY)
        {
            string v;
            char s;


            if (Visible)
            {
                switch (MaSorte)
                {
                    case Sorte.Coeur:
                        s = (char)3;
                        break;
                    case Sorte.Pique:
                        s = (char)6;
                        break;
                    case Sorte.Carreau:
                        s = (char)4;
                        break;
                    case Sorte.Treffle:
                        s = (char)5;
                        break;
                    default:
                        s = 'X';
                        break;
                }

                switch (MaValeur)
                {
                    case Valeur.deux:
                        v = "2 ";
                        break;
                    case Valeur.trois:
                        v = "3 ";
                        break;
                    case Valeur.quatre:
                        v = "4 ";
                        break;
                    case Valeur.cinq:
                        v = "5 ";
                        break;
                    case Valeur.six:
                        v = "6 ";
                        break;
                    case Valeur.sept:
                        v = "7 ";
                        break;
                    case Valeur.huit:
                        v = "8 ";
                        break;
                    case Valeur.neuf:
                        v = "9 ";
                        break;
                    case Valeur.dix:
                        v = "10";
                        break;
                    default:
                        v = MaValeur.ToString()+" ";
                        break;
                }
                Console.SetCursorPosition(positionX*11, positionY);
                Console.WriteLine("┌─────────┐");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│ "+v+"      │");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│         │");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│         │");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│    "+s+"    │");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│         │");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│         │");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│       "+v+"│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("└─────────┘");
            }
            else
            {
                Console.SetCursorPosition(positionX * 11, positionY);
                Console.WriteLine("┌─────────┐");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│░░░░░░░░░│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│░░░░░░░░░│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│░░░░░░░░░│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│░░░░░░░░░│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│░░░░░░░░░│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│░░░░░░░░░│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("│░░░░░░░░░│");
                Console.SetCursorPosition(positionX * 11, ++positionY);
                Console.WriteLine("└─────────┘");
            }
        }

    }
}
