namespace Azure.Health.Deidentification
{
    public partial class DeidentificationClient
    {
        protected DeidentificationClient() { }
        public DeidentificationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DeidentificationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Health.Deidentification.DeidentificationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelJob(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Health.Deidentification.DeidentificationJob> CancelJob(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Health.Deidentification.DeidentificationJob>> CancelJobAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateJob(Azure.WaitUntil waitUntil, string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Health.Deidentification.DeidentificationJob> CreateJob(Azure.WaitUntil waitUntil, string name, Azure.Health.Deidentification.DeidentificationJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateJobAsync(Azure.WaitUntil waitUntil, string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Health.Deidentification.DeidentificationJob>> CreateJobAsync(Azure.WaitUntil waitUntil, string name, Azure.Health.Deidentification.DeidentificationJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Deidentify(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Health.Deidentification.DeidentificationResult> Deidentify(Azure.Health.Deidentification.DeidentificationContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeidentifyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Health.Deidentification.DeidentificationResult>> DeidentifyAsync(Azure.Health.Deidentification.DeidentificationContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteJob(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetJob(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Health.Deidentification.DeidentificationJob> GetJob(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Health.Deidentification.DeidentificationJob>> GetJobAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobDocuments(string name, int? maxpagesize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Health.Deidentification.DocumentDetails> GetJobDocuments(string name, int? maxpagesize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobDocumentsAsync(string name, int? maxpagesize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Health.Deidentification.DocumentDetails> GetJobDocumentsAsync(string name, int? maxpagesize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobs(int? maxpagesize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Health.Deidentification.DeidentificationJob> GetJobs(int? maxpagesize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobsAsync(int? maxpagesize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Health.Deidentification.DeidentificationJob> GetJobsAsync(int? maxpagesize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeidentificationClientOptions : Azure.Core.ClientOptions
    {
        public DeidentificationClientOptions(Azure.Health.Deidentification.DeidentificationClientOptions.ServiceVersion version = Azure.Health.Deidentification.DeidentificationClientOptions.ServiceVersion.V2024_07_12_Preview) { }
        public enum ServiceVersion
        {
            V2024_07_12_Preview = 1,
        }
    }
    public partial class DeidentificationContent : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>
    {
        public DeidentificationContent(string inputText) { }
        public Azure.Health.Deidentification.DocumentDataType? DataType { get { throw null; } set { } }
        public string InputText { get { throw null; } }
        public Azure.Health.Deidentification.OperationType? Operation { get { throw null; } set { } }
        public string RedactionFormat { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationContent System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationJob : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>
    {
        public DeidentificationJob(Azure.Health.Deidentification.SourceStorageLocation sourceLocation, Azure.Health.Deidentification.TargetStorageLocation targetLocation) { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.Health.Deidentification.DocumentDataType? DataType { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAt { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Health.Deidentification.OperationType? Operation { get { throw null; } set { } }
        public string RedactionFormat { get { throw null; } set { } }
        public Azure.Health.Deidentification.SourceStorageLocation SourceLocation { get { throw null; } set { } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.Health.Deidentification.JobStatus Status { get { throw null; } }
        public Azure.Health.Deidentification.JobSummary Summary { get { throw null; } }
        public Azure.Health.Deidentification.TargetStorageLocation TargetLocation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationJob System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationJob System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidentificationResult : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>
    {
        internal DeidentificationResult() { }
        public string OutputText { get { throw null; } }
        public Azure.Health.Deidentification.PhiTaggerResult TaggerResult { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DeidentificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DeidentificationResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DeidentificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentDataType : System.IEquatable<Azure.Health.Deidentification.DocumentDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentDataType(string value) { throw null; }
        public static Azure.Health.Deidentification.DocumentDataType Plaintext { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.DocumentDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.DocumentDataType left, Azure.Health.Deidentification.DocumentDataType right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.DocumentDataType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.DocumentDataType left, Azure.Health.Deidentification.DocumentDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentDetails : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DocumentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentDetails>
    {
        internal DocumentDetails() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Health.Deidentification.DocumentLocation Input { get { throw null; } }
        public Azure.Health.Deidentification.DocumentLocation Output { get { throw null; } }
        public Azure.Health.Deidentification.OperationState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DocumentDetails System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DocumentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DocumentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DocumentDetails System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentLocation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DocumentLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentLocation>
    {
        internal DocumentLocation() { }
        public Azure.ETag Etag { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DocumentLocation System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DocumentLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.DocumentLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.DocumentLocation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.DocumentLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HealthDeidentificationModelFactory
    {
        public static Azure.Health.Deidentification.DeidentificationContent DeidentificationContent(string inputText = null, Azure.Health.Deidentification.OperationType? operation = default(Azure.Health.Deidentification.OperationType?), Azure.Health.Deidentification.DocumentDataType? dataType = default(Azure.Health.Deidentification.DocumentDataType?), string redactionFormat = null) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationJob DeidentificationJob(string name = null, Azure.Health.Deidentification.SourceStorageLocation sourceLocation = null, Azure.Health.Deidentification.TargetStorageLocation targetLocation = null, Azure.Health.Deidentification.OperationType? operation = default(Azure.Health.Deidentification.OperationType?), Azure.Health.Deidentification.DocumentDataType? dataType = default(Azure.Health.Deidentification.DocumentDataType?), string redactionFormat = null, Azure.Health.Deidentification.JobStatus status = default(Azure.Health.Deidentification.JobStatus), Azure.ResponseError error = null, System.DateTimeOffset lastUpdatedAt = default(System.DateTimeOffset), System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), Azure.Health.Deidentification.JobSummary summary = null) { throw null; }
        public static Azure.Health.Deidentification.DeidentificationResult DeidentificationResult(string outputText = null, Azure.Health.Deidentification.PhiTaggerResult taggerResult = null) { throw null; }
        public static Azure.Health.Deidentification.DocumentDetails DocumentDetails(string id = null, Azure.Health.Deidentification.DocumentLocation input = null, Azure.Health.Deidentification.DocumentLocation output = null, Azure.Health.Deidentification.OperationState status = default(Azure.Health.Deidentification.OperationState), Azure.ResponseError error = null) { throw null; }
        public static Azure.Health.Deidentification.DocumentLocation DocumentLocation(string path = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Health.Deidentification.JobSummary JobSummary(int successful = 0, int failed = 0, int canceled = 0, int total = 0, long bytesProcessed = (long)0) { throw null; }
        public static Azure.Health.Deidentification.PhiEntity PhiEntity(Azure.Health.Deidentification.PhiCategory category = default(Azure.Health.Deidentification.PhiCategory), Azure.Health.Deidentification.StringIndex offset = null, Azure.Health.Deidentification.StringIndex length = null, string text = null, double? confidenceScore = default(double?)) { throw null; }
        public static Azure.Health.Deidentification.PhiTaggerResult PhiTaggerResult(System.Collections.Generic.IEnumerable<Azure.Health.Deidentification.PhiEntity> entities = null, string path = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.Health.Deidentification.StringIndex StringIndex(int utf8 = 0, int utf16 = 0, int codePoint = 0) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.Health.Deidentification.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.Health.Deidentification.JobStatus Canceled { get { throw null; } }
        public static Azure.Health.Deidentification.JobStatus Failed { get { throw null; } }
        public static Azure.Health.Deidentification.JobStatus NotStarted { get { throw null; } }
        public static Azure.Health.Deidentification.JobStatus PartialFailed { get { throw null; } }
        public static Azure.Health.Deidentification.JobStatus Running { get { throw null; } }
        public static Azure.Health.Deidentification.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.JobStatus left, Azure.Health.Deidentification.JobStatus right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.JobStatus left, Azure.Health.Deidentification.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobSummary : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.JobSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.JobSummary>
    {
        internal JobSummary() { }
        public long BytesProcessed { get { throw null; } }
        public int Canceled { get { throw null; } }
        public int Failed { get { throw null; } }
        public int Successful { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.JobSummary System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.JobSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.JobSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.JobSummary System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.JobSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.JobSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.JobSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.Health.Deidentification.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.Health.Deidentification.OperationState Canceled { get { throw null; } }
        public static Azure.Health.Deidentification.OperationState Failed { get { throw null; } }
        public static Azure.Health.Deidentification.OperationState NotStarted { get { throw null; } }
        public static Azure.Health.Deidentification.OperationState Running { get { throw null; } }
        public static Azure.Health.Deidentification.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.OperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.OperationState left, Azure.Health.Deidentification.OperationState right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.OperationState (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.OperationState left, Azure.Health.Deidentification.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationType : System.IEquatable<Azure.Health.Deidentification.OperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationType(string value) { throw null; }
        public static Azure.Health.Deidentification.OperationType Redact { get { throw null; } }
        public static Azure.Health.Deidentification.OperationType Surrogate { get { throw null; } }
        public static Azure.Health.Deidentification.OperationType Tag { get { throw null; } }
        public bool Equals(Azure.Health.Deidentification.OperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Health.Deidentification.OperationType left, Azure.Health.Deidentification.OperationType right) { throw null; }
        public static implicit operator Azure.Health.Deidentification.OperationType (string value) { throw null; }
        public static bool operator !=(Azure.Health.Deidentification.OperationType left, Azure.Health.Deidentification.OperationType right) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ETag? Etag { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.PhiTaggerResult System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiTaggerResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.PhiTaggerResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.PhiTaggerResult System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiTaggerResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiTaggerResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.PhiTaggerResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceStorageLocation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.SourceStorageLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.SourceStorageLocation>
    {
        public SourceStorageLocation(System.Uri location, string prefix) { }
        public System.Collections.Generic.IList<string> Extensions { get { throw null; } }
        public System.Uri Location { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.StringIndex System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.StringIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.StringIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.StringIndex System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.StringIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.StringIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.StringIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetStorageLocation : System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TargetStorageLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>
    {
        public TargetStorageLocation(System.Uri location, string prefix) { }
        public System.Uri Location { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.TargetStorageLocation System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TargetStorageLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Health.Deidentification.TargetStorageLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Health.Deidentification.TargetStorageLocation System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Health.Deidentification.TargetStorageLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class HealthDeidentificationClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Deidentification.DeidentificationClient, Azure.Health.Deidentification.DeidentificationClientOptions> AddDeidentificationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Health.Deidentification.DeidentificationClient, Azure.Health.Deidentification.DeidentificationClientOptions> AddDeidentificationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
