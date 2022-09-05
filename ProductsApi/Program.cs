using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Interfaces;
using ProductsApi.Repositiories;
using ProductsApi.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IValidator<Product>, ProductValidator>();
builder.Services.AddTransient<IValidator<Category>, CategoryValidator>();


builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
