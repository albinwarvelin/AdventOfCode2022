using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day6 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            string dataStream = input[0];

            for(int i = 3; i < dataStream.Length; i++)
            {
                if(dataStream[i] != dataStream[i - 1] && dataStream[i] != dataStream[i - 1] && dataStream[i] != dataStream[i - 2] && dataStream[i] != dataStream[i - 3] && dataStream[i - 1] != dataStream[i - 2] && dataStream[i - 1] != dataStream[i - 3] && dataStream[i - 2] != dataStream[i - 3])
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        public override void Run2(string[] input)
        {
            string dataStream = input[0];

            for(int i = 13; i < dataStream.Length; i++)
            {
                if (IsMessage(dataStream, i) == true)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }

        private bool IsMessage(string dataStream, int i)
        {
            for (int j = i; j > i - 14; j--)
            {
                for (int k = j - 1; k > i - 14; k--)
                {
                    if (dataStream[j] == dataStream[k])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
