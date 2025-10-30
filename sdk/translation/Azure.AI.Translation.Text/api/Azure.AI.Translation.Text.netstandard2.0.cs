namespace Azure.AI.Translation.Text
{
    public partial class AzureAITranslationTextContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAITranslationTextContext() { }
        public static Azure.AI.Translation.Text.AzureAITranslationTextContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.DetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.DetectedLanguage>
    {
        internal DetectedLanguage() { }
        public string Language { get { throw null; } }
        public float Score { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.DetectedLanguage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.DetectedLanguage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.DetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.DetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.DetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.DetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.DetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.DetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.DetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSupportedLanguagesResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>
    {
        internal GetSupportedLanguagesResult() { }
        public string Etag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Models { get { throw null; } }
        public string RequestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Translation.Text.TranslationLanguage> Translation { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Translation.Text.TransliterationLanguage> Transliteration { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.GetSupportedLanguagesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Translation.Text.GetSupportedLanguagesResult (Azure.Response result) { throw null; }
        protected virtual Azure.AI.Translation.Text.GetSupportedLanguagesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.GetSupportedLanguagesResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.GetSupportedLanguagesResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LanguageDirectionality
    {
        LeftToRight = 0,
        RightToLeft = 1,
    }
    public partial class LanguageScript : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.LanguageScript>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.LanguageScript>
    {
        internal LanguageScript() { }
        public string Code { get { throw null; } }
        public Azure.AI.Translation.Text.LanguageDirectionality Directionality { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.LanguageScript JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.LanguageScript PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.LanguageScript System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.LanguageScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.LanguageScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.LanguageScript System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.LanguageScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.LanguageScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.LanguageScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ProfanityAction
    {
        NoAction = 0,
        Marked = 1,
        Deleted = 2,
    }
    public enum ProfanityMarker
    {
        Asterisk = 0,
        Tag = 1,
    }
    public partial class ReferenceTextPair : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.ReferenceTextPair>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceTextPair>
    {
        public ReferenceTextPair(string source, string target) { }
        public string Source { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.ReferenceTextPair JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.ReferenceTextPair PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.ReferenceTextPair System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.ReferenceTextPair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.ReferenceTextPair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.ReferenceTextPair System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceTextPair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceTextPair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceTextPair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextTranslationClient
    {
        protected TextTranslationClient() { }
        public TextTranslationClient(Azure.AzureKeyCredential credential, string region = "global", Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.AzureKeyCredential credential, System.Uri endpoint, string region = "global", Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.Core.TokenCredential credential, Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.Core.TokenCredential credential, string resourceId, string region = "global", string tokenScope = "https://cognitiveservices.azure.com/.default", Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.Core.TokenCredential credential, System.Uri endpoint, string tokenScope = "https://cognitiveservices.azure.com/.default", Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.Core.TokenCredential credential, System.Uri endpoint, string resourceId, string region = "global", string tokenScope = "https://cognitiveservices.azure.com/.default", Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(System.Uri endpoint) { }
        public TextTranslationClient(System.Uri endpoint, Azure.AI.Translation.Text.TextTranslationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetSupportedLanguages(string clientTraceId, string scope, string acceptLanguage, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.GetSupportedLanguagesResult> GetSupportedLanguages(string clientTraceId = null, string scope = null, string acceptLanguage = null, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSupportedLanguagesAsync(string clientTraceId, string scope, string acceptLanguage, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.GetSupportedLanguagesResult>> GetSupportedLanguagesAsync(string clientTraceId = null, string scope = null, string acceptLanguage = null, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TranslatedTextItem> Translate(Azure.AI.Translation.Text.TranslateInputItem input, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Translate(Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateInputItem> inputs, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(System.Collections.Generic.IEnumerable<string> content, string targetLanguage, string sourceLanguage = null, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TranslatedTextItem> Translate(string text, string targetLanguage, string sourceLanguage = null, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TranslatedTextItem>> TranslateAsync(Azure.AI.Translation.Text.TranslateInputItem input, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> TranslateAsync(Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateInputItem> inputs, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(System.Collections.Generic.IEnumerable<string> content, string targetLanguage, string sourceLanguage = null, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TranslatedTextItem>> TranslateAsync(string text, string targetLanguage, string sourceLanguage = null, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>> Transliterate(System.Collections.Generic.IEnumerable<string> content, string language, string fromScript, string toScript, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Transliterate(string language, string fromScript, string toScript, Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TransliteratedText> Transliterate(string text, string language, string fromScript, string toScript, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>>> TransliterateAsync(System.Collections.Generic.IEnumerable<string> content, string language, string fromScript, string toScript, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> TransliterateAsync(string language, string fromScript, string toScript, Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TransliteratedText>> TransliterateAsync(string text, string language, string fromScript, string toScript, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextTranslationClientOptions : Azure.Core.ClientOptions
    {
        public TextTranslationClientOptions(Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion version = Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion.V2025_10_01_Preview) { }
        public enum ServiceVersion
        {
            V2025_10_01_Preview = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextType : System.IEquatable<Azure.AI.Translation.Text.TextType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextType(string value) { throw null; }
        public static Azure.AI.Translation.Text.TextType Html { get { throw null; } }
        public static Azure.AI.Translation.Text.TextType Plain { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Text.TextType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Text.TextType left, Azure.AI.Translation.Text.TextType right) { throw null; }
        public static implicit operator Azure.AI.Translation.Text.TextType (string value) { throw null; }
        public static implicit operator Azure.AI.Translation.Text.TextType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Text.TextType left, Azure.AI.Translation.Text.TextType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslatedTextItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>
    {
        internal TranslatedTextItem() { }
        public Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.TranslationText> Translations { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.TranslatedTextItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.TranslatedTextItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TranslatedTextItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslatedTextItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslateInputItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateInputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>
    {
        public TranslateInputItem(string text, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslationTarget> translationTargets) { }
        public TranslateInputItem(string text, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslationTarget> targets, string language = null, string script = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?)) { }
        public string Language { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public string Text { get { throw null; } }
        public Azure.AI.Translation.Text.TextType? TextType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.TranslationTarget> TranslationTargets { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.TranslateInputItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.TranslateInputItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TranslateInputItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateInputItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateInputItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslateInputItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>
    {
        internal TranslationLanguage() { }
        public Azure.AI.Translation.Text.LanguageDirectionality Directionality { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.TranslationLanguage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.TranslationLanguage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TranslationLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationTarget>
    {
        public TranslationTarget(string language) { }
        public TranslationTarget(string language, string script = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), string deploymentName = null, bool? allowFallback = default(bool?), string grade = null, string tone = null, string gender = null, string adaptiveDatasetId = null) { }
        public string AdaptiveDatasetId { get { throw null; } set { } }
        public bool? AllowFallback { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public string Gender { get { throw null; } set { } }
        public string Grade { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public Azure.AI.Translation.Text.ProfanityAction? ProfanityAction { get { throw null; } set { } }
        public Azure.AI.Translation.Text.ProfanityMarker? ProfanityMarker { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.ReferenceTextPair> ReferenceTextPairs { get { throw null; } }
        public string Script { get { throw null; } set { } }
        public string Tone { get { throw null; } set { } }
        protected virtual Azure.AI.Translation.Text.TranslationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.TranslationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TranslationTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationText : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>
    {
        internal TranslationText() { }
        public int? InstructionTokens { get { throw null; } }
        public string Language { get { throw null; } }
        public int? ResponseTokens { get { throw null; } }
        public int? SourceCharacters { get { throw null; } }
        public int? SourceTokens { get { throw null; } }
        public int? TargetTokens { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.TranslationText JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.TranslationText PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TranslationText System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class TranslationTextModelFactory
    {
        public static Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage(string language = null, float score = 0f) { throw null; }
        public static Azure.AI.Translation.Text.GetSupportedLanguagesResult GetSupportedLanguagesResult(string requestId = null, string etag = null, System.Collections.Generic.IDictionary<string, Azure.AI.Translation.Text.TranslationLanguage> translation = null, System.Collections.Generic.IDictionary<string, Azure.AI.Translation.Text.TransliterationLanguage> transliteration = null, System.Collections.Generic.IDictionary<string, string> models = null) { throw null; }
        public static Azure.AI.Translation.Text.LanguageScript LanguageScript(string code = null, string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality directionality = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight) { throw null; }
        public static Azure.AI.Translation.Text.ReferenceTextPair ReferenceTextPair(string source = null, string target = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslatedTextItem TranslatedTextItem(Azure.AI.Translation.Text.DetectedLanguage detectedLanguage = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslationText> translations = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslateInputItem TranslateInputItem(string text = null, string script = null, string language = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslationTarget> translationTargets = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslationLanguage TranslationLanguage(string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality directionality = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight) { throw null; }
        public static Azure.AI.Translation.Text.TranslationTarget TranslationTarget(string language = null, string script = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), string deploymentName = null, bool? allowFallback = default(bool?), string grade = null, string tone = null, string gender = null, string adaptiveDatasetId = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.ReferenceTextPair> referenceTextPairs = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslationText TranslationText(string language = null, int? sourceCharacters = default(int?), int? instructionTokens = default(int?), int? sourceTokens = default(int?), int? responseTokens = default(int?), int? targetTokens = default(int?), string text = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterableScript TransliterableScript(string code = null, string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality directionality = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.LanguageScript> toScripts = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliteratedText TransliteratedText(string text = null, string script = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterationLanguage TransliterationLanguage(string name = null, string nativeName = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TransliterableScript> scripts = null) { throw null; }
    }
    public partial class TransliterableScript : Azure.AI.Translation.Text.LanguageScript, System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterableScript>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>
    {
        internal TransliterableScript() { }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.LanguageScript> ToScripts { get { throw null; } }
        protected override Azure.AI.Translation.Text.LanguageScript JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Translation.Text.LanguageScript PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TransliterableScript System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterableScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterableScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterableScript System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransliteratedText : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliteratedText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>
    {
        internal TransliteratedText() { }
        public string Script { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.TransliteratedText JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.TransliteratedText PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TransliteratedText System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliteratedText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliteratedText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliteratedText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransliterationLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterationLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterationLanguage>
    {
        internal TransliterationLanguage() { }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.TransliterableScript> Scripts { get { throw null; } }
        protected virtual Azure.AI.Translation.Text.TransliterationLanguage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Translation.Text.TransliterationLanguage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Translation.Text.TransliterationLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterationLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterationLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterationLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterationLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterationLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterationLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class TextTranslationClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.AzureKeyCredential credential, string region) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.AzureKeyCredential credential, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.AzureKeyCredential credential, System.Uri endpoint, string region) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.Core.TokenCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.Core.TokenCredential credential, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public static partial class TranslationTextClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.AzureKeyCredential credential, string region = "global") where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.AzureKeyCredential credential, System.Uri endpoint, string region = "global") where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.Core.TokenCredential credential, string resourceId, string region = "global", string tokenScope = "https://cognitiveservices.azure.com/.default") where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.Core.TokenCredential credential, System.Uri endpoint, string tokenScope = "https://cognitiveservices.azure.com/.default") where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, Azure.Core.TokenCredential credential, System.Uri endpoint, string resourceId, string region = "global", string tokenScope = "https://cognitiveservices.azure.com/.default") where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
