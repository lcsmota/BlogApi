using System.Text.Json.Serialization;
using BlogApi.Context;
using BlogApi.Interfaces;
using BlogApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddDbContext<BlogDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(sw =>
    {
        sw.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Blog Api",
            Version = "v1",
            Description = "Simple CRUD using Entity Framework 6"
        });
    });
}

var app = builder.Build();
{

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}