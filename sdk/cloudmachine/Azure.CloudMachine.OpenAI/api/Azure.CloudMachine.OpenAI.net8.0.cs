namespace Azure.CloudMachine.OpenAI
{
    public enum AIModelKind
    {
        Chat = 0,
        Embedding = 1,
    }
    public static partial class AzureOpenAIExtensions
    {
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, OpenAI.Chat.ChatCompletion completion) { }
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, System.Collections.Generic.IEnumerable<Azure.CloudMachine.OpenAI.VectorbaseEntry> entries) { }
        public static void Add(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages, System.Collections.Generic.IEnumerable<OpenAI.Chat.ToolChatMessage> toolCallResults) { }
        public static string AsText(this OpenAI.Chat.ChatCompletion completion) { throw null; }
        public static string AsText(this OpenAI.Chat.ChatMessageContent content) { throw null; }
        public static string AsText(this System.ClientModel.ClientResult<OpenAI.Chat.ChatCompletion> completionResult) { throw null; }
        public static OpenAI.Chat.ChatClient GetOpenAIChatClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
        public static OpenAI.Embeddings.EmbeddingClient GetOpenAIEmbeddingsClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
        public static void Trim(this System.Collections.Generic.List<OpenAI.Chat.ChatMessage> messages) { }
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
        public static implicit operator OpenAI.Chat.ChatCompletionOptions (Azure.CloudMachine.OpenAI.ChatTools tools) { throw null; }
    }
    public partial class EmbeddingsVectorbase
    {
        public EmbeddingsVectorbase(OpenAI.Embeddings.EmbeddingClient client, Azure.CloudMachine.OpenAI.VectorbaseStore? store = null, int factChunkSize = 1000) { }
        public void Add(System.BinaryData data) { }
        public void Add(string text) { }
        public System.Collections.Generic.IEnumerable<Azure.CloudMachine.OpenAI.VectorbaseEntry> Find(string text, Azure.CloudMachine.OpenAI.FindOptions? options = null) { throw null; }
    }
    public partial class FindOptions
    {
        public FindOptions() { }
        public int MaxEntries { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
    }
    public partial class OpenAIModelFeature : Azure.CloudMachine.Core.CloudMachineFeature
    {
        public OpenAIModelFeature(string model, string modelVersion, Azure.CloudMachine.OpenAI.AIModelKind kind = Azure.CloudMachine.OpenAI.AIModelKind.Chat) { }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        protected override void EmitConnections(Azure.Core.ConnectionCollection connections, string cmId) { }
        protected override void EmitFeatures(Azure.CloudMachine.Core.FeatureCollection features, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure cm) { throw null; }
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
        public abstract int Add(Azure.CloudMachine.OpenAI.VectorbaseEntry entry);
        public abstract void Add(System.Collections.Generic.IReadOnlyList<Azure.CloudMachine.OpenAI.VectorbaseEntry> entry);
        public static float CosineSimilarity(System.ReadOnlySpan<float> x, System.ReadOnlySpan<float> y) { throw null; }
        public abstract System.Collections.Generic.IEnumerable<Azure.CloudMachine.OpenAI.VectorbaseEntry> Find(System.ReadOnlyMemory<float> vector, Azure.CloudMachine.OpenAI.FindOptions options);
    }
}
