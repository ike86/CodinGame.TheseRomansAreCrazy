using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodinGame.TheseRomansAreCrazy
{
    public class RomanNumeralParser
    {
        public int Parse(string numeral)
        {
            var result = 0;
            foreach (var ch in numeral)
            {
                if (ch == 'V')
                    result += 5;
                else if (ch == 'I')
                    result += 1;
            }

            return result;
        }
    }
}
