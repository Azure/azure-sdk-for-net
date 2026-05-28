namespace Azure.AI.Language.Conversations
{
    public partial class AzureAILanguageConversationsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageConversationsContext() { }
        public static Azure.AI.Language.Conversations.AzureAILanguageConversationsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConversationAnalysisClient
    {
        protected ConversationAnalysisClient() { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult> AnalyzeConversation(Azure.AI.Language.Conversations.Models.AnalyzeConversationInput analyzeConversationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeConversation(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>> AnalyzeConversationAsync(Azure.AI.Language.Conversations.Models.AnalyzeConversationInput analyzeConversationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeConversationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState> AnalyzeConversations(Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> AnalyzeConversations(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>> AnalyzeConversationsAsync(Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeConversationsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation AnalyzeConversationSubmitOperation(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeConversationSubmitOperation(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeConversationSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput analyzeConversationOperationInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeConversationSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CancelAnalyzeConversations(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CancelAnalyzeConversationsAsync(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAnalyzeConversationJobStatus(System.Guid jobId, bool? showStatistics, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState> GetAnalyzeConversationJobStatus(System.Guid jobId, bool? showStatistics = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnalyzeConversationJobStatusAsync(System.Guid jobId, bool? showStatistics, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>> GetAnalyzeConversationJobStatusAsync(System.Guid jobId, bool? showStatistics = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationsClientOptions : Azure.Core.ClientOptions
    {
        public ConversationsClientOptions(Azure.AI.Language.Conversations.ConversationsClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationsClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_01 = 1,
            V2023_04_01 = 2,
            V2024_05_01 = 3,
            V2024_11_01 = 4,
            V2024_11_15_Preview = 5,
            V2025_05_15_Preview = 6,
        }
    }
    public static partial class ConversationsModelFactory
    {
        public static Azure.AI.Language.Conversations.Models.AgeResolution AgeResolution(double value = 0, Azure.AI.Language.Conversations.Models.AgeUnit unit = default(Azure.AI.Language.Conversations.Models.AgeUnit)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent AIConversationLanguageUnderstandingActionContent(string projectName = null, string deploymentName = null, Azure.AI.Language.Conversations.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Conversations.Models.StringIndexType?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationInput AnalyzeConversationOperationInput(string displayName = null, Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput conversationInput = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationAction> actions = null, float? cancelAfter = default(float?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult AnalyzeConversationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, string kind = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState AnalyzeConversationOperationState(string displayName = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), System.Guid jobId = default(System.Guid), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationError> errors = null, string nextLink = null, Azure.AI.Language.Conversations.Models.ConversationActions actions = null, Azure.AI.Language.Conversations.Models.ConversationRequestStatistics statistics = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationResult AnalyzeConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.Models.PredictionBase prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnswerSpan AnswerSpan(string text = null, double? confidenceScore = default(double?), int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnswersResult AnswersResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AreaResolution AreaResolution(double value = 0, Azure.AI.Language.Conversations.Models.AreaUnit unit = default(Azure.AI.Language.Conversations.Models.AreaUnit)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AudioTiming AudioTiming(long? offset = default(long?), long? duration = default(long?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.BooleanResolution BooleanResolution(bool value = false) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationActionResult ConversationActionResult(Azure.AI.Language.Conversations.Models.AnalyzeConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationActions ConversationActions(int completed = 0, int failed = 0, int inProgress = 0, int total = 0, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult> items = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis ConversationalAIAnalysis(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationalAIIntent> intents = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationalAIEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalAIEntity ConversationalAIEntity(string name = null, string text = null, float confidenceScore = 0f, int offset = 0, int length = 0, string conversationItemId = null, int? conversationItemIndex = default(int?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ResolutionBase> resolutions = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation> extraInformation = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalAIIntent ConversationalAIIntent(string name = null, string type = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationItemRange> conversationItemRanges = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationalAIEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalAIResult ConversationalAIResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis> conversations = null, System.Collections.Generic.IEnumerable<string> warnings = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalAITask ConversationalAITask(Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput analysisInput = null, Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent parameters = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalAITaskResult ConversationalAITaskResult(Azure.AI.Language.Conversations.Models.ConversationalAIResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationalPiiResult ConversationalPiiResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.InputWarning> warnings = null, Azure.AI.Language.Conversations.Models.ConversationStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult> conversationItems = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationEntity ConversationEntity(string category = null, string text = null, int offset = 0, int length = 0, float confidence = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ResolutionBase> resolutions = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation> extraInformation = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationError ConversationError(Azure.AI.Language.Conversations.Models.ConversationErrorCode code = default(Azure.AI.Language.Conversations.Models.ConversationErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationError> details = null, Azure.AI.Language.Conversations.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationInput ConversationInput(string id = null, string language = null, string modality = null, Azure.AI.Language.Conversations.Models.ConversationDomain? domain = default(Azure.AI.Language.Conversations.Models.ConversationDomain?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationIntent ConversationIntent(string category = null, float confidence = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationItemRange ConversationItemRange(int offset = 0, int count = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent ConversationLanguageUnderstandingActionContent(string projectName = null, string deploymentName = null, bool? verbose = default(bool?), bool? isLoggingEnabled = default(bool?), Azure.AI.Language.Conversations.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Conversations.Models.StringIndexType?), string directTarget = null, System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.Models.AnalysisConfig> targetProjectParameters = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput ConversationLanguageUnderstandingInput(Azure.AI.Language.Conversations.Models.ConversationAnalysisInput conversationInput = null, Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent actionContent = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiItemResult ConversationPiiItemResult(string id = null, Azure.AI.Language.Conversations.Models.RedactedTranscriptContent redactedContent = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.NamedEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult ConversationPiiOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, Azure.AI.Language.Conversations.Models.ConversationPiiResults results = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiResults ConversationPiiResults(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DocumentError> errors = null, Azure.AI.Language.Conversations.Models.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationalPiiResult> conversations = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPrediction ConversationPrediction(string topIntent = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationIntent> intents = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationRequestStatistics ConversationRequestStatistics(int documentsCount = 0, int validDocumentsCount = 0, int erroneousDocumentsCount = 0, long transactionsCount = (long)0, int conversationsCount = 0, int validConversationsCount = 0, int erroneousConversationsCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationResult ConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.Models.ConversationPrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationsSummaryResult ConversationsSummaryResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.InputWarning> warnings = null, Azure.AI.Language.Conversations.Models.ConversationStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.SummaryResultItem> summaries = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationStatistics ConversationStatistics(int transactionsCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult ConversationTargetIntentResult(string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.Models.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.CurrencyResolution CurrencyResolution(string iso4217 = null, double value = 0, string unit = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.CustomConversationSummarizationActionContent CustomConversationSummarizationActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null, int? sentenceCount = default(int?), Azure.AI.Language.Conversations.Models.StringIndexType? stringIndexType = default(Azure.AI.Language.Conversations.Models.StringIndexType?), Azure.AI.Language.Conversations.Models.SummaryLengthBucket? summaryLength = default(Azure.AI.Language.Conversations.Models.SummaryLengthBucket?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.SummaryAspect> summaryAspects = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.CustomSummarizationOperationResult CustomSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, Azure.AI.Language.Conversations.Models.CustomSummaryResult results = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.CustomSummaryResult CustomSummaryResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult> conversations = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DocumentError> errors = null, Azure.AI.Language.Conversations.Models.RequestStatistics statistics = null, string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DateTimeResolution DateTimeResolution(string timex = null, Azure.AI.Language.Conversations.Models.DateTimeSubKind dateTimeSubKind = default(Azure.AI.Language.Conversations.Models.DateTimeSubKind), string value = null, Azure.AI.Language.Conversations.Models.TemporalModifier? modifier = default(Azure.AI.Language.Conversations.Models.TemporalModifier?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DocumentError DocumentError(string id = null, Azure.AI.Language.Conversations.Models.ConversationError error = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.EntitySubtype EntitySubtype(string value = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.EntityTag> tags = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.EntityTag EntityTag(string name = null, double? confidenceScore = default(double?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InformationResolution InformationResolution(double value = 0, Azure.AI.Language.Conversations.Models.InformationUnit unit = default(Azure.AI.Language.Conversations.Models.InformationUnit)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InnerErrorModel InnerErrorModel(Azure.AI.Language.Conversations.Models.InnerErrorCode code = default(Azure.AI.Language.Conversations.Models.InnerErrorCode), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> details = null, string target = null, Azure.AI.Language.Conversations.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InputWarning InputWarning(string code = null, string message = null, string targetRef = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ItemizedSummaryContext ItemizedSummaryContext(int offset = 0, int length = 0, string conversationItemId = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer KnowledgeBaseAnswer(System.Collections.Generic.IEnumerable<string> questions = null, string answer = null, double? confidence = default(double?), int? qnaId = default(int?), string source = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog dialog = null, Azure.AI.Language.Conversations.Models.AnswerSpan shortAnswer = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext KnowledgeBaseAnswerContext(int previousQnaId = 0, string previousQuestion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), string displayText = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.LengthResolution LengthResolution(double value = 0, Azure.AI.Language.Conversations.Models.LengthUnit unit = default(Azure.AI.Language.Conversations.Models.LengthUnit)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ListKey ListKey(string key = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.LuisResult LuisResult(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.LuisTargetIntentResult LuisTargetIntentResult(string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.Models.LuisResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.NamedEntity NamedEntity(string text = null, string category = null, string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0, string mask = null, int? maskOffset = default(int?), int? maskLength = default(int?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult NoneLinkedTargetIntentResult(string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.Models.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.NumberResolution NumberResolution(Azure.AI.Language.Conversations.Models.NumberKind numberKind = default(Azure.AI.Language.Conversations.Models.NumberKind), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.NumericRangeResolution NumericRangeResolution(Azure.AI.Language.Conversations.Models.RangeKind rangeKind = default(Azure.AI.Language.Conversations.Models.RangeKind), double minimum = 0, double maximum = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.OrchestrationPrediction OrchestrationPrediction(string topIntent = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Models.TargetIntentResult> intents = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.OrdinalResolution OrdinalResolution(string offset = null, Azure.AI.Language.Conversations.Models.RelativeTo relativeTo = default(Azure.AI.Language.Conversations.Models.RelativeTo), string value = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.PredictionBase PredictionBase(string projectKind = null, string topIntent = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult QuestionAnsweringTargetIntentResult(string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.Models.AnswersResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RedactedTranscriptContent RedactedTranscriptContent(string inverseTextNormalized = null, string maskedInverseTextNormalized = null, string text = null, string lexical = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.AudioTiming> audioTimings = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RegexKey RegexKey(string key = null, string regexPattern = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RequestStatistics RequestStatistics(int documentsCount = 0, int validDocumentsCount = 0, int erroneousDocumentsCount = 0, long transactionsCount = (long)0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SpeedResolution SpeedResolution(double value = 0, Azure.AI.Language.Conversations.Models.SpeedUnit unit = default(Azure.AI.Language.Conversations.Models.SpeedUnit)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummarizationOperationResult SummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Conversations.Models.ConversationActionState status = default(Azure.AI.Language.Conversations.Models.ConversationActionState), string name = null, Azure.AI.Language.Conversations.Models.SummaryResult results = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummaryResult SummaryResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult> conversations = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DocumentError> errors = null, Azure.AI.Language.Conversations.Models.RequestStatistics statistics = null, string modelVersion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SummaryResultItem SummaryResultItem(string aspect = null, string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext> contexts = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TargetIntentResult TargetIntentResult(string targetProjectKind = null, string apiVersion = null, double confidence = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TemperatureResolution TemperatureResolution(double value = 0, Azure.AI.Language.Conversations.Models.TemperatureUnit unit = default(Azure.AI.Language.Conversations.Models.TemperatureUnit)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TemporalSpanResolution TemporalSpanResolution(string begin = null, string end = null, string duration = null, Azure.AI.Language.Conversations.Models.TemporalModifier? modifier = default(Azure.AI.Language.Conversations.Models.TemporalModifier?), string timex = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TextConversation TextConversation(string id = null, string language = null, Azure.AI.Language.Conversations.Models.ConversationDomain? domain = default(Azure.AI.Language.Conversations.Models.ConversationDomain?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TextConversationItem> conversationItems = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TextConversationItem TextConversationItem(string id = null, string participantId = null, string language = null, Azure.AI.Language.Conversations.Models.InputModality? modality = default(Azure.AI.Language.Conversations.Models.InputModality?), Azure.AI.Language.Conversations.Models.ParticipantRole? role = default(Azure.AI.Language.Conversations.Models.ParticipantRole?), string text = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TranscriptConversation TranscriptConversation(string id = null, string language = null, Azure.AI.Language.Conversations.Models.ConversationDomain? domain = default(Azure.AI.Language.Conversations.Models.ConversationDomain?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TranscriptConversationItem> conversationItems = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TranscriptConversationItem TranscriptConversationItem(string id = null, string participantId = null, string language = null, Azure.AI.Language.Conversations.Models.InputModality? modality = default(Azure.AI.Language.Conversations.Models.InputModality?), Azure.AI.Language.Conversations.Models.ParticipantRole? role = default(Azure.AI.Language.Conversations.Models.ParticipantRole?), string inverseTextNormalized = null, string maskedInverseTextNormalized = null, string text = null, string lexical = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.WordLevelTiming> wordLevelTimings = null, Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming conversationItemLevelTiming = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.VolumeResolution VolumeResolution(double value = 0, Azure.AI.Language.Conversations.Models.VolumeUnit unit = default(Azure.AI.Language.Conversations.Models.VolumeUnit)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.WeightResolution WeightResolution(double value = 0, Azure.AI.Language.Conversations.Models.WeightUnit unit = default(Azure.AI.Language.Conversations.Models.WeightUnit)) { throw null; }
    }
}
namespace Azure.AI.Language.Conversations.Authoring
{
    [System.ObsoleteAttribute("This class is obsolete and and will be removed in a future release. Find more details here: https://aka.ms/language-conversations-sdk", true)]
    public partial class ConversationAuthoringClient
    {
        protected ConversationAuthoringClient() { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteDeployment(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteProject(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Operation<System.BinaryData> ExportProject(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ExportProject(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string assetKind = null, string stringIndexType = "Utf16CodeUnit", string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ExportProjectAsync(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ExportProjectAsync(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string assetKind = null, string stringIndexType = "Utf16CodeUnit", string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentJobStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentJobStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetExportProjectJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportProjectJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetImportProjectJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportProjectJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLoadSnapshotJobStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotJobStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProjectDeletionJobStatus(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionJobStatusAsync(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(string language = null, bool? multilingual = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(string language = null, bool? multilingual = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrainingJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ImportProject(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Azure.AI.Language.Conversations.Models
{
    public partial class AgeResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AgeResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AgeResolution>
    {
        internal AgeResolution() { }
        public Azure.AI.Language.Conversations.Models.AgeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AgeResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AgeResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AgeResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AgeResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AgeResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AgeResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AgeResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgeUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.AgeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgeUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AgeUnit Day { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AgeUnit Month { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AgeUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AgeUnit Week { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AgeUnit Year { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.AgeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.AgeUnit left, Azure.AI.Language.Conversations.Models.AgeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.AgeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.AgeUnit left, Azure.AI.Language.Conversations.Models.AgeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AIConversationLanguageUnderstandingActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent>
    {
        public AIConversationLanguageUnderstandingActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalysisConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>
    {
        protected AnalysisConfig() { }
        public string ApiVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalysisConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalysisConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalysisConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeConversationActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>
    {
        protected AnalyzeConversationActionResult() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeConversationInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationInput>
    {
        protected AnalyzeConversationInput() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public float? CancelAfter { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.MultiLanguageConversationInput ConversationInput { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeConversationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>
    {
        internal AnalyzeConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.PredictionBase Prediction { get { throw null; } }
        public string Query { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnalyzeConversationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswerSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnswerSpan>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswerSpan>
    {
        internal AnswerSpan() { }
        public double? ConfidenceScore { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnswerSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnswerSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnswerSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnswerSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswerSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswerSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswerSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswersResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnswersResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswersResult>
    {
        internal AnswersResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer> Answers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnswersResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnswersResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AnswersResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AnswersResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswersResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswersResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AnswersResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AreaResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AreaResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AreaResolution>
    {
        internal AreaResolution() { }
        public Azure.AI.Language.Conversations.Models.AreaUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AreaResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AreaResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AreaResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AreaResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AreaResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AreaResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AreaResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AreaUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.AreaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AreaUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AreaUnit Acre { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareCentimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareDecameter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareDecimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareFoot { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareHectometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareInch { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareKilometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareMeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareMile { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareMillimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit SquareYard { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.AreaUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.AreaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.AreaUnit left, Azure.AI.Language.Conversations.Models.AreaUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.AreaUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.AreaUnit left, Azure.AI.Language.Conversations.Models.AreaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioTiming : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AudioTiming>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>
    {
        internal AudioTiming() { }
        public long? Duration { get { throw null; } }
        public long? Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AudioTiming System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.AudioTiming System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.AudioTiming>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BaseRedactionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.BaseRedactionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BaseRedactionPolicy>
    {
        protected BaseRedactionPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.BaseRedactionPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.BaseRedactionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.BaseRedactionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.BaseRedactionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BaseRedactionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BaseRedactionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BaseRedactionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BooleanResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.BooleanResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BooleanResolution>
    {
        internal BooleanResolution() { }
        public bool Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.BooleanResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.BooleanResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.BooleanResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.BooleanResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BooleanResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BooleanResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.BooleanResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CharacterMaskPolicyType : Azure.AI.Language.Conversations.Models.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType>
    {
        public CharacterMaskPolicyType() { }
        public Azure.AI.Language.Conversations.Models.RedactionCharacter? RedactionCharacter { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CharacterMaskPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationActionResult : Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionResult>
    {
        internal ConversationActionResult() { }
        public Azure.AI.Language.Conversations.Models.AnalyzeConversationResult Result { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationActions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationActions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationActions>
    {
        internal ConversationActions() { }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.AnalyzeConversationOperationResult> Items { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ConversationalAIAnalysis : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis>
    {
        internal ConversationalAIAnalysis() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationalAIEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationalAIIntent> Intents { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalAIAnalysisInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput>
    {
        public ConversationalAIAnalysisInput(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TextConversation> conversations) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.TextConversation> Conversations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalAIEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIEntity>
    {
        internal ConversationalAIEntity() { }
        public float ConfidenceScore { get { throw null; } }
        public string ConversationItemId { get { throw null; } }
        public int? ConversationItemIndex { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation> ExtraInformation { get { throw null; } }
        public int Length { get { throw null; } }
        public string Name { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ResolutionBase> Resolutions { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalAIIntent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIIntent>
    {
        internal ConversationalAIIntent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationItemRange> ConversationItemRanges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationalAIEntity> Entities { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalAIResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIResult>
    {
        internal ConversationalAIResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationalAIAnalysis> Conversations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAIResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAIResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAIResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalAITask : Azure.AI.Language.Conversations.Models.AnalyzeConversationInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAITask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITask>
    {
        public ConversationalAITask(Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput analysisInput, Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent parameters) { }
        public Azure.AI.Language.Conversations.Models.ConversationalAIAnalysisInput AnalysisInput { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.AIConversationLanguageUnderstandingActionContent Parameters { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAITask System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAITask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAITask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAITask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalAITaskResult : Azure.AI.Language.Conversations.Models.AnalyzeConversationActionResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAITaskResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITaskResult>
    {
        internal ConversationalAITaskResult() { }
        public Azure.AI.Language.Conversations.Models.ConversationalAIResult Result { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAITaskResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAITaskResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalAITaskResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalAITaskResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITaskResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITaskResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalAITaskResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationalPiiResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResult>
    {
        internal ConversationalPiiResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationPiiItemResult> ConversationItems { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.InputWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalPiiResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationalPiiResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationalPiiResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAnalysisInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationAnalysisInput>
    {
        public ConversationAnalysisInput(Azure.AI.Language.Conversations.Models.TextConversationItem conversationItem) { }
        public Azure.AI.Language.Conversations.Models.TextConversationItem ConversationItem { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class ConversationEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntity>
    {
        internal ConversationEntity() { }
        public string Category { get { throw null; } }
        public float Confidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation> ExtraInformation { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ResolutionBase> Resolutions { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConversationEntityExtraInformation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation>
    {
        protected ConversationEntityExtraInformation() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationError>
    {
        internal ConversationError() { }
        public Azure.AI.Language.Conversations.Models.ConversationErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationError> Details { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationIntent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationIntent>
    {
        internal ConversationIntent() { }
        public string Category { get { throw null; } }
        public float Confidence { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationItemLevelTiming : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>
    {
        public ConversationItemLevelTiming() { }
        public long? Duration { get { throw null; } set { } }
        public long? Offset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemLevelTiming>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationItemRange : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemRange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemRange>
    {
        internal ConversationItemRange() { }
        public int Count { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationItemRange System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationItemRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationItemRange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationItemRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationLanguageUnderstandingActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent>
    {
        public ConversationLanguageUnderstandingActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string DirectTarget { get { throw null; } set { } }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.Models.AnalysisConfig> TargetProjectParameters { get { throw null; } }
        public bool? Verbose { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationLanguageUnderstandingInput : Azure.AI.Language.Conversations.Models.AnalyzeConversationInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput>
    {
        public ConversationLanguageUnderstandingInput(Azure.AI.Language.Conversations.Models.ConversationAnalysisInput conversationInput, Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent actionContent) { }
        public Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingActionContent ActionContent { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationAnalysisInput ConversationInput { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationLanguageUnderstandingInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.AI.Language.Conversations.Models.BaseRedactionPolicy RedactionPolicy { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.TranscriptContentType? RedactionSource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories CreditCard { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Default { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Email { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories NumericIdentifier { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Person { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategories Phone { get { throw null; } }
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
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions CreditCard { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions Email { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions NumericIdentifier { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions Person { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ConversationPiiCategoryExclusions Phone { get { throw null; } }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationPiiResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>
    {
        internal ConversationPiiResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationalPiiResult> Conversations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPiiResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPiiResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationPrediction : Azure.AI.Language.Conversations.Models.PredictionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPrediction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPrediction>
    {
        internal ConversationPrediction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationIntent> Intents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPrediction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPrediction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationPrediction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationPrediction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPrediction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPrediction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationPrediction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationRequestStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationRequestStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationRequestStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationResult>
    {
        internal ConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationPrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationsSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationsSummaryResult>
    {
        internal ConversationsSummaryResult() { }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.SummaryResultItem> Summaries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.InputWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>
    {
        public ConversationSummarizationActionContent(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.SummaryAspect> summaryAspects) { }
        public string Instruction { get { throw null; } set { } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public int? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.SummaryAspect> SummaryAspects { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.SummaryLengthBucket? SummaryLength { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult>
    {
        internal ConversationTargetIntentResult() : base (default(double)) { }
        public Azure.AI.Language.Conversations.Models.ConversationResult Result { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CurrencyResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CurrencyResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CurrencyResolution>
    {
        internal CurrencyResolution() { }
        public string Iso4217 { get { throw null; } }
        public string Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CurrencyResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CurrencyResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CurrencyResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CurrencyResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CurrencyResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CurrencyResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CurrencyResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CustomSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.CustomSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.CustomSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateTimeResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DateTimeResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DateTimeResolution>
    {
        internal DateTimeResolution() { }
        public Azure.AI.Language.Conversations.Models.DateTimeSubKind DateTimeSubKind { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.TemporalModifier? Modifier { get { throw null; } }
        public string Timex { get { throw null; } }
        public string Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.DateTimeResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DateTimeResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DateTimeResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.DateTimeResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DateTimeResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DateTimeResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DateTimeResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DateTimeSubKind : System.IEquatable<Azure.AI.Language.Conversations.Models.DateTimeSubKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DateTimeSubKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DateTimeSubKind Date { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.DateTimeSubKind DateTime { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.DateTimeSubKind Duration { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.DateTimeSubKind Set { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.DateTimeSubKind Time { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.DateTimeSubKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.DateTimeSubKind left, Azure.AI.Language.Conversations.Models.DateTimeSubKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.DateTimeSubKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.DateTimeSubKind left, Azure.AI.Language.Conversations.Models.DateTimeSubKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DocumentError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>
    {
        internal DocumentError() { }
        public Azure.AI.Language.Conversations.Models.ConversationError Error { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.DocumentError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DocumentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.DocumentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.DocumentError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.DocumentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityMaskTypePolicyType : Azure.AI.Language.Conversations.Models.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType>
    {
        public EntityMaskTypePolicyType() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityMaskTypePolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitySubtype : Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntitySubtype>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntitySubtype>
    {
        internal EntitySubtype() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.EntityTag> Tags { get { throw null; } }
        public string Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.EntitySubtype System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntitySubtype>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntitySubtype>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.EntitySubtype System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntitySubtype>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntitySubtype>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntitySubtype>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityTag : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntityTag>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityTag>
    {
        internal EntityTag() { }
        public double? ConfidenceScore { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.EntityTag System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntityTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.EntityTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.EntityTag System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.EntityTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformationResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InformationResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InformationResolution>
    {
        internal InformationResolution() { }
        public Azure.AI.Language.Conversations.Models.InformationUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.InformationResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InformationResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.InformationResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.InformationResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InformationResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InformationResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.InformationResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformationUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.InformationUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformationUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Bit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Byte { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Gigabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Gigabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Kilobit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Kilobyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Megabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Megabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Petabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Petabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Terabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Terabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.InformationUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.InformationUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.InformationUnit left, Azure.AI.Language.Conversations.Models.InformationUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.InformationUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.InformationUnit left, Azure.AI.Language.Conversations.Models.InformationUnit right) { throw null; }
        public override string ToString() { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ItemizedSummaryContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ItemizedSummaryContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ItemizedSummaryContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswer : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer>
    {
        internal KnowledgeBaseAnswer() { }
        public string Answer { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog Dialog { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public int? QnaId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Questions { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.AnswerSpan ShortAnswer { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>
    {
        public KnowledgeBaseAnswerContext(int previousQnaId) { }
        public int PreviousQnaId { get { throw null; } }
        public string PreviousQuestion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerDialog : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog>
    {
        internal KnowledgeBaseAnswerDialog() { }
        public bool? IsContextOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt> Prompts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt>
    {
        internal KnowledgeBaseAnswerPrompt() { }
        public int? DisplayOrder { get { throw null; } }
        public string DisplayText { get { throw null; } }
        public int? QnaId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LengthResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LengthResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LengthResolution>
    {
        internal LengthResolution() { }
        public Azure.AI.Language.Conversations.Models.LengthUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LengthResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LengthResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LengthResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LengthResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LengthResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LengthResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LengthResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LengthUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.LengthUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LengthUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Centimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Decameter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Decimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Foot { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Hectometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Inch { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Kilometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit LightYear { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Meter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Micrometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Mile { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Millimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Nanometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Picometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Point { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.LengthUnit Yard { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.LengthUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.LengthUnit left, Azure.AI.Language.Conversations.Models.LengthUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.LengthUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.LengthUnit left, Azure.AI.Language.Conversations.Models.LengthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListKey : Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ListKey>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ListKey>
    {
        internal ListKey() { }
        public string Key { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ListKey System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ListKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ListKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ListKey System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ListKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ListKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ListKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LuisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisResult>
    {
        internal LuisResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LuisTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisTargetIntentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisTargetIntentResult>
    {
        internal LuisTargetIntentResult() : base (default(double)) { }
        public Azure.AI.Language.Conversations.Models.LuisResult Result { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisTargetIntentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisTargetIntentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.LuisTargetIntentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.LuisTargetIntentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisTargetIntentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisTargetIntentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.LuisTargetIntentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.MetadataFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.MetadataFilter>
    {
        public MetadataFilter() { }
        public Azure.AI.Language.Conversations.Models.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.MetadataRecord> Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public string Mask { get { throw null; } }
        public int? MaskLength { get { throw null; } }
        public int? MaskOffset { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NamedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NamedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NamedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NamedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoMaskPolicyType : Azure.AI.Language.Conversations.Models.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NoMaskPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoMaskPolicyType>
    {
        public NoMaskPolicyType() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NoMaskPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NoMaskPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NoMaskPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NoMaskPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoMaskPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoMaskPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoMaskPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoneLinkedTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult>
    {
        internal NoneLinkedTargetIntentResult() : base (default(double)) { }
        public Azure.AI.Language.Conversations.Models.ConversationResult Result { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NumberKind : System.IEquatable<Azure.AI.Language.Conversations.Models.NumberKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NumberKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.NumberKind Decimal { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.NumberKind Fraction { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.NumberKind Integer { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.NumberKind Percent { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.NumberKind Power { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.NumberKind Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.NumberKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.NumberKind left, Azure.AI.Language.Conversations.Models.NumberKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.NumberKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.NumberKind left, Azure.AI.Language.Conversations.Models.NumberKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumberResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NumberResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumberResolution>
    {
        internal NumberResolution() { }
        public Azure.AI.Language.Conversations.Models.NumberKind NumberKind { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NumberResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NumberResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NumberResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NumberResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumberResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumberResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumberResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumericRangeResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NumericRangeResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumericRangeResolution>
    {
        internal NumericRangeResolution() { }
        public double Maximum { get { throw null; } }
        public double Minimum { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.RangeKind RangeKind { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NumericRangeResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NumericRangeResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.NumericRangeResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.NumericRangeResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumericRangeResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumericRangeResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.NumericRangeResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationPrediction : Azure.AI.Language.Conversations.Models.PredictionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.OrchestrationPrediction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrchestrationPrediction>
    {
        internal OrchestrationPrediction() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Models.TargetIntentResult> Intents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.OrchestrationPrediction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.OrchestrationPrediction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.OrchestrationPrediction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.OrchestrationPrediction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrchestrationPrediction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrchestrationPrediction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrchestrationPrediction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrdinalResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.OrdinalResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrdinalResolution>
    {
        internal OrdinalResolution() { }
        public string Offset { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.RelativeTo RelativeTo { get { throw null; } }
        public string Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.OrdinalResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.OrdinalResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.OrdinalResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.OrdinalResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrdinalResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrdinalResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.OrdinalResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.PiiOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.PiiOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PiiOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PredictionBase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PredictionBase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PredictionBase>
    {
        protected PredictionBase() { }
        public string TopIntent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.PredictionBase System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PredictionBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.PredictionBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.PredictionBase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PredictionBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PredictionBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.PredictionBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryFilters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QueryFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QueryFilters>
    {
        public QueryFilters() { }
        public Azure.AI.Language.Conversations.Models.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Models.MetadataFilter MetadataFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFilter { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult>
    {
        internal QuestionAnsweringTargetIntentResult() : base (default(double)) { }
        public Azure.AI.Language.Conversations.Models.AnswersResult Result { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnswersConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.QuestionAnswersConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.QuestionAnswersConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RangeKind : System.IEquatable<Azure.AI.Language.Conversations.Models.RangeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RangeKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RangeKind Age { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Area { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Currency { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Information { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Length { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Number { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Speed { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Temperature { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Volume { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RangeKind Weight { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.RangeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.RangeKind left, Azure.AI.Language.Conversations.Models.RangeKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.RangeKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.RangeKind left, Azure.AI.Language.Conversations.Models.RangeKind right) { throw null; }
        public override string ToString() { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class RegexKey : Azure.AI.Language.Conversations.Models.ConversationEntityExtraInformation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RegexKey>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RegexKey>
    {
        internal RegexKey() { }
        public string Key { get { throw null; } }
        public string RegexPattern { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.RegexKey System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RegexKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RegexKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.RegexKey System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RegexKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RegexKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RegexKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelativeTo : System.IEquatable<Azure.AI.Language.Conversations.Models.RelativeTo>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelativeTo(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.RelativeTo Current { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RelativeTo End { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.RelativeTo Start { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.RelativeTo other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.RelativeTo left, Azure.AI.Language.Conversations.Models.RelativeTo right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.RelativeTo (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.RelativeTo left, Azure.AI.Language.Conversations.Models.RelativeTo right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RequestStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>
    {
        internal RequestStatistics() { }
        public int DocumentsCount { get { throw null; } }
        public int ErroneousDocumentsCount { get { throw null; } }
        public long TransactionsCount { get { throw null; } }
        public int ValidDocumentsCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.RequestStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.RequestStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.RequestStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResolutionBase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ResolutionBase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ResolutionBase>
    {
        protected ResolutionBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ResolutionBase System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ResolutionBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ResolutionBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ResolutionBase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ResolutionBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ResolutionBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ResolutionBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShortAnswerConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>
    {
        public ShortAnswerConfig() { }
        public double? ConfidenceThreshold { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ShortAnswerConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.ShortAnswerConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.ShortAnswerConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpeedResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SpeedResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SpeedResolution>
    {
        internal SpeedResolution() { }
        public Azure.AI.Language.Conversations.Models.SpeedUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SpeedResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SpeedResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SpeedResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SpeedResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SpeedResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SpeedResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SpeedResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpeedUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.SpeedUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpeedUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit CentimetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit FootPerMinute { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit FootPerSecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit KilometersPerHour { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit KilometersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit KilometersPerMinute { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit KilometersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit Knot { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit MetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit MetersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit MilesPerHour { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit YardsPerMinute { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.SpeedUnit YardsPerSecond { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.SpeedUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.SpeedUnit left, Azure.AI.Language.Conversations.Models.SpeedUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.SpeedUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.SpeedUnit left, Azure.AI.Language.Conversations.Models.SpeedUnit right) { throw null; }
        public override string ToString() { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SummaryResultItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.SummaryResultItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.SummaryResultItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TargetIntentResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TargetIntentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TargetIntentResult>
    {
        protected TargetIntentResult(double confidence) { }
        public string ApiVersion { get { throw null; } }
        public double Confidence { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TargetIntentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TargetIntentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TargetIntentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TargetIntentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TargetIntentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TargetIntentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TargetIntentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemperatureResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TemperatureResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemperatureResolution>
    {
        internal TemperatureResolution() { }
        public Azure.AI.Language.Conversations.Models.TemperatureUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TemperatureResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TemperatureResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TemperatureResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TemperatureResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemperatureResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemperatureResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemperatureResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemperatureUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.TemperatureUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemperatureUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TemperatureUnit Celsius { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemperatureUnit Fahrenheit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemperatureUnit Kelvin { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemperatureUnit Rankine { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemperatureUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.TemperatureUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.TemperatureUnit left, Azure.AI.Language.Conversations.Models.TemperatureUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.TemperatureUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.TemperatureUnit left, Azure.AI.Language.Conversations.Models.TemperatureUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemporalModifier : System.IEquatable<Azure.AI.Language.Conversations.Models.TemporalModifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemporalModifier(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier After { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier AfterApproximate { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier AfterMid { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier AfterStart { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier Approximate { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier Before { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier BeforeApproximate { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier BeforeEnd { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier BeforeStart { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier End { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier Less { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier Mid { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier More { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier ReferenceUndefined { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier Since { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier SinceEnd { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier Start { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TemporalModifier Until { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.TemporalModifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.TemporalModifier left, Azure.AI.Language.Conversations.Models.TemporalModifier right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.TemporalModifier (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.TemporalModifier left, Azure.AI.Language.Conversations.Models.TemporalModifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemporalSpanResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TemporalSpanResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemporalSpanResolution>
    {
        internal TemporalSpanResolution() { }
        public string Begin { get { throw null; } }
        public string Duration { get { throw null; } }
        public string End { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.TemporalModifier? Modifier { get { throw null; } }
        public string Timex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TemporalSpanResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TemporalSpanResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TemporalSpanResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TemporalSpanResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemporalSpanResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemporalSpanResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TemporalSpanResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextConversation : Azure.AI.Language.Conversations.Models.ConversationInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TextConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TextConversation>
    {
        public TextConversation(string id, string language, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.TextConversationItem> conversationItems) : base (default(string), default(string)) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Models.TextConversationItem> ConversationItems { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TranscriptConversationItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.TranscriptConversationItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.TranscriptConversationItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.VolumeResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.VolumeResolution>
    {
        internal VolumeResolution() { }
        public Azure.AI.Language.Conversations.Models.VolumeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.VolumeResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.VolumeResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.VolumeResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.VolumeResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.VolumeResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.VolumeResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.VolumeResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.VolumeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Barrel { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Bushel { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Centiliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Cord { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit CubicCentimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit CubicFoot { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit CubicInch { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit CubicMeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit CubicMile { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit CubicMillimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit CubicYard { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Cup { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Decaliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit FluidDram { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit FluidOunce { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Gill { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Hectoliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Hogshead { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Liter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Milliliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Minim { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Peck { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Pinch { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Pint { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Quart { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Tablespoon { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Teaspoon { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.VolumeUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.VolumeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.VolumeUnit left, Azure.AI.Language.Conversations.Models.VolumeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.VolumeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.VolumeUnit left, Azure.AI.Language.Conversations.Models.VolumeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeightResolution : Azure.AI.Language.Conversations.Models.ResolutionBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WeightResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WeightResolution>
    {
        internal WeightResolution() { }
        public Azure.AI.Language.Conversations.Models.WeightUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.WeightResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WeightResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WeightResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.WeightResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WeightResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WeightResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WeightResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightUnit : System.IEquatable<Azure.AI.Language.Conversations.Models.WeightUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Dram { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Gallon { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Grain { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Gram { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Kilogram { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit LongTonBritish { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit MetricTon { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Milligram { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Ounce { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit PennyWeight { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Pound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit ShortHundredWeightUS { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit ShortTonUS { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Stone { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Ton { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.WeightUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.WeightUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.WeightUnit left, Azure.AI.Language.Conversations.Models.WeightUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.WeightUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.WeightUnit left, Azure.AI.Language.Conversations.Models.WeightUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WordLevelTiming : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>
    {
        public WordLevelTiming() { }
        public long? Duration { get { throw null; } set { } }
        public long? Offset { get { throw null; } set { } }
        public string Word { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.WordLevelTiming System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Models.WordLevelTiming System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Models.WordLevelTiming>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConversationAnalysisClientExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", true)]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", true)]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
