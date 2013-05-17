namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Static class game containing it's functions
    /// </summary>
    public static class Game
    {
        private static List<Player> scoreboard = new List<Player>();
        private static int helpCounter;
        private static int guessCounter;
        private static string secretNumberAsString;
        private static bool isGuessed;
        private static char[] hint;
        public static Random numberGenerator;
        public static event EventHandler OnGameOver = null;

        /// <summary>
        /// Static void method which allows you to play
        /// </summary>
        public static void Play()
        {
            ConsolePrinter.PrintWelcomeMessage();
            //Initialize();
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
            if (OnGameOver != null)
            {
                OnGameOver(null, EventArgs.Empty);
            }
            //Play();
        }

        public static void Reset()
        {
            //numberGenerator = new Random();
            //pseudo random generator (every time same random numbers, for testing)
            numberGenerator = new Random(0);

            guessCounter = 0;
            helpCounter = 0;
            isGuessed = false;
            hint = new char[] { 'X', 'X', 'X', 'X' };
        }

        /// <summary>
        /// Static constructor for Game, initializing all fields
        /// </summary>
        static Game()
        {
            Reset();
        }

        /// <summary>
        /// Static void method generating secret number between 0 and 9999
        /// </summary>
        private static void GenerateSecretNumber()
        {
            long secretNumber = numberGenerator.Next(0, 9999);
            secretNumberAsString = secretNumber.ToString();
            AddZeroes();
        }

        /// <summary>
        /// Filling missing digits with zeroes
        /// </summary>
        private static void AddZeroes()
        {
            //padleft?
            int missingDigitsCount = 4 - secretNumberAsString.Length;
            StringBuilder filler = new StringBuilder();

            for (int i = 0; i < missingDigitsCount; i++)
            {
                filler.Append("0");
            }

            filler.Append(secretNumberAsString);
            secretNumberAsString = filler.ToString();
        }

        /// <summary>
        /// Static void method revealing current progress
        /// </summary>
        /// <param name="playerGuess">Player input - guess number</param>
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
                    RevealCurrentHits(playerGuess);
                }
            }
            else
            {
                ConsolePrinter.PrintInvalidNumberMessage();
            }
        }

        /// <summary>
        /// Revealing current hits
        /// </summary>
        /// <param name="playerGuess">Player input - guess number</param>
        private static void RevealCurrentHits(string playerGuess)
        {
            int bullsCount = 0;
            int cowsCount = 0;
            CountHits(playerGuess, ref bullsCount, ref cowsCount);
            ConsolePrinter.PrintCurrentHits(bullsCount, cowsCount);
        }

        /// <summary>
        /// Counting player hits
        /// </summary>
        /// <param name="playerGuess">Player input - guess number</param>
        /// <param name="bullsCount">Count of bulls in playerGuess number</param>
        /// <param name="cowsCount">Count of cows in playerGuess number</param>
        public static void CountHits(string playerGuess, ref int bullsCount, ref int cowsCount)
        {
            bool[] isBull = new bool[4];
            bool[] isCow = new bool[10];

            bullsCount = CountBulls(playerGuess, bullsCount, isBull);
            cowsCount = CountCows(playerGuess, cowsCount, isBull, isCow);
        }

        /// <summary>
        /// Static method counting bulls in playerGuess number
        /// </summary>
        /// <param name="playerGuess">Player input - guess number</param>
        /// <param name="bullsCount">Count of bulls in playerGuess number</param>
        /// <param name="isBull">Boolean variable checking whether digit is bull or not</param>
        /// <returns>Count of bulls</returns>
        public static int CountBulls(string playerGuess, int bullsCount, bool[] isBull)
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

        /// <summary>
        /// Static method counting cows in playerGuess number
        /// </summary>
        /// <param name="playerGuess">Player input - guess number</param>
        /// <param name="cowsCount">Count of cows in playerGuess number</param>
        /// <param name="isBull">Boolean variable checking whether digit is bull or not</param>
        /// <param name="isCow">Boolean variable checking whether digit is cow or not</param>
        /// <returns>Count of cows</returns>
        public static int CountCows(string playerGuess, int cowsCount, bool[] isBull, bool[] isCow)
        {
            for (int i = 0; i < playerGuess.Length; i++)
            {
                int playerGuessAsInt = int.Parse(playerGuess[i].ToString());

                if (!isBull[i] && !isCow[playerGuessAsInt])
                {
                    isCow[playerGuessAsInt] = true;

                    for (int j = 0; j < playerGuess.Length; j++)
                    {
                        if (playerGuess[i] == secretNumberAsString[j])
                        {
                            if (!isBull[j])
                            {
                                cowsCount++;
                            }
                        }
                    }
                }
            }

            return cowsCount;
        }

        /// <summary>
        /// Static method checking whether player guess number is correct
        /// </summary>
        /// <param name="playerGuess">Player input - guess number</param>
        /// <returns>Boolean true or false - correct number or not</returns>
        private static bool IsGuessCorrect(string playerGuess)
        {
            bool isCorrect = playerGuess == secretNumberAsString;
            return isCorrect;
        }

        /// <summary>
        /// Static void method printing messages on the console
        /// </summary>
        /// <param name="command">Input command to be checked by the program</param>
        public static void ProcessTextCommand(string command)
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

        /// <summary>
        /// Static void method revealing digits in secret number
        /// </summary>
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

        /// <summary>
        /// Private static method adding player to the scoreboard
        /// </summary>
        /// <param name="playerScore">Current player score</param>
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

        /// <summary>
        /// Static void method adding a player with his nickname and his score
        /// </summary>
        /// <param name="playerScore">Current player score</param>
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
        
        static void Main() { }
    }
}