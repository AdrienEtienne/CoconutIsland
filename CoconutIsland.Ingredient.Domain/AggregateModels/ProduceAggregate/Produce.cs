using CoconutIsland.Ingredient.Domain.StrongTypes;
using CoconutIsland.Structure.Aggregate;

namespace CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate
{
    public class Produce : Entity, IAggregateRoot
    {
        public Produce(int id, NameType name) : base(id)
        {
            this.Name = name;
        }


        public NameType Name { get; }
    }
}