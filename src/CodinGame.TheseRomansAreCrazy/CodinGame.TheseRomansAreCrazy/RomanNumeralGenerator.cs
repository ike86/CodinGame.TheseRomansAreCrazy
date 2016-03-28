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
        private readonly Generator fiftyGenerator;
        private readonly Generator fourtyGenerator;
        private readonly Generator tenGenerator;
        private readonly Generator nineGenerator;
        private readonly Generator fiveGenerator;
        private readonly Generator fourGenerator;
        private readonly Generator oneGenerator;

        private readonly IEnumerable<Generator> generators;

        public RomanNumeralGenerator()
        {
            this.oneGenerator = new Generator(1, "I");
            this.fourGenerator = new Generator(4, "IV");
            this.fiveGenerator = new Generator(5, "V");
            this.nineGenerator = new Generator(9, "IX");
            this.tenGenerator = new Generator(10, "X");
            this.fourtyGenerator = new Generator(40, "XL");
            this.fiftyGenerator = new Generator(50, "L");

            this.generators =
                new Generator[]
                {
                    this.fiftyGenerator,
                    this.fourtyGenerator,
                    this.tenGenerator,
                    this.tenGenerator,
                    this.tenGenerator,
                    this.nineGenerator,
                    this.fiveGenerator,
                    this.fourGenerator,
                    this.oneGenerator,
                    this.oneGenerator,
                    this.oneGenerator
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
