using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public interface IMyList
    {
        void SwitchNodes(Node firstNode, Node secondNode);
        void SetSortStrategy(SortStrategy sortStrategy);
        Node GetFirst();
        void Sort();
        void SortDesc();
    }

    public abstract class SortStrategy
    {
        public abstract void Sort(IMyList list);
        public abstract void SortDesc(IMyList list);
    }

    public class InsertionSort : SortStrategy
    {
        public override void Sort(IMyList list)
        {
            var nextNode = list.GetFirst().next;

            while (nextNode != null)
            {
                for (var cur = list.GetFirst(); cur.next != null; cur = cur.next)
                {
                    if (cur == nextNode)
                        break;
                    if (cur.data < nextNode.data)
                        continue;
                    (cur.data, nextNode.data) = (nextNode.data, cur.data);
                }
                nextNode = nextNode.next;
            }
            Console.WriteLine("InsertionSorted list ");
        }

        public override void SortDesc(IMyList list)
        {
            throw new NotImplementedException();
        }
    }

    public class ReverseInsertionSort : SortStrategy
    {
        public override void Sort(IMyList list)
        {
            var nextNode = list.GetFirst().next;

            while (nextNode != null)
            {
                for (var cur = list.GetFirst(); cur.next != null; cur = cur.next)
                {
                    if (cur == nextNode)
                        break;
                    if (cur.data > nextNode.data)
                        continue;
                    (cur.data, nextNode.data) = (nextNode.data, cur.data);
                }
                nextNode = nextNode.next;
            }
            Console.WriteLine("ReverseInsertionSorted list ");
        }

        public override void SortDesc(IMyList list)
        {
            throw new NotImplementedException();
        }
    }

    public class BubbleSort : SortStrategy
    {
        public override void Sort(IMyList list)
        {
            var Node = list.GetFirst();

            while (Node != null)
            {
                for (var cur = list.GetFirst(); cur.next != null; cur = cur.next)
                {
                    if(cur.next == null)
                    {
                        continue;
                    }
                    if (cur.data > cur.next.data)
                    {
                        list.SwitchNodes(cur, cur.next);
                    }
                }
                Node = Node.next;
            }
            Console.WriteLine("BubbleSorted list ");
        }

        public override void SortDesc(IMyList list)
        {
            var Node = list.GetFirst();

            while (Node != null)
            {
                for (var cur = list.GetFirst(); cur.next != null; cur = cur.next)
                {
                    if (cur.next == null)
                    {
                        continue;
                    }
                    if (cur.data < cur.next.data)
                    {
                        list.SwitchNodes(cur, cur.next);
                    }
                }
                Node = Node.next;
            }
            Console.WriteLine("BubbleSorted list ");
        }
    }
}