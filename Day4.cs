using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            int count = 0;

            foreach(string line in input)
            {
                string[] parts = line.Split(',');
                string[] tempRange1 = parts[0].Split('-');
                string[] tempRange2 = parts[1].Split('-');
                int[] values = new int[4];
                values[0] = int.Parse(tempRange1[0]);
                values[1] = int.Parse(tempRange1[1]);
                values[2] = int.Parse(tempRange2[0]);
                values[3] = int.Parse(tempRange2[1]);

                if ((values[0] >= values[2] && values[1] <= values[3]) || (values[2] >= values[0] && values[3] <= values[1]))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public override void Run2(string[] input)
        {
            int count = 0;

            foreach (string line in input)
            {
                string[] parts = line.Split(',');
                string[] tempRange1 = parts[0].Split('-');
                string[] tempRange2 = parts[1].Split('-');
                int[] values = new int[4];
                values[0] = int.Parse(tempRange1[0]);
                values[1] = int.Parse(tempRange1[1]);
                values[2] = int.Parse(tempRange2[0]);
                values[3] = int.Parse(tempRange2[1]);

                if ((values[1] >= values[2] && values[1] <= values[3]) || (values[0] >= values[2] && values[0] <= values[3]) || (values[2] >= values[0] && values[2] <= values[1]) || (values[3] >= values[0] && values[3] <= values[1]))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
