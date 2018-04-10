using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Day12
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        public Day12(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            MatchCollection IntergerMatch = Regex.Matches(Input, @"[-]?[\d]+");
            int TryParseInt = 0;
            foreach (Match m in IntergerMatch)
            {
                Int32.TryParse(m.Value, out TryParseInt);
                Sum += TryParseInt;
            }
            Sum2 = Sum;
            MatchCollection RedObjects = Regex.Matches(Input, @"({.*?:\""red\"".*?})");
            foreach(Match m in RedObjects)
            {
                MatchCollection RedMatches = Regex.Matches(m.Value, @"[-]?[\d]+");
                foreach (Match mmm in RedMatches)
                {
                    Int32.TryParse(mmm.Value, out TryParseInt);
                    Sum2 -= TryParseInt;
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}