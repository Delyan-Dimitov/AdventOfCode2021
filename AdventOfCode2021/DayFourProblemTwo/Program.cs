using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DayFourProblemTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            //  I hope no one sees this code
             
            string[] inputRaw = File.ReadAllLines(@"C:\Users\gunex\Desktop\AdventOfCode2021\AdventOfCode2021\Inputs\DayFour.txt");

            string[] numbers = inputRaw[0].Split(',').ToArray();

            List<string[,]> boards = new List<string[,]>();
            List<string[,]> winners = new List<string[,]>();

            string[,] lastWinner = new string[5, 5];
            string lastNumber = "";

            GetBoards(inputRaw, boards);

            for (int i = 0; i < numbers.Length; i++)
            {
                MarkNumbers(boards, numbers[i]);
                CheckForBingo(boards, winners);
                if (boards.Count == 0)
                {
                    lastNumber = numbers[i];
                    break;
                }
            }

            lastWinner = winners[winners.Count - 1];
            int score = GetLastBoardScore(lastWinner, lastNumber);

            Console.WriteLine(score);

        }
        private static void GetBoards(string[] inputRaw, List<string[,]> boards)
        {
            for (int i = 2; i < inputRaw.Length; i += 6)
            {
                string[,] board = new string[5, 5];
                for (int j = 0; j < 5; j++)
                {
                    string[] line = inputRaw[j + i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < line.Length; k++)
                    {
                        board[j, k] = line[k];
                    }
                }
                boards.Add(board);
            }
        }
        private static void CheckForBingo(List<string[,]> boards, List<string[,]> winners)
        {
            List<string[,]> boardsToRemove = new List<string[,]>();

            foreach (var board in boards)
            {
                //rows
                for (int row = 0; row < 5; row++)
                {
                    int consecutive = 0;
                    for (int column = 0; column < 5; column++)
                    {
                        if (board[row, column] != "x")
                        {
                            break;
                        }
                        consecutive++;
                    }
                    if (consecutive == 5)
                    {
                        boardsToRemove.Add(board);
                    }
                }
                //columns
                for (int column = 0; column < 5; column++)
                {
                    int consecutive = 0;
                    for (int row = 0; row < 5; row++)
                    {
                        if (board[row, column] != "x")
                        {
                            break;
                        }
                        consecutive++;
                    }
                    if (consecutive == 5)
                    {
                        boardsToRemove.Add(board);
                    }
                }
            }
            foreach (string[,] board in boardsToRemove)
            {
                boards.Remove(board);
                winners.Add(board);
            }
        }
        private static void MarkNumbers(List<string[,]> boards, string number)
        {
            foreach (var board in boards)
            {
                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 5; column++)
                    {
                        if (board[row, column] == number)
                        {
                            board[row, column] = "x";
                        }
                    }
                }
            }
        }
        private static int GetLastBoardScore(string[,] board, string lastNumber)
        {
            int lastNumberAsInt = int.Parse(lastNumber);
            List<int> boardNumbers = new List<int>();
            int boardNumberSum;

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (board[row, col] != "x")
                    {
                        int cellAsInt = int.Parse(board[row, col]);

                        boardNumbers.Add(cellAsInt);
                    }
                }
            }

            boardNumberSum = boardNumbers.Sum();

            return boardNumberSum * lastNumberAsInt;
        }


    }
}
