using OpenAI_API;

namespace DotnetTalkChatGPT.Extensions;

public static class ChatGptExtensions
{

    public static WebApplicationBuilder AddChatGpt(this WebApplicationBuilder builder, IConfiguration configuration)
    {

        string? key = configuration["ChatGpt:Key"];

        if(key == null || string.IsNullOrEmpty(key)) 
        {
            throw new ArgumentNullException("A key de utilização do ChatGPT não foi informada no arquivo 'appsettings.json'.");
        }

        var chat = new OpenAIAPI(key);


        builder.Services.AddSingleton(chat);


        return builder;

    }
}
