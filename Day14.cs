using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day14
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day14(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int Time = 2503;
            List<Raindeer> Raindeers = new List<Raindeer>();
            foreach (string s in Instructions)
                Raindeers.Add(new Raindeer(s));
            foreach (Raindeer r in Raindeers)
                if (r.getDistance(Time) > Sum)
                    Sum = r.getDistance(Time);
            //Part 2
            Dictionary<string, Raindeer> RainDic = new Dictionary<string, Raindeer>();
            foreach (Raindeer r in Raindeers)
                RainDic.Add(r.WhosAGoodBoy(), r);
            for (int i = 1;i <= Time; i++)
            {
                int CompareInt = 0;
                string BestRaindeer = "";
                foreach(Raindeer r in Raindeers)
                {
                    if (r.tick > CompareInt)
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }

    internal class Raindeer
    {
        String Name; //Because its cute
        int Speed = 0;
        int Constitution = 0;
        int RestTime = 0;
        int AccumulatedDistance = 0;
        int SantaPoint = 0;
        public Raindeer(string input)
        {
            string[] Words = input.Split(' ');
            Name = Words[0];
            Int32.TryParse(Words[3], out Speed);
            Int32.TryParse(Words[6], out Constitution);
            Int32.TryParse(Words[13], out RestTime);
        }
        public int getDistance(int Time)
        {
            int WholeCycles = Time / (Constitution + RestTime);
            int WhatIsEnglishForSlatt = Time % (Constitution + RestTime);
            if (WhatIsEnglishForSlatt > Constitution)
                WhatIsEnglishForSlatt = Constitution;
            return WholeCycles * Speed * Constitution + WhatIsEnglishForSlatt * Speed;
        }
        public int tick(int Time)
        {
            if (Time % (Constitution + RestTime) < Constitution)
                AccumulatedDistance += Speed;
            return AccumulatedDistance;
        }
        public string WhosAGoodBoy()
        {
            return Name;
        }
    }
}