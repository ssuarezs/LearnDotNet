using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PizzaStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapGet("/about", () => "Contoso was founded in 2000.");

app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));

app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
    {
        await db.Pizzas.AddAsync(pizza);
        await db.SaveChangesAsync();
        return Results.Created($"/pizza/{pizza.Id}", pizza);
    });

app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
    {
        var pizza = await db.Pizzas.FindAsync(id);
        if (pizza is null)
            return Results.NotFound();
        pizza.Name = updatepizza.Name;
        pizza.Description = updatepizza.Description;
        await db.SaveChangesAsync();
        return Results.NoContent();
    });

app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
    {
        var pizza = await db.Pizzas.FindAsync(id);
        if (pizza is null)
        {
            return Results.NotFound();
        }
        db.Pizzas.Remove(pizza);
        await db.SaveChangesAsync();
        return Results.Ok();
    });

await app.RunAsync();


