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
            int Sum = 1000000;
            int Sum2 = 0;
            Dictionary<int, string> Locations = new Dictionary<int,string>();
            String CharLocations = "";
            List<string> PossibleRoutes;
            int Distance = 0;
            Dictionary<string, int> Distances = new Dictionary<string, int>();
            StringPermutator MUTATE = new StringPermutator();
            int IntInter = 0;
            foreach (string s in Instructions)
            {
                string[] SplitString = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string ss in SplitString)
                {
                    if (Char.IsDigit(ss[0]))
                    {
                        Int32.TryParse(ss, out Distance);
                        Distances.Add(s, Distance);
                    }
                    else
                        if (ss.Length > 3 & !Locations.ContainsValue(ss))
                    {
                        Locations.Add(IntInter,ss);
                        CharLocations += IntInter.ToString();
                        IntInter++;
                    }
                }
            }
            PossibleRoutes = MUTATE.GetStrings(CharLocations);
            foreach(string s in PossibleRoutes)
            {
                int TestSum = 0;
                int TestTester = 0;
                List<string> LocationPermutation = new List<string>();
                //foreach (char c in s)
                //    foreach (KeyValuePair<int,string> ss in Locations)
                //        if (ss.Value == Locations)
                //            LocationPermutation.Add(ss.Value);
                for (int i = 0; i < IntInter-1; i++)
                {
                    foreach (KeyValuePair<string, int> d in Distances)
                    {
                        if (d.Key.Contains(Locations[i]) && d.Key.Contains(Locations[i+1]))
                        {
                            TestSum += d.Value;
                            TestTester++;
                        }
                    }
                }
                if (TestTester == IntInter-1)
                {
                    if (TestSum < Sum)
                        Sum = TestSum;
                }
                else
                {
                    ;//uh oh
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}