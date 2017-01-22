using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dice_Roller.RandomProvider;
using Dice_Roller;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class RandomProviderTests
    {
        const int AMOUNT = 10;
        const int FROM = 5;
        const int TO = 10;

        [TestMethod]
        public void TestSystemProvider()
        { 
            IRandomProvider provider = new SystemRandom();
            int number = provider.RandomNumberAsync(FROM, TO).Result;
            Trace.Write($"{number <= TO} : {number} <= {TO}\t");
            Assert.IsTrue(number <= TO);
            Trace.WriteLine($"{number >= FROM} : {number} >= {FROM}");
            Assert.IsTrue(number >= FROM);
        }

        [TestMethod]
        public void TestSystemProviderAmount()
        {
            IRandomProvider provider = new SystemRandom();
            var numbers = provider.RandomNumberAsync(FROM, TO, AMOUNT).Result;
            foreach(var number in numbers)
            {
                Trace.Write($"{number <= TO} : {number} <= {TO}\t");
                Assert.IsTrue(number <= TO);
                Trace.WriteLine($"{number >= FROM} : {number} >= {FROM}");
                Assert.IsTrue(number >= FROM);
            }   
        }

        [TestMethod]
        public void TestRandomOrgProvider()
        {
            IRandomProvider provider = new RandomOrgProvider();
            var task = provider.RandomNumberAsync(FROM, TO);
            int number = task.Result;
            Trace.Write($"{number <= TO} : {number} <= {TO}\t");
            Assert.IsTrue(number <= TO);
            Trace.WriteLine($"{number >= FROM} : {number} >= {FROM}");
            Assert.IsTrue(number >= FROM);
        }

        [TestMethod]
        public void TestRandomOrgProviderAmount()
        {
            IRandomProvider provider = new RandomOrgProvider();
            var task = provider.RandomNumberAsync(FROM, TO, AMOUNT);
            var numbers = task.Result;
            foreach (var number in numbers)
            {
                Trace.Write($"{number <= TO} : {number} <= {TO}\t");
                Assert.IsTrue(number <= TO);
                Trace.WriteLine($"{number >= FROM} : {number} >= {FROM}");
                Assert.IsTrue(number >= FROM);
            }
        }

    }
}
