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
        private static TokenParser FourParser =
            new TokenParser(
                    s => s.FirstOrDefault() == 'I' && s.Count() > 1 && s[1] == 'V',
                    s => new Tuple<string, int>(s.Substring(2), 4));

        private static TokenParser FiveParser =
            new TokenParser(
                    s => s.FirstOrDefault() == 'V',
                    s => new Tuple<string, int>(s.Substring(1), 5));

        private static TokenParser OneParser =
            new TokenParser(
                    s => s.FirstOrDefault() == 'I',
                    s => new Tuple<string, int>(s.Substring(1), 1));

        private IEnumerable<TokenParser> tokenParsers =
            new TokenParser[]
            {
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

        class TokenParser
        {
            private readonly Func<string, bool> canParse;
            private readonly Func<string, Tuple<string, int>> parse;

            public TokenParser(
                Expression<Func<string, bool>> canParse,
                Func<string, Tuple<string, int>> parse)
            {
                this.canParse = canParse.Compile();
                this.parse = parse;
            }

            public Func<string, Tuple<string, int>> Parse
            {
                get
                {
                    return parse;
                }
            }

            public Func<string, bool> CanParse
            {
                get
                {
                    return canParse;
                }
            }
        }
    }
}
