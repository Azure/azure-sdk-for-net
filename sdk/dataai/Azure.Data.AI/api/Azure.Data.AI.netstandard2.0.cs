namespace Azure.Data.AI
{
    public static partial class AIModelFactory
    {
        public static Azure.Data.AI.LatencyResult LatencyResult(System.TimeSpan? dataPreprocessTime = default(System.TimeSpan?), System.TimeSpan? inferenceTime = default(System.TimeSpan?), System.TimeSpan? postProcessTime = default(System.TimeSpan?)) { throw null; }
        public static Azure.Data.AI.SemanticRerankingInferenceRequest SemanticRerankingInferenceRequest(string query = null, System.Collections.Generic.IEnumerable<string> documents = null, bool? returnDocuments = default(bool?), int? topK = default(int?), int? batchSize = default(int?), bool? sort = default(bool?), Azure.Data.AI.SemanticRerankingDocumentType? documentType = default(Azure.Data.AI.SemanticRerankingDocumentType?), string targetPaths = null, string model = null, bool? returnSentenceScore = default(bool?)) { throw null; }
        public static Azure.Data.AI.SemanticRerankingMetaResult SemanticRerankingMetaResult(Azure.Data.AI.TokenUsageResult tokenUsage = null, Azure.Data.AI.LatencyResult latency = null, string modelName = null, string modelVersion = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingResult SemanticRerankingResult(System.Collections.Generic.IEnumerable<Azure.Data.AI.SemanticRerankingScore> scores = null, Azure.Data.AI.SemanticRerankingMetaResult meta = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingScore SemanticRerankingScore(int? index = default(int?), string document = null, float? score = default(float?), System.Collections.Generic.IEnumerable<Azure.Data.AI.SentenceScore> sentenceScores = null) { throw null; }
        public static Azure.Data.AI.SentenceScore SentenceScore(int index = 0, float score = 0f) { throw null; }
        public static Azure.Data.AI.TokenUsageResult TokenUsageResult(int? totalTokens = default(int?)) { throw null; }
    }
    public partial class AzureDataAIContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureDataAIContext() { }
        public static Azure.Data.AI.AzureDataAIContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class InferenceClient
    {
        protected InferenceClient() { }
        public InferenceClient(Azure.Data.AI.InferenceClientSettings settings) { }
        public InferenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public InferenceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Data.AI.InferenceClientOptions options) { }
        public InferenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public InferenceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Data.AI.InferenceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response SemanticRerank(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Data.AI.SemanticRerankingResult> SemanticRerank(Azure.Data.AI.SemanticRerankingInferenceRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SemanticRerankAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AI.SemanticRerankingResult>> SemanticRerankAsync(Azure.Data.AI.SemanticRerankingInferenceRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class InferenceClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Data.AI.InferenceClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedInferenceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Data.AI.InferenceClientSettings> configureSettings) { throw null; }
    }
    public partial class InferenceClientOptions : Azure.Core.ClientOptions
    {
        public InferenceClientOptions(Azure.Data.AI.InferenceClientOptions.ServiceVersion version = Azure.Data.AI.InferenceClientOptions.ServiceVersion.V2026_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2026_09_01_Preview = 1,
        }
    }
    public partial class InferenceClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public InferenceClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Data.AI.InferenceClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class LatencyResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.LatencyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.LatencyResult>
    {
        internal LatencyResult() { }
        public System.TimeSpan? DataPreprocessTime { get { throw null; } }
        public System.TimeSpan? InferenceTime { get { throw null; } }
        public System.TimeSpan? PostProcessTime { get { throw null; } }
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
    public partial class SemanticRerankingInferenceRequest : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingInferenceRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingInferenceRequest>
    {
        public SemanticRerankingInferenceRequest(string query, System.Collections.Generic.IEnumerable<string> documents) { }
        public int? BatchSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Documents { get { throw null; } }
        public Azure.Data.AI.SemanticRerankingDocumentType? DocumentType { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public bool? ReturnDocuments { get { throw null; } set { } }
        public bool? ReturnSentenceScore { get { throw null; } set { } }
        public bool? Sort { get { throw null; } set { } }
        public string TargetPaths { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.Data.AI.SemanticRerankingInferenceRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Data.AI.SemanticRerankingInferenceRequest semanticRerankingInferenceRequest) { throw null; }
        protected virtual Azure.Data.AI.SemanticRerankingInferenceRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.SemanticRerankingInferenceRequest System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingInferenceRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingInferenceRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.SemanticRerankingInferenceRequest System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingInferenceRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingInferenceRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingInferenceRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticRerankingMetaResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingMetaResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetaResult>
    {
        internal SemanticRerankingMetaResult() { }
        public Azure.Data.AI.LatencyResult Latency { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.Data.AI.TokenUsageResult TokenUsage { get { throw null; } }
        protected virtual Azure.Data.AI.SemanticRerankingMetaResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.SemanticRerankingMetaResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.SemanticRerankingMetaResult System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingMetaResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingMetaResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.SemanticRerankingMetaResult System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetaResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetaResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingMetaResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticRerankingResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingResult>
    {
        internal SemanticRerankingResult() { }
        public Azure.Data.AI.SemanticRerankingMetaResult Meta { get { throw null; } }
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
