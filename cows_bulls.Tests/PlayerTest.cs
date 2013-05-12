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
            Assert.AreEqual(player.Nickname, String.Empty);
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
    }
}
