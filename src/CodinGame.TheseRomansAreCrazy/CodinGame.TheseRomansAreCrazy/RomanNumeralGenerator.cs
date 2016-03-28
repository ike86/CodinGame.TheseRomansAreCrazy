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
        private readonly Generator fiveGenerator;
        private readonly Generator fourGenerator;
        private readonly Generator oneGenerator;

        private readonly IEnumerable<Generator> generators;

        public RomanNumeralGenerator()
        {
            this.oneGenerator = new Generator(
                        value => value > 0,
                        value => new Tuple<int, string>(1, "I"));
            this.fourGenerator = new Generator(
                        value => value == 4,
                        value => new Tuple<int, string>(4, "IV"));
            this.fiveGenerator = new Generator(
                        value => value >= 5,
                        value => new Tuple<int, string>(5, "V"));


            this.generators =
                new Generator[]
                {
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
                    remainingValue -= generationResult.Item1;
                    result += generationResult.Item2;
                }
            }

            return result;
        }

        class Generator
        {
            public Generator(Func<int, bool> canGenerate, Func<int, Tuple<int, string>> generate)
            {
                this.CanGenerate = canGenerate;
                this.Generate = generate;
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
