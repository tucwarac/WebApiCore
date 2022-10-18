global using Microsoft.EntityFrameworkCore;
global using WebApiCore.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApiCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//// Add services to the container.
//builder.Services.AddControllers()
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

//// Configure the API versioning properties of the project. 
//builder.Services.AddApiVersioningConfigured();

//// Add a Swagger generator and Automatic Request and Response annotations:
//builder.Services.AddSwaggerSwashbuckleConfigured();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //// Enable middleware to serve the generated OpenAPI definition as JSON files.
    //app.UseSwagger();

    //// Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.) by specifying the Swagger JSON files(s).
    //var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    //app.UseSwaggerUI(options =>
    //{
    //    // Build a swagger endpoint for each discovered API version
    //    foreach (var description in descriptionProvider.ApiVersionDescriptions)
    //    {
    //        options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    //    }
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
