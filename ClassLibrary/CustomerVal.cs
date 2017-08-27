using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public struct CustomerVal : IEquatable<CustomerVal>, IComparable, IComparable<CustomerVal>, ICloneable
    {
        #region props
        public int Id { get; }
        public string Name { get; }
        public string Lastname { get; }
        #endregion

        #region ctor
        public CustomerVal(int id, string name, string lastname)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
        }
        #endregion

        #region tostring
        public override string ToString()
        {
            return string.Format("id: " + Id + "\nname: " + Name + "\nlast name: " + Lastname);
        }
        #endregion

        #region Equals and GetHashCode
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (obj is CustomerVal)
                return Equals((CustomerVal)obj);

            return false;
        }

        public bool Equals(CustomerVal other)
        {
            return this.Id == other.Id ? true : false;
        }

        public bool Equals(CustomerVal other, IEqualityComparer<CustomerVal> eq)
        {
            if (ReferenceEquals(eq, null))
                return Equals(other);

            return eq.Equals(this, other);
        }

        public override int GetHashCode()
        {
            return 11 * this.Id.GetHashCode();
        }
        #endregion

        #region Icomparable
        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                return 1;

            if (obj is CustomerVal)
                return CompareTo((CustomerVal)obj);

            throw new ArgumentException(nameof(obj));
        }

        public int CompareTo(CustomerVal other)
        {
            return string.Compare(this.Name, other.Name);
        }

        public int CompareTo(CustomerVal other, IComparer<CustomerVal> cmpI)
        {
            if (ReferenceEquals(cmpI, null))
                return CompareTo(other);

            return cmpI.Compare(this, other);
        }

        public int CompareTo(CustomerVal other, Comparison<CustomerVal> cmpD)
        {
            if (ReferenceEquals(cmpD, null))
                return CompareTo(other);

            return cmpD(this, other);
        }
        #endregion

        #region ICloneable
        object ICloneable.Clone() => Clone();

        public CustomerVal Clone() => new CustomerVal(Id, Name, Lastname);
        #endregion

        #region overload
        public static bool operator <(CustomerVal first, CustomerVal second) => CompareLess(first, second);
        public static bool operator >(CustomerVal first, CustomerVal second) => CompareMore(first, second);
        #endregion

        #region static methods
        public static bool CompareLess(CustomerVal first, CustomerVal second)
        {
            if (first.CompareTo(second) < 0)
                return true;

            return false;
        }

        public static bool CompareMore(CustomerVal first, CustomerVal second)
        {
            if (first.CompareTo(second) > 0)
                return true;

            return false;
        }
        #endregion
    }
}