using System;
using CoconutIsland.Api.Configuration;
using CoconutIsland.Ingredient.Application;
using CoconutIsland.Ingredient.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;

namespace CoconutIsland.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions.PropertyNamingPolicy =
                            SnakeCaseNamingPolicy.Instance);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo {Title = "CoconutIsland.Api", Version = "v1"});
            });

            services.AddIngredientApplication();

            services.AddDbContext<IngredientContext>(options =>
            {
                options.UseNpgsql(new NpgsqlConnection()
                {
                    ConnectionString = new NpgsqlConnectionStringBuilder()
                    {
                        Host = "localhost",
                        Database = "postgres",
                        Username = "postgres",
                        Password = "",
                        Port = 5432,
                    }.ConnectionString
                }, builder => { builder.SetPostgresVersion(new Version(11, 6)); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoconutIsland.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}