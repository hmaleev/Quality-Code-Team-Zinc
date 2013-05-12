namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Game
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
            ConsolePrinter.PrintWelcomeMessage();
            Initialize();
            GenerateSecretNumber();

            string consoleInput = string.Empty;
            int consoleInputAsInt = 0;

            while (!isGuessed)
            {
                ConsolePrinter.PrintEnterGuessMessage();
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
            ConsolePrinter.PrintScoreboard(scoreboard);
            Play();
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
                    ConsolePrinter.PrintCongratulationMessage(helpCounter, guessCounter);
                }
                else
                {
                    PrintBullsAndCows(playerGuess);
                }
            }
            else
            {
                ConsolePrinter.PrintInvalidNumberMessage();
            }
        }

        private static void PrintBullsAndCows(string playerGuess)
        {
            int bullsCount = 0;
            int cowsCount = 0;
            CountHits(playerGuess, ref bullsCount, ref cowsCount);
            ConsolePrinter.PrintCurrentHits(bullsCount, cowsCount);
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
                    ConsolePrinter.PrintScoreboard(scoreboard);
                    break;
                case "help":
                    RevealDigit();
                    helpCounter++;
                    break;
                case "restart":
                    Play();
                    return;
                case "exit":
                    ConsolePrinter.PrintByeMessage();
                    Environment.Exit(1);
                    break;
                default:
                    ConsolePrinter.PrintInvalidCommandMessage();
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

            ConsolePrinter.PrintHint(hint);
        }

        private static void AddPlayerToScoreboard(int playerScore)
        {
            if (helpCounter > 0)
            {
                ConsolePrinter.PrintNotAllowedMessage();
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
            string playerNick = string.Empty;

            while (playerNick == string.Empty)
            {
                try
                {
                    ConsolePrinter.PrintEnterNicknameMessage();
                    playerNick = Console.ReadLine();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Player currentPlayer = new Player(playerNick, playerScore);
            scoreboard.Add(currentPlayer);
        }
    }
}