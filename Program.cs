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
            string[] input = File.ReadAllLines("inputs/day11.txt");

            //Day11_2.Main2();
            AdventOfCode adventOfCode = new Day11();

            //adventOfCode.Run1(input);
            adventOfCode.Run2(input);
        }
    }
}
