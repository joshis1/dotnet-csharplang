using System;
using System.Collections.Generic;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(myList.FindAll(x => x % 2 == 0));
        }
    }
}
