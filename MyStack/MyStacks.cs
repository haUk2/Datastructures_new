using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    public class MyStacks
    {
        private LinkedList.SingleLinkedList internalList = new LinkedList.SingleLinkedList();

        public Node Push(int argValue)
        {
            var nodeToAdd = new Node(argValue);
            internalList.insert_AtTheEnd(argValue);
            return nodeToAdd;
        }

        public Node Pop()
        {
            var retval = internalList.GetLast();
            internalList.delete_last();
            return retval;
        }

        public override string ToString()
        {
            return internalList.ToString();
        }
    }
}
