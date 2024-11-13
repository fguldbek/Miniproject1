using ServerAPI1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Tilføj CORS-politik
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:7147", "http://localhost:5144")  // Brug præcis din frontend URL her
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Tilføj services til containeren
builder.Services.AddControllers();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

// Swagger-konfiguration for dokumentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Tilføj CORS-politik til middleware
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");  // Bemærk at "AllowSpecificOrigin" bruges her
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

