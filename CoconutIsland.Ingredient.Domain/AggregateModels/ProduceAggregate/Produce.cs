using CoconutIsland.Ingredient.Domain.StrongTypes;
using CoconutIsland.Structure.Aggregate;

namespace CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate
{
    public class Produce : Entity, IAggregateRoot
    { 
        internal Produce(NameType name, int? id) : base(id)
        {
            Name = name;
        }

        public NameType Name { get; }
    }
}