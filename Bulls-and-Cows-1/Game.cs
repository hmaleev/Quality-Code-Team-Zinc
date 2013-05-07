using System;
using System.Collections.Generic;
using System.Text;

namespace CowsAndBulls
{
    public class Game
    {
        private static List<Player> scoreboard = new List<Player>();
        private static int helpCounter;
        private static int guessCounter;
        private static string secretNumberAsString;
        private static bool isGuessed;
        private static char[] hint;
        private static Random numberGenerator;

        public static void Play()
        {
            PrintWelcomeMessage();
            Initialize();
            GenerateSecretNumber();

            string consoleInput = string.Empty;
            int consoleInputAsInt = 0;

            while (!isGuessed)
            {
                Console.Write("Enter your guess or command: ");
                consoleInput = Console.ReadLine();

                if (int.TryParse(consoleInput, out consoleInputAsInt))
                {
                    ProcessDigitCommand(consoleInput);
                }
                else
                {
                    ProcessTextCommand(consoleInput);
                }
            }

            AddPlayerToScoreboard(guessCounter);
            PrintScoreboard();
            CreateNewGame();
        }

        private static void Initialize()
        {
            numberGenerator = new Random();
            guessCounter = 0;
            helpCounter = 0;
            isGuessed = false;
            hint = new char[] { 'X', 'X', 'X', 'X' };
        }

        private static void GenerateSecretNumber()
        {
            long secretNumber = numberGenerator.Next(0, 9999);
            secretNumberAsString = secretNumber.ToString();
            AddZeroes();
        }

        private static void AddZeroes()
        {
            int missingDigitsCount = 4 - secretNumberAsString.Length;
            StringBuilder filler = new StringBuilder();

            for (int i = 0; i < missingDigitsCount; i++)
            {
                filler.Append("0");
            }

            filler.Append(secretNumberAsString);
            secretNumberAsString = filler.ToString();
        }

        private static void ProcessDigitCommand(string playerGuess)
        {
            if (playerGuess.Length == 4)
            {
                guessCounter++;
                if (IsGuessCorrect(playerGuess))
                {
                    isGuessed = true;
                    PrintCongratulationMessage();
                }
                else
                {
                    PrintBullsAndCows(playerGuess);
                }
            }
            else
            {
                Console.WriteLine("You have entered an invalid number!");
            }
        }

        private static void PrintBullsAndCows(string playerGuess)
        {
            int bullsCount = 0;
            int cowsCount = 0;
            CountHits(playerGuess, ref bullsCount, ref cowsCount);
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}!", bullsCount, cowsCount);
        }

        private static void CountHits(string playerGuess, ref int bullsCount, ref int cowsCount)
        {
            bool[] isBull = new bool[4];
            bool[] isCow = new bool[10];

            bullsCount = CountBulls(playerGuess, bullsCount, isBull);
            cowsCount = CountCows(playerGuess, cowsCount, isBull, isCow);
        }

        private static int CountCows(string playerGuess, int cowsCount, bool[] isBull, bool[] isCow)
        {
            for (int i = 0; i < playerGuess.Length; i++)
            {
                int playerGuessAsInt = int.Parse(playerGuess[i].ToString());

                if (!isBull[i] && !isCow[playerGuessAsInt])
                {
                    isCow[playerGuessAsInt] = true;
                    cowsCount = CountCowsForCurrentDigit(playerGuess, cowsCount, isBull, i);
                }
            }

            return cowsCount;
        }

        private static int CountBulls(string playerGuess, int bullsCount, bool[] isBull)
        {
            for (int i = 0; i < playerGuess.Length; i++)
            {
                if (playerGuess[i] == secretNumberAsString[i])
                {
                    bullsCount++;
                    isBull[i] = true;
                }
            }

            return bullsCount;
        }

        private static int CountCowsForCurrentDigit(string playerGuess, int cowsCount, bool[] isBull, int position)
        {
            for (int i = 0; i < playerGuess.Length; i++)
            {
                if (playerGuess[position] == secretNumberAsString[i])
                {
                    if (!isBull[i])
                    {
                        cowsCount++;
                    }
                }
            }

            return cowsCount;
        }

        private static void PrintCongratulationMessage()
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

        private static bool IsGuessCorrect(string playerGuess)
        {
            bool isCorrect = playerGuess == secretNumberAsString;
            return isCorrect;
        }

        private static void ProcessTextCommand(string command)
        {
            switch (command.ToLower())
            {
                case "top":
                    PrintScoreboard();
                    break;
                case "help":
                    RevealDigit();
                    helpCounter++;
                    break;
                case "restart":
                    CreateNewGame();
                    return;
                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }

        private static void RevealDigit()
        {
            bool isRevealed = false;
            int revealedDigits = 0;

            while (!isRevealed && revealedDigits != 2 * secretNumberAsString.Length)
            {
                int positionToReveal = numberGenerator.Next(0, 4);
                if (hint[positionToReveal] == 'X')
                {
                    hint[positionToReveal] = secretNumberAsString[positionToReveal];
                    isRevealed = true;
                }

                revealedDigits++;
            }

            PrintHint();
        }

        private static void PrintHint()
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

        private static void CreateNewGame()
        {
            Play();
        }

        private static void AddPlayerToScoreboard(int playerScore)
        {
            if (helpCounter > 0)
            {
                Console.WriteLine("You are not allowed to enter the top scoreboard.");
            }
            else
            {
                if (scoreboard.Count < 5)
                {
                    AddPlayer(playerScore);
                }
                else if (scoreboard[4].Score > playerScore)
                {
                    scoreboard.RemoveAt(4);
                    AddPlayer(playerScore);
                }
            }
        }

        private static void AddPlayer(int playerScore)
        {
            Console.WriteLine("You can add your nickname to top scores!");
            string playerNick = string.Empty;
            while (playerNick == string.Empty)
            {
                try
                {
                    Console.Write("Enter your nickname: ");
                    playerNick = Console.ReadLine();
                    Player currentPlayer = new Player(playerNick, playerScore);
                    scoreboard.Add(currentPlayer);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        private static void PrintScoreboard()
        {
            Console.WriteLine();
            StringBuilder scoresMessage = new StringBuilder();

            if (scoreboard.Count > 0)
            {
                int currentPosition = 1;

                scoresMessage.AppendLine("Scoreboard:");

                scoreboard.Sort();
                scoresMessage.AppendLine("{Guesses,7} | Name");
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

        private static void PrintLine(int dashCount)
        {
            for (int i = 0; i < dashCount; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }

        private static void PrintWelcomeMessage()
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
    }
}