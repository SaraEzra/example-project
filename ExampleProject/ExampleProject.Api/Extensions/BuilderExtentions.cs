using Microsoft.OpenApi.Models;

namespace ExampleProject.Api.Extensions
{
    public static class BuilderExtentions
    {
        public static void AddSwaggerSetting(this WebApplicationBuilder builder, ConfigurationManager configuration)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExampleProject.Api", Version = "v1" });
                c.OperationFilter<SwaggerFileOperationFilter>();
            });
        }
    }
}
