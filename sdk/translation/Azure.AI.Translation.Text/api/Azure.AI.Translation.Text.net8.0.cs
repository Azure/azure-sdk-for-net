namespace Azure.AI.Translation.Text
{
    public static partial class AITranslationTextModelFactory
    {
        public static Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage(string language = null, float score = 0f) { throw null; }
        public static Azure.AI.Translation.Text.GetSupportedLanguagesResult GetSupportedLanguagesResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TranslationLanguage> translation = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TransliterationLanguage> transliteration = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.SourceDictionaryLanguage> dictionary = null) { throw null; }
        public static Azure.AI.Translation.Text.LanguageScript LanguageScript(string code = null, string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight) { throw null; }
        public static Azure.AI.Translation.Text.SourceDictionaryLanguage SourceDictionaryLanguage(string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TargetDictionaryLanguage> translations = null) { throw null; }
        public static Azure.AI.Translation.Text.TargetDictionaryLanguage TargetDictionaryLanguage(string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight, string code = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslatedTextItem TranslatedTextItem(Azure.AI.Translation.Text.DetectedLanguage detectedLanguage = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslationText> translations = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslateInputItem TranslateInputItem(string text = null, string script = null, string language = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateTarget> targets = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslateTarget TranslateTarget(string language = null, string script = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), string deploymentName = null, bool? allowFallback = default(bool?), string grade = null, string tone = null, string gender = null, string adaptiveDatasetId = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.ReferenceSentencePair> referenceTextPairs = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslationLanguage TranslationLanguage(string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight) { throw null; }
        public static Azure.AI.Translation.Text.TranslationResult TranslationResult(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslatedTextItem> value = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslationText TranslationText(string language = null, int? sourceCharacters = default(int?), int? instructionTokens = default(int?), int? sourceTokens = default(int?), int? responseTokens = default(int?), int? targetTokens = default(int?), string text = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterableScript TransliterableScript(string code = null, string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.LanguageScript> toScripts = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliteratedText TransliteratedText(string text = null, string script = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterateResult TransliterateResult(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TransliteratedText> value = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterationLanguage TransliterationLanguage(string name = null, string nativeName = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TransliterableScript> scripts = null) { throw null; }
    }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.DetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.DetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.DetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.DetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.DetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.DetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.DetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetSupportedLanguagesResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>
    {
        internal GetSupportedLanguagesResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.SourceDictionaryLanguage> Dictionary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TranslationLanguage> Translation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TransliterationLanguage> Transliteration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.GetSupportedLanguagesResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.GetSupportedLanguagesResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.GetSupportedLanguagesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputTextItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.InputTextItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.InputTextItem>
    {
        public InputTextItem(string text) { }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.InputTextItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.InputTextItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.InputTextItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.InputTextItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.InputTextItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.InputTextItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.InputTextItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputTextWithTranslation
    {
        public InputTextWithTranslation(string word, string translation) { }
        public string Text { get { throw null; } }
        public string Translation { get { throw null; } }
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
        public Azure.AI.Translation.Text.LanguageDirectionality Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ReferenceSentencePair : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.ReferenceSentencePair>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceSentencePair>
    {
        public ReferenceSentencePair(string source, string target) { }
        public string Source { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.ReferenceSentencePair System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.ReferenceSentencePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.ReferenceSentencePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.ReferenceSentencePair System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceSentencePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceSentencePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.ReferenceSentencePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceDictionaryLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.SourceDictionaryLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceDictionaryLanguage>
    {
        internal SourceDictionaryLanguage() { }
        public Azure.AI.Translation.Text.LanguageDirectionality Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TargetDictionaryLanguage> Translations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.SourceDictionaryLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.SourceDictionaryLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.SourceDictionaryLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.SourceDictionaryLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceDictionaryLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceDictionaryLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceDictionaryLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetDictionaryLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TargetDictionaryLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TargetDictionaryLanguage>
    {
        internal TargetDictionaryLanguage() { }
        public string Code { get { throw null; } }
        public Azure.AI.Translation.Text.LanguageDirectionality Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TargetDictionaryLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TargetDictionaryLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TargetDictionaryLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TargetDictionaryLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TargetDictionaryLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TargetDictionaryLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TargetDictionaryLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.AI.Translation.Text.TranslationResult> Translate(Azure.AI.Translation.Text.TranslateBody body, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Translate(Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TranslationResult> Translate(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateInputItem> inputs, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TranslationResult> Translate(string targetLanguage, System.Collections.Generic.IEnumerable<string> content, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TranslationResult> Translate(string targetLanguage, string text, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TranslationResult>> TranslateAsync(Azure.AI.Translation.Text.TranslateBody body, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> TranslateAsync(Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TranslationResult>> TranslateAsync(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateInputItem> inputs, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TranslationResult>> TranslateAsync(string targetLanguage, System.Collections.Generic.IEnumerable<string> content, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TranslationResult>> TranslateAsync(string targetLanguage, string text, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TransliterateResult> Transliterate(string language, string fromScript, string toScript, Azure.AI.Translation.Text.TransliterateBody body, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Transliterate(string language, string fromScript, string toScript, Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TransliterateResult> Transliterate(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.TransliterateResult> Transliterate(string language, string fromScript, string toScript, string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TransliterateResult>> TransliterateAsync(string language, string fromScript, string toScript, Azure.AI.Translation.Text.TransliterateBody body, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> TransliterateAsync(string language, string fromScript, string toScript, Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TransliterateResult>> TransliterateAsync(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.TransliterateResult>> TransliterateAsync(string language, string fromScript, string toScript, string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextTranslationClientOptions : Azure.Core.ClientOptions
    {
        public TextTranslationClientOptions(Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion version = Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion.V2025_10_01_Preview) { }
        public enum ServiceVersion
        {
            V3_0 = 1,
            V2025_10_01_Preview = 2,
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
        public static bool operator !=(Azure.AI.Translation.Text.TextType left, Azure.AI.Translation.Text.TextType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslateBody : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateBody>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateBody>
    {
        public TranslateBody(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateInputItem> inputs) { }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.TranslateInputItem> Inputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslateBody System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslateBody System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslatedTextItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>
    {
        internal TranslatedTextItem() { }
        public Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslationText> Translations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslatedTextItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslatedTextItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslateInputItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateInputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>
    {
        public TranslateInputItem(string text, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateTarget> targets) { }
        public string Language { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.TranslateTarget> Targets { get { throw null; } }
        public string Text { get { throw null; } }
        public Azure.AI.Translation.Text.TextType? TextType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslateInputItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateInputItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateInputItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslateInputItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateInputItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslateTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateTarget>
    {
        public TranslateTarget(string language) { }
        public string AdaptiveDatasetId { get { throw null; } set { } }
        public bool? AllowFallback { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public string Gender { get { throw null; } set { } }
        public string Grade { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public Azure.AI.Translation.Text.ProfanityAction? ProfanityAction { get { throw null; } set { } }
        public Azure.AI.Translation.Text.ProfanityMarker? ProfanityMarker { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.ReferenceSentencePair> ReferenceTextPairs { get { throw null; } }
        public string Script { get { throw null; } set { } }
        public string Tone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslateTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslateTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>
    {
        internal TranslationLanguage() { }
        public Azure.AI.Translation.Text.LanguageDirectionality Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationResult>
    {
        internal TranslationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationText System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslationText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransliterableScript : Azure.AI.Translation.Text.LanguageScript, System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterableScript>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>
    {
        internal TransliterableScript() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.LanguageScript> ToScripts { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterableScript System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterableScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterableScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterableScript System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterableScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransliterateBody : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterateBody>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateBody>
    {
        public TransliterateBody(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.InputTextItem> inputs) { }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.InputTextItem> Inputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterateBody System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterateBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterateBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterateBody System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransliteratedText : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliteratedText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>
    {
        internal TransliteratedText() { }
        public string Script { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliteratedText System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliteratedText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliteratedText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliteratedText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliteratedText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransliterateResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateResult>
    {
        internal TransliterateResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterateResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TransliterateResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransliterationLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TransliterationLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TransliterationLanguage>
    {
        internal TransliterationLanguage() { }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliterableScript> Scripts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
