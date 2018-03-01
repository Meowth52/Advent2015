using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day1
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private readonly MainView _mainView;
        public Day1(string input, MainView mainView)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            _mainView = mainView;
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            bool FoundIt = false;
            foreach(char c in Input)
            {
                if (c == '(')
                    Sum++;
                if (c == ')')
                    Sum--;
                if (!FoundIt)
                {
                    Sum2++;
                    if (Sum == -1)
                        FoundIt = true;
                }
                    
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}
