using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CustomerRef : IEquatable<CustomerRef>, IComparable, IComparable<CustomerRef>, ICloneable
    {
        #region props
        public int Id { get; }
        public string Name { get; }
        public string Lastname { get; }
        #endregion

        #region ctor
        public CustomerRef(int id, string name, string lastname)
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

            if (this.GetType() != obj.GetType())
                return false;

            return Equals((CustomerRef)obj);
        }

        public bool Equals(CustomerRef other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return this.Id == other.Id ? true : false;
        }

        public bool Equals(CustomerRef other, IEqualityComparer<CustomerRef> eq)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(eq, null))
                return Equals(other);

            return eq.Equals(this, other);
        }

        //not called in this context
        public override int GetHashCode()
        {
            return 11 * this.Id.GetHashCode();
        }
        #endregion

        #region Comparable
        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                return 1;

            if (!(obj is CustomerRef))
                throw new ArgumentException(nameof(obj));

            return CompareTo((CustomerRef)obj);
        }

        public int CompareTo(CustomerRef other)
        {
            if (ReferenceEquals(other, null))
                return 1;

            return string.Compare(this.Name, other.Name);
        }

        public int CompareTo(CustomerRef other, IComparer<CustomerRef> cmpI)
        {
            if (ReferenceEquals(other, null))
                return 1;

            if (ReferenceEquals(cmpI, null))
                return CompareTo(other);

            return cmpI.Compare(this, other);
        }

        public int CompareTo(CustomerRef other, Comparison<CustomerRef> cmpD)
        {
            if (ReferenceEquals(other, null))
                return 1;

            if (ReferenceEquals(cmpD, null))
                return CompareTo(other);

            return cmpD(this, other);
        }
        #endregion

        #region ICloneable
        object ICloneable.Clone() => Clone();

        public CustomerRef Clone() => new CustomerRef(Id, Name, Lastname);
        #endregion

        #region overload
        public static bool operator <(CustomerRef first, CustomerRef second) => CompareLess(first, second);
        public static bool operator >(CustomerRef first, CustomerRef second) => CompareMore(first, second);
        #endregion

        #region static methods
        public static bool CompareLess(CustomerRef first, CustomerRef second)
        {
            if (ReferenceEquals(first, null))
            {
                if (ReferenceEquals(second, null))
                    return false;

                return true;
            }

            if (first.CompareTo(second) < 0)
                return true;

            return false;
        }

        public static bool CompareMore(CustomerRef first, CustomerRef second)
        {
            if (ReferenceEquals(first, null))
            {
                if (ReferenceEquals(second, null))
                    return true;

                return false;
            }

            if (first.CompareTo(second) > 0)
                return true;

            return false;
        }
        #endregion
    }
}