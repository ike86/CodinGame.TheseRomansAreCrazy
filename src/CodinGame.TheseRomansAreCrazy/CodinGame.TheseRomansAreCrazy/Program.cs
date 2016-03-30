namespace CodinGame.TheseRomansAreCrazy
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            var rom1 = Console.ReadLine();
            var rom2 = Console.ReadLine();

            var parser = new RomanNumeralParser();
            var generator = new RomanNumeralGenerator();

            Console.WriteLine(
                generator.Generate(
                    parser.Parse(rom1) + parser.Parse(rom2)));
        }
    }
}