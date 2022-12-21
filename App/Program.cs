using GreenThumb.Persistence;
using GreenThumb.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSqlite<PlantDbContext>("Data Source=plants.db");
builder.Services.AddTransient<IDatabaseService, PlantDatabaseService>();

var app = builder.Build();

app.UseSwagger();

Plant plant = new();
app.MapGet("/test", () => "Hello World!");
app.MapGet("/plant-name", plant.Name);
app.MapPut("/add-plant", async (IDatabaseService svc, Plant plant) =>
{
    await svc.AddPlant(plant);
});
app.MapGet("list-plants", async (IDatabaseService svc) =>
{
    return await svc.GetPlants();
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
