using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day11
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        public Day11(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }
        public string Result()
        {
            string Sum = "";
            string Sum2 = "";
            int[] PasswordAsInt = new int[8];
            //Translate
            for (int i = 0; i < 8; i++)
            {
                PasswordAsInt[i] = (int)Input[i];
            }
            bool AreWeThereYet = false;
            while (!AreWeThereYet)
            {
                increment(ref PasswordAsInt);
                AreWeThereYet = test(ref PasswordAsInt);
            }
            for (int i = 0; i < 8; i++)
            {
                Sum += (char)PasswordAsInt[i];
            }
            AreWeThereYet = false;
            while (!AreWeThereYet)
            {
                increment(ref PasswordAsInt);
                AreWeThereYet = test(ref PasswordAsInt);
            }
            for (int i = 0; i < 8; i++)
            {
                Sum2 += (char)PasswordAsInt[i];
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public void increment(ref int[] PasswordAsInt)
        {
            int LowestASCII = 97;
            int HighestASCII = 122;
            //increment
            for (int i = 7; i >= 0; i--)
            {
                PasswordAsInt[i]++;
                if (PasswordAsInt[i] > HighestASCII)
                {
                    PasswordAsInt[i] = LowestASCII;
                }
                else
                {
                    break;
                }
            }
        }
        public bool test(ref int[] PasswordAsInt)
        {
            int LastChar = -1;
            int DoubleCounter = 0;
            bool HasStraight = false;
            bool NoForbiddenCharacters = true;
            for (int i = 0; i < 8; i++)
            {
                int Current = PasswordAsInt[i];
                if (Current == 105 || Current == 111 || Current == 108)
                {
                    NoForbiddenCharacters = false;
                    break;
                }
                if (Current == LastChar)
                {
                    DoubleCounter++;
                    LastChar = -1;
                    continue;
                }
                if (i >= 2 && Current == PasswordAsInt[i - 1] + 1 && PasswordAsInt[i - 1] == PasswordAsInt[i - 2] + 1)
                    HasStraight = true;
                LastChar = Current;
            }
            return HasStraight && DoubleCounter >= 2 && NoForbiddenCharacters;

        }
    }
}