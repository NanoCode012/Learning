using System;

namespace Heap
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var h = new Heap<int>();
            h.Push(5);
            h.Push(2);
            h.Push(7);
            h.Push(1);
            h.Push(4);
            h.Push(10);
            h.Push(8);
            h.Push(0);
            h.Push(15);
            Console.WriteLine(h.Peek());
            Console.WriteLine("------");
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
        }
    }
}
