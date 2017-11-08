using System;

namespace Heap
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var h = new Heap<int>();
            h.Add(5);
            h.Add(7);
            h.Add(2);
            h.Add(8);
            Console.WriteLine(h.Peek());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
        }
    }
}
