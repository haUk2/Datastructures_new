// See https://aka.ms/new-console-template for more information

namespace GenerischeKlassen
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Stack<T>
    {
        T[] gruen = null;

        public T Push(T item)
        {
            gruen[gruen.Length + 1] = item;
            return gruen.Last();
        }

        public int size()
        {
            var size = 0;
            
            foreach(var item in gruen) { size++; }

            return size;
        }

        public T Pop()
        {
            gruen.Reverse().Skip(1).Reverse().ToArray();
            return gruen.Last();
        }

    }
}