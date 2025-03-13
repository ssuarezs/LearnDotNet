using DependencyInjection.Interfaces;
using DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddTransient<IWelcomeService ,WelcomeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", (IWelcomeService welcomeService1, IWelcomeService welcomeService2) =>
{
    string message1 = $"Message1: {welcomeService1.GetWelcomeMessage()}";
    string message2 = $"Message2: {welcomeService2.GetWelcomeMessage()}";
    return $"{message1}\n{message2}";
});

await app.RunAsync();
