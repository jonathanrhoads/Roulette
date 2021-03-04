using System;

namespace Roulette
{
    public class Player
    {
        public int chips;

        public Player()
        {
            this.chips = GetPlayerChipCount();
        }

        /// <summary>
        /// Initializes the amount of chips the player has.
        /// </summary>
        /// <returns></returns>
        public static int GetPlayerChipCount()
        {
            Console.WriteLine("\nHow many chips do you have today?");
            int chips = 0;
            while (chips < 1 || chips > 100000)
            {
                Console.WriteLine("Enter a number 1 - 100,000");
                chips = int.Parse(Console.ReadLine());
            }
            return chips;
        }

        /// <summary>
        /// Adjusts the chip count based off an input difference value.
        /// </summary>
        /// <param name="diff"></param>
        public void UpdateChipCount(int diff) => this.chips = chips + diff;
    }
}