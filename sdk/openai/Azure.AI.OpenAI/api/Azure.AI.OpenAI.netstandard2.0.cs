namespace Azure.AI.OpenAI
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureOpenAIAudience : System.IEquatable<Azure.AI.OpenAI.AzureOpenAIAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureOpenAIAudience(string value) { throw null; }
        public static Azure.AI.OpenAI.AzureOpenAIAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.OpenAI.AzureOpenAIAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AzureOpenAIAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AzureOpenAIAudience left, Azure.AI.OpenAI.AzureOpenAIAudience right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AzureOpenAIAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AzureOpenAIAudience left, Azure.AI.OpenAI.AzureOpenAIAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureOpenAIClient : OpenAI.OpenAIClient
    {
        protected AzureOpenAIClient() { }
        protected AzureOpenAIClient(System.ClientModel.Primitives.ClientPipeline pipeline, System.Uri endpoint, Azure.AI.OpenAI.AzureOpenAIClientOptions options) { }
        public AzureOpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AzureOpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.OpenAI.AzureOpenAIClientOptions options) { }
        public AzureOpenAIClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential) { }
        public AzureOpenAIClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential, Azure.AI.OpenAI.AzureOpenAIClientOptions options) { }
        public override OpenAI.Assistants.AssistantClient GetAssistantClient() { throw null; }
        public override OpenAI.Audio.AudioClient GetAudioClient(string deploymentName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Batch.BatchClient GetBatchClient() { throw null; }
        public OpenAI.Batch.BatchClient GetBatchClient(string deploymentName) { throw null; }
        public override OpenAI.Chat.ChatClient GetChatClient(string deploymentName) { throw null; }
        public override OpenAI.Embeddings.EmbeddingClient GetEmbeddingClient(string deploymentName) { throw null; }
        public override OpenAI.FineTuning.FineTuningClient GetFineTuningClient() { throw null; }
        public override OpenAI.Images.ImageClient GetImageClient(string deploymentName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Moderations.ModerationClient GetModerationClient(string _) { throw null; }
        public override OpenAI.Files.OpenAIFileClient GetOpenAIFileClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Models.OpenAIModelClient GetOpenAIModelClient() { throw null; }
        public override OpenAI.RealtimeConversation.RealtimeConversationClient GetRealtimeConversationClient(string deploymentName) { throw null; }
        public override OpenAI.VectorStores.VectorStoreClient GetVectorStoreClient() { throw null; }
    }
    public partial class AzureOpenAIClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public AzureOpenAIClientOptions(Azure.AI.OpenAI.AzureOpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.AzureOpenAIClientOptions.ServiceVersion.V2024_08_01_Preview) { }
        public Azure.AI.OpenAI.AzureOpenAIAudience? Audience { get { throw null; } set { } }
        public string UserAgentApplicationId { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2024_06_01 = 0,
            V2024_08_01_Preview = 1,
            V2024_10_01_Preview = 3,
        }
    }
    public partial class ContentFilterBlocklistResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterBlocklistResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistResult>
    {
        internal ContentFilterBlocklistResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, bool> BlocklistFilterStatuses { get { throw null; } }
        public bool Filtered { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterBlocklistResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterBlocklistResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterBlocklistResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterBlocklistResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterDetectionResult>
    {
        internal ContentFilterDetectionResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterProtectedMaterialCitationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult>
    {
        internal ContentFilterProtectedMaterialCitationResult() { }
        public string License { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterProtectedMaterialResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>
    {
        internal ContentFilterProtectedMaterialResult() { }
        public Azure.AI.OpenAI.ContentFilterProtectedMaterialCitationResult Citation { get { throw null; } }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentFilterSeverity : System.IEquatable<Azure.AI.OpenAI.ContentFilterSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentFilterSeverity(string value) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterSeverity High { get { throw null; } }
        public static Azure.AI.OpenAI.ContentFilterSeverity Low { get { throw null; } }
        public static Azure.AI.OpenAI.ContentFilterSeverity Medium { get { throw null; } }
        public static Azure.AI.OpenAI.ContentFilterSeverity Safe { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ContentFilterSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ContentFilterSeverity left, Azure.AI.OpenAI.ContentFilterSeverity right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ContentFilterSeverity (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ContentFilterSeverity left, Azure.AI.OpenAI.ContentFilterSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentFilterSeverityResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterSeverityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterSeverityResult>
    {
        internal ContentFilterSeverityResult() { }
        public bool Filtered { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverity Severity { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterSeverityResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterSeverityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterSeverityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterSeverityResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterSeverityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterSeverityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterSeverityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequestContentFilterResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.RequestContentFilterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestContentFilterResult>
    {
        internal RequestContentFilterResult() { }
        public Azure.AI.OpenAI.ContentFilterBlocklistResult CustomBlocklists { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult IndirectAttack { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Violence { get { throw null; } }
        Azure.AI.OpenAI.RequestContentFilterResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.RequestContentFilterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.RequestContentFilterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.RequestContentFilterResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestContentFilterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestContentFilterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestContentFilterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequestImageContentFilterResult : Azure.AI.OpenAI.ResponseImageContentFilterResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.RequestImageContentFilterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestImageContentFilterResult>
    {
        internal RequestImageContentFilterResult() { }
        public Azure.AI.OpenAI.ContentFilterBlocklistResult CustomBlocklists { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        Azure.AI.OpenAI.RequestImageContentFilterResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.RequestImageContentFilterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.RequestImageContentFilterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.RequestImageContentFilterResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestImageContentFilterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestImageContentFilterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.RequestImageContentFilterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseContentFilterResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ResponseContentFilterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseContentFilterResult>
    {
        internal ResponseContentFilterResult() { }
        public Azure.AI.OpenAI.ContentFilterBlocklistResult CustomBlocklists { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterProtectedMaterialResult ProtectedMaterialCode { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult ProtectedMaterialText { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ResponseContentFilterResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ResponseContentFilterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ResponseContentFilterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ResponseContentFilterResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseContentFilterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseContentFilterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseContentFilterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseImageContentFilterResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ResponseImageContentFilterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseImageContentFilterResult>
    {
        internal ResponseImageContentFilterResult() { }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ResponseImageContentFilterResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ResponseImageContentFilterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ResponseImageContentFilterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ResponseImageContentFilterResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseImageContentFilterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseImageContentFilterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ResponseImageContentFilterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.AI.OpenAI.Chat
{
    public static partial class AzureChatExtensions
    {
        public static void AddDataSource(this OpenAI.Chat.ChatCompletionOptions options, Azure.AI.OpenAI.Chat.ChatDataSource dataSource) { }
        public static System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Chat.ChatDataSource> GetDataSources(this OpenAI.Chat.ChatCompletionOptions options) { throw null; }
        public static Azure.AI.OpenAI.Chat.ChatMessageContext GetMessageContext(this OpenAI.Chat.ChatCompletion chatCompletion) { throw null; }
        public static Azure.AI.OpenAI.Chat.ChatMessageContext GetMessageContext(this OpenAI.Chat.StreamingChatCompletionUpdate chatUpdate) { throw null; }
        public static Azure.AI.OpenAI.RequestContentFilterResult GetRequestContentFilterResult(this OpenAI.Chat.ChatCompletion chatCompletion) { throw null; }
        public static Azure.AI.OpenAI.RequestContentFilterResult GetRequestContentFilterResult(this OpenAI.Chat.StreamingChatCompletionUpdate chatUpdate) { throw null; }
        public static Azure.AI.OpenAI.ResponseContentFilterResult GetResponseContentFilterResult(this OpenAI.Chat.ChatCompletion chatCompletion) { throw null; }
        public static Azure.AI.OpenAI.ResponseContentFilterResult GetResponseContentFilterResult(this OpenAI.Chat.StreamingChatCompletionUpdate chatUpdate) { throw null; }
    }
    public partial class AzureSearchChatDataSource : Azure.AI.OpenAI.Chat.ChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public AzureSearchChatDataSource() { }
        public bool? AllowPartialResults { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContexts? OutputContexts { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceQueryType? QueryType { get { throw null; } set { } }
        public string SemanticConfiguration { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceVectorizer VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.AzureSearchChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.AzureSearchChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCitation : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatCitation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatCitation>
    {
        internal ChatCitation() { }
        public string ChunkId { get { throw null; } }
        public string Content { get { throw null; } }
        public string FilePath { get { throw null; } }
        public double? RerankScore { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        Azure.AI.OpenAI.Chat.ChatCitation System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatCitation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatCitation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.ChatCitation System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatCitation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatCitation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatCitation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatDataSource>
    {
        protected ChatDataSource() { }
        Azure.AI.OpenAI.Chat.ChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.ChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatDocumentFilterReason : System.IEquatable<Azure.AI.OpenAI.Chat.ChatDocumentFilterReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatDocumentFilterReason(string value) { throw null; }
        public static Azure.AI.OpenAI.Chat.ChatDocumentFilterReason Rerank { get { throw null; } }
        public static Azure.AI.OpenAI.Chat.ChatDocumentFilterReason Score { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Chat.ChatDocumentFilterReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Chat.ChatDocumentFilterReason left, Azure.AI.OpenAI.Chat.ChatDocumentFilterReason right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Chat.ChatDocumentFilterReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Chat.ChatDocumentFilterReason left, Azure.AI.OpenAI.Chat.ChatDocumentFilterReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatMessageContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatMessageContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatMessageContext>
    {
        internal ChatMessageContext() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Chat.ChatCitation> Citations { get { throw null; } }
        public string Intent { get { throw null; } }
        public Azure.AI.OpenAI.Chat.ChatRetrievedDocument RetrievedDocuments { get { throw null; } }
        Azure.AI.OpenAI.Chat.ChatMessageContext System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatMessageContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatMessageContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.ChatMessageContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatMessageContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatMessageContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatMessageContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRetrievedDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatRetrievedDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatRetrievedDocument>
    {
        internal ChatRetrievedDocument() { }
        public string ChunkId { get { throw null; } }
        public string Content { get { throw null; } }
        public int DataSourceIndex { get { throw null; } }
        public string FilePath { get { throw null; } }
        public Azure.AI.OpenAI.Chat.ChatDocumentFilterReason? FilterReason { get { throw null; } }
        public double? OriginalSearchScore { get { throw null; } }
        public double? RerankScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SearchQueries { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        Azure.AI.OpenAI.Chat.ChatRetrievedDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatRetrievedDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ChatRetrievedDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.ChatRetrievedDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatRetrievedDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatRetrievedDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ChatRetrievedDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosChatDataSource : Azure.AI.OpenAI.Chat.ChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.CosmosChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.CosmosChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public CosmosChatDataSource() { }
        public bool? AllowPartialResults { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContexts? OutputContexts { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceVectorizer VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.CosmosChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.CosmosChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.CosmosChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.CosmosChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.CosmosChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.CosmosChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.CosmosChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataSourceAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>
    {
        protected DataSourceAuthentication() { }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromAccessToken(string accessToken) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromApiKey(string apiKey) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromConnectionString(string connectionString) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromEncodedApiKey(string encodedApiKey) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromKeyAndKeyId(string key, string keyId) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromSystemManagedIdentity() { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromUserManagedIdentity(Azure.Core.ResourceIdentifier identityResource) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromUsernameAndPassword(string username, string password) { throw null; }
        Azure.AI.OpenAI.Chat.DataSourceAuthentication System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.DataSourceAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataSourceFieldMappings : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceFieldMappings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceFieldMappings>
    {
        public DataSourceFieldMappings() { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilePathFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageVectorFieldNames { get { throw null; } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
        Azure.AI.OpenAI.Chat.DataSourceFieldMappings System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceFieldMappings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceFieldMappings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.DataSourceFieldMappings System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceFieldMappings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceFieldMappings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceFieldMappings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.FlagsAttribute]
    public enum DataSourceOutputContexts
    {
        Intent = 1,
        Citations = 2,
        AllRetrievedDocuments = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSourceQueryType : System.IEquatable<Azure.AI.OpenAI.Chat.DataSourceQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSourceQueryType(string value) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceQueryType Semantic { get { throw null; } }
        public static Azure.AI.OpenAI.Chat.DataSourceQueryType Simple { get { throw null; } }
        public static Azure.AI.OpenAI.Chat.DataSourceQueryType Vector { get { throw null; } }
        public static Azure.AI.OpenAI.Chat.DataSourceQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.OpenAI.Chat.DataSourceQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Chat.DataSourceQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Chat.DataSourceQueryType left, Azure.AI.OpenAI.Chat.DataSourceQueryType right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Chat.DataSourceQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Chat.DataSourceQueryType left, Azure.AI.OpenAI.Chat.DataSourceQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataSourceVectorizer : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>
    {
        protected DataSourceVectorizer() { }
        public static Azure.AI.OpenAI.Chat.DataSourceVectorizer FromDeploymentName(string deploymentName) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceVectorizer FromEndpoint(System.Uri endpoint, Azure.AI.OpenAI.Chat.DataSourceAuthentication authentication) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceVectorizer FromIntegratedResource() { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceVectorizer FromModelId(string modelId) { throw null; }
        Azure.AI.OpenAI.Chat.DataSourceVectorizer System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.DataSourceVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticsearchChatDataSource : Azure.AI.OpenAI.Chat.ChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public ElasticsearchChatDataSource() { }
        public bool? AllowPartialResults { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContexts? OutputContexts { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceQueryType? QueryType { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceVectorizer VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBChatDataSource : Azure.AI.OpenAI.Chat.ChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.MongoDBChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.MongoDBChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public MongoDBChatDataSource() { }
        public bool? AllowPartialResults { get { throw null; } set { } }
        public string AppName { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public string CollectionName { get { throw null; } set { } }
        public string EndpointName { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContexts? OutputContexts { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceVectorizer VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.MongoDBChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.MongoDBChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.MongoDBChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.MongoDBChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.MongoDBChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.MongoDBChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.MongoDBChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PineconeChatDataSource : Azure.AI.OpenAI.Chat.ChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public PineconeChatDataSource() { }
        public bool? AllowPartialResults { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public string Environment { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContexts? OutputContexts { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceVectorizer VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.PineconeChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.PineconeChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.AI.OpenAI.Images
{
    public static partial class AzureImageExtensions
    {
        public static Azure.AI.OpenAI.RequestImageContentFilterResult GetRequestContentFilterResult(this OpenAI.Images.GeneratedImage image) { throw null; }
        public static Azure.AI.OpenAI.ResponseImageContentFilterResult GetResponseContentFilterResult(this OpenAI.Images.GeneratedImage image) { throw null; }
    }
}
