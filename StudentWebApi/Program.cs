using StudentWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddSingleton<IStudentService, StudentService>(); // Use singleton to persist in-memory data

var app = builder.Build();

// Map controllers
app.MapControllers();

app.Run();
