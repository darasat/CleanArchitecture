using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Registrar IProductService con su implementación ProductService
builder.Services.AddScoped<IProductService, ProductService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
