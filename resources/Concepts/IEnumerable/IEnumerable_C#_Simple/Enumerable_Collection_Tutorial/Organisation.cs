using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Enumerable_Collection_Tutorial
{
    public class Organisation
    {
        List<Employee> emps = new List<Employee> { };
        OrganisationEnumerator OrganisationEnum = null;

        public Organisation()
        {

            OrganisationEnum = new OrganisationEnumerator(this);
        }

        public void AddEmployes(Employee e)
        {
            emps.Add(e);
        }

        public IEnumerator GetEnumerator()
        {
            return OrganisationEnum;
        }

        public Employee this[int index]
        {
            get
            {
                return emps[index];
            }
        }

        public List<Employee> getEmps()
        {
            return emps;
        }

        public IEnumerable<Employee> Where(Func<Employee, bool> predicate) => emps.Where(predicate);
    }
}
