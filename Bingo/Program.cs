using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            var rule = new BingoRule();
            while (true)
            {
                Console.Clear();
                ShowBoard(GetBoard());
                Console.WriteLine("Input :");
                var input = Console.ReadLine();
                Console.Write("Result : ");
                var result = rule.CheckBingo(input, GetBoard());
                Console.Write(result ? "Bingo" : "Not Bingo");
                Console.WriteLine();
                Console.Write("Press x to exist : ");
                var key = Console.ReadLine();
                if (key == "x" || key == "X") break;
            }

        }
       static private void ShowBoard(int[,] data,int size = 5)
        {
            for (int i = 0; i < size; i++) {
                Console.Write("\t");
                for(int j = 0; j < size; j++)
                {
                    Console.Write(string.Format("{0}\t", data[i, j].ToString()));
                }
                Console.WriteLine();
            }
        }
       static private int[,] GetBoard()
        {
            return new int[,] { { 1,2,3,4,5},
                                { 6,7,8,9,10},
                                {11,12,13,14,15 },
                                {16,17,18,19,20 },
                                {21,22,23,24,25 } };
        }
    }
}
