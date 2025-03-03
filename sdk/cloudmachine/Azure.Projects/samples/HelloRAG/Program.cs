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

List<ChatMessage> messages = [];
ChatTools tools = new(typeof(Tools));

ClientAgent agent = new(project, tools);

while (true)
{
    Console.Write("> ");
    string prompt = Console.ReadLine();
    if (string.IsNullOrEmpty(prompt)) continue;
    if (string.Equals(prompt, "bye", StringComparison.OrdinalIgnoreCase)) break;
    if (prompt.StartsWith("fact:", StringComparison.OrdinalIgnoreCase))
    {
        string fact = prompt[5..].Trim();
        agent.VectorDb.Add(fact);
        continue;
    }

    ChatCompletion completion = agent.TakeTurn(messages, prompt);

    Console.WriteLine(completion.AsText());
}

class Tools
{
    public static string GetCurrentTime() => DateTime.Now.ToString("T");
}

class ClientAgent
{
    public EmbeddingsVectorbase VectorDb { get; set; }
    public ChatTools Tools { get; set; }

    private readonly ChatClient _chat;

    public ClientAgent(ChatClient chat)
    {
        _chat = chat;
    }

    public ClientAgent(ProjectClient project, ChatTools tools = default)
    {
        Tools = tools;
        _chat = project.GetOpenAIChatClient();
        EmbeddingClient embeddings = project.GetOpenAIEmbeddingsClient();
        VectorDb = new(embeddings);
    }

    public ChatCompletion TakeTurn(List<ChatMessage> conversation, string prompt)
    {
        OnGround(conversation, prompt);

        conversation.Add(ChatMessage.CreateUserMessage(prompt));

    complete:
        ChatCompletion completion = OnComplete(conversation, prompt);

        switch (completion.FinishReason)
        {
            case ChatFinishReason.Stop:
                OnStop(conversation, completion);
                return completion;
            case ChatFinishReason.Length:
                OnLength(conversation, completion);
                goto complete;
            case ChatFinishReason.ToolCalls:
                OnToolCalls(conversation, completion);
                goto complete;
            default:
                //case ChatFinishReason.ContentFilter:
                //case ChatFinishReason.FunctionCall:
                throw new NotImplementedException();
        }
    }

    protected virtual void OnGround(List<ChatMessage> conversation, string prompt)
    {
        var related = VectorDb.Find(prompt);
        conversation.Add(related);
    }
    protected virtual ChatCompletion OnComplete(List<ChatMessage> conversation, string prompt)
    {
        ChatCompletion completion = _chat.CompleteChat(conversation, Tools.ToOptions());
        return completion;
    }
    protected virtual void OnStop(List<ChatMessage> conversation, ChatCompletion completion)
    {
        conversation.Add(completion);
    }
    protected virtual void OnLength(List<ChatMessage> conversation, ChatCompletion completion)
    {
        conversation.RemoveRange(0, conversation.Count / 2);
    }
    protected virtual void OnToolCalls(List<ChatMessage> conversation, ChatCompletion completion)
    {
        conversation.Add(completion);
        IEnumerable<ToolChatMessage> toolResults = Tools.CallAll(completion.ToolCalls);
        conversation.AddRange(toolResults);
    }
}
