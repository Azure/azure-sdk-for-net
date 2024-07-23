namespace Azure.AI.Language.Text
{
    public partial class TextAnalysisClient
    {
        protected TextAnalysisClient() { }
        public TextAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TextAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Text.TextAnalysisClientOptions options) { }
        public TextAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TextAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Text.TextAnalysisClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Text.Models.AnalyzeTextResult> AnalyzeText(Azure.AI.Language.Text.Models.AnalyzeTextInput analyzeTextInput, bool? showStatistics = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeText(Azure.Core.RequestContent content, bool? showStatistics = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Models.AnalyzeTextResult>> AnalyzeTextAsync(Azure.AI.Language.Text.Models.AnalyzeTextInput analyzeTextInput, bool? showStatistics = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextAsync(Azure.Core.RequestContent content, bool? showStatistics = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation AnalyzeTextCancelOperation(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeTextCancelOperationAsync(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Models.AnalyzeTextOperationState> AnalyzeTextOperation(Azure.AI.Language.Text.Models.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>> AnalyzeTextOperationAsync(Azure.AI.Language.Text.Models.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeTextOperationStatus(System.Guid jobId, bool? showStats, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Models.AnalyzeTextOperationState> AnalyzeTextOperationStatus(System.Guid jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextOperationStatusAsync(System.Guid jobId, bool? showStats, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>> AnalyzeTextOperationStatusAsync(System.Guid jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeTextSubmitOperation(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Models.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeTextSubmitOperation(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeTextSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Models.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeTextSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class TextAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalysisClientOptions(Azure.AI.Language.Text.TextAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Text.TextAnalysisClientOptions.ServiceVersion.V2023_11_15_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_01 = 1,
            V2023_04_01 = 2,
            V2023_11_15_Preview = 3,
        }
    }
}
namespace Azure.AI.Language.Text.Models
{
    public partial class AbstractiveSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent>
    {
        public AbstractiveSummarizationActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public int? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.SummaryLengthBucket? SummaryLength { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummarizationOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction>
    {
        public AbstractiveSummarizationOperationAction() { }
        public Azure.AI.Language.Text.Models.AbstractiveSummarizationActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummarizationOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult>
    {
        internal AbstractiveSummarizationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.AbstractiveSummarizationResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummarizationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationResult>
    {
        internal AbstractiveSummarizationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AbstractiveSummarizationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummarizationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummary>
    {
        internal AbstractiveSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.SummaryContext> Contexts { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.AbstractiveSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AbstractiveSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummaryDocumentResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage>
    {
        internal AbstractiveSummaryDocumentResultWithDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.AbstractiveSummary> Summaries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgeMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AgeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AgeMetadata>
    {
        internal AgeMetadata() { }
        public Azure.AI.Language.Text.Models.AgeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.AgeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AgeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AgeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AgeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AgeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AgeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AgeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgeUnit : System.IEquatable<Azure.AI.Language.Text.Models.AgeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgeUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.AgeUnit Day { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AgeUnit Month { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AgeUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AgeUnit Week { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AgeUnit Year { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.AgeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.AgeUnit left, Azure.AI.Language.Text.Models.AgeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.AgeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.AgeUnit left, Azure.AI.Language.Text.Models.AgeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class AILanguageTextModelFactory
    {
        public static Azure.AI.Language.Text.Models.AbstractiveSummarizationOperationResult AbstractiveSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.AbstractiveSummarizationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AbstractiveSummarizationResult AbstractiveSummarizationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AbstractiveSummary AbstractiveSummary(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.SummaryContext> contexts = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage AbstractiveSummaryDocumentResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AbstractiveSummary> summaries = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AgeMetadata AgeMetadata(double value = 0, Azure.AI.Language.Text.Models.AgeUnit unit = default(Azure.AI.Language.Text.Models.AgeUnit)) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult AnalyzeTextDynamicClassificationResult(Azure.AI.Language.Text.Models.DynamicClassificationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult AnalyzeTextEntitiesResult(Azure.AI.Language.Text.Models.EntitiesResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult AnalyzeTextEntityLinkingResult(Azure.AI.Language.Text.Models.EntityLinkingResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextError AnalyzeTextError(Azure.AI.Language.Text.Models.AnalyzeTextErrorCode code = default(Azure.AI.Language.Text.Models.AnalyzeTextErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AnalyzeTextError> details = null, Azure.AI.Language.Text.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult AnalyzeTextKeyPhraseResult(Azure.AI.Language.Text.Models.KeyPhraseResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult(Azure.AI.Language.Text.Models.LanguageDetectionResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextOperationResult AnalyzeTextOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, string kind = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextOperationState AnalyzeTextOperationState(string displayName = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.Guid jobId = default(System.Guid), System.DateTimeOffset lastUpdatedAt = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AnalyzeTextError> errors = null, string nextLink = null, Azure.AI.Language.Text.Models.TextActions actions = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextPiiResult AnalyzeTextPiiResult(Azure.AI.Language.Text.Models.PiiResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult AnalyzeTextSentimentResult(Azure.AI.Language.Text.Models.SentimentResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.AreaMetadata AreaMetadata(double value = 0, Azure.AI.Language.Text.Models.AreaUnit unit = default(Azure.AI.Language.Text.Models.AreaUnit)) { throw null; }
        public static Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage ClassificationDocumentResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.ClassificationResult> @class = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.ClassificationResult ClassificationResult(string category = null, double confidenceScore = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.CurrencyMetadata CurrencyMetadata(double value = 0, string unit = null, string iso4217 = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent CustomAbstractiveSummarizationActionContent(int? sentenceCount = default(int?), Azure.AI.Language.Text.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Text.Models.StringIndexType?), Azure.AI.Language.Text.Models.SummaryLengthBucket? summaryLength = default(Azure.AI.Language.Text.Models.SummaryLengthBucket?), bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction CustomAbstractiveSummarizationOperationAction(string name = null, Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent actionContent = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult CustomAbstractiveSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult CustomAbstractiveSummarizationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage> documents = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomEntitiesActionContent CustomEntitiesActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null, Azure.AI.Language.Text.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Text.Models.StringIndexType?)) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage CustomEntitiesResultWithDocumentDetectedLanguage(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string projectName = null, string deploymentName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult CustomEntityRecognitionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomHealthcareActionContent CustomHealthcareActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null, Azure.AI.Language.Text.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Text.Models.StringIndexType?)) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.CustomHealthcareEntity> entities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.HealthcareRelation> relations = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomHealthcareEntity CustomHealthcareEntity(string text = null, Azure.AI.Language.Text.Models.HealthcareEntityCategory category = default(Azure.AI.Language.Text.Models.HealthcareEntityCategory), string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0, Azure.AI.Language.Text.Models.HealthcareAssertion assertion = null, string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.HealthcareEntityLink> links = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.EntityComponentInformation> entityComponentInformation = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomHealthcareOperationResult CustomHealthcareOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.CustomHealthcareResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomHealthcareResult CustomHealthcareResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string projectName = null, string deploymentName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage CustomLabelClassificationResultWithDocumentDetectedLanguage(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string projectName = null, string deploymentName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent CustomMultiLabelClassificationActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult CustomMultiLabelClassificationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomSentenceSentiment CustomSentenceSentiment(string text = null, Azure.AI.Language.Text.Models.SentenceSentimentValue sentiment = Azure.AI.Language.Text.Models.SentenceSentimentValue.Positive, Azure.AI.Language.Text.Models.SentimentConfidenceScores confidenceScores = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent CustomSentimentAnalysisActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null, Azure.AI.Language.Text.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Text.Models.StringIndexType?)) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult CustomSentimentAnalysisOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult CustomSentimentAnalysisResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string projectName = null, string deploymentName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument CustomSentimentAnalysisResultDocument(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, Azure.AI.Language.Text.Models.DocumentSentiment sentiment = Azure.AI.Language.Text.Models.DocumentSentiment.Positive, Azure.AI.Language.Text.Models.SentimentConfidenceScores confidenceScores = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.CustomSentenceSentiment> sentences = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent CustomSingleLabelClassificationActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult CustomSingleLabelClassificationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.DateMetadata DateMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.Models.DateTimeMetadata DateTimeMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.Models.DateValue DateValue(string timex = null, string value = null, Azure.AI.Language.Text.Models.TemporalModifier? modifier = default(Azure.AI.Language.Text.Models.TemporalModifier?)) { throw null; }
        public static Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage(string name = null, string iso6391Name = null, double confidenceScore = 0, Azure.AI.Language.Text.Models.ScriptKind? script = default(Azure.AI.Language.Text.Models.ScriptKind?), Azure.AI.Language.Text.Models.ScriptCode? scriptCode = default(Azure.AI.Language.Text.Models.ScriptCode?)) { throw null; }
        public static Azure.AI.Language.Text.Models.DocumentError DocumentError(string id = null, Azure.AI.Language.Text.Models.AnalyzeTextError error = null) { throw null; }
        public static Azure.AI.Language.Text.Models.DocumentStatistics DocumentStatistics(int charactersCount = 0, int transactionsCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.DocumentWarning DocumentWarning(Azure.AI.Language.Text.Models.WarningCode code = default(Azure.AI.Language.Text.Models.WarningCode), string message = null, string targetRef = null) { throw null; }
        public static Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult DynamicClassificationDocumentResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.ClassificationResult> classifications = null) { throw null; }
        public static Azure.AI.Language.Text.Models.DynamicClassificationResult DynamicClassificationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage EntitiesDocumentResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.NamedEntity> entities = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage EntitiesDocumentResultWithMetadataDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.NamedEntityWithMetadata> entities = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntitiesResult EntitiesResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntityLinkingMatch EntityLinkingMatch(double confidenceScore = 0, string text = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.EntityLinkingOperationResult EntityLinkingOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.EntityLinkingResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntityLinkingResult EntityLinkingResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage EntityLinkingResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.LinkedEntity> entities = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntityRecognitionOperationResult EntityRecognitionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.EntitiesResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.EntityTag EntityTag(string name = null, double? confidenceScore = default(double?)) { throw null; }
        public static Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage ExtractedSummaryDocumentResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.ExtractedSummarySentence> sentences = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.ExtractedSummarySentence ExtractedSummarySentence(string text = null, double rankScore = 0, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult ExtractiveSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.ExtractiveSummarizationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.ExtractiveSummarizationResult ExtractiveSummarizationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.FhirBundle FhirBundle(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareAssertion HealthcareAssertion(Azure.AI.Language.Text.Models.HealthcareAssertionConditionality? conditionality = default(Azure.AI.Language.Text.Models.HealthcareAssertionConditionality?), Azure.AI.Language.Text.Models.HealthcareAssertionCertainty? certainty = default(Azure.AI.Language.Text.Models.HealthcareAssertionCertainty?), Azure.AI.Language.Text.Models.HealthcareAssertionAssociation? association = default(Azure.AI.Language.Text.Models.HealthcareAssertionAssociation?), Azure.AI.Language.Text.Models.HealthcareAssertionTemporality? temporality = default(Azure.AI.Language.Text.Models.HealthcareAssertionTemporality?)) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.HealthcareEntity> entities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.HealthcareRelation> relations = null, Azure.AI.Language.Text.Models.FhirBundle fhirBundle = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareEntity HealthcareEntity(string text = null, Azure.AI.Language.Text.Models.HealthcareEntityCategory category = default(Azure.AI.Language.Text.Models.HealthcareEntityCategory), string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0, Azure.AI.Language.Text.Models.HealthcareAssertion assertion = null, string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.HealthcareEntityLink> links = null) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareEntityLink HealthcareEntityLink(string dataSource = null, string id = null) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareOperationResult HealthcareOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.HealthcareResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareRelation HealthcareRelation(Azure.AI.Language.Text.Models.RelationType relationType = default(Azure.AI.Language.Text.Models.RelationType), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.HealthcareRelationEntity> entities = null, double? confidenceScore = default(double?)) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareRelationEntity HealthcareRelationEntity(string @ref = null, string role = null) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareResult HealthcareResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.InformationMetadata InformationMetadata(double value = 0, Azure.AI.Language.Text.Models.InformationUnit unit = default(Azure.AI.Language.Text.Models.InformationUnit)) { throw null; }
        public static Azure.AI.Language.Text.Models.InnerErrorModel InnerErrorModel(Azure.AI.Language.Text.Models.InnerErrorCode code = default(Azure.AI.Language.Text.Models.InnerErrorCode), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> details = null, string target = null, Azure.AI.Language.Text.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult KeyPhraseExtractionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.KeyPhraseResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.KeyPhraseResult KeyPhraseResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage KeyPhrasesDocumentResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<string> keyPhrases = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult LanguageDetectionDocumentResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.LanguageDetectionResult LanguageDetectionResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.LanguageInput LanguageInput(string id = null, string text = null, string countryHint = null) { throw null; }
        public static Azure.AI.Language.Text.Models.LearnedComponent LearnedComponent(string value = null) { throw null; }
        public static Azure.AI.Language.Text.Models.LengthMetadata LengthMetadata(double value = 0, Azure.AI.Language.Text.Models.LengthUnit unit = default(Azure.AI.Language.Text.Models.LengthUnit)) { throw null; }
        public static Azure.AI.Language.Text.Models.LinkedEntity LinkedEntity(string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.EntityLinkingMatch> matches = null, string language = null, string id = null, string url = null, string dataSource = null, string bingId = null) { throw null; }
        public static Azure.AI.Language.Text.Models.ListComponent ListComponent(string value = null) { throw null; }
        public static Azure.AI.Language.Text.Models.MultiLanguageInput MultiLanguageInput(string id = null, string text = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.Models.NamedEntity NamedEntity(string text = null, string category = null, string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.NamedEntityWithMetadata NamedEntityWithMetadata(string text = null, string category = null, string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0, string type = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.EntityTag> tags = null, Azure.AI.Language.Text.Models.BaseMetadata metadata = null) { throw null; }
        public static Azure.AI.Language.Text.Models.NumberMetadata NumberMetadata(Azure.AI.Language.Text.Models.NumberKind numberKind = default(Azure.AI.Language.Text.Models.NumberKind), double value = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.NumericRangeMetadata NumericRangeMetadata(Azure.AI.Language.Text.Models.RangeKind rangeKind = default(Azure.AI.Language.Text.Models.RangeKind), double minimum = 0, double maximum = 0, Azure.AI.Language.Text.Models.RangeInclusivity? rangeInclusivity = default(Azure.AI.Language.Text.Models.RangeInclusivity?)) { throw null; }
        public static Azure.AI.Language.Text.Models.OrdinalMetadata OrdinalMetadata(string offset = null, Azure.AI.Language.Text.Models.RelativeTo relativeTo = default(Azure.AI.Language.Text.Models.RelativeTo), string value = null) { throw null; }
        public static Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult PiiEntityRecognitionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.PiiResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.PiiResult PiiResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage PiiResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, string redactedText = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.NamedEntity> entities = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.PrebuiltComponent PrebuiltComponent(string value = null) { throw null; }
        public static Azure.AI.Language.Text.Models.RequestStatistics RequestStatistics(int documentsCount = 0, int validDocumentsCount = 0, int erroneousDocumentsCount = 0, long transactionsCount = (long)0) { throw null; }
        public static Azure.AI.Language.Text.Models.SentenceAssessment SentenceAssessment(Azure.AI.Language.Text.Models.TokenSentiment sentiment = Azure.AI.Language.Text.Models.TokenSentiment.Positive, Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel confidenceScores = null, int offset = 0, int length = 0, string text = null, bool isNegated = false) { throw null; }
        public static Azure.AI.Language.Text.Models.SentenceSentiment SentenceSentiment(string text = null, Azure.AI.Language.Text.Models.SentenceSentimentValue sentiment = Azure.AI.Language.Text.Models.SentenceSentimentValue.Positive, Azure.AI.Language.Text.Models.SentimentConfidenceScores confidenceScores = null, int offset = 0, int length = 0, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.SentenceTarget> targets = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.SentenceAssessment> assessments = null) { throw null; }
        public static Azure.AI.Language.Text.Models.SentenceTarget SentenceTarget(Azure.AI.Language.Text.Models.TokenSentiment sentiment = Azure.AI.Language.Text.Models.TokenSentiment.Positive, Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel confidenceScores = null, int offset = 0, int length = 0, string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.TargetRelation> relations = null) { throw null; }
        public static Azure.AI.Language.Text.Models.SentimentConfidenceScores SentimentConfidenceScores(double positive = 0, double neutral = 0, double negative = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage SentimentDocumentResultWithDetectedLanguage(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentWarning> warnings = null, Azure.AI.Language.Text.Models.DocumentStatistics statistics = null, Azure.AI.Language.Text.Models.DocumentSentiment sentiment = Azure.AI.Language.Text.Models.DocumentSentiment.Positive, Azure.AI.Language.Text.Models.SentimentConfidenceScores confidenceScores = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.SentenceSentiment> sentences = null, Azure.AI.Language.Text.Models.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.Models.SentimentOperationResult SentimentOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.Models.TextActionState status = default(Azure.AI.Language.Text.Models.TextActionState), string name = null, Azure.AI.Language.Text.Models.SentimentResult results = null) { throw null; }
        public static Azure.AI.Language.Text.Models.SentimentResult SentimentResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DocumentError> errors = null, Azure.AI.Language.Text.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage> documents = null) { throw null; }
        public static Azure.AI.Language.Text.Models.SpeedMetadata SpeedMetadata(double value = 0, Azure.AI.Language.Text.Models.SpeedUnit unit = default(Azure.AI.Language.Text.Models.SpeedUnit)) { throw null; }
        public static Azure.AI.Language.Text.Models.SummaryContext SummaryContext(int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel TargetConfidenceScoreLabel(double positive = 0, double negative = 0) { throw null; }
        public static Azure.AI.Language.Text.Models.TargetRelation TargetRelation(string @ref = null, Azure.AI.Language.Text.Models.TargetRelationType relationType = Azure.AI.Language.Text.Models.TargetRelationType.Assessment) { throw null; }
        public static Azure.AI.Language.Text.Models.TemperatureMetadata TemperatureMetadata(double value = 0, Azure.AI.Language.Text.Models.TemperatureUnit unit = default(Azure.AI.Language.Text.Models.TemperatureUnit)) { throw null; }
        public static Azure.AI.Language.Text.Models.TemporalSetMetadata TemporalSetMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.Models.TemporalSpanMetadata TemporalSpanMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.TemporalSpanValues> spanValues = null) { throw null; }
        public static Azure.AI.Language.Text.Models.TemporalSpanValues TemporalSpanValues(string begin = null, string end = null, string duration = null, Azure.AI.Language.Text.Models.TemporalModifier? modifier = default(Azure.AI.Language.Text.Models.TemporalModifier?), string timex = null) { throw null; }
        public static Azure.AI.Language.Text.Models.TextActions TextActions(int completed = 0, int failed = 0, int inProgress = 0, int total = 0, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult> items = null) { throw null; }
        public static Azure.AI.Language.Text.Models.TimeMetadata TimeMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Models.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.Models.VolumeMetadata VolumeMetadata(double value = 0, Azure.AI.Language.Text.Models.VolumeUnit unit = default(Azure.AI.Language.Text.Models.VolumeUnit)) { throw null; }
        public static Azure.AI.Language.Text.Models.WeightMetadata WeightMetadata(double value = 0, Azure.AI.Language.Text.Models.WeightUnit unit = default(Azure.AI.Language.Text.Models.WeightUnit)) { throw null; }
    }
    public partial class AllowOverlapEntityPolicyType : Azure.AI.Language.Text.Models.EntityOverlapPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType>
    {
        public AllowOverlapEntityPolicyType() { }
        Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AllowOverlapEntityPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextDynamicClassificationResult : Azure.AI.Language.Text.Models.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult>
    {
        internal AnalyzeTextDynamicClassificationResult() { }
        public Azure.AI.Language.Text.Models.DynamicClassificationResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextDynamicClassificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextEntitiesResult : Azure.AI.Language.Text.Models.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult>
    {
        internal AnalyzeTextEntitiesResult() { }
        public Azure.AI.Language.Text.Models.EntitiesResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextEntityLinkingResult : Azure.AI.Language.Text.Models.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult>
    {
        internal AnalyzeTextEntityLinkingResult() { }
        public Azure.AI.Language.Text.Models.EntityLinkingResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextEntityLinkingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextError>
    {
        internal AnalyzeTextError() { }
        public Azure.AI.Language.Text.Models.AnalyzeTextErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.AnalyzeTextError> Details { get { throw null; } }
        public Azure.AI.Language.Text.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeTextErrorCode : System.IEquatable<Azure.AI.Language.Text.Models.AnalyzeTextErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeTextErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode AzureCognitiveSearchIndexLimitReached { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode AzureCognitiveSearchIndexNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode Conflict { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode Forbidden { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode NotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode OperationNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode ProjectNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode QuotaExceeded { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode Timeout { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode TooManyRequests { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode Unauthorized { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AnalyzeTextErrorCode Warning { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.AnalyzeTextErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.AnalyzeTextErrorCode left, Azure.AI.Language.Text.Models.AnalyzeTextErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.AnalyzeTextErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.AnalyzeTextErrorCode left, Azure.AI.Language.Text.Models.AnalyzeTextErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AnalyzeTextInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextInput>
    {
        protected AnalyzeTextInput() { }
        Azure.AI.Language.Text.Models.AnalyzeTextInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextKeyPhraseResult : Azure.AI.Language.Text.Models.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult>
    {
        internal AnalyzeTextKeyPhraseResult() { }
        public Azure.AI.Language.Text.Models.KeyPhraseResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextKeyPhraseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextLanguageDetectionResult : Azure.AI.Language.Text.Models.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult>
    {
        internal AnalyzeTextLanguageDetectionResult() { }
        public Azure.AI.Language.Text.Models.LanguageDetectionResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextLanguageDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeTextOperationAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction>
    {
        protected AnalyzeTextOperationAction() { }
        public string Name { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.AnalyzeTextOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeTextOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult>
    {
        protected AnalyzeTextOperationResult(System.DateTimeOffset lastUpdateDateTime, Azure.AI.Language.Text.Models.TextActionState status) { }
        public System.DateTimeOffset LastUpdateDateTime { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Language.Text.Models.TextActionState Status { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>
    {
        internal AnalyzeTextOperationState() { }
        public Azure.AI.Language.Text.Models.TextActions Actions { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.AnalyzeTextError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Guid JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAt { get { throw null; } }
        public string NextLink { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        public Azure.AI.Language.Text.Models.TextActionState Status { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextPiiResult : Azure.AI.Language.Text.Models.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextPiiResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextPiiResult>
    {
        internal AnalyzeTextPiiResult() { }
        public Azure.AI.Language.Text.Models.PiiResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextPiiResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextPiiResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextPiiResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextPiiResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextPiiResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextPiiResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextPiiResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeTextResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextResult>
    {
        protected AnalyzeTextResult() { }
        Azure.AI.Language.Text.Models.AnalyzeTextResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextSentimentResult : Azure.AI.Language.Text.Models.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult>
    {
        internal AnalyzeTextSentimentResult() { }
        public Azure.AI.Language.Text.Models.SentimentResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AnalyzeTextSentimentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AreaMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AreaMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AreaMetadata>
    {
        internal AreaMetadata() { }
        public Azure.AI.Language.Text.Models.AreaUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.AreaMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AreaMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.AreaMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.AreaMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AreaMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AreaMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.AreaMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AreaUnit : System.IEquatable<Azure.AI.Language.Text.Models.AreaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AreaUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.AreaUnit Acre { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareCentimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareDecameter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareDecimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareFoot { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareHectometer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareInch { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareKilometer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareMeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareMile { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareMillimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit SquareYard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.AreaUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.AreaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.AreaUnit left, Azure.AI.Language.Text.Models.AreaUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.AreaUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.AreaUnit left, Azure.AI.Language.Text.Models.AreaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BaseMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.BaseMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.BaseMetadata>
    {
        protected BaseMetadata() { }
        Azure.AI.Language.Text.Models.BaseMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.BaseMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.BaseMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.BaseMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.BaseMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.BaseMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.BaseMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassificationDocumentResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage>
    {
        internal ClassificationDocumentResultWithDetectedLanguage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.ClassificationResult> Class { get { throw null; } }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassificationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ClassificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationResult>
    {
        internal ClassificationResult() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        Azure.AI.Language.Text.Models.ClassificationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ClassificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ClassificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ClassificationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ClassificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationType : System.IEquatable<Azure.AI.Language.Text.Models.ClassificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClassificationType(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.ClassificationType Multi { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ClassificationType Single { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.ClassificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.ClassificationType left, Azure.AI.Language.Text.Models.ClassificationType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.ClassificationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.ClassificationType left, Azure.AI.Language.Text.Models.ClassificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CurrencyMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CurrencyMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CurrencyMetadata>
    {
        internal CurrencyMetadata() { }
        public string Iso4217 { get { throw null; } }
        public string Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.CurrencyMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CurrencyMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CurrencyMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CurrencyMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CurrencyMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CurrencyMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CurrencyMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomAbstractiveSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent>
    {
        public CustomAbstractiveSummarizationActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public int? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.SummaryLengthBucket? SummaryLength { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomAbstractiveSummarizationOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction>
    {
        public CustomAbstractiveSummarizationOperationAction(Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent actionContent) { }
        public Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationActionContent ActionContent { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomAbstractiveSummarizationOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult>
    {
        internal CustomAbstractiveSummarizationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomAbstractiveSummarizationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult>
    {
        internal CustomAbstractiveSummarizationResult() { }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.AbstractiveSummaryDocumentResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomAbstractiveSummarizationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntitiesActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesActionContent>
    {
        public CustomEntitiesActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomEntitiesActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomEntitiesActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntitiesOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesOperationAction>
    {
        public CustomEntitiesOperationAction() { }
        public Azure.AI.Language.Text.Models.CustomEntitiesActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomEntitiesOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomEntitiesOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntitiesResultWithDocumentDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage>
    {
        internal CustomEntitiesResultWithDocumentDetectedLanguage() { }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityRecognitionOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult>
    {
        internal CustomEntityRecognitionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.CustomEntitiesResultWithDocumentDetectedLanguage Results { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomEntityRecognitionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareActionContent>
    {
        public CustomHealthcareActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomHealthcareActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomHealthcareActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>
    {
        internal CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.CustomHealthcareEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.HealthcareRelation> Relations { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntity>
    {
        internal CustomHealthcareEntity() { }
        public Azure.AI.Language.Text.Models.HealthcareAssertion Assertion { get { throw null; } }
        public Azure.AI.Language.Text.Models.HealthcareEntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.EntityComponentInformation> EntityComponentInformation { get { throw null; } }
        public int Length { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.HealthcareEntityLink> Links { get { throw null; } }
        public string Name { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomHealthcareEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomHealthcareEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationAction>
    {
        public CustomHealthcareOperationAction() { }
        public Azure.AI.Language.Text.Models.CustomHealthcareActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomHealthcareOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomHealthcareOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationResult>
    {
        internal CustomHealthcareOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.CustomHealthcareResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomHealthcareOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomHealthcareOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareResult>
    {
        internal CustomHealthcareResult() { }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.CustomHealthcareEntitiesDocumentResultWithDocumentDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomHealthcareResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomHealthcareResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomHealthcareResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomHealthcareResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLabelClassificationResultWithDocumentDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage>
    {
        internal CustomLabelClassificationResultWithDocumentDetectedLanguage() { }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.ClassificationDocumentResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent>
    {
        public CustomMultiLabelClassificationActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction>
    {
        public CustomMultiLabelClassificationOperationAction() { }
        public Azure.AI.Language.Text.Models.CustomMultiLabelClassificationActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult>
    {
        internal CustomMultiLabelClassificationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage Results { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomMultiLabelClassificationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSentenceSentiment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentenceSentiment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentenceSentiment>
    {
        internal CustomSentenceSentiment() { }
        public Azure.AI.Language.Text.Models.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.Language.Text.Models.SentenceSentimentValue Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomSentenceSentiment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentenceSentiment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentenceSentiment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSentenceSentiment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentenceSentiment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentenceSentiment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentenceSentiment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSentimentAnalysisActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent>
    {
        public CustomSentimentAnalysisActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSentimentAnalysisOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction>
    {
        public CustomSentimentAnalysisOperationAction() { }
        public Azure.AI.Language.Text.Models.CustomSentimentAnalysisActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSentimentAnalysisOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult>
    {
        internal CustomSentimentAnalysisOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSentimentAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult>
    {
        internal CustomSentimentAnalysisResult() { }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSentimentAnalysisResultDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument>
    {
        internal CustomSentimentAnalysisResultDocument() { }
        public Azure.AI.Language.Text.Models.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.CustomSentenceSentiment> Sentences { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentSentiment Sentiment { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSentimentAnalysisResultDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent>
    {
        public CustomSingleLabelClassificationActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction>
    {
        public CustomSingleLabelClassificationOperationAction() { }
        public Azure.AI.Language.Text.Models.CustomSingleLabelClassificationActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult>
    {
        internal CustomSingleLabelClassificationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.CustomLabelClassificationResultWithDocumentDetectedLanguage Results { get { throw null; } }
        Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.CustomSingleLabelClassificationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateMetadata>
    {
        internal DateMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DateValue> Dates { get { throw null; } }
        Azure.AI.Language.Text.Models.DateMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DateMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateTimeMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateTimeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateTimeMetadata>
    {
        internal DateTimeMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DateValue> Dates { get { throw null; } }
        Azure.AI.Language.Text.Models.DateTimeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateTimeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateTimeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DateTimeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateTimeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateTimeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateTimeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateValue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateValue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateValue>
    {
        internal DateValue() { }
        public Azure.AI.Language.Text.Models.TemporalModifier? Modifier { get { throw null; } }
        public string Timex { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.AI.Language.Text.Models.DateValue System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DateValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DateValue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DateValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DetectedLanguage>
    {
        internal DetectedLanguage() { }
        public double ConfidenceScore { get { throw null; } }
        public string Iso6391Name { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Language.Text.Models.ScriptKind? Script { get { throw null; } }
        public Azure.AI.Language.Text.Models.ScriptCode? ScriptCode { get { throw null; } }
        Azure.AI.Language.Text.Models.DetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentError>
    {
        internal DocumentError() { }
        public Azure.AI.Language.Text.Models.AnalyzeTextError Error { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.AI.Language.Text.Models.DocumentError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DocumentError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DocumentSentiment
    {
        Positive = 0,
        Neutral = 1,
        Negative = 2,
        Mixed = 3,
    }
    public partial class DocumentStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentStatistics>
    {
        internal DocumentStatistics() { }
        public int CharactersCount { get { throw null; } }
        public int TransactionsCount { get { throw null; } }
        Azure.AI.Language.Text.Models.DocumentStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DocumentStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentWarning>
    {
        internal DocumentWarning() { }
        public Azure.AI.Language.Text.Models.WarningCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string TargetRef { get { throw null; } }
        Azure.AI.Language.Text.Models.DocumentWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DocumentWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DocumentWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DocumentWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynamicClassificationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationActionContent>
    {
        public DynamicClassificationActionContent(System.Collections.Generic.IEnumerable<string> categories) { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public Azure.AI.Language.Text.Models.ClassificationType? ClassificationType { get { throw null; } set { } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.DynamicClassificationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DynamicClassificationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynamicClassificationDocumentResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult>
    {
        internal DynamicClassificationDocumentResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.ClassificationResult> Classifications { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynamicClassificationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationResult>
    {
        internal DynamicClassificationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DynamicClassificationDocumentResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.DynamicClassificationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.DynamicClassificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.DynamicClassificationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.DynamicClassificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesActionContent>
    {
        public EntitiesActionContent() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Models.EntityCategory> Exclusions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Models.EntityCategory> Inclusions { get { throw null; } }
        public Azure.AI.Language.Text.Models.EntityInferenceConfig InferenceOptions { get { throw null; } set { } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.EntityOverlapPolicy OverlapPolicy { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.EntitiesActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntitiesActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesDocumentResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage>
    {
        internal EntitiesDocumentResultWithDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.NamedEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesDocumentResultWithMetadataDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage>
    {
        internal EntitiesDocumentResultWithMetadataDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.NamedEntityWithMetadata> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesOperationAction>
    {
        public EntitiesOperationAction() { }
        public Azure.AI.Language.Text.Models.EntitiesActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.EntitiesOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntitiesOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesResult>
    {
        internal EntitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.EntitiesDocumentResultWithMetadataDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.EntitiesResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityCategory : System.IEquatable<Azure.AI.Language.Text.Models.EntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityCategory(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.EntityCategory Address { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Age { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Airport { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Area { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory City { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory ComputingProduct { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Continent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory CountryRegion { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory CulturalEvent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Currency { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Date { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory DateRange { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory DateTime { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory DateTimeRange { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Dimension { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Duration { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Email { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Event { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Geological { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory GeoPoliticalEntity { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Height { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Information { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory IpAddress { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Length { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Location { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory NaturalEvent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Number { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory NumberRange { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Numeric { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Ordinal { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Organization { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory OrganizationMedical { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory OrganizationSports { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory OrganizationStockExchange { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Percentage { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Person { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory PersonType { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Product { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory SetTemporal { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Skill { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Speed { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory SportsEvent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory State { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Structural { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Temperature { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Temporal { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Time { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory TimeRange { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Uri { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Volume { get { throw null; } }
        public static Azure.AI.Language.Text.Models.EntityCategory Weight { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.EntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.EntityCategory left, Azure.AI.Language.Text.Models.EntityCategory right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.EntityCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.EntityCategory left, Azure.AI.Language.Text.Models.EntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EntityComponentInformation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityComponentInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityComponentInformation>
    {
        protected EntityComponentInformation() { }
        Azure.AI.Language.Text.Models.EntityComponentInformation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityComponentInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityComponentInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityComponentInformation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityComponentInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityComponentInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityComponentInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityInferenceConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityInferenceConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityInferenceConfig>
    {
        public EntityInferenceConfig() { }
        public bool? ExcludeNormalizedValues { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.EntityInferenceConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityInferenceConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityInferenceConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityInferenceConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityInferenceConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityInferenceConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityInferenceConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingActionContent>
    {
        public EntityLinkingActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.EntityLinkingActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityLinkingActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingMatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingMatch>
    {
        internal EntityLinkingMatch() { }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.EntityLinkingMatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityLinkingMatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationAction>
    {
        public EntityLinkingOperationAction() { }
        public Azure.AI.Language.Text.Models.EntityLinkingActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.EntityLinkingOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityLinkingOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationResult>
    {
        internal EntityLinkingOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.EntityLinkingResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.EntityLinkingOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityLinkingOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResult>
    {
        internal EntityLinkingResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.EntityLinkingResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityLinkingResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage>
    {
        internal EntityLinkingResultWithDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.LinkedEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityLinkingResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EntityOverlapPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityOverlapPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityOverlapPolicy>
    {
        protected EntityOverlapPolicy() { }
        Azure.AI.Language.Text.Models.EntityOverlapPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityOverlapPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityOverlapPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityOverlapPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityOverlapPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityOverlapPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityOverlapPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityRecognitionOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityRecognitionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityRecognitionOperationResult>
    {
        internal EntityRecognitionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.EntitiesResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.EntityRecognitionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityRecognitionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityRecognitionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityRecognitionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityRecognitionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityRecognitionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityRecognitionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityTag : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityTag>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityTag>
    {
        internal EntityTag() { }
        public double? ConfidenceScore { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.AI.Language.Text.Models.EntityTag System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.EntityTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.EntityTag System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.EntityTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractedSummaryDocumentResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage>
    {
        internal ExtractedSummaryDocumentResultWithDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.ExtractedSummarySentence> Sentences { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractedSummarySentence : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractedSummarySentence>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummarySentence>
    {
        internal ExtractedSummarySentence() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public double RankScore { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.ExtractedSummarySentence System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractedSummarySentence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractedSummarySentence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ExtractedSummarySentence System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummarySentence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummarySentence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractedSummarySentence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent>
    {
        public ExtractiveSummarizationActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public long? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria? SortBy { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction>
    {
        public ExtractiveSummarizationOperationAction() { }
        public Azure.AI.Language.Text.Models.ExtractiveSummarizationActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult>
    {
        internal ExtractiveSummarizationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.ExtractiveSummarizationResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationResult>
    {
        internal ExtractiveSummarizationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.ExtractedSummaryDocumentResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ExtractiveSummarizationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ExtractiveSummarizationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtractiveSummarizationSortingCriteria : System.IEquatable<Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtractiveSummarizationSortingCriteria(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria Offset { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria Rank { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria left, Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria left, Azure.AI.Language.Text.Models.ExtractiveSummarizationSortingCriteria right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirBundle : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.FhirBundle>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.FhirBundle>
    {
        internal FhirBundle() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        Azure.AI.Language.Text.Models.FhirBundle System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.FhirBundle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.FhirBundle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.FhirBundle System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.FhirBundle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.FhirBundle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.FhirBundle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FhirVersion : System.IEquatable<Azure.AI.Language.Text.Models.FhirVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FhirVersion(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.FhirVersion _401 { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.FhirVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.FhirVersion left, Azure.AI.Language.Text.Models.FhirVersion right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.FhirVersion (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.FhirVersion left, Azure.AI.Language.Text.Models.FhirVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareActionContent>
    {
        public HealthcareActionContent() { }
        public Azure.AI.Language.Text.Models.HealthcareDocumentType? DocumentType { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.FhirVersion? FhirVersion { get { throw null; } set { } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.HealthcareActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareAssertion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareAssertion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareAssertion>
    {
        internal HealthcareAssertion() { }
        public Azure.AI.Language.Text.Models.HealthcareAssertionAssociation? Association { get { throw null; } }
        public Azure.AI.Language.Text.Models.HealthcareAssertionCertainty? Certainty { get { throw null; } }
        public Azure.AI.Language.Text.Models.HealthcareAssertionConditionality? Conditionality { get { throw null; } }
        public Azure.AI.Language.Text.Models.HealthcareAssertionTemporality? Temporality { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareAssertion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareAssertion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareAssertion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareAssertion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareAssertion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareAssertion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareAssertion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum HealthcareAssertionAssociation
    {
        Subject = 0,
        Other = 1,
    }
    public enum HealthcareAssertionCertainty
    {
        Positive = 0,
        PositivePossible = 1,
        NeutralPossible = 2,
        NegativePossible = 3,
        Negative = 4,
    }
    public enum HealthcareAssertionConditionality
    {
        Hypothetical = 0,
        Conditional = 1,
    }
    public enum HealthcareAssertionTemporality
    {
        Current = 0,
        Past = 1,
        Future = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareDocumentType : System.IEquatable<Azure.AI.Language.Text.Models.HealthcareDocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareDocumentType(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType ClinicalTrial { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType Consult { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType DischargeSummary { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType HistoryAndPhysical { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType Imaging { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType None { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType Pathology { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType ProcedureNote { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareDocumentType ProgressNote { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.HealthcareDocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.HealthcareDocumentType left, Azure.AI.Language.Text.Models.HealthcareDocumentType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.HealthcareDocumentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.HealthcareDocumentType left, Azure.AI.Language.Text.Models.HealthcareDocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>
    {
        internal HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.HealthcareEntity> Entities { get { throw null; } }
        public Azure.AI.Language.Text.Models.FhirBundle FhirBundle { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.HealthcareRelation> Relations { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntity>
    {
        internal HealthcareEntity() { }
        public Azure.AI.Language.Text.Models.HealthcareAssertion Assertion { get { throw null; } }
        public Azure.AI.Language.Text.Models.HealthcareEntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.HealthcareEntityLink> Links { get { throw null; } }
        public string Name { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareEntityCategory : System.IEquatable<Azure.AI.Language.Text.Models.HealthcareEntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareEntityCategory(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory AdministrativeEvent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Age { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Allergen { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory BodyStructure { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory CareEnvironment { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory ConditionQualifier { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory ConditionScale { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Course { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Date { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Diagnosis { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Direction { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Dosage { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Employment { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Ethnicity { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory ExaminationName { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Expression { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory FamilyRelation { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Frequency { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Gender { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory GeneOrProtein { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory HealthcareProfession { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory LivingStatus { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory MeasurementUnit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory MeasurementValue { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory MedicationClass { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory MedicationForm { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory MedicationName { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory MedicationRoute { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory MutationType { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory RelationalOperator { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory SubstanceUse { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory SubstanceUseAmount { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory SymptomOrSign { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Time { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory TreatmentName { get { throw null; } }
        public static Azure.AI.Language.Text.Models.HealthcareEntityCategory Variant { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.HealthcareEntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.HealthcareEntityCategory left, Azure.AI.Language.Text.Models.HealthcareEntityCategory right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.HealthcareEntityCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.HealthcareEntityCategory left, Azure.AI.Language.Text.Models.HealthcareEntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareEntityLink : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntityLink>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntityLink>
    {
        internal HealthcareEntityLink() { }
        public string DataSource { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareEntityLink System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntityLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareEntityLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareEntityLink System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntityLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntityLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareEntityLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationAction>
    {
        public HealthcareOperationAction() { }
        public Azure.AI.Language.Text.Models.HealthcareActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.HealthcareOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationResult>
    {
        internal HealthcareOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.HealthcareResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareRelation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareRelation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelation>
    {
        internal HealthcareRelation() { }
        public double? ConfidenceScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.HealthcareRelationEntity> Entities { get { throw null; } }
        public Azure.AI.Language.Text.Models.RelationType RelationType { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareRelation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareRelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareRelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareRelation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareRelationEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareRelationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelationEntity>
    {
        internal HealthcareRelationEntity() { }
        public string Ref { get { throw null; } }
        public string Role { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareRelationEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareRelationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareRelationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareRelationEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareRelationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareResult>
    {
        internal HealthcareResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.HealthcareResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.HealthcareResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.HealthcareResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.HealthcareResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformationMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.InformationMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InformationMetadata>
    {
        internal InformationMetadata() { }
        public Azure.AI.Language.Text.Models.InformationUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.InformationMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.InformationMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.InformationMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.InformationMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InformationMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InformationMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InformationMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformationUnit : System.IEquatable<Azure.AI.Language.Text.Models.InformationUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformationUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.InformationUnit Bit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Byte { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Gigabit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Gigabyte { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Kilobit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Kilobyte { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Megabit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Megabyte { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Petabit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Petabyte { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Terabit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Terabyte { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InformationUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.InformationUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.InformationUnit left, Azure.AI.Language.Text.Models.InformationUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.InformationUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.InformationUnit left, Azure.AI.Language.Text.Models.InformationUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InnerErrorCode : System.IEquatable<Azure.AI.Language.Text.Models.InnerErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InnerErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.InnerErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode EmptyRequest { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode ExtractionFailure { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode InvalidCountryHint { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode InvalidDocument { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode InvalidDocumentBatch { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode InvalidParameterValue { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode InvalidRequestBodyFormat { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode KnowledgeBaseNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode MissingInputDocuments { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode ModelVersionIncorrect { get { throw null; } }
        public static Azure.AI.Language.Text.Models.InnerErrorCode UnsupportedLanguageCode { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.InnerErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.InnerErrorCode left, Azure.AI.Language.Text.Models.InnerErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.InnerErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.InnerErrorCode left, Azure.AI.Language.Text.Models.InnerErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InnerErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.InnerErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InnerErrorModel>
    {
        internal InnerErrorModel() { }
        public Azure.AI.Language.Text.Models.InnerErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Details { get { throw null; } }
        public Azure.AI.Language.Text.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.AI.Language.Text.Models.InnerErrorModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.InnerErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.InnerErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.InnerErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InnerErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InnerErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.InnerErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseActionContent>
    {
        public KeyPhraseActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.KeyPhraseActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.KeyPhraseActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseExtractionOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult>
    {
        internal KeyPhraseExtractionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.KeyPhraseResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseExtractionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseOperationAction>
    {
        public KeyPhraseOperationAction() { }
        public Azure.AI.Language.Text.Models.KeyPhraseActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.KeyPhraseOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.KeyPhraseOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseResult>
    {
        internal KeyPhraseResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.KeyPhraseResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhraseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.KeyPhraseResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhraseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhrasesDocumentResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage>
    {
        internal KeyPhrasesDocumentResultWithDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> KeyPhrases { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.KeyPhrasesDocumentResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionActionContent>
    {
        public LanguageDetectionActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.LanguageDetectionActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LanguageDetectionActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionDocumentResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult>
    {
        internal LanguageDetectionDocumentResult() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionResult>
    {
        internal LanguageDetectionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.LanguageDetectionDocumentResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.LanguageDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LanguageDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionTextInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionTextInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionTextInput>
    {
        public LanguageDetectionTextInput() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Models.LanguageInput> Documents { get { throw null; } }
        Azure.AI.Language.Text.Models.LanguageDetectionTextInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionTextInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageDetectionTextInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LanguageDetectionTextInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionTextInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionTextInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageDetectionTextInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageInput>
    {
        public LanguageInput(string id, string text) { }
        public string CountryHint { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.LanguageInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LanguageInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LanguageInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LanguageInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LearnedComponent : Azure.AI.Language.Text.Models.EntityComponentInformation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LearnedComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LearnedComponent>
    {
        internal LearnedComponent() { }
        public string Value { get { throw null; } }
        Azure.AI.Language.Text.Models.LearnedComponent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LearnedComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LearnedComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LearnedComponent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LearnedComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LearnedComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LearnedComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LengthMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LengthMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LengthMetadata>
    {
        internal LengthMetadata() { }
        public Azure.AI.Language.Text.Models.LengthUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.LengthMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LengthMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LengthMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LengthMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LengthMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LengthMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LengthMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LengthUnit : System.IEquatable<Azure.AI.Language.Text.Models.LengthUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LengthUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.LengthUnit Centimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Decameter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Decimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Foot { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Hectometer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Inch { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Kilometer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit LightYear { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Meter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Micrometer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Mile { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Millimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Nanometer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Picometer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Point { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Text.Models.LengthUnit Yard { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.LengthUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.LengthUnit left, Azure.AI.Language.Text.Models.LengthUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.LengthUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.LengthUnit left, Azure.AI.Language.Text.Models.LengthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LinkedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LinkedEntity>
    {
        internal LinkedEntity() { }
        public string BingId { get { throw null; } }
        public string DataSource { get { throw null; } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.EntityLinkingMatch> Matches { get { throw null; } }
        public string Name { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.AI.Language.Text.Models.LinkedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LinkedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.LinkedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.LinkedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LinkedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LinkedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.LinkedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListComponent : Azure.AI.Language.Text.Models.EntityComponentInformation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ListComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ListComponent>
    {
        internal ListComponent() { }
        public string Value { get { throw null; } }
        Azure.AI.Language.Text.Models.ListComponent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ListComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.ListComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.ListComponent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ListComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ListComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.ListComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MatchLongestEntityPolicyType : Azure.AI.Language.Text.Models.EntityOverlapPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType>
    {
        public MatchLongestEntityPolicyType() { }
        Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MatchLongestEntityPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLanguageInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MultiLanguageInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageInput>
    {
        public MultiLanguageInput(string id, string text) { }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.MultiLanguageInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MultiLanguageInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MultiLanguageInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.MultiLanguageInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLanguageTextInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MultiLanguageTextInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageTextInput>
    {
        public MultiLanguageTextInput() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Models.MultiLanguageInput> Documents { get { throw null; } }
        Azure.AI.Language.Text.Models.MultiLanguageTextInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MultiLanguageTextInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.MultiLanguageTextInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.MultiLanguageTextInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageTextInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageTextInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.MultiLanguageTextInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NamedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntity>
    {
        internal NamedEntity() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.NamedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NamedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NamedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.NamedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEntityWithMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NamedEntityWithMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntityWithMetadata>
    {
        internal NamedEntityWithMetadata() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public Azure.AI.Language.Text.Models.BaseMetadata Metadata { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.EntityTag> Tags { get { throw null; } }
        public string Text { get { throw null; } }
        public string Type { get { throw null; } }
        Azure.AI.Language.Text.Models.NamedEntityWithMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NamedEntityWithMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NamedEntityWithMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.NamedEntityWithMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntityWithMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntityWithMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NamedEntityWithMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NumberKind : System.IEquatable<Azure.AI.Language.Text.Models.NumberKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NumberKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.NumberKind Decimal { get { throw null; } }
        public static Azure.AI.Language.Text.Models.NumberKind Fraction { get { throw null; } }
        public static Azure.AI.Language.Text.Models.NumberKind Integer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.NumberKind Percent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.NumberKind Power { get { throw null; } }
        public static Azure.AI.Language.Text.Models.NumberKind Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.NumberKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.NumberKind left, Azure.AI.Language.Text.Models.NumberKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.NumberKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.NumberKind left, Azure.AI.Language.Text.Models.NumberKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumberMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NumberMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumberMetadata>
    {
        internal NumberMetadata() { }
        public Azure.AI.Language.Text.Models.NumberKind NumberKind { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.NumberMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NumberMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NumberMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.NumberMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumberMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumberMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumberMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumericRangeMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NumericRangeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumericRangeMetadata>
    {
        internal NumericRangeMetadata() { }
        public double Maximum { get { throw null; } }
        public double Minimum { get { throw null; } }
        public Azure.AI.Language.Text.Models.RangeInclusivity? RangeInclusivity { get { throw null; } }
        public Azure.AI.Language.Text.Models.RangeKind RangeKind { get { throw null; } }
        Azure.AI.Language.Text.Models.NumericRangeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NumericRangeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.NumericRangeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.NumericRangeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumericRangeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumericRangeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.NumericRangeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrdinalMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.OrdinalMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.OrdinalMetadata>
    {
        internal OrdinalMetadata() { }
        public string Offset { get { throw null; } }
        public Azure.AI.Language.Text.Models.RelativeTo RelativeTo { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.AI.Language.Text.Models.OrdinalMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.OrdinalMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.OrdinalMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.OrdinalMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.OrdinalMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.OrdinalMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.OrdinalMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiActionContent>
    {
        public PiiActionContent() { }
        public Azure.AI.Language.Text.Models.PiiDomain? Domain { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Models.PiiCategoriesExclude> ExcludePiiCategories { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Models.PiiCategory> PiiCategories { get { throw null; } }
        public Azure.AI.Language.Text.Models.RedactionCharacter? RedactionCharacter { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.PiiActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.PiiActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiCategoriesExclude : System.IEquatable<Azure.AI.Language.Text.Models.PiiCategoriesExclude>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiCategoriesExclude(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AbaRoutingNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude Address { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude Age { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ArNationalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AtIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AtValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AuBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AuBusinessNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AuCompanyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AuMedicalAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AuTaxFileNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureDocumentDbauthKey { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureIaasDatabaseConnectionAndSqlString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureIoTConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzurePublishSettingPassword { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureRedisCacheString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureSas { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureServiceBusString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureStorageAccountGeneric { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude AzureStorageAccountKey { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude BeNationalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude BeNationalNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude BeValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude BgUniformCivilNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude BrCpfNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude BrLegalEntityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude BrNationalIdRg { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CaBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CaDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CaHealthServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CaPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CaPersonalHealthIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CaSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ChSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ClIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CnResidentIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CyIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CyTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CzPersonalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude CzPersonalIdentityV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude Date { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DeDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DeIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DeValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DkPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DkPersonalIdentificationV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude DrugEnforcementAgencyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EePersonalIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude Email { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EsDni { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EsTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EuDebitCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EuGpsCoordinates { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EuNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EuSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude EuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FiEuropeanHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FiNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FiNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FiPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FrDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FrHealthInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FrNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FrPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FrSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude FrValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude GrNationalIdCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude GrNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude GrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HkIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HrIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HrNationalIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HrPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HrPersonalIdentificationOIBNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HuPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude HuValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude IdIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude IePersonalPublicServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude IePersonalPublicServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude IlBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude IlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude InPermanentAccount { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude InternationalBankingAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude InUniqueIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude IPAddress { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ItDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ItFiscalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ItValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpMyNumberCorporate { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpMyNumberPersonal { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpResidenceCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude JpSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude KrResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude LtPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude LuNationalIdentificationNumberNatural { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude LuNationalIdentificationNumberNonNatural { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude LvPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude MtIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude MtTaxIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude MyIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NlCitizensServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NlCitizensServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NlValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NoIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NzBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NzDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NzInlandRevenueNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NzMinistryOfHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude NzSocialWelfareNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude Organization { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude Person { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PhUnifiedMultiPurposeIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PlIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PlNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PlPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PlRegonNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PtCitizenCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PtCitizenCardNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude PtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude RoPersonalNumericalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude RuPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude RuPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SaNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SeNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SeNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SgNationalRegistrationIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SiTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SiUniqueMasterCitizenNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SkPersonalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SqlServerConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude SwiftCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ThPopulationIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude TrNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude TwNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude TwPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude TwResidentCertificate { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UaPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UaPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UkDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UkElectoralRollNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UkNationalHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UkNationalInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UkUniqueTaxpayerNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude URL { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UsBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UsDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UsIndividualTaxpayerIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude UsUkPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategoriesExclude ZaIdentificationNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.PiiCategoriesExclude other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.PiiCategoriesExclude left, Azure.AI.Language.Text.Models.PiiCategoriesExclude right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.PiiCategoriesExclude (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.PiiCategoriesExclude left, Azure.AI.Language.Text.Models.PiiCategoriesExclude right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiCategory : System.IEquatable<Azure.AI.Language.Text.Models.PiiCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiCategory(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.PiiCategory AbaRoutingNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory Address { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory Age { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory All { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ArNationalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AtIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AtValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AuBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AuBusinessNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AuCompanyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AuMedicalAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AuTaxFileNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureDocumentDbauthKey { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureIaasDatabaseConnectionAndSqlString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureIoTConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzurePublishSettingPassword { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureRedisCacheString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureSas { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureServiceBusString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureStorageAccountGeneric { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory AzureStorageAccountKey { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory BeNationalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory BeNationalNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory BeValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory BgUniformCivilNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory BrCpfNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory BrLegalEntityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory BrNationalIdRg { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CaBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CaDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CaHealthServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CaPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CaPersonalHealthIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CaSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ChSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ClIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CnResidentIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CyIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CyTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CzPersonalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory CzPersonalIdentityV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory Date { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DeDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory Default { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DeIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DeValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DkPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DkPersonalIdentificationV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory DrugEnforcementAgencyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EePersonalIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory Email { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EsDni { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EsTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EuDebitCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EuGpsCoordinates { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EuNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EuSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory EuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FiEuropeanHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FiNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FiNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FiPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FrDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FrHealthInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FrNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FrPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FrSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory FrValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory GrNationalIdCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory GrNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory GrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HkIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HrIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HrNationalIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HrPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HrPersonalIdentificationOIBNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HuPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory HuValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory IdIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory IePersonalPublicServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory IePersonalPublicServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory IlBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory IlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory InPermanentAccount { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory InternationalBankingAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory InUniqueIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory IPAddress { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ItDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ItFiscalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ItValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpMyNumberCorporate { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpMyNumberPersonal { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpResidenceCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory JpSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory KrResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory LtPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory LuNationalIdentificationNumberNatural { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory LuNationalIdentificationNumberNonNatural { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory LvPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory MtIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory MtTaxIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory MyIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NlCitizensServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NlCitizensServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NlValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NoIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NzBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NzDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NzInlandRevenueNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NzMinistryOfHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory NzSocialWelfareNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory Organization { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory Person { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PhUnifiedMultiPurposeIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PlIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PlNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PlPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PlRegonNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PtCitizenCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PtCitizenCardNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory PtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory RoPersonalNumericalCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory RuPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory RuPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SaNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SeNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SeNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SgNationalRegistrationIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SiTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SiUniqueMasterCitizenNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SkPersonalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SqlServerConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory SwiftCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ThPopulationIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory TrNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory TwNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory TwPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory TwResidentCertificate { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UaPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UaPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UkDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UkElectoralRollNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UkNationalHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UkNationalInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UkUniqueTaxpayerNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory URL { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UsBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UsDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UsIndividualTaxpayerIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory UsUkPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiCategory ZaIdentificationNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.PiiCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.PiiCategory left, Azure.AI.Language.Text.Models.PiiCategory right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.PiiCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.PiiCategory left, Azure.AI.Language.Text.Models.PiiCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiDomain : System.IEquatable<Azure.AI.Language.Text.Models.PiiDomain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiDomain(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.PiiDomain None { get { throw null; } }
        public static Azure.AI.Language.Text.Models.PiiDomain Phi { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.PiiDomain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.PiiDomain left, Azure.AI.Language.Text.Models.PiiDomain right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.PiiDomain (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.PiiDomain left, Azure.AI.Language.Text.Models.PiiDomain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PiiEntityRecognitionOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult>
    {
        internal PiiEntityRecognitionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.PiiResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiEntityRecognitionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiOperationAction>
    {
        public PiiOperationAction() { }
        public Azure.AI.Language.Text.Models.PiiActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.PiiOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.PiiOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResult>
    {
        internal PiiResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.PiiResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.PiiResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage>
    {
        internal PiiResultWithDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.NamedEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public string RedactedText { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PiiResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrebuiltComponent : Azure.AI.Language.Text.Models.EntityComponentInformation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PrebuiltComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PrebuiltComponent>
    {
        internal PrebuiltComponent() { }
        public string Value { get { throw null; } }
        Azure.AI.Language.Text.Models.PrebuiltComponent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PrebuiltComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.PrebuiltComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.PrebuiltComponent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PrebuiltComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PrebuiltComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.PrebuiltComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RangeInclusivity : System.IEquatable<Azure.AI.Language.Text.Models.RangeInclusivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RangeInclusivity(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.RangeInclusivity LeftInclusive { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeInclusivity LeftRightInclusive { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeInclusivity NoneInclusive { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeInclusivity RightInclusive { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.RangeInclusivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.RangeInclusivity left, Azure.AI.Language.Text.Models.RangeInclusivity right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.RangeInclusivity (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.RangeInclusivity left, Azure.AI.Language.Text.Models.RangeInclusivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RangeKind : System.IEquatable<Azure.AI.Language.Text.Models.RangeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RangeKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.RangeKind Age { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Area { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Currency { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Information { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Length { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Number { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Speed { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Temperature { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Volume { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RangeKind Weight { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.RangeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.RangeKind left, Azure.AI.Language.Text.Models.RangeKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.RangeKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.RangeKind left, Azure.AI.Language.Text.Models.RangeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedactionCharacter : System.IEquatable<Azure.AI.Language.Text.Models.RedactionCharacter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedactionCharacter(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Ampersand { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Asterisk { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter AtSign { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Caret { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Dollar { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter EqualsValue { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter ExclamationPoint { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Minus { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter NumberSign { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter PerCent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Plus { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter QuestionMark { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Tilde { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RedactionCharacter Underscore { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.RedactionCharacter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.RedactionCharacter left, Azure.AI.Language.Text.Models.RedactionCharacter right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.RedactionCharacter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.RedactionCharacter left, Azure.AI.Language.Text.Models.RedactionCharacter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelationType : System.IEquatable<Azure.AI.Language.Text.Models.RelationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelationType(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.RelationType Abbreviation { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType BodySiteOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType BodySiteOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType CourseOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType CourseOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType CourseOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType CourseOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType DirectionOfBodyStructure { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType DirectionOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType DirectionOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType DirectionOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType DosageOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType ExaminationFindsCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType ExpressionOfGene { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType ExpressionOfVariant { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType FormOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType FrequencyOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType FrequencyOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType FrequencyOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType MutationTypeOfGene { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType MutationTypeOfVariant { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType QualifierOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType RelationOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType RouteOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType ScaleOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType TimeOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType TimeOfEvent { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType TimeOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType TimeOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType TimeOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType UnitOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType UnitOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType ValueOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType ValueOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelationType VariantOfGene { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.RelationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.RelationType left, Azure.AI.Language.Text.Models.RelationType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.RelationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.RelationType left, Azure.AI.Language.Text.Models.RelationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelativeTo : System.IEquatable<Azure.AI.Language.Text.Models.RelativeTo>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelativeTo(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.RelativeTo Current { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelativeTo End { get { throw null; } }
        public static Azure.AI.Language.Text.Models.RelativeTo Start { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.RelativeTo other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.RelativeTo left, Azure.AI.Language.Text.Models.RelativeTo right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.RelativeTo (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.RelativeTo left, Azure.AI.Language.Text.Models.RelativeTo right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.RequestStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.RequestStatistics>
    {
        internal RequestStatistics() { }
        public int DocumentsCount { get { throw null; } }
        public int ErroneousDocumentsCount { get { throw null; } }
        public long TransactionsCount { get { throw null; } }
        public int ValidDocumentsCount { get { throw null; } }
        Azure.AI.Language.Text.Models.RequestStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.RequestStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.RequestStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.RequestStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.RequestStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.RequestStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.RequestStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptCode : System.IEquatable<Azure.AI.Language.Text.Models.ScriptCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptCode(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.ScriptCode Arab { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Armn { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Beng { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Cans { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Cyrl { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Deva { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Ethi { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Geor { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Grek { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Gujr { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Guru { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Hang { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Hans { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Hant { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Hebr { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Jpan { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Khmr { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Knda { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Laoo { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Latn { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Mlym { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Mymr { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Orya { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Sinh { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Taml { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Telu { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Thaa { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Thai { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptCode Tibt { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.ScriptCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.ScriptCode left, Azure.AI.Language.Text.Models.ScriptCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.ScriptCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.ScriptCode left, Azure.AI.Language.Text.Models.ScriptCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptKind : System.IEquatable<Azure.AI.Language.Text.Models.ScriptKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.ScriptKind Arabic { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Armenian { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Bangla { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Cyrillic { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Devanagari { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Ethiopic { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Georgian { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Greek { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Gujarati { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Gurmukhi { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Hangul { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind HanSimplified { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind HanTraditional { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Hebrew { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Japanese { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Kannada { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Khmer { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Lao { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Latin { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Malayalam { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Myanmar { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Odia { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Sinhala { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Tamil { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Telugu { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Thaana { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Thai { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind Tibetan { get { throw null; } }
        public static Azure.AI.Language.Text.Models.ScriptKind UnifiedCanadianAboriginalSyllabics { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.ScriptKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.ScriptKind left, Azure.AI.Language.Text.Models.ScriptKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.ScriptKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.ScriptKind left, Azure.AI.Language.Text.Models.ScriptKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SentenceAssessment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceAssessment>
    {
        internal SentenceAssessment() { }
        public Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel ConfidenceScores { get { throw null; } }
        public bool IsNegated { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.Language.Text.Models.TokenSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.SentenceAssessment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentenceAssessment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentenceSentiment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceSentiment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceSentiment>
    {
        internal SentenceSentiment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.SentenceAssessment> Assessments { get { throw null; } }
        public Azure.AI.Language.Text.Models.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.Language.Text.Models.SentenceSentimentValue Sentiment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.SentenceTarget> Targets { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.SentenceSentiment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceSentiment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceSentiment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentenceSentiment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceSentiment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceSentiment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceSentiment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SentenceSentimentValue
    {
        Positive = 0,
        Neutral = 1,
        Negative = 2,
    }
    public partial class SentenceTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceTarget>
    {
        internal SentenceTarget() { }
        public Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel ConfidenceScores { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.TargetRelation> Relations { get { throw null; } }
        public Azure.AI.Language.Text.Models.TokenSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Text.Models.SentenceTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentenceTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentenceTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentenceTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentAnalysisActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentAnalysisActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisActionContent>
    {
        public SentimentAnalysisActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public bool? OpinionMining { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.SentimentAnalysisActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentAnalysisActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentAnalysisActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentimentAnalysisActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentAnalysisOperationAction : Azure.AI.Language.Text.Models.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction>
    {
        public SentimentAnalysisOperationAction() { }
        public Azure.AI.Language.Text.Models.SentimentAnalysisActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentAnalysisOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentConfidenceScores : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentConfidenceScores>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentConfidenceScores>
    {
        internal SentimentConfidenceScores() { }
        public double Negative { get { throw null; } }
        public double Neutral { get { throw null; } }
        public double Positive { get { throw null; } }
        Azure.AI.Language.Text.Models.SentimentConfidenceScores System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentConfidenceScores>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentConfidenceScores>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentimentConfidenceScores System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentConfidenceScores>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentConfidenceScores>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentConfidenceScores>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentDocumentResultWithDetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage>
    {
        internal SentimentDocumentResultWithDetectedLanguage() { }
        public Azure.AI.Language.Text.Models.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public Azure.AI.Language.Text.Models.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.SentenceSentiment> Sentences { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentSentiment Sentiment { get { throw null; } }
        public Azure.AI.Language.Text.Models.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentOperationResult : Azure.AI.Language.Text.Models.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentOperationResult>
    {
        internal SentimentOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.Models.TextActionState)) { }
        public Azure.AI.Language.Text.Models.SentimentResult Results { get { throw null; } }
        Azure.AI.Language.Text.Models.SentimentOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentimentOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentResult>
    {
        internal SentimentResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.SentimentDocumentResultWithDetectedLanguage> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Text.Models.SentimentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SentimentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SentimentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SentimentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpeedMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SpeedMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SpeedMetadata>
    {
        internal SpeedMetadata() { }
        public Azure.AI.Language.Text.Models.SpeedUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.SpeedMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SpeedMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SpeedMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SpeedMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SpeedMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SpeedMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SpeedMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpeedUnit : System.IEquatable<Azure.AI.Language.Text.Models.SpeedUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpeedUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.SpeedUnit CentimetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit FeetPerMinute { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit FeetPerSecond { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit KilometersPerHour { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit KilometersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit KilometersPerMinute { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit KilometersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit Knots { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit MetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit MetersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit MilesPerHour { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit YardsPerMinute { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SpeedUnit YardsPerSecond { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.SpeedUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.SpeedUnit left, Azure.AI.Language.Text.Models.SpeedUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.SpeedUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.SpeedUnit left, Azure.AI.Language.Text.Models.SpeedUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Text.Models.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.Language.Text.Models.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.Language.Text.Models.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.StringIndexType left, Azure.AI.Language.Text.Models.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.StringIndexType left, Azure.AI.Language.Text.Models.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SummaryContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SummaryContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SummaryContext>
    {
        internal SummaryContext() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        Azure.AI.Language.Text.Models.SummaryContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SummaryContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.SummaryContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.SummaryContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SummaryContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SummaryContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.SummaryContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SummaryLengthBucket : System.IEquatable<Azure.AI.Language.Text.Models.SummaryLengthBucket>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SummaryLengthBucket(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.SummaryLengthBucket Long { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SummaryLengthBucket Medium { get { throw null; } }
        public static Azure.AI.Language.Text.Models.SummaryLengthBucket Short { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.SummaryLengthBucket other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.SummaryLengthBucket left, Azure.AI.Language.Text.Models.SummaryLengthBucket right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.SummaryLengthBucket (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.SummaryLengthBucket left, Azure.AI.Language.Text.Models.SummaryLengthBucket right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetConfidenceScoreLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel>
    {
        internal TargetConfidenceScoreLabel() { }
        public double Negative { get { throw null; } }
        public double Positive { get { throw null; } }
        Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetConfidenceScoreLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetRelation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TargetRelation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetRelation>
    {
        internal TargetRelation() { }
        public string Ref { get { throw null; } }
        public Azure.AI.Language.Text.Models.TargetRelationType RelationType { get { throw null; } }
        Azure.AI.Language.Text.Models.TargetRelation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TargetRelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TargetRelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TargetRelation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetRelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetRelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TargetRelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TargetRelationType
    {
        Assessment = 0,
        Target = 1,
    }
    public partial class TemperatureMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemperatureMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemperatureMetadata>
    {
        internal TemperatureMetadata() { }
        public Azure.AI.Language.Text.Models.TemperatureUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.TemperatureMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemperatureMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemperatureMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TemperatureMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemperatureMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemperatureMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemperatureMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemperatureUnit : System.IEquatable<Azure.AI.Language.Text.Models.TemperatureUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemperatureUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.TemperatureUnit Celsius { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemperatureUnit Fahrenheit { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemperatureUnit Kelvin { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemperatureUnit Rankine { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemperatureUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.TemperatureUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.TemperatureUnit left, Azure.AI.Language.Text.Models.TemperatureUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.TemperatureUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.TemperatureUnit left, Azure.AI.Language.Text.Models.TemperatureUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemporalModifier : System.IEquatable<Azure.AI.Language.Text.Models.TemporalModifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemporalModifier(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.TemporalModifier After { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier AfterApprox { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier AfterMid { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier AfterStart { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier Approx { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier Before { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier BeforeApprox { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier BeforeEnd { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier BeforeStart { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier End { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier Less { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier Mid { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier More { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier ReferenceUndefined { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier Since { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier SinceEnd { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier Start { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TemporalModifier Until { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.TemporalModifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.TemporalModifier left, Azure.AI.Language.Text.Models.TemporalModifier right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.TemporalModifier (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.TemporalModifier left, Azure.AI.Language.Text.Models.TemporalModifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemporalSetMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSetMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSetMetadata>
    {
        internal TemporalSetMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DateValue> Dates { get { throw null; } }
        Azure.AI.Language.Text.Models.TemporalSetMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSetMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSetMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TemporalSetMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSetMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSetMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSetMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemporalSpanMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSpanMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanMetadata>
    {
        internal TemporalSpanMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.TemporalSpanValues> SpanValues { get { throw null; } }
        Azure.AI.Language.Text.Models.TemporalSpanMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSpanMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSpanMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TemporalSpanMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemporalSpanValues : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSpanValues>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanValues>
    {
        internal TemporalSpanValues() { }
        public string Begin { get { throw null; } }
        public string Duration { get { throw null; } }
        public string End { get { throw null; } }
        public Azure.AI.Language.Text.Models.TemporalModifier? Modifier { get { throw null; } }
        public string Timex { get { throw null; } }
        Azure.AI.Language.Text.Models.TemporalSpanValues System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSpanValues>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TemporalSpanValues>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TemporalSpanValues System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanValues>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanValues>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TemporalSpanValues>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextActions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextActions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextActions>
    {
        internal TextActions() { }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.AnalyzeTextOperationResult> Items { get { throw null; } }
        public int Total { get { throw null; } }
        Azure.AI.Language.Text.Models.TextActions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextActions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextActions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextActions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextActions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextActions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextActions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextActionState : System.IEquatable<Azure.AI.Language.Text.Models.TextActionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextActionState(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.TextActionState Cancelled { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TextActionState Cancelling { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TextActionState Failed { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TextActionState NotStarted { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TextActionState PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TextActionState Running { get { throw null; } }
        public static Azure.AI.Language.Text.Models.TextActionState Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.TextActionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.TextActionState left, Azure.AI.Language.Text.Models.TextActionState right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.TextActionState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.TextActionState left, Azure.AI.Language.Text.Models.TextActionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextDynamicClassificationInput : Azure.AI.Language.Text.Models.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextDynamicClassificationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextDynamicClassificationInput>
    {
        public TextDynamicClassificationInput() { }
        public Azure.AI.Language.Text.Models.DynamicClassificationActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.TextDynamicClassificationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextDynamicClassificationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextDynamicClassificationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextDynamicClassificationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextDynamicClassificationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextDynamicClassificationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextDynamicClassificationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextEntityLinkingInput : Azure.AI.Language.Text.Models.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextEntityLinkingInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityLinkingInput>
    {
        public TextEntityLinkingInput() { }
        public Azure.AI.Language.Text.Models.EntityLinkingActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.TextEntityLinkingInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextEntityLinkingInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextEntityLinkingInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextEntityLinkingInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityLinkingInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityLinkingInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityLinkingInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextEntityRecognitionInput : Azure.AI.Language.Text.Models.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextEntityRecognitionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityRecognitionInput>
    {
        public TextEntityRecognitionInput() { }
        public Azure.AI.Language.Text.Models.EntitiesActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.TextEntityRecognitionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextEntityRecognitionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextEntityRecognitionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextEntityRecognitionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityRecognitionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityRecognitionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextEntityRecognitionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextKeyPhraseExtractionInput : Azure.AI.Language.Text.Models.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput>
    {
        public TextKeyPhraseExtractionInput() { }
        public Azure.AI.Language.Text.Models.KeyPhraseActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextKeyPhraseExtractionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextLanguageDetectionInput : Azure.AI.Language.Text.Models.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextLanguageDetectionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextLanguageDetectionInput>
    {
        public TextLanguageDetectionInput() { }
        public Azure.AI.Language.Text.Models.LanguageDetectionActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.LanguageDetectionTextInput TextInput { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.TextLanguageDetectionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextLanguageDetectionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextLanguageDetectionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextLanguageDetectionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextLanguageDetectionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextLanguageDetectionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextLanguageDetectionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextPiiEntitiesRecognitionInput : Azure.AI.Language.Text.Models.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput>
    {
        public TextPiiEntitiesRecognitionInput() { }
        public Azure.AI.Language.Text.Models.PiiActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextPiiEntitiesRecognitionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextSentimentAnalysisInput : Azure.AI.Language.Text.Models.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextSentimentAnalysisInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextSentimentAnalysisInput>
    {
        public TextSentimentAnalysisInput() { }
        public Azure.AI.Language.Text.Models.SentimentAnalysisActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.Models.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        Azure.AI.Language.Text.Models.TextSentimentAnalysisInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextSentimentAnalysisInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TextSentimentAnalysisInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TextSentimentAnalysisInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextSentimentAnalysisInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextSentimentAnalysisInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TextSentimentAnalysisInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimeMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TimeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TimeMetadata>
    {
        internal TimeMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Models.DateValue> Dates { get { throw null; } }
        Azure.AI.Language.Text.Models.TimeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TimeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.TimeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.TimeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TimeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TimeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.TimeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TokenSentiment
    {
        Positive = 0,
        Mixed = 1,
        Negative = 2,
    }
    public partial class VolumeMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.VolumeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.VolumeMetadata>
    {
        internal VolumeMetadata() { }
        public Azure.AI.Language.Text.Models.VolumeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.VolumeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.VolumeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.VolumeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.VolumeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.VolumeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.VolumeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.VolumeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeUnit : System.IEquatable<Azure.AI.Language.Text.Models.VolumeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.VolumeUnit Barrel { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Bushel { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Centiliter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Cord { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit CubicCentimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit CubicFoot { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit CubicInch { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit CubicMeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit CubicMile { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit CubicMillimeter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit CubicYard { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Cup { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Decaliter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit FluidDram { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit FluidOunce { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Gill { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Hectoliter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Hogshead { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Liter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Milliliter { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Minim { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Peck { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Pinch { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Pint { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Quart { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Tablespoon { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Teaspoon { get { throw null; } }
        public static Azure.AI.Language.Text.Models.VolumeUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.VolumeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.VolumeUnit left, Azure.AI.Language.Text.Models.VolumeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.VolumeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.VolumeUnit left, Azure.AI.Language.Text.Models.VolumeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WarningCode : System.IEquatable<Azure.AI.Language.Text.Models.WarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WarningCode(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.WarningCode DocumentTruncated { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WarningCode LongWordsInDocument { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.WarningCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.WarningCode left, Azure.AI.Language.Text.Models.WarningCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.WarningCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.WarningCode left, Azure.AI.Language.Text.Models.WarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeightMetadata : Azure.AI.Language.Text.Models.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.WeightMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.WeightMetadata>
    {
        internal WeightMetadata() { }
        public Azure.AI.Language.Text.Models.WeightUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        Azure.AI.Language.Text.Models.WeightMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.WeightMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Models.WeightMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Models.WeightMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.WeightMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.WeightMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Models.WeightMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightUnit : System.IEquatable<Azure.AI.Language.Text.Models.WeightUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.Models.WeightUnit Dram { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Gallon { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Grain { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Gram { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Kilogram { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit LongTonBritish { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit MetricTon { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Milligram { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Ounce { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit PennyWeight { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Pound { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit ShortHundredWeightUs { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit ShortTonUs { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Stone { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Ton { get { throw null; } }
        public static Azure.AI.Language.Text.Models.WeightUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Models.WeightUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Models.WeightUnit left, Azure.AI.Language.Text.Models.WeightUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Models.WeightUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Models.WeightUnit left, Azure.AI.Language.Text.Models.WeightUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AILanguageTextClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.TextAnalysisClient, Azure.AI.Language.Text.TextAnalysisClientOptions> AddTextAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.TextAnalysisClient, Azure.AI.Language.Text.TextAnalysisClientOptions> AddTextAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.TextAnalysisClient, Azure.AI.Language.Text.TextAnalysisClientOptions> AddTextAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
