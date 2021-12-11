using System;
using System.IO;
using System.Linq;

namespace DayThreeProblemOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputRaw = File.ReadAllText(@"C:\Users\gunex\Desktop\AdventOfCode2021\AdventOfCode2021\Inputs\DayThree.txt");
            string[] input = inputRaw.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int bitsLength = 12;

            char[] gamma = new char[bitsLength]; 
            char[] epsilon = new char[bitsLength];

            int[] mostCommon = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            foreach (string bits in input)
            {
                for (int i = 0; i < bitsLength; i++)
                {
                    switch (bits[i])
                    {
                        case '1':
                            mostCommon[i]++;
                            break;
                        case '0':
                            mostCommon[i]--;
                            break;
                        default:
                            break;
                    }
                }
            }

            for (int i = 0; i < bitsLength; i++)
            {
                gamma[i] = mostCommon[i] > 0 ? '1' :'0';
                epsilon[i] = mostCommon[i] > 0 ? '0' :'1';
            }

            int gammaRate = Convert.ToInt32(String.Join("", gamma), 2);
            int epsilonRate = Convert.ToInt32(String.Join("", epsilon), 2);

            Console.WriteLine(gammaRate * epsilonRate);
        }
    }
}
