namespace Azure.AI.Language.Conversations
{
    public partial class ConversationAnalysisClient
    {
        protected ConversationAnalysisClient() { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions options) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult> AnalyzeConversation(Azure.AI.Language.Conversations.Models.AnalyzeConversationInput analyzeConversationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeConversation(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>> AnalyzeConversationAsync(Azure.AI.Language.Conversations.Models.AnalyzeConversationInput analyzeConversationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeConversationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation AnalyzeConversationCancelOperation(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeConversationCancelOperationAsync(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState> AnalyzeConversationOperation(Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>> AnalyzeConversationOperationAsync(Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeConversationOperationStatus(System.Guid jobId, bool? showStats, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState> AnalyzeConversationOperationStatus(System.Guid jobId, bool? showStats = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeConversationOperationStatusAsync(System.Guid jobId, bool? showStats, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>> AnalyzeConversationOperationStatusAsync(System.Guid jobId, bool? showStats = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeConversationSubmitOperation(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeConversationSubmitOperation(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeConversationSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeConversationSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConversationAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public ConversationAnalysisClientOptions(Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion.V2024_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_01 = 1,
            V2023_04_01 = 2,
            V2024_05_01 = 3,
            V2024_05_15_Preview = 4,
        }
    }
}
namespace Azure.AI.Language.Conversations.Models
{
    public static partial class AILanguageConversationsModelFactory
    {
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult AnalyzeConversationConversationalResult(Azure.AI.Language.Conversations.Models.AnalyzeConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput AnalyzeConversationOperationInput(string displayName = null, Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput conversationInput = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction> actions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult AnalyzeConversationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, string kind = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState AnalyzeConversationOperationState(string displayName = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), System.Guid jobId = default(System.Guid), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationError> errors = null, string nextLink = null, Azure.AI.Language.Conversations.Models.ConversationActions actions = null, Azure.AI.Language.Conversations.Models.ConversationRequestStatistics statistics = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AudioTiming AudioTiming(long? offset = default(long?), long? duration = default(long?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationActionContent ConversationActionContent(string projectName = null, string deploymentName = null, bool? verbose = default(bool?), bool? isLoggingEnabled = default(bool?), Azure.AI.Language.Conversations.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Conversations.Models.StringIndexType?), string directTarget = null, System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.Models.AnalysisConfig> targetProjectParameters = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationActions ConversationActions(int completed = 0, int failed = 0, int inProgress = 0, int total = 0, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult> items = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalInput ConversationalInput(Azure.AI.Language.Conversations.Models.ConversationAnalysisInput conversationInput = null, Azure.AI.Language.Conversations.Models.ConversationActionContent actionContent = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase ConversationalPiiResultWithResultBase(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.InputWarning> warnings = null, Azure.AI.Language.Conversations.Models.ConversationStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult> conversationItems = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationError ConversationError(Azure.AI.Language.Conversations.Models.ConversationErrorCode code = default(Azure.AI.Language.Conversations.Models.ConversationErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationError> details = null, Azure.AI.Language.Conversations.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationInput ConversationInput(string id = null, string language = null, string modality = null, Azure.AI.Language.Conversations.Models.ConversationDomain? domain = default(Azure.AI.Language.Conversations.Models.ConversationDomain?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiItemResult ConversationPiiItemResult(string id = null, Azure.AI.Language.Conversations.Models.RedactedTranscriptContent redactedContent = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.NamedEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult ConversationPiiOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, Azure.AI.Language.Conversations.Models.ConversationPiiResults results = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiResults ConversationPiiResults(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DocumentError> errors = null, Azure.AI.Language.Conversations.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase> conversations = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationRequestStatistics ConversationRequestStatistics(int documentsCount = 0, int validDocumentsCount = 0, int erroneousDocumentsCount = 0, long transactionsCount = (long)0, int conversationsCount = 0, int validConversationsCount = 0, int erroneousConversationsCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationsSummaryResult ConversationsSummaryResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.InputWarning> warnings = null, Azure.AI.Language.Conversations.Models.ConversationStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.SummaryResultItem> summaries = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationStatistics ConversationStatistics(int transactionsCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent CustomConversationSummarizationActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null, int? sentenceCount = default(int?), Azure.AI.Language.Conversations.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Conversations.Models.StringIndexType?), Azure.AI.Language.Conversations.Models.SummaryLengthBucket? summaryLength = default(Azure.AI.Language.Conversations.Models.SummaryLengthBucket?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.SummaryAspect> summaryAspects = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult CustomSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, Azure.AI.Language.Conversations.Models.CustomSummaryResult results = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.CustomSummaryResult CustomSummaryResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult> conversations = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DocumentError> errors = null, Azure.AI.Language.Conversations.Models.RequestStatistics statistics = null, string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DocumentError DocumentError(string id = null, Azure.AI.Language.Conversations.Models.ConversationError error = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InnerErrorModel InnerErrorModel(Azure.AI.Language.Conversations.Models.InnerErrorCode code = default(Azure.AI.Language.Conversations.Models.InnerErrorCode), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> details = null, string target = null, Azure.AI.Language.Conversations.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InputWarning InputWarning(string code = null, string message = null, string targetRef = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ItemizedSummaryContext ItemizedSummaryContext(int offset = 0, int length = 0, string conversationItemId = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext KnowledgeBaseAnswerContext(int previousQnaId = 0, string previousQuestion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.NamedEntity NamedEntity(string text = null, string category = null, string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RedactedTranscriptContent RedactedTranscriptContent(string inverseTextNormalized = null, string maskedInverseTextNormalized = null, string text = null, string lexical = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.AudioTiming> audioTimings = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RequestStatistics RequestStatistics(int documentsCount = 0, int validDocumentsCount = 0, int erroneousDocumentsCount = 0, long transactionsCount = (long)0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummarizationOperationResult SummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, Azure.AI.Language.Conversations.Models.SummaryResult results = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummaryResult SummaryResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult> conversations = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DocumentError> errors = null, Azure.AI.Language.Conversations.Models.RequestStatistics statistics = null, string modelVersion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummaryResultItem SummaryResultItem(string aspect = null, string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext> contexts = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TextConversation TextConversation(string id = null, string language = null, Azure.AI.Language.Conversations.Models.ConversationDomain? domain = default(Azure.AI.Language.Conversations.Models.ConversationDomain?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TextConversationItem> conversationItems = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TextConversationItem TextConversationItem(string id = null, string participantId = null, string language = null, Azure.AI.Language.Conversations.Models.InputModality? modality = default(Azure.AI.Language.Conversations.Models.InputModality?), Azure.AI.Language.Conversations.Models.ParticipantRole? role = default(Azure.AI.Language.Conversations.Models.ParticipantRole?), string text = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TranscriptConversation TranscriptConversation(string id = null, string language = null, Azure.AI.Language.Conversations.Models.ConversationDomain? domain = default(Azure.AI.Language.Conversations.Models.ConversationDomain?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TranscriptConversationItem> conversationItems = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TranscriptConversationItem TranscriptConversationItem(string id = null, string participantId = null, string language = null, Azure.AI.Language.Conversations.Models.InputModality? modality = default(Azure.AI.Language.Conversations.Models.InputModality?), Azure.AI.Language.Conversations.Models.ParticipantRole? role = default(Azure.AI.Language.Conversations.Models.ParticipantRole?), string inverseTextNormalized = null, string maskedInverseTextNormalized = null, string text = null, string lexical = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.WordLevelTiming> wordLevelTimings = null, Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming conversationItemLevelTiming = null) { throw null; }
    }
    public abstract partial class AnalysisConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>
    {
        protected AnalysisConfig() { }
        public string ApiVersion { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.AnalysisConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalysisConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeConversationConversationalResult : Azure.AI.Language.Conversations.Models.AnalyzeConversationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult>
    {
        internal AnalyzeConversationConversationalResult() { }
        public Azure.AI.Language.Conversations.Models.AnalyzeConversationResult Result { get { throw null; } }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationConversationalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeConversationInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>
    {
        protected AnalyzeConversationInput() { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeConversationOperationAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction>
    {
        protected AnalyzeConversationOperationAction() { }
        public string Name { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeConversationOperationInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput>
    {
        public AnalyzeConversationOperationInput(Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput conversationInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction> actions) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction> Actions { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput ConversationInput { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeConversationOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult>
    {
        protected AnalyzeConversationOperationResult(System.DateTimeOffset lastUpdateDateTime, Azure.AI.Language.Conversations.Models.ConversationActionState status) { }
        public System.DateTimeOffset LastUpdateDateTime { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationActionState Status { get { throw null; } }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeConversationOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>
    {
        internal AnalyzeConversationOperationState() { }
        public Azure.AI.Language.Conversations.Models.ConversationActions Actions { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public System.Guid JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public string NextLink { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationRequestStatistics Statistics { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationActionState Status { get { throw null; } }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeConversationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>
    {
        protected AnalyzeConversationResult() { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioTiming : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AudioTiming>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>
    {
        internal AudioTiming() { }
        public long? Duration { get { throw null; } }
        public long? Offset { get { throw null; } }
        Azure.AI.Language.Conversations.Models.AudioTiming System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AudioTiming System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionContent>
    {
        public ConversationActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string DirectTarget { get { throw null; } set { } }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.Models.AnalysisConfig> TargetProjectParameters { get { throw null; } }
        public bool? Verbose { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.ConversationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationActions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActions>
    {
        internal ConversationActions() { }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult> Items { get { throw null; } }
        public int Total { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationActions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationActions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationActionState : System.IEquatable<Azure.AI.Language.Conversations.Models.ConversationActionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationActionState(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationActionState Cancelled { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationActionState Cancelling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationActionState Failed { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationActionState NotStarted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationActionState PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationActionState Running { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationActionState Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ConversationActionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ConversationActionState left, Azure.AI.Language.Conversations.Models.ConversationActionState right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ConversationActionState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ConversationActionState left, Azure.AI.Language.Conversations.Models.ConversationActionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationalInput : Azure.AI.Language.Conversations.Models.AnalyzeConversationInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalInput>
    {
        public ConversationalInput(Azure.AI.Language.Conversations.Models.ConversationAnalysisInput conversationInput, Azure.AI.Language.Conversations.Models.ConversationActionContent actionContent) { }
        public Azure.AI.Language.Conversations.Models.ConversationActionContent ActionContent { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationAnalysisInput ConversationInput { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationalInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalPiiResultWithResultBase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase>
    {
        internal ConversationalPiiResultWithResultBase() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult> ConversationItems { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.InputWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAnalysisInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>
    {
        public ConversationAnalysisInput(Azure.AI.Language.Conversations.Models.TextConversationItem conversationItem) { }
        public Azure.AI.Language.Conversations.Models.TextConversationItem ConversationItem { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationAnalysisInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationAnalysisInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationCallingConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationCallingConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationCallingConfig>
    {
        public ConversationCallingConfig() { }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.ConversationCallingConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationCallingConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationCallingConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationCallingConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationCallingConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationCallingConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationCallingConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationConfig : Azure.AI.Language.Conversations.Models.AnalysisConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationConfig>
    {
        public ConversationConfig() { }
        public Azure.AI.Language.Conversations.Models.ConversationCallingConfig CallingOptions { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.ConversationConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationDomain : System.IEquatable<Azure.AI.Language.Conversations.Models.ConversationDomain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationDomain(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationDomain Finance { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationDomain Generic { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationDomain Healthcare { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ConversationDomain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ConversationDomain left, Azure.AI.Language.Conversations.Models.ConversationDomain right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ConversationDomain (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ConversationDomain left, Azure.AI.Language.Conversations.Models.ConversationDomain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationError>
    {
        internal ConversationError() { }
        public Azure.AI.Language.Conversations.Models.ConversationErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationError> Details { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationErrorCode : System.IEquatable<Azure.AI.Language.Conversations.Models.ConversationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode AzureCognitiveSearchIndexLimitReached { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode AzureCognitiveSearchIndexNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode Conflict { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode Forbidden { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode NotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode OperationNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode ProjectNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode QuotaExceeded { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode Timeout { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode TooManyRequests { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode Unauthorized { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationErrorCode Warning { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ConversationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ConversationErrorCode left, Azure.AI.Language.Conversations.Models.ConversationErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ConversationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ConversationErrorCode left, Azure.AI.Language.Conversations.Models.ConversationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ConversationInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationInput>
    {
        protected ConversationInput(string id, string language) { }
        public Azure.AI.Language.Conversations.Models.ConversationDomain? Domain { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationItemLevelTiming : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>
    {
        public ConversationItemLevelTiming() { }
        public long? Duration { get { throw null; } set { } }
        public long? Offset { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationPiiActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiActionContent>
    {
        public ConversationPiiActionContent() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions> ExcludePiiCategories { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.ConversationPiiCategories> PiiCategories { get { throw null; } }
        public bool? RedactAudioTiming { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.RedactionCharacter? RedactionCharacter { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.TranscriptContentType? RedactionSource { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.ConversationPiiActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationPiiCategories : System.IEquatable<Azure.AI.Language.Conversations.Models.ConversationPiiCategories>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationPiiCategories(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Address { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories All { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Default { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Email { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Miscellaneous { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories NumericIdentifier { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Person { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories UsSocialSecurityNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ConversationPiiCategories other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ConversationPiiCategories left, Azure.AI.Language.Conversations.Models.ConversationPiiCategories right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ConversationPiiCategories (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ConversationPiiCategories left, Azure.AI.Language.Conversations.Models.ConversationPiiCategories right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationPiiCategoryExclusions : System.IEquatable<Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationPiiCategoryExclusions(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions Address { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions Email { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions NumericIdentifier { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions Person { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions UsSocialSecurityNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions left, Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions left, Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationPiiItemResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult>
    {
        internal ConversationPiiItemResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.NamedEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.RedactedTranscriptContent RedactedContent { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationPiiItemResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiItemResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationPiiOperationResult : Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>
    {
        internal ConversationPiiOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Conversations.Models.ConversationActionState)) { }
        public Azure.AI.Language.Conversations.Models.ConversationPiiResults Results { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationPiiResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>
    {
        internal ConversationPiiResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationalPiiResultWithResultBase> Conversations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationPiiResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationRequestStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>
    {
        internal ConversationRequestStatistics() { }
        public int ConversationsCount { get { throw null; } }
        public int DocumentsCount { get { throw null; } }
        public int ErroneousConversationsCount { get { throw null; } }
        public int ErroneousDocumentsCount { get { throw null; } }
        public long TransactionsCount { get { throw null; } }
        public int ValidConversationsCount { get { throw null; } }
        public int ValidDocumentsCount { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationRequestStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationRequestStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationsSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>
    {
        internal ConversationsSummaryResult() { }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.SummaryResultItem> Summaries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.InputWarning> Warnings { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationsSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationsSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>
    {
        internal ConversationStatistics() { }
        public int TransactionsCount { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ConversationStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>
    {
        public ConversationSummarizationActionContent(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.SummaryAspect> summaryAspects) { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public int? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.SummaryAspect> SummaryAspects { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.SummaryLengthBucket? SummaryLength { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomConversationSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent>
    {
        public CustomConversationSummarizationActionContent(string projectName, string deploymentName, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.SummaryAspect> summaryAspects) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public int? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.SummaryAspect> SummaryAspects { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.SummaryLengthBucket? SummaryLength { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSummarizationOperationAction : Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction>
    {
        public CustomSummarizationOperationAction() { }
        public Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSummarizationOperationResult : Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult>
    {
        internal CustomSummarizationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Conversations.Models.ConversationActionState)) { }
        public Azure.AI.Language.Conversations.Models.CustomSummaryResult Results { get { throw null; } }
        Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>
    {
        internal CustomSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult> Conversations { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Conversations.Models.CustomSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CustomSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DocumentError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>
    {
        internal DocumentError() { }
        public Azure.AI.Language.Conversations.Models.ConversationError Error { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.AI.Language.Conversations.Models.DocumentError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DocumentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DocumentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.DocumentError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InnerErrorCode : System.IEquatable<Azure.AI.Language.Conversations.Models.InnerErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InnerErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode EmptyRequest { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode ExtractionFailure { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode InvalidCountryHint { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode InvalidDocument { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode InvalidDocumentBatch { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode InvalidParameterValue { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode InvalidRequestBodyFormat { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode KnowledgeBaseNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode MissingInputDocuments { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode ModelVersionIncorrect { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InnerErrorCode UnsupportedLanguageCode { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.InnerErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.InnerErrorCode left, Azure.AI.Language.Conversations.Models.InnerErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.InnerErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.InnerErrorCode left, Azure.AI.Language.Conversations.Models.InnerErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InnerErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InnerErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InnerErrorModel>
    {
        internal InnerErrorModel() { }
        public Azure.AI.Language.Conversations.Models.InnerErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Details { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.AI.Language.Conversations.Models.InnerErrorModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InnerErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InnerErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.InnerErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InnerErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InnerErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InnerErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputModality : System.IEquatable<Azure.AI.Language.Conversations.Models.InputModality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputModality(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InputModality Text { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InputModality Transcript { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.InputModality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.InputModality left, Azure.AI.Language.Conversations.Models.InputModality right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.InputModality (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.InputModality left, Azure.AI.Language.Conversations.Models.InputModality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InputWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InputWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InputWarning>
    {
        internal InputWarning() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string TargetRef { get { throw null; } }
        Azure.AI.Language.Conversations.Models.InputWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InputWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InputWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.InputWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InputWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InputWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InputWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemizedSummaryContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>
    {
        internal ItemizedSummaryContext() { }
        public string ConversationItemId { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        Azure.AI.Language.Conversations.Models.ItemizedSummaryContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ItemizedSummaryContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>
    {
        public KnowledgeBaseAnswerContext(int previousQnaId) { }
        public int PreviousQnaId { get { throw null; } }
        public string PreviousQuestion { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicalOperationKind : System.IEquatable<Azure.AI.Language.Conversations.Models.LogicalOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicalOperationKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.LogicalOperationKind And { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LogicalOperationKind Or { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.LogicalOperationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.LogicalOperationKind left, Azure.AI.Language.Conversations.Models.LogicalOperationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.LogicalOperationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.LogicalOperationKind left, Azure.AI.Language.Conversations.Models.LogicalOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LuisCallingConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisCallingConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisCallingConfig>
    {
        public LuisCallingConfig() { }
        public string BingSpellCheckSubscriptionKey { get { throw null; } set { } }
        public bool? Log { get { throw null; } set { } }
        public bool? ShowAllIntents { get { throw null; } set { } }
        public bool? SpellCheck { get { throw null; } set { } }
        public int? TimezoneOffset { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.LuisCallingConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisCallingConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisCallingConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisCallingConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisCallingConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisCallingConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisCallingConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LuisConfig : Azure.AI.Language.Conversations.Models.AnalysisConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisConfig>
    {
        public LuisConfig() { }
        public Azure.AI.Language.Conversations.Models.LuisCallingConfig CallingOptions { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.LuisConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MetadataFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataFilter>
    {
        public MetadataFilter() { }
        public Azure.AI.Language.Conversations.Models.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.MetadataRecord> Metadata { get { throw null; } }
        Azure.AI.Language.Conversations.Models.MetadataFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MetadataFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MetadataFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.MetadataFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MetadataRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataRecord>
    {
        public MetadataRecord(string key, string value) { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.AI.Language.Conversations.Models.MetadataRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MetadataRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MetadataRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.MetadataRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLanguageConversationInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput>
    {
        public MultiLanguageConversationInput(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationInput> conversations) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.ConversationInput> Conversations { get { throw null; } }
        Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NamedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NamedEntity>
    {
        internal NamedEntity() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Conversations.Models.NamedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NamedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NamedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParticipantRole : System.IEquatable<Azure.AI.Language.Conversations.Models.ParticipantRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParticipantRole(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ParticipantRole Agent { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ParticipantRole Customer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ParticipantRole Generic { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ParticipantRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ParticipantRole left, Azure.AI.Language.Conversations.Models.ParticipantRole right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ParticipantRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ParticipantRole left, Azure.AI.Language.Conversations.Models.ParticipantRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PiiOperationAction : Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>
    {
        public PiiOperationAction() { }
        public Azure.AI.Language.Conversations.Models.ConversationPiiActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.PiiOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.PiiOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryFilters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QueryFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QueryFilters>
    {
        public QueryFilters() { }
        public Azure.AI.Language.Conversations.Models.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.MetadataFilter MetadataFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFilter { get { throw null; } }
        Azure.AI.Language.Conversations.Models.QueryFilters System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QueryFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QueryFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QueryFilters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QueryFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QueryFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QueryFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringConfig : Azure.AI.Language.Conversations.Models.AnalysisConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>
    {
        public QuestionAnsweringConfig() { }
        public Azure.AI.Language.Conversations.Models.QuestionAnswersConfig CallingOptions { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnswersConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>
    {
        public QuestionAnswersConfig() { }
        public Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext AnswerContext { get { throw null; } set { } }
        public double? ConfidenceThreshold { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.QueryFilters Filters { get { throw null; } set { } }
        public bool? IncludeUnstructuredSources { get { throw null; } set { } }
        public int? QnaId { get { throw null; } set { } }
        public string Question { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.RankerKind? RankerKind { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.ShortAnswerConfig ShortAnswerOptions { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.QuestionAnswersConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnswersConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RankerKind : System.IEquatable<Azure.AI.Language.Conversations.Models.RankerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RankerKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RankerKind Default { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RankerKind QuestionOnly { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.RankerKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.RankerKind left, Azure.AI.Language.Conversations.Models.RankerKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.RankerKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.RankerKind left, Azure.AI.Language.Conversations.Models.RankerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedactedTranscriptContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RedactedTranscriptContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RedactedTranscriptContent>
    {
        internal RedactedTranscriptContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.AudioTiming> AudioTimings { get { throw null; } }
        public string InverseTextNormalized { get { throw null; } }
        public string Lexical { get { throw null; } }
        public string MaskedInverseTextNormalized { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Conversations.Models.RedactedTranscriptContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RedactedTranscriptContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RedactedTranscriptContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.RedactedTranscriptContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RedactedTranscriptContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RedactedTranscriptContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RedactedTranscriptContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedactionCharacter : System.IEquatable<Azure.AI.Language.Conversations.Models.RedactionCharacter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedactionCharacter(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Ampersand { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Asterisk { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter AtSign { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Caret { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Dollar { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter EqualsValue { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter ExclamationPoint { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Minus { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter NumberSign { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Percent { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Plus { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter QuestionMark { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Tilde { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RedactionCharacter Underscore { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.RedactionCharacter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.RedactionCharacter left, Azure.AI.Language.Conversations.Models.RedactionCharacter right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.RedactionCharacter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.RedactionCharacter left, Azure.AI.Language.Conversations.Models.RedactionCharacter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RequestStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>
    {
        internal RequestStatistics() { }
        public int DocumentsCount { get { throw null; } }
        public int ErroneousDocumentsCount { get { throw null; } }
        public long TransactionsCount { get { throw null; } }
        public int ValidDocumentsCount { get { throw null; } }
        Azure.AI.Language.Conversations.Models.RequestStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.RequestStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShortAnswerConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>
    {
        public ShortAnswerConfig() { }
        public double? ConfidenceThreshold { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.ShortAnswerConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ShortAnswerConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Conversations.Models.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.StringIndexType left, Azure.AI.Language.Conversations.Models.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.StringIndexType left, Azure.AI.Language.Conversations.Models.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SummarizationOperationAction : Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummarizationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationAction>
    {
        public SummarizationOperationAction() { }
        public Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent ActionContent { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.SummarizationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummarizationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummarizationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SummarizationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SummarizationOperationResult : Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationResult>
    {
        internal SummarizationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Conversations.Models.ConversationActionState)) { }
        public Azure.AI.Language.Conversations.Models.SummaryResult Results { get { throw null; } }
        Azure.AI.Language.Conversations.Models.SummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SummaryAspect : System.IEquatable<Azure.AI.Language.Conversations.Models.SummaryAspect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SummaryAspect(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummaryAspect ChapterTitle { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SummaryAspect FollowUpTasks { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SummaryAspect Issue { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SummaryAspect Narrative { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SummaryAspect Recap { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SummaryAspect Resolution { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.SummaryAspect other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.SummaryAspect left, Azure.AI.Language.Conversations.Models.SummaryAspect right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.SummaryAspect (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.SummaryAspect left, Azure.AI.Language.Conversations.Models.SummaryAspect right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SummaryLengthBucket : System.IEquatable<Azure.AI.Language.Conversations.Models.SummaryLengthBucket>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SummaryLengthBucket(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummaryLengthBucket Long { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SummaryLengthBucket Medium { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SummaryLengthBucket Short { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.SummaryLengthBucket other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.SummaryLengthBucket left, Azure.AI.Language.Conversations.Models.SummaryLengthBucket right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.SummaryLengthBucket (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.SummaryLengthBucket left, Azure.AI.Language.Conversations.Models.SummaryLengthBucket right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResult>
    {
        internal SummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult> Conversations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.RequestStatistics Statistics { get { throw null; } }
        Azure.AI.Language.Conversations.Models.SummaryResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SummaryResultItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>
    {
        internal SummaryResultItem() { }
        public string Aspect { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext> Contexts { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Conversations.Models.SummaryResultItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SummaryResultItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextConversation : Azure.AI.Language.Conversations.Models.ConversationInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TextConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversation>
    {
        public TextConversation(string id, string language, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TextConversationItem> conversationItems) : base (default(string), default(string)) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.TextConversationItem> ConversationItems { get { throw null; } }
        Azure.AI.Language.Conversations.Models.TextConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TextConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TextConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TextConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextConversationItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TextConversationItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversationItem>
    {
        public TextConversationItem(string id, string participantId, string text) { }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.InputModality? Modality { get { throw null; } set { } }
        public string ParticipantId { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ParticipantRole? Role { get { throw null; } set { } }
        public string Text { get { throw null; } }
        Azure.AI.Language.Conversations.Models.TextConversationItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TextConversationItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TextConversationItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TextConversationItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversationItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversationItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversationItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranscriptContentType : System.IEquatable<Azure.AI.Language.Conversations.Models.TranscriptContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranscriptContentType(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TranscriptContentType Itn { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TranscriptContentType Lexical { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TranscriptContentType MaskedItn { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TranscriptContentType Text { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.TranscriptContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.TranscriptContentType left, Azure.AI.Language.Conversations.Models.TranscriptContentType right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.TranscriptContentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.TranscriptContentType left, Azure.AI.Language.Conversations.Models.TranscriptContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranscriptConversation : Azure.AI.Language.Conversations.Models.ConversationInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversation>
    {
        public TranscriptConversation(string id, string language, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TranscriptConversationItem> conversationItems) : base (default(string), default(string)) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.TranscriptConversationItem> ConversationItems { get { throw null; } }
        Azure.AI.Language.Conversations.Models.TranscriptConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TranscriptConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptConversationItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>
    {
        public TranscriptConversationItem(string id, string participantId, string inverseTextNormalized, string maskedInverseTextNormalized, string text, string lexical) { }
        public Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming ConversationItemLevelTiming { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string InverseTextNormalized { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Lexical { get { throw null; } }
        public string MaskedInverseTextNormalized { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.InputModality? Modality { get { throw null; } set { } }
        public string ParticipantId { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ParticipantRole? Role { get { throw null; } set { } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.WordLevelTiming> WordLevelTimings { get { throw null; } }
        Azure.AI.Language.Conversations.Models.TranscriptConversationItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TranscriptConversationItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WordLevelTiming : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>
    {
        public WordLevelTiming() { }
        public long? Duration { get { throw null; } set { } }
        public long? Offset { get { throw null; } set { } }
        public string Word { get { throw null; } set { } }
        Azure.AI.Language.Conversations.Models.WordLevelTiming System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.WordLevelTiming System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AILanguageConversationsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
