using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day24
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day24(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<int> Packages = new List<int>();
            int NextPackage;
            foreach (string s in Instructions)
            {
                NextPackage = 0;
                Int32.TryParse(s, out NextPackage);
                if (NextPackage!=0)
                    Packages.Add(NextPackage);
            }
            int TargetWeight = Packages.Sum()/3;
            Dictionary<int, List<int>> PossibleCominations = new Dictionary<int, List<int>> { { Packages[0], new List<int> { Packages[0] } } }; 
            int IterationX = 0;
            Dictionary<int, List<int>> BestCandidates = new Dictionary<int, List<int>>();
            while (PossibleCominations.Count > 0)
            {
                IterationX++;
                int RemoveIndex = PossibleCominations.Last().Key;
                List<int> CopyCurrentElement = copyList(PossibleCominations.Last().Value);
                PossibleCominations.Remove(RemoveIndex);
                foreach (int i in Packages)
                {
                    List<int> ItMightBeThisCombination = copyList(CopyCurrentElement);
                    if (!ItMightBeThisCombination.Contains(i))
                    {
                        ItMightBeThisCombination.Sort();
                        if (i > ItMightBeThisCombination.Last())
                        {
                            ItMightBeThisCombination.Add(i);
                            if (ItMightBeThisCombination.Sum() == TargetWeight)
                            {
                                int QE = 1;
                                foreach (int w in ItMightBeThisCombination)
                                {
                                    QE *= w;
                                }
                                if (!BestCandidates.ContainsKey(QE))
                                    BestCandidates.Add(QE, ItMightBeThisCombination);
                            }
                            else if (ItMightBeThisCombination.Sum() < TargetWeight)
                            {
                                int QE = 1;
                                foreach (int w in ItMightBeThisCombination)
                                {
                                    QE *= w;
                                }
                                if (!PossibleCominations.ContainsKey(QE))
                                    PossibleCominations.Add(QE, ItMightBeThisCombination);
                            }
                        }
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public List<int> copyList(List<int> l)
        {
            List<int> ReturnList = new List<int>();
            foreach (int i in l)
                ReturnList.Add(i);
            return ReturnList;
        }
    }
}