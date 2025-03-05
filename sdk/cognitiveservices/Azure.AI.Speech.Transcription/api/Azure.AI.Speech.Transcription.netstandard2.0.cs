namespace Azure.AI.Speech.Transcription
{
    public static partial class AISpeechTranscriptionModelFactory
    {
        public static Azure.AI.Speech.Transcription.ChannelCombinedPhrases ChannelCombinedPhrases(int? channel = default(int?), string text = null) { throw null; }
        public static Azure.AI.Speech.Transcription.EntityError EntityError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Speech.Transcription.FileLinks FileLinks(System.Uri content = null) { throw null; }
        public static Azure.AI.Speech.Transcription.FileProperties FileProperties(int durationMilliseconds = 0, int size = 0) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscribedPhrase TranscribedPhrase(int? channel = default(int?), int? speaker = default(int?), int offsetMilliseconds = 0, int durationMilliseconds = 0, string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedWord> words = null, string locale = null, float confidence = 0f) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscribedWord TranscribedWord(string text = null, int offsetMilliseconds = 0, int durationMilliseconds = 0) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscribeResult TranscribeResult(int durationMilliseconds = 0, System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.ChannelCombinedPhrases> combinedPhrases = null, System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedPhrase> phrases = null) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionFile TranscriptionFile(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), Azure.AI.Speech.Transcription.FileKind kind = default(Azure.AI.Speech.Transcription.FileKind), Azure.AI.Speech.Transcription.FileLinks links = null, string displayName = null, Azure.AI.Speech.Transcription.FileProperties properties = null, System.Uri self = null) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionJob TranscriptionJob(Azure.AI.Speech.Transcription.TranscriptionLinks links = null, Azure.AI.Speech.Transcription.TranscriptionProperties properties = null, string id = null, System.Uri self = null, Azure.AI.Speech.Transcription.EntityReference model = null, Azure.AI.Speech.Transcription.EntityReference dataset = null, System.Collections.Generic.IEnumerable<System.Uri> contents = null, System.Uri contentContainerUrl = null, string locale = null, string displayName = null, string description = null, System.Collections.Generic.IDictionary<string, string> customProperties = null, System.DateTimeOffset? lastActionDateTime = default(System.DateTimeOffset?), Azure.AI.Speech.Transcription.JobStatus status = default(Azure.AI.Speech.Transcription.JobStatus), System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionLinks TranscriptionLinks(System.Uri files = null) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionProperties TranscriptionProperties(bool? wordLevelTimestampsEnabled = default(bool?), bool? displayFormWordLevelTimestampsEnabled = default(bool?), int? durationMilliseconds = default(int?), System.Collections.Generic.IEnumerable<int> channels = null, System.Uri destinationContainer = null, Azure.AI.Speech.Transcription.PunctuationMode? punctuationMode = default(Azure.AI.Speech.Transcription.PunctuationMode?), Azure.AI.Speech.Transcription.ProfanityFilterMode? profanityFilterMode = default(Azure.AI.Speech.Transcription.ProfanityFilterMode?), int timeToLiveHours = 0, Azure.AI.Speech.Transcription.EntityError error = null, Azure.AI.Speech.Transcription.DiarizationProperties diarization = null, Azure.AI.Speech.Transcription.LanguageIdentificationProperties languageIdentificationProperties = null) { throw null; }
    }
    public partial class BatchTranscription
    {
        protected BatchTranscription() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteTranscription(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTranscriptionAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTranscription(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Speech.Transcription.TranscriptionJob> GetTranscription(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTranscriptionAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Speech.Transcription.TranscriptionJob>> GetTranscriptionAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTranscriptionFiles(string id, int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Speech.Transcription.TranscriptionFile> GetTranscriptionFiles(string id, int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTranscriptionFilesAsync(string id, int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Speech.Transcription.TranscriptionFile> GetTranscriptionFilesAsync(string id, int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTranscriptions(int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Speech.Transcription.TranscriptionJob> GetTranscriptions(int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTranscriptionsAsync(int? maxCount, int? skip, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Speech.Transcription.TranscriptionJob> GetTranscriptionsAsync(int? maxCount = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PatchTranscription(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PatchTranscriptionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Speech.Transcription.TranscriptionJob> SubmitTranscription(Azure.AI.Speech.Transcription.TranscriptionJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitTranscription(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Speech.Transcription.TranscriptionJob>> SubmitTranscriptionAsync(Azure.AI.Speech.Transcription.TranscriptionJob resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitTranscriptionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ChannelCombinedPhrases : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>
    {
        internal ChannelCombinedPhrases() { }
        public int? Channel { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.ChannelCombinedPhrases System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.ChannelCombinedPhrases System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiarizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.DiarizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.DiarizationProperties>
    {
        public DiarizationProperties(bool enabled, int maxSpeakers) { }
        public bool Enabled { get { throw null; } set { } }
        public int MaxSpeakers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.DiarizationProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.DiarizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.DiarizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.DiarizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.DiarizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.DiarizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.DiarizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EntityError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityError>
    {
        public EntityError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.EntityError System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EntityError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EntityError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.EntityError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EntityReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityReference>
    {
        public EntityReference(System.Uri self) { }
        public System.Uri Self { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.EntityReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EntityReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EntityReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.EntityReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EntityReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FastTranscription
    {
        protected FastTranscription() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Transcribe(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Speech.Transcription.TranscribeResult> Transcribe(System.IO.Stream audio, Azure.AI.Speech.Transcription.TranscribeConfig definition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TranscribeAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Speech.Transcription.TranscribeResult>> TranscribeAsync(System.IO.Stream audio, Azure.AI.Speech.Transcription.TranscribeConfig definition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileKind : System.IEquatable<Azure.AI.Speech.Transcription.FileKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileKind(string value) { throw null; }
        public static Azure.AI.Speech.Transcription.FileKind AcousticDataArchive { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind AcousticDataTranscriptionV2 { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind Audio { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind DatasetReport { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind EvaluationDetails { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind LanguageData { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind ModelReport { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind OutputFormattingData { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind PronunciationData { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind Transcription { get { throw null; } }
        public static Azure.AI.Speech.Transcription.FileKind TranscriptionReport { get { throw null; } }
        public bool Equals(Azure.AI.Speech.Transcription.FileKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.Transcription.FileKind left, Azure.AI.Speech.Transcription.FileKind right) { throw null; }
        public static implicit operator Azure.AI.Speech.Transcription.FileKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.Transcription.FileKind left, Azure.AI.Speech.Transcription.FileKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileLinks : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.FileLinks>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileLinks>
    {
        internal FileLinks() { }
        public System.Uri Content { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.FileLinks System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.FileLinks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.FileLinks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.FileLinks System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileLinks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileLinks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileLinks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.FileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileProperties>
    {
        internal FileProperties() { }
        public int DurationMilliseconds { get { throw null; } }
        public int Size { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.FileProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.FileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.FileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.FileProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.FileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.AI.Speech.Transcription.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.AI.Speech.Transcription.JobStatus Failed { get { throw null; } }
        public static Azure.AI.Speech.Transcription.JobStatus NotStarted { get { throw null; } }
        public static Azure.AI.Speech.Transcription.JobStatus Running { get { throw null; } }
        public static Azure.AI.Speech.Transcription.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Speech.Transcription.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.Transcription.JobStatus left, Azure.AI.Speech.Transcription.JobStatus right) { throw null; }
        public static implicit operator Azure.AI.Speech.Transcription.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.Transcription.JobStatus left, Azure.AI.Speech.Transcription.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LanguageIdentificationMode : System.IEquatable<Azure.AI.Speech.Transcription.LanguageIdentificationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LanguageIdentificationMode(string value) { throw null; }
        public static Azure.AI.Speech.Transcription.LanguageIdentificationMode Continuous { get { throw null; } }
        public static Azure.AI.Speech.Transcription.LanguageIdentificationMode Single { get { throw null; } }
        public bool Equals(Azure.AI.Speech.Transcription.LanguageIdentificationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.Transcription.LanguageIdentificationMode left, Azure.AI.Speech.Transcription.LanguageIdentificationMode right) { throw null; }
        public static implicit operator Azure.AI.Speech.Transcription.LanguageIdentificationMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.Transcription.LanguageIdentificationMode left, Azure.AI.Speech.Transcription.LanguageIdentificationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LanguageIdentificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.LanguageIdentificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.LanguageIdentificationProperties>
    {
        public LanguageIdentificationProperties(System.Collections.Generic.IEnumerable<string> candidateLocales) { }
        public System.Collections.Generic.IList<string> CandidateLocales { get { throw null; } }
        public Azure.AI.Speech.Transcription.LanguageIdentificationMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Speech.Transcription.EntityReference> SpeechModelMapping { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.LanguageIdentificationProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.LanguageIdentificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.LanguageIdentificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.LanguageIdentificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.LanguageIdentificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.LanguageIdentificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.LanguageIdentificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfanityFilterMode : System.IEquatable<Azure.AI.Speech.Transcription.ProfanityFilterMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfanityFilterMode(string value) { throw null; }
        public static Azure.AI.Speech.Transcription.ProfanityFilterMode Masked { get { throw null; } }
        public static Azure.AI.Speech.Transcription.ProfanityFilterMode None { get { throw null; } }
        public static Azure.AI.Speech.Transcription.ProfanityFilterMode Removed { get { throw null; } }
        public static Azure.AI.Speech.Transcription.ProfanityFilterMode Tags { get { throw null; } }
        public bool Equals(Azure.AI.Speech.Transcription.ProfanityFilterMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.Transcription.ProfanityFilterMode left, Azure.AI.Speech.Transcription.ProfanityFilterMode right) { throw null; }
        public static implicit operator Azure.AI.Speech.Transcription.ProfanityFilterMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.Transcription.ProfanityFilterMode left, Azure.AI.Speech.Transcription.ProfanityFilterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PunctuationMode : System.IEquatable<Azure.AI.Speech.Transcription.PunctuationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PunctuationMode(string value) { throw null; }
        public static Azure.AI.Speech.Transcription.PunctuationMode Automatic { get { throw null; } }
        public static Azure.AI.Speech.Transcription.PunctuationMode Dictated { get { throw null; } }
        public static Azure.AI.Speech.Transcription.PunctuationMode DictatedAndAutomatic { get { throw null; } }
        public static Azure.AI.Speech.Transcription.PunctuationMode None { get { throw null; } }
        public bool Equals(Azure.AI.Speech.Transcription.PunctuationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.Transcription.PunctuationMode left, Azure.AI.Speech.Transcription.PunctuationMode right) { throw null; }
        public static implicit operator Azure.AI.Speech.Transcription.PunctuationMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.Transcription.PunctuationMode left, Azure.AI.Speech.Transcription.PunctuationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpeechToTextClient
    {
        protected SpeechToTextClient() { }
        public SpeechToTextClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public SpeechToTextClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Speech.Transcription.SpeechToTextClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Speech.Transcription.BatchTranscription GetBatchTranscriptionClient(string apiVersion = "2024-11-15") { throw null; }
        public virtual Azure.AI.Speech.Transcription.FastTranscription GetFastTranscriptionClient(string apiVersion = "2024-11-15") { throw null; }
    }
    public partial class SpeechToTextClientOptions : Azure.Core.ClientOptions
    {
        public SpeechToTextClientOptions(Azure.AI.Speech.Transcription.SpeechToTextClientOptions.ServiceVersion version = Azure.AI.Speech.Transcription.SpeechToTextClientOptions.ServiceVersion.V2024_11_15) { }
        public enum ServiceVersion
        {
            V2024_11_15 = 1,
        }
    }
    public partial class TranscribeConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeConfig>
    {
        public TranscribeConfig() { }
        public System.Collections.Generic.IList<int> ActiveChannels { get { throw null; } }
        public Azure.AI.Speech.Transcription.TranscribeDiarizationProperties DiarizationProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Locales { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Uri> Models { get { throw null; } }
        public Azure.AI.Speech.Transcription.ProfanityFilterMode? ProfanityFilterMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribeConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribeConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscribeDiarizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeDiarizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeDiarizationProperties>
    {
        public TranscribeDiarizationProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxSpeakers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribeDiarizationProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeDiarizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeDiarizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribeDiarizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeDiarizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeDiarizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeDiarizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscribedPhrase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedPhrase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedPhrase>
    {
        internal TranscribedPhrase() { }
        public int? Channel { get { throw null; } }
        public float Confidence { get { throw null; } }
        public int DurationMilliseconds { get { throw null; } }
        public string Locale { get { throw null; } }
        public int OffsetMilliseconds { get { throw null; } }
        public int? Speaker { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Speech.Transcription.TranscribedWord> Words { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribedPhrase System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedPhrase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedPhrase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribedPhrase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedPhrase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedPhrase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedPhrase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscribedWord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>
    {
        internal TranscribedWord() { }
        public int DurationMilliseconds { get { throw null; } }
        public int OffsetMilliseconds { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribedWord System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribedWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscribeResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeResult>
    {
        internal TranscribeResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Speech.Transcription.ChannelCombinedPhrases> CombinedPhrases { get { throw null; } }
        public int DurationMilliseconds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Speech.Transcription.TranscribedPhrase> Phrases { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribeResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribeResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionFile>
    {
        internal TranscriptionFile() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.AI.Speech.Transcription.FileKind Kind { get { throw null; } }
        public Azure.AI.Speech.Transcription.FileLinks Links { get { throw null; } }
        public Azure.AI.Speech.Transcription.FileProperties Properties { get { throw null; } }
        public System.Uri Self { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionJob>
    {
        public TranscriptionJob(Azure.AI.Speech.Transcription.TranscriptionProperties properties, string locale, string displayName) { }
        public System.Uri ContentContainerUrl { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> Contents { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public Azure.AI.Speech.Transcription.EntityReference Dataset { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActionDateTime { get { throw null; } }
        public Azure.AI.Speech.Transcription.TranscriptionLinks Links { get { throw null; } set { } }
        public string Locale { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.EntityReference Model { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.TranscriptionProperties Properties { get { throw null; } set { } }
        public System.Uri Self { get { throw null; } }
        public Azure.AI.Speech.Transcription.JobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionLinks : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionLinks>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionLinks>
    {
        public TranscriptionLinks() { }
        public System.Uri Files { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionLinks System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionLinks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionLinks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionLinks System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionLinks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionLinks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionLinks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionProperties>
    {
        public TranscriptionProperties(int timeToLiveHours) { }
        public System.Collections.Generic.IList<int> Channels { get { throw null; } }
        public System.Uri DestinationContainer { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.DiarizationProperties Diarization { get { throw null; } set { } }
        public bool? DisplayFormWordLevelTimestampsEnabled { get { throw null; } set { } }
        public int? DurationMilliseconds { get { throw null; } }
        public Azure.AI.Speech.Transcription.EntityError Error { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.LanguageIdentificationProperties LanguageIdentificationProperties { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.ProfanityFilterMode? ProfanityFilterMode { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.PunctuationMode? PunctuationMode { get { throw null; } set { } }
        public int TimeToLiveHours { get { throw null; } set { } }
        public bool? WordLevelTimestampsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AISpeechTranscriptionClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Speech.Transcription.SpeechToTextClient, Azure.AI.Speech.Transcription.SpeechToTextClientOptions> AddSpeechToTextClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Speech.Transcription.SpeechToTextClient, Azure.AI.Speech.Transcription.SpeechToTextClientOptions> AddSpeechToTextClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
