using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day9
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day9(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<string> Locations = new List<string>();
            List<string> NextLocations;
            foreach (string s in Instructions)
            {
                string[] SplitString = s.Split(' ');
                foreach (string ss in SplitString)
                {
                    if (ss.Length > 3 &! Locations.Contains(ss))
                        Locations.Add(ss);
                }
            }
            while(Locations.Count > 0)
            {
                fore
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}