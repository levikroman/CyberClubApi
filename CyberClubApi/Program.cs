using Microsoft.EntityFrameworkCore; // ДОДАНО
using CyberClubApi.Data;             // ДОДАНО

var builder = WebApplication.CreateBuilder(args);

// --- ДОДАНО: Підключення до бази даних SQLite ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=cyberclub.db"));
// -------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройка конвейера HTTP-запросов.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();