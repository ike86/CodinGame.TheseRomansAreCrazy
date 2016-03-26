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
            for (int i = 0; i < numeral.Count(); i++)
            {
                var ch = numeral[i];
                var nextCh = char.MinValue;
                if (i + 1 < numeral.Count())
                {
                    nextCh = numeral[i + 1];
                }

                if (i + 1 < numeral.Count() && ch == 'I' && nextCh == 'V')
                {
                    result += 4;
                    i++;
                }
                else if (ch == 'V')
                    result += 5;
                else if (ch == 'I')
                    result += 1;
            }

            return result;
        }
    }
}
