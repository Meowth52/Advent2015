using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day13
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day13(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            // Setting up possibilities
            Dictionary<string, int> HappinessCombinations = new Dictionary<string, int>();
            string PermutationString = getPermutationStringAndHappinessList(Instructions, ref HappinessCombinations);
            StringPermutator stringPermutator = new StringPermutator();
            List<string> AllThePermutations = stringPermutator.GetStrings(PermutationString);
            Sum=getMaxHappiness(AllThePermutations, HappinessCombinations);
            //Part 2
            Dictionary<string, int> MyHappinessCombinations = new Dictionary<string, int>(HappinessCombinations);
            foreach (KeyValuePair<string, int> k in HappinessCombinations)
            {
                string NewPair = k.Key[0].ToString()+"Y";
                string NewPair2 = "Y" + k.Key[1].ToString();
                if (!MyHappinessCombinations.ContainsKey(NewPair))
                    MyHappinessCombinations.Add(NewPair, 0);
                if (!MyHappinessCombinations.ContainsKey(NewPair2))
                    MyHappinessCombinations.Add(NewPair2, 0);
            }
            string MyPermutationString = PermutationString + "Y";
            stringPermutator = new StringPermutator();
            List<string> AllMyPermutations = stringPermutator.GetStrings(MyPermutationString);
            Sum2 = getMaxHappiness(AllMyPermutations, MyHappinessCombinations);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public string stringswapper(string ab)
        {
            string ba = ab + ab.First().ToString();
            return ba.Remove(0,1);
        }
        public string getPermutationStringAndHappinessList(string[] Instructions, ref Dictionary<string, int> HappinessCombinations)
        {
            string PermutationString = "";
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    string c = s[0].ToString();                    
                    if (!PermutationString.Contains(c))
                        PermutationString += c;
                    string[] Words = s.Split(' ');
                    bool IsGain = Words[2] == "gain";
                    string PairOfHappyPeople = "";
                    PairOfHappyPeople += Words[0][0].ToString() + Words[10][0].ToString();
                    int ThisHappy = 0;
                    Int32.TryParse(Words[3], out ThisHappy);
                    if (!IsGain)
                        ThisHappy = ThisHappy * -1;
                    HappinessCombinations.Add(PairOfHappyPeople, ThisHappy);
                }
            }
            return PermutationString;
        }
        public int getMaxHappiness(List<string> AllThePermutations, Dictionary<string, int> HappinessCombinations)
        {
            int ReturnValue = 0;
            foreach (string s in AllThePermutations)
            {
                int PermutaionHappiness = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int SecondCharacter = i + 1;
                    if (SecondCharacter == s.Length)
                        SecondCharacter = 0;
                    string CurrentTest = s[i].ToString() + s[SecondCharacter].ToString();
                    PermutaionHappiness += HappinessCombinations[CurrentTest];
                    string SwappedTest = stringswapper(CurrentTest);
                    PermutaionHappiness += HappinessCombinations[SwappedTest];
                }
                if (PermutaionHappiness > ReturnValue)
                    ReturnValue = PermutaionHappiness;
            }
            return ReturnValue;
        }
    }
}