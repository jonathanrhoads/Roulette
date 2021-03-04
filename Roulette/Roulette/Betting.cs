using System;

namespace Roulette
{
    internal class Betting
    {
        /// <summary>
        /// Asks the user for their bet amount and checks to make sure its less than total bet remaining.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>The amount of chips the user wants to bet.</returns>
        private static int PlaceBetAmount(ref Player player)
        {
            Console.WriteLine("\nHow much would you like to bet?");
            int bet = 0;

            while (bet < 1 || bet > player.chips)
            {
                Console.WriteLine($"Enter a bet less than or equal to your remaining chips ({player.chips}).");
                bet = int.Parse(Console.ReadLine());
            }
            return bet;
        }

        /// <summary>
        /// Lists the options of bets to choose from.
        /// </summary>
        /// <returns>An integer corresponding to the bet type chosen.</returns>
        private static int PickBet()
        {
            int choice = 0;
            while (choice < 1 || choice > 10)
            {
                Console.WriteLine("\nType in the number corresponding to the bet you want to place then press enter.");
                Console.WriteLine("1. Number: Bet on a single number (0, 00, or 1-36). Payout = 35:1");
                Console.WriteLine("2. Evens/Odds: Bet that the number type. (Odd or Even). Payout 1:1");
                Console.WriteLine("3. Reds/Blacks: Bet on the color (Red or Black). Payout 1:1");
                Console.WriteLine("4. Lows/Highs: Low (1 – 18) or High (19 – 38). Payout 1:1");
                Console.WriteLine("5. Dozens: Row thirds, (1 – 12), (13 – 24), (25 – 36). Payout 2:1");
                Console.WriteLine("6. Columns: First, second, or third columns. Payout 2:1");
                Console.WriteLine("7. Street: Rows, e.g., 1/2/3 or 22/23/24. Payout 11:1");
                Console.WriteLine("8. 6 Numbers: Double rows, e.g., 1/2/3/4/5/6 or 22/23/24/25/26/26. Payout 5:1");
                Console.WriteLine("9. Split: at the edge of any two contiguous numbers, e.g., 1/2, 11/14, and 35/36. Payout 17:1");
                Console.WriteLine("10. Corner: at the intersection of any four contiguous numbers, e.g., 1/2/4/5, or 23/24/26/27. Payout 8:1");
                Console.WriteLine();
                choice = int.Parse(Console.ReadLine());
            }

            return choice;
        }

        /// <summary>
        /// Starts the game of roulette and calls on the type of bet chosen.
        /// </summary>
        /// <param name="player"></param>
        public static void Play(ref Player player)
        {
            CheckIfOutOfChips(player);

            int choice = PickBet();
            int betAmount = PlaceBetAmount(ref player);
            switch (choice)
            {
                case 1:
                    Numbers(player, betAmount);
                    break;

                case 2:
                    EvenOdd(player, betAmount);
                    break;

                case 3:
                    RedBlack(player, betAmount);
                    break;

                case 4:
                    LowHigh(player, betAmount);
                    break;

                case 5:
                    Dozens(player, betAmount);
                    break;

                case 6:
                    Columns(player, betAmount);
                    break;

                case 7:
                    Streets(player, betAmount);
                    break;

                case 8:
                    SixNums(player, betAmount);
                    break;

                case 9:
                    Split(player, betAmount);
                    break;

                case 10:
                    Corner(player, betAmount);
                    break;
            }
        }

        /// <summary>
        /// Checks to see if the player is out of chips.
        /// </summary>
        /// <param name="player"></param>
        private static void CheckIfOutOfChips(Player player)
        {
            if (player.chips <= 0)
            {
                Console.WriteLine("\nSorry you are out of chips. Come back on pay day!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private static void Corner(Player player, int betAmount)
        {
            int payout = 8;

            Console.WriteLine("You picked Corners. Pick a corner from below.");
            Console.WriteLine("1. {1, 2, 5, 4}");
            Console.WriteLine("2. { 2, 3, 5, 6 }");
            Console.WriteLine("3. { 4, 5, 7, 8 }");
            Console.WriteLine("4. { 5, 6, 8, 9 }");
            Console.WriteLine("5. { 7, 8, 10, 11 }");
            Console.WriteLine("6. { 8, 9, 11, 12 }");
            Console.WriteLine("7. { 10, 11, 13, 14 }");
            Console.WriteLine("8. { 11, 12, 14, 15 }");
            Console.WriteLine("9. { 13, 16, 14, 17 }");
            Console.WriteLine("10. { 14, 15, 17, 18 }");
            Console.WriteLine("11. { 16, 17, 19, 20 }");
            Console.WriteLine("12. { 17, 18, 20, 21 }");
            Console.WriteLine("13. { 19, 20, 22, 23 }");
            Console.WriteLine("14. { 20, 21, 23, 24 }");
            Console.WriteLine("15. { 22, 23, 25, 26 }");
            Console.WriteLine("16. { 23, 24, 26, 27 }");
            Console.WriteLine("17. { 25, 26, 28, 29 }");
            Console.WriteLine("18. { 26, 27, 29, 30 }");
            Console.WriteLine("19. { 28, 29, 31, 32 }");
            Console.WriteLine("20. { 29, 30, 32, 33 }");
            Console.WriteLine("21. { 31, 32, 34, 35 }");
            Console.WriteLine("22. { 32, 33, 35, 36 }");

            string bet = Console.ReadLine();

            bool win = CheckBets.Corner(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void Split(Player player, int betAmount)
        {
            int payout = 17;
            Console.WriteLine("You picked Split. Which split would you like?");
            Console.WriteLine("1. { 1, 2 }");
            Console.WriteLine("2. { 2, 3 }");
            Console.WriteLine("3. { 1, 4 }");
            Console.WriteLine("4. { 2, 5 }");
            Console.WriteLine("5. { 3, 6 }");
            Console.WriteLine("6. { 4, 5 }");
            Console.WriteLine("7. { 5, 6 }");
            Console.WriteLine("8. { 4, 7 }");
            Console.WriteLine("9. { 5, 8 }");
            Console.WriteLine("10. { 6, 9 }");
            Console.WriteLine("11. { 7, 8 }");
            Console.WriteLine("12. { 8, 9 }");
            Console.WriteLine("13. { 9, 12 }");
            Console.WriteLine("14. { 8, 11 }");
            Console.WriteLine("15. { 7, 10 }");
            Console.WriteLine("16. { 10, 11 }");
            Console.WriteLine("17. { 11, 12 }");
            Console.WriteLine("18. { 12, 15 }");
            Console.WriteLine("19. { 11, 14 }");
            Console.WriteLine("20. { 10, 13 }");
            Console.WriteLine("21. { 13, 14 }");
            Console.WriteLine("22. { 14, 15 }");
            Console.WriteLine("23. { 15, 18 }");
            Console.WriteLine("24. { 14, 17 }");
            Console.WriteLine("25. { 13, 16 }");
            Console.WriteLine("26. { 16, 17 }");
            Console.WriteLine("27. { 17, 18 }");
            Console.WriteLine("28. { 18, 21 }");
            Console.WriteLine("29. { 17, 20 }");
            Console.WriteLine("30. { 16, 19 }");
            Console.WriteLine("31. { 19, 20 }");
            Console.WriteLine("32. { 20, 21 }");
            Console.WriteLine("33. { 21, 24 }");
            Console.WriteLine("34. { 20, 23 }");
            Console.WriteLine("35. { 19, 22 }");
            Console.WriteLine("36. { 22, 23 }");
            Console.WriteLine("37. { 23, 24 }");
            Console.WriteLine("38. { 24, 27 }");
            Console.WriteLine("39. { 23, 26 }");
            Console.WriteLine("40. { 22, 25 }");
            Console.WriteLine("41. { 25, 26 }");
            Console.WriteLine("42. { 26, 27 }");
            Console.WriteLine("43. { 27, 30 }");
            Console.WriteLine("44. { 26, 29 }");
            Console.WriteLine("45. { 25, 28 }");
            Console.WriteLine("46. { 28, 29 }");
            Console.WriteLine("47. { 29, 30 }");
            Console.WriteLine("48. { 30, 33 }");
            Console.WriteLine("49. { 29, 32 }");
            Console.WriteLine("50. { 28, 31 }");
            Console.WriteLine("51. { 31, 32 }");
            Console.WriteLine("52. { 32, 33 }");
            Console.WriteLine("53. { 33, 36 }");
            Console.WriteLine("54. { 32, 35 }");
            Console.WriteLine("55. { 31, 34 }");
            Console.WriteLine("56. { 34, 35 }");
            Console.WriteLine("57. { 35, 36 }");
            Console.WriteLine("58. { 0, 1 }");
            Console.WriteLine("59. { 0, 2 }");
            Console.WriteLine("60. { 00, 2 }");
            Console.WriteLine("61. { 00, 3 }");
            Console.WriteLine("62. { 00, 0 }");

            string bet = Console.ReadLine();

            bool win = CheckBets.Split(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void SixNums(Player player, int betAmount)
        {
            int payout = 5;

            Console.WriteLine("You picked 6 Numbers. Pick a group of 6 from below.");
            Console.WriteLine("1. (1, 2, 3, 4, 5, 6)");
            Console.WriteLine("2. (4, 5, 6, 7, 8, 9)");
            Console.WriteLine("3. (7, 8, 9, 10, 11, 12)");
            Console.WriteLine("4. (10, 11, 12, 13, 14, 15)");
            Console.WriteLine("5. (13, 14, 15, 16, 17, 18)");
            Console.WriteLine("6. (16, 17, 18, 19, 20, 21)");
            Console.WriteLine("7. (19, 20, 21, 22, 23, 24)");
            Console.WriteLine("8. (22, 23, 24, 25, 26, 27)");
            Console.WriteLine("9. (25, 26, 27, 28, 29, 30)");
            Console.WriteLine("10. (28, 29, 30, 31, 32, 33)");
            Console.WriteLine("11. (31, 32, 33, 34, 35, 36)");

            string bet = Console.ReadLine();

            bool win = CheckBets.SixNums(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void Streets(Player player, int betAmount)
        {
            int payout = 11;

            Console.WriteLine("You picked Streets. Pick a row from below");
            Console.WriteLine("1. (1, 2, 3)");
            Console.WriteLine("2. (4, 5, 6)");
            Console.WriteLine("3. (7, 8, 9)");
            Console.WriteLine("4. (10, 11, 12)");
            Console.WriteLine("5. (13, 14, 15)");
            Console.WriteLine("6. (16, 17, 18)");
            Console.WriteLine("7. (19, 20, 21)");
            Console.WriteLine("8. (22, 23, 24)");
            Console.WriteLine("9. (25, 26, 27)");
            Console.WriteLine("10. (28, 29, 30)");
            Console.WriteLine("11. (31, 32, 33)");
            Console.WriteLine("12. (34, 35, 36)");

            string bet = Console.ReadLine();

            bool win = CheckBets.Streets(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void Columns(Player player, int betAmount)
        {
            int payout = 2;

            Console.WriteLine("You picked Columns. Which one would you like to pick?");
            Console.WriteLine("1. 1st Column (1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34)");
            Console.WriteLine("2. 2nd Column (2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35)");
            Console.WriteLine("3. 3rd Column (3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36)");

            string bet = Console.ReadLine();

            bool win = CheckBets.Columns(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void Dozens(Player player, int betAmount)
        {
            int payout = 2;

            Console.WriteLine("You picked Dozens. Pick a dozen from below.");
            Console.WriteLine("1. 1-12");
            Console.WriteLine("2. 13-24");
            Console.WriteLine("3. 25-36");

            string bet = Console.ReadLine();

            bool win = CheckBets.Dozens(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void LowHigh(Player player, int betAmount)
        {
            int payout = 1;
            Console.WriteLine("You picked Lows/Highs. What one would you like to pick?");
            Console.WriteLine("1. Lows\n2. Highs");

            string bet = Console.ReadLine();

            bool win = CheckBets.LowHigh(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void RedBlack(Player player, int betAmount)
        {
            int payout = 1;
            Console.WriteLine("You picked Reds/Blacks. What color would you like to pick?");
            Console.WriteLine("1. Red\n2. Black");
            string bet = Console.ReadLine();

            bool win = CheckBets.RedBlack(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void EvenOdd(Player player, int betAmount)
        {
            int payout = 1;
            Console.WriteLine("You picked Evens/Odds. What type would you like to pick?");
            Console.WriteLine("1. Odd\n2. Even");
            string bet = Console.ReadLine();

            bool win = CheckBets.EvenOdd(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        private static void Numbers(Player player, int betAmount)
        {
            int payout = 35;
            Console.WriteLine("You picked Numbers. What number would you like to pick?");
            Console.WriteLine("Enter 0, 00, or a number 1-36.");
            string bet = Console.ReadLine();

            bool win = CheckBets.Numbers(bet);
            WinOrLose(ref player, betAmount, ref payout, win);
        }

        /// <summary>
        /// Tells the user if they won or loss and then corrects chip count appropriately.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="betAmount"></param>
        /// <param name="payout"></param>
        /// <param name="win"></param>
        private static void WinOrLose(ref Player player, int betAmount, ref int payout, bool win)
        {
            if (win == false)
            {
                payout = -1;
                Console.WriteLine("\nYou lost this game.");
            }
            else
            {
                Console.WriteLine("\nYou won this game.");
            }

            player.UpdateChipCount(betAmount * payout);
            Console.WriteLine($"You now have {player.chips} chips.");

            Console.WriteLine("\n\nPress enter to play again or type f and hit enter to quit.");
            string playAgain = Console.ReadLine();

            if (playAgain == "f") Environment.Exit(0);

            Play(ref player);
        }
    }
}