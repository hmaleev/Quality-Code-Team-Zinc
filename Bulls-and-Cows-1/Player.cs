namespace BullsAndCows
{
    using System;

    public class Player : IComparable<Player>
    {
        private string nickname;
        private int score;

        public Player(string nickname, int score)
        {
            this.Nickname = nickname;
            this.Score = score;
        }

        /// <summary>
        /// Property for player's nickname
        /// </summary>
        public string Nickname
        {
            get
            {
                return this.nickname;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Nickname is missing");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Nickname is blank!");
                }

                this.nickname = value;
            }
        }

        /// <summary>
        /// Only get property of the score
        /// </summary>
        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score cannot be negative");
                }

                this.score = value;
            }
        }

        /// <summary>
        /// Comparing the scores
        /// </summary>
        /// <param name="otherPlayerScore">Score of the opponent</param>
        /// <returns>Compared score</returns>
        public int CompareTo(Player otherPlayerScore)
        {
            if (this.Score.CompareTo(otherPlayerScore.Score) == 0)
            {
                return this.Nickname.CompareTo(otherPlayerScore.Nickname);
            }
            else
            {
                return this.Score.CompareTo(otherPlayerScore.Score);
            }
        }

        public override string ToString()
        {
            string result = string.Format("{0,7} | {1}", this.Score, this.Nickname);
            return result;
        }
    }
}