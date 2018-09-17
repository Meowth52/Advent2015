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
            while (Index >= 0 && Index <= AssembleCounter)
            {

            }
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
            Int32.TryParse(Splitstring[2], out Offset);
        }
        public int AssembelBunnysAssemble(int i, ref int a, ref int b)
        {
            
            char caseSwitch = Type;

            switch (caseSwitch)
            {
                case 'f':
                    a=a/2;
                    break;
                case 'l':
                    Console.WriteLine("Case 2");
                    break;
                case 'c':
                    Console.WriteLine("Case 2");
                    break;
                case 'p':
                    Console.WriteLine("Case 2");
                    break;
                case 'e':
                    Console.WriteLine("Case 2");
                    break;
                case 'o':
                    Console.WriteLine("Case 2");
                    break;
                default:
                    ;
                    break;
            }
            return 1;
      int caseSwitch = 1;
      
      switch (caseSwitch)
      {
          case 1:
              Console.WriteLine("Case 1");
              break;
          case 2:
              Console.WriteLine("Case 2");
              break;
          default:
              Console.WriteLine("Default case");
              break;
      }
        }
    }
}