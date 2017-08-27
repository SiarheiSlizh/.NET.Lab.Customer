using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUI.ClassComparer
{
    class EqualityByName : IEqualityComparer<CustomerRef>
    {
        public bool Equals(CustomerRef x, CustomerRef y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Name == y.Name ? true : false;
        }

        //not called in this context
        public int GetHashCode(CustomerRef obj)
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException(nameof(obj));

            return 11 * obj.Name.GetHashCode();
        }
    }
}