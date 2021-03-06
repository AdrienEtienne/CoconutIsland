using System.Collections.Generic;
using System.Linq;
using CoconutIsland.Structure.Builder;

namespace CoconutIsland.Structure.Aggregate
{
    public abstract class ValueObject : Product
    {
        protected static bool EqualOperator(ValueObject? left, ValueObject? right)
        {
            if ( ReferenceEquals(left, null) ^ ReferenceEquals(right, null) ) return false;
            return ReferenceEquals(left, null) || left.Equals(right);
        }


        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }


        protected abstract IEnumerable<object> GetEqualityComponents();


        public override bool Equals(object? obj)
        {
            if ( obj == null || obj.GetType() != this.GetType() ) return false;

            var other = ( ValueObject ) obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }


        public override int GetHashCode()
        {
            return this.GetEqualityComponents()
                       .Select(x => x != null ? x.GetHashCode() : 0)
                       .Aggregate((x, y) => x ^ y);
        }


        public ValueObject GetCopy()
        {
            return ( ValueObject ) this.MemberwiseClone();
        }
    }
}