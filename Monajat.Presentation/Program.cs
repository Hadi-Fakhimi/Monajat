using Microsoft.EntityFrameworkCore;
using Monajat.Infra.Data.Context;
using Monajat.Infra.Data.Seeder;
using Monajat.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Context

builder.Services.AddDbContext<MonajatDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), sqlOption =>
    {
        sqlOption.MaxBatchSize(5000);
    });

});

#endregion

#region Services-IoC

DependencyContainer.RegisterService(builder.Services);

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

#region Seed data

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MonajatDbContext>();
    context.Database.EnsureCreated();
    await DataSeeder.SeedDataAsync(context);
}

#endregion

app.Run();
