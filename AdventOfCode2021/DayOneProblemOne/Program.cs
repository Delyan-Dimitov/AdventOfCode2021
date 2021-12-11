using System;
using System.IO;
using System.Linq;

namespace DayOneProblemOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputRaw = File.ReadAllText(@"C:\Users\gunex\Desktop\AdventOfCode2021\AdventOfCode2021\Inputs\DayOnePartOne.txt");
            int[] input = inputRaw.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            int largerMeasurements = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > input[i - 1])
                {
                    largerMeasurements++;
                }
            }
            Console.WriteLine(largerMeasurements);
        }
    }
}
