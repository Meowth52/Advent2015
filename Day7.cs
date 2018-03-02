using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Day7
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        public Day7(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                {
                    Instructions.Add(s.Split(' '));
                }
            }
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            //setting up registers
            Dictionary<string, int> Wires = new Dictionary<string, int>();
            foreach(string[] Instruction in Instructions)
            {
                Wires.Add(Instruction.Last(), 0);
            }
            string RemoveIndex = "";
            Regex MatchRegister = new Regex(@"[a-z]+");
            List<string> RegisterMatch = new List<string>();
            Regex MatchInstruction = new Regex(@"[A-Z]+");
            while (Instructions.Count > 0)
            {
                foreach(string[] Instruction in Instructions)
                {
                    RegisterMatch.Clear();
                    foreach (string s in Instruction)
                        if (Instruction.Last() != s && Wires.ContainsKey(s) && Wires[s] != 0)
                        {
                            //markera för att det går att genomföra operationen, genomför den, breaka och ta bort den.
                        }                            
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}