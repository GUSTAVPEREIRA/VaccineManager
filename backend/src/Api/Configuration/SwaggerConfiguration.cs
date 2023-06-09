using System.Reflection;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Api.Configuration;

public static class SwaggerConfiguration
{
    private const string GithubUrl = "https://github.com/GUSTAVPEREIRA";

    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Vaccine Manager API",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Email = "gugupereira123@hotmail.com",
                        Name = "Gustavo Antonio Pereira",
                        Url = new Uri(GithubUrl)
                    },
                    TermsOfService = new Uri(GithubUrl)
                });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insert Token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            xmlPath = Path.Combine(AppContext.BaseDirectory, "Application.xml");
            c.IncludeXmlComments(xmlPath);
        });

        services.AddFluentValidationRulesToSwagger();
        services.AddSwaggerGenNewtonsoftSupport();
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        });
    }
}