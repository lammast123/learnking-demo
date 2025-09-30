using LearnKing.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LearnKing API", Version = "v1" });
});

// Configure SQLite (file-based)
var connection = builder.Configuration.GetConnectionString("DefaultConnection") 
                 ?? "Data Source=learnking.db";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connection));

var app = builder.Build();

// ✅ Luôn bật Swagger (kể cả Production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearnKing API v1");
});

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map API controllers
app.MapControllers();

// Health check
app.MapGet("/health", () => Results.Ok("OK"));

app.Run();
