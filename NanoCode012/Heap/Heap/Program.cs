using System;

namespace Heap
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var h = new HeapV1<int>();
            h.Push(5);
            h.Push(2);
            h.Push(7);
            h.Push(1);
            h.Push(4);
            h.Push(10);
            h.Push(8);
            h.Push(0);
            h.Push(-5);
            h.Push(-4);
            h.Push(3);
            h.Push(-9);
            Console.WriteLine(h.Peek());
            Console.WriteLine("---------");
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());
            Console.WriteLine(h.Pop());

            Console.WriteLine("********");

            var h2 = new HeapV2(10);
            h2.Push(4);
            h2.Push(7);
            h2.Push(10);
            h2.Push(6);
            h2.Push(8);
            h2.Push(20);
            h2.Push(88);
            h2.Push(23);
            h2.Push(1);
            h2.Push(4);
            h2.Push(34);
            h2.Push(0);

            Console.WriteLine("++++++++++++");

            //Testing only. To check tree in array order
            foreach (var item in h2.GetAr())
            {
                Console.WriteLine(item);
            }
            //End of testing

            Console.WriteLine("=========");
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());
            Console.WriteLine(h2.Pop());

            Console.WriteLine("|||||||||||||||||||");
            var h3 = new HeapV3<int>();
            h3.Push(10);
            h3.Push(19);
            h3.Push(100);
            h3.Push(77);
            h3.Push(-3);
            h3.Push(29);
            Console.WriteLine(h3.Pop());
            Console.WriteLine(h3.Pop());
            Console.WriteLine(h3.Pop());
            Console.WriteLine(h3.Pop());
            Console.WriteLine(h3.Pop());
            Console.WriteLine(h3.Pop());



        }
    }
}
