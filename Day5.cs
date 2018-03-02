using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Day5
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day5(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            // Part one rules
            Regex Vovels = new Regex(@"[a | e | i | o | u]");
            Regex Dubbels = new Regex(@"(.)\1");
            Regex ForbiddenStrings = new Regex(@"ab|cd|pq|xy");
            // Part two rules
            Regex Twice = new Regex(@"(.{2}).*\1");
            Regex Between = new Regex(@"(.)(.)\1");
            foreach(string s in Instructions)
            {
                if (Vovels.Matches(s).Count >= 3 && Dubbels.Match(s).Success & !ForbiddenStrings.Match(s).Success)
                    Sum++;
                if (Twice.Match(s).Success && Between.Match(s).Success)
                    Sum2++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}