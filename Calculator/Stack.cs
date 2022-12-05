using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StackChar
    {
        private List<char> container;
        public int Length { get; private set; }
        public StackChar()
        {
            container = new List<char>();
            Length = 0;
        }
        public void Push(char data)
        {
            container.Add(data);
            Length++;
        }
        public void Pop()
        {
            container.RemoveAt(Length - 1);
            Length--;
        }
        public bool Empty() { return Length == 0; }
    }
}
