namespace Azure.AI.Inference
{
    public static partial class AIInferenceExtensions
    {
        public static Azure.AI.Inference.ChatCompletionsClient GetChatCompletionsClient(this System.ClientModel.Primitives.ClientConnectionProvider provider) { throw null; }
        public static Azure.AI.Inference.EmbeddingsClient GetEmbeddingsClient(this System.ClientModel.Primitives.ClientConnectionProvider provider) { throw null; }
    }
    public static partial class AIInferenceModelFactory
    {
        public static Azure.AI.Inference.ChatChoice ChatChoice(int index = 0, Azure.AI.Inference.CompletionsFinishReason? finishReason = default(Azure.AI.Inference.CompletionsFinishReason?), Azure.AI.Inference.ChatResponseMessage message = null) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsNamedToolChoice ChatCompletionsNamedToolChoice(Azure.AI.Inference.ChatCompletionsNamedToolChoiceType type = default(Azure.AI.Inference.ChatCompletionsNamedToolChoiceType), Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction function = null) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsToolCall ChatCompletionsToolCall(string id = null, Azure.AI.Inference.ChatCompletionsToolCallType type = default(Azure.AI.Inference.ChatCompletionsToolCallType), Azure.AI.Inference.FunctionCall function = null) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsToolDefinition ChatCompletionsToolDefinition(Azure.AI.Inference.ChatCompletionsToolDefinitionType type = default(Azure.AI.Inference.ChatCompletionsToolDefinitionType), Azure.AI.Inference.FunctionDefinition function = null) { throw null; }
        public static Azure.AI.Inference.ChatMessageTextContentItem ChatMessageTextContentItem(string text = null) { throw null; }
        public static Azure.AI.Inference.ChatRequestDeveloperMessage ChatRequestDeveloperMessage(string content = null) { throw null; }
        public static Azure.AI.Inference.ChatRequestSystemMessage ChatRequestSystemMessage(string content = null) { throw null; }
        public static Azure.AI.Inference.ChatRequestToolMessage ChatRequestToolMessage(string content = null, string toolCallId = null) { throw null; }
        public static Azure.AI.Inference.ChatResponseMessage ChatResponseMessage(Azure.AI.Inference.ChatRole role = default(Azure.AI.Inference.ChatRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Inference.ChatCompletionsToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Inference.CompletionsUsage CompletionsUsage(int completionTokens = 0, int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.Inference.EmbeddingItem EmbeddingItem(System.BinaryData embedding = null, int index = 0) { throw null; }
        public static Azure.AI.Inference.EmbeddingsResult EmbeddingsResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Inference.EmbeddingItem> data = null, Azure.AI.Inference.EmbeddingsUsage usage = null, string model = null) { throw null; }
        public static Azure.AI.Inference.EmbeddingsUsage EmbeddingsUsage(int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.Inference.ImageEmbeddingInput ImageEmbeddingInput(string image = null, string text = null) { throw null; }
        public static Azure.AI.Inference.ModelInfo ModelInfo(string modelName = null, Azure.AI.Inference.ModelType modelType = default(Azure.AI.Inference.ModelType), string modelProviderName = null) { throw null; }
        public static Azure.AI.Inference.StreamingChatChoiceUpdate StreamingChatChoiceUpdate(int index = 0, Azure.AI.Inference.CompletionsFinishReason? finishReason = default(Azure.AI.Inference.CompletionsFinishReason?), Azure.AI.Inference.StreamingChatResponseMessageUpdate delta = null) { throw null; }
        public static Azure.AI.Inference.StreamingChatCompletionsUpdate StreamingChatCompletionsUpdate(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), string model = null, System.Collections.Generic.IEnumerable<Azure.AI.Inference.StreamingChatChoiceUpdate> choices = null, Azure.AI.Inference.CompletionsUsage usage = null) { throw null; }
        public static Azure.AI.Inference.StreamingChatResponseMessageUpdate StreamingChatResponseMessageUpdate(Azure.AI.Inference.ChatRole? role = default(Azure.AI.Inference.ChatRole?), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Inference.StreamingChatResponseToolCallUpdate> toolCalls = null) { throw null; }
        public static Azure.AI.Inference.StreamingChatResponseToolCallUpdate StreamingChatResponseToolCallUpdate(string id = null, Azure.AI.Inference.FunctionCall function = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioContentFormat : System.IEquatable<Azure.AI.Inference.AudioContentFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioContentFormat(string value) { throw null; }
        public static Azure.AI.Inference.AudioContentFormat Mp3 { get { throw null; } }
        public static Azure.AI.Inference.AudioContentFormat Wav { get { throw null; } }
        public bool Equals(Azure.AI.Inference.AudioContentFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.AudioContentFormat left, Azure.AI.Inference.AudioContentFormat right) { throw null; }
        public static implicit operator Azure.AI.Inference.AudioContentFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.AudioContentFormat left, Azure.AI.Inference.AudioContentFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAIInferenceClientOptions : Azure.Core.ClientOptions
    {
        public AzureAIInferenceClientOptions(Azure.AI.Inference.AzureAIInferenceClientOptions.ServiceVersion version = Azure.AI.Inference.AzureAIInferenceClientOptions.ServiceVersion.V2024_05_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_05_01_Preview = 1,
        }
    }
    public partial class AzureAIInferenceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIInferenceContext() { }
        public static Azure.AI.Inference.AzureAIInferenceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ChatChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>
    {
        internal ChatChoice() { }
        public Azure.AI.Inference.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.Inference.ChatResponseMessage Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>
    {
        internal ChatCompletions() { }
        public string Content { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public Azure.AI.Inference.CompletionsFinishReason? FinishReason { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.Inference.ChatRole Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Inference.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
        public Azure.AI.Inference.CompletionsUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletions System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatCompletionsClient
    {
        protected ChatCompletionsClient() { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Inference.AzureAIInferenceClientOptions options) { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ChatCompletionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Inference.AzureAIInferenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Inference.ChatCompletions> Complete(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.ChatCompletions>> CompleteAsync(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Inference.StreamingResponse<Azure.AI.Inference.StreamingChatCompletionsUpdate> CompleteStreaming(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Inference.StreamingResponse<Azure.AI.Inference.StreamingChatCompletionsUpdate>> CompleteStreamingAsync(Azure.AI.Inference.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetModelInfo(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Inference.ModelInfo> GetModelInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelInfoAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.ModelInfo>> GetModelInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatCompletionsNamedToolChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoice>
    {
        public ChatCompletionsNamedToolChoice(Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction function) { }
        public Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction Function { get { throw null; } }
        public Azure.AI.Inference.ChatCompletionsNamedToolChoiceType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsNamedToolChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsNamedToolChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsNamedToolChoiceFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction>
    {
        public ChatCompletionsNamedToolChoiceFunction(string name) { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsNamedToolChoiceFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatCompletionsNamedToolChoiceType : System.IEquatable<Azure.AI.Inference.ChatCompletionsNamedToolChoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatCompletionsNamedToolChoiceType(string value) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsNamedToolChoiceType Function { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ChatCompletionsNamedToolChoiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ChatCompletionsNamedToolChoiceType left, Azure.AI.Inference.ChatCompletionsNamedToolChoiceType right) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatCompletionsNamedToolChoiceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ChatCompletionsNamedToolChoiceType left, Azure.AI.Inference.ChatCompletionsNamedToolChoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatCompletionsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>
    {
        public ChatCompletionsOptions() { }
        public ChatCompletionsOptions(System.Collections.Generic.IEnumerable<Azure.AI.Inference.ChatRequestMessage> messages) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ChatRequestMessage> Messages { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public Azure.AI.Inference.ChatCompletionsResponseFormat ResponseFormat { get { throw null; } set { } }
        public long? Seed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public Azure.AI.Inference.ChatCompletionsToolChoice ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ChatCompletionsToolDefinition> Tools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatCompletionsResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>
    {
        protected ChatCompletionsResponseFormat() { }
        public static Azure.AI.Inference.ChatCompletionsResponseFormat CreateJsonFormat() { throw null; }
        public static Azure.AI.Inference.ChatCompletionsResponseFormat CreateJsonFormat(string jsonSchemaFormatName, System.Collections.Generic.IDictionary<string, System.BinaryData> jsonSchema, string jsonSchemaFormatDescription = null, bool? jsonSchemaIsStrict = default(bool?)) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsResponseFormat CreateTextFormat() { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsResponseFormatJsonObject : Azure.AI.Inference.ChatCompletionsResponseFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject>
    {
        public ChatCompletionsResponseFormatJsonObject() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatJsonObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsResponseFormatText : Azure.AI.Inference.ChatCompletionsResponseFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>
    {
        public ChatCompletionsResponseFormatText() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormatText System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsResponseFormatText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsResponseFormatText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>
    {
        public ChatCompletionsToolCall(string id, Azure.AI.Inference.FunctionCall function) { }
        public string Arguments { get { throw null; } set { } }
        public Azure.AI.Inference.FunctionCall Function { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Inference.ChatCompletionsToolCallType Type { get { throw null; } }
        public static Azure.AI.Inference.ChatCompletionsToolCall CreateFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatCompletionsToolCallType : System.IEquatable<Azure.AI.Inference.ChatCompletionsToolCallType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatCompletionsToolCallType(string value) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsToolCallType Function { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ChatCompletionsToolCallType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ChatCompletionsToolCallType left, Azure.AI.Inference.ChatCompletionsToolCallType right) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolCallType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ChatCompletionsToolCallType left, Azure.AI.Inference.ChatCompletionsToolCallType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatCompletionsToolChoice
    {
        public static readonly Azure.AI.Inference.ChatCompletionsToolChoice Auto;
        public static readonly Azure.AI.Inference.ChatCompletionsToolChoice None;
        public static readonly Azure.AI.Inference.ChatCompletionsToolChoice Required;
        public ChatCompletionsToolChoice(Azure.AI.Inference.ChatCompletionsToolDefinition functionToolDefinition) { }
        public ChatCompletionsToolChoice(Azure.AI.Inference.FunctionDefinition functionDefinition) { }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolChoice (Azure.AI.Inference.ChatCompletionsToolDefinition functionToolDefinition) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolChoice (Azure.AI.Inference.FunctionDefinition functionDefinition) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatCompletionsToolChoicePreset : System.IEquatable<Azure.AI.Inference.ChatCompletionsToolChoicePreset>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatCompletionsToolChoicePreset(string value) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsToolChoicePreset Auto { get { throw null; } }
        public static Azure.AI.Inference.ChatCompletionsToolChoicePreset None { get { throw null; } }
        public static Azure.AI.Inference.ChatCompletionsToolChoicePreset Required { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ChatCompletionsToolChoicePreset other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ChatCompletionsToolChoicePreset left, Azure.AI.Inference.ChatCompletionsToolChoicePreset right) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolChoicePreset (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ChatCompletionsToolChoicePreset left, Azure.AI.Inference.ChatCompletionsToolChoicePreset right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatCompletionsToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>
    {
        public ChatCompletionsToolDefinition(Azure.AI.Inference.FunctionDefinition function) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Inference.FunctionDefinition Function { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.AI.Inference.ChatCompletionsToolDefinitionType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatCompletionsToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatCompletionsToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatCompletionsToolDefinitionType : System.IEquatable<Azure.AI.Inference.ChatCompletionsToolDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatCompletionsToolDefinitionType(string value) { throw null; }
        public static Azure.AI.Inference.ChatCompletionsToolDefinitionType Function { get { throw null; } }
        public bool Equals(Azure.AI.Inference.ChatCompletionsToolDefinitionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.ChatCompletionsToolDefinitionType left, Azure.AI.Inference.ChatCompletionsToolDefinitionType right) { throw null; }
        public static implicit operator Azure.AI.Inference.ChatCompletionsToolDefinitionType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.ChatCompletionsToolDefinitionType left, Azure.AI.Inference.ChatCompletionsToolDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatMessageAudioContentItem : Azure.AI.Inference.ChatMessageContentItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageAudioContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageAudioContentItem>
    {
        public ChatMessageAudioContentItem(System.BinaryData bytes, Azure.AI.Inference.AudioContentFormat audioFormat) { }
        public ChatMessageAudioContentItem(System.IO.Stream stream, Azure.AI.Inference.AudioContentFormat audioFormat) { }
        public ChatMessageAudioContentItem(string audioFilePath, Azure.AI.Inference.AudioContentFormat audioFormat) { }
        public ChatMessageAudioContentItem(System.Uri audioUri) { }
        Azure.AI.Inference.ChatMessageAudioContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageAudioContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageAudioContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatMessageAudioContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageAudioContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageAudioContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageAudioContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatMessageContentItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageContentItem>
    {
        protected ChatMessageContentItem() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public ChatMessageImageContentItem(string imageFilePath, string mimeType, Azure.AI.Inference.ChatMessageImageDetailLevel? detailLevel = default(Azure.AI.Inference.ChatMessageImageDetailLevel?)) { }
        public ChatMessageImageContentItem(System.Uri imageUri, Azure.AI.Inference.ChatMessageImageDetailLevel? detailLevel = default(Azure.AI.Inference.ChatMessageImageDetailLevel?)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ChatMessageInputAudio : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageInputAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageInputAudio>
    {
        public ChatMessageInputAudio(string data, Azure.AI.Inference.AudioContentFormat format) { }
        public string Data { get { throw null; } }
        public Azure.AI.Inference.AudioContentFormat Format { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static Azure.AI.Inference.ChatMessageInputAudio Load(string path, Azure.AI.Inference.AudioContentFormat format) { throw null; }
        Azure.AI.Inference.ChatMessageInputAudio System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageInputAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageInputAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatMessageInputAudio System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageInputAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageInputAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageInputAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatMessageTextContentItem : Azure.AI.Inference.ChatMessageContentItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageTextContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>
    {
        public ChatMessageTextContentItem(string text) { }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatMessageTextContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageTextContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatMessageTextContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatMessageTextContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatMessageTextContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestAssistantMessage : Azure.AI.Inference.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestAssistantMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>
    {
        public ChatRequestAssistantMessage(Azure.AI.Inference.ChatCompletions chatCompletions) { }
        public ChatRequestAssistantMessage(System.Collections.Generic.IEnumerable<Azure.AI.Inference.ChatCompletionsToolCall> toolCalls, string content = null) { }
        public ChatRequestAssistantMessage(string content) { }
        public string Content { get { throw null; } set { } }
        public string ParticipantName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestAssistantMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestAssistantMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestAssistantMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestDeveloperMessage : Azure.AI.Inference.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestDeveloperMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestDeveloperMessage>
    {
        public ChatRequestDeveloperMessage(string content) { }
        public string Content { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestDeveloperMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestDeveloperMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestDeveloperMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestDeveloperMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestDeveloperMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestDeveloperMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestDeveloperMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatRequestMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestMessage>
    {
        protected ChatRequestMessage() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestSystemMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestSystemMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestSystemMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ChatRequestSystemMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestSystemMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestSystemMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestSystemMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestToolMessage : Azure.AI.Inference.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatRequestToolMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ChatRequestToolMessage>
    {
        public ChatRequestToolMessage(string toolCallId) { }
        public ChatRequestToolMessage(string content, string toolCallId) { }
        public string Content { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.AI.Inference.ChatRole Developer { get { throw null; } }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.CompletionsUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.CompletionsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.CompletionsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.CompletionsUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.CompletionsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.CompletionsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.CompletionsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingEncodingFormat : System.IEquatable<Azure.AI.Inference.EmbeddingEncodingFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingEncodingFormat(string value) { throw null; }
        public static Azure.AI.Inference.EmbeddingEncodingFormat Base64 { get { throw null; } }
        public static Azure.AI.Inference.EmbeddingEncodingFormat Binary { get { throw null; } }
        public static Azure.AI.Inference.EmbeddingEncodingFormat Byte { get { throw null; } }
        public static Azure.AI.Inference.EmbeddingEncodingFormat SByte { get { throw null; } }
        public static Azure.AI.Inference.EmbeddingEncodingFormat Single { get { throw null; } }
        public static Azure.AI.Inference.EmbeddingEncodingFormat Ubinary { get { throw null; } }
        public bool Equals(Azure.AI.Inference.EmbeddingEncodingFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.EmbeddingEncodingFormat left, Azure.AI.Inference.EmbeddingEncodingFormat right) { throw null; }
        public static implicit operator Azure.AI.Inference.EmbeddingEncodingFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.EmbeddingEncodingFormat left, Azure.AI.Inference.EmbeddingEncodingFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingInputType : System.IEquatable<Azure.AI.Inference.EmbeddingInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingInputType(string value) { throw null; }
        public static Azure.AI.Inference.EmbeddingInputType Document { get { throw null; } }
        public static Azure.AI.Inference.EmbeddingInputType Query { get { throw null; } }
        public static Azure.AI.Inference.EmbeddingInputType Text { get { throw null; } }
        public bool Equals(Azure.AI.Inference.EmbeddingInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Inference.EmbeddingInputType left, Azure.AI.Inference.EmbeddingInputType right) { throw null; }
        public static implicit operator Azure.AI.Inference.EmbeddingInputType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Inference.EmbeddingInputType left, Azure.AI.Inference.EmbeddingInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmbeddingItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingItem>
    {
        internal EmbeddingItem() { }
        public System.BinaryData Embedding { get { throw null; } }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmbeddingsClient
    {
        protected EmbeddingsClient() { }
        public EmbeddingsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EmbeddingsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Inference.AzureAIInferenceClientOptions options) { }
        public EmbeddingsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public EmbeddingsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Inference.AzureAIInferenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Inference.EmbeddingsResult> Embed(Azure.AI.Inference.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Embed(Azure.Core.RequestContent content, string extraParams = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.EmbeddingsResult>> EmbedAsync(Azure.AI.Inference.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EmbedAsync(Azure.Core.RequestContent content, string extraParams = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelInfo(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Inference.ModelInfo> GetModelInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelInfoAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.ModelInfo>> GetModelInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmbeddingsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsOptions>
    {
        public EmbeddingsOptions(System.Collections.Generic.IEnumerable<string> input) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? Dimensions { get { throw null; } set { } }
        public Azure.AI.Inference.EmbeddingEncodingFormat? EncodingFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Input { get { throw null; } }
        public Azure.AI.Inference.EmbeddingInputType? InputType { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmbeddingsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsResult>
    {
        internal EmbeddingsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Inference.EmbeddingItem> Data { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.Inference.EmbeddingsUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmbeddingsUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsUsage>
    {
        internal EmbeddingsUsage() { }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingsUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.EmbeddingsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.EmbeddingsUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.EmbeddingsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionCall>
    {
        public FunctionCall(string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.FunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.FunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.FunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.FunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageEmbeddingInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ImageEmbeddingInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingInput>
    {
        public ImageEmbeddingInput(string image) { }
        public string Image { get { throw null; } }
        public string Text { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static Azure.AI.Inference.ImageEmbeddingInput Load(string imageFilePath, string imageFormat, string text = null) { throw null; }
        Azure.AI.Inference.ImageEmbeddingInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ImageEmbeddingInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ImageEmbeddingInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ImageEmbeddingInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageEmbeddingsClient
    {
        protected ImageEmbeddingsClient() { }
        public ImageEmbeddingsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ImageEmbeddingsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Inference.AzureAIInferenceClientOptions options) { }
        public ImageEmbeddingsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ImageEmbeddingsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Inference.AzureAIInferenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Inference.EmbeddingsResult> Embed(Azure.AI.Inference.ImageEmbeddingsOptions imageEmbeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.EmbeddingsResult>> EmbedAsync(Azure.AI.Inference.ImageEmbeddingsOptions imageEmbeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetModelInfo(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Inference.ModelInfo> GetModelInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelInfoAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Inference.ModelInfo>> GetModelInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageEmbeddingsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ImageEmbeddingsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingsOptions>
    {
        public ImageEmbeddingsOptions(System.Collections.Generic.IEnumerable<Azure.AI.Inference.ImageEmbeddingInput> input) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? Dimensions { get { throw null; } set { } }
        public Azure.AI.Inference.EmbeddingEncodingFormat? EncodingFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Inference.ImageEmbeddingInput> Input { get { throw null; } }
        public Azure.AI.Inference.EmbeddingInputType? InputType { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ImageEmbeddingsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ImageEmbeddingsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ImageEmbeddingsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.ImageEmbeddingsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ImageEmbeddingsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ModelInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.ModelInfo>
    {
        internal ModelInfo() { }
        public string ModelName { get { throw null; } }
        public string ModelProviderName { get { throw null; } }
        public Azure.AI.Inference.ModelType ModelType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.AI.Inference.ModelType ChatCompletion { get { throw null; } }
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
        public Azure.AI.Inference.StreamingChatResponseMessageUpdate Delta { get { throw null; } }
        public Azure.AI.Inference.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatChoiceUpdate System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatChoiceUpdate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatChoiceUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingChatCompletionsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>
    {
        internal StreamingChatCompletionsUpdate() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Inference.StreamingChatChoiceUpdate> Choices { get { throw null; } }
        public string ContentUpdate { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public Azure.AI.Inference.CompletionsFinishReason? FinishReason { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.Inference.ChatRole? Role { get { throw null; } }
        public Azure.AI.Inference.StreamingChatResponseToolCallUpdate ToolCallUpdate { get { throw null; } }
        public Azure.AI.Inference.CompletionsUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatCompletionsUpdate System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatCompletionsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatCompletionsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingChatResponseMessageUpdate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatResponseMessageUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseMessageUpdate>
    {
        internal StreamingChatResponseMessageUpdate() { }
        public string Content { get { throw null; } }
        public Azure.AI.Inference.ChatRole? Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Inference.StreamingChatResponseToolCallUpdate> ToolCalls { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatResponseMessageUpdate System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatResponseMessageUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatResponseMessageUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatResponseMessageUpdate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseMessageUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseMessageUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseMessageUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingChatResponseToolCallUpdate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatResponseToolCallUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseToolCallUpdate>
    {
        internal StreamingChatResponseToolCallUpdate() { }
        public Azure.AI.Inference.FunctionCall Function { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatResponseToolCallUpdate System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatResponseToolCallUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.StreamingChatResponseToolCallUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Inference.StreamingChatResponseToolCallUpdate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseToolCallUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseToolCallUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Inference.StreamingChatResponseToolCallUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Microsoft.Extensions.Azure
{
    public static partial class AIInferenceClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ChatCompletionsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddChatCompletionsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ChatCompletionsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddChatCompletionsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ChatCompletionsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddChatCompletionsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.EmbeddingsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddEmbeddingsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.EmbeddingsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddEmbeddingsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.EmbeddingsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddEmbeddingsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ImageEmbeddingsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddImageEmbeddingsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ImageEmbeddingsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddImageEmbeddingsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Inference.ImageEmbeddingsClient, Azure.AI.Inference.AzureAIInferenceClientOptions> AddImageEmbeddingsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
