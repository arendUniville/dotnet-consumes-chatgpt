using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;





namespace DotnetTalkChatGPT.Controllers;



[Route("/api/v1/[controller]")]
public class ChatController : Controller
{

    private readonly OpenAIAPI _chatGpt;


    public ChatController(OpenAIAPI chatGpt)
    {
        _chatGpt = chatGpt;
    }



    [HttpGet("/method1")]
    public async Task<IActionResult> Chat([FromQuery(Name = "prompt")] string prompt )
    {
        var response = string.Empty;


        var completion = new CompletionRequest
        {
            Prompt = prompt,
            Model = "gpt-3.5-turbo",
            MaxTokens = 200,
        };


        var result = await _chatGpt.Completions.CreateCompletionAsync(completion);

        result.Completions.ForEach(resultText => response = resultText.Text);


        return Ok(response);
    }



    [HttpGet("/method2")]
    public async Task<IActionResult> Chat2([FromQuery(Name = "prompt")] string prompt)
    {
        var response = string.Empty;

        var chatRequest = new ChatRequest
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<ChatMessage>
            {
                new ChatMessage(ChatMessageRole.System, "Você é um assistente útil."),
                new ChatMessage(ChatMessageRole.User, "Olá, como você está?")
            }
        };

        var chatResult = await _chatGpt.Chat.CreateChatCompletionAsync(chatRequest);

        var responseMessage = chatResult.Choices.First().Message.Content;


        return Ok(responseMessage);
    }




}
