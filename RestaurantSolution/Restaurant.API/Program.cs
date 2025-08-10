using Restaurant.API.Extensions;
using Restaurants.Application.Extension;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//var scope = app.Services.CreateScope();

//var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeders>();

//await seeder.Seed();

//app.UseMiddleware<ErrorHandlingMiddlewere>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<User>();

app.UseAuthorization();
app.MapControllers();

app.Run();