using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorStr
    {
        public double Calculate(string input)
        {
            try
            {
                return Calculate(sortDataPMFirst(splitData(input)));
            }
            catch(Exception ex)
            {
                return double.NaN;
            }
            finally
            {
                
            }
            

        }
        public double Calculate(string[] data)
        {
            var list_data = new List<string>();
            list_data.AddRange(data);

            while (list_data.Count > 1)
            {
                var i = list_data.FindIndex(key => operation.oper.Contains(key));
                if (i > 1)
                {
                    var temp_a = popAt(ref list_data, i - 2);
                    var temp_b = popAt(ref list_data, i - 2);
                    var temp_o = list_data[i - 2];
                    list_data[i - 2] = unitCalculation(temp_a, temp_b, temp_o);
                }
                else return double.NaN;
            }
            return Convert.ToDouble(list_data[0]);
        }
        public string unitCalculation(string temp_a, string temp_b, string temp_oper)
        {
            var a = Convert.ToDouble(temp_a);
            var b = Convert.ToDouble(temp_b);
            double result = 0;
            if (temp_oper == operation.plus) result = plus(a, b);
            else if (temp_oper == operation.minus) result = minus(a, b);
            else if (temp_oper == operation.divide) result = divide(a, b);
            else if (temp_oper == operation.multiple) result = multiple(a, b);
            return result.ToString();
        }
        #region Clean and prepair data
        private string[] sortDataPMFirst(string[] data)
        {
            var list_num = new List<string>();
            var list_oper = new List<string>();

            for (int i = 0; i < data.Length; i++)
            {
                var s = data[i];
                if (s == operation.divide ||
                    s == operation.multiple)
                {
                    list_oper.Add(s);
                }
                else if (s == operation.plus ||
                    s == operation.minus)
                {
                    //insert closed blanket to let * / operation to be after num
                    list_oper.Add(s);
                    var temp_num = data[i + 1];
                    list_num.Add(temp_num);
                    data[i] = temp_num;
                    data[i + 1] = operation.close;

                }
                else if (s == operation.open)
                {

                }
                else if (s == operation.close)
                {
                    addOperInNum(ref list_oper, ref list_num);

                }
                else
                {
                    list_num.Add(s);
                }

            }

            addOperInNum(ref list_oper, ref list_num);

            return list_num.ToArray();
        }

        private void addOperInNum(ref List<string> list_oper, ref List<string> list_num)
        {
            // let divide be before multiple

            while (list_oper.Count > 0)
            {
                var temp_o = popLast(ref list_oper);
                if (temp_o == operation.multiple && list_oper.Count > 0)
                {
                    var temp_oo = popLast(ref list_oper);
                    if (temp_oo == operation.divide)
                    {
                        list_num.Add(temp_oo);
                    }
                    else
                    {
                        var temp = temp_oo;
                        list_num.Add(temp_o);
                        temp_o = temp;
                    }
                }
                list_num.Add(temp_o);
            }
        }

        private string[] splitData(string data)
        {
            data = data.Replace("+", " + ");
            data = data.Replace("-", " - ");
            data = data.Replace("*", " * ");
            data = data.Replace("/", " / ");
            data = data.Replace("(", "( ");
            data = data.Replace(")", " )");

            return data.Split();
        }
        #endregion
        #region pop array
        public string popFirst(ref List<string> list)
        {
            return pop(ref list, 0);
        }
        public string popLast(ref List<string> list)
        {
            var index = list.Count - 1;
            return pop(ref list, index);
        }
        public string popAt(ref List<string> list, int index)
        {
            return pop(ref list, index);

        }
        private string pop(ref List<string> list, int index)
        {
            var temp = list[index];
            list.RemoveAt(index);
            return temp;
        }
        #endregion
        #region unit operation
        private double plus(double a, double b)
        {
            return a + b;
        }
        private double minus(double a, double b)
        {
            return a - b;
        }
        private double multiple(double a, double b)
        {
            return a * b;
        }
        private double divide(double a, double b)
        {
            if (b == 0) return double.NaN;
            else return a / b;
        }
        public struct operation
        {
            public const string plus = "+";
            public const string minus = "-";
            public const string divide = "/";
            public const string multiple = "*";
            public const string open = "(";
            public const string close = ")";
            public const string oper = "+-*/";
        }
        #endregion
    }
}
