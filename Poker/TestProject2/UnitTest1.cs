using System;
using Poker;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFlushRoyale()
        {
            Carte[] flushRoyale = new Carte[5];
            Carte[] fausseFlushRoyale = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            for (int i = 0; i < 5; i++)
            {
                flushRoyale[i] = new Poker.Carte(Sorte.Carreau, (Valeur)i + 8);
            }

            fausseFlushRoyale[0] = new Carte(Sorte.Pique, Valeur.cinq);
            fausseFlushRoyale[1] = new Carte(Sorte.Pique, Valeur.six);
            fausseFlushRoyale[2] = new Carte(Sorte.Pique, Valeur.sept);
            fausseFlushRoyale[3] = new Carte(Sorte.Pique, Valeur.huit);
            fausseFlushRoyale[4] = new Carte(Sorte.Pique, Valeur.neuf);


            if (!main.IsRoyalFlush(flushRoyale))
            {
                Assert.Fail();
            }

            if (main.IsRoyalFlush(fausseFlushRoyale))
            {
                Assert.Fail();
            }
        }
    }
}