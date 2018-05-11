using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day18
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        private readonly MainView mainView;
        public Day18(string input, MainView _mainView)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            mainView = _mainView;
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            bool Part2 = true;
            int GridSize = Instructions.Length;
            bool[,] TheGrid = new bool[GridSize, GridSize];
            bool[,] NextGrid = new bool[GridSize, GridSize];
            List<Coordinate> AllAdjacentPositions = new List<Coordinate>();
            AllAdjacentPositions.Add(new Coordinate(1, 1));
            AllAdjacentPositions.Add(new Coordinate(1, -1));
            AllAdjacentPositions.Add(new Coordinate(1, 0));
            AllAdjacentPositions.Add(new Coordinate(0, -1));
            AllAdjacentPositions.Add(new Coordinate(0, 1));
            AllAdjacentPositions.Add(new Coordinate(-1, 1));
            AllAdjacentPositions.Add(new Coordinate(-1, -1));
            AllAdjacentPositions.Add(new Coordinate(-1, 0));
            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    TheGrid[x, y] = Instructions[x][y] == '#';
                }
            }
            if (Part2)
            {
                TheGrid[0, 0] = true;
                TheGrid[0, GridSize - 1] = true;
                TheGrid[GridSize - 1, 0] = true;
                TheGrid[GridSize - 1, GridSize - 1] = true;
            }

            for (int i = 1; i <= 100; i++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    for (int x = 0; x < GridSize; x++)
                    {
                        int TurnedOnNeighbors = 0;
                        Coordinate CurrentPosition = new Coordinate(x, y);
                        foreach (Coordinate c in AllAdjacentPositions)
                        {
                            Coordinate Currentest = CurrentPosition.GetSum(c);
                            if (Currentest.IsInPositiveBounds(GridSize - 1, GridSize - 1) && TheGrid[Currentest.x, Currentest.y])
                                TurnedOnNeighbors++;
                        }
                        if (TheGrid[x, y])
                            NextGrid[x, y] = (TurnedOnNeighbors == 2 || TurnedOnNeighbors == 3);
                        else
                            NextGrid[x, y] = (TurnedOnNeighbors == 3);
                    }
                }
                TheGrid = (bool[,])NextGrid.Clone();
                if (Part2)
                {
                    TheGrid[0, 0] = true;
                    TheGrid[0, GridSize-1] = true;
                    TheGrid[GridSize-1, 0] = true;
                    TheGrid[GridSize-1, GridSize-1] = true;
                }

                mainView.OutText = getOutputString(TheGrid);
                System.Threading.Thread.Sleep(100);
            }
            foreach (bool b in TheGrid)
            {
                if (b)
                    if (!Part2)
                        Sum++;
                    else
                        Sum2++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            mainView.OutText = "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms\r\n" + getOutputString(TheGrid);
            return "This will be overwriten";
        }
        public string getOutputString(bool[,] TheGrid)
        {
            int GridSize = (int)Math.Sqrt(TheGrid.Length);
            StringBuilder SBuilder = new StringBuilder();
            int rowcounter = 0;
            foreach (bool b in TheGrid)
            {
                if (rowcounter % GridSize == 0)
                    SBuilder.Append("\r\n");
                rowcounter++;
                if (b)
                    SBuilder.Append("#");
                else
                    SBuilder.Append(".");
            }
            return SBuilder.ToString();
        }
    }
}