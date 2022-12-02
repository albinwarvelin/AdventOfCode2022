﻿using System;
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
            string[] input = File.ReadAllLines("inputs/day2.txt");


            AdventOfCode adventOfCode = new Day2();

            adventOfCode.Run1(input);
            adventOfCode.Run2(input);
        }
    }
}
