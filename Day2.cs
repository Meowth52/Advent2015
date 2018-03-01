using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day2
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day2(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<Parcel> Presents = new List<Parcel>();
            foreach(string s in Instructions)
            {
                if (s!="")
                    Presents.Add(new Parcel(s));
            }
            foreach(Parcel p in Presents)
            {
                //Part 1
                Sum += p.getArea();
                //Part 2
                Sum2 += p.getRibbon();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

        private class Parcel
        {
            int Height;
            int Lenght;
            int Width;
            public Parcel(string s)
            {
                string[] SplitString = s.Split('x');
                Int32.TryParse(SplitString[0], out Height);
                Int32.TryParse(SplitString[1], out Lenght);
                Int32.TryParse(SplitString[2], out Width);
            }
            public int getArea()
            {
                List<int> Sides = new List<int>
                {
                    Lenght * Width,
                    Width * Height,
                    Height * Lenght
                };
                Sides.Sort();
                return 2 * (Sides.Sum()) + Sides[0];
            }
            public int getRibbon()
            {
                List<int> Dimensions = new List<int>
                {
                    Lenght,
                    Width,
                    Height
                };
                Dimensions.Sort();
                return 2*(Dimensions[0] + Dimensions[1]) + Dimensions.Aggregate(1, (x, y) => x * y);
            }
        }
    }
}