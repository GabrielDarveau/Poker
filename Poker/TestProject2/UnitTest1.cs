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
            Carte[] main = new Carte[5];

            for (int i = 0; i < 5; i++)
            {
                main[i] = new Poker.Carte(Sorte.Carreau, (Valeur)i + 10);
            }


        }
    }
}