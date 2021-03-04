using System;

namespace Roulette
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Fancy a game of roulette?");
                Player player = new Player();
                Betting.Play(ref player);
            }
            catch (ArgumentException aEx)
            {
                Console.WriteLine(aEx.Message);
            }
            catch (FormatException fEx)
            {
                Console.WriteLine(fEx.Message);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }
    }
}