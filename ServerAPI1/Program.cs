using ServerAPI1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Tilføj CORS-politik
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
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
app.UseCors("AllowAllOrigins");  // Ensure CORS is applied before other middleware
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");  // Bemærk at "AllowAllOrigins" bruges her
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors("policy");
app.Run();

