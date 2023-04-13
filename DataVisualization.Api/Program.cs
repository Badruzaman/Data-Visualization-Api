using Microsoft.EntityFrameworkCore;
using DataVisualization.DAL;
using DataVisualization.DAL.Repository;
using DataVisualization.Domain.Abstractions;
using DataVisualization.Service.Services;
using DataVisualization.Domain.Configuration;
using DataVisualization.Domain.Mappings;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));
builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection("MongoDbConnection"));
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ISecondaryOrderRepository, SecondaryOrderRepository>();
builder.Services.AddScoped<ISecondaryOrderService, SecondaryOrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.WithOrigins("http://localhost:7256", "https://localhost:7256").AllowAnyMethod().WithHeaders(HeaderNames.ContentType));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
