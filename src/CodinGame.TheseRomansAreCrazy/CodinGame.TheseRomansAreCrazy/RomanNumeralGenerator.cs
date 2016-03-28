using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodinGame.TheseRomansAreCrazy
{
    public class RomanNumeralGenerator
    {
        private readonly IEnumerable<Generator> generators;

        public RomanNumeralGenerator()
        {
            var oneGenerator = new Generator(1, "I");
            var fourGenerator = new Generator(4, "IV");
            var fiveGenerator = new Generator(5, "V");
            var nineGenerator = new Generator(9, "IX");
            var tenGenerator = new Generator(10, "X");
            var fourtyGenerator = new Generator(40, "XL");
            var fiftyGenerator = new Generator(50, "L");
            var ninetyGenerator = new Generator(90, "XC");
            var oneHundredGenerator = new Generator(100, "C");
            var fourHundredGenerator = new Generator(400, "CD");
            var fiveHundredGenerator = new Generator(500, "D");
            var nineHundredGenerator = new Generator(900, "CM");
            var oneTousandGenerator = new Generator(1000, "M");

            this.generators =
                new Generator[]
                {
                    oneTousandGenerator,
                    oneTousandGenerator,
                    oneTousandGenerator,
                    oneTousandGenerator,
                    nineHundredGenerator,
                    fiveHundredGenerator,
                    fourHundredGenerator,
                    oneHundredGenerator,
                    oneHundredGenerator,
                    oneHundredGenerator,
                    ninetyGenerator,
                    fiftyGenerator,
                    fourtyGenerator,
                    tenGenerator,
                    tenGenerator,
                    tenGenerator,
                    nineGenerator,
                    fiveGenerator,
                    fourGenerator,
                    oneGenerator,
                    oneGenerator,
                    oneGenerator
                };
        }

        public string Generate(int value)
        {
            var remainingValue = value;
            var result = string.Empty;

            foreach (var generator in this.generators)
            {
                if (generator.CanGenerate(remainingValue))
                {
                    var generationResult = generator.Generate(remainingValue);
                    remainingValue = generationResult.Item1;
                    result += generationResult.Item2;
                }
            }

            return result;
        }

        class Generator
        {
            protected Generator(Func<int, bool> canGenerate, Func<int, Tuple<int, string>> generate)
            {
                this.CanGenerate = canGenerate;
                this.Generate = generate;
            }

            public Generator(int value, string outputToken)
                : this(
                      v => v >= value,
                      v => new Tuple<int, string>(v - value, outputToken))
            {
            }

            public Func<int, bool> CanGenerate
            {
                get; private set;
            }

            public Func<int, Tuple<int, string>> Generate
            {
                get; private set;
            }
        }
    }
}
