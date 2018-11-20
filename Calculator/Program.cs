using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cal = new CalculatorStr();
            Console.WriteLine("Please Input :");
            while (true)
            {
                Console.Write("\t");
                var str = Console.ReadLine();
                var result = cal.Calculate(str);
                Console.WriteLine(string.Format("\t\t={0}", result.ToString("##.##")));

            }
        }
    }
}
