using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUI.ClassComparer
{
    public class CompareByLastName : IComparer<CustomerRef>
    {
        public int Compare(CustomerRef x, CustomerRef y)
        {
            if (ReferenceEquals(x, y))
                return 0;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                throw new ArgumentNullException();

            return string.Compare(x.Lastname, y.Lastname);
        }
    }
}