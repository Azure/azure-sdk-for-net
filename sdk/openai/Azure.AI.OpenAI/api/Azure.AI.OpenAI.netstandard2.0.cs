namespace Azure.AI.OpenAI
{
    public partial class AudioTranscription : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscription>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscription>
    {
        internal AudioTranscription() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranscriptionSegment> Segments { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.AudioTranscription System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AudioTranscription System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioTranscriptionFormat : System.IEquatable<Azure.AI.OpenAI.AudioTranscriptionFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioTranscriptionFormat(string value) { throw null; }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Simple { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Srt { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Verbose { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Vtt { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AudioTranscriptionFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AudioTranscriptionFormat left, Azure.AI.OpenAI.AudioTranscriptionFormat right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AudioTranscriptionFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AudioTranscriptionFormat left, Azure.AI.OpenAI.AudioTranscriptionFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioTranscriptionOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscriptionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionOptions>
    {
        public AudioTranscriptionOptions() { }
        public AudioTranscriptionOptions(string deploymentName, System.BinaryData audioData) { }
        public System.BinaryData AudioData { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public Azure.AI.OpenAI.AudioTranscriptionFormat? ResponseFormat { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        Azure.AI.OpenAI.AudioTranscriptionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscriptionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscriptionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AudioTranscriptionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioTranscriptionSegment : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscriptionSegment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionSegment>
    {
        internal AudioTranscriptionSegment() { }
        public float AverageLogProbability { get { throw null; } }
        public float CompressionRatio { get { throw null; } }
        public System.TimeSpan End { get { throw null; } }
        public int Id { get { throw null; } }
        public float NoSpeechProbability { get { throw null; } }
        public int Seek { get { throw null; } }
        public System.TimeSpan Start { get { throw null; } }
        public float Temperature { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Tokens { get { throw null; } }
        Azure.AI.OpenAI.AudioTranscriptionSegment System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscriptionSegment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranscriptionSegment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AudioTranscriptionSegment System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionSegment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionSegment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranscriptionSegment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioTranslation : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslation>
    {
        internal AudioTranslation() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranslationSegment> Segments { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.AudioTranslation System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AudioTranslation System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioTranslationFormat : System.IEquatable<Azure.AI.OpenAI.AudioTranslationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioTranslationFormat(string value) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslationFormat Simple { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranslationFormat Srt { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranslationFormat Verbose { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranslationFormat Vtt { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AudioTranslationFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AudioTranslationFormat left, Azure.AI.OpenAI.AudioTranslationFormat right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AudioTranslationFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AudioTranslationFormat left, Azure.AI.OpenAI.AudioTranslationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioTranslationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationOptions>
    {
        public AudioTranslationOptions() { }
        public AudioTranslationOptions(string deploymentName, System.BinaryData audioData) { }
        public System.BinaryData AudioData { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public Azure.AI.OpenAI.AudioTranslationFormat? ResponseFormat { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        Azure.AI.OpenAI.AudioTranslationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AudioTranslationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioTranslationSegment : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslationSegment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationSegment>
    {
        internal AudioTranslationSegment() { }
        public float AverageLogProbability { get { throw null; } }
        public float CompressionRatio { get { throw null; } }
        public System.TimeSpan End { get { throw null; } }
        public int Id { get { throw null; } }
        public float NoSpeechProbability { get { throw null; } }
        public int Seek { get { throw null; } }
        public System.TimeSpan Start { get { throw null; } }
        public float Temperature { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Tokens { get { throw null; } }
        Azure.AI.OpenAI.AudioTranslationSegment System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslationSegment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AudioTranslationSegment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AudioTranslationSegment System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationSegment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationSegment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AudioTranslationSegment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatEnhancementConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatEnhancementConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancementConfiguration>
    {
        public AzureChatEnhancementConfiguration() { }
        public Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration Grounding { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration Ocr { get { throw null; } set { } }
        Azure.AI.OpenAI.AzureChatEnhancementConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatEnhancementConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatEnhancementConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureChatEnhancementConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancementConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancementConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancementConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatEnhancements : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatEnhancements>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancements>
    {
        internal AzureChatEnhancements() { }
        public Azure.AI.OpenAI.AzureGroundingEnhancement Grounding { get { throw null; } }
        Azure.AI.OpenAI.AzureChatEnhancements System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatEnhancements>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatEnhancements>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureChatEnhancements System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancements>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancements>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatEnhancements>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AzureChatExtensionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionConfiguration>
    {
        protected AzureChatExtensionConfiguration() { }
        Azure.AI.OpenAI.AzureChatExtensionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureChatExtensionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatExtensionDataSourceResponseCitation : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation>
    {
        internal AzureChatExtensionDataSourceResponseCitation() { }
        public string ChunkId { get { throw null; } }
        public string Content { get { throw null; } }
        public string Filepath { get { throw null; } }
        public string Title { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatExtensionsMessageContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionsMessageContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionsMessageContext>
    {
        internal AzureChatExtensionsMessageContext() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation> Citations { get { throw null; } }
        public string Intent { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResultsForPrompt RequestContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResultsForChoice ResponseContentFilterResults { get { throw null; } }
        Azure.AI.OpenAI.AzureChatExtensionsMessageContext System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionsMessageContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatExtensionsMessageContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureChatExtensionsMessageContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionsMessageContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionsMessageContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatExtensionsMessageContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatExtensionsOptions
    {
        public AzureChatExtensionsOptions() { }
        public Azure.AI.OpenAI.AzureChatEnhancementConfiguration EnhancementOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.AzureChatExtensionConfiguration> Extensions { get { throw null; } }
    }
    public partial class AzureChatGroundingEnhancementConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration>
    {
        public AzureChatGroundingEnhancementConfiguration(bool enabled) { }
        public bool Enabled { get { throw null; } }
        Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureChatOCREnhancementConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration>
    {
        public AzureChatOCREnhancementConfiguration(bool enabled) { }
        public bool Enabled { get { throw null; } }
        Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureCosmosDBChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration>
    {
        public AzureCosmosDBChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBChatExtensionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureCosmosDBFieldMappingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions>
    {
        public AzureCosmosDBFieldMappingOptions(System.Collections.Generic.IEnumerable<string> contentFieldNames, System.Collections.Generic.IEnumerable<string> vectorFieldNames) { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
        Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureGroundingEnhancement : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancement>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancement>
    {
        internal AzureGroundingEnhancement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AzureGroundingEnhancementLine> Lines { get { throw null; } }
        Azure.AI.OpenAI.AzureGroundingEnhancement System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureGroundingEnhancement System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureGroundingEnhancementCoordinatePoint : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint>
    {
        internal AzureGroundingEnhancementCoordinatePoint() { }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureGroundingEnhancementLine : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementLine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLine>
    {
        internal AzureGroundingEnhancementLine() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan> Spans { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.AzureGroundingEnhancementLine System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementLine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementLine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureGroundingEnhancementLine System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureGroundingEnhancementLineSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan>
    {
        internal AzureGroundingEnhancementLineSpan() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint> Polygon { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMachineLearningIndexChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration>
    {
        public AzureMachineLearningIndexChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ProjectResourceId { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureMachineLearningIndexChatExtensionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AzureOpenAIModelFactory
    {
        public static Azure.AI.OpenAI.AudioTranscription AudioTranscription(string text, string language, System.TimeSpan duration, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranscriptionSegment> segments) { throw null; }
        public static Azure.AI.OpenAI.AudioTranscriptionSegment AudioTranscriptionSegment(int id = 0, System.TimeSpan start = default(System.TimeSpan), System.TimeSpan end = default(System.TimeSpan), string text = null, float temperature = 0f, float averageLogProbability = 0f, float compressionRatio = 0f, float noSpeechProbability = 0f, System.Collections.Generic.IEnumerable<int> tokens = null, int seek = 0) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslation AudioTranslation(string text, string language, System.TimeSpan duration, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranslationSegment> segments) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslationSegment AudioTranslationSegment(int id = 0, System.TimeSpan start = default(System.TimeSpan), System.TimeSpan end = default(System.TimeSpan), string text = null, float temperature = 0f, float averageLogProbability = 0f, float compressionRatio = 0f, float noSpeechProbability = 0f, System.Collections.Generic.IEnumerable<int> tokens = null, int seek = 0) { throw null; }
        public static Azure.AI.OpenAI.AzureChatEnhancements AzureChatEnhancements(Azure.AI.OpenAI.AzureGroundingEnhancement grounding = null) { throw null; }
        public static Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation AzureChatExtensionDataSourceResponseCitation(string content = null, string title = null, string url = null, string filepath = null, string chunkId = null) { throw null; }
        public static Azure.AI.OpenAI.AzureChatExtensionsMessageContext AzureChatExtensionsMessageContext(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.AzureChatExtensionDataSourceResponseCitation> citations = null, string intent = null) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancement AzureGroundingEnhancement(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.AzureGroundingEnhancementLine> lines = null) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint AzureGroundingEnhancementCoordinatePoint(float x = 0f, float y = 0f) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancementLine AzureGroundingEnhancementLine(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan> spans = null) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan AzureGroundingEnhancementLineSpan(string text = null, int offset = 0, int length = 0, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint> polygon = null) { throw null; }
        public static Azure.AI.OpenAI.ChatChoice ChatChoice(Azure.AI.OpenAI.ChatResponseMessage message = null, Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo logProbabilityInfo = null, int index = 0, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?), Azure.AI.OpenAI.ChatFinishDetails finishDetails = null, Azure.AI.OpenAI.ChatResponseMessage deltaMessage = null, Azure.AI.OpenAI.ContentFilterResultsForChoice contentFilterResults = null, Azure.AI.OpenAI.AzureChatEnhancements enhancements = null) { throw null; }
        public static Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo ChatChoiceLogProbabilityInfo(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatTokenLogProbabilityResult> tokenLogProbabilityResults = null) { throw null; }
        public static Azure.AI.OpenAI.ChatCompletions ChatCompletions(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatChoice> choices = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterResultsForPrompt> promptFilterResults = null, string systemFingerprint = null, Azure.AI.OpenAI.CompletionsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition ChatCompletionsFunctionToolDefinition(Azure.AI.OpenAI.FunctionDefinition function = null) { throw null; }
        public static Azure.AI.OpenAI.ChatMessageImageContentItem ChatMessageImageContentItem(Azure.AI.OpenAI.ChatMessageImageUrl imageUrl = null) { throw null; }
        public static Azure.AI.OpenAI.ChatMessageImageUrl ChatMessageImageUrl(System.Uri url = null, Azure.AI.OpenAI.ChatMessageImageDetailLevel? detail = default(Azure.AI.OpenAI.ChatMessageImageDetailLevel?)) { throw null; }
        public static Azure.AI.OpenAI.ChatMessageTextContentItem ChatMessageTextContentItem(string text = null) { throw null; }
        public static Azure.AI.OpenAI.ChatRequestAssistantMessage ChatRequestAssistantMessage(string content = null, string name = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatCompletionsToolCall> toolCalls = null, Azure.AI.OpenAI.FunctionCall functionCall = null) { throw null; }
        public static Azure.AI.OpenAI.ChatRequestFunctionMessage ChatRequestFunctionMessage(string name = null, string content = null) { throw null; }
        public static Azure.AI.OpenAI.ChatRequestSystemMessage ChatRequestSystemMessage(string content = null, string name = null) { throw null; }
        public static Azure.AI.OpenAI.ChatRequestToolMessage ChatRequestToolMessage(string content = null, string toolCallId = null) { throw null; }
        public static Azure.AI.OpenAI.ChatResponseMessage ChatResponseMessage(Azure.AI.OpenAI.ChatRole role = default(Azure.AI.OpenAI.ChatRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatCompletionsToolCall> toolCalls = null, Azure.AI.OpenAI.FunctionCall functionCall = null, Azure.AI.OpenAI.AzureChatExtensionsMessageContext azureExtensionsContext = null) { throw null; }
        public static Azure.AI.OpenAI.ChatTokenLogProbabilityInfo ChatTokenLogProbabilityInfo(string token = null, float logProbability = 0f, System.Collections.Generic.IEnumerable<int> utf8ByteValues = null) { throw null; }
        public static Azure.AI.OpenAI.ChatTokenLogProbabilityResult ChatTokenLogProbabilityResult(string token = null, float logProbability = 0f, System.Collections.Generic.IEnumerable<int> utf8ByteValues = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo> topLogProbabilityEntries = null) { throw null; }
        public static Azure.AI.OpenAI.Choice Choice(string text = null, int index = 0, Azure.AI.OpenAI.ContentFilterResultsForChoice contentFilterResults = null, Azure.AI.OpenAI.CompletionsLogProbabilityModel logProbabilityModel = null, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?)) { throw null; }
        public static Azure.AI.OpenAI.Completions Completions(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterResultsForPrompt> promptFilterResults = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Choice> choices = null, Azure.AI.OpenAI.CompletionsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.CompletionsLogProbabilityModel CompletionsLogProbabilityModel(System.Collections.Generic.IEnumerable<string> tokens = null, System.Collections.Generic.IEnumerable<float?> tokenLogProbabilities = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, float?>> topLogProbabilities = null, System.Collections.Generic.IEnumerable<int> textOffsets = null) { throw null; }
        public static Azure.AI.OpenAI.CompletionsUsage CompletionsUsage(int completionTokens = 0, int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterBlocklistIdResult ContentFilterBlocklistIdResult(string id = null, bool filtered = false) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterCitedDetectionResult ContentFilterCitedDetectionResult(bool filtered = false, bool detected = false, System.Uri url = null, string license = null) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterDetectionResult ContentFilterDetectionResult(bool filtered = false, bool detected = false) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResult ContentFilterResult(Azure.AI.OpenAI.ContentFilterSeverity severity = default(Azure.AI.OpenAI.ContentFilterSeverity), bool filtered = false) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt ContentFilterResultDetailsForPrompt(Azure.AI.OpenAI.ContentFilterResult sexual = null, Azure.AI.OpenAI.ContentFilterResult violence = null, Azure.AI.OpenAI.ContentFilterResult hate = null, Azure.AI.OpenAI.ContentFilterResult selfHarm = null, Azure.AI.OpenAI.ContentFilterDetectionResult profanity = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> customBlocklists = null, Azure.ResponseError error = null, Azure.AI.OpenAI.ContentFilterDetectionResult jailbreak = null) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultsForChoice ContentFilterResultsForChoice(Azure.AI.OpenAI.ContentFilterResult sexual = null, Azure.AI.OpenAI.ContentFilterResult violence = null, Azure.AI.OpenAI.ContentFilterResult hate = null, Azure.AI.OpenAI.ContentFilterResult selfHarm = null, Azure.AI.OpenAI.ContentFilterDetectionResult profanity = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> customBlocklists = null, Azure.ResponseError error = null, Azure.AI.OpenAI.ContentFilterDetectionResult protectedMaterialText = null, Azure.AI.OpenAI.ContentFilterCitedDetectionResult protectedMaterialCode = null) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultsForPrompt ContentFilterResultsForPrompt(int promptIndex = 0, Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt contentFilterResults = null) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingItem EmbeddingItem(System.ReadOnlyMemory<float> embedding = default(System.ReadOnlyMemory<float>), int index = 0) { throw null; }
        public static Azure.AI.OpenAI.Embeddings Embeddings(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.EmbeddingItem> data = null, Azure.AI.OpenAI.EmbeddingsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingsUsage EmbeddingsUsage(int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationContentFilterResults ImageGenerationContentFilterResults(Azure.AI.OpenAI.ContentFilterResult sexual = null, Azure.AI.OpenAI.ContentFilterResult violence = null, Azure.AI.OpenAI.ContentFilterResult hate = null, Azure.AI.OpenAI.ContentFilterResult selfHarm = null) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationData ImageGenerationData(System.Uri url = null, string base64Data = null, Azure.AI.OpenAI.ImageGenerationContentFilterResults contentFilterResults = null, string revisedPrompt = null, Azure.AI.OpenAI.ImageGenerationPromptFilterResults promptFilterResults = null) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationPromptFilterResults ImageGenerationPromptFilterResults(Azure.AI.OpenAI.ContentFilterResult sexual = null, Azure.AI.OpenAI.ContentFilterResult violence = null, Azure.AI.OpenAI.ContentFilterResult hate = null, Azure.AI.OpenAI.ContentFilterResult selfHarm = null, Azure.AI.OpenAI.ContentFilterDetectionResult profanity = null, Azure.AI.OpenAI.ContentFilterDetectionResult jailbreak = null) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerations ImageGenerations(System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ImageGenerationData> data = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions OnYourDataAccessTokenAuthenticationOptions(string accessToken = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions OnYourDataApiKeyAuthenticationOptions(string key = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions OnYourDataConnectionStringAuthenticationOptions(string connectionString = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource OnYourDataDeploymentNameVectorizationSource(string deploymentName = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions OnYourDataEncodedApiKeyAuthenticationOptions(string encodedApiKey = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource OnYourDataEndpointVectorizationSource(System.Uri endpoint = null, Azure.AI.OpenAI.OnYourDataAuthenticationOptions authentication = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions OnYourDataKeyAndKeyIdAuthenticationOptions(string key = null, string keyId = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource OnYourDataModelIdVectorizationSource(string modelId = null) { throw null; }
        public static Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions OnYourDataUserAssignedManagedIdentityAuthenticationOptions(string managedIdentityResourceId = null) { throw null; }
        public static Azure.AI.OpenAI.StopFinishDetails StopFinishDetails(string stop = null) { throw null; }
        public static Azure.AI.OpenAI.StreamingChatCompletionsUpdate StreamingChatCompletionsUpdate(string id, System.DateTimeOffset created, string systemFingerprint, int? choiceIndex = default(int?), Azure.AI.OpenAI.ChatRole? role = default(Azure.AI.OpenAI.ChatRole?), string authorName = null, string contentUpdate = null, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?), string functionName = null, string functionArgumentsUpdate = null, Azure.AI.OpenAI.StreamingToolCallUpdate toolCallUpdate = null, Azure.AI.OpenAI.AzureChatExtensionsMessageContext azureExtensionsContext = null) { throw null; }
        public static Azure.AI.OpenAI.StreamingFunctionToolCallUpdate StreamingFunctionToolCallUpdate(string id, int toolCallIndex, string functionName, string functionArgumentsUpdate) { throw null; }
    }
    public partial class AzureSearchChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration>
    {
        public AzureSearchChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureSearchQueryType? QueryType { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public System.Uri SearchEndpoint { get { throw null; } set { } }
        public string SemanticConfiguration { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchChatExtensionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSearchIndexFieldMappingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions>
    {
        public AzureSearchIndexFieldMappingOptions() { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageVectorFieldNames { get { throw null; } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
        Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.AzureSearchIndexFieldMappingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSearchQueryType : System.IEquatable<Azure.AI.OpenAI.AzureSearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSearchQueryType(string value) { throw null; }
        public static Azure.AI.OpenAI.AzureSearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.OpenAI.AzureSearchQueryType Simple { get { throw null; } }
        public static Azure.AI.OpenAI.AzureSearchQueryType Vector { get { throw null; } }
        public static Azure.AI.OpenAI.AzureSearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.OpenAI.AzureSearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AzureSearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AzureSearchQueryType left, Azure.AI.OpenAI.AzureSearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AzureSearchQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AzureSearchQueryType left, Azure.AI.OpenAI.AzureSearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoice>
    {
        internal ChatChoice() { }
        public Azure.AI.OpenAI.ContentFilterResultsForChoice ContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.AzureChatEnhancements Enhancements { get { throw null; } }
        public Azure.AI.OpenAI.ChatFinishDetails FinishDetails { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo LogProbabilityInfo { get { throw null; } }
        public Azure.AI.OpenAI.ChatResponseMessage Message { get { throw null; } }
        Azure.AI.OpenAI.ChatChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatChoiceLogProbabilityInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo>
    {
        internal ChatChoiceLogProbabilityInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatTokenLogProbabilityResult> TokenLogProbabilityResults { get { throw null; } }
        Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatChoiceLogProbabilityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletions>
    {
        internal ChatCompletions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatChoice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterResultsForPrompt> PromptFilterResults { get { throw null; } }
        public string SystemFingerprint { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
        Azure.AI.OpenAI.ChatCompletions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatCompletions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsFunctionToolCall : Azure.AI.OpenAI.ChatCompletionsToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolCall>
    {
        public ChatCompletionsFunctionToolCall(string id, Azure.AI.OpenAI.FunctionCall function) : base (default(string)) { }
        public ChatCompletionsFunctionToolCall(string id, string name, string arguments) : base (default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.AI.OpenAI.ChatCompletionsFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatCompletionsFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsFunctionToolDefinition : Azure.AI.OpenAI.ChatCompletionsToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition>
    {
        public ChatCompletionsFunctionToolDefinition() { }
        public ChatCompletionsFunctionToolDefinition(Azure.AI.OpenAI.FunctionDefinition function) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.OpenAI.FunctionDefinition Function { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsOptions>
    {
        public ChatCompletionsOptions() { }
        public ChatCompletionsOptions(string deploymentName, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatRequestMessage> messages) { }
        public Azure.AI.OpenAI.AzureChatExtensionsOptions AzureExtensionsOptions { get { throw null; } set { } }
        public int? ChoiceCount { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public bool? EnableLogProbabilities { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public Azure.AI.OpenAI.FunctionDefinition FunctionCall { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.FunctionDefinition> Functions { get { throw null; } }
        public int? LogProbabilitiesPerToken { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatRequestMessage> Messages { get { throw null; } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public Azure.AI.OpenAI.ChatCompletionsResponseFormat ResponseFormat { get { throw null; } set { } }
        public long? Seed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> TokenSelectionBiases { get { throw null; } }
        public Azure.AI.OpenAI.ChatCompletionsToolChoice ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatCompletionsToolDefinition> Tools { get { throw null; } }
        public string User { get { throw null; } set { } }
        Azure.AI.OpenAI.ChatCompletionsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatCompletionsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatCompletionsResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsResponseFormat>
    {
        public static readonly Azure.AI.OpenAI.ChatCompletionsResponseFormat JsonObject;
        public static readonly Azure.AI.OpenAI.ChatCompletionsResponseFormat Text;
        protected ChatCompletionsResponseFormat() { }
        Azure.AI.OpenAI.ChatCompletionsResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatCompletionsResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatCompletionsToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolCall>
    {
        protected ChatCompletionsToolCall(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.AI.OpenAI.ChatCompletionsToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatCompletionsToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionsToolChoice
    {
        public static readonly Azure.AI.OpenAI.ChatCompletionsToolChoice Auto;
        public static readonly Azure.AI.OpenAI.ChatCompletionsToolChoice None;
        public ChatCompletionsToolChoice(Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition functionToolDefinition) { }
        public ChatCompletionsToolChoice(Azure.AI.OpenAI.FunctionDefinition functionDefinition) { }
        public static implicit operator Azure.AI.OpenAI.ChatCompletionsToolChoice (Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition functionToolDefinition) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatCompletionsToolChoice (Azure.AI.OpenAI.FunctionDefinition functionDefinition) { throw null; }
    }
    public abstract partial class ChatCompletionsToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolDefinition>
    {
        protected ChatCompletionsToolDefinition() { }
        Azure.AI.OpenAI.ChatCompletionsToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatCompletionsToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatCompletionsToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatCompletionsToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatFinishDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatFinishDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatFinishDetails>
    {
        protected ChatFinishDetails() { }
        Azure.AI.OpenAI.ChatFinishDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatFinishDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatFinishDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatFinishDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatFinishDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatFinishDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatFinishDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatMessageContentItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageContentItem>
    {
        protected ChatMessageContentItem() { }
        Azure.AI.OpenAI.ChatMessageContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatMessageContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatMessageImageContentItem : Azure.AI.OpenAI.ChatMessageContentItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageImageContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageContentItem>
    {
        public ChatMessageImageContentItem(Azure.AI.OpenAI.ChatMessageImageUrl imageUrl) { }
        public ChatMessageImageContentItem(System.Uri imageUri) { }
        public ChatMessageImageContentItem(System.Uri imageUri, Azure.AI.OpenAI.ChatMessageImageDetailLevel detailLevel) { }
        public Azure.AI.OpenAI.ChatMessageImageUrl ImageUrl { get { throw null; } }
        Azure.AI.OpenAI.ChatMessageImageContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageImageContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageImageContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatMessageImageContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatMessageImageDetailLevel : System.IEquatable<Azure.AI.OpenAI.ChatMessageImageDetailLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatMessageImageDetailLevel(string value) { throw null; }
        public static Azure.AI.OpenAI.ChatMessageImageDetailLevel Auto { get { throw null; } }
        public static Azure.AI.OpenAI.ChatMessageImageDetailLevel High { get { throw null; } }
        public static Azure.AI.OpenAI.ChatMessageImageDetailLevel Low { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ChatMessageImageDetailLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ChatMessageImageDetailLevel left, Azure.AI.OpenAI.ChatMessageImageDetailLevel right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatMessageImageDetailLevel (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ChatMessageImageDetailLevel left, Azure.AI.OpenAI.ChatMessageImageDetailLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatMessageImageUrl : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageImageUrl>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageUrl>
    {
        public ChatMessageImageUrl(System.Uri url) { }
        public Azure.AI.OpenAI.ChatMessageImageDetailLevel? Detail { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
        Azure.AI.OpenAI.ChatMessageImageUrl System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageImageUrl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageImageUrl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatMessageImageUrl System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageUrl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageUrl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageImageUrl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatMessageTextContentItem : Azure.AI.OpenAI.ChatMessageContentItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageTextContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageTextContentItem>
    {
        public ChatMessageTextContentItem(string text) { }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.ChatMessageTextContentItem System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageTextContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatMessageTextContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatMessageTextContentItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageTextContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageTextContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatMessageTextContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestAssistantMessage : Azure.AI.OpenAI.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestAssistantMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestAssistantMessage>
    {
        public ChatRequestAssistantMessage(Azure.AI.OpenAI.ChatResponseMessage responseMessage) { }
        public ChatRequestAssistantMessage(string content) { }
        public string Content { get { throw null; } }
        public Azure.AI.OpenAI.FunctionCall FunctionCall { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
        Azure.AI.OpenAI.ChatRequestAssistantMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestAssistantMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestAssistantMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatRequestAssistantMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestAssistantMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestAssistantMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestAssistantMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestFunctionMessage : Azure.AI.OpenAI.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestFunctionMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestFunctionMessage>
    {
        public ChatRequestFunctionMessage(string name, string content) { }
        public string Content { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.AI.OpenAI.ChatRequestFunctionMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestFunctionMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestFunctionMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatRequestFunctionMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestFunctionMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestFunctionMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestFunctionMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatRequestMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestMessage>
    {
        protected ChatRequestMessage() { }
        public Azure.AI.OpenAI.ChatRole Role { get { throw null; } set { } }
        Azure.AI.OpenAI.ChatRequestMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatRequestMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestSystemMessage : Azure.AI.OpenAI.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestSystemMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestSystemMessage>
    {
        public ChatRequestSystemMessage(string content) { }
        public string Content { get { throw null; } }
        public string Name { get { throw null; } set { } }
        Azure.AI.OpenAI.ChatRequestSystemMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestSystemMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestSystemMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatRequestSystemMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestSystemMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestSystemMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestSystemMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestToolMessage : Azure.AI.OpenAI.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestToolMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestToolMessage>
    {
        public ChatRequestToolMessage(string content, string toolCallId) { }
        public string Content { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        Azure.AI.OpenAI.ChatRequestToolMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestToolMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestToolMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatRequestToolMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestToolMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestToolMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestToolMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRequestUserMessage : Azure.AI.OpenAI.ChatRequestMessage, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestUserMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestUserMessage>
    {
        public ChatRequestUserMessage(params Azure.AI.OpenAI.ChatMessageContentItem[] content) { }
        public ChatRequestUserMessage(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatMessageContentItem> content) { }
        public ChatRequestUserMessage(string content) { }
        public string Content { get { throw null; } protected set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatMessageContentItem> MultimodalContentItems { get { throw null; } }
        public string Name { get { throw null; } set { } }
        Azure.AI.OpenAI.ChatRequestUserMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestUserMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatRequestUserMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatRequestUserMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestUserMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestUserMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatRequestUserMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatResponseMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatResponseMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatResponseMessage>
    {
        internal ChatResponseMessage() { }
        public Azure.AI.OpenAI.AzureChatExtensionsMessageContext AzureExtensionsContext { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.OpenAI.FunctionCall FunctionCall { get { throw null; } }
        public Azure.AI.OpenAI.ChatRole Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
        Azure.AI.OpenAI.ChatResponseMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatResponseMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatResponseMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatResponseMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatResponseMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatResponseMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatResponseMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatRole : System.IEquatable<Azure.AI.OpenAI.ChatRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatRole(string value) { throw null; }
        public static Azure.AI.OpenAI.ChatRole Assistant { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole Function { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole System { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole Tool { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole User { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ChatRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatTokenLogProbabilityInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo>
    {
        internal ChatTokenLogProbabilityInfo() { }
        public float LogProbability { get { throw null; } }
        public string Token { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Utf8ByteValues { get { throw null; } }
        Azure.AI.OpenAI.ChatTokenLogProbabilityInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatTokenLogProbabilityInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatTokenLogProbabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatTokenLogProbabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityResult>
    {
        internal ChatTokenLogProbabilityResult() { }
        public float LogProbability { get { throw null; } }
        public string Token { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatTokenLogProbabilityInfo> TopLogProbabilityEntries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Utf8ByteValues { get { throw null; } }
        Azure.AI.OpenAI.ChatTokenLogProbabilityResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatTokenLogProbabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ChatTokenLogProbabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ChatTokenLogProbabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ChatTokenLogProbabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Choice : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Choice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Choice>
    {
        internal Choice() { }
        public Azure.AI.OpenAI.ContentFilterResultsForChoice ContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsLogProbabilityModel LogProbabilityModel { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.Choice System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Choice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Choice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Choice System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Choice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Choice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Choice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Completions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Completions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Completions>
    {
        internal Completions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Choice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterResultsForPrompt> PromptFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
        Azure.AI.OpenAI.Completions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Completions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Completions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Completions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Completions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Completions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Completions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompletionsFinishReason : System.IEquatable<Azure.AI.OpenAI.CompletionsFinishReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompletionsFinishReason(string value) { throw null; }
        public static Azure.AI.OpenAI.CompletionsFinishReason ContentFiltered { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason FunctionCall { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason Stopped { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason TokenLimitReached { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.CompletionsFinishReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.CompletionsFinishReason left, Azure.AI.OpenAI.CompletionsFinishReason right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.CompletionsFinishReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.CompletionsFinishReason left, Azure.AI.OpenAI.CompletionsFinishReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CompletionsLogProbabilityModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsLogProbabilityModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsLogProbabilityModel>
    {
        internal CompletionsLogProbabilityModel() { }
        public System.Collections.Generic.IReadOnlyList<int> TextOffsets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float?> TokenLogProbabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, float?>> TopLogProbabilities { get { throw null; } }
        Azure.AI.OpenAI.CompletionsLogProbabilityModel System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsLogProbabilityModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsLogProbabilityModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.CompletionsLogProbabilityModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsLogProbabilityModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsLogProbabilityModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsLogProbabilityModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompletionsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsOptions>
    {
        public CompletionsOptions() { }
        public CompletionsOptions(string deploymentName, System.Collections.Generic.IEnumerable<string> prompts) { }
        public int? ChoicesPerPrompt { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public bool? Echo { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? GenerationSampleCount { get { throw null; } set { } }
        public int? LogProbabilityCount { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Prompts { get { throw null; } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> TokenSelectionBiases { get { throw null; } }
        public string User { get { throw null; } set { } }
        Azure.AI.OpenAI.CompletionsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.CompletionsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompletionsUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsUsage>
    {
        internal CompletionsUsage() { }
        public int CompletionTokens { get { throw null; } }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        Azure.AI.OpenAI.CompletionsUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.CompletionsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.CompletionsUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.CompletionsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterBlocklistIdResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterBlocklistIdResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistIdResult>
    {
        internal ContentFilterBlocklistIdResult() { }
        public bool Filtered { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterBlocklistIdResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterBlocklistIdResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterBlocklistIdResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterBlocklistIdResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistIdResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistIdResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterBlocklistIdResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterCitedDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterCitedDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterCitedDetectionResult>
    {
        internal ContentFilterCitedDetectionResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        public string License { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterCitedDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterCitedDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterCitedDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterCitedDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterCitedDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterCitedDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterCitedDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContentFilterResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResult>
    {
        internal ContentFilterResult() { }
        public bool Filtered { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverity Severity { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterResult System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterResultDetailsForPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt>
    {
        internal ContentFilterResultDetailsForPrompt() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> CustomBlocklists { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterResultsForChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultsForChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForChoice>
    {
        internal ContentFilterResultsForChoice() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> CustomBlocklists { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterCitedDetectionResult ProtectedMaterialCode { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult ProtectedMaterialText { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterResultsForChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultsForChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultsForChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterResultsForChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterResultsForPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultsForPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForPrompt>
    {
        internal ContentFilterResultsForPrompt() { }
        public Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt ContentFilterResults { get { throw null; } }
        public int PromptIndex { get { throw null; } }
        Azure.AI.OpenAI.ContentFilterResultsForPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultsForPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ContentFilterResultsForPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ContentFilterResultsForPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ContentFilterResultsForPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ElasticsearchChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration>
    {
        public ElasticsearchChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public Azure.AI.OpenAI.ElasticsearchQueryType? QueryType { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } set { } }
        Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchChatExtensionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticsearchIndexFieldMappingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions>
    {
        public ElasticsearchIndexFieldMappingOptions() { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
        Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticsearchQueryType : System.IEquatable<Azure.AI.OpenAI.ElasticsearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticsearchQueryType(string value) { throw null; }
        public static Azure.AI.OpenAI.ElasticsearchQueryType Simple { get { throw null; } }
        public static Azure.AI.OpenAI.ElasticsearchQueryType Vector { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ElasticsearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ElasticsearchQueryType left, Azure.AI.OpenAI.ElasticsearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ElasticsearchQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ElasticsearchQueryType left, Azure.AI.OpenAI.ElasticsearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmbeddingItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingItem>
    {
        internal EmbeddingItem() { }
        public System.ReadOnlyMemory<float> Embedding { get { throw null; } }
        public int Index { get { throw null; } }
        Azure.AI.OpenAI.EmbeddingItem System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.EmbeddingItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Embeddings : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Embeddings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Embeddings>
    {
        internal Embeddings() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.EmbeddingItem> Data { get { throw null; } }
        public Azure.AI.OpenAI.EmbeddingsUsage Usage { get { throw null; } }
        Azure.AI.OpenAI.Embeddings System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Embeddings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Embeddings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Embeddings System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Embeddings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Embeddings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Embeddings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmbeddingsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsOptions>
    {
        public EmbeddingsOptions() { }
        public EmbeddingsOptions(string deploymentName, System.Collections.Generic.IEnumerable<string> input) { }
        public string DeploymentName { get { throw null; } set { } }
        public int? Dimensions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Input { get { throw null; } }
        public string InputType { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        Azure.AI.OpenAI.EmbeddingsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.EmbeddingsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmbeddingsUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingsUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsUsage>
    {
        internal EmbeddingsUsage() { }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        Azure.AI.OpenAI.EmbeddingsUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.EmbeddingsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.EmbeddingsUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.EmbeddingsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.FunctionCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionCall>
    {
        public FunctionCall(string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.AI.OpenAI.FunctionCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.FunctionCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.FunctionCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.FunctionCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.FunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionDefinition>
    {
        public static Azure.AI.OpenAI.FunctionDefinition Auto;
        public static Azure.AI.OpenAI.FunctionDefinition None;
        public FunctionDefinition() { }
        public FunctionDefinition(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        Azure.AI.OpenAI.FunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.FunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.FunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.FunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.FunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageGenerationContentFilterResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationContentFilterResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationContentFilterResults>
    {
        internal ImageGenerationContentFilterResults() { }
        public Azure.AI.OpenAI.ContentFilterResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ImageGenerationContentFilterResults System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationContentFilterResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationContentFilterResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ImageGenerationContentFilterResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationContentFilterResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationContentFilterResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationContentFilterResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageGenerationData : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationData>
    {
        internal ImageGenerationData() { }
        public string Base64Data { get { throw null; } }
        public Azure.AI.OpenAI.ImageGenerationContentFilterResults ContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.ImageGenerationPromptFilterResults PromptFilterResults { get { throw null; } }
        public string RevisedPrompt { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        Azure.AI.OpenAI.ImageGenerationData System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ImageGenerationData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageGenerationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationOptions>
    {
        public ImageGenerationOptions() { }
        public ImageGenerationOptions(string prompt) { }
        public string DeploymentName { get { throw null; } set { } }
        public int? ImageCount { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public Azure.AI.OpenAI.ImageGenerationQuality? Quality { get { throw null; } set { } }
        public Azure.AI.OpenAI.ImageSize? Size { get { throw null; } set { } }
        public Azure.AI.OpenAI.ImageGenerationStyle? Style { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        Azure.AI.OpenAI.ImageGenerationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ImageGenerationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageGenerationPromptFilterResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationPromptFilterResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationPromptFilterResults>
    {
        internal ImageGenerationPromptFilterResults() { }
        public Azure.AI.OpenAI.ContentFilterResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Violence { get { throw null; } }
        Azure.AI.OpenAI.ImageGenerationPromptFilterResults System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationPromptFilterResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerationPromptFilterResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ImageGenerationPromptFilterResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationPromptFilterResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationPromptFilterResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerationPromptFilterResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageGenerationQuality : System.IEquatable<Azure.AI.OpenAI.ImageGenerationQuality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageGenerationQuality(string value) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationQuality Hd { get { throw null; } }
        public static Azure.AI.OpenAI.ImageGenerationQuality Standard { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ImageGenerationQuality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ImageGenerationQuality left, Azure.AI.OpenAI.ImageGenerationQuality right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ImageGenerationQuality (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ImageGenerationQuality left, Azure.AI.OpenAI.ImageGenerationQuality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageGenerations : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerations>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerations>
    {
        internal ImageGenerations() { }
        public System.DateTimeOffset Created { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ImageGenerationData> Data { get { throw null; } }
        Azure.AI.OpenAI.ImageGenerations System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.ImageGenerations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.ImageGenerations System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.ImageGenerations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageGenerationStyle : System.IEquatable<Azure.AI.OpenAI.ImageGenerationStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageGenerationStyle(string value) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationStyle Natural { get { throw null; } }
        public static Azure.AI.OpenAI.ImageGenerationStyle Vivid { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ImageGenerationStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ImageGenerationStyle left, Azure.AI.OpenAI.ImageGenerationStyle right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ImageGenerationStyle (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ImageGenerationStyle left, Azure.AI.OpenAI.ImageGenerationStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageSize : System.IEquatable<Azure.AI.OpenAI.ImageSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageSize(string value) { throw null; }
        public static Azure.AI.OpenAI.ImageSize Size1024x1024 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size1024x1792 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size1792x1024 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size256x256 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size512x512 { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ImageSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ImageSize left, Azure.AI.OpenAI.ImageSize right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ImageSize (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ImageSize left, Azure.AI.OpenAI.ImageSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaxTokensFinishDetails : Azure.AI.OpenAI.ChatFinishDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.MaxTokensFinishDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.MaxTokensFinishDetails>
    {
        internal MaxTokensFinishDetails() { }
        Azure.AI.OpenAI.MaxTokensFinishDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.MaxTokensFinishDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.MaxTokensFinishDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.MaxTokensFinishDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.MaxTokensFinishDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.MaxTokensFinishDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.MaxTokensFinishDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataAccessTokenAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions>
    {
        public OnYourDataAccessTokenAuthenticationOptions(string accessToken) { }
        public string AccessToken { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAccessTokenAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataApiKeyAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions>
    {
        public OnYourDataApiKeyAuthenticationOptions(string key) { }
        public string Key { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataApiKeyAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OnYourDataAuthenticationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAuthenticationOptions>
    {
        protected OnYourDataAuthenticationOptions() { }
        Azure.AI.OpenAI.OnYourDataAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataConnectionStringAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions>
    {
        public OnYourDataConnectionStringAuthenticationOptions(string connectionString) { }
        public string ConnectionString { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataConnectionStringAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataDeploymentNameVectorizationSource : Azure.AI.OpenAI.OnYourDataVectorizationSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource>
    {
        public OnYourDataDeploymentNameVectorizationSource(string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataDeploymentNameVectorizationSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataEncodedApiKeyAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions>
    {
        public OnYourDataEncodedApiKeyAuthenticationOptions(string encodedApiKey) { }
        public string EncodedApiKey { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEncodedApiKeyAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataEndpointVectorizationSource : Azure.AI.OpenAI.OnYourDataVectorizationSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource>
    {
        public OnYourDataEndpointVectorizationSource(System.Uri endpoint, Azure.AI.OpenAI.OnYourDataAuthenticationOptions authentication) { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataEndpointVectorizationSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataKeyAndKeyIdAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions>
    {
        public OnYourDataKeyAndKeyIdAuthenticationOptions(string key, string keyId) { }
        public string Key { get { throw null; } }
        public string KeyId { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataKeyAndKeyIdAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataModelIdVectorizationSource : Azure.AI.OpenAI.OnYourDataVectorizationSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource>
    {
        public OnYourDataModelIdVectorizationSource(string modelId) { }
        public string ModelId { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataModelIdVectorizationSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataSystemAssignedManagedIdentityAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions>
    {
        public OnYourDataSystemAssignedManagedIdentityAuthenticationOptions() { }
        Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataSystemAssignedManagedIdentityAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnYourDataUserAssignedManagedIdentityAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions>
    {
        public OnYourDataUserAssignedManagedIdentityAuthenticationOptions(string managedIdentityResourceId) { }
        public string ManagedIdentityResourceId { get { throw null; } }
        Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataUserAssignedManagedIdentityAuthenticationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OnYourDataVectorizationSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataVectorizationSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataVectorizationSource>
    {
        protected OnYourDataVectorizationSource() { }
        Azure.AI.OpenAI.OnYourDataVectorizationSource System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataVectorizationSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.OnYourDataVectorizationSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.OnYourDataVectorizationSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataVectorizationSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataVectorizationSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.OnYourDataVectorizationSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIClient
    {
        protected OpenAIClient() { }
        public OpenAIClient(string openAIApiKey) { }
        public OpenAIClient(string openAIApiKey, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.BinaryData> GenerateSpeechFromText(Azure.AI.OpenAI.SpeechGenerationOptions speechGenerationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GenerateSpeechFromTextAsync(Azure.AI.OpenAI.SpeechGenerationOptions speechGenerationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.AudioTranscription> GetAudioTranscription(Azure.AI.OpenAI.AudioTranscriptionOptions audioTranscriptionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.AudioTranscription>> GetAudioTranscriptionAsync(Azure.AI.OpenAI.AudioTranscriptionOptions audioTranscriptionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.AudioTranslation> GetAudioTranslation(Azure.AI.OpenAI.AudioTranslationOptions audioTranslationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.AudioTranslation>> GetAudioTranslationAsync(Azure.AI.OpenAI.AudioTranslationOptions audioTranslationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.ChatCompletions> GetChatCompletions(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.ChatCompletions>> GetChatCompletionsAsync(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.StreamingChatCompletionsUpdate> GetChatCompletionsStreaming(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.StreamingChatCompletionsUpdate>> GetChatCompletionsStreamingAsync(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.Completions> GetCompletionsStreaming(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.Completions>> GetCompletionsStreamingAsync(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Embeddings> GetEmbeddings(Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Embeddings>> GetEmbeddingsAsync(Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.ImageGenerations> GetImageGenerations(Azure.AI.OpenAI.ImageGenerationOptions imageGenerationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.ImageGenerations>> GetImageGenerationsAsync(Azure.AI.OpenAI.ImageGenerationOptions imageGenerationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenAIClientOptions : Azure.Core.ClientOptions
    {
        public OpenAIClientOptions(Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion.V2024_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
            V2023_05_15 = 2,
            V2023_06_01_Preview = 3,
            V2023_07_01_Preview = 4,
            V2024_02_15_Preview = 5,
            V2024_03_01_Preview = 6,
        }
    }
    public partial class PineconeChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.PineconeChatExtensionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeChatExtensionConfiguration>
    {
        public PineconeChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public string Environment { get { throw null; } set { } }
        public Azure.AI.OpenAI.PineconeFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } }
        Azure.AI.OpenAI.PineconeChatExtensionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.PineconeChatExtensionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.PineconeChatExtensionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.PineconeChatExtensionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeChatExtensionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeChatExtensionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeChatExtensionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PineconeFieldMappingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.PineconeFieldMappingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeFieldMappingOptions>
    {
        public PineconeFieldMappingOptions(System.Collections.Generic.IEnumerable<string> contentFieldNames) { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        Azure.AI.OpenAI.PineconeFieldMappingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.PineconeFieldMappingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.PineconeFieldMappingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.PineconeFieldMappingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeFieldMappingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeFieldMappingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.PineconeFieldMappingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpeechGenerationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.SpeechGenerationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.SpeechGenerationOptions>
    {
        public SpeechGenerationOptions() { }
        public SpeechGenerationOptions(string deploymentName, string input, Azure.AI.OpenAI.SpeechVoice voice) { }
        public string DeploymentName { get { throw null; } set { } }
        public string Input { get { throw null; } set { } }
        public Azure.AI.OpenAI.SpeechGenerationResponseFormat? ResponseFormat { get { throw null; } set { } }
        public float? Speed { get { throw null; } set { } }
        public Azure.AI.OpenAI.SpeechVoice Voice { get { throw null; } set { } }
        Azure.AI.OpenAI.SpeechGenerationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.SpeechGenerationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.SpeechGenerationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.SpeechGenerationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.SpeechGenerationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.SpeechGenerationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.SpeechGenerationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpeechGenerationResponseFormat : System.IEquatable<Azure.AI.OpenAI.SpeechGenerationResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpeechGenerationResponseFormat(string value) { throw null; }
        public static Azure.AI.OpenAI.SpeechGenerationResponseFormat Aac { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechGenerationResponseFormat Flac { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechGenerationResponseFormat Mp3 { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechGenerationResponseFormat Opus { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.SpeechGenerationResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.SpeechGenerationResponseFormat left, Azure.AI.OpenAI.SpeechGenerationResponseFormat right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.SpeechGenerationResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.SpeechGenerationResponseFormat left, Azure.AI.OpenAI.SpeechGenerationResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpeechVoice : System.IEquatable<Azure.AI.OpenAI.SpeechVoice>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpeechVoice(string value) { throw null; }
        public static Azure.AI.OpenAI.SpeechVoice Alloy { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechVoice Echo { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechVoice Fable { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechVoice Nova { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechVoice Onyx { get { throw null; } }
        public static Azure.AI.OpenAI.SpeechVoice Shimmer { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.SpeechVoice other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.SpeechVoice left, Azure.AI.OpenAI.SpeechVoice right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.SpeechVoice (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.SpeechVoice left, Azure.AI.OpenAI.SpeechVoice right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StopFinishDetails : Azure.AI.OpenAI.ChatFinishDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.StopFinishDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.StopFinishDetails>
    {
        internal StopFinishDetails() { }
        public string Stop { get { throw null; } }
        Azure.AI.OpenAI.StopFinishDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.StopFinishDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.StopFinishDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.StopFinishDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.StopFinishDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.StopFinishDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.StopFinishDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingChatCompletionsUpdate
    {
        internal StreamingChatCompletionsUpdate() { }
        public string AuthorName { get { throw null; } }
        public Azure.AI.OpenAI.AzureChatExtensionsMessageContext AzureExtensionsContext { get { throw null; } }
        public int? ChoiceIndex { get { throw null; } }
        public string ContentUpdate { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public string FunctionArgumentsUpdate { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.ChatRole? Role { get { throw null; } }
        public string SystemFingerprint { get { throw null; } }
        public Azure.AI.OpenAI.StreamingToolCallUpdate ToolCallUpdate { get { throw null; } }
    }
    public partial class StreamingFunctionToolCallUpdate : Azure.AI.OpenAI.StreamingToolCallUpdate
    {
        internal StreamingFunctionToolCallUpdate() { }
        public string ArgumentsUpdate { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class StreamingResponse<T> : System.Collections.Generic.IAsyncEnumerable<T>, System.IDisposable
    {
        internal StreamingResponse() { }
        public static Azure.AI.OpenAI.StreamingResponse<T> CreateFromResponse(Azure.Response response, System.Func<Azure.Response, System.Collections.Generic.IAsyncEnumerable<T>> asyncEnumerableProcessor) { throw null; }
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
    public static partial class AIOpenAIClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
