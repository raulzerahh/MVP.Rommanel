using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MVP.Project.Infra.Data.Context;

namespace MVP.Project.Services.Api.Configuration;

public static class ApplicationBuilderExtensions
{
    public static void UseDbSeed(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }

    public static void UseSwaggerSetup(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MVP Project API v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
} 