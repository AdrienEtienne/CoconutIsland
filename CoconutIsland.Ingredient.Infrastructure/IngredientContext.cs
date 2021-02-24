using System.Threading;
using System.Threading.Tasks;
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
        private readonly Director _director;
        private readonly IMediator _mediator;


        public IngredientContext(IMediator mediator, Director director)
        {
            this._mediator = mediator;
            this._director = director;
        }


        public DbSet<ProduceEntity> Produces { get; set; } = null!;


        public async Task<bool> CompleteAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await this._mediator.DispatchDomainEventsAsync(this._director);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProduceEntityTypeConfiguration());
        }
    }
}