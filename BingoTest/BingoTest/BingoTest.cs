using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BingoTest
{
    [TestClass]
    public class BingoTest
    {
        [TestMethod]
        public void testBingo_1()
        {
           
            var output1 = true;
            var result1 = CheckBingo(GetInput1(),GetBoard());
            Assert.IsTrue(result1 == output1);
           

        }
        [TestMethod]
        public void testBingo_2()
        {
            var output2 = false;
            var result2 = CheckBingo(GetInput2(), GetBoard());
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void testBingo_3()
        {
            var output3 = true;
            var result3 = CheckBingo(GetInput3(), GetBoard());
            Assert.IsTrue(result3);
        }

        private int[,] GetBoard()
        {
            return new int[,] { { 1,2,3,4,5},
                                { 6,7,8,9,10},
                                {11,12,13,14,15 },
                                {16,17,18,19,20 },
                                {21,22,23,24,25 } };
        }
        private int[] GetInput1()
        {
            return new int[] { 3, 4, 8, 13, 18, 19, 23 };
        }
        private int[] GetInput2()
        {
            return new int[] { 1, 13, 19, 25, 23, 2 };
        }
        private int[] GetInput3()
        {
            return new int[] { 2, 1, 12, 15, 6, 18, 16, 4, 3, 21, 11 };
        }

        private int[,] GetIndexData(string str, int[,] board)
        {
            var ss = GetDataArray(str);
            return GetIndex(ss, board);
        }

        private int[] GetDataArray(string str)
        {
            var ss = str.Split(',');
            var result = new int[ss.Length];
            for(int i = 0; i < ss.Length; i++) {
                result[i] = Convert.ToInt32(ss[i]);
            }
            return result;
        }

        [TestMethod]
        public void test_get_index()
        {
            var input = new int[] { 7, 8,14 };
            var output = new int[,] { { 2, 2, 3 },{ 2, 3, 4 }  };
            var board = GetBoard();
            var result = GetIndex(input, board);
            Assert.IsTrue(getStrFromArr(output)==getStrFromArr(result));          
        }
        [TestMethod]
        public void test_get_index_false()
        {
            var input = new int[] { 7, 8, 14 };
            var output = new int[,] { { 2, 2, 4 }, { 2, 3, 4 } };
            var board = GetBoard();
            var result = GetIndex(input, board);
            Assert.IsFalse(getStrFromArr(output) == getStrFromArr(result));
        }
        private string getStrFromArr(int[,] arr)
        {
            var str = "";
            for (int i = 0; i <2; i++)
            {
                for (int j = 0; j < arr.Length / 2; j++)
                {
                    str += arr[i,j].ToString();
                }
            }
            return str;
        }

        private int[,] GetIndex(int[] data, int[,] board,int size = 5)
        {
            var result = new int[2, data.Length];
            for(int z = 0; z < data.Length; z++)
            {

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                        if (data[z] == board[i,j])
                        {
                            result[0, z] = i + 1;
                            result[1, z] = j + 1;
                        }

                        }
                    }
            }
            return result;
        }
        public bool CheckBingo(int[] data,int[,] board)
        {
            var index = GetIndex(data, board);
            return CheckBingo(index);
        }
        public bool CheckBingo(int[,] data,int size=5,int target=15)
        {
            if (CheckBingoRow(data,size,target)) return true;
            if (CheckBingoCol(data,size,target)) return true;
            if (CheckBingoCrossDT(data,size,target)) return true;
            if (CheckBingoCrossTD(data,size,target)) return true;
            if (CheckBingoCorner(data,size,size)) return true;
            else return false;
        }

        private bool CheckBingoCorner(int[,] data, int size, int target)
        {

            var sum = 0;
            var mid = (size + 1) / 2;
            for(int z=0; z < data.Length / 2; z++)
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
                    if (data[0, z] ==i &&data[1, z]==size-i+1)
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
            for(int i = 1; i <= size; i++)
            {
                for(int z = 0; z < data.Length / 2; z++)
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
