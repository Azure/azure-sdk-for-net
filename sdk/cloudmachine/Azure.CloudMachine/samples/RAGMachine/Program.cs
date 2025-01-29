using Azure.CloudMachine.AppService;
using Azure.CloudMachine.OpenAI;
using Azure.CloudMachine;
using OpenAI.Chat;

CloudMachineInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));
infrastructure.AddFeature(new AppServiceFeature());
CloudMachineClient client = infrastructure.GetClient();

// the app can be called with -init switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

// Add CloudMachine to the DI container
builder.Services.AddSingleton(client);

var app = builder.Build();
app.MapRazorPages();
app.UseStaticFiles();

EmbeddingsVectorbase vectorDb = new(client.GetOpenAIEmbeddingsClient());
List<ChatMessage> prompt = [];

// Register the vector db to be updated when a new file is uploaded
client.Storage.WhenUploaded(vectorDb.Add);

app.MapPost("/upload", async (HttpRequest request)
    => await client.Storage.UploadFormAsync(request));

app.MapPost("/chat", async (HttpRequest request) =>
{
    try
    {
        var message = await new StreamReader(request.Body).ReadToEndAsync();
        IEnumerable<VectorbaseEntry> related = vectorDb.Find(message);
        prompt.Add(related);
        prompt.Add(ChatMessage.CreateUserMessage(message));

        ChatClient chat = client.GetOpenAIChatClient();
        ChatCompletion completion = await chat.CompleteChatAsync(prompt);
        switch (completion.FinishReason)
        {
            case ChatFinishReason.Stop:
                prompt.Add(completion);
                string response = completion.Content[0].Text;
                return response;
            #region NotImplemented
            //case ChatFinishReason.Length:
            //case ChatFinishReason.ToolCalls:
            //case ChatFinishReason.ContentFilter:
            //case ChatFinishReason.FunctionCall:
            default:
                return ($"FinishReason {completion.FinishReason} not implemented");
                #endregion
        }
    }
    catch (Exception ex)
    {
        return ex.Message;
    }
});

app.Run();
