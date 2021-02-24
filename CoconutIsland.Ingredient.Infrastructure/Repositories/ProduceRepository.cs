using System.Collections.Generic;
using System.Threading.Tasks;
using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using CoconutIsland.Structure.Aggregate;

namespace CoconutIsland.Ingredient.Infrastructure.Repositories
{
    public class ProduceRepository : IProduceRepository
    {
        public ProduceRepository(IngredientContext ingredientContext)
        {
            UnitOfWork = ingredientContext;
        }

        public IUnitOfWork UnitOfWork { get; }

        public Task<IEnumerable<Produce>> ListAll()
        {
            throw new System.NotImplementedException();
        }
    }
}