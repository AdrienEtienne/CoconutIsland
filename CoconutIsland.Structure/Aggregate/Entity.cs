using CoconutIsland.Structure.Builder;

namespace CoconutIsland.Structure.Aggregate
{
    public abstract class Entity : Product
    {
        protected Entity(int? id = null)
        {
            this.Id = id ?? this.Id;
        }


        public int Id { get; }


        public bool IsTransient()
        {
            return this.Id == 0;
        }


        public override bool Equals(object? obj)
        {
            if ( !( obj is Entity ) )
                return false;

            if ( ReferenceEquals(this, obj) )
                return true;

            if ( this.GetType() != obj.GetType() )
                return false;

            var item = ( Entity ) obj;

            if ( item.IsTransient() || this.IsTransient() )
                return false;
            return item.Id == this.Id;
        }


        public override int GetHashCode()
        {
            // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
            return 0;
        }


        public static bool operator ==(Entity? left, Entity? right)
        {
            return left?.Equals(right) ?? false;
        }


        public static bool operator !=(Entity left, Entity right)
        {
            return !( left == right );
        }
    }
}