using Models;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// For Dependency Injection  (Uses a single instance of dictionary; which is the in-memory studentDb)
builder.Services.AddSingleton<IStudentService, StudentService>();

// For Controller
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{
    app.MapOpenApi();
    
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();





