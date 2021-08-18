namespace Azure.AI.Translation.Document
{
    public partial class DocumentFilter
    {
        public DocumentFilter() { }
        public System.DateTimeOffset CreatedAfter { get { throw null; } set { } }
        public System.DateTimeOffset CreatedBefore { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.DocumentFilterOrder> OrderBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.DocumentTranslationStatus> Statuses { get { throw null; } }
    }
    public partial class DocumentFilterOrder
    {
        public DocumentFilterOrder(Azure.AI.Translation.Document.DocumentFilterProperty property, bool asc = true) { }
        public Azure.AI.Translation.Document.DocumentFilterProperty Property { get { throw null; } set { } }
    }
    public enum DocumentFilterProperty
    {
        CreatedOn = 0,
    }
    public partial class DocumentStatus
    {
        internal DocumentStatus() { }
        public long CharactersCharged { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.AI.Translation.Document.DocumentTranslationError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Uri SourceDocumentUri { get { throw null; } }
        public Azure.AI.Translation.Document.DocumentTranslationStatus Status { get { throw null; } }
        public System.Uri TranslatedDocumentUri { get { throw null; } }
        public string TranslatedTo { get { throw null; } }
        public float TranslationProgressPercentage { get { throw null; } }
    }
    public partial class DocumentTranslationClient
    {
        protected DocumentTranslationClient() { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Translation.Document.DocumentTranslationClientOptions options) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Translation.Document.DocumentTranslationClientOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.FileFormat>> GetSupportedDocumentFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.FileFormat>>> GetSupportedDocumentFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.FileFormat>> GetSupportedGlossaryFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.FileFormat>>> GetSupportedGlossaryFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translation.Document.TranslationStatus> GetTranslationStatuses(Azure.AI.Translation.Document.TranslationFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translation.Document.TranslationStatus> GetTranslationStatusesAsync(Azure.AI.Translation.Document.TranslationFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Translation.Document.DocumentTranslationOperation StartTranslation(Azure.AI.Translation.Document.DocumentTranslationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Translation.Document.DocumentTranslationOperation StartTranslation(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.DocumentTranslationInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Translation.Document.DocumentTranslationOperation> StartTranslationAsync(Azure.AI.Translation.Document.DocumentTranslationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Translation.Document.DocumentTranslationOperation> StartTranslationAsync(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.DocumentTranslationInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationClientOptions : Azure.Core.ClientOptions
    {
        public DocumentTranslationClientOptions(Azure.AI.Translation.Document.DocumentTranslationClientOptions.ServiceVersion version = Azure.AI.Translation.Document.DocumentTranslationClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationError
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.Translation.Document.DocumentTranslationErrorCode ErrorCode { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationErrorCode : System.IEquatable<Azure.AI.Translation.Document.DocumentTranslationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTranslationErrorCode(string value) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslationErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationErrorCode RequestRateTooHigh { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationErrorCode Unauthorized { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Document.DocumentTranslationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Document.DocumentTranslationErrorCode left, Azure.AI.Translation.Document.DocumentTranslationErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Translation.Document.DocumentTranslationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Document.DocumentTranslationErrorCode left, Azure.AI.Translation.Document.DocumentTranslationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationInput
    {
        public DocumentTranslationInput(Azure.AI.Translation.Document.TranslationSource source, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.TranslationTarget> targets) { }
        public DocumentTranslationInput(System.Uri sourceUri, System.Uri targetUri, string targetLanguageCode, Azure.AI.Translation.Document.TranslationGlossary glossary = null) { }
        public Azure.AI.Translation.Document.TranslationSource Source { get { throw null; } }
        public Azure.AI.Translation.Document.StorageInputType? StorageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.TranslationTarget> Targets { get { throw null; } }
        public void AddTarget(System.Uri targetUri, string languageCode, Azure.AI.Translation.Document.TranslationGlossary glossary = null) { }
    }
    public static partial class DocumentTranslationModelFactory
    {
        public static Azure.AI.Translation.Document.DocumentStatus DocumentStatus(string id, System.Uri sourceDocumentUri, Azure.AI.Translation.Document.DocumentTranslationError error, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, string translatedTo, float progress, long charactersCharged) { throw null; }
        public static Azure.AI.Translation.Document.DocumentStatus DocumentStatus(string id, System.Uri sourceDocumentUri, System.Uri translatedDocumentUri, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, string translatedTo, float progress, long charactersCharged) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslationError DocumentTranslationError(Azure.AI.Translation.Document.DocumentTranslationErrorCode errorCode, string message, string target) { throw null; }
        public static Azure.AI.Translation.Document.FileFormat FileFormat(string format = null, System.Collections.Generic.IEnumerable<string> fileExtensions = null, System.Collections.Generic.IEnumerable<string> contentTypes = null, string defaultFormatVersion = null, System.Collections.Generic.IEnumerable<string> formatVersions = null) { throw null; }
        public static Azure.AI.Translation.Document.TranslationStatus TranslationStatus(string id, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, Azure.AI.Translation.Document.DocumentTranslationError error, int total, int failed, int success, int inProgress, int notYetStarted, int canceled, long totalCharacterCharged) { throw null; }
    }
    public partial class DocumentTranslationOperation : Azure.PageableOperation<Azure.AI.Translation.Document.DocumentStatus>
    {
        protected DocumentTranslationOperation() { }
        public DocumentTranslationOperation(string translationId, Azure.AI.Translation.Document.DocumentTranslationClient client) { }
        public virtual System.DateTimeOffset CreatedOn { get { throw null; } }
        public virtual int DocumentsCanceled { get { throw null; } }
        public virtual int DocumentsFailed { get { throw null; } }
        public virtual int DocumentsInProgress { get { throw null; } }
        public virtual int DocumentsNotStarted { get { throw null; } }
        public virtual int DocumentsSucceeded { get { throw null; } }
        public virtual int DocumentsTotal { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual System.DateTimeOffset LastModified { get { throw null; } }
        public virtual Azure.AI.Translation.Document.DocumentTranslationStatus Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatus> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Document.DocumentStatus> GetDocumentStatus(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.DocumentStatus>> GetDocumentStatusAsync(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translation.Document.DocumentStatus> GetDocumentStatuses(Azure.AI.Translation.Document.DocumentFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatus> GetDocumentStatusesAsync(Azure.AI.Translation.Document.DocumentFilter filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.Translation.Document.DocumentStatus> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatus> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatus>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatus>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationStatus : System.IEquatable<Azure.AI.Translation.Document.DocumentTranslationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTranslationStatus(string value) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslationStatus Canceled { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationStatus Canceling { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationStatus Failed { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationStatus Running { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationStatus Succeeded { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationStatus ValidationFailed { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Document.DocumentTranslationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Document.DocumentTranslationStatus left, Azure.AI.Translation.Document.DocumentTranslationStatus right) { throw null; }
        public static implicit operator Azure.AI.Translation.Document.DocumentTranslationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Document.DocumentTranslationStatus left, Azure.AI.Translation.Document.DocumentTranslationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileFormat
    {
        internal FileFormat() { }
        public System.Collections.Generic.IReadOnlyList<string> ContentTypes { get { throw null; } }
        public string DefaultFormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileExtensions { get { throw null; } }
        public string Format { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FormatVersions { get { throw null; } }
    }
    public enum StorageInputType
    {
        File = 0,
        Folder = 1,
    }
    public partial class TranslationFilter
    {
        public TranslationFilter() { }
        public System.DateTimeOffset? CreatedAfter { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedBefore { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.TranslationFilterOrder> OrderBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.DocumentTranslationStatus> Statuses { get { throw null; } }
    }
    public partial class TranslationFilterOrder
    {
        public TranslationFilterOrder(Azure.AI.Translation.Document.TranslationFilterProperty property, bool asc = true) { }
        public Azure.AI.Translation.Document.TranslationFilterProperty Property { get { throw null; } set { } }
    }
    public enum TranslationFilterProperty
    {
        CreatedOn = 0,
    }
    public partial class TranslationGlossary
    {
        public TranslationGlossary(System.Uri glossaryUri, string format) { }
        public string Format { get { throw null; } }
        public string FormatVersion { get { throw null; } set { } }
        public System.Uri GlossaryUri { get { throw null; } }
    }
    public partial class TranslationSource
    {
        public TranslationSource(System.Uri sourceUri) { }
        public string LanguageCode { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class TranslationStatus
    {
        internal TranslationStatus() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public int DocumentsCanceled { get { throw null; } }
        public int DocumentsFailed { get { throw null; } }
        public int DocumentsInProgress { get { throw null; } }
        public int DocumentsNotStarted { get { throw null; } }
        public int DocumentsSucceeded { get { throw null; } }
        public int DocumentsTotal { get { throw null; } }
        public Azure.AI.Translation.Document.DocumentTranslationError? Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.Translation.Document.DocumentTranslationStatus Status { get { throw null; } }
        public long TotalCharactersCharged { get { throw null; } }
    }
    public partial class TranslationTarget
    {
        public TranslationTarget(System.Uri targetUri, string languageCode) { }
        public string CategoryId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.TranslationGlossary> Glossaries { get { throw null; } }
        public string LanguageCode { get { throw null; } }
        public System.Uri TargetUri { get { throw null; } }
    }
}
