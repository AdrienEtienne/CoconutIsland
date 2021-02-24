using System.Collections.Generic;
using System.Threading.Tasks;
using CoconutIsland.Structure.Aggregate;

namespace CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate
{
    public interface IProduceRepository : IRepository<Produce>
    {
        Task<IEnumerable<Produce>> ListAllAsync();
    }
}