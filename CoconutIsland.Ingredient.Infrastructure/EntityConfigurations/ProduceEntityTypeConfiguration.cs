using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoconutIsland.Ingredient.Infrastructure.EntityConfigurations
{
    public class ProduceEntityTypeConfiguration : IEntityTypeConfiguration<Produce>
    {
        public void Configure(EntityTypeBuilder<Produce> builder)
        {
            builder.HasKey(cr => cr.Id);
            builder
                .Property(entity => entity.Id)
                .ValueGeneratedOnAddOrUpdate();
            
            builder
                .Property(cr => cr.Name)
                .IsRequired();
        }
    }
}