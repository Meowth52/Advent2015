using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day15
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day15(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<Ingridient> Ingridients = new List<Ingridient>();
            foreach (string s in Instructions)
                Ingridients.Add(new Ingridient(s));
            List<int[]> AllTheCombinations = Permutate();
            foreach (int[] Combination in AllTheCombinations)
            {
                Ingridient Cookie = new Ingridient();
                for(int i = 0; i<4; i++)
                {
                    Cookie.Capacity += Combination[i] * Ingridients[i].Capacity;
                    Cookie.Durability += Combination[i] * Ingridients[i].Durability;
                    Cookie.Flavor += Combination[i] * Ingridients[i].Flavor;
                    Cookie.Texture += Combination[i] * Ingridients[i].Texture;
                    Cookie.Calories += Combination[i] * Ingridients[i].Calories;
                }
                int ThisCombinationsScore = Cookie.getScore();
                if (ThisCombinationsScore > Sum)
                {
                    Sum = ThisCombinationsScore;
                }
                if (Cookie.Calories == 500 && ThisCombinationsScore >= Sum2)
                    Sum2 = ThisCombinationsScore;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public List<int[]> Permutate()
        {
            List<int[]> ReturnValue = new List<int[]>();
            int[] numbers = new int[4]{0,0,0,0};
            for (int i = 0; i <= 100000000; i++)
            {
                int ModI = i;
                int a = ModI % 100;
                ModI = (ModI - a)/100;
                int b = ModI % 100;
                ModI = (ModI - b) / 100;
                int c = ModI % 100;
                ModI = (ModI - c) / 100;
                int d = ModI % 100;
                if (a + b + c + d == 100 && a!=0 && b!=0 && c!=0 && d != 0)
                {
                    ReturnValue.Add(new int[4] { a, b, c, d });
                }
            }
            return ReturnValue;

        }
    }
    class Ingridient
    {
        private string Name;
        public int Capacity = 0;
        public int Durability = 0;
        public int Flavor = 0;
        public int Texture = 0;
        public int Calories = 0;
        public Ingridient(string s)
        {
            s = s.Replace(",", "");
            string[] SplitString = s.Split(' ');
            Name = SplitString[0];
            Int32.TryParse(SplitString[2], out Capacity);
            Int32.TryParse(SplitString[4], out Durability);
            Int32.TryParse(SplitString[6], out Flavor);
            Int32.TryParse(SplitString[8], out Texture);
            Int32.TryParse(SplitString[10], out Calories);
        }
        public Ingridient()
        {
            Name = "Not A real Ingridient";
        }
        public int getScore()
        {
            if (Capacity <= 0 || Durability <= 0 || Flavor <= 0 || Texture <= 0)
                return 0;
            return Capacity * Durability * Flavor * Texture;
        }
    }
}