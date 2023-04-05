using iot.Data.Configurations;
using iot.Data;
using Microsoft.EntityFrameworkCore;
using iot.Data.Repositories;
using iot.API;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DroneDatabase");
// Add services to the container.
var policyName = builder.Configuration.GetSection("Cors")["policyName"];
var origin = builder.Configuration.GetSection("Cors")["origin"];
builder.Services.AddCorsPolicy(policyName, origin);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IItemsRepository, ItemsRepository>();

builder.Services.AddSpaStaticFiles(Configuration =>
{
    Configuration.RootPath = "wwwroot/spa";
});
builder.Services.AddDatabase(connectionString);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();