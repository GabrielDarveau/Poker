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

        [TestMethod]
        public void TestStraightFlush()
        {
            Carte[] straightFlush = new Carte[5];
            Carte[] fausseStraightFlush = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            for (int i = 0; i < 5; i++)
            {
                straightFlush[i] = new Poker.Carte(Sorte.Carreau, (Valeur)i);
            }

            fausseStraightFlush[0] = new Carte(Sorte.Pique, Valeur.quatre);
            fausseStraightFlush[1] = new Carte(Sorte.Pique, Valeur.six);
            fausseStraightFlush[2] = new Carte(Sorte.Pique, Valeur.sept);
            fausseStraightFlush[3] = new Carte(Sorte.Pique, Valeur.huit);
            fausseStraightFlush[4] = new Carte(Sorte.Pique, Valeur.neuf);


            if (!main.IsStraightFlush(straightFlush))
            {
                Assert.Fail();
            }

            if (main.IsStraightFlush(fausseStraightFlush))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestStraight()
        {
            Carte[] straight = new Carte[5];
            Carte[] fausseStraight = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            for (int i = 0; i < 5; i++)
            {
                straight[i] = new Poker.Carte(Sorte.Carreau, (Valeur)i);
            }

            fausseStraight[0] = new Carte(Sorte.Pique, Valeur.quatre);
            fausseStraight[1] = new Carte(Sorte.Pique, Valeur.six);
            fausseStraight[2] = new Carte(Sorte.Pique, Valeur.sept);
            fausseStraight[3] = new Carte(Sorte.Pique, Valeur.huit);
            fausseStraight[4] = new Carte(Sorte.Pique, Valeur.neuf);


            if (!main.IsStraight(straight))
            {
                Assert.Fail();
            }

            if (main.IsStraight(fausseStraight))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFlush()
        {
            Carte[] flush = new Carte[5];
            Carte[] fausseFlush = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            for (int i = 0; i < 5; i++)
            {
                flush[i] = new Poker.Carte(Sorte.Carreau, (Valeur)i);
            }

            fausseFlush[0] = new Carte(Sorte.Carreau, Valeur.quatre);
            fausseFlush[1] = new Carte(Sorte.Pique, Valeur.six);
            fausseFlush[2] = new Carte(Sorte.Pique, Valeur.sept);
            fausseFlush[3] = new Carte(Sorte.Pique, Valeur.huit);
            fausseFlush[4] = new Carte(Sorte.Pique, Valeur.neuf);


            if (!main.IsFlush(flush))
            {
                Assert.Fail();
            }

            if (main.IsFlush(fausseFlush))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestPair()
        {
            Carte[] pair = new Carte[5];
            Carte[] faussePair = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            pair[0] = new Carte(Sorte.Carreau, Valeur.deux);
            pair[1] = new Carte(Sorte.Pique, Valeur.quatre);
            pair[2] = new Carte(Sorte.Treffle, Valeur.sept);
            pair[3] = new Carte(Sorte.Pique, Valeur.huit);
            pair[4] = new Carte(Sorte.Carreau, Valeur.huit);

            faussePair[0] = new Carte(Sorte.Carreau, Valeur.quatre);
            faussePair[1] = new Carte(Sorte.Pique, Valeur.six);
            faussePair[2] = new Carte(Sorte.Pique, Valeur.sept);
            faussePair[3] = new Carte(Sorte.Pique, Valeur.huit);
            faussePair[4] = new Carte(Sorte.Pique, Valeur.neuf);


            if (!main.IsPair(pair))
            {
                Assert.Fail();
            }

            if (main.IsPair(faussePair))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFourOfAKind()
        {
            Carte[] fourOAK = new Carte[5];
            Carte[] fausseFourOAK = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            fourOAK[0] = new Carte(Sorte.Coeur, Valeur.deux);
            fourOAK[1] = new Carte(Sorte.Pique, Valeur.deux);
            fourOAK[2] = new Carte(Sorte.Treffle, Valeur.deux);
            fourOAK[3] = new Carte(Sorte.Coeur, Valeur.A);
            fourOAK[4] = new Carte(Sorte.Carreau, Valeur.deux);

            fausseFourOAK[0] = new Carte(Sorte.Carreau, Valeur.quatre);
            fausseFourOAK[1] = new Carte(Sorte.Pique, Valeur.quatre);
            fausseFourOAK[2] = new Carte(Sorte.Treffle, Valeur.quatre);
            fausseFourOAK[3] = new Carte(Sorte.Coeur, Valeur.huit);
            fausseFourOAK[4] = new Carte(Sorte.Pique, Valeur.neuf);


            if (!main.IsFourOfAKind(fourOAK))
            {
                Assert.Fail();
            }

            if (main.IsFourOfAKind(fausseFourOAK))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            Carte[] threeOAK = new Carte[5];
            Carte[] fausseThreeOAK = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            threeOAK[0] = new Carte(Sorte.Carreau, Valeur.trois);
            threeOAK[1] = new Carte(Sorte.Pique, Valeur.deux);
            threeOAK[2] = new Carte(Sorte.Treffle, Valeur.deux);
            threeOAK[3] = new Carte(Sorte.Coeur, Valeur.A);
            threeOAK[4] = new Carte(Sorte.Carreau, Valeur.deux);

            fausseThreeOAK[0] = new Carte(Sorte.Carreau, Valeur.quatre);
            fausseThreeOAK[1] = new Carte(Sorte.Pique, Valeur.quatre);
            fausseThreeOAK[2] = new Carte(Sorte.Treffle, Valeur.cinq);
            fausseThreeOAK[3] = new Carte(Sorte.Coeur, Valeur.huit);
            fausseThreeOAK[4] = new Carte(Sorte.Pique, Valeur.neuf);

            if (!main.IsThreeOfAKind(threeOAK))
            {
                Assert.Fail();
            }

            if (main.IsThreeOfAKind(fausseThreeOAK))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFullHouse()
        {
            Carte[] fullHouse = new Carte[5];
            Carte[] fausseFullHouse = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            fullHouse[0] = new Carte(Sorte.Carreau, Valeur.A);
            fullHouse[1] = new Carte(Sorte.Pique, Valeur.deux);
            fullHouse[2] = new Carte(Sorte.Treffle, Valeur.deux);
            fullHouse[3] = new Carte(Sorte.Coeur, Valeur.A);
            fullHouse[4] = new Carte(Sorte.Carreau, Valeur.deux);

            fausseFullHouse[0] = new Carte(Sorte.Carreau, Valeur.quatre);
            fausseFullHouse[1] = new Carte(Sorte.Pique, Valeur.quatre);
            fausseFullHouse[2] = new Carte(Sorte.Treffle, Valeur.cinq);
            fausseFullHouse[3] = new Carte(Sorte.Coeur, Valeur.huit);
            fausseFullHouse[4] = new Carte(Sorte.Pique, Valeur.neuf);

            if (!main.IsFullHouse(fullHouse))
            {
                Assert.Fail();
            }

            if (main.IsFullHouse(fausseFullHouse))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestTwoPair()
        {
            Carte[] twoPair = new Carte[5];
            Carte[] fausseTwoPair = new Carte[5];

            MainJoueur main = new Poker.MainJoueur();

            twoPair[0] = new Carte(Sorte.Carreau, Valeur.A);
            twoPair[1] = new Carte(Sorte.Pique, Valeur.trois);
            twoPair[2] = new Carte(Sorte.Treffle, Valeur.deux);
            twoPair[3] = new Carte(Sorte.Coeur, Valeur.A);
            twoPair[4] = new Carte(Sorte.Carreau, Valeur.deux);

            fausseTwoPair[0] = new Carte(Sorte.Carreau, Valeur.quatre);
            fausseTwoPair[1] = new Carte(Sorte.Pique, Valeur.quatre);
            fausseTwoPair[2] = new Carte(Sorte.Treffle, Valeur.cinq);
            fausseTwoPair[3] = new Carte(Sorte.Coeur, Valeur.huit);
            fausseTwoPair[4] = new Carte(Sorte.Pique, Valeur.neuf);

            if (!main.IsTwoPair(twoPair))
            {
                Assert.Fail();
            }

            if (main.IsTwoPair(fausseTwoPair))
            {
                Assert.Fail();
            }
        }
    }
}