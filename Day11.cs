using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AdventOfCode2022
{
    internal class Day11 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            Monkey[] monkeys = new Monkey[4];

            for(int i = 0; i < monkeys.Length; i++)
            {
                string[] partInstructions = new string[5];
                for(int j = 0; j < partInstructions.Length; j++)
                {
                    partInstructions[j] = input[j + (i * 7) + 1];
                }

                monkeys[i] = new Monkey(partInstructions);
            }

            for(int rounds = 0; rounds < 1000; rounds++)
            {
                for(int i = 0; i < monkeys.Length; i++)
                {
                    monkeys[i].RunInspections(monkeys);
                }
            }

            foreach(Monkey monkey in monkeys)
            {
                Console.WriteLine(monkey.TimesInspected);
            }

            Console.WriteLine();
        }

        public override void Run2(string[] input)
        {
            Monkey[] monkeys = new Monkey[8];
            
            for (int i = 0; i < monkeys.Length; i++)
            {
                string[] partInstructions = new string[5];
                for (int j = 0; j < partInstructions.Length; j++)
                {
                    partInstructions[j] = input[j + (i * 7) + 1];
                }

                monkeys[i] = new Monkey(partInstructions);
            }

            for (int rounds = 0; rounds < 10000; rounds++)
            {
                for (int i = 0; i < monkeys.Length; i++)
                {
                    monkeys[i].RunInspections2(monkeys);
                }

                Console.WriteLine("Round: " + rounds);
            }


            int[] highestCount = new int[2];

            foreach (Monkey monkey in monkeys)
            {
                Console.WriteLine(monkey.TimesInspected);

                if(monkey.TimesInspected > highestCount[0])
                {
                    highestCount[1] = highestCount[0];
                    highestCount[0] = monkey.TimesInspected;
                }
                else if(monkey.TimesInspected > highestCount[1])
                {
                    highestCount[1] = monkey.TimesInspected;
                }
            }

            Console.WriteLine(highestCount[0] * highestCount[1]);
        }
    }

    internal class Monkey
    {
        private List<long> worryLevels = new List<long>();
        private string value;
        private string op;
        private int divisibleBy;
        private int trueMonkey;
        private int falseMonkey;

        private int timesInspected = 0;

        public Monkey(string[] instructions)
        {
            string[] tempWorryLevels = instructions[0][18..].Split(',');

            for(int i = 0; i < tempWorryLevels.Length; i++)
            {
                worryLevels.Add(int.Parse(tempWorryLevels[i].Trim()));
            }

            op = instructions[1].Substring(23, 1);
            value = instructions[1][25..];

            divisibleBy = int.Parse(instructions[2][21..]);

            trueMonkey = int.Parse(instructions[3][29..]);
            falseMonkey = int.Parse(instructions[4][30..]);
        }

        public List<long> WorryLevels
        {
            get 
            { 
                return worryLevels; 
            }
        }

        public void RunInspections(Monkey[] monkeys)
        {
            while(worryLevels.Count != 0)
            {
                long tempWorryLevel = worryLevels[0];
                worryLevels.RemoveAt(0);

                if(int.TryParse(value, out _))
                {
                    switch (op)
                    {
                        case "+":
                            {
                                tempWorryLevel = tempWorryLevel + int.Parse(value);
                                break;
                            }
                        case "*":
                            {
                                tempWorryLevel = tempWorryLevel * int.Parse(value);
                                break;
                            }
                    }
                }
                else
                {
                    switch (op)
                    {
                        case "+":
                            {
                                tempWorryLevel = tempWorryLevel + tempWorryLevel;
                                break;
                            }
                        case "*":
                            {
                                tempWorryLevel = tempWorryLevel * tempWorryLevel;
                                break;
                            }
                    }
                }

                tempWorryLevel = tempWorryLevel / 3;

                if(tempWorryLevel % divisibleBy == 0)
                {
                    monkeys[trueMonkey].WorryLevels.Add(tempWorryLevel);
                }
                else
                {
                    monkeys[falseMonkey].WorryLevels.Add(tempWorryLevel);
                }

                timesInspected++;
            }
        }

        public void RunInspections2(Monkey[] monkeys)
        {
            while (worryLevels.Count != 0)
            {
                long tempWorryLevel = worryLevels[0];
                worryLevels.RemoveAt(0);

                if (int.TryParse(value, out _))
                {
                    switch (op)
                    {
                        case "+":
                            {
                                tempWorryLevel = tempWorryLevel + int.Parse(value);
                                break;
                            }
                        case "*":
                            {
                                tempWorryLevel = tempWorryLevel * int.Parse(value);
                                break;
                            }
                    }
                }
                else
                {
                    switch (op)
                    {
                        case "+":
                            {
                                tempWorryLevel = tempWorryLevel + tempWorryLevel;
                                break;
                            }
                        case "*":
                            {
                                tempWorryLevel = tempWorryLevel * tempWorryLevel;
                                break;
                            }
                    }
                }

                int LCM = 9699690;
                while (tempWorryLevel >= LCM)
                {
                    tempWorryLevel -= LCM;
                }

                if (tempWorryLevel % divisibleBy == 0)
                {
                    monkeys[trueMonkey].WorryLevels.Add(tempWorryLevel);
                }
                else
                {
                    monkeys[falseMonkey].WorryLevels.Add(tempWorryLevel);
                }


                timesInspected++;
            }
        }

        public int TimesInspected
        {
            get
            { 
                return timesInspected; 
            }
        }

        public int DivisibleBy
        {
            get 
            { 
                return divisibleBy; 
            }
        }
    }
}
