namespace BullsAndCows
{
    using System;

    class Start
    {
        static void Main()
        {
            Random random = new Random(0);

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine(random.Next(0, 9999));
            //}

            Game.OnGameOver += (obj, x) =>
            {
                Game.Play();
            };

            Game.Play();
        }
    }
}