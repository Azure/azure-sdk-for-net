namespace Azure.AI.OpenAI
{
    public static partial class AzureChatCompletionExtensions
    {
        public static Azure.AI.OpenAI.Chat.AzureChatMessageContext GetAzureMessageContext(this OpenAI.Chat.ChatCompletion chatCompletion) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultForPrompt GetContentFilterResultForPrompt(this OpenAI.Chat.ChatCompletion chatCompletion) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultForResponse GetContentFilterResultForResponse(this OpenAI.Chat.ChatCompletion chatCompletion) { throw null; }
    }
    public static partial class AzureChatCompletionOptionsExtensions
    {
        public static void AddDataSource(this OpenAI.Chat.ChatCompletionOptions options, Azure.AI.OpenAI.Chat.AzureChatDataSource dataSource) { }
        public static System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Chat.AzureChatDataSource> GetDataSources(this OpenAI.Chat.ChatCompletionOptions options) { throw null; }
    }
    public static partial class AzureGeneratedImageExtensions
    {
        public static Azure.AI.OpenAI.ImageContentFilterResultForPrompt GetContentFilterResultForPrompt(this OpenAI.Images.GeneratedImage image) { throw null; }
        public static Azure.AI.OpenAI.ImageContentFilterResultForResponse GetContentFilterResultForResponse(this OpenAI.Images.GeneratedImage image) { throw null; }
    }
    public partial class AzureOpenAIClient : OpenAI.OpenAIClient
    {
        protected AzureOpenAIClient() { }
        protected AzureOpenAIClient(System.ClientModel.Primitives.ClientPipeline pipeline, System.Uri endpoint, Azure.AI.OpenAI.AzureOpenAIClientOptions options) { }
        public AzureOpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public AzureOpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.OpenAI.AzureOpenAIClientOptions options) { }
        public AzureOpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AzureOpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.OpenAI.AzureOpenAIClientOptions options = null) { }
        public AzureOpenAIClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential) { }
        public AzureOpenAIClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential, Azure.AI.OpenAI.AzureOpenAIClientOptions options) { }
        public override OpenAI.Assistants.AssistantClient GetAssistantClient() { throw null; }
        public override OpenAI.Audio.AudioClient GetAudioClient(string deploymentName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Batch.BatchClient GetBatchClient() { throw null; }
        public OpenAI.Batch.BatchClient GetBatchClient(string deploymentName) { throw null; }
        public override OpenAI.Chat.ChatClient GetChatClient(string deploymentName) { throw null; }
        public override OpenAI.Embeddings.EmbeddingClient GetEmbeddingClient(string deploymentName) { throw null; }
        public override OpenAI.Files.FileClient GetFileClient() { throw null; }
        public override OpenAI.FineTuning.FineTuningClient GetFineTuningClient() { throw null; }
        public override OpenAI.Images.ImageClient GetImageClient(string deploymentName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Models.ModelClient GetModelClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Moderations.ModerationClient GetModerationClient(string _) { throw null; }
        public override OpenAI.VectorStores.VectorStoreClient GetVectorStoreClient() { throw null; }
    }
    public partial class AzureOpenAIClientOptions : OpenAI.OpenAIClientOptions
    {
        public AzureOpenAIClientOptions(Azure.AI.OpenAI.AzureOpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.AzureOpenAIClientOptions.ServiceVersion.V2024_07_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_04_01_Preview = 7,
            V2024_05_01_Preview = 8,
            V2024_06_01 = 9,
            V2024_07_01_Preview = 10,
        }
    }
    public static partial class AzureStreamingChatCompletionUpdateExtensions
    {
        public static Azure.AI.OpenAI.Chat.AzureChatMessageContext GetAzureMessageContext(this OpenAI.Chat.StreamingChatCompletionUpdate chatUpdate) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultForPrompt GetContentFilterResultForPrompt(this OpenAI.Chat.StreamingChatCompletionUpdate chatUpdate) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultForResponse GetContentFilterResultForResponse(this OpenAI.Chat.StreamingChatCompletionUpdate chatUpdate) { throw null; }
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
    public partial class ContentFilterProtectedMaterialCitedResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult>
    {
        internal ContentFilterProtectedMaterialCitedResult() { }
        public string License { get { throw null; } }
        public System.Uri URL { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterProtectedMaterialResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>
    {
        internal ContentFilterProtectedMaterialResult() { }
        public Azure.AI.OpenAI.ContentFilterProtectedMaterialCitedResult Citation { get { throw null; } }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterProtectedMaterialResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterProtectedMaterialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterResultForPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultForPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForPrompt>
    {
        internal ContentFilterResultForPrompt() { }
        public Azure.AI.OpenAI.ContentFilterBlocklistResult CustomBlocklists { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult IndirectAttack { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterResultForPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultForPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultForPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterResultForPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterResultForResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultForResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForResponse>
    {
        internal ContentFilterResultForResponse() { }
        public Azure.AI.OpenAI.ContentFilterBlocklistResult CustomBlocklists { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterProtectedMaterialResult ProtectedMaterialCode { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult ProtectedMaterialText { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterResultForResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultForResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultForResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterResultForResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultForResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ImageContentFilterResultForPrompt : Azure.AI.OpenAI.ImageContentFilterResultForResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageContentFilterResultForPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForPrompt>
    {
        internal ImageContentFilterResultForPrompt() { }
        public Azure.AI.OpenAI.ContentFilterBlocklistResult CustomBlocklists { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        Azure.AI.OpenAI.ImageContentFilterResultForPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageContentFilterResultForPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageContentFilterResultForPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ImageContentFilterResultForPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageContentFilterResultForResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageContentFilterResultForResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForResponse>
    {
        internal ImageContentFilterResultForResponse() { }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverityResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ImageContentFilterResultForResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageContentFilterResultForResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageContentFilterResultForResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ImageContentFilterResultForResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageContentFilterResultForResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.AI.OpenAI.Chat
{
    public partial class AzureChatCitation : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatCitation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatCitation>
    {
        internal AzureChatCitation() { }
        public string ChunkId { get { throw null; } }
        public string Content { get { throw null; } }
        public string Filepath { get { throw null; } }
        public string Title { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.AI.OpenAI.Chat.AzureChatCitation System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatCitation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatCitation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.AzureChatCitation System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatCitation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatCitation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatCitation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AzureChatDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatDataSource>
    {
        protected AzureChatDataSource() { }
        Azure.AI.OpenAI.Chat.AzureChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.AzureChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatMessageContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatMessageContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatMessageContext>
    {
        internal AzureChatMessageContext() { }
        public Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument AllRetrievedDocuments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Chat.AzureChatCitation> Citations { get { throw null; } }
        public string Intent { get { throw null; } }
        Azure.AI.OpenAI.Chat.AzureChatMessageContext System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatMessageContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatMessageContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.AzureChatMessageContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatMessageContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatMessageContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatMessageContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatRetrievedDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument>
    {
        internal AzureChatRetrievedDocument() { }
        public string ChunkId { get { throw null; } }
        public string Content { get { throw null; } }
        public int DataSourceIndex { get { throw null; } }
        public string Filepath { get { throw null; } }
        public Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason? FilterReason { get { throw null; } }
        public double? OriginalSearchScore { get { throw null; } }
        public double? RerankScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SearchQueries { get { throw null; } }
        public string Title { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureChatRetrievedDocumentFilterReason : System.IEquatable<Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureChatRetrievedDocumentFilterReason(string value) { throw null; }
        public static Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason Rerank { get { throw null; } }
        public static Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason Score { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason left, Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason left, Azure.AI.OpenAI.Chat.AzureChatRetrievedDocumentFilterReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureCosmosDBChatDataSource : Azure.AI.OpenAI.Chat.AzureChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public AzureCosmosDBChatDataSource() { }
        public bool? AllowPartialResult { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContextFlags? OutputContextFlags { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceVectorizer VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureCosmosDBChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMachineLearningIndexChatDataSource : Azure.AI.OpenAI.Chat.AzureChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public AzureMachineLearningIndexChatDataSource() { }
        public bool? AllowPartialResult { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContextFlags? OutputContextFlags { get { throw null; } set { } }
        public string ProjectResourceId { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureMachineLearningIndexChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSearchChatDataSource : Azure.AI.OpenAI.Chat.AzureChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.AzureSearchChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public AzureSearchChatDataSource() { }
        public bool? AllowPartialResult { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContextFlags? OutputContextFlags { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceQueryType? QueryType { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
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
    public abstract partial class DataSourceAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceAuthentication>
    {
        protected DataSourceAuthentication() { }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromAccessToken(string accessToken) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromApiKey(string apiKey) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromConnectionString(string connectionString) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromEncodedApiKey(string encodedApiKey) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromKeyAndKeyId(string key, string keyId) { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromSystemManagedIdentity() { throw null; }
        public static Azure.AI.OpenAI.Chat.DataSourceAuthentication FromUserManagedIdentity(string identityResourceId) { throw null; }
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
        public string FilepathFieldName { get { throw null; } set { } }
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
    public enum DataSourceOutputContextFlags
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
        public static Azure.AI.OpenAI.Chat.DataSourceVectorizer FromModelId(string modelId) { throw null; }
        Azure.AI.OpenAI.Chat.DataSourceVectorizer System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.DataSourceVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.DataSourceVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticsearchChatDataSource : Azure.AI.OpenAI.Chat.AzureChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public ElasticsearchChatDataSource() { }
        public bool? AllowPartialResult { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContextFlags? OutputContextFlags { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceQueryType? QueryType { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public int? TopNDocuments { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceVectorizer VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.ElasticsearchChatDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PineconeChatDataSource : Azure.AI.OpenAI.Chat.AzureChatDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Chat.PineconeChatDataSource>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        public PineconeChatDataSource() { }
        public bool? AllowPartialResult { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceAuthentication Authentication { get { throw null; } set { } }
        public string Environment { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceFieldMappings FieldMappings { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public bool? InScope { get { throw null; } set { } }
        public int? MaxSearchQueries { get { throw null; } set { } }
        public Azure.AI.OpenAI.Chat.DataSourceOutputContextFlags? OutputContextFlags { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
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
