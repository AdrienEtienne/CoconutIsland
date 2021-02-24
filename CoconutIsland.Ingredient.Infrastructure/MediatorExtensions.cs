using System.Threading.Tasks;
using CoconutIsland.Structure.Builder;
using MediatR;

namespace CoconutIsland.Ingredient.Infrastructure
{
    internal static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, Director director)
        {
            foreach (var domainEvent in director.DomainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}