using System;
using System.Collections.Generic;

namespace DelegateApp
{
    class MainClass
    {
        public delegate bool delegateFilter(Person p);

        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person {name="Samaya", age= 2 },
                new Person {name="Riya", age = 3 },
                new Person {name="Prady", age = 39},
                new Person {name="Neha", age=33},
                new Person {name="Madhuri",age=62},
                new Person {name="Anil", age=64}
            };
            MainClass.Display("Child", people, IsChild);
            MainClass.Display("Old", people, IsOld);
            MainClass.Display("Adult", people, IsAdult);
        }

        static void Display(string categoery,List<Person>people, delegateFilter filter )
        {
            Console.WriteLine("*********" + categoery + "***********");
            foreach(Person p in people)
            {
                if(filter(p))
                {
                    Console.WriteLine(p.name);
                }
            }
        }

        static bool IsChild(Person p)
        {
            if (p.age < 5)
            {
                return true;
            }
            return false;
        }
        static bool IsAdult(Person p)
        {
            if (p.age > 5 && p.age < 40)
            {
                return true;
            }
            return false;
        }
        static bool IsOld(Person p)
        {
            if (p.age > 40)
            {
                return true;
            }
            return false;

        }
       
    }
}
