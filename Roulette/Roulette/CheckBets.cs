using System;
using System.Collections.Generic;

namespace Roulette
{
    internal class CheckBets
    {
        /// <summary>
        /// Initializes the roulette wheel for the class so that each method only has to get the next random integer.
        /// </summary>
        private static RouletteWheel wheel = new RouletteWheel();

        public static bool Numbers(string bet)
        {
            int result = wheel.spinWheel();

            Console.WriteLine($"Your bet was {bet}");
            Console.WriteLine($"The ball landed in the {result} bin.");

            if (bet == "0" && result == 37)
            {
                return true;
            }
            else if (bet == "00" && result == 38)
            {
                return true;
            }
            else
            {
                return int.Parse(bet) == result;
            }
        }

        public static bool Corner(string bet)
        {
            int[,] corners =
            {
                {1, 2, 5, 4},
                {2, 3, 5, 6 },
                {4, 5, 7, 8 },
                {5, 6, 8, 9 },
                {7, 8, 10, 11 },
                {8, 9, 11, 12 },
                {10, 11, 13, 14 },
                {11, 12, 14, 15 },
                {13, 16, 14, 17 },
                {14, 15, 17, 18 },
                {16, 17, 19, 20 },
                {17, 18, 20, 21 },
                {19, 20, 22, 23 },
                {20, 21, 23, 24 },
                {22, 23, 25, 26 },
                {23, 24, 26, 27 },
                {25, 26, 28, 29 },
                {26, 27, 29, 30 },
                {28, 29, 31, 32 },
                {29, 30, 32, 33 },
                {31, 32, 34, 35 },
                {32, 33, 35, 36 }
            };

            int cornerBet = int.Parse(bet) - 1;
            int result = wheel.spinWheel();

            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }

            Console.WriteLine($"The ball landed in the {result} bin.");
            Console.WriteLine($"You chose the {corners[cornerBet, 0]}, {corners[cornerBet, 1]}, " +
                $"{corners[cornerBet, 2]}, {corners[cornerBet, 3]} corner.");

            if (result == corners[cornerBet, 0] || result == corners[cornerBet, 1] ||
                result == corners[cornerBet, 2] || result == corners[cornerBet, 3])
                return true;
            else
                return false;
        }

        public static bool Split(string bet)
        {
            int[,] splits =
            {
                {1, 2 },
                {2, 3 },
                {1, 4 },
                {2, 5 },
                {3, 6 },
                {4, 5 },
                {5, 6 },
                {4, 7 },
                {5, 8 },
                {6, 9 },
                {7, 8 },
                {8, 9 },
                {9, 12 },
                {8, 11 },
                {7, 10 },
                {10, 11 },
                {11, 12 },
                {12, 15 },
                {11, 14 },
                {10, 13 },
                {13, 14 },
                {14, 15 },
                {15, 18 },
                {14, 17 },
                {13, 16 },
                {16, 17 },
                {17, 18 },
                {18, 21 },
                {17, 20 },
                {16, 19 },
                {19, 20 },
                {20, 21 },
                {21, 24 },
                {20, 23 },
                {19, 22 },
                {22, 23 },
                {23, 24 },
                {24, 27 },
                {23, 26 },
                {22, 25 },
                {25, 26 },
                {26, 27 },
                {27, 30 },
                {26, 29 },
                {25, 28 },
                {28, 29 },
                {29, 30 },
                {30, 33 },
                {29, 32 },
                {28, 31 },
                {31, 32 },
                {32, 33 },
                {33, 36 },
                {32, 35 },
                {31, 34 },
                {34, 35 },
                {35, 36 },
                {37, 1 },
                {37, 2 },
                {38, 2 },
                {38, 3 },
                {37, 38 }
            };

            int splitBet = int.Parse(bet) - 1;
            int result = wheel.spinWheel();

            Console.WriteLine($"The ball landed in the {result} bin.");
            Console.WriteLine($"You chose the {splits[splitBet, 0]}, {splits[splitBet, 1]} split.");

            if (result == splits[splitBet, 0] || result == splits[splitBet, 1]) return true;
            return false;
        }

        public static bool SixNums(string bet)
        {
            HashSet<int> row1 = new HashSet<int> { 1, 2, 3, 4, 5, 6 };
            HashSet<int> row2 = new HashSet<int> { 4, 5, 6, 7, 8, 9 };
            HashSet<int> row3 = new HashSet<int> { 7, 8, 9, 10, 11, 12 };
            HashSet<int> row4 = new HashSet<int> { 10, 11, 12, 13, 14, 15 };
            HashSet<int> row5 = new HashSet<int> { 13, 14, 15, 16, 17, 18 };
            HashSet<int> row6 = new HashSet<int> { 16, 17, 18, 19, 20, 21 };
            HashSet<int> row7 = new HashSet<int> { 19, 20, 21, 22, 23, 24 };
            HashSet<int> row8 = new HashSet<int> { 22, 23, 24, 25, 26, 27 };
            HashSet<int> row9 = new HashSet<int> { 25, 26, 27, 28, 29, 30 };
            HashSet<int> row10 = new HashSet<int> { 28, 29, 30, 31, 32, 33 };
            HashSet<int> row11 = new HashSet<int> { 31, 32, 33, 34, 35, 36 };

            bool win = false;
            int result = wheel.spinWheel();

            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }

            Console.WriteLine($"The ball landed in the {result} bin.");

            if (row1.Contains(result) && bet == "1") win = true;
            else if (row2.Contains(result) && bet == "2") win = true;
            else if (row3.Contains(result) && bet == "3") win = true;
            else if (row4.Contains(result) && bet == "4") win = true;
            else if (row5.Contains(result) && bet == "5") win = true;
            else if (row6.Contains(result) && bet == "6") win = true;
            else if (row7.Contains(result) && bet == "7") win = true;
            else if (row8.Contains(result) && bet == "8") win = true;
            else if (row9.Contains(result) && bet == "9") win = true;
            else if (row10.Contains(result) && bet == "10") win = true;
            else if (row11.Contains(result) && bet == "11") win = true;

            return win;
        }

        public static bool Streets(string bet)
        {
            HashSet<int> row1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> row2 = new HashSet<int> { 4, 5, 6 };
            HashSet<int> row3 = new HashSet<int> { 7, 8, 9 };
            HashSet<int> row4 = new HashSet<int> { 10, 11, 12 };
            HashSet<int> row5 = new HashSet<int> { 13, 14, 15 };
            HashSet<int> row6 = new HashSet<int> { 16, 17, 18 };
            HashSet<int> row7 = new HashSet<int> { 19, 20, 21 };
            HashSet<int> row8 = new HashSet<int> { 22, 23, 24 };
            HashSet<int> row9 = new HashSet<int> { 25, 26, 27 };
            HashSet<int> row10 = new HashSet<int> { 28, 29, 30 };
            HashSet<int> row11 = new HashSet<int> { 31, 32, 33 };
            HashSet<int> row12 = new HashSet<int> { 34, 35, 36 };

            bool win = false;
            int result = wheel.spinWheel();

            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }

            Console.WriteLine($"The ball landed in the {result} bin.");

            if (row1.Contains(result) && bet == "1") win = true;
            else if (row2.Contains(result) && bet == "2") win = true;
            else if (row3.Contains(result) && bet == "3") win = true;
            else if (row4.Contains(result) && bet == "4") win = true;
            else if (row5.Contains(result) && bet == "5") win = true;
            else if (row6.Contains(result) && bet == "6") win = true;
            else if (row7.Contains(result) && bet == "7") win = true;
            else if (row8.Contains(result) && bet == "8") win = true;
            else if (row9.Contains(result) && bet == "9") win = true;
            else if (row10.Contains(result) && bet == "10") win = true;
            else if (row11.Contains(result) && bet == "11") win = true;
            else if (row12.Contains(result) && bet == "12") win = true;

            return win;
        }

        public static bool Columns(string bet)
        {
            HashSet<int> col1 = new HashSet<int> { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
            HashSet<int> col2 = new HashSet<int> { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            HashSet<int> col3 = new HashSet<int> { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };

            if (bet == "1") Console.WriteLine("You picked the 1st column.");
            else if (bet == "2") Console.WriteLine("You picked the 2nd column");
            else Console.WriteLine("You picked the third column.");

            bool win = false;
            int result = wheel.spinWheel();

            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }

            Console.WriteLine($"The ball landed in the {result} bin.");

            if (col1.Contains(result) && bet == "1") win = true;
            else if (col2.Contains(result) && bet == "2") win = true;
            else if (col3.Contains(result) && bet == "3") win = true;

            return win;
        }

        public static bool Dozens(string bet)
        {
            if (bet == "1") Console.WriteLine("You picked 1-12.");
            else if (bet == "2") Console.WriteLine("You picked 13-24");
            else Console.WriteLine("You picked 25-36.");

            bool win = false;
            int result = wheel.spinWheel();

            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }

            Console.WriteLine($"The ball landed in the {result} bin.");

            if (result >= 1 && result <= 12 && bet == "1")
            {
                win = true;
            }
            else if (result >= 13 && result <= 24 && bet == "2")
            {
                win = true;
            }
            else if (result >= 25 && result <= 36 && bet == "3")
            {
                win = true;
            }

            return win;
        }

        public static bool LowHigh(string bet)
        {
            if (bet == "1") Console.WriteLine("You picked lows.");
            else Console.WriteLine("You picked highs.");

            int result = wheel.spinWheel();

            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }
            else if (result <= 18)
            {
                Console.WriteLine($"The result of {result} was in lows.");
                return true;
            }
            else
            {
                Console.WriteLine($"The result of {result} was in highs.");
                return false;
            }
        }

        public static bool RedBlack(string bet)
        {
            if (bet == "1") Console.WriteLine("You picked reds.");
            else Console.WriteLine("You picked blacks.");

            int result = wheel.spinWheel();
            string resultColor = RouletteWheel.checkColor(result);

            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }
            Console.WriteLine($"The ball landed in the {result} bin.");

            if (resultColor == "1")
                Console.WriteLine($"{result} is a red bin");
            else
                Console.WriteLine($"{result} is a black bin");

            if (resultColor == bet) return true;
            return false;
        }

        public static bool EvenOdd(string bet)
        {
            if (bet == "1") Console.WriteLine("You picked odds.");
            else Console.WriteLine("You picked evens.");

            int result = wheel.spinWheel();
            bool win = false;
            if (result > 36)
            {
                Console.WriteLine("The ball landed in the zeros.");
                return false;
            }
            Console.WriteLine($"The ball landed in the {result} bin.");

            if (result % 2 == 1)
            {
                Console.WriteLine("The result was odd.");
                if (bet == "1")
                {
                    win = true;
                }
            }
            else
            {
                Console.WriteLine("The result was even.");
                if (bet == "2")
                {
                    win = true;
                }
            }

            return win;
        }
    }
}