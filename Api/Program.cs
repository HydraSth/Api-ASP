using Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ItesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DeafultConnection")));
//builder.Services.AddTransient<ITestService, TestService>(); Existe a lo largo del proyecto
//builder.Services.AddScoped<ITestService, TestService>(); Mientras estes conectado existe el objeto
//builder.Services.AddSingleton A lo largo de toda la conexion con la base de datos
builder.Services.AddSingleton<TokenGenerator>();
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