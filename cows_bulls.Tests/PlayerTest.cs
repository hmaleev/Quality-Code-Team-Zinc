using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace cows_bulls.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestNickname()
        {
            Player player = new Player("pesho", 10);
            Assert.AreEqual(player.Nickname, "pesho");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyNickName()
        {
            Player player = new Player("", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullNickname()
        {
            Player player = new Player(null, 0);
        }

        [TestMethod]
        public void TestScore()
        {
            Player player = new Player("pesho", 10);
            Assert.AreEqual(player.Score, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNullScore()
        {
            Player player = new Player("pesho", -10000);
        }

        [TestMethod]
        public void TestCompareToSmaller()
        {
            Player player1 = new Player("player1", 999);
            Player player2 = new Player("player2", 1000);
            int result = player1.CompareTo(player2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestCompareToBigger()
        {
            Player player1 = new Player("player1", 1000);
            Player player2 = new Player("player2", 999);
            int result = player1.CompareTo(player2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestCompareToWithSameScore()
        {
            Player player1 = new Player("player1", 1000);
            Player player2 = new Player("player2", 1000);
            int result = player1.CompareTo(player2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestToString()
        {
            Player player = new Player("player", 10);
            string expected = " 10 | player";
            string result = player.ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
