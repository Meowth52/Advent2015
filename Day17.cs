using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day17
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day17(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int MagicNumber = 150;
            List<int> Containers = new List<int>();
            List<Combination> Combinations = new List<Combination>();
            Combinations.Add(new Combination( Instructions));
            List<Combination> NextCombinations = new List<Combination>();
            List<Combination> LegitCombinations = new List<Combination>();

            while (Combinations.Count > 0)
            {
                foreach(Combination C in Combinations)
                {
                    if (C.hasSumReached(MagicNumber))
                    {
                        Sum++;
                        LegitCombinations.Add(C);
                    }
                    else if (!C.isEmpty() && C.getSumSoFar() < MagicNumber)
                    {
                        NextCombinations.Add(new Combination(C.getNextSkipCombination()));
                        NextCombinations.Add(new Combination( C.getNextCombination()));
                    }
                }
                Combinations = new List<Combination>(NextCombinations);
                NextCombinations.Clear();
            }
            int LeastNumberOfContainers = 1000000;
            foreach(Combination C in LegitCombinations)
            {
                if (C.getNumberOfContainers() < LeastNumberOfContainers)
                    LeastNumberOfContainers = C.getNumberOfContainers();
            }
            foreach (Combination C in LegitCombinations)
            {
                if (C.getNumberOfContainers() == LeastNumberOfContainers)
                    Sum2++;
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
    class Combination
    {
        List<int> Containers;
        int SumSoFar = 0;
        List<int> UsedContainers;
        int ValueRemoved = 0;
        public Combination(string[] Input)
        {
            int TryParseInt;
            Containers = new List<int>();
            foreach (string s in Input)
            {
                TryParseInt = 0;
                Int32.TryParse(s, out TryParseInt);
                if (TryParseInt != 0)
                    Containers.Add(TryParseInt);
                UsedContainers = new List<int>();
            }
        }
        public Combination(Combination OldCombination)
        {
            Containers = new List<int>(OldCombination.getList());
            SumSoFar = OldCombination.getSumSoFar();
            UsedContainers = new List<int>(OldCombination.UsedContainers);
        }
        public bool hasSumReached(int i)
        {
            return SumSoFar == i;
        }
        public bool isEmpty()
        {
            return Containers.Count == 0;
        }
        public bool hasThreeEntries()
        {
            return Containers.Count() >= 3; // Because three is the magic number
        }
        public List<int> getList()
        {
            return Containers;
        }
        public int getSumSoFar()
        {
            return SumSoFar;
        }
        public int getNumberOfContainers()
        {
            return UsedContainers.Count;
        }
        public Combination getNextCombination()
        {
            SumSoFar += ValueRemoved;
            UsedContainers.Add(ValueRemoved);
            return this;
        }
        public Combination getNextSkipCombination()
        {
            ValueRemoved = Containers[0];
            Containers.RemoveAt(0);
            return this;
        }
    }
}