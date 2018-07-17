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
            string Molecule = "";
            List<string[]> Replacments = new List<string[]>();
            foreach (string s in Instructions)
            {
                string[] SplitString = s.Split(' ');
                if (SplitString.Length == 1)
                    Molecule = s;
                if (SplitString.Length == 3)
                {
                    Replacments.Add(new string[] { SplitString[0], SplitString[2] });
                }
            }
            Sum = getReplacements(Replacments, Molecule).Count;
            //Part 2
            // Reddit solution https://www.reddit.com/r/adventofcode/comments/3xflz8/day_19_solutions/cy4etju/
            Molecule = Molecule.Replace("Rn", "");
            Molecule = Molecule.Replace("Ar", "");
            Sum2 = Regex.Matches(Molecule, @"[A-Z]").Count;
            Sum2 -= Regex.Matches(Molecule, @"Y").Count * 2;
            Sum2--;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public List<string> getReplacements(List<string[]> Replacments, string Molecule)
        {
            List<string> DistinctMolecules = new List<string>();
            int JustForcuriosity = 0;
            foreach (string[] s in Replacments)
            {
                Dictionary<int,int> NumberOfReplacments = new Dictionary<int, int>();
                int CurrentIndex = 0;
                //string MutatableMolecule = Molecule.Replace(s[0], "_");
                for (int i = 0; i <= Molecule.Length - s[0].Length; i++)
                    if (Molecule.Substring(i, s[0].Length) == s[0])
                    {
                        NumberOfReplacments.Add(CurrentIndex, i);
                        CurrentIndex++;
                    }
                for (int i = 0; i < CurrentIndex; i++)
                {
                    StringBuilder LetsTryThisOne = new StringBuilder();
                        {
                            if (NumberOfReplacments[i] > 0)
                                LetsTryThisOne.Append(Molecule.Substring(0, NumberOfReplacments[i]));
                            LetsTryThisOne.Append(s[1]);
                            if (NumberOfReplacments[i] < Molecule.Length)
                                LetsTryThisOne.Append(Molecule.Substring(NumberOfReplacments[i] + s[0].Length));
                        }
                    if (!DistinctMolecules.Contains(LetsTryThisOne.ToString()))
                        DistinctMolecules.Add(LetsTryThisOne.ToString());
                    else
                        JustForcuriosity++;
                }
            }
            return DistinctMolecules;
        }
        public List<string> getBackwardReplacements(List<string[]> Replacments, string Molecule)
        {
            List<string> DistinctMolecules = new List<string>();
            int JustForcuriosity = 0;
            foreach (string[] s in Replacments)
            {
                Dictionary<int, int> NumberOfReplacments = new Dictionary<int, int>();
                int CurrentIndex = 0;
                //string MutatableMolecule = Molecule.Replace(s[0], "_");
                for (int i = 0; i <= Molecule.Length - s[1].Length; i++)
                    if (Molecule.Substring(i, s[1].Length) == s[1])
                    {
                        NumberOfReplacments.Add(CurrentIndex, i);
                        CurrentIndex++;
                    }
                for (int i = 0; i < CurrentIndex; i++)
                {
                    StringBuilder LetsTryThisOne = new StringBuilder();
                    {
                        if (NumberOfReplacments[i] > 0)
                            LetsTryThisOne.Append(Molecule.Substring(0, NumberOfReplacments[i]));
                        LetsTryThisOne.Append(s[0]);
                        if (NumberOfReplacments[i] < Molecule.Length)
                            LetsTryThisOne.Append(Molecule.Substring(NumberOfReplacments[i] + s[1].Length));
                    }
                    if (!DistinctMolecules.Contains(LetsTryThisOne.ToString()))
                        DistinctMolecules.Add(LetsTryThisOne.ToString());
                    else
                        JustForcuriosity++;
                }
            }
            return DistinctMolecules;
        }
    }
}