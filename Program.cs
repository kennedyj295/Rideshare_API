using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rideshare_API.Data;
using Rideshare_API.Entities;
using Rideshare_API.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();
//builder.Services.AddAuthorization(opt =>
//{
//    opt.AddPolicy("RequreRiderRole", policy => policy.RequireRole("Rider"));
//    opt.AddPolicy("RequireDriverRole", policy => policy.RequireRole("Driver"));
//});
builder.Services.AddScoped<IRiderRepository, RiderRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await RoleSeeder.SeedRoles(app.Services);

app.Run();
