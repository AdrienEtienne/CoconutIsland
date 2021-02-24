using CoconutIsland.Ingredient.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoconutIsland.Ingredient.Infrastructure.EntityConfigurations
{
    public class ProduceEntityTypeConfiguration : IEntityTypeConfiguration<ProduceEntity>
    {
        public void Configure(EntityTypeBuilder<ProduceEntity> builder)
        {
            // Id
            builder
                .HasKey(cr => cr.Id);
            builder
                .Property(entity => entity.Id)
                .ValueGeneratedOnAddOrUpdate();

            // Name
            builder
                .Property(cr => cr.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder
                .HasIndex(entity => entity.Name);
        }
    }
}