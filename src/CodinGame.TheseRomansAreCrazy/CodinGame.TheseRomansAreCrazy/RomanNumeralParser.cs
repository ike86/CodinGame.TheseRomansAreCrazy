using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodinGame.TheseRomansAreCrazy
{
    public class RomanNumeralParser
    {
        private IEnumerable<Func<string, Tuple<string, int>>> tokenParsers =
            new Func<string, Tuple<string, int>>[]
            {
                ParseFour,
                ParseFive,
                ParseOne,
                ParseOne,
                ParseOne
            };

        public int Parse(string numeral)
        {
            var result = 0;
            var remainingNumeral = numeral;
            foreach (var tokenParser in this.tokenParsers)
            {
                var tokenParsingResult = tokenParser(remainingNumeral);
                remainingNumeral = tokenParsingResult.Item1;
                result += tokenParsingResult.Item2;
            }

            return result;
        }
        
        private static Tuple<string, int> Identity(string s)
        {
            return new Tuple<string, int>(s, 0);
        }

        private static Tuple<string, int> ParseFour(string s)
        {
            if (s.FirstOrDefault() == 'I' && s.Count() > 1 && s[1] == 'V')
                return new Tuple<string, int>(s.Substring(2), 4);
            else
                return Identity(s);
        }

        private static Tuple<string, int> ParseFive(string s)
        {
            if (s.FirstOrDefault() == 'V')
                return new Tuple<string, int>(s.Substring(1), 5);
            else
                return Identity(s);
        }

        private static Tuple<string, int> ParseOne(string s)
        {
            if (s.FirstOrDefault() == 'I')
                return new Tuple<string, int>(s.Substring(1), 1);
            else
                return Identity(s);
        }
    }
}
