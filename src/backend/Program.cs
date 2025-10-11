using Microsoft.EntityFrameworkCore;
using OneManDev_PI.Repositories;
using OneManDev_PI.Services;

var builder = WebApplication.CreateBuilder(args);

// Nome da política CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Serviços
builder.Services.AddScoped<MesaRepository>();
builder.Services.AddScoped<MesaService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext com Npgsql usando a connection string "DefaultConnection"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS (ajuste a origem conforme sua porta do frontend: 3000 com Nginx, ou 5173 no Vite)
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Aplica migrações automaticamente ao subir (dev)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Swagger em Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

// Escutar em todas as interfaces na 5000
app.Urls.Add("http://0.0.0.0:5000");

app.Run();
