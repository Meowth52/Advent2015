using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day16
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day16(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<Sue> BigFamily = new List<Sue>();
            foreach (string s in Instructions)
            {
                BigFamily.Add(new Sue(s));
            }
            Dictionary<string, int> MFCSAM_Items = new Dictionary<string, int>();
            MFCSAM_Items.Add("children", 3);
            MFCSAM_Items.Add("cats", 7);
            MFCSAM_Items.Add("samoyeds", 2);
            MFCSAM_Items.Add("pomeranians", 3);
            MFCSAM_Items.Add("akitas", 0);
            MFCSAM_Items.Add("vizslas", 0);
            MFCSAM_Items.Add("goldfish", 5);
            MFCSAM_Items.Add("trees", 3);
            MFCSAM_Items.Add("cars", 2);
            MFCSAM_Items.Add("perfumes", 1);
            //Part one
            foreach (Sue s in BigFamily)
            {
                bool FoundIt = true;
                foreach (KeyValuePair<string, int> item in MFCSAM_Items)
                {
                    if (s.getSueItem(item.Key) >= 0 && s.getSueItem(item.Key) != item.Value)
                        FoundIt = false;
                }
                if (FoundIt)
                {
                    Sum = s.getID();
                }
            }
            //Part 2
            foreach (Sue s in BigFamily)
            {
                bool FoundIt = true;
                foreach (KeyValuePair<string, int> item in MFCSAM_Items)
                {
                    if (s.getSueItem(item.Key) >= 0)
                    {
                        switch (item.Key)
                        {
                            case "cats":
                            case "trees":
                                if (s.getSueItem(item.Key) <= item.Value)
                                    FoundIt = false;
                                break;
                            case "pomeranians":
                            case "goldfish":
                                if (s.getSueItem(item.Key) >= item.Value)
                                    FoundIt = false;
                                break;
                            default:
                                if (s.getSueItem(item.Key) != item.Value)
                                    FoundIt = false;
                                break;
                        }
                    }
                }
                if (FoundIt)
                {
                    Sum2 = s.getID();
                }
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
    class Sue
    {
        int SueID = 0;
        Dictionary<string, int> SueItems = new Dictionary<string, int>();
        int TryParseNumber = 0;
        public Sue(string input)
        {
            string Input = input.Replace(",", "");
            Input = Input.Replace(":", "");
            string[] Words = Input.Split(' ');
            Int32.TryParse(Words[1], out SueID);
            Int32.TryParse(Words[3], out TryParseNumber);
            SueItems.Add(Words[2], TryParseNumber);
            Int32.TryParse(Words[5], out TryParseNumber);
            SueItems.Add(Words[4], TryParseNumber);
            Int32.TryParse(Words[7], out TryParseNumber);
            SueItems.Add(Words[6], TryParseNumber);
        }
        public int getSueItem(string s)
        {
            if (SueItems.ContainsKey(s))
            {
                return SueItems[s];
            }
            else return -1;
        }
        public int getID()
        {
            return SueID;
        }
    }
}