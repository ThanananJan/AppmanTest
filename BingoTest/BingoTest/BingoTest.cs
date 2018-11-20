using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BingoTest
{
    [TestClass]
    public class BingoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
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
    }
}
