namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class printing on the console
    /// </summary>
    public class ConsolePrinter
    {
        /// <summary>
        /// Static void method writing on the console Intro Message
        /// </summary>
        public static void PrintWelcomeMessage()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.AppendLine("Welcome to “Bulls and Cows” game.");
            welcomeMessage.AppendLine("Please try to guess my secret 4-digit number.");
            welcomeMessage.AppendLine("Commands you can use:");
            welcomeMessage.AppendLine("\"top\" will show you the current top 5 scores;" + Environment.NewLine +
                "\"restart\" will start a new game for you;" + Environment.NewLine +
                "\"help\" will reveal one random digit in the secret 4-digit number;" + Environment.NewLine +
                "\"exit\" will get you out of this mess.");
            welcomeMessage.AppendLine("Have fun!");

            Console.WriteLine(welcomeMessage.ToString());
        }

        /// <summary>
        /// Static void method printing on the console what to do
        /// </summary>
        public static void PrintEnterGuessMessage()
        {
            Console.Write("Enter your guess or command: ");
        }

        /// <summary>
        /// Prints on the console if user input is incorrect
        /// </summary>
        public static void PrintInvalidNumberMessage()
        {
            Console.WriteLine("You have entered an invalid number!");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints on the console if user input is incorrect
        /// </summary>
        public static void PrintInvalidCommandMessage()
        {
            Console.WriteLine("You have entered an invalid command!");
            Console.WriteLine();
        }

        /// <summary>
        /// Printing your current progress
        /// </summary>
        /// <param name="bullsCount">Number of bulls</param>
        /// <param name="cowsCount">Number of cows</param>
        public static void PrintCurrentHits(int bullsCount, int cowsCount)
        {
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}!", bullsCount, cowsCount);
            Console.WriteLine();
        }

        /// <summary>
        /// Printing on the console hint message
        /// </summary>
        /// <param name="hint">Char array of hint</param>
        public static void PrintHint(char[] hint)
        {
            StringBuilder hintMessage = new StringBuilder();

            hintMessage.Append("The number looks like ");
            foreach (char symbol in hint)
            {
                hintMessage.Append(symbol);
            }

            hintMessage.Append(".");
            Console.WriteLine(hintMessage.ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// Printing message after finishing the game
        /// </summary>
        /// <param name="helpCounter">Count of cheats used</param>
        /// <param name="guessCounter">Count of attempts</param>
        public static void PrintCongratulationMessage(int helpCounter, int guessCounter)
        {
            StringBuilder congratulationMessage = new StringBuilder();

            if (helpCounter == 0)
            {
                congratulationMessage.AppendFormat("Congratulations! You guessed the secret number in {0} attempts.", guessCounter);
            }
            else
            {
                congratulationMessage.AppendFormat("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", guessCounter, helpCounter);
            }

            Console.WriteLine();
            Console.WriteLine(congratulationMessage.ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// Static void method printing scoreboard
        /// </summary>
        /// <param name="scoreboard">List of players</param>
        public static void PrintScoreboard(List<Player> scoreboard)
        {
            Console.WriteLine();
            StringBuilder scoresMessage = new StringBuilder();

            if (scoreboard.Count > 0)
            {
                int currentPosition = 1;

                scoresMessage.AppendLine("Scoreboard:");

                scoreboard.Sort();
                scoresMessage.AppendLine("Rank | Guesses | Name");

                foreach (var player in scoreboard)
                {
                    scoresMessage.AppendFormat("{0,4} | {1}{2}", currentPosition, player, Environment.NewLine);
                    currentPosition++;
                }

                PrintLine(40);
            }
            else
            {
                scoresMessage.AppendLine("Scoreboard is empty!");
            }

            Console.WriteLine(scoresMessage.ToString());
            PrintLine(40);
            Console.WriteLine();
        }

        /// <summary>
        /// Static void method printing on the console message to enter user nickname
        /// </summary>
        public static void PrintEnterNicknameMessage()
        {
            Console.WriteLine("You can add your nickname to top scores!");
            Console.Write("Enter your nickname: ");
        }

        /// <summary>
        /// Printing information message on the console
        /// </summary>
        public static void PrintNotAllowedMessage()
        {
            Console.WriteLine("You are not allowed to enter the top scoreboard.");
        }

        /// <summary>
        /// Printing on the console bye message
        /// </summary>
        public static void PrintByeMessage()
        {
            Console.WriteLine("Good bye!");
        }

        /// <summary>
        /// Printing on the console 
        /// </summary>
        /// <param name="dashCount">Count of dashes to be printed on the console</param>
        private static void PrintLine(int dashCount)
        {
            for (int i = 0; i < dashCount; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}
