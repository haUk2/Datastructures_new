using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedList
{
    public class SingleLinkedList : IMyList
    {
        Node head;
        int count;
        SortStrategy sortstrategy;
        public SingleLinkedList()
        {
            head = null;
        }

        public override string ToString()
        {
            string retval = "";
            if (head == null)
                return "No elements in List";

            var node = head;
            while (node != null)
            {
                retval += "| " + node.data + " ";
                node = node.next;
            }
            retval += "|";
            return retval;
        }
        public void insert_front(int newElement)
        {
            Node newNode = new Node();
            newNode.data = newElement;
            newNode.next = head;
            head = newNode;
            count++;
        }
        public void InsertAfter(Node previousNode, int newData)
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode == previousNode)
                {
                    Node previousNextNode = currentNode.next;
                    currentNode.next = new Node(newData);
                    currentNode.next.next = previousNextNode;
                    count++;
                }
                if (currentNode.next == null)
                {
                    return;
                }
                currentNode = currentNode.next;
            }
            count++;
        }

        public void insert_AtTheEnd(int newElement)
        {
            Node newNode = new Node();
            newNode.data = newElement;
            newNode.next = null;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = new Node();
                temp = head;
                while (temp.next != null)
                    temp = temp.next;
                temp.next = newNode;
            }
            count++;
        }

        public Node? GetNode(int data)
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.data.Equals(data))
                {
                    return currentNode;
                }

                if (currentNode.next == null)
                {
                    return null;
                }
                currentNode = currentNode.next;
            }
            return null;
        }

        public Node? GetLast()
        {
            for(Node cur = head; cur.next != null; cur = cur.next)
            {
                if(cur.next == null)
                {
                    return cur;
                }
            }
            return null;
        }

        public void DeleteFirst()
        {
            count--;
            head = head.next;
        }

        public bool DeleteNode(Node node)
        {
            Node currentNode = head;
            Node previousNode = head;
            while (currentNode != null)
            {
                if (currentNode == node)
                {
                    if (currentNode == head)
                    {
                        DeleteFirst();
                    }
                    else
                    {
                        previousNode.next = currentNode.next;
                    }
                    count--;
                    return true;
                }

                if (currentNode.next == null)
                {
                    return false;
                }
                previousNode = currentNode;
                currentNode = currentNode.next;
            }

            return false;
        }

        public void delete_last()
        {
            var cur = head;
            while (cur.next != null)
            {
                if (cur.next.next == null)
                {
                    cur.next = null;
                    break;
                };
                cur = cur.next;
            }
        }


        public int size()
        {
            return count;
        }

        public void PrintList()
        {
            Node temp = new Node();
            temp = this.head;
            if (temp != null)
            {
                Console.Write("The list contains: ");
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }

        public void SwitchNodes(Node firstNode, Node secondNode)
        {
            if(GetNode(firstNode.data) != null && GetNode(secondNode.data) != null)
            {
                (firstNode.data, secondNode.data) = (secondNode.data, firstNode.data);
            }
 
        }
        public void Insertsort()
        {
            var temp = head.next;

            while(temp != null)
            {
                for (var current = head; current.next != null; current = current.next)
                {
                    if (current.data == temp.data && current.next.data == temp.next.data)
                        break;
                    if (current.data <= temp.data)
                        continue;
                    var speicher = current.data;
                    current.data = temp.data;
                    temp.data = speicher;
                }
                temp = temp.next;
            }
        }

        public void InsertsortReverse()
        {
            var temp = head;

            while (temp != null)
            {
                for (var current = head; current.next != null; current = current.next)
                {
                    if (current.data == temp.data && current.next.data == temp.next.data)
                        break;
                    if (current.data >= temp.data)
                        continue;
                    var speicher = current.data;
                    current.data = temp.data;
                    temp.data = speicher;
                }
                temp = temp.next;
            }
        }

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            sortstrategy = sortStrategy;
        }

        public Node GetFirst()
        {
            return head;
        }

        public void Sort()
        {
            sortstrategy.Sort(this);
        }

        public void SortDesc()
        {
            sortstrategy.SortDesc(this);
        }
    }
}

