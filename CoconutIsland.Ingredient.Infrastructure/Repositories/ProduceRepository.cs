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
        private readonly Director _director;
        private readonly IngredientContext _ingredientContext;


        public ProduceRepository(IngredientContext ingredientContext, Director director)
        {
            this._ingredientContext = ingredientContext;
            this._director = director;
        }


        public IUnitOfWork UnitOfWork => this._ingredientContext;


        public async Task<IEnumerable<Produce>> ListAllAsync()
        {
            var produceEntities = await this._ingredientContext.Produces.ToListAsync();

            return produceEntities.Select(entity => this._director.Build(new ProduceBuilder(
                entity.Id,
                new NameType(entity.Name))));
        }
    }
}