using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class BingoRule
    {
        int size, target;
        public BingoRule()
        {
            size = 5;
            target = 15;
        }
        public BingoRule(int _size)
        {
            size = _size;
            target = GetTarget(_size);
        }
        private int GetTarget(int size)
        {
            var result = 0;
            for(int i = 1; i <= size; i++)
            {
                result += i;
            }
            return result;
        }
        private int[,] GetIndex(int[] data, int[,] board, int size = 5)
        {
            var result = new int[2, data.Length];
            for (int z = 0; z < data.Length; z++)
            {

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (data[z] == board[i, j])
                        {
                            result[0, z] = i + 1;
                            result[1, z] = j + 1;
                        }

                    }
                }
            }
            return result;
        }
        private int[,] GetIndexData(string str, int[,] board)
        {
            var ss = GetDataArray(str);
            return GetIndex(ss, board,size);
        }
        private int[] GetDataArray(string str)
        {
            var ss = str.Split(',');
            var result = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                result[i] = Convert.ToInt32(ss[i]);
            }
            return result;
        }
        public bool CheckBingo(string data, int[,] board)
        {
            var index = GetIndexData(data, board);
            return CheckBingo(index);
        }
        public bool CheckBingo(int[] data, int[,] board)
        {
            var index = GetIndex(data, board);
            return CheckBingo(index);
        }
        public bool CheckBingo(int[,] data, int size = 5, int target = 15)
        {
            if (CheckBingoRow(data, size, target)) return true;
            if (CheckBingoCol(data, size, target)) return true;
            if (CheckBingoCrossDT(data, size, target)) return true;
            if (CheckBingoCrossTD(data, size, target)) return true;
            if (CheckBingoCorner(data, size, size)) return true;
            else return false;
        }

        private bool CheckBingoCorner(int[,] data, int size, int target)
        {

            var sum = 0;
            var mid = (size + 1) / 2;
            for (int z = 0; z < data.Length / 2; z++)
            {
                if (data[0, z] == 1 && data[1, z] == 1)
                {
                    sum += 1;
                }
                else if (data[0, z] == size && data[1, z] == 1)
                {
                    sum += 1;
                }
                else if (data[0, z] == 1 && data[1, z] == size)
                {
                    sum += 1;
                }
                else if (data[0, z] == mid && data[1, z] == mid)
                {
                    sum += 1;
                }
                else if (data[0, z] == size && data[1, z] == size)
                {
                    sum += 1;
                }
            }
            if (sum == target) return true;
            else return false;
        }

        private bool CheckBingoCrossTD(int[,] data, int size, int target)
        {
            var result = false;
            var sum = 0;
            for (int i = 1; i <= size; i++)
            {
                for (int z = 0; z < data.Length / 2; z++)
                {
                    if (data[0, z] == i && data[1, z] == i)
                    {
                        sum += data[0, z];
                    }
                }
                if (sum == target) return true;
                else sum = 0;
            }
            return result;
        }

        private bool CheckBingoCrossDT(int[,] data, int size, int target)
        {
            var result = false;
            var sum = 0;
            for (int i = 1; i <= size; i++)
            {
                for (int z = 0; z < data.Length / 2; z++)
                {
                    if (data[0, z] == i && data[1, z] == size - i + 1)
                    {
                        sum += data[0, z];
                    }
                }
                if (sum == target) return true;
                else sum = 0;
            }
            return result;
        }

        private bool CheckBingoCol(int[,] data, int size, int target)
        {
            var result = false;
            var sum = 0;
            for (int i = 1; i <= size; i++)
            {
                for (int z = 0; z < data.Length / 2; z++)
                {
                    if (data[1, z] == i)
                    {
                        sum += data[0, z];
                    }
                }
                if (sum == target) return true;
                else sum = 0;
            }
            return result;
        }

        private bool CheckBingoRow(int[,] data, int size, int target)
        {
            var result = false;
            var sum = 0;
            for (int i = 1; i <= size; i++)
            {
                for (int z = 0; z < data.Length / 2; z++)
                {
                    if (data[0, z] == i)
                    {
                        sum += data[1, z];
                    }
                }
                if (sum == target) return true;
                else sum = 0;
            }
            return result;
        }
    }
}
