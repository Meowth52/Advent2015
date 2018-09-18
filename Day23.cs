using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day23
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day23(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int AssembleCounter = 0;
            int a = 0;
            int b = 0;
            int Index = 0;
            Dictionary<int, Instruction> Assembelbunnys = new Dictionary<int, Instruction>();
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    Assembelbunnys.Add(AssembleCounter, new Instruction(s));
                    AssembleCounter++;
                }
            }
            while (Index >= 0 && Index <= AssembleCounter-1)
            {
                Index += Assembelbunnys[Index].AssembelBunnysAssemble(ref a, ref b);
            }
            Sum = b;
            a = 1;
            b = 0;
            Index = 0;
            while (Index >= 0 && Index <= AssembleCounter - 1)
            {
                Index += Assembelbunnys[Index].AssembelBunnysAssemble(ref a, ref b);
            }
            Sum2 = b;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
    class Instruction
    {
        char Type;
        char Register;
        int Offset = 0;
        public Instruction (string s)
        {
            string[] Splitstring = s.Split(' ');
            Type = Splitstring[0][2];
            Register = Splitstring[1][0];
            Int32.TryParse(Splitstring.Last(), out Offset);
        }
        public int AssembelBunnysAssemble(ref int a, ref int b)
        {
            int ReturnValue = 1;
            int ActiveRegister = 0;
            switch (Register)
            {
                case 'a':
                    ActiveRegister = a;
                    break;
                case 'b':
                    ActiveRegister = b;
                    break;
            }
            char caseSwitch = Type;

            switch (caseSwitch)
            {
                case 'f':
                    ActiveRegister=ActiveRegister/2;
                    break;
                case 'l':
                    ActiveRegister = ActiveRegister * 3;
                    break;
                case 'c':
                    ActiveRegister++;
                    break;
                case 'p':
                    ReturnValue = Offset;
                    break;
                case 'e':
                    if (ActiveRegister%2 == 0)
                        ReturnValue = Offset;
                    break;
                case 'o':
                    if (ActiveRegister == 1)
                        ReturnValue = Offset;
                    break;
                default:
                    ;
                    break;
            }
            switch (Register)
            {
                case 'a':
                    a = ActiveRegister;
                    break;
                case 'b':
                    b = ActiveRegister;
                    break;
                default:
                    ;
                    break;
            }
            return ReturnValue;
        }
    }
}