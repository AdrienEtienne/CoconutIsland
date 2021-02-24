using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using CoconutIsland.Structure.Builder;
using FluentValidation;

namespace CoconutIsland.Ingredient.Domain.Builders
{
    public class IngredientBuilder : Builder<Produce>
    {
        public IngredientBuilder(Produce product) : base(product)
        {
        }

        protected override AbstractValidator<Produce> GetValidator()
        {
            var validator = new InlineValidator<Produce>();

            return validator;
        }
    }
}