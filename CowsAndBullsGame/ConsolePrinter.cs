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
        public static string PrintWelcomeMessage()
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

            return welcomeMessage.ToString();
        }

        /// <summary>
        /// Static void method printing on the console what to do
        /// </summary>
        public static string PrintEnterGuessMessage()
        {
            StringBuilder guessMessage = new StringBuilder();
            guessMessage.Append("Enter your guess or command: ");
            return guessMessage.ToString();
        }

        /// <summary>
        /// Prints on the console if user input is incorrect
        /// </summary>
        public static string PrintInvalidNumberMessage()
        {   
            StringBuilder invalidNumberMessage = new StringBuilder();
            invalidNumberMessage.AppendLine("You have entered an invalid number!");
            invalidNumberMessage.AppendLine();
            return invalidNumberMessage.ToString();
        }

        /// <summary>
        /// Prints on the console if user input is incorrect
        /// </summary>
        public static string PrintInvalidCommandMessage()
        {
            StringBuilder invalidCommandMessage = new StringBuilder();
            invalidCommandMessage.AppendLine("You have entered an invalid command!");
            invalidCommandMessage.AppendLine();
            return invalidCommandMessage.ToString();
        }

        /// <summary>
        /// Printing your current progress
        /// </summary>
        /// <param name="bullsCount">Number of bulls</param>
        /// <param name="cowsCount">Number of cows</param>
        public static string PrintCurrentHits(int bullsCount, int cowsCount)
        {
            StringBuilder currentHits = new StringBuilder();
            currentHits.AppendFormat("Wrong number! Bulls: {0}, Cows: {1}!", bullsCount, cowsCount);
            currentHits.AppendLine();
            return currentHits.ToString();
        }

        /// <summary>
        /// Printing on the console hint message
        /// </summary>
        /// <param name="hint">Char array of hint</param>
        public static string PrintHint(char[] hint)
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
            return hintMessage.ToString();
        }

        /// <summary>
        /// Printing message after finishing the game
        /// </summary>
        /// <param name="helpCounter">Count of cheats used</param>
        /// <param name="guessCounter">Count of attempts</param>
        public static string PrintCongratulationMessage(int helpCounter, int guessCounter)
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
            return congratulationMessage.ToString();
          
        }

        /// <summary>
        /// Static void method printing scoreboard
        /// </summary>
        /// <param name="scoreboard">List of players</param>
        public static string PrintScoreboard(List<Player> scoreboard)
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

                Console.WriteLine(PrintLine(40));
            }
            else
            {
                scoresMessage.AppendLine("Scoreboard is empty!");
            }
            scoresMessage.AppendLine();
            Console.WriteLine(PrintLine(40));
            return scoresMessage.ToString();
        }

        /// <summary>
        /// Static void method printing on the console message to enter user nickname
        /// </summary>
        public static string PrintEnterNicknameMessage()
        {
            StringBuilder enterNicknameMessage = new StringBuilder();
            enterNicknameMessage.AppendLine("You can add your nickname to top scores!");
            enterNicknameMessage.Append("Enter your nickname: ");
            return enterNicknameMessage.ToString();
        }

        /// <summary>
        /// Printing information message on the console
        /// </summary>
        public static string PrintNotAllowedMessage()
        {
            StringBuilder notAllowedMessage = new StringBuilder();
            notAllowedMessage.AppendLine("You are not allowed to enter the top scoreboard.");
            return notAllowedMessage.ToString();
        }

        /// <summary>
        /// Printing on the console bye message
        /// </summary>
        public static string PrintByeMessage()
        {
            StringBuilder byeMessage = new StringBuilder();
            byeMessage.AppendLine("Good bye!");
            return byeMessage.ToString();
        }

        /// <summary>
        /// Printing on the console 
        /// </summary>
        /// <param name="dashCount">Count of dashes to be printed on the console</param>
        private static string PrintLine(int dashCount)
        {
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < dashCount; i++)
            {
               line.Append("-");
            }

            line.AppendLine();
            return line.ToString();
        }
    }
}
