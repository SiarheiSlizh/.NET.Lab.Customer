using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUI.StructComparer
{
    public class EqualityByName : IEqualityComparer<CustomerVal>
    {
        public bool Equals(CustomerVal x, CustomerVal y)
        {
            return x.Name == y.Name ? true : false;
        }

        //not called in this context
        public int GetHashCode(CustomerVal obj)
        {
            return 11 * obj.Name.GetHashCode();
        }
    }
}