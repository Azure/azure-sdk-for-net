namespace Azure.AI.Translation.Document
{
    public partial class DocumentFilterOrder
    {
        public DocumentFilterOrder(Azure.AI.Translation.Document.DocumentFilterProperty property, bool ascending = true) { }
        public bool Ascending { get { throw null; } set { } }
        public Azure.AI.Translation.Document.DocumentFilterProperty Property { get { throw null; } set { } }
    }
    public enum DocumentFilterProperty
    {
        CreatedOn = 0,
    }
    public partial class DocumentStatusResult
    {
        internal DocumentStatusResult() { }
        public long CharactersCharged { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Uri SourceDocumentUri { get { throw null; } }
        public Azure.AI.Translation.Document.DocumentTranslationStatus Status { get { throw null; } }
        public System.Uri TranslatedDocumentUri { get { throw null; } }
        public string TranslatedToLanguageCode { get { throw null; } }
        public float TranslationProgressPercentage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationAudience : System.IEquatable<Azure.AI.Translation.Document.DocumentTranslationAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTranslationAudience(string value) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslationAudience AzureChina { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.Translation.Document.DocumentTranslationAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Document.DocumentTranslationAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Document.DocumentTranslationAudience left, Azure.AI.Translation.Document.DocumentTranslationAudience right) { throw null; }
        public static implicit operator Azure.AI.Translation.Document.DocumentTranslationAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Document.DocumentTranslationAudience left, Azure.AI.Translation.Document.DocumentTranslationAudience right) { throw null; }
        public override string ToString() { throw null; }
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
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.DocumentTranslationFileFormat>> GetSupportedDocumentFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.DocumentTranslationFileFormat>>> GetSupportedDocumentFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.DocumentTranslationFileFormat>> GetSupportedGlossaryFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.DocumentTranslationFileFormat>>> GetSupportedGlossaryFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translation.Document.TranslationStatusResult> GetTranslationStatuses(Azure.AI.Translation.Document.GetTranslationStatusesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translation.Document.TranslationStatusResult> GetTranslationStatusesAsync(Azure.AI.Translation.Document.GetTranslationStatusesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.AI.Translation.Document.DocumentTranslationAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public partial class DocumentTranslationFileFormat
    {
        internal DocumentTranslationFileFormat() { }
        public System.Collections.Generic.IReadOnlyList<string> ContentTypes { get { throw null; } }
        public string DefaultFormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileExtensions { get { throw null; } }
        public string Format { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FormatVersions { get { throw null; } }
    }
    public partial class DocumentTranslationInput
    {
        public DocumentTranslationInput(Azure.AI.Translation.Document.TranslationSource source, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.TranslationTarget> targets) { }
        public DocumentTranslationInput(System.Uri sourceUri, System.Uri targetUri, string targetLanguageCode, Azure.AI.Translation.Document.TranslationGlossary glossary = null) { }
        public Azure.AI.Translation.Document.TranslationSource Source { get { throw null; } }
        public Azure.AI.Translation.Document.StorageInputUriKind? StorageUriKind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.TranslationTarget> Targets { get { throw null; } }
        public void AddTarget(System.Uri targetUri, string languageCode, Azure.AI.Translation.Document.TranslationGlossary glossary = null, string categoryId = null) { }
    }
    public static partial class DocumentTranslationModelFactory
    {
        public static Azure.AI.Translation.Document.DocumentStatusResult DocumentStatusResult(string id, System.Uri sourceDocumentUri, System.BinaryData error, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, string translatedTo, float progress, long charactersCharged) { throw null; }
        public static Azure.AI.Translation.Document.DocumentStatusResult DocumentStatusResult(string id, System.Uri sourceDocumentUri, System.Uri translatedDocumentUri, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, string translatedTo, float progress, long charactersCharged) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslationFileFormat DocumentTranslationFileFormat(string format = null, System.Collections.Generic.IEnumerable<string> fileExtensions = null, System.Collections.Generic.IEnumerable<string> contentTypes = null, string defaultFormatVersion = null, System.Collections.Generic.IEnumerable<string> formatVersions = null) { throw null; }
        public static Azure.AI.Translation.Document.TranslationStatusResult TranslationStatusResult(string id, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, System.BinaryData error, int total, int failed, int success, int inProgress, int notYetStarted, int canceled, long totalCharacterCharged) { throw null; }
    }
    public partial class DocumentTranslationOperation : Azure.PageableOperation<Azure.AI.Translation.Document.DocumentStatusResult>
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
        public override Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatusResult> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Document.DocumentStatusResult> GetDocumentStatus(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.DocumentStatusResult>> GetDocumentStatusAsync(string documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translation.Document.DocumentStatusResult> GetDocumentStatuses(Azure.AI.Translation.Document.GetDocumentStatusesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatusResult> GetDocumentStatusesAsync(Azure.AI.Translation.Document.GetDocumentStatusesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.Translation.Document.DocumentStatusResult> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatusResult> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatusResult>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatusResult>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class GetDocumentStatusesOptions
    {
        public GetDocumentStatusesOptions() { }
        public System.DateTimeOffset? CreatedAfter { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedBefore { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.DocumentFilterOrder> OrderBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.DocumentTranslationStatus> Statuses { get { throw null; } }
    }
    public partial class GetTranslationStatusesOptions
    {
        public GetTranslationStatusesOptions() { }
        public System.DateTimeOffset? CreatedAfter { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedBefore { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.TranslationFilterOrder> OrderBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.DocumentTranslationStatus> Statuses { get { throw null; } }
    }
    public enum StorageInputUriKind
    {
        File = 0,
        Folder = 1,
    }
    public partial class TranslationFilterOrder
    {
        public TranslationFilterOrder(Azure.AI.Translation.Document.TranslationFilterProperty property, bool ascending = true) { }
        public bool Ascending { get { throw null; } set { } }
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
    public partial class TranslationStatusResult
    {
        internal TranslationStatusResult() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public int DocumentsCanceled { get { throw null; } }
        public int DocumentsFailed { get { throw null; } }
        public int DocumentsInProgress { get { throw null; } }
        public int DocumentsNotStarted { get { throw null; } }
        public int DocumentsSucceeded { get { throw null; } }
        public int DocumentsTotal { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
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
