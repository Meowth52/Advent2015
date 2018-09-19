using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;

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
            int NumberOfCompartments;
            if (MessageBox.Show("Is it time for part 2?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                NumberOfCompartments = 4;
            }
            else
            {
                NumberOfCompartments = 3;
            }
            long Sum = 0;
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
             // for part one
            int TargetWeight = Packages.Sum()/NumberOfCompartments;
            
            int IterationX = 0;
            int LowestCount = 100;
            long LowestQE = 100000000000;
            Dictionary<long, List<int>> BestCandidates = new Dictionary<long, List<int>>();
            foreach (int StartInt in Packages)
            {
                Dictionary<long, List<int>> PossibleCominations = new Dictionary<long, List<int>> { { StartInt, new List<int> { StartInt } } };
                while (PossibleCominations.Count > 0)
                {
                    IterationX++;
                    long RemoveIndex = PossibleCominations.Last().Key;
                    List<int> CopyCurrentElement = copyList(PossibleCominations.Last().Value);
                    PossibleCominations.Remove(RemoveIndex);
                    foreach (int i in Packages)
                    {
                        List<int> ItMightBeThisCombination = copyList(CopyCurrentElement);
                        if (!ItMightBeThisCombination.Contains(i))
                        {
                            ItMightBeThisCombination.Sort();
                            if (true)
                            {
                                ItMightBeThisCombination.Add(i);
                                if (ItMightBeThisCombination.Sum() == TargetWeight)
                                {
                                    if (ItMightBeThisCombination.Count <= LowestCount)
                                    {
                                        LowestCount = ItMightBeThisCombination.Count;
                                        long QE = 1;
                                        foreach (int w in ItMightBeThisCombination)
                                        {
                                            QE *= w;
                                        }
                                        if (QE <= LowestQE)
                                        {
                                            LowestQE = QE;
                                            if (!BestCandidates.ContainsKey(QE))
                                                BestCandidates.Add(QE, ItMightBeThisCombination);
                                        }
                                    }
                                }
                                else if (ItMightBeThisCombination.Sum() < TargetWeight && ItMightBeThisCombination.Count < LowestCount)
                                {
                                    long QE = 1;
                                    foreach (int w in ItMightBeThisCombination)
                                    {
                                        QE *= w;
                                    }
                                    if (QE <= LowestQE)
                                    {
                                        if (!PossibleCominations.ContainsKey(QE))
                                            PossibleCominations.Add(QE, ItMightBeThisCombination);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach(KeyValuePair<long, List<int>> k in BestCandidates)
            {
                if (k.Key < LowestQE)
                    LowestQE = k.Key;
            }
            Sum = LowestQE;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Svaret är: " + Sum.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
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