using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day20
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private readonly MainView mainView;
        public Day20(string input, MainView _mainView)
        {
            stopWatch.Start();
            Input = input;
            mainView = _mainView;
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int InputNumber = 0;
            Int32.TryParse(Input, out InputNumber);
            InputNumber /= 10;
            int CurrentHouse = 1;
            int HouseSum = 0;
            List<int> LowHouses = new List<int>();
            while (HouseSum < InputNumber)
            {
                CurrentHouse ++;
                HouseSum = GetFactors1(CurrentHouse).Sum();
                mainView.OutText = CurrentHouse.ToString();
            }
            Sum = CurrentHouse;
            InputNumber *= 10;
            while (HouseSum < InputNumber)
            {
                CurrentHouse++;
                IEnumerable<int> Factors = GetFactors1(CurrentHouse);
                HouseSum = 0;
                foreach(int i in Factors)
                {
                    if (CurrentHouse / i <= 50)
                        HouseSum += i;
                }
                HouseSum *= 11;
                mainView.OutText = CurrentHouse.ToString();
            }
            Sum2 = CurrentHouse;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            mainView.OutText = "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public int getHouseSum(int HouseNr)
        {
            int HouseSum = 0;
            for (int i = HouseNr-49; i <= HouseNr; i++)
            {
                if (HouseNr % i == 0)
                    HouseSum += i;
            }
            return HouseSum*11;
        }
        //snabbare faktoriesering tack vare https://stackoverflow.com/questions/239865/best-way-to-find-all-factors-of-a-given-number
        private IEnumerable<int> GetFactors1(int x)
        {
            int max = (int)Math.Ceiling(Math.Sqrt(x));
            for (int factor = 1; factor < max; factor++)
            {
                if (x % factor == 0)
                {
                    yield return factor;
                    if (factor != max)
                        yield return x / factor;
                }
            }
        }
    }
}