using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using CoconutIsland.Ingredient.Domain.StrongTypes;
using CoconutIsland.Structure.Builder;
using FluentValidation;

namespace CoconutIsland.Ingredient.Domain.Builders
{
    public class ProduceBuilder : Builder<Produce>
    {
        public ProduceBuilder(int id, NameType name) : base(new Produce(id, name))
        {
        }


        protected override AbstractValidator<Produce> GetValidator()
        {
            var validator = new InlineValidator<Produce>();

            return validator;
        }
    }
}