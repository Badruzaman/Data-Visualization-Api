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
using Amazon.Auth.AccessControlPolicy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("custom", policy =>
    {
        policy.Expire(TimeSpan.FromSeconds(10));
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));
builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection("MongoDbConnection"));
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ISecondaryOrderRepository, SecondaryOrderRepository>();
builder.Services.AddScoped<ISecondaryOrderService, SecondaryOrderService>();
builder.Services.AddScoped<ISecondaryOrderDataMigrationService, SecondaryOrderDataMigrationService>();
builder.Services.AddScoped<ISecondaryOrderDataMigrationRepository, SecondaryOrderDataMigrationRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseOutputCache();
app.Run();
