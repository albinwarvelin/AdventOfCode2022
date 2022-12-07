using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day7 : AdventOfCode
    {
        public override void Run1(string[] input)
        {
            Directory mainDir = new Directory("mainDir", null);
            Directory currentDir = mainDir;

            for(int i = 1; i < input.Length; i++)
            {
                if(input[i] == "$ ls")
                {

                }
                else if(input[i].Substring(0, 3) == "dir")
                {
                    currentDir.Contents.Add(new Directory(input[i].Substring(4), currentDir));
                }
                else if (input[i].Substring(0, 7) == "$ cd ..")
                {
                    currentDir = currentDir.Parent;
                }
                else if(input[i].Substring(0, 4) == "$ cd")
                {
                    for(int j = 0; j < currentDir.Contents.Count; j++)
                    {
                        if (currentDir.Contents[j].Name == input[i].Substring(5))
                        {
                            currentDir = currentDir.Contents[j];
                            break;
                        }
                    }
                }
                else if(int.TryParse(input[i].Substring(0, 1), out _) == true)
                {
                    string[] temp = input[i].Split(' ');
                    currentDir.Contents.Add(new FileD(int.Parse(temp[0]), temp[1], currentDir));
                }
            }

            List<int> sizes = new List<int>();
            Size(mainDir, sizes);

            int sumSizes = 0;
            
            foreach(int size in sizes)
            {
                if(size <= 100000)
                {
                    sumSizes += size;
                }
            }

            Console.WriteLine(sumSizes);
        }

        public override void Run2(string[] input)
        {
            Directory mainDir = new Directory("mainDir", null);
            Directory currentDir = mainDir;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == "$ ls")
                {

                }
                else if (input[i].Substring(0, 3) == "dir")
                {
                    currentDir.Contents.Add(new Directory(input[i].Substring(4), currentDir));
                }
                else if (input[i].Substring(0, 7) == "$ cd ..")
                {
                    currentDir = currentDir.Parent;
                }
                else if (input[i].Substring(0, 4) == "$ cd")
                {
                    for (int j = 0; j < currentDir.Contents.Count; j++)
                    {
                        if (currentDir.Contents[j].Name == input[i].Substring(5))
                        {
                            currentDir = currentDir.Contents[j];
                            break;
                        }
                    }
                }
                else if (int.TryParse(input[i].Substring(0, 1), out _) == true)
                {
                    string[] temp = input[i].Split(' ');
                    currentDir.Contents.Add(new FileD(int.Parse(temp[0]), temp[1], currentDir));
                }
            }

            List<Directory> directories = new List<Directory>();
            directories.Add(mainDir);
            int totalSize = 0;

            for(int i = 0; i < directories.Count; i++)
            {
                for(int j = 0; j < directories[i].Contents.Count; j++)
                {
                    if(directories[i].Contents[j] is FileD)
                    {
                        totalSize += (directories[i].Contents[j] as FileD).Size;
                    }
                    else
                    {
                        directories.Add(directories[i].Contents[j]);
                    }
                }
            }

            List<int> sizes = new List<int>();

            FindDir(mainDir, sizes, totalSize);

            int smallest = sizes[0];

            foreach(int size in sizes)
            {
                if (size < smallest)
                {
                    smallest = size;
                }
            }

            Console.WriteLine(smallest);
        }

        private int Size(Directory dir, List<int> sizes)
        {
            int size = 0;

            for (int i = 0; i < dir.Contents.Count; i++)
            {
                if (dir.Contents[i] is FileD)
                {
                    size += (dir.Contents[i] as FileD).Size;
                }
                else if (dir.Contents[i] is Directory)
                {
                    size += Size(dir.Contents[i], sizes);
                }
            }

            sizes.Add(size);
            return size;
        }

        private int FindDir(Directory dir, List<int> sizes, int totalSize)
        {
            int size = 0;

            for (int i = 0; i < dir.Contents.Count; i++)
            {
                if (dir.Contents[i] is FileD)
                {
                    size += (dir.Contents[i] as FileD).Size;
                }
                else if (dir.Contents[i] is Directory)
                {
                    size += FindDir(dir.Contents[i], sizes, totalSize);
                }
            }

            if(size >= totalSize - 40000000)
            {
                sizes.Add(size);
            }

            return size;
        }
    }

    internal class Directory
    {
        private string name;
        private List<Directory> contents = new List<Directory>();
        private Directory parent;

        public Directory(string name, Directory parent)
        {
            this.name = name;
            this.parent = parent;
        }

        public string Name 
        { 
            get 
            { 
                return name; 
            } 
        }

        public List<Directory> Contents 
        { 
            get 
            { 
                return contents; 
            } 
        }

        public Directory Parent
        {
            get { return parent; }
        }
    }

    internal class FileD : Directory
    {
        private int size;

        public FileD(int size, string name, Directory parent):base(name, parent)
        {
            this.size = size;
        }

        public int Size 
        { 
            get 
            { 
                return size; 
            } 
        }    
    }
}
