using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayFourProblemOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputRaw = File.ReadAllLines(@"C:\Users\gunex\Desktop\AdventOfCode2021\AdventOfCode2021\Inputs\DayFour.txt");
          
            string[] numbers = inputRaw[0].Split(',').ToArray();

            List<string[,]> boards = new List<string[,]>();

            string[,] winner = new string[5,5];
            string lastNumber = "";

            GetBoards(inputRaw, boards);

            for (int i = 0; i < numbers.Length; i++)
            {
                MarkNumbers(boards, numbers[i]);
                string[,] winnerBoard = CheckForBingo(boards);
                if (winnerBoard != null)
                {
                    winner = winnerBoard;
                    lastNumber = numbers[i];
                    break;
                }
            }

            int score = GetWinningBoardScore(winner, lastNumber);

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

        private static string[,] CheckForBingo(List<string[,]> boards)
        {

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
                        return board;
                    }
                }
                //columns
                for (int column = 0; column < 5; column++)
                {
                    int consecutive = 0;
                    for (int row = 0; row < 5; row++)
                    {
                        if (board[column, row] != "x")
                        {
                            break;
                        }
                        consecutive++;
                    }
                    if (consecutive == 5)
                    {
                        return board;
                    }
                }
            }
            return null;
        }

        private static int GetWinningBoardScore(string[,] board, string lastNumber)
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
