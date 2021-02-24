using System.Threading;
using System.Threading.Tasks;
using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using CoconutIsland.Ingredient.Infrastructure.Entities;
using CoconutIsland.Ingredient.Infrastructure.EntityConfigurations;
using CoconutIsland.Structure.Aggregate;
using CoconutIsland.Structure.Builder;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoconutIsland.Ingredient.Infrastructure
{
    public class IngredientContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        private readonly Director _director;

        public IngredientContext(IMediator mediator, Director director)
        {
            _mediator = mediator;
            _director = director;
        }

        public DbSet<ProduceEntity> Produces { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProduceEntityTypeConfiguration());
        }

        public async Task<bool> CompleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(_director);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}