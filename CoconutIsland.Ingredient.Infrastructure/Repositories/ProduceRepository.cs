using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using CoconutIsland.Ingredient.Domain.Builders;
using CoconutIsland.Ingredient.Domain.StrongTypes;
using CoconutIsland.Structure.Aggregate;
using CoconutIsland.Structure.Builder;
using Microsoft.EntityFrameworkCore;

namespace CoconutIsland.Ingredient.Infrastructure.Repositories
{
    public class ProduceRepository : IProduceRepository
    {
        private readonly IngredientContext _ingredientContext;
        private readonly Director _director;

        public ProduceRepository(IngredientContext ingredientContext, Director director)
        {
            _ingredientContext = ingredientContext;
            _director = director;
        }

        public IUnitOfWork UnitOfWork => _ingredientContext;

        public async Task<IEnumerable<Produce>> ListAll()
        {
            var produceEntities = await _ingredientContext.Produces.ToListAsync();

            return produceEntities.Select(entity => _director.Build(new ProduceBuilder(
                entity.Id,
                new NameType(entity.Name))));
        }
    }
}