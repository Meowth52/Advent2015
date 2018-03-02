using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Day6
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day6(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            bool[,] TheGrid = new bool[1000, 1000];
            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    TheGrid[x, y] = false;
            int[,] TheGrid2 = new int[1000, 1000];
            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    TheGrid2[x, y] = 0;
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    PartOnePermutation(s, ref TheGrid);
                    PartTwoPermutation(s, ref TheGrid2);
                }
            }
            foreach (bool b in TheGrid)
                if (b)
                    Sum++;
            foreach(int i in TheGrid2)
            {
                Sum2 += i;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public void PartOnePermutation(string s, ref bool[,] TheGrid)
        {
            string ss = s.Replace(",", " ");
            string[] SplitString = s.Split(' ');
            Regex Numbers = new Regex(@"\d+");
            List<int> NumberList = ParseNumbers(s);
            int X = NumberList[0];
            int Y = NumberList[1];
            int X2 = NumberList[2];
            int Y2 = NumberList[3];
            Regex Vovels = new Regex(@"[a | e | i | o | u]");
            switch (SplitString[1])
            {
                case "off":
                    for (int x = X; x <= X2; x++)
                        for (int y = Y; y <= Y2; y++)
                            TheGrid[x, y] = false;
                    break;
                case "on":
                    for (int x = X; x <= X2; x++)
                        for (int y = Y; y <= Y2; y++)
                            TheGrid[x, y] = true;
                    break;
                default:
                    for (int x = X; x <= X2; x++)
                        for (int y = Y; y <= Y2; y++)
                            TheGrid[x, y] = !TheGrid[x, y];
                    break;
            }
        }
        public void PartTwoPermutation(string s, ref int[,] TheGrid2)
        {
            string ss = s.Replace(",", " ");
            string[] SplitString = s.Split(' ');
            Regex Numbers = new Regex(@"\d+");
            List<int> NumberList = ParseNumbers(s);
            int X = NumberList[0];
            int Y = NumberList[1];
            int X2 = NumberList[2];
            int Y2 = NumberList[3];
            Regex Vovels = new Regex(@"[a | e | i | o | u]");
            switch (SplitString[1])
            {
                case "off":
                    for (int x = X; x <= X2; x++)
                        for (int y = Y; y <= Y2; y++)
                            if (TheGrid2[x, y] > 0)
                                TheGrid2[x, y]--;
                    break;
                case "on":
                    for (int x = X; x <= X2; x++)
                        for (int y = Y; y <= Y2; y++)
                            TheGrid2[x, y]++;
                    break;
                default:
                    for (int x = X; x <= X2; x++)
                        for (int y = Y; y <= Y2; y++)
                            TheGrid2[x, y] += 2;
                    break;
            }

        }
        public List<int> ParseNumbers(string s)
        {
            Regex Numbers = new Regex(@"\d+");
            List<int> NumberList = new List<int>();
            int TryParseInt = 0;
            foreach (Match m in Numbers.Matches(s))
            {
                Int32.TryParse(m.Value, out TryParseInt);
                NumberList.Add(TryParseInt);
            }
            return NumberList;
        }
    }
}