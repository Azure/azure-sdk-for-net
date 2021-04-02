namespace Azure.AI.Translator.DocumentTranslation
{
    public partial class DocumentFilter
    {
        public DocumentFilter() { }
        public string Prefix { get { throw null; } set { } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class DocumentStatusResult
    {
        internal DocumentStatusResult() { }
        public long CharactersCharged { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DocumentId { get { throw null; } }
        public Azure.AI.Translator.DocumentTranslation.DocumentTranslationError Error { get { throw null; } }
        public bool HasCompleted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Uri SourceDocumentUri { get { throw null; } }
        public Azure.AI.Translator.DocumentTranslation.TranslationStatus Status { get { throw null; } }
        public System.Uri TranslatedDocumentUri { get { throw null; } }
        public string TranslateTo { get { throw null; } }
        public float TranslationProgressPercentage { get { throw null; } }
    }
    public partial class DocumentTranslationClient
    {
        protected DocumentTranslationClient() { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Translator.DocumentTranslation.DocumentTranslationClientOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translator.DocumentTranslation.FileFormat>> GetDocumentFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translator.DocumentTranslation.FileFormat>>> GetDocumentFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translator.DocumentTranslation.FileFormat>> GetGlossaryFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translator.DocumentTranslation.FileFormat>>> GetGlossaryFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translator.DocumentTranslation.TranslationStatusResult> GetTranslations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translator.DocumentTranslation.TranslationStatusResult> GetTranslationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Translator.DocumentTranslation.DocumentTranslationOperation StartTranslation(Azure.AI.Translator.DocumentTranslation.DocumentTranslationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Translator.DocumentTranslation.DocumentTranslationOperation StartTranslation(System.Collections.Generic.IEnumerable<Azure.AI.Translator.DocumentTranslation.DocumentTranslationInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Translator.DocumentTranslation.DocumentTranslationOperation> StartTranslationAsync(Azure.AI.Translator.DocumentTranslation.DocumentTranslationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Translator.DocumentTranslation.DocumentTranslationOperation> StartTranslationAsync(System.Collections.Generic.IEnumerable<Azure.AI.Translator.DocumentTranslation.DocumentTranslationInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationClientOptions : Azure.Core.ClientOptions
    {
        public DocumentTranslationClientOptions(Azure.AI.Translator.DocumentTranslation.DocumentTranslationClientOptions.ServiceVersion version = Azure.AI.Translator.DocumentTranslation.DocumentTranslationClientOptions.ServiceVersion.V1_0_preview_1) { }
        public enum ServiceVersion
        {
            V1_0_preview_1 = 1,
        }
    }
    public partial class DocumentTranslationError
    {
        internal DocumentTranslationError() { }
        public Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode ErrorCode { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationErrorCode : System.IEquatable<Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTranslationErrorCode(string value) { throw null; }
        public static Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode RequestRateTooHigh { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode Unauthorized { get { throw null; } }
        public bool Equals(Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode left, Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode left, Azure.AI.Translator.DocumentTranslation.DocumentTranslationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationInput
    {
        public DocumentTranslationInput(Azure.AI.Translator.DocumentTranslation.TranslationSource source, System.Collections.Generic.IEnumerable<Azure.AI.Translator.DocumentTranslation.TranslationTarget> targets) { }
        public DocumentTranslationInput(System.Uri sourceUri, System.Uri targetUri, string targetLanguageCode, Azure.AI.Translator.DocumentTranslation.TranslationGlossary glossary = null) { }
        public Azure.AI.Translator.DocumentTranslation.TranslationSource Source { get { throw null; } }
        public Azure.AI.Translator.DocumentTranslation.StorageInputType? StorageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translator.DocumentTranslation.TranslationTarget> Targets { get { throw null; } }
        public void AddTarget(System.Uri targetUri, string languageCode, Azure.AI.Translator.DocumentTranslation.TranslationGlossary glossary = null) { }
    }
    public partial class DocumentTranslationOperation : Azure.AI.Translator.DocumentTranslation.PageableOperation<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult>
    {
        protected DocumentTranslationOperation() { }
        public DocumentTranslationOperation(string translationId, Azure.AI.Translator.DocumentTranslation.DocumentTranslationClient client) { }
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
        public Azure.AI.Translator.DocumentTranslation.TranslationStatus Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.AsyncPageable<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult> GetAllDocumentStatuses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult> GetAllDocumentStatusesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult> GetDocumentStatus(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult>> GetDocumentStatusAsync(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult> GetValues() { throw null; }
        public override Azure.AsyncPageable<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult> GetValuesAsync() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.Translator.DocumentTranslation.DocumentStatusResult>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public abstract partial class PageableOperation<T> : Azure.Operation<Azure.AsyncPageable<T>> where T : notnull
    {
        protected PageableOperation() { }
        public override Azure.AsyncPageable<T> Value { get { throw null; } }
        public abstract Azure.Pageable<T> GetValues();
        public abstract Azure.AsyncPageable<T> GetValuesAsync();
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageInputType : System.IEquatable<Azure.AI.Translator.DocumentTranslation.StorageInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageInputType(string value) { throw null; }
        public static Azure.AI.Translator.DocumentTranslation.StorageInputType File { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.StorageInputType Folder { get { throw null; } }
        public bool Equals(Azure.AI.Translator.DocumentTranslation.StorageInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translator.DocumentTranslation.StorageInputType left, Azure.AI.Translator.DocumentTranslation.StorageInputType right) { throw null; }
        public static implicit operator Azure.AI.Translator.DocumentTranslation.StorageInputType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translator.DocumentTranslation.StorageInputType left, Azure.AI.Translator.DocumentTranslation.StorageInputType right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.AI.Translator.DocumentTranslation.DocumentFilter Filter { get { throw null; } set { } }
        public string LanguageCode { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranslationStatus : System.IEquatable<Azure.AI.Translator.DocumentTranslation.TranslationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranslationStatus(string value) { throw null; }
        public static Azure.AI.Translator.DocumentTranslation.TranslationStatus Cancelled { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.TranslationStatus Cancelling { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.TranslationStatus Failed { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.TranslationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.TranslationStatus Running { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.TranslationStatus Succeeded { get { throw null; } }
        public static Azure.AI.Translator.DocumentTranslation.TranslationStatus ValidationFailed { get { throw null; } }
        public bool Equals(Azure.AI.Translator.DocumentTranslation.TranslationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translator.DocumentTranslation.TranslationStatus left, Azure.AI.Translator.DocumentTranslation.TranslationStatus right) { throw null; }
        public static implicit operator Azure.AI.Translator.DocumentTranslation.TranslationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translator.DocumentTranslation.TranslationStatus left, Azure.AI.Translator.DocumentTranslation.TranslationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslationStatusResult
    {
        internal TranslationStatusResult() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public int DocumentsCancelled { get { throw null; } }
        public int DocumentsFailed { get { throw null; } }
        public int DocumentsInProgress { get { throw null; } }
        public int DocumentsNotStarted { get { throw null; } }
        public int DocumentsSucceeded { get { throw null; } }
        public int DocumentsTotal { get { throw null; } }
        public Azure.AI.Translator.DocumentTranslation.DocumentTranslationError Error { get { throw null; } }
        public bool HasCompleted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.Translator.DocumentTranslation.TranslationStatus Status { get { throw null; } }
        public long TotalCharactersCharged { get { throw null; } }
        public string TranslationId { get { throw null; } }
    }
    public partial class TranslationTarget
    {
        public TranslationTarget(System.Uri targetUri, string languageCode) { }
        public string CategoryId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translator.DocumentTranslation.TranslationGlossary> Glossaries { get { throw null; } }
        public string LanguageCode { get { throw null; } }
        public System.Uri TargetUri { get { throw null; } }
    }
}
