using DotnetTalkChatGPT.Extensions;



var builder = WebApplication.CreateBuilder(args);

string? appName = builder.Configuration["application_name"] ?? "No app name";


builder.AddSerilog(builder.Configuration, appName);

//Carregando infos de configura��o do chatgpt
builder.AddChatGpt(builder.Configuration);


//Os valores enviados na url passar�o para lowerCase
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

//Configurando swagger
builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


app.UseSwaggerDoc(appName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
