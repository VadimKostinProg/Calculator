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
        private StringBuilder _sb = new StringBuilder();
        public double Calculate(string expression)
        {
            //Converting expression to the postfix form
            PostfixConverter postfixConverter = new PostfixConverter();
            var postfixExpression = postfixConverter.ConvertToPostfix(expression);

            string postfix = string.Join(" ", postfixExpression);

            //Building expression tree from the postfix form
            TreeBuilder treeBuilder = new TreeBuilder();
            TNode root = treeBuilder.BuildExpressionTree(postfixExpression);

            PostfixTraversal(root);

            using(FileStream stream = new FileStream("postfix.txt", FileMode.Truncate, FileAccess.Write))
            using(StreamWriter streamWriter = new StreamWriter(stream))
            {
                streamWriter.WriteLine(expression);
                streamWriter.WriteLine(postfix);
                streamWriter.WriteLine(this._sb.ToString());
            }

            //Solving expression tree
            TreeCalculator treeCalculator = new TreeCalculator();
            return treeCalculator.CalculateNode(root);
        }

        private void PostfixTraversal(TNode node)
        {
            if (node == null)
            {
                return;
            }

            PostfixTraversal(node.Left);
            PostfixTraversal(node.Right);
            this._sb.Append($"{node.Data} ");
        }
    }
}
