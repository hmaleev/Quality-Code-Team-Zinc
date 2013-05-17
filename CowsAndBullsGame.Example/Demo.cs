using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows;

namespace CowsAndBullsGame.Example
{
    class Demo
    {
        static void Main()
        {
            Random random = new Random();

            Game.OnGameOver += (obj, x) =>
            {
                Game.Reset();
                Game.Play();
            };

            Game.Play();
        }
    }
}
