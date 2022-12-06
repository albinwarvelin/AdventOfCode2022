using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            Stack<char>[] stacks =  new Stack<char>[9];
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>();
            }

            for (int i = 7; i >= 0; i--)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(input[i][j] != ' ')
                    {
                        stacks[j].Push(input[i][j]);
                    }
                }
            }

            for (int i = 10; i < input.Length; i++)
            {
                int count = int.Parse(input[i].Substring(5, input[i].IndexOf(' ', 5) - 5));
                int fromStackIndex = int.Parse(input[i].Substring(input[i].IndexOf("from") + 5, 1)) - 1;
                int toStackIndex = int.Parse(input[i].Substring(input[i].IndexOf("from") + 10, 1)) - 1;


                for (int j = 0; j < count; j++)
                {
                    stacks[toStackIndex].Push(stacks[fromStackIndex].Pop());
                }
            }
            
            for (int i = 0; i < 9; i++)
            {
                Console.Write(stacks[i].Peek());
            }

            Console.WriteLine();
        }

        public override void Run2(string[] input)
        {
            Stack<char>[] stacks = new Stack<char>[9];
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>();
            }

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (input[i][j] != ' ')
                    {
                        stacks[j].Push(input[i][j]);
                    }
                }
            }

            for (int i = 10; i < input.Length; i++)
            {
                int count = int.Parse(input[i].Substring(5, input[i].IndexOf(' ', 5) - 5));
                int fromStackIndex = int.Parse(input[i].Substring(input[i].IndexOf("from") + 5, 1)) - 1;
                int toStackIndex = int.Parse(input[i].Substring(input[i].IndexOf("from") + 10, 1)) - 1;

                Stack<char> tempStack = new Stack<char>();

                for (int j = 0; j < count; j++)
                {
                    tempStack.Push(stacks[fromStackIndex].Pop());
                }

                for (int j = 0; j < count; j++)
                {
                    stacks[toStackIndex].Push(tempStack.Pop());
                }
            }

            for (int i = 0; i < 9; i++)
            {
                Console.Write(stacks[i].Peek());
            }
        }
    }
}
