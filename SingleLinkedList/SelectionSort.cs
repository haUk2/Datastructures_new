using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SelectionSort : SortStrategy
    {
        public override void Sort(IMyList list)
        {
            var current = list.GetFirst();

            while(current.next != null)
            {
                var extreme = current;
                for(var cur = current.next; cur != null; cur = cur.next)
                {
                    if(cur.data > extreme.data)
                        continue;
                    extreme = cur;
                    break;
                }
                (extreme.data, current.data) = (current.data, extreme.data);
                current = current.next;
            }

        }

        public override void SortDesc(IMyList list)
        {
            throw new NotImplementedException();
        }
    }
}
