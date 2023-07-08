using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ExpressionTreeCalculator
{
    public static class Precedence
    {
        public static Dictionary<string, int> Operators = new Dictionary<string, int>
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "^", 3 },
        };

        public static Dictionary<string, int> Functions = new Dictionary<string, int>
        {
            { "sin", 3 },
            { "cos", 3 },
            { "tan", 3 },
            { "log", 3 },
            { "lg", 3 },
            { "ln", 3 },
            { "sqrt", 3 }
        };
    }
}
