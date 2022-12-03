using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            string items = "";

            foreach(string rucksack in input)
            {
                string compartment1 = rucksack.Substring(0, rucksack.Length / 2);
                string compartment2 = rucksack.Substring(rucksack.Length / 2);

                foreach(char item in compartment1)
                {
                    if (compartment2.Contains(item))
                    {
                        items += item;
                        break;
                    }
                }
            }

            int priority = 0;

            foreach(char item in items)
            {
                if(char.IsUpper(item))
                {
                    priority += item - 38;
                }
                else
                {
                    priority += item - 96;
                }
            }

            Console.WriteLine(priority);
        }

        public override void Run2(string[] input)
        {
            string badges = "";

            for(int i = 0; i < input.Length; i += 3)
            {
                foreach(char item in input[i])
                {
                    if(input[i + 1].Contains(item) && input[i + 2].Contains(item))
                    {
                        badges += item;
                        break;
                    }
                }
            }

            int priority = 0;

            foreach (char item in badges)
            {
                if (char.IsUpper(item))
                {
                    priority += item - 38;
                }
                else
                {
                    priority += item - 96;
                }
            }

            Console.WriteLine(priority);
        }
    }
}
