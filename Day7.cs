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
            Dictionary<string, Schmenum> Wires = new Dictionary<string, Schmenum>();
            foreach(string[] Instruction in Instructions)
            {
                if (!Wires.ContainsKey(Instruction.Last()))
                    Wires.Add(Instruction.Last(), new Schmenum());
            }
            int RemoveIndex;
            Regex MatchRegister = new Regex(@"[a-z]+");
            List<string> RegisterMatch = new List<string>();
            Regex MatchInstruction = new Regex(@"[A-Z]+");
            while (Instructions.Count > 0)
            {
                RemoveIndex = -1;
                foreach(string[] Instruction in Instructions)
                {
                    RegisterMatch.Clear();
                    bool Doable = true;
                    foreach (string s in Instruction)
                    {
                        if (Instruction.Last() != s && Wires.ContainsKey(s))
                        {
                            if (!Wires[s].IsAssigned()) // tveksam kontroll
                            {
                                Doable = false;
                                //markera för att det går att genomföra operationen, genomför den, breaka och ta bort den.
                            }
                        }
                    }
                    if (Doable)
                    {
                        char Keyword = '_';
                        RemoveIndex = Instructions.IndexOf(Instruction);
                        foreach (string s in Instruction)
                        {
                            if (char.IsUpper(s[0]))
                                Keyword = s[0];
                        }
                        ushort Value1;
                        ushort Value2;
                        
                        string Target = Instruction.Last();
                        switch (Keyword)
                        {
                            case 'A': // And
                                Value1 = GetNumber(Instruction[0], ref Wires);
                                Value2 = GetNumber(Instruction[2], ref Wires);
                                Wires[Target].Assign((ushort)(Value1 & Value2));
                                break;
                            case 'O': //Or
                                Value1 = GetNumber(Instruction[0], ref Wires);
                                Value2 = GetNumber(Instruction[2], ref Wires);
                                Wires[Target].Assign((ushort)(Value1 | Value2));
                                break;
                            case 'L': //Lshift
                                Value1 = GetNumber(Instruction[0], ref Wires);
                                Value2 = GetNumber(Instruction[2], ref Wires);
                                Wires[Target].Assign((ushort)(Value1 << Value2));
                                break;
                            case 'R': //Rshift
                                Value1 = GetNumber(Instruction[0], ref Wires);
                                Value2 = GetNumber(Instruction[2], ref Wires);
                                Wires[Target].Assign((ushort)(Value1 >> Value2));
                                break;
                            case 'N': //Not
                                Value2 = GetNumber(Instruction[1], ref Wires);
                                Wires[Target].Assign((ushort)(~Value2));
                                break;
                            default:
                                break;
                        }
                    break;
                    }

                }
                Instructions.RemoveAt(RemoveIndex);
            }
            Sum = Wires["a"].GetValue();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public ushort GetNumber(string s, ref Dictionary<string, Schmenum> Dick)
        {
            ushort TheNumber = 0;
            if (char.IsDigit(s[0]))
                ushort.TryParse(s, out TheNumber);
            else
                TheNumber = Dick[s].GetValue();
            return TheNumber;
        }

    }
    class Schmenum
    {
        bool Assigned;
        ushort Value;
        public Schmenum()
        {
            Assigned = false;
        }
        public void Assign(ushort i)
        {
            Assigned = true;
            Value = i;
        }
        public bool IsAssigned()
        {
            return Assigned;
        }
        public ushort GetValue()
        {
            return Value;
        }
    }
}