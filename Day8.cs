using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day8 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            int[][] trees = new int[99][];
            for(int i = 0; i < 99; i++)
            {
                trees[i] = new int[99];
            }

            for(int i = 0;i < 99; i++)
            {
                for(int j = 0; j < 99; j++)
                {
                    trees[i][j] = int.Parse("" + input[i][j]);
                }
            }

            int visibleTrees = 0;

            for(int i = 0; i < 99; i++)
            {
                for(int j = 0; j < 99; j++)
                {
                    int focusedTree = trees[i][j];
                    bool isVisibleU = true;
                    bool isVisibleR = true;
                    bool isVisibleD = true;
                    bool isVisibleL = true;


                    for (int k = i - 1; k >= 0; k--) //Check upwards
                    {
                        if(focusedTree <= trees[k][j])
                        {
                            isVisibleU = false;
                            break;
                        }
                    }

                    for (int k = j + 1; k < 99; k++) //Check right
                    {
                        if (focusedTree <= trees[i][k])
                        {
                            isVisibleR = false;
                            break;
                        }
                    }

                    for (int k = i + 1; k < 99; k++) //Check downwards
                    {
                        if (focusedTree <= trees[k][j])
                        {
                            isVisibleD = false;
                            break;
                        }
                    }

                    for (int k = j - 1; k >= 0; k--) //Check left
                    {
                        if (focusedTree <= trees[i][k])
                        {
                            isVisibleL = false;
                            break;
                        }
                    }

                    if (isVisibleU || isVisibleR || isVisibleD || isVisibleL)
                    {
                        visibleTrees++;
                    }
                }
            }

            Console.WriteLine(visibleTrees);
        }

        public override void Run2(string[] input)
        {
            int[][] trees = new int[99][];
            for (int i = 0; i < 99; i++)
            {
                trees[i] = new int[99];
            }

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    trees[i][j] = int.Parse("" + input[i][j]);
                }
            }

            int topScenicScore = 0;

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    int focusedTree = trees[i][j];
                    int viewU = 0;
                    int viewR = 0;
                    int viewD = 0;
                    int viewL = 0;
                    

                    for (int k = i - 1; k >= 0; k--) //Check upwards
                    {
                        viewU++;

                        if (focusedTree <= trees[k][j])
                        {
                            break;
                        }
                    }

                    for (int k = j + 1; k < 99; k++) //Check right
                    {
                        viewR++;

                        if (focusedTree <= trees[i][k])
                        {
                            break;
                        }
                    }

                    for (int k = i + 1; k < 99; k++) //Check downwards
                    {
                        viewD++;

                        if (focusedTree <= trees[k][j])
                        {
                            break;
                        } 
                    }

                    for (int k = j - 1; k >= 0; k--) //Check left
                    {
                        viewL++;

                        if (focusedTree <= trees[i][k])
                        {
                            break;
                        }                     
                    }

                    if (viewU * viewR * viewD * viewL > topScenicScore)
                    {
                        topScenicScore = viewU * viewR * viewD * viewL;
                    }
                }
            }

            Console.WriteLine(topScenicScore);
        }
    }
}
