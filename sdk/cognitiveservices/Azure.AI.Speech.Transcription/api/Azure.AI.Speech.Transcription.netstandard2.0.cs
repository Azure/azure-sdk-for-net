namespace Azure.AI.Speech.Transcription
{
    public static partial class AISpeechTranscriptionModelFactory
    {
        public static Azure.AI.Speech.Transcription.EnhancedModeProperties EnhancedModeProperties(bool? enabled = default(bool?), string task = null, string targetLanguage = null, System.Collections.Generic.IEnumerable<string> prompt = null) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions TranscriptionDiarizationOptions(bool? enabled = default(bool?), int? maxSpeakers = default(int?)) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionOptions TranscriptionOptions(System.Uri audioUri = null, System.Collections.Generic.IEnumerable<string> locales = null, System.Collections.Generic.IDictionary<string, System.Uri> models = null, Azure.AI.Speech.Transcription.ProfanityFilterMode? profanityFilterMode = default(Azure.AI.Speech.Transcription.ProfanityFilterMode?), Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions diarizationOptions = null, System.Collections.Generic.IEnumerable<int> activeChannels = null, Azure.AI.Speech.Transcription.EnhancedModeProperties enhancedMode = null, Azure.AI.Speech.Transcription.PhraseListProperties phraseList = null) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionResult TranscriptionResult(int durationMilliseconds = 0) { throw null; }
    }
    public partial class AzureAISpeechTranscriptionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAISpeechTranscriptionContext() { }
        public static Azure.AI.Speech.Transcription.AzureAISpeechTranscriptionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EnhancedModeProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>
    {
        public EnhancedModeProperties() { }
        public bool? Enabled { get { throw null; } }
        public System.Collections.Generic.IList<string> Prompt { get { throw null; } }
        public string TargetLanguage { get { throw null; } set { } }
        public string Task { get { throw null; } set { } }
        Azure.AI.Speech.Transcription.EnhancedModeProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.EnhancedModeProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhraseListProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.PhraseListProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.PhraseListProperties>
    {
        public PhraseListProperties() { }
        public float? BiasingWeight { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Phrases { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.PhraseListProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.PhraseListProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.PhraseListProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.PhraseListProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.PhraseListProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.PhraseListProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.PhraseListProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TranscribedPhrase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedPhrase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedPhrase>
    {
        internal TranscribedPhrase() { }
        public float Confidence { get { throw null; } }
        public System.TimeSpan Duration { get { throw null; } }
        public string Locale { get { throw null; } }
        public System.TimeSpan Offset { get { throw null; } }
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
    public partial class TranscribedPhrases
    {
        public int? Channel;
        public System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedPhrase> Phrases;
        public TranscribedPhrases(int? Channel, string Text, System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedPhrase> Phrases) { }
        public string Text { get { throw null; } }
    }
    public partial class TranscribedWord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>
    {
        internal TranscribedWord() { }
        public System.TimeSpan Duration { get { throw null; } }
        public System.TimeSpan Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribedWord System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribedWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionClient
    {
        protected TranscriptionClient() { }
        public TranscriptionClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TranscriptionClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Speech.Transcription.TranscriptionClientOptions options) { }
        public TranscriptionClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TranscriptionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Speech.Transcription.TranscriptionClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Speech.Transcription.TranscriptionResult>> TranscribeAsync(Azure.AI.Speech.Transcription.TranscriptionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TranscriptionClientOptions : Azure.Core.ClientOptions
    {
        public TranscriptionClientOptions(Azure.AI.Speech.Transcription.TranscriptionClientOptions.ServiceVersion version = Azure.AI.Speech.Transcription.TranscriptionClientOptions.ServiceVersion.V2025_10_15) { }
        public enum ServiceVersion
        {
            V2025_10_15 = 1,
        }
    }
    public partial class TranscriptionDiarizationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>
    {
        public TranscriptionDiarizationOptions() { }
        public bool? Enabled { get { throw null; } }
        public int? MaxSpeakers { get { throw null; } set { } }
        Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionOptions>
    {
        public TranscriptionOptions() { }
        public TranscriptionOptions(System.IO.Stream audioStream) { }
        public TranscriptionOptions(System.Uri audioUri) { }
        public System.Collections.Generic.IList<int> ActiveChannels { get { throw null; } }
        public System.Uri AudioUri { get { throw null; } }
        public Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions DiarizationOptions { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.EnhancedModeProperties EnhancedMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Locales { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Uri> Models { get { throw null; } }
        public Azure.AI.Speech.Transcription.PhraseListProperties PhraseList { get { throw null; } set { } }
        public Azure.AI.Speech.Transcription.ProfanityFilterMode? ProfanityFilterMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>
    {
        internal TranscriptionResult() { }
        public System.TimeSpan Duration { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedPhrases> PhrasesByChannel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AISpeechTranscriptionClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Speech.Transcription.TranscriptionClient, Azure.AI.Speech.Transcription.TranscriptionClientOptions> AddTranscriptionClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Speech.Transcription.TranscriptionClient, Azure.AI.Speech.Transcription.TranscriptionClientOptions> AddTranscriptionClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Speech.Transcription.TranscriptionClient, Azure.AI.Speech.Transcription.TranscriptionClientOptions> AddTranscriptionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
