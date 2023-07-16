using Microsoft.EntityFrameworkCore;
using PracticalTwenty.Data.Contexts;
using PracticalTwenty.Data.Interfaces;
using PracticalTwenty.Data.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configure DB Context
builder.Services.AddDbContext<ApplicationDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//configure service files
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Configure Serilog 
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Error");
app.UseHsts();

//Use Serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

//Redirect error codes
app.UseStatusCodePagesWithReExecute("/Error/PageNotFound/{0}");

app.UseStaticFiles();
app.UseRouting();

// Default app route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

try
{
    Log.Information("Application execution start - {DT}", DateTime.Now);
    app.Run();
}
catch (Exception e)
{
    Log.Information("Exception thrown - {Exc}", e.Message);
}
finally
{
    Log.Information("Application execution end - {DT}", DateTime.Now);
}