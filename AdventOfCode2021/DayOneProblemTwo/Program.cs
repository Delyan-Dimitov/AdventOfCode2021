using System;
using System.IO;
using System.Linq;

namespace DayOneProblemTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputRaw = File.ReadAllText(@"C:\Users\gunex\Desktop\AdventOfCode2021\AdventOfCode2021\Inputs\DayOne.txt");
            int[] input = inputRaw.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = input.Length - 2;
            int columns = 3;

            int[,] groupsOfThree = new int[rows, columns];

            int largerMeasurements = 0;

            for (int i = 0; i < rows; i++)
            {
                groupsOfThree[i, 0] = input[i];
                groupsOfThree[i, 1] = input[i + 1];
                groupsOfThree[i, 2] = input[i + 2];
            }

            for (int i = 1; i < rows; i++)
            {
                int currentRowsSum = groupsOfThree[i, 0] + groupsOfThree[i, 1] + groupsOfThree[i, 2];
                int prevRowSum = groupsOfThree[i - 1, 0] + groupsOfThree[i - 1, 1] + groupsOfThree[i - 1, 2];

                if (currentRowsSum > prevRowSum)
                {
                    largerMeasurements++;
                }
            }
            Console.WriteLine(largerMeasurements);
        }
    }
}
