using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ExpressionTreeCalculator
{
    /// <summary>
    /// Class that calculates the result of expression tree.
    /// </summary>
    public class TreeCalculator
    {
        /// <summary>
        /// Method for calculation result of expressionTree.
        /// </summary>
        /// <param name="node">Node of expression tree to calculate result.</param>
        /// <returns>Result of epression.</returns>
        public double CalculateNode(TNode node)
        {
            //If all nodes are null - node is leaf of tree, that`s why it`s data is an operand
            if (node.Left == null && node.Right == null)
            {
                if (node.Data == "pi")
                    return Math.PI;

                if (node.Data == "e")
                    return Math.E;

                return double.Parse(node.Data);
            }

            //If only right child of node is not null it`s data is unary operator
            if (node.Right == null)
            {
                double childResult = CalculateNode(node.Left);

                return CalculateUnaryOperator(node.Data, childResult);
            }

            //If both childes of node are not null it`s data is arithmetic operator
            double leftChildResult = CalculateNode(node.Left);
            double rightChildResult = CalculateNode(node.Right);

            return CalculateArithemticOperator(node.Data, leftChildResult, rightChildResult);
        }

        private int Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Error! Cannot count factorial of negative number");

            if(number == 1) return 1;

            return number * Factorial(number - 1);
        }

        //Method for calculate result of unary operator
        private double CalculateUnaryOperator(string operatorStr, double value)
        {
            double result = 0;

            switch (operatorStr)
            {
                case "-":
                    result = -value;
                    break;
                case "sin":
                    result = Math.Sin(value);
                    break;
                case "cos":
                    result = Math.Cos(value);
                    break;
                case "tan":
                    result = Math.Tan(value);
                    break;
                case "log":
                    result = Math.Log(value, 2);
                    break;
                case "lg":
                    result = Math.Log10(value);
                    break;
                case "ln":
                    result = Math.Log(value);
                    break;
                case "sqrt":
                    result = Math.Sqrt(value);
                    break;
                case "!":
                    int num;
                    bool parseResult = int.TryParse(value.ToString(), out num);
                    if (!parseResult)
                        throw new ArgumentException("Error! Cannot count factorial of double");
                    result = Factorial(num);
                    break;
                default:
                    throw new ArgumentException("Error! Unknown operator");
            }

            return result;
        }

        //Method for calculate result of arithmetic operator
        private double CalculateArithemticOperator(string operatorStr, double leftValue, double rightValue)
        {
            double result = 0;

            switch (operatorStr)
            {
                case "+":
                    result = leftValue + rightValue;
                    break;
                case "-":
                    result = leftValue - rightValue;
                    break;
                case "*":
                    result = leftValue * rightValue;
                    break;
                case "/":
                    result = leftValue / rightValue;
                    break;
                case "^":
                    result = Math.Pow(leftValue, rightValue);
                    break;
            }

            return result;
        }
    }
}
