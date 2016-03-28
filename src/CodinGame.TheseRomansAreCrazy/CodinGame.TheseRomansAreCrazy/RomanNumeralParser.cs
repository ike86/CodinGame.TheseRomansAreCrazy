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
        private readonly TokenParser oneTousandParser;

        private readonly TokenParser fiveHundredParser;

        private readonly TokenParser ninetyParser;

        private readonly TokenParser oneHundredParser;

        private readonly TokenParser fourtyParser;

        private readonly TokenParser fiftyParser;

        private readonly TokenParser nineParser;

        private readonly TokenParser tenParser;

        private readonly TokenParser fourParser;

        private readonly TokenParser fiveParser;

        private readonly TokenParser oneParser;

        private readonly IEnumerable<TokenParser> tokenParsers;

        public RomanNumeralParser()
        {
            this.oneParser = new SimpleTokenParser('I', 1);
            this.fiveParser = new SimpleTokenParser('V', 5);
            this.fourParser = new ModifiedTokenParser('I', -1, fiveParser as SimpleTokenParser);
            this.tenParser = new SimpleTokenParser('X', 10);
            this.nineParser = new ModifiedTokenParser('I', -1, tenParser as SimpleTokenParser);
            this.fiftyParser = new SimpleTokenParser('L', 50);
            this.fourtyParser = new ModifiedTokenParser('X', -10, fiftyParser as SimpleTokenParser);
            this.oneHundredParser = new SimpleTokenParser('C', 100);
            this.ninetyParser = new ModifiedTokenParser('X', -10, oneHundredParser as SimpleTokenParser);
            this.fiveHundredParser = new SimpleTokenParser('D', 500);
            this.oneTousandParser = new SimpleTokenParser('M', 1000);

            tokenParsers =
                new TokenParser[]
                {
                    this.oneTousandParser,
                    this.oneTousandParser,
                    this.oneTousandParser,
                    this.oneTousandParser,
                    this.fiveHundredParser,
                    this.ninetyParser,
                    this.oneHundredParser,
                    this.ninetyParser,
                    this.oneHundredParser,
                    this.ninetyParser,
                    this.oneHundredParser,
                    this.fourtyParser,
                    this.fiftyParser,
                    this.tenParser,
                    this.tenParser,
                    this.nineParser,
                    this.tenParser,
                    this.fourParser,
                    this.fiveParser,
                    this.oneParser,
                    this.oneParser,
                    this.oneParser
                };
        }

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
                      s => s.TraceAs("SimpleParser s") && s.FirstOrDefault() == letter,
                      s => new Tuple<string, int>(s.Substring(1), value))
            {
            }
        }

        class ModifiedTokenParser : TokenParser
        {
            public ModifiedTokenParser(char modifierLetter, int modifierValue, SimpleTokenParser tokenParserToModify)//// char letter, int value)
                : base(
                     s => tokenParserToModify.ArgumentIsNotNull(nameof(tokenParserToModify))
                        && s.TraceAs("ModifiedParser s")
                        && s.FirstOrDefault() == modifierLetter
                        && s.Count() > 1 // TODO review: maybe it's redundant
                        && tokenParserToModify.CanParse(s.Substring(1)),
                     s => new Tuple<string, int>(
                         s.Substring(2),
                         tokenParserToModify.Parse(s.Substring(1)).Item2 + modifierValue))
            {
            }
        }
    }

    public static class Tracers
    {
        public static bool TraceAs(this string value, string message)
        {
            System.Diagnostics.Trace.WriteLine($"{message}: {value}");
            return true;
        }
    }

    public static class Guards
    {
        public static bool ArgumentIsNotNull(this object value, string name)
        {
            if (value == null)
                throw new ArgumentNullException(name);

            return true;
        }
    }
}
