using Microsoft.EntityFrameworkCore;
using PracticalTwenty.Data.Contexts;
using PracticalTwenty.Data.Interfaces;
using PracticalTwenty.Data.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//configure service files
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IApplicationLogRepository, ApplicationLogRepository>();

//Configure Serilog 
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//Use Serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStatusCodePagesWithReExecute("/Error/PageNotFound");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
