using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("inputs/day7.txt");


            AdventOfCode adventOfCode = new Day7();

            adventOfCode.Run1(input);
            adventOfCode.Run2(input);
        }
    }
}
