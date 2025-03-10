namespace Azure.AI.OpenAI
{
    public static partial class AzureOpenAIExtensions
    {
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, OpenAI.Chat.ChatCompletion completion) { }
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, System.Collections.Generic.IEnumerable<Azure.Projects.OpenAI.VectorbaseEntry> entries) { }
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> toolCallResults) { }
        public static string AsText(this OpenAI.Chat.ChatCompletion completion) { throw null; }
        public static string AsText(this OpenAI.Chat.ChatMessageContent content) { throw null; }
        public static string AsText(this System.ClientModel.ClientResult<OpenAI.Chat.ChatCompletion> completionResult) { throw null; }
        public static OpenAI.Chat.ChatClient GetOpenAIChatClient(this System.ClientModel.Primitives.ConnectionProvider provider, string? deploymentName = null) { throw null; }
        public static OpenAI.Embeddings.EmbeddingClient GetOpenAIEmbeddingClient(this System.ClientModel.Primitives.ConnectionProvider provider, string? deploymentName = null) { throw null; }
        public static void Trim(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages) { }
    }
}
namespace Azure.Projects.OpenAI
{
    public enum AIModelKind
    {
        Chat = 0,
        Embedding = 1,
    }
    public partial class ChatProcessor
    {
        public ChatProcessor(OpenAI.Chat.ChatClient chat) { }
        public ChatProcessor(OpenAI.Chat.ChatClient chat, OpenAI.Embeddings.EmbeddingClient? embeddings, Azure.Projects.OpenAI.ChatTools? tools = null) { }
        public Azure.Projects.OpenAI.ChatTools? Tools { get { throw null; } set { } }
        public Azure.Projects.OpenAI.EmbeddingsVectorbase? VectorDb { get { throw null; } set { } }
        protected virtual OpenAI.Chat.ChatCompletion OnComplete(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, string prompt) { throw null; }
        protected virtual void OnGround(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, string prompt) { }
        protected virtual void OnLength(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { }
        protected virtual void OnStop(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { }
        protected virtual void OnToolCalls(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { }
        protected virtual void OnToolError(System.Collections.Generic.List<string> failed, System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, OpenAI.Chat.ChatCompletion completion) { }
        public OpenAI.Chat.ChatCompletion TakeTurn(System.Collections.Generic.List<OpenAI.Chat.ChatMessage> conversation, string prompt) { throw null; }
    }
    public partial class ChatTools
    {
        public ChatTools(params System.Type[] tools) { }
        public System.Collections.Generic.IList<OpenAI.Chat.ChatTool> Definitions { get { throw null; } }
        public void Add(System.Reflection.MethodInfo function) { }
        public void Add(System.Type functions) { }
        public string Call(OpenAI.Chat.ChatToolCall call) { throw null; }
        public string Call(string name, object[] arguments) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> CallAll(System.Collections.Generic.IEnumerable<OpenAI.Chat.ChatToolCall> toolCalls) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> CallAll(System.Collections.Generic.IEnumerable<OpenAI.Chat.ChatToolCall> toolCalls, out System.Collections.Generic.List<string>? failed) { throw null; }
        public static implicit operator OpenAI.Chat.ChatCompletionOptions (Azure.Projects.OpenAI.ChatTools tools) { throw null; }
        public OpenAI.Chat.ChatCompletionOptions ToOptions() { throw null; }
    }
    public partial class EmbeddingsVectorbase
    {
        public EmbeddingsVectorbase(OpenAI.Embeddings.EmbeddingClient client, Azure.Projects.OpenAI.VectorbaseStore? store = null, int factChunkSize = 1000) { }
        public void Add(System.BinaryData data) { }
        public void Add(string text) { }
        public System.Collections.Generic.IEnumerable<Azure.Projects.OpenAI.VectorbaseEntry> Find(string text, Azure.Projects.OpenAI.FindOptions? options = null) { throw null; }
    }
    public partial class FindOptions
    {
        public FindOptions() { }
        public int MaxEntries { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
    }
    public partial class OpenAIChatFeature : Azure.Projects.OpenAI.OpenAIModelFeature
    {
        public OpenAIChatFeature(string model, string modelVersion) : base (default(string), default(string), default(Azure.Projects.OpenAI.AIModelKind)) { }
    }
    public partial class OpenAIEmbeddingFeature : Azure.Projects.OpenAI.OpenAIModelFeature
    {
        public OpenAIEmbeddingFeature(string model, string modelVersion) : base (default(string), default(string), default(Azure.Projects.OpenAI.AIModelKind)) { }
    }
    public partial class OpenAIModelFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public OpenAIModelFeature(string model, string modelVersion, Azure.Projects.OpenAI.AIModelKind kind = Azure.Projects.OpenAI.AIModelKind.Chat) { }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        protected override void AddImplicitFeatures(Azure.Projects.Core.FeatureCollection features, string cmId) { }
        public System.ClientModel.Primitives.ClientConnection CreateConnection(string cmId) { throw null; }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure cm) { throw null; }
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
    public abstract partial class VectorbaseStore
    {
        protected VectorbaseStore() { }
        public abstract int Add(Azure.Projects.OpenAI.VectorbaseEntry entry);
        public abstract void Add(System.Collections.Generic.IReadOnlyList<Azure.Projects.OpenAI.VectorbaseEntry> entry);
        public static float CosineSimilarity(System.ReadOnlySpan<float> x, System.ReadOnlySpan<float> y) { throw null; }
        public abstract System.Collections.Generic.IEnumerable<Azure.Projects.OpenAI.VectorbaseEntry> Find(System.ReadOnlyMemory<float> vector, Azure.Projects.OpenAI.FindOptions options);
    }
}
