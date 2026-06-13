namespace Azure.AI.Language.Documents
{
    public partial class AbstractiveSummarizationOperationResult : Azure.AI.Language.Documents.AnalyzeDocumentsLROResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult>
    {
        internal AbstractiveSummarizationOperationResult() { }
        public Azure.AI.Language.Documents.AnalyzeDocumentsResult Results { get { throw null; } }
        protected override Azure.AI.Language.Documents.AnalyzeDocumentsLROResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.AnalyzeDocumentsLROResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeDocumentsClient
    {
        protected AnalyzeDocumentsClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public AnalyzeDocumentsClient(Azure.AI.Language.Documents.AnalyzeDocumentsClientSettings settings) { }
        public AnalyzeDocumentsClient(string endpoint, Azure.AzureKeyCredential credential) { }
        public AnalyzeDocumentsClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions options) { }
        public AnalyzeDocumentsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AnalyzeDocumentsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AnalyzeDocumentsCancelOperation(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation AnalyzeDocumentsCancelOperation(Azure.WaitUntil waitUntil, System.Guid jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeDocumentsCancelOperationAsync(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeDocumentsCancelOperationAsync(Azure.WaitUntil waitUntil, System.Guid jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeDocumentsSubmitOperation(Azure.WaitUntil waitUntil, Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput analyzeDocumentOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeDocumentsSubmitOperation(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeDocumentsSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput analyzeDocumentOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeDocumentsSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAnalyzeDocumentsJobStatus(System.Guid jobId, bool? showStats, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Documents.AnalyzeDocumentsJobState> GetAnalyzeDocumentsJobStatus(System.Guid jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnalyzeDocumentsJobStatusAsync(System.Guid jobId, bool? showStats, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>> GetAnalyzeDocumentsJobStatusAsync(System.Guid jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalyzeDocumentsClientOptions : Azure.Core.ClientOptions
    {
        public AnalyzeDocumentsClientOptions(Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions.ServiceVersion version = Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions.ServiceVersion.V2026_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2024_11_15_Preview = 1,
            V2026_05_01 = 2,
            V2026_05_15_Preview = 3,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class AnalyzeDocumentsClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public AnalyzeDocumentsClientSettings() { }
        public string Endpoint { get { throw null; } set { } }
        public Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class AnalyzeDocumentsDocumentError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError>
    {
        internal AnalyzeDocumentsDocumentError() { }
        public Azure.AI.Language.Documents.AnalyzeDocumentsError Error { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeDocumentsError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsError>
    {
        internal AnalyzeDocumentsError() { }
        public Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.AnalyzeDocumentsError> Details { get { throw null; } }
        public Azure.AI.Language.Documents.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AnalyzeDocumentsError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AnalyzeDocumentsError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeDocumentsErrorCode : System.IEquatable<Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeDocumentsErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode AzureCognitiveSearchIndexLimitReached { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode AzureCognitiveSearchIndexNotFound { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode Conflict { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode Forbidden { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode NotFound { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode OperationNotFound { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode ProjectNotFound { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode QuotaExceeded { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode Timeout { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode TooManyRequests { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode Unauthorized { get { throw null; } }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode Warning { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode left, Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode left, Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeDocumentsJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>
    {
        internal AnalyzeDocumentsJobState() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.AnalyzeDocumentsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Guid JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAt { get { throw null; } }
        public string NextLink { get { throw null; } }
        public Azure.AI.Language.Documents.RequestStatistics Statistics { get { throw null; } }
        public Azure.AI.Language.Documents.DocumentActionState Status { get { throw null; } }
        public Azure.AI.Language.Documents.DocumentActions Tasks { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsJobState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.Documents.AnalyzeDocumentsJobState (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsJobState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AnalyzeDocumentsJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AnalyzeDocumentsJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeDocumentsLROResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult>
    {
        internal AnalyzeDocumentsLROResult() { }
        public System.DateTimeOffset LastUpdateDateTime { get { throw null; } }
        public Azure.AI.Language.Documents.DocumentActionState Status { get { throw null; } }
        public string TaskName { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsLROResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsLROResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AnalyzeDocumentsLROResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AnalyzeDocumentsLROResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeDocumentsOperationAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction>
    {
        internal AnalyzeDocumentsOperationAction() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeDocumentsOperationInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput>
    {
        public AnalyzeDocumentsOperationInput(Azure.AI.Language.Documents.MultiLanguageDocumentInput documentsInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction> actions) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction> Actions { get { throw null; } }
        public string DefaultLanguage { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.AI.Language.Documents.MultiLanguageDocumentInput DocumentsInput { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput analyzeDocumentsOperationInput) { throw null; }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeDocumentsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsResult>
    {
        internal AnalyzeDocumentsResult() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult> Documents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Documents.RequestStatistics Statistics { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.AnalyzeDocumentsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AnalyzeDocumentsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AnalyzeDocumentsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AnalyzeDocumentsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AnalyzeDocumentsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAILanguageDocumentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageDocumentsContext() { }
        public static Azure.AI.Language.Documents.AzureAILanguageDocumentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureBlobDocumentLocation : Azure.AI.Language.Documents.DocumentLocation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureBlobDocumentLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureBlobDocumentLocation>
    {
        public AzureBlobDocumentLocation(string location) { }
        public override string Location { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        protected override Azure.AI.Language.Documents.DocumentLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.DocumentLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AzureBlobDocumentLocation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureBlobDocumentLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureBlobDocumentLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AzureBlobDocumentLocation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureBlobDocumentLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureBlobDocumentLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureBlobDocumentLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContainerDocumentLocation : Azure.AI.Language.Documents.DocumentLocation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureContainerDocumentLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerDocumentLocation>
    {
        public AzureContainerDocumentLocation(string location) { }
        public override string Location { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        protected override Azure.AI.Language.Documents.DocumentLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.DocumentLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AzureContainerDocumentLocation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureContainerDocumentLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureContainerDocumentLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AzureContainerDocumentLocation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerDocumentLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerDocumentLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerDocumentLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContainerFolderDocumentLocation : Azure.AI.Language.Documents.DocumentLocation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation>
    {
        public AzureContainerFolderDocumentLocation(string location) { }
        public override string Location { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        protected override Azure.AI.Language.Documents.DocumentLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.DocumentLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BaseRedactionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.BaseRedactionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.BaseRedactionPolicy>
    {
        internal BaseRedactionPolicy() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.PiiCategories> EntityTypes { get { throw null; } }
        public bool? IsDefault { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        protected virtual Azure.AI.Language.Documents.BaseRedactionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.BaseRedactionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.BaseRedactionPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.BaseRedactionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.BaseRedactionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.BaseRedactionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.BaseRedactionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.BaseRedactionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.BaseRedactionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CharacterMaskPolicy : Azure.AI.Language.Documents.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.CharacterMaskPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.CharacterMaskPolicy>
    {
        public CharacterMaskPolicy() { }
        public Azure.AI.Language.Documents.RedactionCharacter? RedactionCharacter { get { throw null; } set { } }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.CharacterMaskPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.CharacterMaskPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.CharacterMaskPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.CharacterMaskPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.CharacterMaskPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.CharacterMaskPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.CharacterMaskPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidenceScoreThreshold : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ConfidenceScoreThreshold>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThreshold>
    {
        public ConfidenceScoreThreshold(float @default) { }
        public float Default { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride> Overrides { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.ConfidenceScoreThreshold JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.ConfidenceScoreThreshold PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.ConfidenceScoreThreshold System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ConfidenceScoreThreshold>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ConfidenceScoreThreshold>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.ConfidenceScoreThreshold System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThreshold>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThreshold>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThreshold>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidenceScoreThresholdOverride : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride>
    {
        public ConfidenceScoreThresholdOverride(Azure.AI.Language.Documents.PiiCategories entity, float value, string language) { }
        public Azure.AI.Language.Documents.PiiCategories Entity { get { throw null; } }
        public string Language { get { throw null; } }
        public float Value { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentActions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentActions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentActions>
    {
        internal DocumentActions() { }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult> Items { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.DocumentActions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.DocumentActions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.DocumentActions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentActions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentActions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.DocumentActions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentActions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentActions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentActions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentActionState : System.IEquatable<Azure.AI.Language.Documents.DocumentActionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentActionState(string value) { throw null; }
        public static Azure.AI.Language.Documents.DocumentActionState Cancelled { get { throw null; } }
        public static Azure.AI.Language.Documents.DocumentActionState Cancelling { get { throw null; } }
        public static Azure.AI.Language.Documents.DocumentActionState Failed { get { throw null; } }
        public static Azure.AI.Language.Documents.DocumentActionState NotStarted { get { throw null; } }
        public static Azure.AI.Language.Documents.DocumentActionState PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Documents.DocumentActionState Running { get { throw null; } }
        public static Azure.AI.Language.Documents.DocumentActionState Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.DocumentActionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.DocumentActionState left, Azure.AI.Language.Documents.DocumentActionState right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.DocumentActionState (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.DocumentActionState? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.DocumentActionState left, Azure.AI.Language.Documents.DocumentActionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentAnalysisDocumentResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult>
    {
        internal DocumentAnalysisDocumentResult() { }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Documents.DocumentLocation Source { get { throw null; } }
        public Azure.AI.Language.Documents.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.DocumentLocation> Target { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.DocumentWarning> Warnings { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.DocumentAnalysisDocumentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.DocumentAnalysisDocumentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.DocumentAnalysisDocumentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.DocumentAnalysisDocumentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DocumentLocation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentLocation>
    {
        internal DocumentLocation() { }
        public virtual string Location { get { throw null; } set { } }
        protected virtual Azure.AI.Language.Documents.DocumentLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.DocumentLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.DocumentLocation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.DocumentLocation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentStatistics>
    {
        internal DocumentStatistics() { }
        public int CharactersCount { get { throw null; } }
        public int TransactionsCount { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.DocumentStatistics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.DocumentStatistics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.DocumentStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.DocumentStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentWarning>
    {
        internal DocumentWarning() { }
        public Azure.AI.Language.Documents.WarningCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string TargetRef { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.DocumentWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.DocumentWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.DocumentWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.DocumentWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.DocumentWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.DocumentWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityMaskPolicy : Azure.AI.Language.Documents.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntityMaskPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntityMaskPolicy>
    {
        public EntityMaskPolicy() { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.EntityMaskPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntityMaskPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntityMaskPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.EntityMaskPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntityMaskPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntityMaskPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntityMaskPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitySynonym : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntitySynonym>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonym>
    {
        public EntitySynonym(string synonym) { }
        public string Language { get { throw null; } set { } }
        public string Synonym { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.EntitySynonym JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.EntitySynonym PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.EntitySynonym System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntitySynonym>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntitySynonym>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.EntitySynonym System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonym>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonym>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonym>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitySynonyms : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntitySynonyms>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonyms>
    {
        public EntitySynonyms(Azure.AI.Language.Documents.PiiCategories entityType, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.EntitySynonym> synonyms) { }
        public Azure.AI.Language.Documents.PiiCategories EntityType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.EntitySynonym> Synonyms { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.EntitySynonyms JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.EntitySynonyms PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.EntitySynonyms System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntitySynonyms>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.EntitySynonyms>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.EntitySynonyms System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonyms>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonyms>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.EntitySynonyms>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InnerErrorCode : System.IEquatable<Azure.AI.Language.Documents.InnerErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InnerErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Documents.InnerErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode EmptyRequest { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode ExtractionFailure { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode InvalidCountryHint { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode InvalidDocument { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode InvalidDocumentBatch { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode InvalidParameterValue { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode InvalidRequestBodyFormat { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode KnowledgeBaseNotFound { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode MissingInputDocuments { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode ModelVersionIncorrect { get { throw null; } }
        public static Azure.AI.Language.Documents.InnerErrorCode UnsupportedLanguageCode { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.InnerErrorCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.InnerErrorCode left, Azure.AI.Language.Documents.InnerErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.InnerErrorCode (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.InnerErrorCode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.InnerErrorCode left, Azure.AI.Language.Documents.InnerErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InnerErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.InnerErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.InnerErrorModel>
    {
        internal InnerErrorModel() { }
        public Azure.AI.Language.Documents.InnerErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Details { get { throw null; } }
        public Azure.AI.Language.Documents.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.InnerErrorModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.InnerErrorModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.InnerErrorModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.InnerErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.InnerErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.InnerErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.InnerErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.InnerErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.InnerErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class LanguageDocumentsModelFactory
    {
        public static Azure.AI.Language.Documents.AbstractiveSummarizationOperationResult AbstractiveSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Documents.DocumentActionState status = default(Azure.AI.Language.Documents.DocumentActionState), string taskName = null, Azure.AI.Language.Documents.AnalyzeDocumentsResult results = null) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError AnalyzeDocumentsDocumentError(string id = null, Azure.AI.Language.Documents.AnalyzeDocumentsError error = null) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsError AnalyzeDocumentsError(Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode code = default(Azure.AI.Language.Documents.AnalyzeDocumentsErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.AnalyzeDocumentsError> details = null, Azure.AI.Language.Documents.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsJobState AnalyzeDocumentsJobState(string displayName = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.Guid jobId = default(System.Guid), System.DateTimeOffset lastUpdatedAt = default(System.DateTimeOffset), Azure.AI.Language.Documents.DocumentActionState status = default(Azure.AI.Language.Documents.DocumentActionState), System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.AnalyzeDocumentsError> errors = null, string nextLink = null, Azure.AI.Language.Documents.DocumentActions tasks = null, Azure.AI.Language.Documents.RequestStatistics statistics = null) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsLROResult AnalyzeDocumentsLROResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Documents.DocumentActionState status = default(Azure.AI.Language.Documents.DocumentActionState), string taskName = null, string kind = null) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction AnalyzeDocumentsOperationAction(string name = null, string kind = null) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsOperationInput AnalyzeDocumentsOperationInput(string displayName = null, Azure.AI.Language.Documents.MultiLanguageDocumentInput documentsInput = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction> actions = null, string defaultLanguage = null) { throw null; }
        public static Azure.AI.Language.Documents.AnalyzeDocumentsResult AnalyzeDocumentsResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.AnalyzeDocumentsDocumentError> errors = null, Azure.AI.Language.Documents.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.DocumentAnalysisDocumentResult> documents = null) { throw null; }
        public static Azure.AI.Language.Documents.AzureBlobDocumentLocation AzureBlobDocumentLocation(string location = null, string managedIdentityClientId = null) { throw null; }
        public static Azure.AI.Language.Documents.AzureContainerDocumentLocation AzureContainerDocumentLocation(string location = null, string managedIdentityClientId = null) { throw null; }
        public static Azure.AI.Language.Documents.AzureContainerFolderDocumentLocation AzureContainerFolderDocumentLocation(string location = null, string managedIdentityClientId = null) { throw null; }
        public static Azure.AI.Language.Documents.BaseRedactionPolicy BaseRedactionPolicy(string policyKind = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategories> entityTypes = null, string policyName = null, bool? isDefault = default(bool?)) { throw null; }
        public static Azure.AI.Language.Documents.CharacterMaskPolicy CharacterMaskPolicy(System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategories> entityTypes = null, string policyName = null, bool? isDefault = default(bool?), Azure.AI.Language.Documents.RedactionCharacter? redactionCharacter = default(Azure.AI.Language.Documents.RedactionCharacter?)) { throw null; }
        public static Azure.AI.Language.Documents.ConfidenceScoreThreshold ConfidenceScoreThreshold(float @default = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride> overrides = null) { throw null; }
        public static Azure.AI.Language.Documents.ConfidenceScoreThresholdOverride ConfidenceScoreThresholdOverride(Azure.AI.Language.Documents.PiiCategories entity = default(Azure.AI.Language.Documents.PiiCategories), float value = 0f, string language = null) { throw null; }
        public static Azure.AI.Language.Documents.DocumentActions DocumentActions(int completed = 0, int failed = 0, int inProgress = 0, int total = 0, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.AnalyzeDocumentsLROResult> items = null) { throw null; }
        public static Azure.AI.Language.Documents.DocumentAnalysisDocumentResult DocumentAnalysisDocumentResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.DocumentWarning> warnings = null, Azure.AI.Language.Documents.DocumentStatistics statistics = null, Azure.AI.Language.Documents.DocumentLocation source = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.DocumentLocation> target = null) { throw null; }
        public static Azure.AI.Language.Documents.DocumentLocation DocumentLocation(string kind = null, string location = null) { throw null; }
        public static Azure.AI.Language.Documents.DocumentStatistics DocumentStatistics(int charactersCount = 0, int transactionsCount = 0) { throw null; }
        public static Azure.AI.Language.Documents.DocumentWarning DocumentWarning(Azure.AI.Language.Documents.WarningCode code = default(Azure.AI.Language.Documents.WarningCode), string message = null, string targetRef = null) { throw null; }
        public static Azure.AI.Language.Documents.EntityMaskPolicy EntityMaskPolicy(System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategories> entityTypes = null, string policyName = null, bool? isDefault = default(bool?)) { throw null; }
        public static Azure.AI.Language.Documents.EntitySynonym EntitySynonym(string synonym = null, string language = null) { throw null; }
        public static Azure.AI.Language.Documents.EntitySynonyms EntitySynonyms(Azure.AI.Language.Documents.PiiCategories entityType = default(Azure.AI.Language.Documents.PiiCategories), System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.EntitySynonym> synonyms = null) { throw null; }
        public static Azure.AI.Language.Documents.InnerErrorModel InnerErrorModel(Azure.AI.Language.Documents.InnerErrorCode code = default(Azure.AI.Language.Documents.InnerErrorCode), string message = null, System.Collections.Generic.IDictionary<string, string> details = null, string target = null, Azure.AI.Language.Documents.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Documents.MarkerMaskPolicy MarkerMaskPolicy(System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategories> entityTypes = null, string policyName = null, bool? isDefault = default(bool?)) { throw null; }
        public static Azure.AI.Language.Documents.MultiLanguageDocumentInput MultiLanguageDocumentInput(System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.MultiLanguageInput> documents = null) { throw null; }
        public static Azure.AI.Language.Documents.MultiLanguageInput MultiLanguageInput(string id = null, Azure.AI.Language.Documents.DocumentLocation source = null, Azure.AI.Language.Documents.DocumentLocation target = null, string language = null) { throw null; }
        public static Azure.AI.Language.Documents.NoMaskPolicy NoMaskPolicy(System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategories> entityTypes = null, string policyName = null, bool? isDefault = default(bool?)) { throw null; }
        public static Azure.AI.Language.Documents.PiiActionContent PiiActionContent(bool? loggingOptOut = default(bool?), string modelVersion = null, Azure.AI.Language.Documents.PiiDomain? domain = default(Azure.AI.Language.Documents.PiiDomain?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategoriesExtended> piiCategories = null, Azure.AI.Language.Documents.StringIndexType? stringIndexType = default(Azure.AI.Language.Documents.StringIndexType?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategories> excludePiiCategories = null, Azure.AI.Language.Documents.ValueExclusionPolicy valueExclusionPolicy = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.EntitySynonyms> entitySynonyms = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.BaseRedactionPolicy> redactionPolicies = null, Azure.AI.Language.Documents.ConfidenceScoreThreshold confidenceScoreThreshold = null, bool? disableEntityValidation = default(bool?)) { throw null; }
        public static Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult PiiEntityRecognitionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Documents.DocumentActionState status = default(Azure.AI.Language.Documents.DocumentActionState), string taskName = null, Azure.AI.Language.Documents.AnalyzeDocumentsResult results = null) { throw null; }
        public static Azure.AI.Language.Documents.PiiLROTask PiiLROTask(string name = null, Azure.AI.Language.Documents.PiiActionContent parameters = null) { throw null; }
        public static Azure.AI.Language.Documents.RequestStatistics RequestStatistics(int documentsCount = 0, int validDocumentsCount = 0, int erroneousDocumentsCount = 0, long transactionsCount = (long)0) { throw null; }
        public static Azure.AI.Language.Documents.SyntheticReplacementPolicyType SyntheticReplacementPolicyType(System.Collections.Generic.IEnumerable<Azure.AI.Language.Documents.PiiCategories> entityTypes = null, string policyName = null, bool? isDefault = default(bool?), bool? preserveDataFormat = default(bool?)) { throw null; }
        public static Azure.AI.Language.Documents.ValueExclusionPolicy ValueExclusionPolicy(bool caseSensitive = false, System.Collections.Generic.IEnumerable<string> excludedValues = null) { throw null; }
    }
    public partial class MarkerMaskPolicy : Azure.AI.Language.Documents.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MarkerMaskPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MarkerMaskPolicy>
    {
        public MarkerMaskPolicy() { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.MarkerMaskPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MarkerMaskPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MarkerMaskPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.MarkerMaskPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MarkerMaskPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MarkerMaskPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MarkerMaskPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLanguageDocumentInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MultiLanguageDocumentInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageDocumentInput>
    {
        public MultiLanguageDocumentInput() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.MultiLanguageInput> Documents { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.MultiLanguageDocumentInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.MultiLanguageDocumentInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.MultiLanguageDocumentInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MultiLanguageDocumentInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MultiLanguageDocumentInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.MultiLanguageDocumentInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageDocumentInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageDocumentInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageDocumentInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLanguageInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MultiLanguageInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageInput>
    {
        public MultiLanguageInput(string id, Azure.AI.Language.Documents.DocumentLocation source, Azure.AI.Language.Documents.DocumentLocation target) { }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.AI.Language.Documents.DocumentLocation Source { get { throw null; } }
        public Azure.AI.Language.Documents.DocumentLocation Target { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.MultiLanguageInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.MultiLanguageInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.MultiLanguageInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MultiLanguageInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.MultiLanguageInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.MultiLanguageInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.MultiLanguageInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoMaskPolicy : Azure.AI.Language.Documents.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.NoMaskPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.NoMaskPolicy>
    {
        public NoMaskPolicy() { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.NoMaskPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.NoMaskPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.NoMaskPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.NoMaskPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.NoMaskPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.NoMaskPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.NoMaskPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiActionContent>
    {
        public PiiActionContent() { }
        public Azure.AI.Language.Documents.ConfidenceScoreThreshold ConfidenceScoreThreshold { get { throw null; } set { } }
        public bool? DisableEntityValidation { get { throw null; } set { } }
        public Azure.AI.Language.Documents.PiiDomain? Domain { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.EntitySynonyms> EntitySynonyms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.PiiCategories> ExcludePiiCategories { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.PiiCategoriesExtended> PiiCategories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Documents.BaseRedactionPolicy> RedactionPolicies { get { throw null; } }
        public Azure.AI.Language.Documents.StringIndexType? StringIndexType { get { throw null; } set { } }
        public Azure.AI.Language.Documents.ValueExclusionPolicy ValueExclusionPolicy { get { throw null; } set { } }
        protected virtual Azure.AI.Language.Documents.PiiActionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.PiiActionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.PiiActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.PiiActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiCategories : System.IEquatable<Azure.AI.Language.Documents.PiiCategories>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiCategories(string value) { throw null; }
        public static Azure.AI.Language.Documents.PiiCategories AbaRoutingNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories Address { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories Age { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ArNationalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AtIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AtValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AuBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AuBusinessNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AuCompanyNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AuMedicalAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AuTaxFileNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureDocumentDbauthKey { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureIaasDatabaseConnectionAndSqlString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureIoTConnectionString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzurePublishSettingPassword { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureRedisCacheString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureSas { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureServiceBusString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureStorageAccountGeneric { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories AzureStorageAccountKey { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories BeNationalNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories BeNationalNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories BeValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories BgUniformCivilNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories BrCpfNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories BrLegalEntityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories BrNationalIdRg { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CaBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CaDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CaHealthServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CaPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CaPersonalHealthIdentification { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CaSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ChSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ClIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CnResidentIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CyIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CyTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CzPersonalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories CzPersonalIdentityV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories Date { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DeDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DeIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DeValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DkPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DkPersonalIdentificationV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories DrugEnforcementAgencyNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EePersonalIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories Email { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EsDni { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EsTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EuDebitCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EuGpsCoordinates { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EuNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EuSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories EuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FiEuropeanHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FiNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FiNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FiPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FrDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FrHealthInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FrNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FrPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FrSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories FrValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories GrNationalIdCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories GrNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories GrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HkIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HrIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HrNationalIdNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HrPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HrPersonalIdentificationOIBNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HuPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories HuValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories IdIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories IePersonalPublicServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories IePersonalPublicServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories IlBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories IlNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories InPermanentAccount { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories InternationalBankingAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories InUniqueIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories IPAddress { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ItDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ItFiscalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ItValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpMyNumberCorporate { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpMyNumberPersonal { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpResidenceCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories JpSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories KrResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories LtPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories LuNationalIdentificationNumberNatural { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories LuNationalIdentificationNumberNonNatural { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories LvPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories MtIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories MtTaxIdNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories MyIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NlCitizensServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NlCitizensServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NlValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NoIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NzBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NzDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NzInlandRevenueNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NzMinistryOfHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories NzSocialWelfareNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories Organization { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories Person { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PhUnifiedMultiPurposeIdNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PlIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PlNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PlNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PlPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PlRegonNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PtCitizenCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PtCitizenCardNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories PtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories RoPersonalNumericalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories RuPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories RuPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SaNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SeNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SeNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SgNationalRegistrationIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SiTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SiUniqueMasterCitizenNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SkPersonalNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SqlServerConnectionString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories SwiftCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ThPopulationIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories TrNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories TwNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories TwPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories TwResidentCertificate { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UaPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UaPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UkDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UkElectoralRollNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UkNationalHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UkNationalInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UkUniqueTaxpayerNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories URL { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UsBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UsDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UsIndividualTaxpayerIdentification { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories UsUkPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategories ZaIdentificationNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.PiiCategories other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.PiiCategories left, Azure.AI.Language.Documents.PiiCategories right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.PiiCategories (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.PiiCategories? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.PiiCategories left, Azure.AI.Language.Documents.PiiCategories right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiCategoriesExtended : System.IEquatable<Azure.AI.Language.Documents.PiiCategoriesExtended>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiCategoriesExtended(string value) { throw null; }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AbaRoutingNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended Address { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended Age { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended All { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ArNationalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AtIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AtValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AuBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AuBusinessNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AuCompanyNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AuMedicalAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AuTaxFileNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureDocumentDbauthKey { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureIaasDatabaseConnectionAndSqlString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureIoTConnectionString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzurePublishSettingPassword { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureRedisCacheString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureSas { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureServiceBusString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureStorageAccountGeneric { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended AzureStorageAccountKey { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended BeNationalNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended BeNationalNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended BeValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended BgUniformCivilNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended BrCpfNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended BrLegalEntityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended BrNationalIdRg { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CaBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CaDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CaHealthServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CaPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CaPersonalHealthIdentification { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CaSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ChSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ClIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CnResidentIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CyIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CyTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CzPersonalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended CzPersonalIdentityV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended Date { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DeDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended Default { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DeIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DeValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DkPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DkPersonalIdentificationV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended DrugEnforcementAgencyNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EePersonalIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended Email { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EsDni { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EsTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EuDebitCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EuGpsCoordinates { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EuNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EuSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended EuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FiEuropeanHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FiNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FiNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FiPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FrDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FrHealthInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FrNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FrPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FrSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended FrValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended GrNationalIdCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended GrNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended GrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HkIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HrIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HrNationalIdNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HrPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HrPersonalIdentificationOIBNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HuPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended HuValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended IdIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended IePersonalPublicServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended IePersonalPublicServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended IlBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended IlNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended InPermanentAccount { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended InternationalBankingAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended InUniqueIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended IPAddress { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ItDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ItFiscalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ItValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpMyNumberCorporate { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpMyNumberPersonal { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpResidenceCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended JpSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended KrResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended LtPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended LuNationalIdentificationNumberNatural { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended LuNationalIdentificationNumberNonNatural { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended LvPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended MtIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended MtTaxIdNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended MyIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NlCitizensServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NlCitizensServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NlValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NoIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NzBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NzDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NzInlandRevenueNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NzMinistryOfHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended NzSocialWelfareNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended Organization { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended Person { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PhUnifiedMultiPurposeIdNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PlIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PlNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PlNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PlPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PlRegonNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PtCitizenCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PtCitizenCardNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended PtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended RoPersonalNumericalCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended RuPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended RuPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SaNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SeNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SeNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SgNationalRegistrationIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SiTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SiUniqueMasterCitizenNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SkPersonalNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SqlServerConnectionString { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended SwiftCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ThPopulationIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended TrNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended TwNationalId { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended TwPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended TwResidentCertificate { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UaPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UaPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UkDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UkElectoralRollNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UkNationalHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UkNationalInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UkUniqueTaxpayerNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended URL { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UsBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UsDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UsIndividualTaxpayerIdentification { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended UsUkPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiCategoriesExtended ZaIdentificationNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.PiiCategoriesExtended other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.PiiCategoriesExtended left, Azure.AI.Language.Documents.PiiCategoriesExtended right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.PiiCategoriesExtended (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.PiiCategoriesExtended? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.PiiCategoriesExtended left, Azure.AI.Language.Documents.PiiCategoriesExtended right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiDomain : System.IEquatable<Azure.AI.Language.Documents.PiiDomain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiDomain(string value) { throw null; }
        public static Azure.AI.Language.Documents.PiiDomain None { get { throw null; } }
        public static Azure.AI.Language.Documents.PiiDomain Phi { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.PiiDomain other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.PiiDomain left, Azure.AI.Language.Documents.PiiDomain right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.PiiDomain (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.PiiDomain? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.PiiDomain left, Azure.AI.Language.Documents.PiiDomain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PiiEntityRecognitionOperationResult : Azure.AI.Language.Documents.AnalyzeDocumentsLROResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult>
    {
        internal PiiEntityRecognitionOperationResult() { }
        public Azure.AI.Language.Documents.AnalyzeDocumentsResult Results { get { throw null; } }
        protected override Azure.AI.Language.Documents.AnalyzeDocumentsLROResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.AnalyzeDocumentsLROResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiEntityRecognitionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiLROTask : Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiLROTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiLROTask>
    {
        public PiiLROTask() { }
        public Azure.AI.Language.Documents.PiiActionContent Parameters { get { throw null; } set { } }
        protected override Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.AnalyzeDocumentsOperationAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.PiiLROTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiLROTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.PiiLROTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.PiiLROTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiLROTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiLROTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.PiiLROTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedactionCharacter : System.IEquatable<Azure.AI.Language.Documents.RedactionCharacter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedactionCharacter(string value) { throw null; }
        public static Azure.AI.Language.Documents.RedactionCharacter Ampersand { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter Asterisk { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter AtSign { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter Caret { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter Dollar { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter EqualSign { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter ExclamationPoint { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter Minus { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter NumberSign { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter PerCent { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter Plus { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter QuestionMark { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter Tilde { get { throw null; } }
        public static Azure.AI.Language.Documents.RedactionCharacter Underscore { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.RedactionCharacter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.RedactionCharacter left, Azure.AI.Language.Documents.RedactionCharacter right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.RedactionCharacter (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.RedactionCharacter? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.RedactionCharacter left, Azure.AI.Language.Documents.RedactionCharacter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.RequestStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.RequestStatistics>
    {
        internal RequestStatistics() { }
        public int DocumentsCount { get { throw null; } }
        public int ErroneousDocumentsCount { get { throw null; } }
        public long TransactionsCount { get { throw null; } }
        public int ValidDocumentsCount { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.RequestStatistics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.RequestStatistics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.RequestStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.RequestStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.RequestStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.RequestStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.RequestStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.RequestStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.RequestStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Documents.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Documents.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.Language.Documents.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.Language.Documents.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.StringIndexType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.StringIndexType left, Azure.AI.Language.Documents.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.StringIndexType (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.StringIndexType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.StringIndexType left, Azure.AI.Language.Documents.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyntheticReplacementPolicyType : Azure.AI.Language.Documents.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.SyntheticReplacementPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.SyntheticReplacementPolicyType>
    {
        public SyntheticReplacementPolicyType() { }
        public bool? PreserveDataFormat { get { throw null; } set { } }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.Documents.BaseRedactionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.SyntheticReplacementPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.SyntheticReplacementPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.SyntheticReplacementPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.SyntheticReplacementPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.SyntheticReplacementPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.SyntheticReplacementPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.SyntheticReplacementPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValueExclusionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ValueExclusionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ValueExclusionPolicy>
    {
        public ValueExclusionPolicy(bool caseSensitive, System.Collections.Generic.IEnumerable<string> excludedValues) { }
        public bool CaseSensitive { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedValues { get { throw null; } }
        protected virtual Azure.AI.Language.Documents.ValueExclusionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.Documents.ValueExclusionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.Documents.ValueExclusionPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ValueExclusionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Documents.ValueExclusionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Documents.ValueExclusionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ValueExclusionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ValueExclusionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Documents.ValueExclusionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WarningCode : System.IEquatable<Azure.AI.Language.Documents.WarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WarningCode(string value) { throw null; }
        public static Azure.AI.Language.Documents.WarningCode DocumentTruncated { get { throw null; } }
        public static Azure.AI.Language.Documents.WarningCode LongWordsInDocument { get { throw null; } }
        public bool Equals(Azure.AI.Language.Documents.WarningCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Documents.WarningCode left, Azure.AI.Language.Documents.WarningCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.WarningCode (string value) { throw null; }
        public static implicit operator Azure.AI.Language.Documents.WarningCode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Documents.WarningCode left, Azure.AI.Language.Documents.WarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class LanguageDocumentsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Documents.AnalyzeDocumentsClient, Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions> AddAnalyzeDocumentsClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Documents.AnalyzeDocumentsClient, Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions> AddAnalyzeDocumentsClient<TBuilder>(this TBuilder builder, string endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Documents.AnalyzeDocumentsClient, Azure.AI.Language.Documents.AnalyzeDocumentsClientOptions> AddAnalyzeDocumentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
