using IT_EXPERT.Test.DAL;
using IT_EXPERT.Test.Services;
using IT_EXPERT.Test.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("it_expertTestDb");

builder.Host.UseSerilog((context, config) =>
{    
    config.WriteTo.PostgreSQL(connectionString, "Logs", needAutoCreateTable: true)
    .MinimumLevel.Information();

    if (context.HostingEnvironment.IsDevelopment())
    {
        config.WriteTo.Console().MinimumLevel.Information();
    }
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(option => option.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ApplicationContext>().Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHttpLogging();
app.Run();
