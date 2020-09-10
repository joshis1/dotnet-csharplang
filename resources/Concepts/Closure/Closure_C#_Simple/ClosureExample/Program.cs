using System;

namespace ClosureExample
{
    class Program
    {
        static Func<string> LogValues(string name)
        {
            string nm = name;

            return delegate
            {
                return "Hello " + nm;
            };
        }

        static void Main(string[] args)
        {
            Func<string> closure_Test = LogValues("Shreyas");
            Console.WriteLine(closure_Test());
            Console.ReadLine();
        }
    }
}
