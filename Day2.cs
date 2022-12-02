using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            int points = 0;

            foreach(string line in input)
            {
                switch(line[0])
                {
                    case 'A':
                        switch(line[2])
                        {
                            case 'X':
                                points += 4;
                                break;
                            case 'Y':
                                points += 8;
                                break;
                            case 'Z':
                                points += 3;
                                break;
                        }
                        break;
                    case 'B':
                        switch (line[2])
                        {
                            case 'X':
                                points += 1;
                                break;
                            case 'Y':
                                points += 5;
                                break;
                            case 'Z':
                                points += 9;
                                break;
                        }
                        break;
                    case 'C':
                        switch (line[2])
                        {
                            case 'X':
                                points += 7;
                                break;
                            case 'Y':
                                points += 2;
                                break;
                            case 'Z':
                                points += 6;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(points);
        }

        public override void Run2(string[] input)
        {
            int points = 0;

            foreach (string line in input)
            {
                switch (line[0])
                {
                    case 'A':
                        switch (line[2])
                        {
                            case 'X':
                                points += 3;
                                break;
                            case 'Y':
                                points += 4;
                                break;
                            case 'Z':
                                points += 8;
                                break;
                        }
                        break;
                    case 'B':
                        switch (line[2])
                        {
                            case 'X':
                                points += 1;
                                break;
                            case 'Y':
                                points += 5;
                                break;
                            case 'Z':
                                points += 9;
                                break;
                        }
                        break;
                    case 'C':
                        switch (line[2])
                        {
                            case 'X':
                                points += 2;
                                break;
                            case 'Y':
                                points += 6;
                                break;
                            case 'Z':
                                points += 7;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(points);
        }
    }
}
