using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ExpressionTreeCalculator
{
    /// <summary>
    /// Converter expressions from infix to postfix form.
    /// </summary>
    public sealed class PostfixConverter
    {
        private bool IsOperator(string token)
        {
            return Precedence.Operators.ContainsKey(token);
        }

        private bool IsFunction(string token)
        {
            return Precedence.Functions.ContainsKey(token);
        }

        private List<string> SplitExpression(string expression)
        {
            List<string> tokens = new List<string>();
            StringBuilder token = new StringBuilder();

            foreach (char c in expression)
            {
                if (c == ' ')
                {
                    if (token.Length > 0)
                    {
                        tokens.Add(token.ToString());
                        token.Clear();
                    }
                }
                else if (c == '(' || c == ')' || c == '^' || c == '!')
                {
                    if (token.Length > 0)
                    {
                        tokens.Add(token.ToString());
                        token.Clear();
                    }
                    tokens.Add(c.ToString());
                }
                else
                {
                    token.Append(c);
                }
            }

            if (token.Length > 0)
            {
                tokens.Add(token.ToString());
            }

            return tokens;
        }

        public List<string> ConvertToPostfix(string expression)
        {
            List<string> postfix = new List<string>();
            Stack<string> operatorStack = new Stack<string>();

            var tokens = SplitExpression(expression);

            foreach (string token in tokens)
            {
                if (IsOperator(token))
                {
                    while (operatorStack.Count > 0 && IsOperator(operatorStack.Peek()) && Precedence.Operators[token] <= Precedence.Operators[operatorStack.Peek()])
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
                else if (token == "!")
                {
                    postfix.Add(token);
                }
                else if (IsFunction(token))
                {
                    operatorStack.Push(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push("(");
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        postfix.Add(operatorStack.Pop());
                    }

                    if (operatorStack.Count > 0 && operatorStack.Peek() == "(")
                    {
                        operatorStack.Pop();
                    }

                    if (operatorStack.Count > 0 && IsFunction(operatorStack.Peek()))
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                }
                else
                {
                    postfix.Add(token);
                }
            }

            while (operatorStack.Count > 0)
            {
                postfix.Add(operatorStack.Pop());
            }

            return postfix;
        }
    }
}
