using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniMakers.Products.Application.Products.Interfaces;
using MiniMakers.Products.Infrastructure.Persistence;
using MiniMakers.Products.Infrastructure.Repositories;
using MiniMakers.Products.Application.Products.Queries;
using FluentValidation;
using MiniMakers.Products.Application.Products.Behaviors;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<GetProductsQuery>();
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssemblyContaining<GetProductsQueryValidator>();

builder.Services.AddDbContext<ProductsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
    sqlOptions => sqlOptions.CommandTimeout(300)));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API V1");
    options.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
