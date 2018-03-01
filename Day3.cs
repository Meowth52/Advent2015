using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day3
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        public Day3(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int x = 0;
            int y = 0;

            List<Coordinate> PlacesBeen = new List<Coordinate>();
            PlacesBeen.Add(new Coordinate(x, y));
            //Part 1
            foreach (char c in Input)
            {
                Coordinate MaybeNew = GetCoordinate(c, ref x, ref y);
                if (!PlacesBeen.Contains(MaybeNew))
                    PlacesBeen.Add(MaybeNew);
            }
            Sum = PlacesBeen.Count;
            //Part 2
            bool IsSantaARobot = false;
            x = 0;
            y = 0;
            int Robotx = 0;
            int Roboty = 0;
            PlacesBeen.Clear();
            PlacesBeen.Add(new Coordinate(x, y));
            List<Coordinate> RobotPlacesBeen = new List<Coordinate>();
            foreach (char c in Input)
            {
                if (IsSantaARobot)
                {
                    Coordinate MaybeNew = GetCoordinate(c, ref x, ref y);
                    if (!PlacesBeen.Contains(MaybeNew))
                        PlacesBeen.Add(MaybeNew);
                    IsSantaARobot = !IsSantaARobot;
                }
                else
                {
                    Coordinate MaybeNew = GetCoordinate(c, ref Robotx, ref Roboty);
                    if (!RobotPlacesBeen.Contains(MaybeNew))
                        RobotPlacesBeen.Add(MaybeNew);
                    IsSantaARobot = !IsSantaARobot;
                }
            }
            foreach (Coordinate c in RobotPlacesBeen)
            {
                if (!PlacesBeen.Contains(c))
                    PlacesBeen.Add(c);
            }
            Sum2 = PlacesBeen.Count;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public Coordinate GetCoordinate(char c, ref int x, ref int y)
        {
            switch (c)
            {
                case '<':
                    x--;
                    break;
                case '>':
                    x++;
                    break;
                case '^':
                    y++;
                    break;
                case 'v':
                    y--;
                    break;
                default:
                    ;
                    break;
            }
            return new Coordinate(x, y);
        }
    }
}