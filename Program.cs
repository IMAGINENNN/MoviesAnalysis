using Microsoft.EntityFrameworkCore;
using MoviesAnalysis.Data;
// using MoviesAnalysis.Services;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add TMDb service and MVC
// builder.Services.AddScoped<TmdbService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
