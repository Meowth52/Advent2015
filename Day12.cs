﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Advent2015
{
    class Day12
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        public Day12(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            MatchCollection IntergerMatch = Regex.Matches(Input, @"[-]?[\d]+");
            int TryParseInt = 0;
            foreach (Match m in IntergerMatch)
            {
                Int32.TryParse(m.Value, out TryParseInt);
                Sum += TryParseInt;
            }
            dynamic InputObject = JsonConvert.DeserializeObject(Input);
            int ExtraInt;
            foreach (Newtonsoft.Json.Linq.JProperty o in InputObject)
            {
                ExtraInt = getObjects(o);
                if (ExtraInt == -1000000)
                {
                    ;
                }
                else
                    Sum2 += ExtraInt;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public int getObjects(Newtonsoft.Json.Linq.JToken p)
        {
            bool Redrum = false;
            int Counter = 0;
            int ExtraInt = 0;
            Match IntergerMatch;
            int TryParseInt = 0;
            foreach (Newtonsoft.Json.Linq.JToken o in p)
            {
                if (o.HasValues)
                {
                    ExtraInt = getObjects(o);
                    if (ExtraInt == -1000000)
                    {
                        Counter = 0;
                        break;
                    }
                    else
                        Counter += ExtraInt;
                }
                else
                {
                    string wtf = o.ToString();
                    if (p.Type != Newtonsoft.Json.Linq.JTokenType.Array && o.ToString().Contains("red"))
                    {
                        Redrum = true;
                        break;
                    }
                    else
                    {
                        IntergerMatch = Regex.Match(o.ToString(), @"[-]?[\d]+");
                        Int32.TryParse(IntergerMatch.Value, out TryParseInt);
                        Counter += TryParseInt;
                    }
                }
            }
            if (Redrum)
                Counter = -1000000;
            return Counter;
        }
    }
}