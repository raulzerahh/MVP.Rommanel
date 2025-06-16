using MVP.Project.Infra.CrossCutting.Identity.Configuration;
using MVP.Project.Services.Api.Configurations;
using MVP.Project.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.AddApiConfiguration();
builder.AddDatabaseConfiguration();
builder.AddApiIdentityConfiguration();
builder.AddSwaggerConfiguration();
NativeInjectorBootStrapper.RegisterServices(builder);

var app = builder.Build();

// Configure
app.UseHttpsRedirection();
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.UseDbSeed();
app.UseSwaggerSetup();

app.Run();