using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using BullsAndCows;

namespace cows_bulls.Tests
{
    [TestClass]
    public class ConsolePrinterTest
    {

        [TestMethod]
        public void TestEnterGuessMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsolePrinter.PrintEnterGuessMessage();
                string expected = string.Format("Enter your guess or command: ");
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestInvalidNumberMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsolePrinter.PrintInvalidNumberMessage();
                string expected = string.Format("You have entered an invalid number!{0}{1}",
                                                Environment.NewLine,Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestInvalidCommandMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsolePrinter.PrintInvalidCommandMessage();
                string expected = string.Format("You have entered an invalid command!{0}{1}",
                                                Environment.NewLine, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestByeMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsolePrinter.PrintByeMessage();
                string expected = string.Format("Good bye!{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestNotAllowedMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsolePrinter.PrintNotAllowedMessage();
                string expected = string.Format("You are not allowed to enter the top scoreboard.{0}",
                                                 Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestCurrentHits()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsolePrinter.PrintCurrentHits(2, 2);
                int expectedCowsCount = 2;
                int expectedBullsCount = 2;
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}!{2}{3}",
                    expectedBullsCount, expectedCowsCount, Environment.NewLine, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestCongratsMessageWithZeroCheats()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsolePrinter.PrintCongratulationMessage(0, 4);
                             int expectedGuessesCount = 4;
                string expected = string.Format("{0}Congratulations! You guessed the secret number in {1} attempts.{2}{3}",
                   Environment.NewLine, expectedGuessesCount, Environment.NewLine, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestCongratsMessageWithTwoCheats()
        {
            using (StringWriter sw = new StringWriter())
            {
                //congratulationMessage.AppendFormat("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", guessCounter, helpCounter);

                Console.SetOut(sw);
                ConsolePrinter.PrintCongratulationMessage(2, 6);
                int expectedHelpCounter = 2;
                int expectedGuessesCount = 6;
                string expected = string.Format("{0}Congratulations! You guessed the secret number in {1} attempts and {2} cheats.{3}{4}",
                  Environment.NewLine, expectedGuessesCount, expectedHelpCounter, Environment.NewLine,Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
