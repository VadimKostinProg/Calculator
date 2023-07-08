using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculator.ExpressionTreeCalculator
{
    /// <summary>
    /// Calculator that computes result of expression with method of Expression Tree.
    /// </summary>
    public class Calculator : ICalculator
    {
        public double Calculate(string expression)
        {
            //Converting expression to the postfix form
            PostfixConverter postfixConverter = new PostfixConverter();
            var postfixExpression = postfixConverter.ConvertToPostfix(expression);

            //Building expression tree from the postfix form
            TreeBuilder treeBuilder = new TreeBuilder();
            TNode root = treeBuilder.BuildExpressionTree(postfixExpression);

            //Solving expression tree
            TreeCalculator treeCalculator = new TreeCalculator();
            return treeCalculator.CalculateNode(root);
        }
    }
}
