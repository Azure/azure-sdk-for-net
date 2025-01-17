using Azure.CloudMachine.AppService;
using Azure.CloudMachine.OpenAI;
using Azure.CloudMachine;
using OpenAI.Chat;
using Azure.Core;

CloudMachineInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));
infrastructure.AddFeature(new AppServiceFeature());

// the app can be called with -init switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;

// create client, vector DB, prompt cache, tools definitaions
CloudMachineClient client = infrastructure.GetClient();
EmbeddingsVectorbase vectorDb = new(client.GetOpenAIEmbeddingsClient());
client.Storage.WhenUploaded(vectorDb.Add); // add documents that are uploaded to storage to the vector DB
ChatTools tools = new(typeof(Tools));

// setup ASP.NET app stuff
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddSingleton(client);
builder.Services.AddSingleton(client.GetOpenAIChatClient());
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapRazorPages();

// upload a document to storage (the document is then added to the vector DB)
app.MapPost("/upload", async (HttpRequest request) =>
    await client.Storage.UploadFormAsync(request));

// handle chat request
app.MapPost("/chat", async (HttpRequest request, ChatClient chat) =>
{
    ChatPrompt prompt = new();
    try
    {
        if (request.HttpContext.Session.TryGetValue("prompt", out byte[]? promptBytes))
        {
            prompt = ChatPrompt.Deserialize(promptBytes);
        }

        BinaryData message = await BinaryData.FromStreamAsync(request.Body);
        IEnumerable<VectorbaseEntry> related = vectorDb.Find(message.ToString());

        prompt.Add(related);
        prompt.Add(ChatMessage.CreateUserMessage(message.ToString()));

        complete:
        ChatCompletion completion = await chat.CompleteChatAsync(prompt);

        switch (completion.FinishReason)
        {
            case ChatFinishReason.Stop:
                prompt.Add(completion);
                string response = completion.Content[0].Text;
                return response;

            case ChatFinishReason.ToolCalls:
                prompt.Add(completion);
                IEnumerable<ToolChatMessage> toolResults = tools.CallAll(completion.ToolCalls);
                prompt.AddRange(toolResults);
                goto complete;

            case ChatFinishReason.Length:
                prompt.Trim();
                goto complete;

            default:
                return ($"FinishReason {completion.FinishReason} not implemented");
        }
    }
    catch (Exception ex)
    {
        return ex.Message;
    }
    finally
    {
        SessionBufferWriter writer = new(request.HttpContext.Session, "prompt");
        prompt.Serialize(writer);
    }
});

app.Run();

static class Tools
{
    public static string GetCurrentTime() => DateTime.Now.ToString("HH:mm");
}
