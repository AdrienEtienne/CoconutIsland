using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CoconutIsland.Structure.Aggregate
{
    public abstract class Enumeration : IComparable
    {
        protected Enumeration(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


        public int Id { get; }

        public string Name { get; }


        public int CompareTo(object? other)
        {
            if ( other == null ) throw new ArgumentNullException(nameof(other));
            return this.Id.CompareTo(( ( Enumeration ) other ).Id);
        }


        public override string ToString()
        {
            return this.Name;
        }


        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields =
                typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static |
                                    BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }


        public override bool Equals(object? obj)
        {
            if ( obj == null ) return false;

            var otherValue = ( Enumeration ) obj;

            var typeMatches = this.GetType() == obj.GetType();
            var valueMatches = this.Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }


        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }


        public static T FromValue<T>(int value) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }


        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            var matchingItem =
                Parse<T, string>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }


        private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate)
            where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if ( matchingItem == null )
                throw new InvalidOperationException(
                    $"'{value}' is not a valid {description} in {typeof(T)}");

            return matchingItem;
        }
    }
}