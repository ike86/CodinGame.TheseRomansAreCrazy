using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodinGame.TheseRomansAreCrazy
{
    public class RomanNumeralParser
    {
        private static TokenParser NineParser = new ModifiedTokenParser('I', 1, 'X', 10);

        private static TokenParser TenParser = new SimpleTokenParser('X', 10);

        private static TokenParser FourParser = new ModifiedTokenParser('I', 1, 'V', 5);

        private static TokenParser FiveParser = new SimpleTokenParser('V', 5);

        private static TokenParser OneParser = new SimpleTokenParser('I', 1);

        private IEnumerable<TokenParser> tokenParsers =
            new TokenParser[]
            {
                NineParser,
                TenParser,
                NineParser,
                TenParser,
                NineParser,
                TenParser,
                FourParser,
                FiveParser,
                OneParser,
                OneParser,
                OneParser
            };

        public int Parse(string numeral)
        {
            var result = 0;
            var remainingNumeral = numeral;
            foreach (var tokenParser in this.tokenParsers)
            {
                if (tokenParser.CanParse(remainingNumeral))
                {
                    var tokenParsingResult = tokenParser.Parse(remainingNumeral);
                    remainingNumeral = tokenParsingResult.Item1;
                    result += tokenParsingResult.Item2;
                }
            }

            return result;
        }

        private static Tuple<string, int> Identity(string s)
        {
            return new Tuple<string, int>(s, 0);
        }

        interface ITokenParser
        {
            Func<string, bool> CanParse { get; }

            Func<string, Tuple<string, int>> Parse { get; }
        }

        abstract class TokenParser
        {
            private readonly Func<string, bool> canParse;
            private readonly Func<string, Tuple<string, int>> parse;

            protected TokenParser(
                Expression<Func<string, bool>> canParse,
                Func<string, Tuple<string, int>> parse)
            {
                this.canParse = canParse.Compile();
                this.parse = parse;
            }

            public Func<string, bool> CanParse
            {
                get
                {
                    return canParse;
                }
            }

            public Func<string, Tuple<string, int>> Parse
            {
                get
                {
                    return parse;
                }
            }
        }

        class SimpleTokenParser : TokenParser
        {
            public SimpleTokenParser(char letter, int value)
                : base(
                      s => s.FirstOrDefault() == letter,
                      s => new Tuple<string, int>(s.Substring(1), value))
            {
            }
        }

        class ModifiedTokenParser : TokenParser
        {
            public ModifiedTokenParser(char modifierLetter, int modifierValue, char letter, int value)
                : base(
                     s => s.FirstOrDefault() == modifierLetter && s.Count() > 1 && s[1] == letter,
                     s => new Tuple<string, int>(s.Substring(2), value - modifierValue))
            {
            }
        }
    }
}
