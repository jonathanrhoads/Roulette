using System;
using System.Collections.Generic;

namespace Roulette
{
    internal class RouletteWheel
    {
        private static readonly HashSet<int> redNums = new HashSet<int>
            { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

        private static readonly HashSet<int> blackNums = new HashSet<int>
            { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        /// <summary>
        /// Generates a random number that represents a bin on a roulette wheel.
        /// </summary>
        /// <returns>Random integer between 1-38 inclusive. 37 and 38 are 0 and 00 respectively.</returns>
        public int spinWheel()
        {
            Random random = new Random();
            return random.Next(1, 39);
        }

        /// <summary>
        /// Checks the color of the bin based off the number input.
        /// </summary>
        /// <param name="num">A random number.</param>
        /// <returns>A string of 1 for red, 2 for black, 0 or 00.</returns>
        public static string checkColor(int num)
        {
            if (redNums.Contains(num)) return "1";
            else if (blackNums.Contains(num)) return "2";
            else if (num == 37) return "0";
            else return "00";
        }
    }
}