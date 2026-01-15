namespace Azure.AI.Models
{
    public static partial class AIModelsExtensions
    {
        public static Azure.AI.Models.ModelsClient GetModelsClient(this System.ClientModel.Primitives.ClientConnectionProvider provider, string? deploymentName = null) { throw null; }
    }
    public partial class ModelsClient
    {
        protected ModelsClient() { }
        public ModelsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ModelsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, OpenAI.OpenAIClientOptions options) { }
        public ModelsClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential) { }
        public ModelsClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential, OpenAI.OpenAIClientOptions options) { }
        public OpenAI.Chat.ChatClient GetChatClient(string model) { throw null; }
        public OpenAI.Embeddings.EmbeddingClient GetEmbeddingClient(string model) { throw null; }
    }
}
namespace Azure.AI.OpenAI
{
    public static partial class AzureOpenAIExtensions
    {
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, OpenAI.Chat.ChatCompletion completion) { }
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, System.Collections.Generic.IEnumerable<Azure.Projects.AI.VectorbaseEntry> entries) { }
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> toolCallResults) { }
        public static string AsText(this OpenAI.Chat.ChatCompletion completion) { throw null; }
        public static string AsText(this OpenAI.Chat.ChatMessageContent content) { throw null; }
        public static string AsText(this System.ClientModel.ClientResult<OpenAI.Chat.ChatCompletion> completionResult) { throw null; }
        public static OpenAI.Chat.ChatClient GetOpenAIChatClient(this System.ClientModel.Primitives.ClientConnectionProvider provider, string? deploymentName = null) { throw null; }
        public static OpenAI.Embeddings.EmbeddingClient GetOpenAIEmbeddingClient(this System.ClientModel.Primitives.ClientConnectionProvider provider, string? deploymentName = null) { throw null; }
        public static void Trim(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages) { }
    }
}
namespace Azure.Projects
{
    public enum AIModelKind
    {
        Chat = 0,
        Embedding = 1,
    }
    public partial class AIModelsFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AIModelsFeature(string model, string modelVersion) { }
        protected override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
    }
    public partial class OpenAIChatFeature : Azure.Projects.OpenAIModelFeature
    {
        public OpenAIChatFeature(string model, string modelVersion) : base (default(string), default(string), default(Azure.Projects.AIModelKind)) { }
    }
    public partial class OpenAIEmbeddingFeature : Azure.Projects.OpenAIModelFeature
    {
        public OpenAIEmbeddingFeature(string model, string modelVersion) : base (default(string), default(string), default(Azure.Projects.AIModelKind)) { }
    }
    public partial class OpenAIModelFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public OpenAIModelFeature(string model, string modelVersion, Azure.Projects.AIModelKind kind = Azure.Projects.AIModelKind.Chat) { }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public System.ClientModel.Primitives.ClientConnection CreateConnection(string cmId) { throw null; }
        protected override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
        protected override void EmitFeatures(Azure.Projects.ProjectInfrastructure infrastructure) { }
    }
}
namespace Azure.Projects.AI
{
    public partial class ChatRunner
    {
        public ChatRunner(OpenAI.Chat.ChatClient chat) { }
        public ChatRunner(OpenAI.Chat.ChatClient chat, OpenAI.Embeddings.EmbeddingClient? embeddings) { }
        public Azure.Projects.AI.ChatTools Tools { get { throw null; } protected set { } }
        public Azure.Projects.AI.EmbeddingsStore? VectorDb { get { throw null; } set { } }
        protected virtual OpenAI.Chat.ChatCompletion OnComplete(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, string prompt) { throw null; }
        protected virtual void OnGround(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, string prompt) { }
        protected virtual void OnLength(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { }
        protected virtual void OnStop(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { }
        protected virtual System.Threading.Tasks.Task OnToolCalls(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { throw null; }
        protected virtual void OnToolError(System.Collections.Generic.List<string> failed, System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { }
        public System.Threading.Tasks.Task<OpenAI.Chat.ChatCompletion> TakeTurnAsync(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, string prompt) { throw null; }
    }
    public partial class ChatThread : System.Collections.Generic.List<OpenAI.Chat.ChatMessage>
    {
        public ChatThread() { }
    }
    public partial class ChatTools
    {
        public ChatTools(OpenAI.Embeddings.EmbeddingClient? embeddingClient = null) { }
        public ChatTools(params System.Type[] tools) { }
        public bool CanFilterTools { get { throw null; } }
        public System.Collections.Generic.IList<OpenAI.Chat.ChatTool> Definitions { get { throw null; } }
        public void Add(System.Reflection.MethodInfo function) { }
        public void Add(System.Type functions) { }
        public void AddLocalTools(params System.Type[] tools) { }
        public System.Threading.Tasks.Task AddMcpServerAsync(System.Uri serverEndpoint) { throw null; }
        public string Call(OpenAI.Chat.ChatToolCall call) { throw null; }
        public string Call(string name, object[] arguments) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> CallAll(System.Collections.Generic.IEnumerable<OpenAI.Chat.ChatToolCall> toolCalls) { throw null; }
        public System.Threading.Tasks.Task<Azure.Projects.AI.ToolCallResult> CallAllWithErrors(System.Collections.Generic.IEnumerable<OpenAI.Chat.ChatToolCall> toolCalls) { throw null; }
        public static implicit operator OpenAI.Chat.ChatCompletionOptions (Azure.Projects.AI.ChatTools tools) { throw null; }
        public OpenAI.Chat.ChatCompletionOptions ToOptions() { throw null; }
        public OpenAI.Chat.ChatCompletionOptions ToOptions(string prompt, Azure.Projects.AI.ChatTools.ToolFindOptions? options = null) { throw null; }
        public partial class ToolFindOptions
        {
            public ToolFindOptions() { }
            public int MaxEntries { get { throw null; } set { } }
            public float Threshold { get { throw null; } set { } }
        }
    }
    public abstract partial class EmbeddingsStore
    {
        protected EmbeddingsStore(OpenAI.Embeddings.EmbeddingClient client, int factChunkSize = 1000) { }
        public abstract int Add(Azure.Projects.AI.VectorbaseEntry entry);
        public void Add(System.BinaryData data) { }
        public abstract void Add(System.Collections.Generic.IReadOnlyList<Azure.Projects.AI.VectorbaseEntry> entry);
        public void Add(string text) { }
        public static float CosineSimilarity(System.ReadOnlySpan<float> x, System.ReadOnlySpan<float> y) { throw null; }
        public static Azure.Projects.AI.EmbeddingsStore Create(OpenAI.Embeddings.EmbeddingClient client) { throw null; }
        public abstract System.Collections.Generic.IEnumerable<Azure.Projects.AI.VectorbaseEntry> Find(System.ReadOnlyMemory<float> vector, Azure.Projects.AI.FindOptions options);
        public System.Collections.Generic.IEnumerable<Azure.Projects.AI.VectorbaseEntry> FindRelated(string text, Azure.Projects.AI.FindOptions? options = null) { throw null; }
    }
    public partial class FindOptions
    {
        public FindOptions() { }
        public int MaxEntries { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ToolCallResult
    {
        private object _dummy;
        private int _dummyPrimitive;
        public ToolCallResult(System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> messages, System.Collections.Generic.List<string>? failed = null) { throw null; }
        public System.Collections.Generic.List<string>? Failed { get { throw null; } }
        public System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> Messages { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorbaseEntry
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorbaseEntry(System.ReadOnlyMemory<float> vector, System.BinaryData data, int? id = default(int?)) { throw null; }
        public System.BinaryData Data { get { throw null; } }
        public int? Id { get { throw null; } }
        public System.ReadOnlyMemory<float> Vector { get { throw null; } }
    }
}
