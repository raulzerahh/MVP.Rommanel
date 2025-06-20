using MVP.Project.UI.Web.Configurations;
using MVP.Project.Infra.CrossCutting.Identity.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adding Services
builder.AddMvcConfiguration()                   // Entire MvpProject MVC Config
       .AddDatabaseConfiguration()              // Setting DBContexts
       .AddWebIdentityConfiguration()           // ASP.NET Identity Config
       .AddDependencyInjectionConfiguration();  // DotNet Native DI Abstraction

var app = builder.Build();

// Configure Services
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage()
       .UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/error/500")
       .UseStatusCodePagesWithRedirects("/error/{0}")
       .UseHsts();
}

app.UseHttpsRedirection()
   .UseStaticFiles()
   .UseRouting()
   .UseAuthentication()
   .UseAuthorization();

app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Applying migrations and seeding some data
app.UseDbSeed();

app.Run();
