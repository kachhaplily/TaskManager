using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.applicationDbContext;
using TaskManager.Model;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL database connection
var connectionString = builder.Configuration.GetConnectionString("taskManagement");
builder.Services.AddDbContext<applicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add user identity
builder.Services.AddIdentity<appUser, IdentityRole>()
          .AddEntityFrameworkStores<applicationDbContext>()
          .AddDefaultTokenProviders();

// Add services to the container
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
