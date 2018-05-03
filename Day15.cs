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
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public List<int[]> Permutate()
        {
            int[] numbers = new int[4]{0,0,0,0};
            for (int i = 0; i <= 100000000; i++)
            {
            
            }


        }
    }
    class Ingridient
    {
        private string Name;
        private int Capacity = 0;
        private int Durability = 0;
        private int Flavor = 0;
        private int Texture = 0;
        private int Calories = 0;
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
    }
}