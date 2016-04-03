namespace CodinGame.TheseRomansAreCrazy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RomanNumeralParser
    {
        private readonly IEnumerable<TokenParser> tokenParsers;

        public RomanNumeralParser()
        {
            var oneParser = new SimpleTokenParser('I', 1);
            var fiveParser = new SimpleTokenParser('V', 5);
            var fourParser = new ModifiedTokenParser('I', -1, fiveParser as SimpleTokenParser);
            var tenParser = new SimpleTokenParser('X', 10);
            var nineParser = new ModifiedTokenParser('I', -1, tenParser as SimpleTokenParser);
            var fiftyParser = new SimpleTokenParser('L', 50);
            var fourtyParser = new ModifiedTokenParser('X', -10, fiftyParser as SimpleTokenParser);
            var oneHundredParser = new SimpleTokenParser('C', 100);
            var ninetyParser = new ModifiedTokenParser('X', -10, oneHundredParser as SimpleTokenParser);
            var fiveHundredParser = new SimpleTokenParser('D', 500);
            var fourHundredParser = new ModifiedTokenParser('C', -100, fiveHundredParser as SimpleTokenParser);
            var oneTousandParser = new SimpleTokenParser('M', 1000);
            var nineHundredParser = new ModifiedTokenParser('C', -100, oneTousandParser as SimpleTokenParser);

            this.tokenParsers =
                new TokenParser[]
                {
                    nineHundredParser,
                    oneTousandParser,
                    nineHundredParser,
                    oneTousandParser,
                    nineHundredParser,
                    oneTousandParser,
                    nineHundredParser,
                    oneTousandParser,
                    fourHundredParser,
                    fiveHundredParser,
                    oneHundredParser,
                    oneHundredParser,
                    oneHundredParser,
                    ninetyParser,
                    fourtyParser,
                    fiftyParser,
                    tenParser,
                    tenParser,
                    tenParser,
                    nineParser,
                    fourParser,
                    fiveParser,
                    oneParser,
                    oneParser,
                    oneParser
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

        private abstract class TokenParser
        {
            protected TokenParser(
                Func<string, bool> canParse,
                Func<string, Tuple<string, int>> parse)
            {
                this.CanParse = canParse;
                this.Parse = parse;
            }

            public Func<string, bool> CanParse
            {
                get; private set;
            }

            public Func<string, Tuple<string, int>> Parse
            {
                get; private set;
            }
        }

        private class SimpleTokenParser : TokenParser
        {
            public SimpleTokenParser(char letter, int value)
                : base(
                      s => s.TraceAs("SimpleParser s") && s.FirstOrDefault() == letter,
                      s => new Tuple<string, int>(s.Substring(1), value))
            {
            }
        }

        private class ModifiedTokenParser : TokenParser
        {
            public ModifiedTokenParser(char modifierLetter, int modifierValue, SimpleTokenParser tokenParserToModify)
                : base(
                     s => tokenParserToModify.ArgumentIsNotNull("tokenParserToModify")
                        && s.TraceAs("ModifiedParser s")
                        && s.FirstOrDefault() == modifierLetter
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
            System.Diagnostics.Trace.WriteLine(message + ": " + value);
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