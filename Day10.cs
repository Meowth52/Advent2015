using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day10
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        public Day10(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            StringBuilder NewString = new StringBuilder();
            char LastChar;
            int HowManyOf;
            for (int i = 0;i <50;i++)
            {
                NewString.Clear();
                LastChar = ' ';
                HowManyOf = 1;
                Input += "_";
                foreach (char c in Input)
                {
                    if (LastChar != ' ')
                    {
                        if (c == LastChar)
                        {
                            HowManyOf++;
                        }
                        else
                        {
                            NewString.Append(HowManyOf.ToString()+LastChar.ToString());
                            HowManyOf = 1;
                        }
                    }
                    LastChar = c;
                }
                Input = NewString.ToString();
            }
            Sum = Input.Length;
           stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}