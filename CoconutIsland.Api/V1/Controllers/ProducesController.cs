using System.Linq;
using System.Threading.Tasks;
using CoconutIsland.Api.V1.Models;
using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CoconutIsland.Api.V1.Controllers
{
    public class ProducesController : V1Controller
    {
        private readonly IProduceRepository _produceRepository;

        public ProducesController(IProduceRepository produceRepository)
        {
            this._produceRepository = produceRepository;
        }

        [HttpGet]
        public async Task<ListResponse<ProduceDto>> GetAsync()
        {
            var produces = await this._produceRepository.ListAllAsync();

            return new ListResponse<ProduceDto>(produces.Select(produce =>
                new ProduceDto(produce.Id, produce.Name.Name)));
        }
    }
}