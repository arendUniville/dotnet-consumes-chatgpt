using DotnetTalkChatGPT.Extensions;



var builder = WebApplication.CreateBuilder(args);


builder.AddSerilog(builder.Configuration, "Dotnet 8 Talk With ChatGPT");

//Carregando infos de configuração do chatgpt
builder.AddChatGpt(builder.Configuration);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
