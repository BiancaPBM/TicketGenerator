
using Microsoft.EntityFrameworkCore;
using TicketGenerator.BusinessLogic;
using TicketGenerator.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var connectionString = string.Format(@"Data Source={0};Initial Catalog={1};User Id={2};Password={3};Persist Security Info=True;TrustServerCertificate=True;MultipleActiveResultSets=True;Column Encryption Setting=enabled",
                                    builder.Configuration.GetValue<string>("AppSettings:DatabaseServer"),
                                    builder.Configuration.GetValue<string>("AppSettings:DatabaseName"),
                                    builder.Configuration.GetValue<string>("AppSettings:DatabaseUser"),
                                    builder.Configuration.GetValue<string>("AppSettings:DatabasePassword"));
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
