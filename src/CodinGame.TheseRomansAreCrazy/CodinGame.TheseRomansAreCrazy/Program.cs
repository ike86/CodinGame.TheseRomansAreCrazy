using System;

namespace CodinGame.TheseRomansAreCrazy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string rom1 = Console.ReadLine();
            string rom2 = Console.ReadLine();

            var parser = new RomanNumeralParser();

            Console.WriteLine(parser.Parse(rom1) + parser.Parse(rom2));
        }
    }
}