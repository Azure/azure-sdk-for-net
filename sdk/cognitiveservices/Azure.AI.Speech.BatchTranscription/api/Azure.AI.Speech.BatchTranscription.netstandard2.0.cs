namespace Azure.AI.Speech.BatchTranscription
{
    public static partial class AISpeechBatchTranscriptionModelFactory
    {
        public static Azure.AI.Speech.BatchTranscription.EntityError EntityError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.FileLinks FileLinks(System.Uri content = null) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.TranscriptionFile TranscriptionFile(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), Azure.AI.Speech.BatchTranscription.FileKind kind = default(Azure.AI.Speech.BatchTranscription.FileKind), Azure.AI.Speech.BatchTranscription.FileLinks links = null, string displayName = null, Azure.AI.Speech.BatchTranscription.FileProperties properties = null, string id = null, System.Uri self = null) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.TranscriptionJob TranscriptionJob(Azure.AI.Speech.BatchTranscription.TranscriptionProperties properties = null, string id = null, System.Uri self = null, Azure.AI.Speech.BatchTranscription.EntityReference model = null, Azure.AI.Speech.BatchTranscription.EntityReference dataset = null, System.Collections.Generic.IList<System.Uri> contentUrls = null, System.Uri contentContainerUrl = null, string locale = null, string displayName = null, string description = null, System.Collections.Generic.IDictionary<string, string> customProperties = null, System.DateTimeOffset? lastActionDateTime = default(System.DateTimeOffset?), Azure.AI.Speech.BatchTranscription.TranscriptionStatus status = default(Azure.AI.Speech.BatchTranscription.TranscriptionStatus), System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class AzureAISpeechBatchTranscriptionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAISpeechBatchTranscriptionContext() { }
        public static Azure.AI.Speech.BatchTranscription.AzureAISpeechBatchTranscriptionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BatchTranscriptionClient
    {
        protected BatchTranscriptionClient() { }
        public BatchTranscriptionClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public BatchTranscriptionClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Speech.BatchTranscription.BatchTranscriptionClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteTranscription(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTranscriptionAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTranscription(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Speech.BatchTranscription.TranscriptionJob> GetTranscription(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTranscriptionAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Speech.BatchTranscription.TranscriptionJob>> GetTranscriptionAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTranscriptionFiles(string id, int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Speech.BatchTranscription.TranscriptionFile> GetTranscriptionFiles(string id, int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTranscriptionFilesAsync(string id, int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Speech.BatchTranscription.TranscriptionFile> GetTranscriptionFilesAsync(string id, int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTranscriptions(int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Speech.BatchTranscription.TranscriptionJob> GetTranscriptions(int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTranscriptionsAsync(int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Speech.BatchTranscription.TranscriptionJob> GetTranscriptionsAsync(int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Speech.BatchTranscription.TranscriptionJob> StartTranscription(Azure.AI.Speech.BatchTranscription.TranscriptionJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartTranscription(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Speech.BatchTranscription.TranscriptionJob>> StartTranscriptionAsync(Azure.AI.Speech.BatchTranscription.TranscriptionJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartTranscriptionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Speech.BatchTranscription.TranscriptionJob> Transcribe(Azure.AI.Speech.BatchTranscription.TranscriptionJob resource, Azure.WaitUntil waitUntil, System.TimeSpan? pollingInterval = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Speech.BatchTranscription.TranscriptionJob>> TranscribeAsync(Azure.AI.Speech.BatchTranscription.TranscriptionJob resource, Azure.WaitUntil waitUntil, System.TimeSpan? pollingInterval = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchTranscriptionClientOptions : Azure.Core.ClientOptions
    {
        public BatchTranscriptionClientOptions(Azure.AI.Speech.BatchTranscription.BatchTranscriptionClientOptions.ServiceVersion version = Azure.AI.Speech.BatchTranscription.BatchTranscriptionClientOptions.ServiceVersion.V2025_10_15) { }
        public enum ServiceVersion
        {
            V2025_10_15 = 1,
        }
    }
    public partial class BestPhrase
    {
        public BestPhrase() { }
        public float Confidence { get { throw null; } }
        public string Display { get { throw null; } }
        public string InverseTextNormalization { get { throw null; } }
        public string Lexical { get { throw null; } }
        public string MaskedInverseTextNormalization { get { throw null; } }
    }
    public partial class CombinedRecognizedPhrase
    {
        public CombinedRecognizedPhrase() { }
        public int Channel { get { throw null; } }
        public string Display { get { throw null; } }
        public string InverseTextNormalization { get { throw null; } }
        public string Lexical { get { throw null; } }
        public string MaskedInverseTextNormalization { get { throw null; } }
    }
    public partial class DiarizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.DiarizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.DiarizationProperties>
    {
        public DiarizationProperties(bool enabled, int maxSpeakers) { }
        public bool Enabled { get { throw null; } set { } }
        public int MaxSpeakers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.DiarizationProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.DiarizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.DiarizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.DiarizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.DiarizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.DiarizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.DiarizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.EntityError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityError>
    {
        public EntityError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.EntityError System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.EntityError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.EntityError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.EntityError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.EntityReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityReference>
    {
        public EntityReference(System.Uri self) { }
        public System.Uri Self { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.EntityReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.EntityReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.EntityReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.EntityReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.EntityReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileKind : System.IEquatable<Azure.AI.Speech.BatchTranscription.FileKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileKind(string value) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.FileKind AcousticDataArchive { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind AcousticDataTranscriptionV2 { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind Audio { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind DatasetReport { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind EvaluationDetails { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind LanguageData { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind ModelReport { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind OutputFormattingData { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind PronunciationData { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind Transcription { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.FileKind TranscriptionReport { get { throw null; } }
        public bool Equals(Azure.AI.Speech.BatchTranscription.FileKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.BatchTranscription.FileKind left, Azure.AI.Speech.BatchTranscription.FileKind right) { throw null; }
        public static implicit operator Azure.AI.Speech.BatchTranscription.FileKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.BatchTranscription.FileKind left, Azure.AI.Speech.BatchTranscription.FileKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileLinks : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.FileLinks>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileLinks>
    {
        internal FileLinks() { }
        public System.Uri Content { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.FileLinks System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.FileLinks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.FileLinks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.FileLinks System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileLinks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileLinks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileLinks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.FileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileProperties>
    {
        internal FileProperties() { }
        public System.TimeSpan Duration { get { throw null; } }
        public int Size { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.FileProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.FileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.FileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.FileProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.FileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LanguageIdentificationMode : System.IEquatable<Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LanguageIdentificationMode(string value) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode Continuous { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode Single { get { throw null; } }
        public bool Equals(Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode left, Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode right) { throw null; }
        public static implicit operator Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode left, Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LanguageIdentificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties>
    {
        public LanguageIdentificationProperties(System.Collections.Generic.IEnumerable<string> candidateLocales) { }
        public System.Collections.Generic.IList<string> CandidateLocales { get { throw null; } }
        public Azure.AI.Speech.BatchTranscription.LanguageIdentificationMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Speech.BatchTranscription.EntityReference> SpeechModelMapping { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfanityFilterMode : System.IEquatable<Azure.AI.Speech.BatchTranscription.ProfanityFilterMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfanityFilterMode(string value) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.ProfanityFilterMode Masked { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.ProfanityFilterMode None { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.ProfanityFilterMode Removed { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.ProfanityFilterMode Tags { get { throw null; } }
        public bool Equals(Azure.AI.Speech.BatchTranscription.ProfanityFilterMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.BatchTranscription.ProfanityFilterMode left, Azure.AI.Speech.BatchTranscription.ProfanityFilterMode right) { throw null; }
        public static implicit operator Azure.AI.Speech.BatchTranscription.ProfanityFilterMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.BatchTranscription.ProfanityFilterMode left, Azure.AI.Speech.BatchTranscription.ProfanityFilterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PunctuationMode : System.IEquatable<Azure.AI.Speech.BatchTranscription.PunctuationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PunctuationMode(string value) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.PunctuationMode Automatic { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.PunctuationMode Dictated { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.PunctuationMode DictatedAndAutomatic { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.PunctuationMode None { get { throw null; } }
        public bool Equals(Azure.AI.Speech.BatchTranscription.PunctuationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.BatchTranscription.PunctuationMode left, Azure.AI.Speech.BatchTranscription.PunctuationMode right) { throw null; }
        public static implicit operator Azure.AI.Speech.BatchTranscription.PunctuationMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.BatchTranscription.PunctuationMode left, Azure.AI.Speech.BatchTranscription.PunctuationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecognizedPhrase
    {
        public RecognizedPhrase() { }
        public int? Channel { get { throw null; } }
        public System.TimeSpan Duration { get { throw null; } }
        public long DurationInTicks { get { throw null; } }
        public Azure.AI.Speech.BatchTranscription.BestPhrase[] NBest { get { throw null; } }
        public System.TimeSpan Offset { get { throw null; } }
        public long OffsetInTicks { get { throw null; } }
        public string RecognitionStatus { get { throw null; } }
        public int? Speaker { get { throw null; } }
    }
    public partial class TranscriptionFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionFile>
    {
        internal TranscriptionFile() { }
        public System.DateTimeOffset Created { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.FileKind Kind { get { throw null; } }
        public Azure.AI.Speech.BatchTranscription.FileLinks Links { get { throw null; } }
        public Azure.AI.Speech.BatchTranscription.FileProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.TranscriptionFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.TranscriptionFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionFileContent
    {
        public TranscriptionFileContent() { }
        public Azure.AI.Speech.BatchTranscription.CombinedRecognizedPhrase[] CombinedRecognizedPhrases { get { throw null; } }
        public System.TimeSpan Duration { get { throw null; } }
        public long DurationInTicks { get { throw null; } }
        public Azure.AI.Speech.BatchTranscription.RecognizedPhrase[] RecognizedPhrases { get { throw null; } }
        public System.Uri Source { get { throw null; } }
        public System.DateTime Timestamp { get { throw null; } }
    }
    public partial class TranscriptionJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionJob>
    {
        public TranscriptionJob(Azure.AI.Speech.BatchTranscription.TranscriptionProperties properties, string locale, string displayName) { }
        public System.Collections.Generic.IList<System.Uri> Contents { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public Azure.AI.Speech.BatchTranscription.EntityReference Dataset { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.DateTimeOffset? LastActionDateTime { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.EntityReference Model { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.TranscriptionProperties Properties { get { throw null; } set { } }
        public System.Uri SourceContainer { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.TranscriptionStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.TranscriptionJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.TranscriptionJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionProperties>
    {
        public TranscriptionProperties(int timeToLiveHours) { }
        public System.Collections.Generic.IList<int> Channels { get { throw null; } }
        public System.Uri DestinationContainer { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.DiarizationProperties Diarization { get { throw null; } set { } }
        public bool? DisplayFormWordLevelTimestampsEnabled { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.AI.Speech.BatchTranscription.EntityError Error { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.LanguageIdentificationProperties LanguageIdentificationProperties { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.ProfanityFilterMode? ProfanityFilterMode { get { throw null; } set { } }
        public Azure.AI.Speech.BatchTranscription.PunctuationMode? PunctuationMode { get { throw null; } set { } }
        public System.TimeSpan TimeToLive { get { throw null; } }
        public bool? WordLevelTimestampsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.TranscriptionProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.BatchTranscription.TranscriptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.BatchTranscription.TranscriptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.BatchTranscription.TranscriptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranscriptionStatus : System.IEquatable<Azure.AI.Speech.BatchTranscription.TranscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranscriptionStatus(string value) { throw null; }
        public static Azure.AI.Speech.BatchTranscription.TranscriptionStatus Failed { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.TranscriptionStatus NotStarted { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.TranscriptionStatus Running { get { throw null; } }
        public static Azure.AI.Speech.BatchTranscription.TranscriptionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Speech.BatchTranscription.TranscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.BatchTranscription.TranscriptionStatus left, Azure.AI.Speech.BatchTranscription.TranscriptionStatus right) { throw null; }
        public static implicit operator Azure.AI.Speech.BatchTranscription.TranscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.BatchTranscription.TranscriptionStatus left, Azure.AI.Speech.BatchTranscription.TranscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AISpeechBatchTranscriptionClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Speech.BatchTranscription.BatchTranscriptionClient, Azure.AI.Speech.BatchTranscription.BatchTranscriptionClientOptions> AddBatchTranscriptionClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Speech.BatchTranscription.BatchTranscriptionClient, Azure.AI.Speech.BatchTranscription.BatchTranscriptionClientOptions> AddBatchTranscriptionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
