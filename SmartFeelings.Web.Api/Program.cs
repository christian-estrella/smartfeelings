using SmartFeelings.Application;
using SmartFeelings.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Application services
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
