using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ExpressionTreeCalculator
{
    /// <summary>
    /// Node of Expression Tree
    /// </summary>
    public sealed class TNode
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
}