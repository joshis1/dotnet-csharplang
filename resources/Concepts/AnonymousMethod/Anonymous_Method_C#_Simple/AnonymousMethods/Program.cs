using System;

namespace AnonymousMethods
{
    class MainClass
    {
        /** Declaration of delegate is the first step **/
        public delegate string SayHelloDelegate(string msg);

        public static void Main(string[] args)
        {
        
            /** Anonymous Methods **/  
            SayHelloDelegate msgDelegate = delegate (string message){

                return "Hello " + message;
            };

            Console.WriteLine(msgDelegate.Invoke("Shreyas"));
        }
    }
}
