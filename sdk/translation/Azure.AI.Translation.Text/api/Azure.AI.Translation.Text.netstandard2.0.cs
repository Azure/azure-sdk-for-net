namespace Azure.AI.Translation.Text
{
    public static partial class AITranslationTextModelFactory
    {
        public static Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage(string language = null, float score = 0f) { throw null; }
        public static Azure.AI.Translation.Text.GetSupportedLanguagesResult GetSupportedLanguagesResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TranslationLanguage> translation = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TransliterationLanguage> transliteration = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.SourceDictionaryLanguage> dictionary = null) { throw null; }
        public static Azure.AI.Translation.Text.LanguageScript LanguageScript(string code = null, string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight) { throw null; }
        public static Azure.AI.Translation.Text.SourceDictionaryLanguage SourceDictionaryLanguage(string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TargetDictionaryLanguage> translations = null) { throw null; }
        public static Azure.AI.Translation.Text.SourceText SourceText(string text = null) { throw null; }
        public static Azure.AI.Translation.Text.TargetDictionaryLanguage TargetDictionaryLanguage(string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight, string code = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslateBody TranslateBody(string text = null, string script = null, string language = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateTarget> targets = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslatedTextItem TranslatedTextItem(Azure.AI.Translation.Text.DetectedLanguage detectedLanguage = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslationText> translations = null, Azure.AI.Translation.Text.SourceText sourceText = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslationLanguage TranslationLanguage(string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight) { throw null; }
        public static Azure.AI.Translation.Text.TranslationText TranslationText(string to = null, string text = null, Azure.AI.Translation.Text.TransliteratedText transliteration = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterableScript TransliterableScript(string code = null, string name = null, string nativeName = null, Azure.AI.Translation.Text.LanguageDirectionality dir = Azure.AI.Translation.Text.LanguageDirectionality.LeftToRight, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.LanguageScript> toScripts = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliteratedText TransliteratedText(string text = null, string script = null) { throw null; }
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
        public ReferenceSentencePair(string referenceTextPairsSource, string referenceTextPairsTarget) { }
        public string ReferenceTextPairsSource { get { throw null; } }
        public string ReferenceTextPairsTarget { get { throw null; } }
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
    public partial class SourceText : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.SourceText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceText>
    {
        internal SourceText() { }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.SourceText System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.SourceText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.SourceText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.SourceText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.SourceText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSupportedLanguagesAsync(string clientTraceId, string scope, string acceptLanguage, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.GetSupportedLanguagesResult>> GetSupportedLanguagesAsync(string clientTraceId = null, string scope = null, string acceptLanguage = null, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(Azure.AI.Translation.Text.TextTranslationTranslateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Translate(Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateBody> body, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid), string sourceLanguage = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), string category = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), bool? includeAlignment = default(bool?), bool? includeSentenceLength = default(bool?), string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(string targetLanguage, System.Collections.Generic.IEnumerable<string> content, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(string targetLanguage, string text, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(Azure.AI.Translation.Text.TextTranslationTranslateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TranslateAsync(Azure.Core.RequestContent content, string clientTraceId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateBody> body, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid), string sourceLanguage = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), string category = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), bool? includeAlignment = default(bool?), bool? includeSentenceLength = default(bool?), string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(string targetLanguage, System.Collections.Generic.IEnumerable<string> content, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(string targetLanguage, string text, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>> Transliterate(Azure.AI.Translation.Text.TextTranslationTransliterateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>> Transliterate(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>> Transliterate(string language, string fromScript, string toScript, string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>>> TransliterateAsync(Azure.AI.Translation.Text.TextTranslationTransliterateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextTranslationClientOptions : Azure.Core.ClientOptions
    {
        public TextTranslationClientOptions(Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion version = Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion.V2025_05_01_Preview) { }
        public enum ServiceVersion
        {
            V3_0 = 1,
            V2025_05_01_Preview = 2,
        }
    }
    public partial class TextTranslationTranslateOptions
    {
        public TextTranslationTranslateOptions(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content) { }
        public TextTranslationTranslateOptions(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid), string sourceLanguage = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), string category = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), bool? includeAlignment = default(bool?), bool? includeSentenceLength = default(bool?), string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = default(bool?)) { }
        public TextTranslationTranslateOptions(string targetLanguage, string content) { }
        public bool? AllowFallback { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public System.Guid ClientTraceId { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> Content { get { throw null; } }
        public string FromScript { get { throw null; } set { } }
        public bool? IncludeAlignment { get { throw null; } set { } }
        public bool? IncludeSentenceLength { get { throw null; } set { } }
        public Azure.AI.Translation.Text.ProfanityAction? ProfanityAction { get { throw null; } set { } }
        public Azure.AI.Translation.Text.ProfanityMarker? ProfanityMarker { get { throw null; } set { } }
        public string SourceLanguage { get { throw null; } set { } }
        public string SuggestedFrom { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> TargetLanguages { get { throw null; } }
        public Azure.AI.Translation.Text.TextType? TextType { get { throw null; } set { } }
        public string ToScript { get { throw null; } set { } }
    }
    public partial class TextTranslationTransliterateOptions
    {
        public TextTranslationTransliterateOptions(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, System.Guid clientTraceId = default(System.Guid)) { }
        public TextTranslationTransliterateOptions(string language, string fromScript, string toScript, string content, System.Guid clientTraceId = default(System.Guid)) { }
        public System.Guid ClientTraceId { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> Content { get { throw null; } }
        public string FromScript { get { throw null; } }
        public string Language { get { throw null; } }
        public string ToScript { get { throw null; } }
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
        public TranslateBody(string text, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TranslateTarget> targets) { }
        public string Language { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Translation.Text.TranslateTarget> Targets { get { throw null; } }
        public string Text { get { throw null; } }
        public Azure.AI.Translation.Text.TextType? TextType { get { throw null; } set { } }
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
        public Azure.AI.Translation.Text.SourceText SourceText { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslationText> Translations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslatedTextItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslatedTextItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Translation.Text.TranslatedTextItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslatedTextItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranslateTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslateTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslateTarget>
    {
        public TranslateTarget(System.Collections.Generic.IEnumerable<string> language) { }
        public string AdaptiveDatasetId { get { throw null; } set { } }
        public bool? AllowFallback { get { throw null; } set { } }
        public string DeploymentNameModel { get { throw null; } set { } }
        public string Gender { get { throw null; } set { } }
        public string Grade { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Language { get { throw null; } }
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
    public partial class TranslationText : System.ClientModel.Primitives.IJsonModel<Azure.AI.Translation.Text.TranslationText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Translation.Text.TranslationText>
    {
        internal TranslationText() { }
        public string Text { get { throw null; } }
        public string To { get { throw null; } }
        public Azure.AI.Translation.Text.TransliteratedText Transliteration { get { throw null; } }
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
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Translation.Text.TextTranslationClient, Azure.AI.Translation.Text.TextTranslationClientOptions> AddTextTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
