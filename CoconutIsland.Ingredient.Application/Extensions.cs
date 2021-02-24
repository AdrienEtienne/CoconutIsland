using System.Reflection;
using CoconutIsland.Ingredient.Domain.AggregateModels.ProduceAggregate;
using CoconutIsland.Ingredient.Infrastructure;
using CoconutIsland.Ingredient.Infrastructure.Repositories;
using CoconutIsland.Structure.Aggregate;
using CoconutIsland.Structure.Builder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CoconutIsland.Ingredient.Application
{
    public static class Extensions
    {
        public static void AddIngredientApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Domain
            services.AddScoped<Director>();

            // Unit of work
            services.AddTransient<IUnitOfWork, IngredientContext>();

            // Repositories
            services.AddTransient<IProduceRepository, ProduceRepository>();

            // Domain events

            // Commands
        }
    }
}