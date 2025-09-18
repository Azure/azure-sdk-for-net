namespace Azure.Health.Deidentification
{
    public partial class AzureHealthDeidentificationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureHealthDeidentificationContext() { }
        public static Azure.Health.Deidentification.AzureHealthDeidentificationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeidentificationClient
    {
        protected DeidentificationClient() { }
        public DeidentificationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DeidentificationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Health.Deidentification.DeidentificationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelJob(string jobName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Health.Deidentification.DeidentificationJob> CancelJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(string jobName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Health.Deidentification.DeidentificationJob>> CancelJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeidentifyDocuments(Azure.WaitUntil waitUntil, string jobName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Deidentification.DeidentificationJob> DeidentifyDocuments(Azure.WaitUntil waitUntil, string jobName, Azure.Health.Deidentification.DeidentificationJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeidentifyDocumentsAsync(Azure.WaitUntil waitUntil, string jobName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Deidentification.DeidentificationJob>> DeidentifyDocumentsAsync(Azure.WaitUntil waitUntil, string jobName, Azure.Health.Deidentification.DeidentificationJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeidentifyText(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Health.Deidentification.DeidentificationResult> DeidentifyText(Azure.Health.Deidentification.DeidentificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeidentifyTextAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Health.Deidentification.DeidentificationResult>> DeidentifyTextAsync(Azure.Health.Deidentification.DeidentificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteJob(string jobName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string jobName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetJob(string jobName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Health.Deidentification.DeidentificationJob> GetJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobAsync(string jobName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Health.Deidentification.DeidentificationJob>> GetJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobDocuments(string jobName, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Health.Deidentification.DeidentificationDocumentDetails> GetJobDocuments(string jobName, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobDocumentsAsync(string jobName, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Health.Deidentification.DeidentificationDocumentDetails> GetJobDocumentsAsync(string jobName, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobs(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Health.Deidentification.DeidentificationJob> GetJobs(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobsAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Health.Deidentification.DeidentificationJob> GetJobsAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeidentificationClientOptions : Azure.Core.ClientOptions
    {
        public DeidentificationClientOptions(Azure.Health.Deidentification.DeidentificationClientOptions.ServiceVersion version = Azure.Health.Deidentification.DeidentificationClientOptions.ServiceVersion.V2025_07_15_Preview) { }
        public enum ServiceVersion
        {
            V2024_11_15 = 1,
            V2025_07_15_Preview = 2,
        }
    }
    public partial class DeidentificationContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>
    {
        public DeidentificationContent(string inputText) { }
        public Azure.Health.Deidentification.DeidentificationCustomizationOptions Customizations { get { throw null; } set { } }
        public string InputText { get { throw null; } }
        public Azure.Health.Deidentification.DeidentificationOperationType? OperationType { get { throw null; } set { } }
        public Azure.Health.Deidentification.TaggedPhiEntities TaggedEntities { get { throw null; } set { } }
        protected virtual Azure.Health.Deidentification.DeidentificationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Health.Deidentification.DeidentificationContent deidentificationContent) { throw null; }
        protected virtual Azure.Health.Deidentification.DeidentificationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationContent System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationCustomizationOptions : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationCustomizationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationCustomizationOptions>
    {
        public DeidentificationCustomizationOptions() { }
        public string InputLocale { get { throw null; } set { } }
        public string RedactionFormat { get { throw null; } set { } }
        public string SurrogateLocale { get { throw null; } set { } }
        protected virtual Azure.Health.Deidentification.DeidentificationCustomizationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.DeidentificationCustomizationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationCustomizationOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationCustomizationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationCustomizationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationCustomizationOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationCustomizationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationCustomizationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationCustomizationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationDocumentDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationDocumentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentDetails>
    {
        internal DeidentificationDocumentDetails() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Deidentification.DeidentificationDocumentLocation InputLocation { get { throw null; } }
        public Azure.Health.Deidentification.DeidentificationDocumentLocation OutputLocation { get { throw null; } }
        public Azure.Health.Deidentification.OperationStatus Status { get { throw null; } }
        protected virtual Azure.Health.Deidentification.DeidentificationDocumentDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.DeidentificationDocumentDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationDocumentDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationDocumentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationDocumentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationDocumentDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationDocumentLocation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationDocumentLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentLocation>
    {
        internal DeidentificationDocumentLocation() { }
        public Azure.ETag Etag { get { throw null; } }
        public System.Uri Location { get { throw null; } }
        protected virtual Azure.Health.Deidentification.DeidentificationDocumentLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.DeidentificationDocumentLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationDocumentLocation System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationDocumentLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationDocumentLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationDocumentLocation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationDocumentLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationJob : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>
    {
        public DeidentificationJob(Azure.Health.Deidentification.SourceStorageLocation sourceLocation, Azure.Health.Deidentification.TargetStorageLocation targetLocation) { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.Health.Deidentification.DeidentificationJobCustomizationOptions Customizations { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public string JobName { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAt { get { throw null; } }
        public Azure.Health.Deidentification.DeidentificationOperationType? OperationType { get { throw null; } set { } }
        public Azure.Health.Deidentification.SourceStorageLocation SourceLocation { get { throw null; } set { } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.Health.Deidentification.OperationStatus Status { get { throw null; } }
        public Azure.Health.Deidentification.DeidentificationJobSummary Summary { get { throw null; } }
        public Azure.Health.Deidentification.TargetStorageLocation TargetLocation { get { throw null; } set { } }
        protected virtual Azure.Health.Deidentification.DeidentificationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Health.Deidentification.DeidentificationJob (Azure.Response result) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Health.Deidentification.DeidentificationJob deidentificationJob) { throw null; }
        protected virtual Azure.Health.Deidentification.DeidentificationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationJob System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationJob System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationJobCustomizationOptions : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJobCustomizationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobCustomizationOptions>
    {
        public DeidentificationJobCustomizationOptions() { }
        public string InputLocale { get { throw null; } set { } }
        public string RedactionFormat { get { throw null; } set { } }
        public string SurrogateLocale { get { throw null; } set { } }
        protected virtual Azure.Health.Deidentification.DeidentificationJobCustomizationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.DeidentificationJobCustomizationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationJobCustomizationOptions System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJobCustomizationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJobCustomizationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationJobCustomizationOptions System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobCustomizationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobCustomizationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobCustomizationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationJobSummary : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJobSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobSummary>
    {
        internal DeidentificationJobSummary() { }
        public long BytesProcessed { get { throw null; } }
        public int CanceledCount { get { throw null; } }
        public int FailedCount { get { throw null; } }
        public int SuccessfulCount { get { throw null; } }
        public int TotalCount { get { throw null; } }
        protected virtual Azure.Health.Deidentification.DeidentificationJobSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.DeidentificationJobSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationJobSummary System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJobSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJobSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationJobSummary System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJobSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeidentificationOperationType : System.IEquatable<Azure.Health.Deidentification.DeidentificationOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeidentificationOperationType(string value) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationOperationType Redact { get { throw null; } }
        public static Azure.Health.Deidentification.DeidentificationOperationType Surrogate { get { throw null; } }
        public static Azure.Health.Deidentification.DeidentificationOperationType SurrogateOnly { get { throw null; } }
        public static Azure.Health.Deidentification.DeidentificationOperationType Tag { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.DeidentificationOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.DeidentificationOperationType left, Azure.Health.Deidentification.DeidentificationOperationType right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.DeidentificationOperationType (string value) { throw null; }
        public static implicit operator Azure.Health.Deidentification.DeidentificationOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.DeidentificationOperationType left, Azure.Health.Deidentification.DeidentificationOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeidentificationResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>
    {
        internal DeidentificationResult() { }
        public string OutputText { get { throw null; } }
        public Azure.Health.Deidentification.PhiTaggerResult TaggerResult { get { throw null; } }
        protected virtual Azure.Health.Deidentification.DeidentificationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Health.Deidentification.DeidentificationResult (Azure.Response result) { throw null; }
        protected virtual Azure.Health.Deidentification.DeidentificationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.DeidentificationResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HealthDeidentificationModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Health.Deidentification.DeidentificationContent DeidentificationContent(string inputText, Azure.Health.Deidentification.DeidentificationOperationType? operationType, Azure.Health.Deidentification.DeidentificationCustomizationOptions customizations) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationContent DeidentificationContent(string inputText = null, Azure.Health.Deidentification.DeidentificationOperationType? operationType = default(Azure.Health.Deidentification.DeidentificationOperationType?), Azure.Health.Deidentification.TaggedPhiEntities taggedEntities = null, Azure.Health.Deidentification.DeidentificationCustomizationOptions customizations = null) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationCustomizationOptions DeidentificationCustomizationOptions(string redactionFormat = null, string surrogateLocale = null, string inputLocale = null) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationDocumentDetails DeidentificationDocumentDetails(string id = null, Azure.Health.Deidentification.DeidentificationDocumentLocation inputLocation = null, Azure.Health.Deidentification.DeidentificationDocumentLocation outputLocation = null, Azure.Health.Deidentification.OperationStatus status = default(Azure.Health.Deidentification.OperationStatus), Azure.ResponseError error = null) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationDocumentLocation DeidentificationDocumentLocation(System.Uri location = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationJob DeidentificationJob(string jobName = null, Azure.Health.Deidentification.DeidentificationOperationType? operationType = default(Azure.Health.Deidentification.DeidentificationOperationType?), Azure.Health.Deidentification.SourceStorageLocation sourceLocation = null, Azure.Health.Deidentification.TargetStorageLocation targetLocation = null, Azure.Health.Deidentification.DeidentificationJobCustomizationOptions customizations = null, Azure.Health.Deidentification.OperationStatus status = default(Azure.Health.Deidentification.OperationStatus), Azure.ResponseError error = null, System.DateTimeOffset lastUpdatedAt = default(System.DateTimeOffset), System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), Azure.Health.Deidentification.DeidentificationJobSummary summary = null) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationJobCustomizationOptions DeidentificationJobCustomizationOptions(string redactionFormat = null, string surrogateLocale = null, string inputLocale = null) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationJobSummary DeidentificationJobSummary(int successfulCount = 0, int failedCount = 0, int canceledCount = 0, int totalCount = 0, long bytesProcessed = (long)0) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationResult DeidentificationResult(string outputText = null, Azure.Health.Deidentification.PhiTaggerResult taggerResult = null) { throw null; }
        public static Azure.Health.Deidentification.PhiEntity PhiEntity(Azure.Health.Deidentification.PhiCategory category = default(Azure.Health.Deidentification.PhiCategory), Azure.Health.Deidentification.StringIndex offset = null, Azure.Health.Deidentification.StringIndex length = null, string text = null, double? confidenceScore = default(double?)) { throw null; }
        public static Azure.Health.Deidentification.PhiTaggerResult PhiTaggerResult(System.Collections.Generic.IEnumerable<Azure.Health.Deidentification.PhiEntity> entities = null) { throw null; }
        public static Azure.Health.Deidentification.SimplePhiEntity SimplePhiEntity(Azure.Health.Deidentification.PhiCategory category = default(Azure.Health.Deidentification.PhiCategory), int offset = 0, int length = 0, string text = null) { throw null; }
        public static Azure.Health.Deidentification.SourceStorageLocation SourceStorageLocation(System.Uri location = null, string prefix = null, System.Collections.Generic.IEnumerable<string> extensions = null) { throw null; }
        public static Azure.Health.Deidentification.StringIndex StringIndex(int utf8 = 0, int utf16 = 0, int codePoint = 0) { throw null; }
        public static Azure.Health.Deidentification.TaggedPhiEntities TaggedPhiEntities(Azure.Health.Deidentification.TextEncodingType encoding = default(Azure.Health.Deidentification.TextEncodingType), System.Collections.Generic.IEnumerable<Azure.Health.Deidentification.SimplePhiEntity> entities = null) { throw null; }
        public static Azure.Health.Deidentification.TargetStorageLocation TargetStorageLocation(System.Uri location = null, string prefix = null, bool? overwrite = default(bool?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.Health.Deidentification.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.Health.Deidentification.OperationStatus Canceled { get { throw null; } }
        public static Azure.Health.Deidentification.OperationStatus Failed { get { throw null; } }
        public static Azure.Health.Deidentification.OperationStatus NotStarted { get { throw null; } }
        public static Azure.Health.Deidentification.OperationStatus Running { get { throw null; } }
        public static Azure.Health.Deidentification.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.OperationStatus left, Azure.Health.Deidentification.OperationStatus right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.OperationStatus (string value) { throw null; }
        public static implicit operator Azure.Health.Deidentification.OperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.OperationStatus left, Azure.Health.Deidentification.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhiCategory : System.IEquatable<Azure.Health.Deidentification.PhiCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhiCategory(string value) { throw null; }
        public static Azure.Health.Deidentification.PhiCategory Account { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Age { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory BioID { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory City { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory CountryOrRegion { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Date { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Device { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Doctor { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Email { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Fax { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory HealthPlan { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Hospital { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory IDNum { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory IPAddress { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory License { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory LocationOther { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory MedicalRecord { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Organization { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Patient { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Phone { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Profession { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory SocialSecurity { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory State { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Street { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Unknown { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Url { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Username { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Vehicle { get { throw null; } }
        public static Azure.Health.Deidentification.PhiCategory Zip { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.PhiCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.PhiCategory left, Azure.Health.Deidentification.PhiCategory right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.PhiCategory (string value) { throw null; }
        public static implicit operator Azure.Health.Deidentification.PhiCategory? (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.PhiCategory left, Azure.Health.Deidentification.PhiCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhiEntity : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiEntity>
    {
        internal PhiEntity() { }
        public Azure.Health.Deidentification.PhiCategory Category { get { throw null; } }
        public double? ConfidenceScore { get { throw null; } }
        public Azure.Health.Deidentification.StringIndex Length { get { throw null; } }
        public Azure.Health.Deidentification.StringIndex Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.Health.Deidentification.PhiEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.PhiEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.PhiEntity System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.PhiEntity System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhiTaggerResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiTaggerResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiTaggerResult>
    {
        internal PhiTaggerResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Health.Deidentification.PhiEntity> Entities { get { throw null; } }
        protected virtual Azure.Health.Deidentification.PhiTaggerResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.PhiTaggerResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.PhiTaggerResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiTaggerResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiTaggerResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.PhiTaggerResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiTaggerResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiTaggerResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiTaggerResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimplePhiEntity : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.SimplePhiEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SimplePhiEntity>
    {
        public SimplePhiEntity(Azure.Health.Deidentification.PhiCategory category, int offset, int length) { }
        public Azure.Health.Deidentification.PhiCategory Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } set { } }
        protected virtual Azure.Health.Deidentification.SimplePhiEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.SimplePhiEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.SimplePhiEntity System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.SimplePhiEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.SimplePhiEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.SimplePhiEntity System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SimplePhiEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SimplePhiEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SimplePhiEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceStorageLocation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.SourceStorageLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SourceStorageLocation>
    {
        public SourceStorageLocation(System.Uri location, string prefix) { }
        public System.Collections.Generic.IList<string> Extensions { get { throw null; } }
        public System.Uri Location { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected virtual Azure.Health.Deidentification.SourceStorageLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.SourceStorageLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.SourceStorageLocation System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.SourceStorageLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.SourceStorageLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.SourceStorageLocation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SourceStorageLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SourceStorageLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SourceStorageLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringIndex : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.StringIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.StringIndex>
    {
        internal StringIndex() { }
        public int CodePoint { get { throw null; } }
        public int Utf16 { get { throw null; } }
        public int Utf8 { get { throw null; } }
        protected virtual Azure.Health.Deidentification.StringIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.StringIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.StringIndex System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.StringIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.StringIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.StringIndex System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.StringIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.StringIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.StringIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaggedPhiEntities : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TaggedPhiEntities>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TaggedPhiEntities>
    {
        public TaggedPhiEntities(Azure.Health.Deidentification.TextEncodingType encoding, System.Collections.Generic.IEnumerable<Azure.Health.Deidentification.SimplePhiEntity> entities) { }
        public Azure.Health.Deidentification.TextEncodingType Encoding { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Health.Deidentification.SimplePhiEntity> Entities { get { throw null; } }
        protected virtual Azure.Health.Deidentification.TaggedPhiEntities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.TaggedPhiEntities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.TaggedPhiEntities System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TaggedPhiEntities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TaggedPhiEntities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.TaggedPhiEntities System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TaggedPhiEntities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TaggedPhiEntities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TaggedPhiEntities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetStorageLocation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TargetStorageLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>
    {
        public TargetStorageLocation(System.Uri location, string prefix) { }
        public System.Uri Location { get { throw null; } set { } }
        public bool? Overwrite { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected virtual Azure.Health.Deidentification.TargetStorageLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Health.Deidentification.TargetStorageLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Health.Deidentification.TargetStorageLocation System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TargetStorageLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TargetStorageLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.TargetStorageLocation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextEncodingType : System.IEquatable<Azure.Health.Deidentification.TextEncodingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextEncodingType(string value) { throw null; }
        public static Azure.Health.Deidentification.TextEncodingType CodePoint { get { throw null; } }
        public static Azure.Health.Deidentification.TextEncodingType Utf16 { get { throw null; } }
        public static Azure.Health.Deidentification.TextEncodingType Utf8 { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.TextEncodingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.TextEncodingType left, Azure.Health.Deidentification.TextEncodingType right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.TextEncodingType (string value) { throw null; }
        public static implicit operator Azure.Health.Deidentification.TextEncodingType? (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.TextEncodingType left, Azure.Health.Deidentification.TextEncodingType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class HealthDeidentificationClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Deidentification.DeidentificationClient, Azure.Health.Deidentification.DeidentificationClientOptions> AddDeidentificationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Deidentification.DeidentificationClient, Azure.Health.Deidentification.DeidentificationClientOptions> AddDeidentificationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
