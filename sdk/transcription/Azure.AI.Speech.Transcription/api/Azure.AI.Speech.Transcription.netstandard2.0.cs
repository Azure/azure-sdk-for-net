namespace Azure.AI.Speech.Transcription
{
    public partial class AzureAISpeechTranscriptionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAISpeechTranscriptionContext() { }
        public static Azure.AI.Speech.Transcription.AzureAISpeechTranscriptionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ChannelCombinedPhrases : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>
    {
        internal ChannelCombinedPhrases() { }
        public int? Channel { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Speech.Transcription.ChannelCombinedPhrases JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Speech.Transcription.ChannelCombinedPhrases PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Speech.Transcription.ChannelCombinedPhrases System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.ChannelCombinedPhrases System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.ChannelCombinedPhrases>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnhancedModeProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.EnhancedModeProperties>
    {
        public EnhancedModeProperties() { }
        public System.Collections.Generic.IList<string> Prompt { get { throw null; } }
        public string TargetLanguage { get { throw null; } set { } }
        public string Task { get { throw null; } set { } }
        protected virtual Azure.AI.Speech.Transcription.EnhancedModeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual Azure.AI.Speech.Transcription.EnhancedModeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.AI.Speech.Transcription.PhraseListProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Speech.Transcription.PhraseListProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Speech.Transcription.ProfanityFilterMode left, Azure.AI.Speech.Transcription.ProfanityFilterMode right) { throw null; }
        public static implicit operator Azure.AI.Speech.Transcription.ProfanityFilterMode (string value) { throw null; }
        public static implicit operator Azure.AI.Speech.Transcription.ProfanityFilterMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Speech.Transcription.ProfanityFilterMode left, Azure.AI.Speech.Transcription.ProfanityFilterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class SpeechTranscriptionModelFactory
    {
        public static Azure.AI.Speech.Transcription.ChannelCombinedPhrases ChannelCombinedPhrases(int? channel = default(int?), string text = null) { throw null; }
        public static Azure.AI.Speech.Transcription.EnhancedModeProperties EnhancedModeProperties(bool? enabled = default(bool?), string task = null, string targetLanguage = null, System.Collections.Generic.IEnumerable<string> prompt = null) { throw null; }
        public static Azure.Core.Foundations.Error Error(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Core.Foundations.Error> details = null, Azure.Core.Foundations.InnerError innererror = null) { throw null; }
        public static Azure.Core.Foundations.ErrorResponse ErrorResponse(Azure.Core.Foundations.Error error = null, string errorCode = null) { throw null; }
        public static Azure.Core.Foundations.InnerError InnerError(string code = null, Azure.Core.Foundations.InnerError innererror = null) { throw null; }
        public static Azure.AI.Speech.Transcription.PhraseListProperties PhraseListProperties(System.Collections.Generic.IEnumerable<string> phrases = null, float? biasingWeight = default(float?)) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscribedPhrase TranscribedPhrase(int? channel = default(int?), int? speaker = default(int?), int offsetMilliseconds = 0, int durationMilliseconds = 0, string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedWord> words = null, string locale = null, float confidence = 0f) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscribedWord TranscribedWord(string text = null, int offsetMilliseconds = 0, int durationMilliseconds = 0) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions TranscriptionDiarizationOptions(bool? enabled = default(bool?), int? maxSpeakers = default(int?)) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionOptions TranscriptionOptions(System.Uri audioUri = null, System.Collections.Generic.IEnumerable<string> locales = null, System.Collections.Generic.IDictionary<string, System.Uri> models = null, Azure.AI.Speech.Transcription.ProfanityFilterMode? profanityFilterMode = default(Azure.AI.Speech.Transcription.ProfanityFilterMode?), Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions diarizationOptions = null, System.Collections.Generic.IEnumerable<int> activeChannels = null, Azure.AI.Speech.Transcription.EnhancedModeProperties enhancedMode = null, Azure.AI.Speech.Transcription.PhraseListProperties phraseList = null) { throw null; }
        public static Azure.AI.Speech.Transcription.TranscriptionResult TranscriptionResult(int durationMilliseconds = 0, System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.ChannelCombinedPhrases> combinedPhrases = null, System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedPhrase> phrases = null) { throw null; }
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
        public System.Collections.Generic.IList<Azure.AI.Speech.Transcription.TranscribedWord> Words { get { throw null; } }
        protected virtual Azure.AI.Speech.Transcription.TranscribedPhrase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Speech.Transcription.TranscribedPhrase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.AI.Speech.Transcription.TranscribedWord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Speech.Transcription.TranscribedWord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Speech.Transcription.TranscribedWord System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscribedWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscribedWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscribedWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionClient
    {
        protected TranscriptionClient() { }
        public TranscriptionClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential) { }
        public TranscriptionClient(System.Uri endpoint, System.ClientModel.ApiKeyCredential credential, Azure.AI.Speech.Transcription.TranscriptionClientOptions options) { }
        public TranscriptionClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) { }
        public TranscriptionClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Speech.Transcription.TranscriptionClientOptions options) { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Speech.Transcription.TranscriptionResult> Transcribe(Azure.AI.Speech.Transcription.TranscriptionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Speech.Transcription.TranscriptionResult>> TranscribeAsync(Azure.AI.Speech.Transcription.TranscriptionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TranscriptionClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public TranscriptionClientOptions(Azure.AI.Speech.Transcription.TranscriptionClientOptions.ServiceVersion version = Azure.AI.Speech.Transcription.TranscriptionClientOptions.ServiceVersion.V20251015) { }
        public enum ServiceVersion
        {
            V20251015 = 1,
        }
    }
    public partial class TranscriptionDiarizationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions>
    {
        public TranscriptionDiarizationOptions() { }
        public bool? Enabled { get { throw null; } }
        public int? MaxSpeakers { get { throw null; } set { } }
        protected virtual Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual Azure.AI.Speech.Transcription.TranscriptionDiarizationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.AI.Speech.Transcription.TranscriptionOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Speech.Transcription.TranscriptionOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Speech.Transcription.TranscriptionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>
    {
        internal TranscriptionResult() { }
        public System.Collections.Generic.IList<Azure.AI.Speech.Transcription.ChannelCombinedPhrases> CombinedPhrases { get { throw null; } }
        public System.TimeSpan Duration { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.Speech.Transcription.TranscribedPhrases> PhrasesByChannel { get { throw null; } }
        protected virtual Azure.AI.Speech.Transcription.TranscriptionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Speech.Transcription.TranscriptionResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Speech.Transcription.TranscriptionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Speech.Transcription.TranscriptionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Speech.Transcription.TranscriptionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Speech.Transcription.TranscriptionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.Core.Foundations
{
    public partial class Error : System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.Error>, System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.Error>
    {
        internal Error() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.Foundations.Error> Details { get { throw null; } }
        public Azure.Core.Foundations.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.Core.Foundations.Error JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Core.Foundations.Error PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Core.Foundations.Error System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.Error>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.Error>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Core.Foundations.Error System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.Error>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.Error>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.Error>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorResponse : System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.ErrorResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.ErrorResponse>
    {
        internal ErrorResponse() { }
        public Azure.Core.Foundations.Error Error { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        protected virtual Azure.Core.Foundations.ErrorResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Core.Foundations.ErrorResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Core.Foundations.ErrorResponse System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.ErrorResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.ErrorResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Core.Foundations.ErrorResponse System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.ErrorResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.ErrorResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.ErrorResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.InnerError>
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public Azure.Core.Foundations.InnerError Innererror { get { throw null; } }
        protected virtual Azure.Core.Foundations.InnerError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Core.Foundations.InnerError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Core.Foundations.InnerError System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Core.Foundations.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Core.Foundations.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Core.Foundations.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
