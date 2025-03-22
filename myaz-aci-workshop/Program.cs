var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Allow all origins
              .AllowAnyHeader() // Allow any headers
              .AllowAnyMethod(); // Allow any method (GET, POST, etc.)
    });
});

// Add controllers
Console.WriteLine("latest version");
builder.Services.AddControllers();

var app = builder.Build();

// Use CORS
app.UseCors("AllowAll");  // Apply the CORS policy

app.UseAuthorization();
app.MapControllers();
app.Run();