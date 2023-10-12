namespace Azure.AI.Translation.Text
{
    public static partial class AITranslationTextModelFactory
    {
        public static Azure.AI.Translation.Text.BackTranslation BackTranslation(string normalizedText = null, string displayText = null, int numExamples = 0, int frequencyCount = 0) { throw null; }
        public static Azure.AI.Translation.Text.BreakSentenceItem BreakSentenceItem(Azure.AI.Translation.Text.DetectedLanguage detectedLanguage = null, System.Collections.Generic.IEnumerable<int> sentLen = null) { throw null; }
        public static Azure.AI.Translation.Text.CommonScriptModel CommonScriptModel(string code = null, string name = null, string nativeName = null, string dir = null) { throw null; }
        public static Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage(string language = null, float score = 0f) { throw null; }
        public static Azure.AI.Translation.Text.DictionaryExample DictionaryExample(string sourcePrefix = null, string sourceTerm = null, string sourceSuffix = null, string targetPrefix = null, string targetTerm = null, string targetSuffix = null) { throw null; }
        public static Azure.AI.Translation.Text.DictionaryExampleItem DictionaryExampleItem(string normalizedSource = null, string normalizedTarget = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.DictionaryExample> examples = null) { throw null; }
        public static Azure.AI.Translation.Text.DictionaryLookupItem DictionaryLookupItem(string normalizedSource = null, string displaySource = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.DictionaryTranslation> translations = null) { throw null; }
        public static Azure.AI.Translation.Text.DictionaryTranslation DictionaryTranslation(string normalizedTarget = null, string displayTarget = null, string posTag = null, float confidence = 0f, string prefixWord = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.BackTranslation> backTranslations = null) { throw null; }
        public static Azure.AI.Translation.Text.GetLanguagesResult GetLanguagesResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TranslationLanguage> translation = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TransliterationLanguage> transliteration = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.SourceDictionaryLanguage> dictionary = null) { throw null; }
        public static Azure.AI.Translation.Text.SentenceLength SentenceLength(System.Collections.Generic.IEnumerable<int> srcSentLen = null, System.Collections.Generic.IEnumerable<int> transSentLen = null) { throw null; }
        public static Azure.AI.Translation.Text.SourceDictionaryLanguage SourceDictionaryLanguage(string name = null, string nativeName = null, string dir = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TargetDictionaryLanguage> translations = null) { throw null; }
        public static Azure.AI.Translation.Text.SourceText SourceText(string text = null) { throw null; }
        public static Azure.AI.Translation.Text.TargetDictionaryLanguage TargetDictionaryLanguage(string name = null, string nativeName = null, string dir = null, string code = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslatedTextAlignment TranslatedTextAlignment(string proj = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslatedTextItem TranslatedTextItem(Azure.AI.Translation.Text.DetectedLanguage detectedLanguage = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.Translation> translations = null, Azure.AI.Translation.Text.SourceText sourceText = null) { throw null; }
        public static Azure.AI.Translation.Text.Translation Translation(string to = null, string text = null, Azure.AI.Translation.Text.TransliteratedText transliteration = null, Azure.AI.Translation.Text.TranslatedTextAlignment alignment = null, Azure.AI.Translation.Text.SentenceLength sentLen = null) { throw null; }
        public static Azure.AI.Translation.Text.TranslationLanguage TranslationLanguage(string name = null, string nativeName = null, string dir = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterableScript TransliterableScript(string code = null, string name = null, string nativeName = null, string dir = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.CommonScriptModel> toScripts = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliteratedText TransliteratedText(string text = null, string script = null) { throw null; }
        public static Azure.AI.Translation.Text.TransliterationLanguage TransliterationLanguage(string name = null, string nativeName = null, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.TransliterableScript> scripts = null) { throw null; }
    }
    public partial class BackTranslation
    {
        internal BackTranslation() { }
        public string DisplayText { get { throw null; } }
        public int FrequencyCount { get { throw null; } }
        public string NormalizedText { get { throw null; } }
        public int NumExamples { get { throw null; } }
    }
    public partial class BreakSentenceItem
    {
        internal BreakSentenceItem() { }
        public Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> SentLen { get { throw null; } }
    }
    public partial class CommonScriptModel
    {
        internal CommonScriptModel() { }
        public string Code { get { throw null; } }
        public string Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
    }
    public partial class DetectedLanguage
    {
        internal DetectedLanguage() { }
        public string Language { get { throw null; } }
        public float Score { get { throw null; } }
    }
    public partial class DictionaryExample
    {
        internal DictionaryExample() { }
        public string SourcePrefix { get { throw null; } }
        public string SourceSuffix { get { throw null; } }
        public string SourceTerm { get { throw null; } }
        public string TargetPrefix { get { throw null; } }
        public string TargetSuffix { get { throw null; } }
        public string TargetTerm { get { throw null; } }
    }
    public partial class DictionaryExampleItem
    {
        internal DictionaryExampleItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryExample> Examples { get { throw null; } }
        public string NormalizedSource { get { throw null; } }
        public string NormalizedTarget { get { throw null; } }
    }
    public partial class DictionaryExampleTextItem : Azure.AI.Translation.Text.InputTextItem
    {
        public DictionaryExampleTextItem(string text, string translation) : base (default(string)) { }
        public string Translation { get { throw null; } }
    }
    public partial class DictionaryLookupItem
    {
        internal DictionaryLookupItem() { }
        public string DisplaySource { get { throw null; } }
        public string NormalizedSource { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryTranslation> Translations { get { throw null; } }
    }
    public partial class DictionaryTranslation
    {
        internal DictionaryTranslation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.BackTranslation> BackTranslations { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string DisplayTarget { get { throw null; } }
        public string NormalizedTarget { get { throw null; } }
        public string PosTag { get { throw null; } }
        public string PrefixWord { get { throw null; } }
    }
    public partial class GetLanguagesResult
    {
        internal GetLanguagesResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.SourceDictionaryLanguage> Dictionary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TranslationLanguage> Translation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Translation.Text.TransliterationLanguage> Transliteration { get { throw null; } }
    }
    public partial class InputTextItem
    {
        public InputTextItem(string text) { }
        public string Text { get { throw null; } }
    }
    public partial class InputTextWithTranslation
    {
        public InputTextWithTranslation(string word, string translation) { }
        public string Text { get { throw null; } }
        public string Translation { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfanityAction : System.IEquatable<Azure.AI.Translation.Text.ProfanityAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfanityAction(string value) { throw null; }
        public static Azure.AI.Translation.Text.ProfanityAction Deleted { get { throw null; } }
        public static Azure.AI.Translation.Text.ProfanityAction Marked { get { throw null; } }
        public static Azure.AI.Translation.Text.ProfanityAction NoAction { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Text.ProfanityAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Text.ProfanityAction left, Azure.AI.Translation.Text.ProfanityAction right) { throw null; }
        public static implicit operator Azure.AI.Translation.Text.ProfanityAction (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Text.ProfanityAction left, Azure.AI.Translation.Text.ProfanityAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfanityMarker : System.IEquatable<Azure.AI.Translation.Text.ProfanityMarker>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfanityMarker(string value) { throw null; }
        public static Azure.AI.Translation.Text.ProfanityMarker Asterisk { get { throw null; } }
        public static Azure.AI.Translation.Text.ProfanityMarker Tag { get { throw null; } }
        public bool Equals(Azure.AI.Translation.Text.ProfanityMarker other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Translation.Text.ProfanityMarker left, Azure.AI.Translation.Text.ProfanityMarker right) { throw null; }
        public static implicit operator Azure.AI.Translation.Text.ProfanityMarker (string value) { throw null; }
        public static bool operator !=(Azure.AI.Translation.Text.ProfanityMarker left, Azure.AI.Translation.Text.ProfanityMarker right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SentenceLength
    {
        internal SentenceLength() { }
        public System.Collections.Generic.IReadOnlyList<int> SrcSentLen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> TransSentLen { get { throw null; } }
    }
    public partial class SourceDictionaryLanguage
    {
        internal SourceDictionaryLanguage() { }
        public string Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TargetDictionaryLanguage> Translations { get { throw null; } }
    }
    public partial class SourceText
    {
        internal SourceText() { }
        public string Text { get { throw null; } }
    }
    public partial class TargetDictionaryLanguage
    {
        internal TargetDictionaryLanguage() { }
        public string Code { get { throw null; } }
        public string Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
    }
    public partial class TextTranslationClient
    {
        protected TextTranslationClient() { }
        public TextTranslationClient(Azure.AzureKeyCredential credential, string region = "global", Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.AzureKeyCredential credential, System.Uri endpoint, string region = "global", Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.Core.TokenCredential credential, Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        public TextTranslationClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.AI.Translation.Text.TextTranslationClientOptions options = null) { }
        protected TextTranslationClient(System.Uri endpoint) { }
        protected TextTranslationClient(System.Uri endpoint, Azure.AI.Translation.Text.TextTranslationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.BreakSentenceItem>> FindSentenceBoundaries(System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null, string language = null, string script = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.BreakSentenceItem>> FindSentenceBoundaries(string text, string clientTraceId = null, string language = null, string script = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.BreakSentenceItem>>> FindSentenceBoundariesAsync(System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null, string language = null, string script = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.BreakSentenceItem>>> FindSentenceBoundariesAsync(string text, string clientTraceId = null, string language = null, string script = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLanguages(string clientTraceId, string scope, string acceptLanguage, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Translation.Text.GetLanguagesResult> GetLanguages(string clientTraceId = null, string scope = null, string acceptLanguage = null, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLanguagesAsync(string clientTraceId, string scope, string acceptLanguage, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Translation.Text.GetLanguagesResult>> GetLanguagesAsync(string clientTraceId = null, string scope = null, string acceptLanguage = null, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryLookupItem>> LookupDictionaryEntries(string from, string to, System.Collections.Generic.IEnumerable<string> words, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryLookupItem>> LookupDictionaryEntries(string from, string to, string word, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string from, string to, System.Collections.Generic.IEnumerable<string> words, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string from, string to, string word, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryExampleItem>> LookupDictionaryExamples(string from, string to, Azure.AI.Translation.Text.InputTextWithTranslation content, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryExampleItem>> LookupDictionaryExamples(string from, string to, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.InputTextWithTranslation> content, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string from, string to, Azure.AI.Translation.Text.InputTextWithTranslation content, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string from, string to, System.Collections.Generic.IEnumerable<Azure.AI.Translation.Text.InputTextWithTranslation> content, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(Azure.AI.Translation.Text.TextTranslationTranslateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null, string sourceLanguage = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), string category = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), bool? includeAlignment = default(bool?), bool? includeSentenceLength = default(bool?), string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(string targetLanguage, System.Collections.Generic.IEnumerable<string> content, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>> Translate(string targetLanguage, string text, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(Azure.AI.Translation.Text.TextTranslationTranslateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null, string sourceLanguage = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), string category = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), bool? includeAlignment = default(bool?), bool? includeSentenceLength = default(bool?), string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(string targetLanguage, System.Collections.Generic.IEnumerable<string> content, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TranslatedTextItem>>> TranslateAsync(string targetLanguage, string text, string sourceLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>> Transliterate(Azure.AI.Translation.Text.TextTranslationTransliterateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>> Transliterate(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>> Transliterate(string language, string fromScript, string toScript, string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>>> TransliterateAsync(Azure.AI.Translation.Text.TextTranslationTransliterateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextTranslationClientOptions : Azure.Core.ClientOptions
    {
        public TextTranslationClientOptions(Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion version = Azure.AI.Translation.Text.TextTranslationClientOptions.ServiceVersion.V3_0) { }
        public enum ServiceVersion
        {
            V3_0 = 1,
        }
    }
    public partial class TextTranslationTranslateOptions
    {
        public TextTranslationTranslateOptions(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content) { }
        public TextTranslationTranslateOptions(System.Collections.Generic.IEnumerable<string> targetLanguages, System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null, string sourceLanguage = null, Azure.AI.Translation.Text.TextType? textType = default(Azure.AI.Translation.Text.TextType?), string category = null, Azure.AI.Translation.Text.ProfanityAction? profanityAction = default(Azure.AI.Translation.Text.ProfanityAction?), Azure.AI.Translation.Text.ProfanityMarker? profanityMarker = default(Azure.AI.Translation.Text.ProfanityMarker?), bool? includeAlignment = default(bool?), bool? includeSentenceLength = default(bool?), string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = default(bool?)) { }
        public TextTranslationTranslateOptions(string targetLanguage, string content) { }
        public bool? AllowFallback { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string ClientTraceId { get { throw null; } set { } }
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
        public TextTranslationTransliterateOptions(string language, string fromScript, string toScript, System.Collections.Generic.IEnumerable<string> content, string clientTraceId = null) { }
        public TextTranslationTransliterateOptions(string language, string fromScript, string toScript, string content, string clientTraceId = null) { }
        public string ClientTraceId { get { throw null; } set { } }
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
    public partial class TranslatedTextAlignment
    {
        internal TranslatedTextAlignment() { }
        public string Proj { get { throw null; } }
    }
    public partial class TranslatedTextItem
    {
        internal TranslatedTextItem() { }
        public Azure.AI.Translation.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public Azure.AI.Translation.Text.SourceText SourceText { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.Translation> Translations { get { throw null; } }
    }
    public partial class Translation
    {
        internal Translation() { }
        public Azure.AI.Translation.Text.TranslatedTextAlignment Alignment { get { throw null; } }
        public Azure.AI.Translation.Text.SentenceLength SentLen { get { throw null; } }
        public string Text { get { throw null; } }
        public string To { get { throw null; } }
        public Azure.AI.Translation.Text.TransliteratedText Transliteration { get { throw null; } }
    }
    public partial class TranslationLanguage
    {
        internal TranslationLanguage() { }
        public string Dir { get { throw null; } }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
    }
    public partial class TransliterableScript : Azure.AI.Translation.Text.CommonScriptModel
    {
        internal TransliterableScript() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.CommonScriptModel> ToScripts { get { throw null; } }
    }
    public partial class TransliteratedText
    {
        internal TransliteratedText() { }
        public string Script { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class TransliterationLanguage
    {
        internal TransliterationLanguage() { }
        public string Name { get { throw null; } }
        public string NativeName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Translation.Text.TransliterableScript> Scripts { get { throw null; } }
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
