using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using CUI.ClassComparer;
using CUI.StructComparer;

namespace CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRef first = new CustomerRef(1, "Sasha", "Hell");
            CustomerRef second = new CustomerRef(2, "Alex", "Penn");
            CustomerRef third = new CustomerRef(2, "Olga", "Enn");

            Console.WriteLine("---class---");

            Console.WriteLine(second.Equals(third, new ClassComparer.EqualityByName()));
            Console.WriteLine(second.CompareTo(third));
            Console.WriteLine(second.CompareTo(third, new ClassComparer.CompareByLastName()));
            Console.WriteLine(second.CompareTo(third, new ClassComparer.CompareByLastName().Compare));

            Console.WriteLine("-------------------");
            Console.WriteLine(second < second);
            Console.WriteLine(second > second);
            Console.WriteLine(first.Clone().ToString());

            Console.WriteLine("---structure---");

            CustomerVal valFirst = new CustomerVal(1, "Sasha", "Hell");
            CustomerVal valSec = new CustomerVal(2, "Alex", "Penn");
            CustomerVal valThird = new CustomerVal(2, "Olga", "Enn");

            object obj = valSec;
            Console.WriteLine(obj.Equals(valSec));
            Console.WriteLine(valSec.Equals(obj));
            Console.WriteLine(valSec.Equals(valThird, new StructComparer.EqualityByName()));

            Console.WriteLine(valSec.CompareTo(valThird));
            Console.WriteLine(valSec.CompareTo(valThird, new StructComparer.CompareByLastName()));
            Console.WriteLine(valSec.CompareTo(valThird, new StructComparer.CompareByLastName().Compare));

            Console.WriteLine("-------------------");
            Console.WriteLine(valSec < valSec);
            Console.WriteLine(valSec > valSec);
            Console.WriteLine(valFirst.Clone().ToString());
        }
    }
}