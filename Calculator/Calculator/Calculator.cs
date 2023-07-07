using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculator.Calculator
{
    /// <summary>
    /// Node of Expression Tree
    /// </summary>
    public class TNode
    {
        public string Data { get; set; }
        public TNode Left { get; set; }
        public TNode Right { get; set; }

        public TNode(string symbol, TNode left = null, TNode right = null)
        {
            Data = symbol;
            Left = left;
            Right = right;
        }
    }

    /// <summary>
    /// Calculator that computes result of expression with method of Expression Tree.
    /// </summary>
    public class Calculator : ICalculator
    {
        private TNode _root = null;

        public double Calculate(string expression)
        {
            BreakExpressionIntoTheTree(expression);

            return CalculateNode(_root);
        }

        #region CREATING EXPRESSION TREE LOGIC
        // Method for breaking expession into the Expression Tree
        private TNode BreakExpressionIntoTheTree(string expression)
        {
            var postfixExpression = ToPostfixExpression(expression);

            return null;
        }

        private List<string> ToPostfixExpression(string expression)
        {
            Stack<string> operatorsStack = new Stack<string>();
            List<string> postfixExpression = new List<string>();

            string[] expressionArr = expression.Split(new char[] { ' ' });

            foreach(string item in expressionArr)
            {

            }

            return postfixExpression;
        }
        #endregion

        #region CALCULATION TREE LOGIC
        // Method for calculate result of the node calculation recursivly
        private double CalculateNode(TNode node)
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
            if (node.Left == null)
            {
                double childResult = CalculateNode(node.Right);

                return CalculateUnaryOperator(node.Data, childResult);
            }

            //If both childes of node are not null it`s data is arithmetic operator
            double leftChildResult = CalculateNode(node.Left);
            double rightChildResult = CalculateNode(node.Right);

            return CalculateArithemticOperator(node.Data, leftChildResult, rightChildResult);
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
        #endregion
    }
}
