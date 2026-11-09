namespace Azure.Data.AI
{
    public partial class AzureDataAIContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureDataAIContext() { }
        public static Azure.Data.AI.AzureDataAIContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EmbeddingContentItem : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.EmbeddingContentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.EmbeddingContentItem>
    {
        public EmbeddingContentItem(Azure.Data.AI.EmbeddingContentType type) { }
        public string Content { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.Data.AI.EmbeddingContentType Type { get { throw null; } }
        public System.Uri Url { get { throw null; } set { } }
        protected virtual Azure.Data.AI.EmbeddingContentItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.EmbeddingContentItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.EmbeddingContentItem System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.EmbeddingContentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.EmbeddingContentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.EmbeddingContentItem System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.EmbeddingContentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.EmbeddingContentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.EmbeddingContentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingContentType : System.IEquatable<Azure.Data.AI.EmbeddingContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingContentType(string value) { throw null; }
        public static Azure.Data.AI.EmbeddingContentType Image { get { throw null; } }
        public static Azure.Data.AI.EmbeddingContentType Query { get { throw null; } }
        public static Azure.Data.AI.EmbeddingContentType Text { get { throw null; } }
        public bool Equals(Azure.Data.AI.EmbeddingContentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.EmbeddingContentType left, Azure.Data.AI.EmbeddingContentType right) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingContentType (string value) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingContentType? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.EmbeddingContentType left, Azure.Data.AI.EmbeddingContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingDelivery : System.IEquatable<Azure.Data.AI.EmbeddingDelivery>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingDelivery(string value) { throw null; }
        public static Azure.Data.AI.EmbeddingDelivery Inline { get { throw null; } }
        public static Azure.Data.AI.EmbeddingDelivery Link { get { throw null; } }
        public bool Equals(Azure.Data.AI.EmbeddingDelivery other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.EmbeddingDelivery left, Azure.Data.AI.EmbeddingDelivery right) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingDelivery (string value) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingDelivery? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.EmbeddingDelivery left, Azure.Data.AI.EmbeddingDelivery right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingEncodingFormat : System.IEquatable<Azure.Data.AI.EmbeddingEncodingFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingEncodingFormat(string value) { throw null; }
        public static Azure.Data.AI.EmbeddingEncodingFormat Base64 { get { throw null; } }
        public static Azure.Data.AI.EmbeddingEncodingFormat Float { get { throw null; } }
        public bool Equals(Azure.Data.AI.EmbeddingEncodingFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.EmbeddingEncodingFormat left, Azure.Data.AI.EmbeddingEncodingFormat right) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingEncodingFormat (string value) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingEncodingFormat? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.EmbeddingEncodingFormat left, Azure.Data.AI.EmbeddingEncodingFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingImageFormat : System.IEquatable<Azure.Data.AI.EmbeddingImageFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingImageFormat(string value) { throw null; }
        public static Azure.Data.AI.EmbeddingImageFormat Gif { get { throw null; } }
        public static Azure.Data.AI.EmbeddingImageFormat Jpeg { get { throw null; } }
        public static Azure.Data.AI.EmbeddingImageFormat Png { get { throw null; } }
        public static Azure.Data.AI.EmbeddingImageFormat Webp { get { throw null; } }
        public bool Equals(Azure.Data.AI.EmbeddingImageFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.EmbeddingImageFormat left, Azure.Data.AI.EmbeddingImageFormat right) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingImageFormat (string value) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingImageFormat? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.EmbeddingImageFormat left, Azure.Data.AI.EmbeddingImageFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingOutputDataType : System.IEquatable<Azure.Data.AI.EmbeddingOutputDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingOutputDataType(string value) { throw null; }
        public static Azure.Data.AI.EmbeddingOutputDataType Float16 { get { throw null; } }
        public static Azure.Data.AI.EmbeddingOutputDataType Float32 { get { throw null; } }
        public bool Equals(Azure.Data.AI.EmbeddingOutputDataType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.EmbeddingOutputDataType left, Azure.Data.AI.EmbeddingOutputDataType right) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingOutputDataType (string value) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingOutputDataType? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.EmbeddingOutputDataType left, Azure.Data.AI.EmbeddingOutputDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingVectorType : System.IEquatable<Azure.Data.AI.EmbeddingVectorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingVectorType(string value) { throw null; }
        public static Azure.Data.AI.EmbeddingVectorType Dense { get { throw null; } }
        public static Azure.Data.AI.EmbeddingVectorType DenseAndMulti { get { throw null; } }
        public static Azure.Data.AI.EmbeddingVectorType Multi { get { throw null; } }
        public bool Equals(Azure.Data.AI.EmbeddingVectorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.EmbeddingVectorType left, Azure.Data.AI.EmbeddingVectorType right) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingVectorType (string value) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingVectorType? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.EmbeddingVectorType left, Azure.Data.AI.EmbeddingVectorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmbeddingWarningCode : System.IEquatable<Azure.Data.AI.EmbeddingWarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmbeddingWarningCode(string value) { throw null; }
        public static Azure.Data.AI.EmbeddingWarningCode InputTruncated { get { throw null; } }
        public static Azure.Data.AI.EmbeddingWarningCode SasLongLived { get { throw null; } }
        public bool Equals(Azure.Data.AI.EmbeddingWarningCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.EmbeddingWarningCode left, Azure.Data.AI.EmbeddingWarningCode right) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingWarningCode (string value) { throw null; }
        public static implicit operator Azure.Data.AI.EmbeddingWarningCode? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.EmbeddingWarningCode left, Azure.Data.AI.EmbeddingWarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InferenceClient
    {
        protected InferenceClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public InferenceClient(Azure.Data.AI.InferenceClientSettings settings) { }
        public InferenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public InferenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Data.AI.InferenceClientOptions options) { }
        public InferenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public InferenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Data.AI.InferenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response MultiModalEmbed(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Data.AI.MultimodalEmbeddingResult> MultiModalEmbed(System.Collections.Generic.IEnumerable<Azure.Data.AI.EmbeddingContentItem> contents, string model = null, string modelVersion = null, Azure.Data.AI.EmbeddingVectorType? vectorType = default(Azure.Data.AI.EmbeddingVectorType?), int? dimensions = default(int?), int? multiDimensions = default(int?), int? maxNumVectors = default(int?), Azure.Data.AI.EmbeddingOutputDataType? outputDataType = default(Azure.Data.AI.EmbeddingOutputDataType?), Azure.Data.AI.EmbeddingEncodingFormat? encodingFormat = default(Azure.Data.AI.EmbeddingEncodingFormat?), Azure.Data.AI.EmbeddingDelivery? delivery = default(Azure.Data.AI.EmbeddingDelivery?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MultiModalEmbedAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AI.MultimodalEmbeddingResult>> MultiModalEmbedAsync(System.Collections.Generic.IEnumerable<Azure.Data.AI.EmbeddingContentItem> contents, string model = null, string modelVersion = null, Azure.Data.AI.EmbeddingVectorType? vectorType = default(Azure.Data.AI.EmbeddingVectorType?), int? dimensions = default(int?), int? multiDimensions = default(int?), int? maxNumVectors = default(int?), Azure.Data.AI.EmbeddingOutputDataType? outputDataType = default(Azure.Data.AI.EmbeddingOutputDataType?), Azure.Data.AI.EmbeddingEncodingFormat? encodingFormat = default(Azure.Data.AI.EmbeddingEncodingFormat?), Azure.Data.AI.EmbeddingDelivery? delivery = default(Azure.Data.AI.EmbeddingDelivery?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SemanticRerank(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Data.AI.SemanticRerankingResult> SemanticRerank(Azure.Data.AI.SemanticRerankingOptions request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SemanticRerankAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AI.SemanticRerankingResult>> SemanticRerankAsync(Azure.Data.AI.SemanticRerankingOptions request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class InferenceClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Data.AI.InferenceClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Data.AI.InferenceClientSettings> configureSettings) { throw null; }
    }
    public partial class InferenceClientOptions : Azure.Core.ClientOptions
    {
        public InferenceClientOptions(Azure.Data.AI.InferenceClientOptions.ServiceVersion version = Azure.Data.AI.InferenceClientOptions.ServiceVersion.V2026_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2026_10_30 = 1,
            V2026_11_01_Preview = 2,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class InferenceClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public InferenceClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Data.AI.InferenceClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public static partial class InferenceModelFactory
    {
        public static Azure.Data.AI.EmbeddingContentItem EmbeddingContentItem(string id = null, Azure.Data.AI.EmbeddingContentType type = default(Azure.Data.AI.EmbeddingContentType), string content = null, System.Uri url = null, string sasToken = null) { throw null; }
        public static Azure.Data.AI.LatencyResult LatencyResult(System.TimeSpan? dataPreprocessDuration = default(System.TimeSpan?), System.TimeSpan? inferenceDuration = default(System.TimeSpan?), System.TimeSpan? postProcessDuration = default(System.TimeSpan?)) { throw null; }
        public static Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding MultimodalDenseAndMultiVectorEmbedding(int index = 0, string id = null, Azure.Data.AI.EmbeddingContentType type = default(Azure.Data.AI.EmbeddingContentType), int? width = default(int?), int? height = default(int?), Azure.Data.AI.EmbeddingImageFormat? format = default(Azure.Data.AI.EmbeddingImageFormat?), long? tokens = default(long?), long? visualTokens = default(long?), bool? truncated = default(bool?), long? inputTokens = default(long?), System.Collections.Generic.IEnumerable<int> shape = null, System.BinaryData embedding = null, System.BinaryData multiEmbedding = null) { throw null; }
        public static Azure.Data.AI.MultimodalDenseEmbedding MultimodalDenseEmbedding(int index = 0, string id = null, Azure.Data.AI.EmbeddingContentType type = default(Azure.Data.AI.EmbeddingContentType), int? width = default(int?), int? height = default(int?), Azure.Data.AI.EmbeddingImageFormat? format = default(Azure.Data.AI.EmbeddingImageFormat?), long? tokens = default(long?), long? visualTokens = default(long?), bool? truncated = default(bool?), long? inputTokens = default(long?), System.BinaryData embedding = null) { throw null; }
        public static Azure.Data.AI.MultimodalEmbeddingItem MultimodalEmbeddingItem(int index = 0, string id = null, Azure.Data.AI.EmbeddingContentType type = default(Azure.Data.AI.EmbeddingContentType), string kind = null, int? width = default(int?), int? height = default(int?), Azure.Data.AI.EmbeddingImageFormat? format = default(Azure.Data.AI.EmbeddingImageFormat?), long? tokens = default(long?), long? visualTokens = default(long?), bool? truncated = default(bool?), long? inputTokens = default(long?)) { throw null; }
        public static Azure.Data.AI.MultimodalEmbeddingOutput MultimodalEmbeddingOutput(string id = null, System.Uri url = null, string sasToken = null, System.DateTimeOffset expiresOn = default(System.DateTimeOffset), int records = 0, long bytes = (long)0, string sha256 = null, string contentType = null) { throw null; }
        public static Azure.Data.AI.MultimodalEmbeddingResult MultimodalEmbeddingResult(string model = null, string modelVersion = null, Azure.Data.AI.EmbeddingOutputDataType outputDataType = default(Azure.Data.AI.EmbeddingOutputDataType), System.Collections.Generic.IEnumerable<Azure.Data.AI.MultimodalEmbeddingItem> data = null, Azure.Data.AI.MultimodalEmbeddingUsage usage = null, System.Collections.Generic.IEnumerable<Azure.Data.AI.MultimodalEmbeddingWarning> warnings = null, Azure.Data.AI.MultimodalEmbeddingOutput output = null) { throw null; }
        public static Azure.Data.AI.MultimodalEmbeddingUsage MultimodalEmbeddingUsage(long? promptTokens = default(long?), long? totalTokens = default(long?), long? textTokens = default(long?), int imageCount = 0, long? visualTokens = default(long?)) { throw null; }
        public static Azure.Data.AI.MultimodalEmbeddingWarning MultimodalEmbeddingWarning(Azure.Data.AI.EmbeddingWarningCode code = default(Azure.Data.AI.EmbeddingWarningCode), int? number = default(int?), int index = 0, long? inputTokens = default(long?), long? tokens = default(long?), string message = null) { throw null; }
        public static Azure.Data.AI.MultimodalMultiVectorEmbedding MultimodalMultiVectorEmbedding(int index = 0, string id = null, Azure.Data.AI.EmbeddingContentType type = default(Azure.Data.AI.EmbeddingContentType), int? width = default(int?), int? height = default(int?), Azure.Data.AI.EmbeddingImageFormat? format = default(Azure.Data.AI.EmbeddingImageFormat?), long? tokens = default(long?), long? visualTokens = default(long?), bool? truncated = default(bool?), long? inputTokens = default(long?), System.Collections.Generic.IEnumerable<int> shape = null, System.BinaryData multiEmbedding = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingMetadata SemanticRerankingMetadata(Azure.Data.AI.TokenUsageResult tokenUsage = null, Azure.Data.AI.LatencyResult latency = null, string modelName = null, string modelVersion = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingOptions SemanticRerankingOptions(string query = null, System.Collections.Generic.IEnumerable<string> documents = null, bool? returnDocuments = default(bool?), int? topK = default(int?), int? batchSize = default(int?), bool? sort = default(bool?), Azure.Data.AI.SemanticRerankingDocumentType? documentType = default(Azure.Data.AI.SemanticRerankingDocumentType?), System.Collections.Generic.IEnumerable<string> targetPaths = null, string model = null, bool? returnSentenceScore = default(bool?)) { throw null; }
        public static Azure.Data.AI.SemanticRerankingResult SemanticRerankingResult(System.Collections.Generic.IEnumerable<Azure.Data.AI.SemanticRerankingScore> scores = null, Azure.Data.AI.SemanticRerankingMetadata metadata = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingScore SemanticRerankingScore(int? index = default(int?), string document = null, float? score = default(float?), System.Collections.Generic.IEnumerable<Azure.Data.AI.SentenceScore> sentenceScores = null) { throw null; }
        public static Azure.Data.AI.SentenceScore SentenceScore(int index = 0, float score = 0f) { throw null; }
        public static Azure.Data.AI.TokenUsageResult TokenUsageResult(int? totalTokens = default(int?)) { throw null; }
    }
    public partial class LatencyResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.LatencyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.LatencyResult>
    {
        internal LatencyResult() { }
        public System.TimeSpan? DataPreprocessDuration { get { throw null; } }
        public System.TimeSpan? InferenceDuration { get { throw null; } }
        public System.TimeSpan? PostProcessDuration { get { throw null; } }
        protected virtual Azure.Data.AI.LatencyResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.LatencyResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.LatencyResult System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.LatencyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.LatencyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.LatencyResult System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.LatencyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.LatencyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.LatencyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultimodalDenseAndMultiVectorEmbedding : Azure.Data.AI.MultimodalEmbeddingItem, System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding>
    {
        internal MultimodalDenseAndMultiVectorEmbedding() { }
        public System.BinaryData Embedding { get { throw null; } }
        public System.BinaryData MultiEmbedding { get { throw null; } }
        public System.Collections.Generic.IList<int> Shape { get { throw null; } }
        protected override Azure.Data.AI.MultimodalEmbeddingItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Data.AI.MultimodalEmbeddingItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseAndMultiVectorEmbedding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultimodalDenseEmbedding : Azure.Data.AI.MultimodalEmbeddingItem, System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalDenseEmbedding>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseEmbedding>
    {
        internal MultimodalDenseEmbedding() { }
        public System.BinaryData Embedding { get { throw null; } }
        protected override Azure.Data.AI.MultimodalEmbeddingItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Data.AI.MultimodalEmbeddingItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalDenseEmbedding System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalDenseEmbedding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalDenseEmbedding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalDenseEmbedding System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseEmbedding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseEmbedding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalDenseEmbedding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MultimodalEmbeddingItem : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingItem>
    {
        internal MultimodalEmbeddingItem() { }
        public Azure.Data.AI.EmbeddingImageFormat? Format { get { throw null; } }
        public int? Height { get { throw null; } }
        public string Id { get { throw null; } }
        public int Index { get { throw null; } }
        public long? InputTokens { get { throw null; } }
        public long? Tokens { get { throw null; } }
        public bool? Truncated { get { throw null; } }
        public Azure.Data.AI.EmbeddingContentType Type { get { throw null; } }
        public long? VisualTokens { get { throw null; } }
        public int? Width { get { throw null; } }
        protected virtual Azure.Data.AI.MultimodalEmbeddingItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.MultimodalEmbeddingItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalEmbeddingItem System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalEmbeddingItem System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultimodalEmbeddingOutput : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingOutput>
    {
        internal MultimodalEmbeddingOutput() { }
        public long Bytes { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Id { get { throw null; } }
        public int Records { get { throw null; } }
        public string SasToken { get { throw null; } }
        public string Sha256 { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Data.AI.MultimodalEmbeddingOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.MultimodalEmbeddingOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalEmbeddingOutput System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalEmbeddingOutput System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultimodalEmbeddingResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingResult>
    {
        internal MultimodalEmbeddingResult() { }
        public System.Collections.Generic.IList<Azure.Data.AI.MultimodalEmbeddingItem> Data { get { throw null; } }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public string Object { get { throw null; } }
        public Azure.Data.AI.MultimodalEmbeddingOutput Output { get { throw null; } }
        public Azure.Data.AI.EmbeddingOutputDataType OutputDataType { get { throw null; } }
        public Azure.Data.AI.MultimodalEmbeddingUsage Usage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Data.AI.MultimodalEmbeddingWarning> Warnings { get { throw null; } }
        protected virtual Azure.Data.AI.MultimodalEmbeddingResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Data.AI.MultimodalEmbeddingResult (Azure.Response response) { throw null; }
        protected virtual Azure.Data.AI.MultimodalEmbeddingResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalEmbeddingResult System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalEmbeddingResult System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultimodalEmbeddingUsage : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingUsage>
    {
        internal MultimodalEmbeddingUsage() { }
        public int ImageCount { get { throw null; } }
        public long? PromptTokens { get { throw null; } }
        public long? TextTokens { get { throw null; } }
        public long? TotalTokens { get { throw null; } }
        public long? VisualTokens { get { throw null; } }
        protected virtual Azure.Data.AI.MultimodalEmbeddingUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.MultimodalEmbeddingUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalEmbeddingUsage System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalEmbeddingUsage System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultimodalEmbeddingWarning : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingWarning>
    {
        internal MultimodalEmbeddingWarning() { }
        public Azure.Data.AI.EmbeddingWarningCode Code { get { throw null; } }
        public int Index { get { throw null; } }
        public long? InputTokens { get { throw null; } }
        public string Message { get { throw null; } }
        public int? Number { get { throw null; } }
        public long? Tokens { get { throw null; } }
        protected virtual Azure.Data.AI.MultimodalEmbeddingWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.MultimodalEmbeddingWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalEmbeddingWarning System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalEmbeddingWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalEmbeddingWarning System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalEmbeddingWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultimodalMultiVectorEmbedding : Azure.Data.AI.MultimodalEmbeddingItem, System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalMultiVectorEmbedding>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalMultiVectorEmbedding>
    {
        internal MultimodalMultiVectorEmbedding() { }
        public System.BinaryData MultiEmbedding { get { throw null; } }
        public System.Collections.Generic.IList<int> Shape { get { throw null; } }
        protected override Azure.Data.AI.MultimodalEmbeddingItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Data.AI.MultimodalEmbeddingItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MultimodalMultiVectorEmbedding System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalMultiVectorEmbedding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MultimodalMultiVectorEmbedding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MultimodalMultiVectorEmbedding System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalMultiVectorEmbedding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalMultiVectorEmbedding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MultimodalMultiVectorEmbedding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SemanticRerankingDocumentType : System.IEquatable<Azure.Data.AI.SemanticRerankingDocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SemanticRerankingDocumentType(string value) { throw null; }
        public static Azure.Data.AI.SemanticRerankingDocumentType Json { get { throw null; } }
        public static Azure.Data.AI.SemanticRerankingDocumentType Text { get { throw null; } }
        public bool Equals(Azure.Data.AI.SemanticRerankingDocumentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.SemanticRerankingDocumentType left, Azure.Data.AI.SemanticRerankingDocumentType right) { throw null; }
        public static implicit operator Azure.Data.AI.SemanticRerankingDocumentType (string value) { throw null; }
        public static implicit operator Azure.Data.AI.SemanticRerankingDocumentType? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.SemanticRerankingDocumentType left, Azure.Data.AI.SemanticRerankingDocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SemanticRerankingMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetadata>
    {
        internal SemanticRerankingMetadata() { }
        public Azure.Data.AI.LatencyResult Latency { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.Data.AI.TokenUsageResult TokenUsage { get { throw null; } }
        protected virtual Azure.Data.AI.SemanticRerankingMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.SemanticRerankingMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.SemanticRerankingMetadata System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.SemanticRerankingMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticRerankingOptions : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingOptions>
    {
        public SemanticRerankingOptions(string query, System.Collections.Generic.IEnumerable<string> documents) { }
        public int? BatchSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Documents { get { throw null; } }
        public Azure.Data.AI.SemanticRerankingDocumentType? DocumentType { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public bool? ReturnDocuments { get { throw null; } set { } }
        public bool? ReturnSentenceScore { get { throw null; } set { } }
        public bool? Sort { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TargetPaths { get { throw null; } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.Data.AI.SemanticRerankingOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Data.AI.SemanticRerankingOptions semanticRerankingOptions) { throw null; }
        protected virtual Azure.Data.AI.SemanticRerankingOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.SemanticRerankingOptions System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.SemanticRerankingOptions System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticRerankingResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingResult>
    {
        internal SemanticRerankingResult() { }
        public Azure.Data.AI.SemanticRerankingMetadata Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Data.AI.SemanticRerankingScore> Scores { get { throw null; } }
        protected virtual Azure.Data.AI.SemanticRerankingResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Data.AI.SemanticRerankingResult (Azure.Response response) { throw null; }
        protected virtual Azure.Data.AI.SemanticRerankingResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.SemanticRerankingResult System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.SemanticRerankingResult System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticRerankingScore : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingScore>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingScore>
    {
        internal SemanticRerankingScore() { }
        public string Document { get { throw null; } }
        public int? Index { get { throw null; } }
        public float? Score { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Data.AI.SentenceScore> SentenceScores { get { throw null; } }
        protected virtual Azure.Data.AI.SemanticRerankingScore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.SemanticRerankingScore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.SemanticRerankingScore System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingScore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingScore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.SemanticRerankingScore System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingScore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingScore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingScore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentenceScore : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SentenceScore>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SentenceScore>
    {
        internal SentenceScore() { }
        public int Index { get { throw null; } }
        public float Score { get { throw null; } }
        protected virtual Azure.Data.AI.SentenceScore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.SentenceScore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.SentenceScore System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SentenceScore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SentenceScore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.SentenceScore System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SentenceScore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SentenceScore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SentenceScore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenUsageResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.TokenUsageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.TokenUsageResult>
    {
        internal TokenUsageResult() { }
        public int? TotalTokens { get { throw null; } }
        protected virtual Azure.Data.AI.TokenUsageResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.TokenUsageResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.TokenUsageResult System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.TokenUsageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.TokenUsageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.TokenUsageResult System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.TokenUsageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.TokenUsageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.TokenUsageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
