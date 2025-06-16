using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MVP.Project.Services.Api.Configuration;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MVP Project API",
                Version = "v1",
                Description = "API do MVP Project",
                Contact = new OpenApiContact
                {
                    Name = "MVP Project",
                    Email = "contato@mvpproject.com"
                }
            });
        });
    }
} 