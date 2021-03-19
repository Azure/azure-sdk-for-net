namespace Azure.AI.DocumentTranslation
{
    public partial class DocumentFilter
    {
        public DocumentFilter() { }
        public string Prefix { get { throw null; } set { } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class DocumentStatusDetail
    {
        internal DocumentStatusDetail() { }
        public long? CharacterCharged { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DocumentId { get { throw null; } }
        public Azure.AI.DocumentTranslation.DocumentTranslationError Error { get { throw null; } }
        public bool HasCompleted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Uri LocationUri { get { throw null; } }
        public Azure.AI.DocumentTranslation.TranslationStatus Status { get { throw null; } }
        public string TranslateTo { get { throw null; } }
        public float TranslationProgressPercentage { get { throw null; } }
    }
    public partial class DocumentTranslationClient
    {
        protected DocumentTranslationClient() { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentTranslation.DocumentTranslationClientOptions options) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.DocumentTranslation.DocumentTranslationClientOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.FileFormat>> GetDocumentFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.FileFormat>>> GetDocumentFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.FileFormat>> GetGlossaryFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.FileFormat>>> GetGlossaryFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentTranslation.TranslationStatusDetail> GetTranslations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentTranslation.TranslationStatusDetail> GetTranslationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.DocumentTranslation.DocumentTranslationOperation StartTranslation(Azure.AI.DocumentTranslation.TranslationConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.DocumentTranslation.DocumentTranslationOperation StartTranslation(System.Collections.Generic.IEnumerable<Azure.AI.DocumentTranslation.TranslationConfiguration> configurations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.DocumentTranslation.DocumentTranslationOperation> StartTranslationAsync(Azure.AI.DocumentTranslation.TranslationConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.DocumentTranslation.DocumentTranslationOperation> StartTranslationAsync(System.Collections.Generic.IEnumerable<Azure.AI.DocumentTranslation.TranslationConfiguration> configurations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationClientOptions : Azure.Core.ClientOptions
    {
        public DocumentTranslationClientOptions(Azure.AI.DocumentTranslation.DocumentTranslationClientOptions.ServiceVersion version = Azure.AI.DocumentTranslation.DocumentTranslationClientOptions.ServiceVersion.V1_0_preview_1) { }
        public enum ServiceVersion
        {
            V1_0_preview_1 = 1,
        }
    }
    public partial class DocumentTranslationError
    {
        internal DocumentTranslationError() { }
        public Azure.AI.DocumentTranslation.DocumentTranslationErrorCode? ErrorCode { get { throw null; } }
        public Azure.AI.DocumentTranslation.DocumentTranslationInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationErrorCode : System.IEquatable<Azure.AI.DocumentTranslation.DocumentTranslationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTranslationErrorCode(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.DocumentTranslationErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.DocumentTranslation.DocumentTranslationErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.DocumentTranslation.DocumentTranslationErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.DocumentTranslation.DocumentTranslationErrorCode RequestRateTooHigh { get { throw null; } }
        public static Azure.AI.DocumentTranslation.DocumentTranslationErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.AI.DocumentTranslation.DocumentTranslationErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.DocumentTranslation.DocumentTranslationErrorCode Unauthorized { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.DocumentTranslationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.DocumentTranslationErrorCode left, Azure.AI.DocumentTranslation.DocumentTranslationErrorCode right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.DocumentTranslationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.DocumentTranslationErrorCode left, Azure.AI.DocumentTranslation.DocumentTranslationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationInnerError
    {
        internal DocumentTranslationInnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.DocumentTranslation.DocumentTranslationInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class DocumentTranslationOperation : Azure.AI.DocumentTranslation.PageableOperation<Azure.AI.DocumentTranslation.DocumentStatusDetail>
    {
        protected DocumentTranslationOperation() { }
        public DocumentTranslationOperation(string translationId, Azure.AI.DocumentTranslation.DocumentTranslationClient client) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public int DocumentsCancelled { get { throw null; } }
        public int DocumentsFailed { get { throw null; } }
        public int DocumentsInProgress { get { throw null; } }
        public int DocumentsNotStarted { get { throw null; } }
        public int DocumentsSucceeded { get { throw null; } }
        public int DocumentsTotal { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.DocumentTranslation.TranslationStatus Status { get { throw null; } }
        public override Azure.AsyncPageable<Azure.AI.DocumentTranslation.DocumentStatusDetail> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentTranslation.DocumentStatusDetail> GetAllDocumentsStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentTranslation.DocumentStatusDetail> GetAllDocumentsStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentTranslation.DocumentStatusDetail> GetDocumentStatus(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentTranslation.DocumentStatusDetail>> GetDocumentStatusAsync(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.DocumentTranslation.DocumentStatusDetail> GetValues() { throw null; }
        public override Azure.AsyncPageable<Azure.AI.DocumentTranslation.DocumentStatusDetail> GetValuesAsync() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.DocumentTranslation.DocumentStatusDetail>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.DocumentTranslation.DocumentStatusDetail>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileFormat
    {
        internal FileFormat() { }
        public System.Collections.Generic.IReadOnlyList<string> ContentTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileExtensions { get { throw null; } }
        public string Format { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Versions { get { throw null; } }
    }
    public abstract partial class PageableOperation<T> : Azure.Operation<Azure.AsyncPageable<T>> where T : notnull
    {
        protected PageableOperation() { }
        public override Azure.AsyncPageable<T> Value { get { throw null; } }
        public abstract Azure.Pageable<T> GetValues();
        public abstract Azure.AsyncPageable<T> GetValuesAsync();
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.AI.DocumentTranslation.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.StorageType File { get { throw null; } }
        public static Azure.AI.DocumentTranslation.StorageType Folder { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.StorageType left, Azure.AI.DocumentTranslation.StorageType right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.StorageType left, Azure.AI.DocumentTranslation.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslationConfiguration
    {
        public TranslationConfiguration(Azure.AI.DocumentTranslation.TranslationSource source, System.Collections.Generic.IEnumerable<Azure.AI.DocumentTranslation.TranslationTarget> targets) { }
        public TranslationConfiguration(System.Uri sourceUri, System.Uri targetUri, string targetLanguageCode, Azure.AI.DocumentTranslation.TranslationGlossary glossary = null) { }
        public Azure.AI.DocumentTranslation.TranslationSource Source { get { throw null; } }
        public Azure.AI.DocumentTranslation.StorageType? StorageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.DocumentTranslation.TranslationTarget> Targets { get { throw null; } }
        public void AddTarget(System.Uri targetUri, string languageCode, Azure.AI.DocumentTranslation.TranslationGlossary glossary = null) { }
    }
    public partial class TranslationGlossary
    {
        public TranslationGlossary(System.Uri glossaryUri) { }
        public string FormatVersion { get { throw null; } set { } }
        public System.Uri GlossaryUri { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class TranslationSource
    {
        public TranslationSource(System.Uri sourceUri) { }
        public Azure.AI.DocumentTranslation.DocumentFilter Filter { get { throw null; } set { } }
        public string LanguageCode { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranslationStatus : System.IEquatable<Azure.AI.DocumentTranslation.TranslationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranslationStatus(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.TranslationStatus Cancelled { get { throw null; } }
        public static Azure.AI.DocumentTranslation.TranslationStatus Cancelling { get { throw null; } }
        public static Azure.AI.DocumentTranslation.TranslationStatus Failed { get { throw null; } }
        public static Azure.AI.DocumentTranslation.TranslationStatus NotStarted { get { throw null; } }
        public static Azure.AI.DocumentTranslation.TranslationStatus Running { get { throw null; } }
        public static Azure.AI.DocumentTranslation.TranslationStatus Succeeded { get { throw null; } }
        public static Azure.AI.DocumentTranslation.TranslationStatus ValidationFailed { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.TranslationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.TranslationStatus left, Azure.AI.DocumentTranslation.TranslationStatus right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.TranslationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.TranslationStatus left, Azure.AI.DocumentTranslation.TranslationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslationStatusDetail
    {
        internal TranslationStatusDetail() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public int DocumentsCancelled { get { throw null; } }
        public int DocumentsFailed { get { throw null; } }
        public int DocumentsInProgress { get { throw null; } }
        public int DocumentsNotStarted { get { throw null; } }
        public int DocumentsSucceeded { get { throw null; } }
        public int DocumentsTotal { get { throw null; } }
        public Azure.AI.DocumentTranslation.DocumentTranslationError Error { get { throw null; } }
        public bool HasCompleted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.DocumentTranslation.TranslationStatus Status { get { throw null; } }
        public long TotalCharacterCharged { get { throw null; } }
        public string TranslationId { get { throw null; } }
    }
    public partial class TranslationTarget
    {
        public TranslationTarget(System.Uri targetUri, string languageCode) { }
        public string CategoryId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.DocumentTranslation.TranslationGlossary> Glossaries { get { throw null; } }
        public string LanguageCode { get { throw null; } }
        public System.Uri TargetUri { get { throw null; } }
    }
}
