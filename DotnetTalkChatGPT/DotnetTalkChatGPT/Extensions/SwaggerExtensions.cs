using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DotnetTalkChatGPT.Extensions;


public static class SwaggerExtensions
{

    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {

        //Buscando nome da aplicação
        string? appName = configuration["application_name"] ?? "No app name";

        //Buscando versao
        string version = Assembly.GetEntryAssembly().GetName().Version.ToString();

        if (string.IsNullOrEmpty(version))
        {
            version = string.Empty;
        }



        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(version, new OpenApiInfo
            {
                Title = appName,
                Version = version,
            });

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });

    }
    
    public static void UseSwaggerDoc(this IApplicationBuilder app, string appName)
    {
        //Buscando versao
        string version = Assembly.GetEntryAssembly().GetName().Version.ToString();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"/swagger/{version}/swagger.json", appName);
            c.RoutePrefix = "swagger";
        });

    }


    

}
