using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Day19
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day19(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int JustForcuriosity = 0;
            string Molecule = "";
            List<string> DistinctMolecules = new List<string>();
            List<string[]> Replacments = new List<string[]>();
            foreach(string s in Instructions)
            {
                string[] SplitString = s.Split(' ');
                if (SplitString.Length == 1)
                    Molecule = s;
                if (SplitString.Length == 3)
                {
                    Replacments.Add(new string[] { SplitString[0], SplitString[2] });
                }
            }
            foreach (string[] s in Replacments)
            {
                string MutatableMolecule = Molecule.Replace(s[0], "_");
                string[] Splitmolecule = MutatableMolecule.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0;i < Splitmolecule.Length-1;i++)
                {
                    StringBuilder LetsTryThisOne = new StringBuilder();
                    for (int ii = 0; ii < Splitmolecule.Length; ii++)
                    {
                        LetsTryThisOne.Append(Splitmolecule[ii]);
                        if (ii == Splitmolecule.Length)
                            break;
                        if (i == ii)
                            LetsTryThisOne.Append(s[1]);
                        else
                            LetsTryThisOne.Append(s[0]);
                    }
                    if (!DistinctMolecules.Contains(LetsTryThisOne.ToString()))
                        DistinctMolecules.Add(LetsTryThisOne.ToString());
                    else
                        JustForcuriosity++;
                }
            }
            Sum = DistinctMolecules.Count;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}