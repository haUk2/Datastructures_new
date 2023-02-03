using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public static class Factory_Patterns
    {
        public static SortStrategy FactoryPattern(string SortStrategy)
        {
            switch (SortStrategy)
            {
                case "InsertionSort":
                    return new InsertionSort();
                case "BubbleSort":
                    return new BubbleSort();
                case "SelectionSort":
                    return new SelectionSort();
                default:
                    return null;
            }
        }
    }
}
