using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Day25
    {
        Stopwatch stopWatch = new Stopwatch();
        public string Input;
        public Day25(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }
        public string Result()
        {
            long Sum = 0;
            int Sum2 = 0;
            int Firstcode = 20151125;
            int MultiplBy = 252533;
            int ModBy = 33554393;
            MatchCollection InputNumbers = Regex.Matches(Input, @"\d+");
            int Row = 0;
            int Column = 0;
            Int32.TryParse(InputNumbers[0].Value, out Row);
            Int32.TryParse(InputNumbers[1].Value, out Column);            
            double Fy = Row;
            double Fx = Column;
            double testX = (Fx / 2 + 0.5) * Fx;
            int RowCounter = 1;
            while (RowCounter < Row)
            {
                testX += Column + RowCounter - 1;
                RowCounter++;
            }
            Sum = Firstcode;
            for (int i = 1; i < testX; i++)
            {
                Sum *= MultiplBy;
                Sum %= ModBy;
            }

            //double testY = ((Fy - 2)/2 + 0.5) * (Fy - 2) + Fy;
            //double testXY = ((Fx + Fy - 1) / 2 + Fy / 2) * Fx + Fy - 1;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}