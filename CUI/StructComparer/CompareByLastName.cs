using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUI.StructComparer
{
    public class CompareByLastName : IComparer<CustomerVal>
    {
        public int Compare(CustomerVal x, CustomerVal y)
        {
            return string.Compare(x.Lastname, y.Lastname);
        }
    }
}