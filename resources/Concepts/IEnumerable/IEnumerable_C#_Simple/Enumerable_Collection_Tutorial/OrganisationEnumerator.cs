using System;
using System.Collections;

namespace Enumerable_Collection_Tutorial
{
    public class OrganisationEnumerator: IEnumerator
    {
        Organisation org = null;
        int currentIndex = -1;

        public OrganisationEnumerator(Organisation org)
        {
            this.org = org;
        }
        public object Current => org[currentIndex];

        public bool MoveNext()
        {

            if (++currentIndex >= org.getEmps().Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
