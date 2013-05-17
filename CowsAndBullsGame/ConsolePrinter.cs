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
            StringBuilder guessMessage = new StringBuilder();
            guessMessage.Append("Enter your guess or command: ");
            Console.WriteLine(guessMessage.ToString());
        }

        /// <summary>
        /// Prints on the console if user input is incorrect
        /// </summary>
        public static void PrintInvalidNumberMessage()
        {   
            StringBuilder invalidNumberMessage = new StringBuilder();
            invalidNumberMessage.AppendLine("You have entered an invalid number!");
            invalidNumberMessage.AppendLine();
            Console.WriteLine(invalidNumberMessage.ToString());
        }

        /// <summary>
        /// Prints on the console if user input is incorrect
        /// </summary>
        public static void PrintInvalidCommandMessage()
        {
            StringBuilder invalidCommandMessage = new StringBuilder();
            invalidCommandMessage.AppendLine("You have entered an invalid command!");
            invalidCommandMessage.AppendLine();
            Console.WriteLine(invalidCommandMessage.ToString());
        }

        /// <summary>
        /// Printing your current progress
        /// </summary>
        /// <param name="bullsCount">Number of bulls</param>
        /// <param name="cowsCount">Number of cows</param>
        public static void PrintCurrentHits(int bullsCount, int cowsCount)
        {
            StringBuilder currentHits = new StringBuilder();
            currentHits.AppendFormat("Wrong number! Bulls: {0}, Cows: {1}!", bullsCount, cowsCount);
            currentHits.AppendLine();
            Console.WriteLine(currentHits.ToString());
        }

        /// <summary>
        /// Printing on the console hint message
        /// </summary>
        /// <param name="hint">Char array of hint</param>
        public static void PrintHint(char[] hint)
        {
            StringBuilder hintMessage = new StringBuilder();
         //   StringBuilder printHint = new StringBuilder();
            hintMessage.Append("The number looks like ");
            foreach (char symbol in hint)
            {
                hintMessage.Append(symbol);
            }

            hintMessage.Append(".");
          //  Console.WriteLine(hintMessage.ToString());
          //  Console.WriteLine();
            Console.WriteLine(hintMessage.ToString());
        }

        /// <summary>
        /// Printing message after finishing the game
        /// </summary>
        /// <param name="helpCounter">Count of cheats used</param>
        /// <param name="guessCounter">Count of attempts</param>
        public static void PrintCongratulationMessage(int helpCounter, int guessCounter)
        {
            StringBuilder congratulationMessage = new StringBuilder();

            congratulationMessage.AppendLine();
            if (helpCounter == 0)
            {
                congratulationMessage.AppendFormat("Congratulations! You guessed the secret number in {0} attempts.", guessCounter);
            }
            else
            {
                congratulationMessage.AppendFormat("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", guessCounter, helpCounter);
            }

            congratulationMessage.AppendLine();
            Console.WriteLine(congratulationMessage.ToString());
        }

        /// <summary>
        /// Static void method printing scoreboard
        /// </summary>
        /// <param name="scoreboard">List of players</param>
        public static void PrintScoreboard(List<Player> scoreboard)
        {
          
            StringBuilder scoresMessage = new StringBuilder();
            scoresMessage.AppendLine();

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
            scoresMessage.AppendLine();
            PrintLine(40);
            Console.WriteLine(scoresMessage.ToString());
        }

        /// <summary>
        /// Static void method printing on the console message to enter user nickname
        /// </summary>
        public static void PrintEnterNicknameMessage()
        {
            StringBuilder enterNicknameMessage = new StringBuilder();
            enterNicknameMessage.AppendLine("You can add your nickname to top scores!");
            enterNicknameMessage.Append("Enter your nickname: ");
            Console.WriteLine(enterNicknameMessage.ToString());
        }

        /// <summary>
        /// Printing information message on the console
        /// </summary>
        public static void PrintNotAllowedMessage()
        {
            StringBuilder notAllowedMessage = new StringBuilder();
            notAllowedMessage.AppendLine("You are not allowed to enter the top scoreboard.");
            Console.WriteLine(notAllowedMessage.ToString());
        }

        /// <summary>
        /// Printing on the console bye message
        /// </summary>
        public static void PrintByeMessage()
        {
            StringBuilder byeMessage = new StringBuilder();
            byeMessage.AppendLine("Good bye!");
            Console.WriteLine(byeMessage.ToString());
        }

        /// <summary>
        /// Printing on the console 
        /// </summary>
        /// <param name="dashCount">Count of dashes to be printed on the console</param>
        private static void PrintLine(int dashCount)
        {
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < dashCount; i++)
            {
               line.Append("-");
            }

            line.AppendLine();
            Console.WriteLine(line.ToString());
        }
    }
}
