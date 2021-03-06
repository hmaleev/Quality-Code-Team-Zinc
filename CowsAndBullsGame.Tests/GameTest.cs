﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;
using System.Reflection;
using System.IO;

namespace cows_bulls.Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GamePlayTestChampion()
        {
            Game.numberGenerator = new Random(0);
            string num = "7261\nPlayer";
            Console.SetIn(new StringReader(num));

            Game.Play();
        }

        [TestMethod]
        public void GamePlayTestSecondGuess()
        {
            Game.numberGenerator = new Random(0);
            string num = "1235\n7261\nPlayer";
            Console.SetIn(new StringReader(num));

            Game.Play();
        }

        [TestMethod]
        public void GameTestCurrentHits()
        {
            PrivateType pr = new PrivateType(typeof(Game));
            pr.SetStaticFieldOrProperty("secretNumberAsString", "1234");
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Game.RevealCurrentHits("1234");
            var result = sw.ToString();
            var expected = String.Format("Wrong number! Bulls: 4, Cows: 0!{0}{0}",
                Environment.NewLine);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCountHits()
        {
            bool[] isBull = new bool[4];
            bool[] isCow = new bool[10];
            PrivateType pr = new PrivateType(typeof(Game));
            pr.SetStaticFieldOrProperty("secretNumberAsString", "1234");
            int bulls = Game.CountBulls("1234", 0, isBull);
            int cows = Game.CountCows("1234", 0, isBull, isCow);
            Assert.AreEqual(4, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void TestCountBulls()
        {
            bool[] isBull = new bool[4];
            PrivateType pr = new PrivateType(typeof(Game));
            pr.SetStaticFieldOrProperty("secretNumberAsString", "1234");
            int res = Game.CountBulls("1235", 0, isBull);
            Assert.AreEqual(3, res);
        }

        [TestMethod]
        public void TestCountCows()
        {
            bool[] isBull = new bool[4];
            bool[] isCow = new bool[10];
            PrivateType pr = new PrivateType(typeof(Game));
            pr.SetStaticFieldOrProperty("secretNumberAsString", "1234");
            int res = Game.CountCows("4321", 0, isBull, isCow);
            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void TestInvalidInputCommand()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            string command = "exit2";
            ConsolePrinter.PrintInvalidCommandMessage();
            string expected = sw.ToString();
            sw.Dispose();
            StringWriter sw2 = new StringWriter();
            Console.SetOut(sw2);
            Game.ProcessTextCommand(command);
            string result = sw2.ToString();
            sw2.Dispose();
            Assert.AreEqual(expected, result);
        }
    }
}
