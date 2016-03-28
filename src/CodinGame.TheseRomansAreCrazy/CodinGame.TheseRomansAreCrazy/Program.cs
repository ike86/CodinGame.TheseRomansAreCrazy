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
            var generator = new RomanNumeralGenerator();

            Console.WriteLine(
                generator.Generate(
                    parser.Parse(rom1) + parser.Parse(rom2)));
        }
    }
}