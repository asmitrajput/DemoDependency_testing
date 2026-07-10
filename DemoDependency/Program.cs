using DemoDependency.CustomeMiddleware;
using DemoDependency.Database;
using DemoDependency.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registering connection string in program.cs file. 
// builder is an instance of WebApplicationBuilder class.
// Services is a property of builder that provides access to the IServiceCollection.
// AddDbContext is an extension method used to register a DbContext type with the dependency injection container.
// StudentDbContext is the custom DbContext class that manages the database operations for Student entities.
//option is a parameter that represents the options used to configure the DbContext.
// UseSqlServer is an extension method that configures the DbContext to use SQL Server as the database provider.
// Configuration is a property of builder that provides access to the application's configuration settings.
// GetConnectionString is a method that retrieves the connection string named "Democonnection" from the configuration settings.
// The connection string typically contains information such as the database server address, database name, authentication details, and other parameters required to establish a connection to the SQL Server database.
builder.Services.AddDbContext<StudentDbContext>(option=>option.UseSqlServer( builder.Configuration.GetConnectionString("Democonnection")));
builder.Services.AddScoped<IStudentRepo, StudentService>();
var app = builder.Build();
app.UseMiddleware<LoggingMiddleware>(); 
// test

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
