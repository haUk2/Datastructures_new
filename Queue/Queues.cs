using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queues : ISubject
    {
        private SingleLinkedList internalList = new SingleLinkedList();
        private List<IObserver> _observers = new List<IObserver>();

        public Node Enqueue(int argValue)
        {
            var nodeToAdd = new Node(argValue);
            internalList.insert_AtTheEnd(argValue);
            Notify();
            return nodeToAdd;
        }

        public Node Dequeue()
        {
            var retval = internalList.GetFirst();
            internalList.DeleteFirst();
            Notify();
            return retval;
        }

        public override string ToString()
        {
            return internalList.ToString();
        }

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
