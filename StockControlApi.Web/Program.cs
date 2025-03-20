using Microsoft.EntityFrameworkCore;
using StockControlApi.Application.Services;
using StockControlApi.Core.Interfaces;
using StockControlApi.Infrastructure.Data;
using StockControlApi.Infrastructure.Repositories;
using StockControlApi.Web.Extensions;
using StockControlApi.Infrastructure.Data.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StockContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StockContext>();
    context.EnsureDatabaseMigrated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
