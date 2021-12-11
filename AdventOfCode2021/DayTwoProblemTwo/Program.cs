using System;
using System.IO;
using System.Linq;

namespace DayTwoProblemTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputRaw = File.ReadAllText(@"C:\Users\gunex\Desktop\AdventOfCode2021\AdventOfCode2021\Inputs\DayTwo.txt");
            string[] inputs = inputRaw.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int horizontalPostion = 0;
            int depth = 0;
            int aim = 0;

            foreach (string input in inputs)
            {
                string[] inputSplit = input.Split(" ");
                string command = inputSplit[0];
                int value = int.Parse(inputSplit[1]);

                switch (command)
                {
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "forward":
                        horizontalPostion += value;
                        depth += aim * value;
                        break;
                    default: break;
                }
            }
            Console.WriteLine(horizontalPostion * depth);
        }
    }
}
