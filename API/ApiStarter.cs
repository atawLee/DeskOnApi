﻿namespace API;

public class ApiStarter
{
    public async Task StartApi()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddOpenApi();
        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");

        await app.RunAsync();
    }
}