using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day9 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            int size = 500;
            string[][] environment = new string[size][];

            for(int y = 0; y < size; y++)
            {
                environment[y] = new string[size];

                for (int x = 0; x < size; x++)
                {
                    environment[y][x] = ".";
                }
            }

            RopeEnd head = new RopeEnd(size / 2, size / 2);
            RopeEnd tail = new RopeEnd(size / 2, size / 2);

            foreach(string direction in input)
            {
                switch(direction[0])
                {
                    case 'U':
                        {
                            for(int i = 0; i < int.Parse(direction[2..]); i++)
                            {
                                head.MoveUp();
                                if(head.Y < tail.Y - 1)
                                {
                                    tail.MoveUp();

                                    if(head.X < tail.X)
                                    {
                                        tail.MoveLeft();
                                    }
                                    else if(head.X > tail.X)
                                    {
                                        tail.MoveRight();
                                    }
                                }

                                environment[tail.Y][tail.X] = "#";
                            }
                            break;
                        }
                    case 'R':
                        {
                            for (int i = 0; i < int.Parse(direction[2..]); i++)
                            {
                                head.MoveRight();
                                if(head.X > tail.X + 1)
                                {
                                    tail.MoveRight();

                                    if(head.Y < tail.Y)
                                    {
                                        tail.MoveUp();
                                    }
                                    else if(head.Y > tail.Y)
                                    {
                                        tail.MoveDown();
                                    }
                                }

                                environment[tail.Y][tail.X] = "#";
                            }
                            break;
                        }
                    case 'D':
                        {
                            for (int i = 0; i < int.Parse(direction[2..]); i++)
                            {
                                head.MoveDown();
                                if(head.Y > tail.Y + 1)
                                {
                                    tail.MoveDown();

                                    if(head.X < tail.X)
                                    {
                                        tail.MoveLeft();
                                    }
                                    else if (head.X > tail.X)
                                    {
                                        tail.MoveRight();
                                    }
                                }

                                environment[tail.Y][tail.X] = "#";
                            }
                            break;
                        }
                    case 'L':
                        {
                            for (int i = 0; i < int.Parse(direction[2..]); i++)
                            {
                                head.MoveLeft();
                                if(head.X < tail.X - 1)
                                {
                                    tail.MoveLeft();

                                    if(head.Y < tail.Y)
                                    {
                                        tail.MoveUp();
                                    }
                                    else if(head.Y > tail.Y)
                                    {
                                        tail.MoveDown();
                                    }
                                }

                                environment[tail.Y][tail.X] = "#";
                            }
                            break;
                        }
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x == head.X && y == head.Y)
                    {
                        Console.Write("H");
                    }
                    else if (x == tail.X && y == tail.Y)
                    {
                        Console.Write("T");
                    }
                    else
                    {
                        Console.Write(environment[y][x]);
                    }
                }
                Console.WriteLine();
            }

            int count = 0;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if(environment[y][x] == "#")
                    {
                        count++;
                    }
                    else if(environment[y][x] == "T")
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        public override void Run2(string[] input)
        {
            int size = 500;
            string[][] environment = new string[size][];

            for (int y = 0; y < size; y++)
            {
                environment[y] = new string[size];

                for (int x = 0; x < size; x++)
                {
                    environment[y][x] = ".";
                }
            }

            RopeEnd[] ropePart = new RopeEnd[10];
            for (int i = 0; i < ropePart.Length; i++)
            {
                ropePart[i] = new RopeEnd(size / 2, size / 2);
            }

            foreach (string direction in input)
            {
                for(int i = 0; i < int.Parse(direction[2..]); i++)
                {
                    switch(direction[0])
                    {
                        case 'U':
                            {
                                ropePart[0].MoveUp();
                                break;
                            }
                        case 'R':
                            {
                                ropePart[0].MoveRight();
                                break;
                            }
                        case 'D':
                            {
                                ropePart[0].MoveDown();
                                break;
                            }
                        case 'L':
                            {
                                ropePart[0].MoveLeft();
                                break;
                            }
                    }

                    for (int x = 1; x < ropePart.Length; x++)
                    {
                        if(ropePart[x].X > ropePart[x - 1].X && ropePart[x].Y > ropePart[x - 1].Y && !(ropePart[x].X == ropePart[x - 1].X + 1 && ropePart[x].Y == ropePart[x - 1].Y + 1))
                        {
                            ropePart[x].MoveLeft();
                            ropePart[x].MoveUp();
                        }
                        else if(ropePart[x].X < ropePart[x - 1].X && ropePart[x].Y > ropePart[x - 1].Y && !(ropePart[x].X == ropePart[x - 1].X - 1 && ropePart[x].Y == ropePart[x - 1].Y + 1))
                        {
                            ropePart[x].MoveRight();
                            ropePart[x].MoveUp();
                        }
                        else if(ropePart[x].X < ropePart[x - 1].X && ropePart[x].Y < ropePart[x - 1].Y && !(ropePart[x].X == ropePart[x - 1].X - 1 && ropePart[x].Y == ropePart[x - 1].Y - 1))
                        {
                            ropePart[x].MoveRight();
                            ropePart[x].MoveDown();
                        }
                        else if(ropePart[x].X > ropePart[x - 1].X && ropePart[x].Y < ropePart[x - 1].Y && !(ropePart[x].X == ropePart[x - 1].X + 1 && ropePart[x].Y == ropePart[x - 1].Y - 1))
                        {
                            ropePart[x].MoveLeft();
                            ropePart[x].MoveDown();
                        }
                        else if(ropePart[x].Y > ropePart[x - 1].Y + 1)
                        {
                            ropePart[x].MoveUp();
                        }
                        else if(ropePart[x].X < ropePart[x - 1].X - 1)
                        {
                            ropePart[x].MoveRight();
                        }
                        else if(ropePart[x].Y < ropePart[x - 1].Y - 1)
                        {
                            ropePart[x].MoveDown();
                        }
                        else if(ropePart[x].X > ropePart[x - 1].X + 1)
                        {
                            ropePart[x].MoveLeft();
                        }
                    }

                    environment[ropePart[ropePart.Length - 1].Y][ropePart[ropePart.Length - 1].X] = "#";
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Console.Write(environment[y][x]);
                }
                Console.WriteLine();
            }

            int count = 0;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (environment[y][x] == "#")
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }

    internal class RopeEnd
    {
        private int x;
        private int y;

        public RopeEnd(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X 
        { 
            get 
            { 
                return x; 
            } 
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public void MoveUp()
        {
            y--;
        }
        public void MoveRight()
        {
            x++;
        }
        public void MoveDown()
        {
            y++;
        }
        public void MoveLeft()
        {
            x--;
        }
    }
}
