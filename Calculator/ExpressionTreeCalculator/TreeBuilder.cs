using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculator.ExpressionTreeCalculator
{
    public class TreeBuilder
    {
        public TNode BuildExpressionTree(List<string> postfix)
        {
            Stack<TNode> stack = new Stack<TNode>();

            foreach (string token in postfix)
            {
                if (IsOperator(token))
                {
                    TNode right = stack.Pop();
                    TNode left = stack.Pop();
                    TNode node = new TNode(token, left, right);
                    stack.Push(node);
                }
                else if (IsFunction(token))
                {
                    TNode argument = stack.Pop();
                    TNode node = new TNode(token, argument);
                    stack.Push(node);
                }
                else if (token == "!")
                {
                    TNode operand = stack.Pop();
                    TNode node = new TNode(token, operand);
                    stack.Push(node);
                }
                else
                {
                    TNode node = new TNode(token);
                    stack.Push(node);
                }
            }

            if (stack.Count > 1)
            {
                throw new ArgumentException("Invalid expression");
            }

            return stack.Pop();
        }

        static bool IsOperator(string token)
        {
            return Precedence.Operators.ContainsKey(token);
        }

        static bool IsFunction(string token)
        {
            return Precedence.Functions.ContainsKey(token);
        }
    }
}
