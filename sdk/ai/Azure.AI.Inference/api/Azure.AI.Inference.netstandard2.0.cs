namespace Azure.AI.Inference
{
    public static partial class AIInferenceModelFactory
    {
        public static Azure.AI.Inference.ChatChoice ChatChoice(int index = 0, Azure.AI.Inference.CompletionsFinishReason? finishReason = default(Azure.AI.Inference.CompletionsFinishReason?), Azure.AI.Inference.ChatResponseMessage message = null) { throw null; }
        public static Azure.AI.Inference.ChatCompletions ChatCompletions(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), string model = null, Azure.AI.Inference.CompletionsUsage usage = null, System.Collections.Generic.IEnumerable<Azure.AI.Inference.ChatChoice> choices = null) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsFunctionToolDefinition ChatCompletionsFunctionToolDefinition(Azure.AI.Inference.FunctionDefinition function = null) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection ChatCompletionsNamedFunctionToolSelection(Azure.AI.Inference.ChatCompletionsFunctionToolSelection function = null) { throw null; }
        public static Azure.AI.Inference.ChatMessageTextContentItem ChatMessageTextContentItem(string text = null) { throw null; }
        public static Azure.AI.Inference.ChatRequestSystemMessage ChatRequestSystemMessage(string content = null) { throw null; }
        public static Azure.AI.Inference.ChatRequestToolMessage ChatRequestToolMessage(string content = null, string toolCallId = null) { throw null; }
        public static Azure.AI.Inference.ChatResponseMessage ChatResponseMessage(Azure.AI.Inference.ChatRole role = default(Azure.AI.Inference.ChatRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Inference.ChatCompletionsToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Inference.CompletionsUsage CompletionsUsage(int completionTokens = 0, int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.Inference.ModelInfo ModelInfo(string modelName = null, Azure.AI.Inference.ModelType modelType = default(Azure.AI.Inference.ModelType), string modelProviderName = null) { throw null; }
        public static Azure.AI.Inference.StreamingChatChoiceUpdate StreamingChatChoiceUpdate(int index = 0, Azure.AI.Inference.CompletionsFinishReason? finishReason = default(Azure.AI.Inference.CompletionsFinishReason?), Azure.AI.Inference.ChatResponseMessage delta = null) { throw null; }
        public static Azure.AI.Inference.StreamingChatCompletionsUpdate StreamingChatCompletionsUpdate(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), string model = null, Azure.AI.Inference.CompletionsUsage usage = null, System.Collections.Generic.IEnumerable<Azure.AI.Inference.StreamingChatChoiceUpdate> choices = null) { throw null; }
    }
    public partial class ChatChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>
    {
        internal ChatChoice() { }
        public Azure.AI.Inference.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.Inference.ChatResponseMessage Message { get { throw null; } }
        Azure.AI.Inference.ChatChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>
    {
        internal ChatCompletions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Inference.ChatChoice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.Inference.CompletionsUsage Usage { get { throw null; } }
        Azure.AI.Inference.ChatCompletions System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsClient
    {
        protected ChatCompletionsClient() { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Inference.ChatCompletionsClientOptions options) { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Inference.ChatCompletionsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Inference.ChatCompletions> Complete(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, Azure.AI.Inference.ExtraParameters? extraParams = default(Azure.AI.Inference.ExtraParameters?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.ChatCompletions>> CompleteAsync(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, Azure.AI.Inference.ExtraParameters? extraParams = default(Azure.AI.Inference.ExtraParameters?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Inference.StreamingResponse<Azure.AI.Inference.StreamingChatCompletionsUpdate> CompleteStreaming(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Inference.StreamingResponse<Azure.AI.Inference.StreamingChatCompletionsUpdate>> CompleteStreamingAsync(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetModelInfo(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Inference.ModelInfo> GetModelInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelInfoAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.ModelInfo>> GetModelInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatCompletionsClientOptions : Azure.Core.ClientOptions
    {
        public ChatCompletionsClientOptions(Azure.AI.Inference.ChatCompletionsClientOptions.ServiceVersion version = Azure.AI.Inference.ChatCompletionsClientOptions.ServiceVersion.V2024_05_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_05_01_Preview = 1,
        }
    }
    public partial class ChatCompletionsFunctionToolCall : Azure.AI.Inference.ChatCompletionsToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolCall>
    {
        public ChatCompletionsFunctionToolCall(string id, Azure.AI.Inference.FunctionCall function) : base (default(string)) { }
        public ChatCompletionsFunctionToolCall(string id, string name, string arguments) : base (default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.AI.Inference.ChatCompletionsFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsFunctionToolDefinition : Azure.AI.Inference.ChatCompletionsToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolDefinition>
    {
        public ChatCompletionsFunctionToolDefinition() { }
        public ChatCompletionsFunctionToolDefinition(Azure.AI.Inference.FunctionDefinition function) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Inference.FunctionDefinition Function { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        Azure.AI.Inference.ChatCompletionsFunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsFunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsFunctionToolSelection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolSelection>
    {
        public ChatCompletionsFunctionToolSelection(string name) { }
        public string Name { get { throw null; } }
        Azure.AI.Inference.ChatCompletionsFunctionToolSelection System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsFunctionToolSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsFunctionToolSelection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsFunctionToolSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsNamedFunctionToolSelection : Azure.AI.Inference.ChatCompletionsNamedToolSelection, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection>
    {
        public ChatCompletionsNamedFunctionToolSelection(Azure.AI.Inference.ChatCompletionsFunctionToolSelection function) { }
        public Azure.AI.Inference.ChatCompletionsFunctionToolSelection Function { get { throw null; } }
        Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedFunctionToolSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatCompletionsNamedToolSelection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolSelection>
    {
        protected ChatCompletionsNamedToolSelection() { }
        Azure.AI.Inference.ChatCompletionsNamedToolSelection System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsNamedToolSelection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>
    {
        public ChatCompletionsOptions() { }
        public ChatCompletionsOptions(System.Collections.Generic.IEnumerable<Azure.AI.Inference.ChatRequestMessage> messages) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ChatRequestMessage> Messages { get { throw null; } }
        public string Model { get { throw null; } set { } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public Azure.AI.Inference.ChatCompletionsResponseFormat ResponseFormat { get { throw null; } set { } }
        public long? Seed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public Azure.AI.Inference.ChatCompletionsToolChoice ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ChatCompletionsToolDefinition> Tools { get { throw null; } }
        Azure.AI.Inference.ChatCompletionsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatCompletionsResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>
    {
        protected ChatCompletionsResponseFormat() { }
        Azure.AI.Inference.ChatCompletionsResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsResponseFormatJSON : Azure.AI.Inference.ChatCompletionsResponseFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatJSON>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJSON>
    {
        public ChatCompletionsResponseFormatJSON() { }
        Azure.AI.Inference.ChatCompletionsResponseFormatJSON System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatJSON>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatJSON>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormatJSON System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJSON>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJSON>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJSON>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsResponseFormatText : Azure.AI.Inference.ChatCompletionsResponseFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>
    {
        public ChatCompletionsResponseFormatText() { }
        Azure.AI.Inference.ChatCompletionsResponseFormatText System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormatText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatCompletionsToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>
    {
        protected ChatCompletionsToolCall(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.AI.Inference.ChatCompletionsToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsToolChoice
    {
        public static readonly Azure.AI.Inference.ChatCompletionsToolChoice Auto;
        public static readonly Azure.AI.Inference.ChatCompletionsToolChoice None;
        public static readonly Azure.AI.Inference.ChatCompletionsToolChoice Required;
        public ChatCompletionsToolChoice(Azure.AI.Inference.ChatCompletionsFunctionToolDefinition functionToolDefinition) { }
        public ChatCompletionsToolChoice(Azure.AI.Inference.FunctionDefinition functionDefinition) { }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolChoice (Azure.AI.Inference.ChatCompletionsFunctionToolDefinition functionToolDefinition) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolChoice (Azure.AI.Inference.FunctionDefinition functionDefinition) { throw null; }
    }
    public abstract partial class ChatCompletionsToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>
    {
        protected ChatCompletionsToolDefinition() { }
        Azure.AI.Inference.ChatCompletionsToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatCompletionsToolSelectionPreset : System.IEquatable<Azure.AI.Inference.ChatCompletionsToolSelectionPreset>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatCompletionsToolSelectionPreset(string value) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsToolSelectionPreset Auto { get { throw null; } }
        public static Azure.AI.Inference.ChatCompletionsToolSelectionPreset None { get { throw null; } }
        public static Azure.AI.Inference.ChatCompletionsToolSelectionPreset Required { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ChatCompletionsToolSelectionPreset other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ChatCompletionsToolSelectionPreset left, Azure.AI.Inference.ChatCompletionsToolSelectionPreset right) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolSelectionPreset (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ChatCompletionsToolSelectionPreset left, Azure.AI.Inference.ChatCompletionsToolSelectionPreset right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ChatMessageContentItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageContentItem>
    {
        protected ChatMessageContentItem() { }
        Azure.AI.Inference.ChatMessageContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatMessageContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatMessageImageContentItem : Azure.AI.Inference.ChatMessageContentItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageImageContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageImageContentItem>
    {
        public ChatMessageImageContentItem(System.BinaryData bytes, string mimeType, Azure.AI.Inference.ChatMessageImageDetailLevel? detailLevel = default(Azure.AI.Inference.ChatMessageImageDetailLevel?)) { }
        public ChatMessageImageContentItem(System.IO.Stream stream, string mimeType, Azure.AI.Inference.ChatMessageImageDetailLevel? detailLevel = default(Azure.AI.Inference.ChatMessageImageDetailLevel?)) { }
        public ChatMessageImageContentItem(System.Uri imageUri, Azure.AI.Inference.ChatMessageImageDetailLevel? detailLevel = default(Azure.AI.Inference.ChatMessageImageDetailLevel?)) { }
        Azure.AI.Inference.ChatMessageImageContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageImageContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageImageContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatMessageImageContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageImageContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageImageContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageImageContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatMessageImageDetailLevel : System.IEquatable<Azure.AI.Inference.ChatMessageImageDetailLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatMessageImageDetailLevel(string value) { throw null; }
        public static Azure.AI.Inference.ChatMessageImageDetailLevel Auto { get { throw null; } }
        public static Azure.AI.Inference.ChatMessageImageDetailLevel High { get { throw null; } }
        public static Azure.AI.Inference.ChatMessageImageDetailLevel Low { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ChatMessageImageDetailLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ChatMessageImageDetailLevel left, Azure.AI.Inference.ChatMessageImageDetailLevel right) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatMessageImageDetailLevel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ChatMessageImageDetailLevel left, Azure.AI.Inference.ChatMessageImageDetailLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatMessageTextContentItem : Azure.AI.Inference.ChatMessageContentItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageTextContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>
    {
        public ChatMessageTextContentItem(string text) { }
        public string Text { get { throw null; } }
        Azure.AI.Inference.ChatMessageTextContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageTextContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageTextContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatMessageTextContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestAssistantMessage : Azure.AI.Inference.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestAssistantMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>
    {
        public ChatRequestAssistantMessage() { }
        public ChatRequestAssistantMessage(Azure.AI.Inference.ChatResponseMessage responseMessage) { }
        public string Content { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Inference.ChatRequestAssistantMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestAssistantMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatRequestMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestMessage>
    {
        protected ChatRequestMessage() { }
        Azure.AI.Inference.ChatRequestMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestSystemMessage : Azure.AI.Inference.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestSystemMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestSystemMessage>
    {
        public ChatRequestSystemMessage(string content) { }
        public string Content { get { throw null; } }
        Azure.AI.Inference.ChatRequestSystemMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestSystemMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestSystemMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestSystemMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestSystemMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestSystemMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestSystemMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestToolMessage : Azure.AI.Inference.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestToolMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestToolMessage>
    {
        public ChatRequestToolMessage(string content, string toolCallId) { }
        public string Content { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        Azure.AI.Inference.ChatRequestToolMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestToolMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestToolMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestToolMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestToolMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestToolMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestToolMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestUserMessage : Azure.AI.Inference.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestUserMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestUserMessage>
    {
        public ChatRequestUserMessage(params Azure.AI.Inference.ChatMessageContentItem[] content) { }
        public ChatRequestUserMessage(System.Collections.Generic.IEnumerable<Azure.AI.Inference.ChatMessageContentItem> content) { }
        public ChatRequestUserMessage(string content) { }
        public string Content { get { throw null; } protected set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ChatMessageContentItem> MultimodalContentItems { get { throw null; } }
        Azure.AI.Inference.ChatRequestUserMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestUserMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestUserMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestUserMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestUserMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestUserMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestUserMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatResponseMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatResponseMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatResponseMessage>
    {
        internal ChatResponseMessage() { }
        public string Content { get { throw null; } }
        public Azure.AI.Inference.ChatRole Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Inference.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Inference.ChatResponseMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatResponseMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatResponseMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatResponseMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatResponseMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatResponseMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatResponseMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatRole : System.IEquatable<Azure.AI.Inference.ChatRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatRole(string value) { throw null; }
        public static Azure.AI.Inference.ChatRole Assistant { get { throw null; } }
        public static Azure.AI.Inference.ChatRole System { get { throw null; } }
        public static Azure.AI.Inference.ChatRole Tool { get { throw null; } }
        public static Azure.AI.Inference.ChatRole User { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ChatRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ChatRole left, Azure.AI.Inference.ChatRole right) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ChatRole left, Azure.AI.Inference.ChatRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompletionsFinishReason : System.IEquatable<Azure.AI.Inference.CompletionsFinishReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompletionsFinishReason(string value) { throw null; }
        public static Azure.AI.Inference.CompletionsFinishReason ContentFiltered { get { throw null; } }
        public static Azure.AI.Inference.CompletionsFinishReason Stopped { get { throw null; } }
        public static Azure.AI.Inference.CompletionsFinishReason TokenLimitReached { get { throw null; } }
        public static Azure.AI.Inference.CompletionsFinishReason ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.Inference.CompletionsFinishReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.CompletionsFinishReason left, Azure.AI.Inference.CompletionsFinishReason right) { throw null; }
        public static implicit operator Azure.AI.Inference.CompletionsFinishReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.CompletionsFinishReason left, Azure.AI.Inference.CompletionsFinishReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CompletionsUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.CompletionsUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.CompletionsUsage>
    {
        internal CompletionsUsage() { }
        public int CompletionTokens { get { throw null; } }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        Azure.AI.Inference.CompletionsUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.CompletionsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.CompletionsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.CompletionsUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.CompletionsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.CompletionsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.CompletionsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtraParameters : System.IEquatable<Azure.AI.Inference.ExtraParameters>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtraParameters(string value) { throw null; }
        public static Azure.AI.Inference.ExtraParameters Drop { get { throw null; } }
        public static Azure.AI.Inference.ExtraParameters Error { get { throw null; } }
        public static Azure.AI.Inference.ExtraParameters PassThrough { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ExtraParameters other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ExtraParameters left, Azure.AI.Inference.ExtraParameters right) { throw null; }
        public static implicit operator Azure.AI.Inference.ExtraParameters (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ExtraParameters left, Azure.AI.Inference.ExtraParameters right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionCall>
    {
        public FunctionCall(string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.AI.Inference.FunctionCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.FunctionCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionDefinition>
    {
        public static Azure.AI.Inference.FunctionDefinition Auto;
        public static Azure.AI.Inference.FunctionDefinition None;
        public static Azure.AI.Inference.FunctionDefinition Required;
        public FunctionDefinition() { }
        public FunctionDefinition(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        Azure.AI.Inference.FunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.FunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ModelInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ModelInfo>
    {
        internal ModelInfo() { }
        public string ModelName { get { throw null; } }
        public string ModelProviderName { get { throw null; } }
        public Azure.AI.Inference.ModelType ModelType { get { throw null; } }
        Azure.AI.Inference.ModelInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ModelInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ModelInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ModelInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ModelInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ModelInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ModelInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelType : System.IEquatable<Azure.AI.Inference.ModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelType(string value) { throw null; }
        public static Azure.AI.Inference.ModelType AudioGeneration { get { throw null; } }
        public static Azure.AI.Inference.ModelType Chat { get { throw null; } }
        public static Azure.AI.Inference.ModelType Embeddings { get { throw null; } }
        public static Azure.AI.Inference.ModelType ImageEmbeddings { get { throw null; } }
        public static Azure.AI.Inference.ModelType ImageGeneration { get { throw null; } }
        public static Azure.AI.Inference.ModelType TextGeneration { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ModelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ModelType left, Azure.AI.Inference.ModelType right) { throw null; }
        public static implicit operator Azure.AI.Inference.ModelType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ModelType left, Azure.AI.Inference.ModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingChatChoiceUpdate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatChoiceUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatChoiceUpdate>
    {
        internal StreamingChatChoiceUpdate() { }
        public Azure.AI.Inference.ChatResponseMessage Delta { get { throw null; } }
        public Azure.AI.Inference.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        Azure.AI.Inference.StreamingChatChoiceUpdate System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatChoiceUpdate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingChatCompletionsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>
    {
        internal StreamingChatCompletionsUpdate() { }
        public string AuthorName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Inference.StreamingChatChoiceUpdate> Choices { get { throw null; } }
        public string ContentUpdate { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public Azure.AI.Inference.CompletionsFinishReason? FinishReason { get { throw null; } }
        public string FunctionArgumentsUpdate { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.Inference.ChatRole? Role { get { throw null; } }
        public Azure.AI.Inference.StreamingToolCallUpdate ToolCallUpdate { get { throw null; } }
        public Azure.AI.Inference.CompletionsUsage Usage { get { throw null; } }
        Azure.AI.Inference.StreamingChatCompletionsUpdate System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatCompletionsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingFunctionToolCallUpdate : Azure.AI.Inference.StreamingToolCallUpdate
    {
        internal StreamingFunctionToolCallUpdate() { }
        public string ArgumentsUpdate { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class StreamingResponse<T> : System.Collections.Generic.IAsyncEnumerable<T>, System.IDisposable
    {
        internal StreamingResponse() { }
        public static Azure.AI.Inference.StreamingResponse<T> CreateFromResponse(Azure.Response response, System.Func<Azure.Response, System.Collections.Generic.IAsyncEnumerable<T>> asyncEnumerableProcessor) { throw null; }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public System.Collections.Generic.IAsyncEnumerable<T> EnumerateValues() { throw null; }
        public Azure.Response GetRawResponse() { throw null; }
        System.Collections.Generic.IAsyncEnumerator<T> System.Collections.Generic.IAsyncEnumerable<T>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public abstract partial class StreamingToolCallUpdate
    {
        internal StreamingToolCallUpdate() { }
        public string Id { get { throw null; } }
        public int ToolCallIndex { get { throw null; } }
    }
}
namespace Azure.AI.Inference.Telemetry
{
    public partial class OpenTelemetryConstants
    {
        public const string ActivityName = "Azure.AI.Inference.ChatCompletionsClient";
        public const string EnvironmentVariableSwitchName = "OPENAI_EXPERIMENTAL_ENABLE_OPEN_TELEMETRY";
        public const string EnvironmentVariableTraceContents = "AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED";
        public OpenTelemetryConstants() { }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIInferenceClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ChatCompletionsClient, Azure.AI.Inference.ChatCompletionsClientOptions> AddChatCompletionsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ChatCompletionsClient, Azure.AI.Inference.ChatCompletionsClientOptions> AddChatCompletionsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ChatCompletionsClient, Azure.AI.Inference.ChatCompletionsClientOptions> AddChatCompletionsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
