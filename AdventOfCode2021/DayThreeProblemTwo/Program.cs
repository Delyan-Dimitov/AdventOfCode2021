using System;
using System.IO;
using System.Linq;

namespace DayThreeProblemTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputRaw = File.ReadAllText(@"C:\Users\gunex\Desktop\AdventOfCode2021\AdventOfCode2021\Inputs\DayThree.txt");
            string[] input = inputRaw.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int bitsLength = input[0].Length;

            string oxygenGeneratorRatingBits = GetRating(input, bitsLength, 0, '1', true);
            string c02ScrubberRatingBits = GetRating(input, bitsLength, 0, '0', false);


            int oxygenGeneratorRating = Convert.ToInt32(String.Join("", oxygenGeneratorRatingBits), 2);
            int c02ScrubberRating = Convert.ToInt32(String.Join("", c02ScrubberRatingBits), 2);

            Console.WriteLine(oxygenGeneratorRating * c02ScrubberRating);
        }

        private static string GetRating(string[] bitArray, int bitsLength, int position, char defaultBit, bool findMostCommon)
        {
            char bit;

            if (bitArray.Length == 1)
            {
                return bitArray[0];
            }

            int bitSumAtPosition = 0;
            foreach (string bits in bitArray)
            {
                switch (bits[position])
                {
                    case '1':
                        bitSumAtPosition++;
                        break;
                    case '0':
                        bitSumAtPosition--;
                        break;
                    default:
                        break;
                }
            }
            bit = bitSumAtPosition != 0 ?
                bitSumAtPosition < 0 ?
                findMostCommon ? '0' : '1' :
                findMostCommon ? '1' : '0' : defaultBit;
                

            string[] newbitArray = bitArray.Where(x => x[position] == bit).ToArray();
            position++;

            return GetRating(newbitArray, bitsLength, position, defaultBit, findMostCommon);
        }
    }
}
