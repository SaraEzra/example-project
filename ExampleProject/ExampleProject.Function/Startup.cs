using ExampleProject.Core.Mapping;
using ExampleProject.Core.Models;
using ExampleProject.Core.Repository;
using ExampleProject.Core.Services;
using ExampleProject.Data;
using ExampleProject.Data.DataRepository;
using ExampleProject.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SlackLogger;
using System;

[assembly: FunctionsStartup(typeof(ExampleProject.Function.StartUp))]

namespace ExampleProject.Function
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
            builder.Services.AddScoped<CurrentRequest>();
    
            builder.Services.AddDbContext <ExampleContext > (options => options.UseSqlServer(config.GetConnectionString("ExampleDB")
             , x =>
             {
                 x.MigrationsAssembly("ExampleProject.Data"); x.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                 x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
             }));
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDataRepository, DataRepository>();

            builder.Services.AddMemoryCache();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddLogging(builder =>
            {
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddSlack(options =>
                {
                    options.WebhookUrl = config.GetValue<string>("SlackWebhookUrl");
                });
            });


        }

    }

}
