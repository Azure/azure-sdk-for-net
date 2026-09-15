namespace Azure.Data.AI
{
    public static partial class AIModelFactory
    {
        public static Azure.Data.AI.LatencyResult LatencyResult(float? dataPreprocessTime = default(float?), float? inferenceTime = default(float?), float? postProcessTime = default(float?)) { throw null; }
        public static Azure.Data.AI.MetaResult MetaResult(Azure.Data.AI.TokenUsageResult tokenUsage = null, Azure.Data.AI.LatencyResult latency = null, string modelName = null, string modelVersion = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingInferenceRequest SemanticRerankingInferenceRequest(string query = null, System.Collections.Generic.IEnumerable<string> documents = null, bool? returnDocuments = default(bool?), int? topK = default(int?), int? batchSize = default(int?), bool? sort = default(bool?), Azure.Data.AI.DocumentType? documentType = default(Azure.Data.AI.DocumentType?), string targetPaths = null, string model = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingResult SemanticRerankingResult(System.Collections.Generic.IEnumerable<Azure.Data.AI.SemanticRerankingScore> scores = null, Azure.Data.AI.MetaResult meta = null) { throw null; }
        public static Azure.Data.AI.SemanticRerankingScore SemanticRerankingScore(int? index = default(int?), string document = null, float? score = default(float?)) { throw null; }
        public static Azure.Data.AI.TokenUsageResult TokenUsageResult(int? totalTokens = default(int?)) { throw null; }
    }
    public partial class AzureDataAIContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureDataAIContext() { }
        public static Azure.Data.AI.AzureDataAIContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DataInference
    {
        protected DataInference() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response SemanticRerank(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Data.AI.SemanticRerankingResult> SemanticRerank(Azure.Data.AI.SemanticRerankingInferenceRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SemanticRerankAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AI.SemanticRerankingResult>> SemanticRerankAsync(Azure.Data.AI.SemanticRerankingInferenceRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentType : System.IEquatable<Azure.Data.AI.DocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentType(string value) { throw null; }
        public static Azure.Data.AI.DocumentType Json { get { throw null; } }
        public static Azure.Data.AI.DocumentType Text { get { throw null; } }
        public bool Equals(Azure.Data.AI.DocumentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AI.DocumentType left, Azure.Data.AI.DocumentType right) { throw null; }
        public static implicit operator Azure.Data.AI.DocumentType (string value) { throw null; }
        public static implicit operator Azure.Data.AI.DocumentType? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AI.DocumentType left, Azure.Data.AI.DocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InferenceServiceClient
    {
        protected InferenceServiceClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public InferenceServiceClient(Azure.Data.AI.InferenceServiceClientSettings settings) { }
        public InferenceServiceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public InferenceServiceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Data.AI.InferenceServiceClientOptions options) { }
        public InferenceServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public InferenceServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Data.AI.InferenceServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Data.AI.DataInference GetDataInferenceClient() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class InferenceServiceClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddInferenceServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddInferenceServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Data.AI.InferenceServiceClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedInferenceServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedInferenceServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Data.AI.InferenceServiceClientSettings> configureSettings) { throw null; }
    }
    public partial class InferenceServiceClientOptions : Azure.Core.ClientOptions
    {
        public InferenceServiceClientOptions(Azure.Data.AI.InferenceServiceClientOptions.ServiceVersion version = Azure.Data.AI.InferenceServiceClientOptions.ServiceVersion.V2026_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2026_09_01_Preview = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class InferenceServiceClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public InferenceServiceClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Data.AI.InferenceServiceClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class LatencyResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.LatencyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.LatencyResult>
    {
        internal LatencyResult() { }
        public float? DataPreprocessTime { get { throw null; } }
        public float? InferenceTime { get { throw null; } }
        public float? PostProcessTime { get { throw null; } }
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
    public partial class MetaResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MetaResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MetaResult>
    {
        internal MetaResult() { }
        public Azure.Data.AI.LatencyResult Latency { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.Data.AI.TokenUsageResult TokenUsage { get { throw null; } }
        protected virtual Azure.Data.AI.MetaResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AI.MetaResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AI.MetaResult System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MetaResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.MetaResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AI.MetaResult System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MetaResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MetaResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.MetaResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticRerankingInferenceRequest : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingInferenceRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingInferenceRequest>
    {
        public SemanticRerankingInferenceRequest(string query, System.Collections.Generic.IEnumerable<string> documents) { }
        public int? BatchSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Documents { get { throw null; } }
        public Azure.Data.AI.DocumentType? DocumentType { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public bool? ReturnDocuments { get { throw null; } set { } }
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
    public partial class SemanticRerankingResult : System.ClientModel.Primitives.IJsonModel<Azure.Data.AI.SemanticRerankingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AI.SemanticRerankingResult>
    {
        internal SemanticRerankingResult() { }
        public Azure.Data.AI.MetaResult Meta { get { throw null; } }
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
