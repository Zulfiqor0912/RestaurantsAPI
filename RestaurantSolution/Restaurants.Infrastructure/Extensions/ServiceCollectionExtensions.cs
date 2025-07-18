﻿using Restaurants.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Repositories;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        services
            .AddDbContext<RestaurantsDbContext>(options => 
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());

        services.AddScoped<IRestaurantSeeders, RestaurantSeeders>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
    }
}
