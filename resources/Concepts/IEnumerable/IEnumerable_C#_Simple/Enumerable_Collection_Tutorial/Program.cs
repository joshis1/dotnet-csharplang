using System;
using System.Collections;

namespace Enumerable_Collection_Tutorial
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Organisation org = new Organisation();
            org.AddEmployes(new Employee { Id = 52, name = "Shragul", role = "Senior Software Engineer" });
            org.AddEmployes(new Employee { Id = 62, name = "Oliver", role = "Senior Director" });
            org.AddEmployes(new Employee { Id = 72, name = "Ramul", role = "Director" });
            org.AddEmployes(new Employee { Id = 82, name = "Stevo", role = "Tech Lead" });
            org.AddEmployes(new Employee { Id = 92, name = "Nevton", role = "Project Manager" });
            org.AddEmployes(new Employee { Id = 97, name = "Tramton", role = "Senior Software Engineer" });

            IEnumerable names = from n in org where (n.name.StartsWith("S", StringComparison.CurrentCulture)) select n;

            foreach(Employee name in names)
            {
                Console.WriteLine(name.name);
            }

            foreach (Employee item in org)
            {
                Console.WriteLine("{0,0} {1,0} {2,0}", item.Id, item.name, item.role);
            }
        }
    }
}
