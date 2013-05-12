namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsolePrinter
    {
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

        public static void PrintEnterGuessMessage()
        {
            Console.Write("Enter your guess or command: ");
        }

        public static void PrintInvalidNumberMessage()
        {
            Console.WriteLine("You have entered an invalid number!");
        }

        public static void PrintInvalidCommandMessage()
        {
            Console.WriteLine("You have entered an invalid command!");
        }

        public static void PrintCurrentHits(int bullsCount, int cowsCount)
        {
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}!", bullsCount, cowsCount);
        }

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

            Console.WriteLine(congratulationMessage.ToString());
            Console.WriteLine();
        }

        public static void PrintScoreboard(List<Player> scoreboard)
        {
            Console.WriteLine();
            StringBuilder scoresMessage = new StringBuilder();

            if (scoreboard.Count > 0)
            {
                int currentPosition = 1;

                scoresMessage.AppendLine("Scoreboard:");

                scoreboard.Sort();
                scoresMessage.AppendLine("No | Guesses | Name");
                PrintLine(40);

                foreach (var player in scoreboard)
                {
                    scoresMessage.AppendFormat("{0} | {1}", currentPosition, player);
                    PrintLine(40);
                    currentPosition++;
                }
            }
            else
            {
                scoresMessage.AppendLine("Scoreboard is empty!");
            }

            Console.WriteLine(scoresMessage.ToString());
        }

        public static void PrintEnterNicknameMessage()
        {
            Console.WriteLine("You can add your nickname to top scores!");
            Console.Write("Enter your nickname: ");
        }

        public static void PrintNotAllowedMessage()
        {
            Console.WriteLine("You are not allowed to enter the top scoreboard.");
        }

        public static void PrintByeMessage()
        {
            Console.WriteLine("Good bye!");
        }

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
