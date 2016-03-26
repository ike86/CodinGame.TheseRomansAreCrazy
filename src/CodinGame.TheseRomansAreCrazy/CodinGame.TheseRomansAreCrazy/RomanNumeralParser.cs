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
            return numeral.Count(ch => ch == 'V') * 5
                + numeral.Count(ch => ch == 'I');
        }
    }
}
