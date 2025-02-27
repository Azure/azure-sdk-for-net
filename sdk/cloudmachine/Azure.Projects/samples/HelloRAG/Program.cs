using Azure.Messaging.EventGrid.SystemEvents;
using Azure.Projects;
using Azure.Projects.OpenAI;
using OpenAI.Chat;
using OpenAI.Embeddings;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));

// the app can be called with -init switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;

ProjectClient project = infrastructure.GetClient();
ChatClient chat = project.GetOpenAIChatClient();
EmbeddingClient embeddings = project.GetOpenAIEmbeddingsClient();
EmbeddingsVectorbase vectorDb = new(embeddings);
List<ChatMessage> messages = [];
ChatTools tools = new ChatTools(typeof(Tools));

while (true)
{
    Console.Write("> ");
    string prompt = Console.ReadLine();
    if (string.IsNullOrEmpty(prompt)) continue;
    if (string.Equals(prompt, "bye", StringComparison.OrdinalIgnoreCase)) break;

    messages.Add(ChatMessage.CreateUserMessage(prompt));

    complete:
    ChatCompletion completion = chat.CompleteChat(messages, tools.ToOptions());

    switch (completion.FinishReason)
    {
        case ChatFinishReason.Stop:
            messages.Add(completion);
            Console.WriteLine(completion.AsText());
            break;
        case ChatFinishReason.Length:
            messages = new (messages.Slice(messages.Count/2, messages.Count/2));
            goto complete;
        case ChatFinishReason.ToolCalls:
            messages.Add(completion);
            IEnumerable<ToolChatMessage> toolResults = tools.CallAll(completion.ToolCalls);
            messages.AddRange(toolResults);
            goto complete;
        default:
            //case ChatFinishReason.ContentFilter:
            //case ChatFinishReason.FunctionCall:
            throw new NotImplementedException();
    }
}

class Tools
{
    public static string GetCurrentTime() => DateTime.Now.ToString("T");
}
