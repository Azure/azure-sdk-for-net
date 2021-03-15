namespace Azure.AI.DocumentTranslation
{
    public partial class DocumentTranslationClient
    {
        protected DocumentTranslationClient() { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.DocumentTranslation.DocumentTranslationClientOptions options) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.DocumentTranslation.DocumentTranslationClientOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.Models.FileFormat>> GetDocumentFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.Models.FileFormat>>> GetDocumentFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.Models.FileFormat>> GetGlossaryFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.DocumentTranslation.Models.FileFormat>>> GetGlossaryFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentTranslation.Models.TranslationStatusDetail> GetTranslations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentTranslation.Models.TranslationStatusDetail> GetTranslationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.DocumentTranslation.DocumentTranslationOperation StartTranslation(System.Collections.Generic.IEnumerable<Azure.AI.DocumentTranslation.Models.TranslationConfiguration> configurations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.DocumentTranslation.DocumentTranslationOperation StartTranslation(System.Uri sourceBlobContainerSas, System.Uri targetBlobContainerSas, string targetLanguageCode, Azure.AI.DocumentTranslation.Models.TranslationGlossary glossary = null, Azure.AI.DocumentTranslation.Models.TranslationOperationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.DocumentTranslation.DocumentTranslationOperation> StartTranslationAsync(System.Collections.Generic.IEnumerable<Azure.AI.DocumentTranslation.Models.TranslationConfiguration> configurations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.DocumentTranslation.DocumentTranslationOperation> StartTranslationAsync(System.Uri sourceBlobContainerSas, System.Uri targetBlobContainerSas, string targetLanguageCode, Azure.AI.DocumentTranslation.Models.TranslationGlossary glossary = null, Azure.AI.DocumentTranslation.Models.TranslationOperationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DocumentTranslationOperation : Azure.AI.DocumentTranslation.PageableOperation<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail>
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
        public Azure.AI.DocumentTranslation.Models.TranslationStatus Status { get { throw null; } }
        public override Azure.AsyncPageable<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail> GetAllDocumentsStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail> GetAllDocumentsStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail> GetDocumentStatus(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail>> GetDocumentStatusAsync(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail> GetValues() { throw null; }
        public override Azure.AsyncPageable<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail> GetValuesAsync() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.DocumentTranslation.Models.DocumentStatusDetail>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class PageableOperation<T> : Azure.Operation<Azure.AsyncPageable<T>> where T : notnull
    {
        protected PageableOperation() { }
        public override Azure.AsyncPageable<T> Value { get { throw null; } }
        public abstract Azure.Pageable<T> GetValues();
        public abstract Azure.AsyncPageable<T> GetValuesAsync();
    }
}
namespace Azure.AI.DocumentTranslation.Models
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
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationError Error { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Uri LocationUri { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.TranslationStatus Status { get { throw null; } }
        public string TranslateTo { get { throw null; } }
        public float TranslationProgressPercentage { get { throw null; } }
    }
    public partial class DocumentTranslationError
    {
        internal DocumentTranslationError() { }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode? ErrorCode { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationErrorCode : System.IEquatable<Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTranslationErrorCode(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode RequestRateTooHigh { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode Unauthorized { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode left, Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode left, Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationInnerError
    {
        internal DocumentTranslationInnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class FileFormat
    {
        internal FileFormat() { }
        public System.Collections.Generic.IReadOnlyList<string> ContentTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileExtensions { get { throw null; } }
        public string Format { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Versions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSource : System.IEquatable<Azure.AI.DocumentTranslation.Models.StorageSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSource(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.StorageSource AzureBlob { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.StorageSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.StorageSource left, Azure.AI.DocumentTranslation.Models.StorageSource right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.StorageSource (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.StorageSource left, Azure.AI.DocumentTranslation.Models.StorageSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.AI.DocumentTranslation.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.StorageType File { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.StorageType Folder { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.StorageType left, Azure.AI.DocumentTranslation.Models.StorageType right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.StorageType left, Azure.AI.DocumentTranslation.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslationConfiguration
    {
        public TranslationConfiguration(Azure.AI.DocumentTranslation.Models.TranslationSource source, System.Collections.Generic.IEnumerable<Azure.AI.DocumentTranslation.Models.TranslationTarget> targets) { }
        public Azure.AI.DocumentTranslation.Models.TranslationSource Source { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.StorageType? StorageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.DocumentTranslation.Models.TranslationTarget> Targets { get { throw null; } }
    }
    public partial class TranslationGlossary
    {
        public TranslationGlossary(System.Uri glossaryUri) { }
        public string FormatVersion { get { throw null; } set { } }
        public System.Uri GlossaryUri { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class TranslationOperationOptions
    {
        public TranslationOperationOptions() { }
        public string Category { get { throw null; } set { } }
        public Azure.AI.DocumentTranslation.Models.DocumentFilter Filter { get { throw null; } set { } }
        public string SourceLanguage { get { throw null; } set { } }
        public Azure.AI.DocumentTranslation.Models.StorageType? StorageType { get { throw null; } set { } }
    }
    public partial class TranslationSource
    {
        public TranslationSource(System.Uri sourceUri) { }
        public Azure.AI.DocumentTranslation.Models.DocumentFilter Filter { get { throw null; } set { } }
        public string LanguageCode { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranslationStatus : System.IEquatable<Azure.AI.DocumentTranslation.Models.TranslationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranslationStatus(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Cancelled { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Cancelling { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Failed { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus NotStarted { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Running { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Succeeded { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus ValidationFailed { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.TranslationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.TranslationStatus left, Azure.AI.DocumentTranslation.Models.TranslationStatus right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.TranslationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.TranslationStatus left, Azure.AI.DocumentTranslation.Models.TranslationStatus right) { throw null; }
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
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationError Error { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.TranslationStatus Status { get { throw null; } }
        public long TotalCharacterCharged { get { throw null; } }
        public string TranslationId { get { throw null; } }
    }
    public partial class TranslationTarget
    {
        public TranslationTarget(System.Uri targetUri, string languageCode) { }
        public string Category { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.DocumentTranslation.Models.TranslationGlossary> Glossaries { get { throw null; } }
        public string LanguageCode { get { throw null; } }
        public System.Uri TargetUri { get { throw null; } }
    }
}
