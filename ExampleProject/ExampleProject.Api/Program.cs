using ExampleProject.Api.Extensions;
using ExampleProject.Core.Mapping;
using ExampleProject.Core.Repository;
using ExampleProject.Core.Services;
using ExampleProject.Data;
using ExampleProject.Data.DataRepository;
using ExampleProject.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using SlackLogger;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
configuration.AddEnvironmentVariables();
builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddCors(options => options.AddPolicy("allowAny", o => o.AllowAnyOrigin()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ExampleContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ExampleDB")
     , x =>
     {
         x.MigrationsAssembly("ExampleProject.Data"); x.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
         x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
     });
    options.UseLoggerFactory(LoggerFactory.Create(builder =>
    {
        builder.AddDebug();
    }));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

builder.Services.AddLogging();
builder.Services.AddApplicationInsightsTelemetry();
builder.Logging.AddSlack();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExampleProject.Api", Version = "v1" });
    c.OperationFilter<SwaggerFileOperationFilter>();
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampleProject.Api V1");
});

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
    builder.WithExposedHeaders("Content-Disposition");
});

app.MapControllers();

app.Run();
