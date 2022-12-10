using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day10 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            int cycle = 0;
            int register = 0;

            for(int i = 0; i < input.Length; i++)
            {
                cycle++;
                if(cycle >= 19 && cycle <= 20)
                {
                    Console.WriteLine(20 * register);
                }
                if (cycle >= 59 && cycle <= 60)
                {
                    Console.WriteLine(60 * register);
                }
                if (cycle >= 99 && cycle <= 100)
                {
                    Console.WriteLine(100 * register);
                }
                if (cycle >= 139 && cycle <= 140)
                {
                    Console.WriteLine(140 * register);
                }
                if (cycle >= 179 && cycle <= 180)
                {
                    Console.WriteLine(180 * register);
                }
                if (cycle >= 219 && cycle <= 220)
                {
                    Console.WriteLine(220 * register);
                }

                if (input[i].Substring(0, 4) == "addx")
                {
                    cycle++;
                    register += int.Parse(input[i][5..]);
                }
            }
        }

        public override void Run2(string[] input)
        {
            int cycle = -1;
            int register = 1;

            for (int i = 0; i < input.Length; i++)
            {
                cycle++;
                
                if(cycle == 40)
                {
                    Console.WriteLine();
                    cycle = 0;
                }
                if(cycle >= register - 1 && cycle <= register + 1)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }


                if (input[i].Substring(0, 4) == "addx")
                {
                    cycle++;

                    if (cycle == 40)
                    {
                        Console.WriteLine();
                        cycle = 0;
                    }
                    if (cycle >= register - 1 && cycle <= register + 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }

                    register += int.Parse(input[i][5..]);
                }
            }
        }
    }
}
