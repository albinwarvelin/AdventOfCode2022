using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day1 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            List<int> calories = new List<int>();
            int sumCalories = 0;

            foreach(string line in input)
            {
                if(line != "")
                {
                    sumCalories += int.Parse(line);
                }
                else
                {
                    calories.Add(sumCalories);
                    sumCalories = 0;
                }
            }

            int highestCalories = 0;
            
            foreach(int value in calories)
            {
                if(value > highestCalories)
                {
                    highestCalories = value;
                }
            }

            Console.WriteLine(highestCalories);
        }

        public override void Run2(string[] input)
        {
            List<int> calories = new List<int>();
            int sumCalories = 0;

            foreach (string line in input)
            {
                if (line != "")
                {
                    sumCalories += int.Parse(line);
                }
                else
                {
                    calories.Add(sumCalories);
                    sumCalories = 0;
                }
            }

            int[] highestCalories = new int[3];

            foreach (int value in calories)
            {
                if(value > highestCalories[0])
                {
                    highestCalories[2] = highestCalories[1];
                    highestCalories[1] = highestCalories[0];
                    highestCalories[0] = value;
                }
                else if(value > highestCalories[1])
                {
                    highestCalories[2] = highestCalories[1];
                    highestCalories[1] = value;
                }
                else if(value > highestCalories[2])
                {
                    highestCalories[2] = value;
                }
            }

            Console.WriteLine(highestCalories[0] + highestCalories[1] + highestCalories[2]);
        }
    }
}
