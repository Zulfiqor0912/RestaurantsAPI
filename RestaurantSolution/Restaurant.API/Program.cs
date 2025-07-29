using Microsoft.OpenApi.Models;
using Restaurant.API.Middlewares;
using Restaurants.Application.Extension;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
            },
            []
        }
    });
});


builder.Services.AddControllers();
builder.Services.AddScoped<ErrorHandlingMiddlewere>();
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration)
);


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeders>();

await seeder.Seed();

//app.UseMiddleware<ErrorHandlingMiddlewere>();


app.UseSerilogRequestLogging();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();
app.MapControllers();

app.Run();

