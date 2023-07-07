using Calculator.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ExpresionCalculator : ICalculator
    {
        public void ComputeBrackets(ref string expresion)
        {
            while (true)
            {
                if (expresion.Contains("("))
                {
                    int startIndex = expresion.IndexOf('(');
                    int length = LengthInBreckets(expresion, startIndex);
                    string newExpresion = expresion.Substring(startIndex + 1, length - 1);
                    double subResult = Calculate(newExpresion);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < expresion.Length; i++)
                    {
                        if (i == startIndex)
                        {
                            sb.Append(subResult.ToString());
                        }
                        else if (i > startIndex && i <= startIndex + length) continue;
                        else sb.Append(expresion[i]);
                    }
                    expresion = sb.ToString();
                }
                else break;
            }
        }
        public void ComputePower(ref string[] ExpresionsArr)
        {
            for (int i = 0; i < ExpresionsArr.Length; i++)
            {
                if (ExpresionsArr[i].Contains("^"))
                {
                    string[] powerArr = ExpresionsArr[i].Split('^');
                    ExpresionsArr[i] = Math.Pow(ToDouble(powerArr[0]), ToDouble(powerArr[1])).ToString();
                }
            }
        }
        public void ComputeFactorial(ref string[] ExpresionsArr)
        {
            for (int i = 0; i < ExpresionsArr.Length; i++)
            {
                if (ExpresionsArr[i].Contains("!"))
                {
                    double number = ToDouble(ExpresionsArr[i].Substring(0, ExpresionsArr[i].Length - 1));
                    ExpresionsArr[i] = factorial((ulong)number).ToString();
                }
            }
        }
        public void ComputeSqrt(ref string[] ExpresionsArr)
        {
            for (int i = 0; i < ExpresionsArr.Length; i++)
            {
                if (ExpresionsArr[i].Contains("sqrt"))
                {
                    ExpresionsArr[i] = Math.Sqrt(ToDouble(ExpresionsArr[i].Substring(4, ExpresionsArr[i].Length - 4))).ToString();
                }
            }
        }
        public void ComputeTrigonometrial(ref string[] ExpresionsArr)
        {
            for (int i = 0; i < ExpresionsArr.Length; i++)
            {
                if (ExpresionsArr[i].Contains("sin"))
                {
                    ExpresionsArr[i] = ((double)Math.Round(Math.Sin(ToDouble(ExpresionsArr[i].Substring(3, ExpresionsArr[i].Length - 3))),3)).ToString();
                }
                else if (ExpresionsArr[i].Contains("cos"))
                {
                    ExpresionsArr[i] = ((double)Math.Round(Math.Cos(ToDouble(ExpresionsArr[i].Substring(3, ExpresionsArr[i].Length - 3))), 3)).ToString();
                }
                else if (ExpresionsArr[i].Contains("tan"))
                {
                    ExpresionsArr[i] = ((double)Math.Round(Math.Sin(ToDouble(ExpresionsArr[i].Substring(3, ExpresionsArr[i].Length - 3))), 3) /
                        (double)Math.Round(Math.Cos(ToDouble(ExpresionsArr[i].Substring(3, ExpresionsArr[i].Length - 3))), 3)).ToString();
                }
            }
        }
        public void ComputeLogarifmical(ref string[] ExpresionsArr)
        {
            for (int i = 0; i < ExpresionsArr.Length; i++)
            {
                if (ExpresionsArr[i].Contains("log"))
                {
                    ExpresionsArr[i] = Math.Log(ToDouble(ExpresionsArr[i].Substring(3, ExpresionsArr[i].Length - 3)), 2).ToString();
                }
                else if (ExpresionsArr[i].Contains("lg"))
                {
                    ExpresionsArr[i] = Math.Log10(ToDouble(ExpresionsArr[i].Substring(2, ExpresionsArr[i].Length - 2))).ToString();
                }
                else if (ExpresionsArr[i].Contains("ln"))
                {
                    ExpresionsArr[i] = Math.Log(ToDouble(ExpresionsArr[i].Substring(2, ExpresionsArr[i].Length - 2))).ToString();
                }
            }
        }
        public void ComputeOperations(ref string[] ExpresionsArr, ref double result)
        {
            bool isFirst = true;
            int i = 1;
            while(i < ExpresionsArr.Length)
            {
                if (ExpresionsArr[i] == "*" || ExpresionsArr[i] == "/")
                {
                    double subResult = 0;
                    switch (ExpresionsArr[i])
                    {
                        case "*":
                            if (isFirst)
                                subResult = ToDouble(ExpresionsArr[i - 1]) * ToDouble(ExpresionsArr[i + 1]);
                            else
                                subResult *= ToDouble(ExpresionsArr[i + 1]);
                            break;
                        case "/":
                            if (isFirst)
                                subResult = ToDouble(ExpresionsArr[i - 1]) / ToDouble(ExpresionsArr[i + 1]);
                            else
                                subResult /= ToDouble(ExpresionsArr[i + 1]);
                            break;
                    }
                    string[] ExpresionsArrNew = new string[ExpresionsArr.Length - 2];
                    int k = 0;
                    for (int j = 0; j < ExpresionsArr.Length; j++)
                    {
                        if (j == i - 1)
                        {
                            ExpresionsArrNew[k++] = subResult.ToString();
                        }
                        else if (j == i || j == i + 1) continue;
                        else ExpresionsArrNew[k++] = ExpresionsArr[j];
                    }
                    ExpresionsArr = ExpresionsArrNew;
                }
                else i += 2;
            }
            for (i = 1; i < ExpresionsArr.Length; i += 2)
            {
                switch (ExpresionsArr[i])
                {
                    case "+":
                        if (isFirst)
                            result = ToDouble(ExpresionsArr[i - 1]) + ToDouble(ExpresionsArr[i + 1]);
                        else
                            result += ToDouble(ExpresionsArr[i + 1]);
                        break;
                    case "-":
                        if (isFirst)
                            result = ToDouble(ExpresionsArr[i - 1]) - ToDouble(ExpresionsArr[i + 1]);
                        else
                            result -= ToDouble(ExpresionsArr[i + 1]);
                        break;
                }
                isFirst = false;
            }
        }
        public double Calculate(string expresion)
        {
            double result = 0;

            ComputeBrackets(ref expresion);

            string[] ExpresionsArr = expresion.Split(' ');

            ComputePower(ref ExpresionsArr);

            ComputeFactorial(ref ExpresionsArr);

            ComputeSqrt(ref ExpresionsArr);
            
            ComputeTrigonometrial(ref ExpresionsArr);

            ComputeLogarifmical(ref ExpresionsArr);

            ComputeOperations(ref ExpresionsArr, ref result);

            if(ExpresionsArr.Length == 1) result = ToDouble(ExpresionsArr[0]);
            return result;
        }
        public ulong factorial(ulong number) { return number > 1 ? number * factorial(number-1) : 1; }

        private double ToDouble(string expresion)
        {
            switch (expresion)
            {
                case "pi":
                    return Math.PI;
                case "e":
                    return Math.E;
                default:
                    return Double.Parse(expresion);
            }
        }

        private int LengthInBreckets(string expresion, int indexOfFirstBracket)
        {
            StackChar stack = new StackChar();
            for (int i = indexOfFirstBracket; i < expresion.Length; i++)
            {
                if (expresion[i] == '(') stack.Push(expresion[i]);
                else if(expresion[i] == ')')
                {
                    stack.Pop();
                    if(stack.Length == 0) return i - indexOfFirstBracket;
                }
            }
            throw new ArgumentException("Breckets are entered incorrectly.");
        }
    }
}
