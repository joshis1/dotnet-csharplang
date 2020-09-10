using System;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(() => testThread());
            t.Start();
            Console.ReadLine();
        }
        static void testThread()
        {
            for(int i=0; i< 1000; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
