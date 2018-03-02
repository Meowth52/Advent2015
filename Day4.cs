using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day4
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private readonly MainView mainView;
        public Day4(string input, MainView _mainView)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
            mainView = _mainView;
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            string _input = Input;
            string TestString = "12345";
            ContainerOfHash OhSantaIsGonnaGetHigh = new ContainerOfHash();
            while (TestString.Substring(0,5)!="00000")
            {
                Sum++;
                TestString = OhSantaIsGonnaGetHigh.GetHash(_input + Sum.ToString());
                //if (Sum % 1000 == 0)
                //mainView._OutText = Sum.ToString() + ", " + TestString;
            }
            Sum2 = Sum;
            while (TestString.Substring(0, 6) != "000000")
            {
                Sum2++;
                TestString = OhSantaIsGonnaGetHigh.GetHash(_input + Sum2.ToString());
                if (Sum2 % 1000 == 0)
                    GC.Collect();
                //mainView._OutText = Sum.ToString() + ", " + TestString;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}