using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Day8
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        public Day8(string input)
        {
            stopWatch.Start();
            Input = input;
        }
        public string Result()
        {
            int Slashes = Regex.Matches(Input, @"\\\\").Count;
            Input = Input.Replace("\\\\", "");
            int Quotes = Regex.Matches(Input, @"\""").Count;
            int Hexes = Regex.Matches(Input, @"\\x").Count;

            int Sum = Quotes + Slashes + Hexes * 3;
            int Sum2 = Quotes*2 + Slashes*2 +Hexes;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}