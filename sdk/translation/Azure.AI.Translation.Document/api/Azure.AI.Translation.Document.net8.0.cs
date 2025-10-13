namespace Azure.AI.Translation.Document
{
    public partial class AzureAITranslationDocumentContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAITranslationDocumentContext() { }
        public static Azure.AI.Translation.Document.AzureAITranslationDocumentContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BatchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.BatchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.BatchOptions>
    {
        public BatchOptions() { }
        public bool? TranslateTextWithinImage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.BatchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.BatchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.BatchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.BatchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.BatchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.BatchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.BatchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
    public partial class DocumentStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentStatusResult>
    {
        internal DocumentStatusResult() { }
        public long CharactersCharged { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Uri SourceDocumentUri { get { throw null; } }
        public Azure.AI.Translation.Document.DocumentTranslationStatus Status { get { throw null; } }
        public int? TotalImageScansFailed { get { throw null; } }
        public int? TotalImageScansSucceeded { get { throw null; } }
        public System.Uri TranslatedDocumentUri { get { throw null; } }
        public string TranslatedToLanguageCode { get { throw null; } }
        public float TranslationProgressPercentage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentStatusResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTranslateContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslateContent>
    {
        public DocumentTranslateContent(Azure.AI.Translation.Document.MultipartFormFileData document) { }
        public DocumentTranslateContent(Azure.AI.Translation.Document.MultipartFormFileData document, System.Collections.Generic.IList<Azure.AI.Translation.Document.MultipartFormFileData> glossaries) { }
        public Azure.AI.Translation.Document.MultipartFormFileData MultipartDocument { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.MultipartFormFileData> MultipartGlossary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentTranslateContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentTranslateContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelTranslation(System.Guid translationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Document.TranslationStatusResult> CancelTranslation(System.Guid translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelTranslationAsync(System.Guid translationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.TranslationStatusResult>> CancelTranslationAsync(System.Guid translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDocumentsStatus(System.Guid translationId, int? maxCount, int? skip, int? maxpagesize, System.Collections.Generic.IEnumerable<System.Guid> documentIds, System.Collections.Generic.IEnumerable<string> statuses, System.DateTimeOffset? createdDateTimeUtcStart, System.DateTimeOffset? createdDateTimeUtcEnd, System.Collections.Generic.IEnumerable<string> orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translation.Document.DocumentStatusResult> GetDocumentsStatus(System.Guid translationId, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Collections.Generic.IEnumerable<System.Guid> documentIds = null, System.Collections.Generic.IEnumerable<string> statuses = null, System.DateTimeOffset? createdDateTimeUtcStart = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateTimeUtcEnd = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDocumentsStatusAsync(System.Guid translationId, int? maxCount, int? skip, int? maxpagesize, System.Collections.Generic.IEnumerable<System.Guid> documentIds, System.Collections.Generic.IEnumerable<string> statuses, System.DateTimeOffset? createdDateTimeUtcStart, System.DateTimeOffset? createdDateTimeUtcEnd, System.Collections.Generic.IEnumerable<string> orderby, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translation.Document.DocumentStatusResult> GetDocumentsStatusAsync(System.Guid translationId, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Collections.Generic.IEnumerable<System.Guid> documentIds = null, System.Collections.Generic.IEnumerable<string> statuses = null, System.DateTimeOffset? createdDateTimeUtcStart = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateTimeUtcEnd = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDocumentStatus(System.Guid translationId, System.Guid documentId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Document.DocumentStatusResult> GetDocumentStatus(System.Guid translationId, System.Guid documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDocumentStatusAsync(System.Guid translationId, System.Guid documentId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.DocumentStatusResult>> GetDocumentStatusAsync(System.Guid translationId, System.Guid documentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.AI.Translation.Document.SupportedFileFormats> GetSupportedDocumentFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.SupportedFileFormats>> GetSupportedDocumentFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Document.SupportedFileFormats> GetSupportedFormats(Azure.AI.Translation.Document.FileFormatType? type = default(Azure.AI.Translation.Document.FileFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSupportedFormats(string type, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.SupportedFileFormats>> GetSupportedFormatsAsync(Azure.AI.Translation.Document.FileFormatType? type = default(Azure.AI.Translation.Document.FileFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSupportedFormatsAsync(string type, Azure.RequestContext context) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.AI.Translation.Document.SupportedFileFormats> GetSupportedGlossaryFormats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.SupportedFileFormats>> GetSupportedGlossaryFormatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTranslationsStatus(int? maxCount, int? skip, int? maxpagesize, System.Collections.Generic.IEnumerable<System.Guid> ids, System.Collections.Generic.IEnumerable<string> statuses, System.DateTimeOffset? createdDateTimeUtcStart, System.DateTimeOffset? createdDateTimeUtcEnd, System.Collections.Generic.IEnumerable<string> orderBy, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translation.Document.TranslationStatusResult> GetTranslationsStatus(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Collections.Generic.IEnumerable<System.Guid> ids = null, System.Collections.Generic.IEnumerable<string> statuses = null, System.DateTimeOffset? createdDateTimeUtcStart = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateTimeUtcEnd = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTranslationsStatusAsync(int? maxCount, int? skip, int? maxpagesize, System.Collections.Generic.IEnumerable<System.Guid> ids, System.Collections.Generic.IEnumerable<string> statuses, System.DateTimeOffset? createdDateTimeUtcStart, System.DateTimeOffset? createdDateTimeUtcEnd, System.Collections.Generic.IEnumerable<string> orderBy, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translation.Document.TranslationStatusResult> GetTranslationsStatusAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Collections.Generic.IEnumerable<System.Guid> ids = null, System.Collections.Generic.IEnumerable<string> statuses = null, System.DateTimeOffset? createdDateTimeUtcStart = default(System.DateTimeOffset?), System.DateTimeOffset? createdDateTimeUtcEnd = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTranslationStatus(System.Guid translationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Document.TranslationStatusResult> GetTranslationStatus(System.Guid translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTranslationStatusAsync(System.Guid translationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Document.TranslationStatusResult>> GetTranslationStatusAsync(System.Guid translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Translation.Document.TranslationStatusResult> GetTranslationStatuses(Azure.AI.Translation.Document.GetTranslationStatusesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Translation.Document.TranslationStatusResult> GetTranslationStatusesAsync(Azure.AI.Translation.Document.GetTranslationStatusesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Translation.Document.DocumentTranslationOperation StartTranslation(Azure.AI.Translation.Document.DocumentTranslationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.Translation.Document.TranslationStatusResult> StartTranslation(Azure.WaitUntil waitUntil, Azure.AI.Translation.Document.TranslationBatch body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> StartTranslation(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AI.Translation.Document.DocumentTranslationOperation StartTranslation(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.DocumentTranslationInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Translation.Document.DocumentTranslationOperation> StartTranslationAsync(Azure.AI.Translation.Document.DocumentTranslationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Translation.Document.TranslationStatusResult>> StartTranslationAsync(Azure.WaitUntil waitUntil, Azure.AI.Translation.Document.TranslationBatch body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> StartTranslationAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Translation.Document.DocumentTranslationOperation> StartTranslationAsync(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.DocumentTranslationInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DocumentTranslationClientOptions : Azure.Core.ClientOptions
    {
        public DocumentTranslationClientOptions(Azure.AI.Translation.Document.DocumentTranslationClientOptions.ServiceVersion version = Azure.AI.Translation.Document.DocumentTranslationClientOptions.ServiceVersion.V2024_11_01_Preview) { }
        public Azure.AI.Translation.Document.DocumentTranslationAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2024_05_01 = 1,
            V2024_11_01_Preview = 2,
        }
    }
    public partial class DocumentTranslationFileFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslationFileFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationFileFormat>
    {
        internal DocumentTranslationFileFormat() { }
        public System.Collections.Generic.IReadOnlyList<string> ContentTypes { get { throw null; } }
        public string DefaultFormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileExtensions { get { throw null; } }
        public string Format { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FormatVersions { get { throw null; } }
        public Azure.AI.Translation.Document.FileFormatType? Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentTranslationFileFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslationFileFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslationFileFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentTranslationFileFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationFileFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationFileFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationFileFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTranslationInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationInput>
    {
        public DocumentTranslationInput(Azure.AI.Translation.Document.TranslationSource source, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.TranslationTarget> targets) { }
        public DocumentTranslationInput(System.Uri sourceUri, System.Uri targetUri, string targetLanguageCode, Azure.AI.Translation.Document.TranslationGlossary glossary = null) { }
        public Azure.AI.Translation.Document.TranslationSource Source { get { throw null; } }
        public Azure.AI.Translation.Document.StorageInputUriKind? StorageUriKind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.TranslationTarget> Targets { get { throw null; } }
        public void AddTarget(System.Uri targetUri, string languageCode, Azure.AI.Translation.Document.TranslationGlossary glossary = null, string categoryId = null) { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentTranslationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.DocumentTranslationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.DocumentTranslationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.DocumentTranslationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DocumentTranslationModelFactory
    {
        public static Azure.AI.Translation.Document.DocumentStatusResult DocumentStatusResult(string id, System.Uri sourceDocumentUri, System.BinaryData error, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, string translatedTo, float progress, long charactersCharged) { throw null; }
        public static Azure.AI.Translation.Document.DocumentStatusResult DocumentStatusResult(string id, System.Uri sourceDocumentUri, System.Uri translatedDocumentUri, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, string translatedTo, float progress, long charactersCharged) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslateContent DocumentTranslateContent(System.IO.Stream document = null, System.Collections.Generic.IEnumerable<System.IO.Stream> glossary = null) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslationFileFormat DocumentTranslationFileFormat(string format = null, System.Collections.Generic.IEnumerable<string> fileExtensions = null, System.Collections.Generic.IEnumerable<string> contentTypes = null, string defaultFormatVersion = null, System.Collections.Generic.IEnumerable<string> formatVersions = null, Azure.AI.Translation.Document.FileFormatType? type = default(Azure.AI.Translation.Document.FileFormatType?)) { throw null; }
        public static Azure.AI.Translation.Document.DocumentTranslationInput DocumentTranslationInput(Azure.AI.Translation.Document.TranslationSource source = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.TranslationTarget> targets = null, Azure.AI.Translation.Document.StorageInputUriKind? storageUriKind = default(Azure.AI.Translation.Document.StorageInputUriKind?)) { throw null; }
        public static Azure.AI.Translation.Document.SupportedFileFormats SupportedFileFormats(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.DocumentTranslationFileFormat> value = null) { throw null; }
        public static Azure.AI.Translation.Document.TranslationGlossary TranslationGlossary(System.Uri glossaryUri = null, string format = null, string formatVersion = null, Azure.AI.Translation.Document.TranslationStorageSource? storageSource = default(Azure.AI.Translation.Document.TranslationStorageSource?)) { throw null; }
        public static Azure.AI.Translation.Document.TranslationStatusResult TranslationStatusResult(string id, System.DateTimeOffset createdOn, System.DateTimeOffset lastModified, Azure.AI.Translation.Document.DocumentTranslationStatus status, System.BinaryData error, int total, int failed, int success, int inProgress, int notYetStarted, int canceled, long totalCharacterCharged) { throw null; }
        public static Azure.AI.Translation.Document.TranslationTarget TranslationTarget(System.Uri targetUri = null, string categoryId = null, string languageCode = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.TranslationGlossary> glossaries = null, Azure.AI.Translation.Document.TranslationStorageSource? storageSource = default(Azure.AI.Translation.Document.TranslationStorageSource?)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileFormatType : System.IEquatable<Azure.AI.Translation.Document.FileFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileFormatType(string value) { throw null; }
        public static Azure.AI.Translation.Document.FileFormatType Document { get { throw null; } }
        public static Azure.AI.Translation.Document.FileFormatType Glossary { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Document.FileFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Document.FileFormatType left, Azure.AI.Translation.Document.FileFormatType right) { throw null; }
        public static implicit operator Azure.AI.Translation.Document.FileFormatType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Document.FileFormatType left, Azure.AI.Translation.Document.FileFormatType right) { throw null; }
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
    public partial class MultipartFormFileData
    {
        public MultipartFormFileData(string name, System.IO.Stream content, string contentType) { }
        public MultipartFormFileData(string name, System.IO.Stream content, string contentType, System.Collections.Generic.IDictionary<string, string> headers) { }
        public System.IO.Stream Content { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SingleDocumentTranslationClient
    {
        protected SingleDocumentTranslationClient() { }
        public SingleDocumentTranslationClient(System.Uri endpoint) { }
        public SingleDocumentTranslationClient(System.Uri endpoint, Azure.AI.Translation.Document.DocumentTranslationClientOptions options) { }
        public SingleDocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public SingleDocumentTranslationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Translation.Document.DocumentTranslationClientOptions options) { }
        public SingleDocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public SingleDocumentTranslationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Translation.Document.DocumentTranslationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.BinaryData> Translate(string targetLanguage, Azure.AI.Translation.Document.DocumentTranslateContent documentTranslateContent, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), bool? translateTextWithinImage = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Translate(string targetLanguage, Azure.Core.RequestContent content, string contentType, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), bool? translateTextWithinImage = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> TranslateAsync(string targetLanguage, Azure.AI.Translation.Document.DocumentTranslateContent documentTranslateContent, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), bool? translateTextWithinImage = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TranslateAsync(string targetLanguage, Azure.Core.RequestContent content, string contentType, string sourceLanguage = null, string category = null, bool? allowFallback = default(bool?), bool? translateTextWithinImage = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public enum StorageInputUriKind
    {
        File = 0,
        Folder = 1,
    }
    public partial class SupportedFileFormats : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.SupportedFileFormats>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.SupportedFileFormats>
    {
        internal SupportedFileFormats() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Document.DocumentTranslationFileFormat> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.SupportedFileFormats System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.SupportedFileFormats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.SupportedFileFormats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.SupportedFileFormats System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.SupportedFileFormats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.SupportedFileFormats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.SupportedFileFormats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationBatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationBatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationBatch>
    {
        public TranslationBatch(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Document.DocumentTranslationInput> inputs) { }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.DocumentTranslationInput> Inputs { get { throw null; } }
        public Azure.AI.Translation.Document.BatchOptions Options { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationBatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationBatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationBatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationBatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationBatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationBatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationBatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TranslationGlossary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationGlossary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationGlossary>
    {
        public TranslationGlossary(System.Uri glossaryUri, string format) { }
        public string Format { get { throw null; } }
        public string FormatVersion { get { throw null; } set { } }
        public System.Uri GlossaryUri { get { throw null; } }
        public Azure.AI.Translation.Document.TranslationStorageSource? StorageSource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationGlossary System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationGlossary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationGlossary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationGlossary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationGlossary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationGlossary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationGlossary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationSource>
    {
        public TranslationSource(System.Uri sourceUri) { }
        public TranslationSource(System.Uri sourceUri, string languageCode = null, string storageSource = null, string prefix = null, string suffix = null) { }
        public string LanguageCode { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } }
        public Azure.AI.Translation.Document.TranslationStorageSource? StorageSource { get { throw null; } set { } }
        public string Suffix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationStatusResult>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranslationStorageSource : System.IEquatable<Azure.AI.Translation.Document.TranslationStorageSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranslationStorageSource(string value) { throw null; }
        public static Azure.AI.Translation.Document.TranslationStorageSource AzureBlob { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Document.TranslationStorageSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Document.TranslationStorageSource left, Azure.AI.Translation.Document.TranslationStorageSource right) { throw null; }
        public static implicit operator Azure.AI.Translation.Document.TranslationStorageSource (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Document.TranslationStorageSource left, Azure.AI.Translation.Document.TranslationStorageSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslationTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationTarget>
    {
        public TranslationTarget(System.Uri targetUri, string languageCode) { }
        public string CategoryId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Document.TranslationGlossary> Glossaries { get { throw null; } }
        public string LanguageCode { get { throw null; } }
        public Azure.AI.Translation.Document.TranslationStorageSource? StorageSource { get { throw null; } set { } }
        public System.Uri TargetUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Document.TranslationTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Document.TranslationTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Document.TranslationTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AITranslationDocumentClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Document.DocumentTranslationClient, Azure.AI.Translation.Document.DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Document.DocumentTranslationClient, Azure.AI.Translation.Document.DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Document.DocumentTranslationClient, Azure.AI.Translation.Document.DocumentTranslationClientOptions> AddDocumentTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Document.SingleDocumentTranslationClient, Azure.AI.Translation.Document.DocumentTranslationClientOptions> AddSingleDocumentTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Document.SingleDocumentTranslationClient, Azure.AI.Translation.Document.DocumentTranslationClientOptions> AddSingleDocumentTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Document.SingleDocumentTranslationClient, Azure.AI.Translation.Document.DocumentTranslationClientOptions> AddSingleDocumentTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
