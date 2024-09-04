using Microsoft.EntityFrameworkCore;
//using UniversityManagementSystem.API.DbContext;
using UniversityManagementSystem.API.StartupExtension;
using UniversityManagementSystem.BLL.Service;
//using UniversityManagementSystem.BLL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseExtentionHelper(builder.Configuration);//database configaration
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.RunMigration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

