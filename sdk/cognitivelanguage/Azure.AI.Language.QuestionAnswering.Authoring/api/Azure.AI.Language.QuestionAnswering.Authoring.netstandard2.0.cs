namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    public partial class ActiveLearningFeedback : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>
    {
        public ActiveLearningFeedback() { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord> Records { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback activeLearningFeedback) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.AssetKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.AssetKind Qnas { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.AssetKind Synonyms { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind left, Azure.AI.Language.QuestionAnswering.Authoring.AssetKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.AssetKind (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind left, Azure.AI.Language.QuestionAnswering.Authoring.AssetKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAILanguageQuestionAnsweringAuthoringContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageQuestionAnsweringAuthoringContext() { }
        public static Azure.AI.Language.QuestionAnswering.Authoring.AzureAILanguageQuestionAnsweringAuthoringContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class FeedbackRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>
    {
        public FeedbackRecord() { }
        public int? QnaId { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
        public string UserQuestion { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImportContentType : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImportContentType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType ApplicationJson { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType left, Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType left, Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImportJobOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>
    {
        public ImportJobOptions() { }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets Assets { get { throw null; } set { } }
        public System.Uri FileUri { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject Metadata { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions importJobOptions) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportQnaRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>
    {
        public ImportQnaRecord(int id) { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> ActiveLearningSuggestions { get { throw null; } }
        public string Answer { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog Dialog { get { throw null; } set { } }
        public int Id { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedDateTime { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string SourceDisplayName { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Cancelling { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Failed { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.JobStatus NotStarted { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.JobStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Running { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus left, Azure.AI.Language.QuestionAnswering.Authoring.JobStatus right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.JobStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.JobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus left, Azure.AI.Language.QuestionAnswering.Authoring.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeBaseFormat : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeBaseFormat(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat Excel { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat Json { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat Tsv { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat left, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat left, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class LanguageQuestionAnsweringAuthoringModelFactory
    {
        public static Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback ActiveLearningFeedback(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord> records = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord FeedbackRecord(string userId = null, string userQuestion = null, int? qnaId = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions ImportJobOptions(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject metadata = null, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets assets = null, System.Uri fileUri = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord ImportQnaRecord(int id = 0, string answer = null, string source = null, System.Collections.Generic.IEnumerable<string> questions = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog dialog = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> activeLearningSuggestions = null, System.DateTimeOffset? lastUpdatedDateTime = default(System.DateTimeOffset?), string sourceDisplayName = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment ProjectDeployment(string deploymentName = null, System.DateTimeOffset? lastDeployedDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings ProjectSettings(string defaultAnswer = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog QnaDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt QnaPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord qna = null, string displayText = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord QnaRecord(int id = 0, string answer = null, string source = null, System.Collections.Generic.IEnumerable<string> questions = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog dialog = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> activeLearningSuggestions = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord QnaSourceRecord(string displayName = null, string source = null, System.Uri sourceUri = null, Azure.AI.Language.QuestionAnswering.Authoring.SourceKind sourceKind = default(Azure.AI.Language.QuestionAnswering.Authoring.SourceKind), Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind? contentStructureKind = default(Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind?), System.DateTimeOffset? lastUpdatedDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets QuestionAnsweringAuthoringAssets(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations> synonyms = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord> qnas = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState QuestionAnsweringAuthoringExportJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.JobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, string resultUrl = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState QuestionAnsweringAuthoringImportJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.JobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState QuestionAnsweringAuthoringProjectDeletionJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.JobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState QuestionAnsweringAuthoringProjectDeploymentJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.JobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState QuestionAnsweringAuthoringUpdateQnasJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.JobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState QuestionAnsweringAuthoringUpdateSourcesJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.JobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.JobStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject QuestionAnsweringProject(string projectName = null, string description = null, string language = null, bool? multilingualResource = default(bool?), Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings settings = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedDateTime = default(System.DateTimeOffset?), bool? configureSemanticRanking = default(bool?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord RetrieveQnaRecord(int id = 0, string answer = null, string source = null, System.Collections.Generic.IEnumerable<string> questions = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog dialog = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> activeLearningSuggestions = null, System.DateTimeOffset? lastUpdatedDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion SuggestedQuestion(string question = null, int? userSuggestedCount = default(int?), int? autoSuggestedCount = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster SuggestedQuestionsCluster(string clusterHead = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion> suggestedQuestions = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets SynonymAssets(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations WordAlterations(System.Collections.Generic.IEnumerable<string> alterations = null) { throw null; }
    }
    public partial class ProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>
    {
        internal ProjectDeployment() { }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset? LastDeployedDateTime { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>
    {
        public ProjectSettings() { }
        public string DefaultAnswer { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QnaDialog : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog>
    {
        public QnaDialog() { }
        public bool? IsContextOnly { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt> Prompts { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QnaPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt>
    {
        public QnaPrompt() { }
        public int? DisplayOrder { get { throw null; } set { } }
        public string DisplayText { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord Qna { get { throw null; } set { } }
        public int? QnaId { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QnaRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord>
    {
        public QnaRecord(int id) { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> ActiveLearningSuggestions { get { throw null; } }
        public string Answer { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog Dialog { get { throw null; } set { } }
        public int Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QnaSourceRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord>
    {
        internal QnaSourceRecord() { }
        public Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind? ContentStructureKind { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedDateTime { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.SourceKind SourceKind { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringAssets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>
    {
        public QuestionAnsweringAuthoringAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord> Qnas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations> Synonyms { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionAnsweringAuthoringAudience : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionAnsweringAuthoringAudience(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience AzureChina { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringAuthoringClient
    {
        protected QuestionAnsweringAuthoringClient() { }
        public QuestionAnsweringAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public QuestionAnsweringAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions options) { }
        public QuestionAnsweringAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public QuestionAnsweringAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddFeedback(string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddFeedback(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddFeedbackAsync(string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddFeedbackAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, string format, string assetKind, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, string format, string assetKind, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetDeleteStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState> GetDeleteStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeleteStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>> GetDeleteStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment> GetDeployments(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment> GetDeploymentsAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeployStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState> GetDeployStatus(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeployStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>> GetDeployStatusAsync(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState> GetExportStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>> GetExportStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetImportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState> GetImportStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>> GetImportStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProjectDetails(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject> GetProjectDetails(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDetailsAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>> GetProjectDetailsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject> GetProjects(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject> GetProjectsAsync(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetQnas(string projectName, int? top, int? skip, int? maxpagesize, string source, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord> GetQnas(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string source = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetQnasAsync(string projectName, int? top, int? skip, int? maxpagesize, string source, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord> GetQnasAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string source = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSources(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord> GetSources(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSourcesAsync(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.QnaSourceRecord> GetSourcesAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSynonyms(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations> GetSynonyms(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSynonymsAsync(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations> GetSynonymsAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUpdateQnasStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState> GetUpdateQnasStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateQnasStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>> GetUpdateQnasStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUpdateSourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState> GetUpdateSourcesStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateSourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>> GetUpdateSourcesStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions body = null, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType? contentType = default(Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string format = null, string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions body = null, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType? contentType = default(Azure.AI.Language.QuestionAnswering.Authoring.ImportContentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string format = null, string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation ImportFromFiles(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string contentType, string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportFromFilesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string contentType, string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UpdateQnas(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UpdateQnasAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UpdateSources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UpdateSourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UpdateSourcesFromFiles(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UpdateSourcesFromFilesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateSynonyms(string projectName, Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSynonyms(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSynonymsAsync(string projectName, Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSynonymsAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringClientOptions : Azure.Core.ClientOptions
    {
        public QuestionAnsweringAuthoringClientOptions(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions.ServiceVersion version = Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2025_05_15_Preview = 2,
        }
    }
    public partial class QuestionAnsweringAuthoringExportJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>
    {
        internal QuestionAnsweringAuthoringExportJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public string ResultUrl { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Status { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringImportJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>
    {
        internal QuestionAnsweringAuthoringImportJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Status { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringProjectDeletionJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>
    {
        internal QuestionAnsweringAuthoringProjectDeletionJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Status { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringProjectDeploymentJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>
    {
        internal QuestionAnsweringAuthoringProjectDeploymentJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Status { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeploymentJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringUpdateQnasJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>
    {
        internal QuestionAnsweringAuthoringUpdateQnasJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Status { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringUpdateSourcesJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>
    {
        internal QuestionAnsweringAuthoringUpdateSourcesJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.JobStatus Status { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringProject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>
    {
        public QuestionAnsweringProject() { }
        public bool? ConfigureSemanticRanking { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public System.DateTimeOffset? LastDeployedDateTime { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public bool? MultilingualResource { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings Settings { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RetrieveQnaRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>
    {
        internal RetrieveQnaRecord() { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> ActiveLearningSuggestions { get { throw null; } }
        public string Answer { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QnaDialog Dialog { get { throw null; } }
        public int Id { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceContentStructureKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceContentStructureKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind Unstructured { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind left, Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind left, Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.SourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.SourceKind File { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.SourceKind Url { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.SourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.SourceKind left, Azure.AI.Language.QuestionAnswering.Authoring.SourceKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.SourceKind (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.SourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.SourceKind left, Azure.AI.Language.QuestionAnswering.Authoring.SourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SuggestedQuestion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>
    {
        public SuggestedQuestion() { }
        public int? AutoSuggestedCount { get { throw null; } set { } }
        public string Question { get { throw null; } set { } }
        public int? UserSuggestedCount { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuggestedQuestionsCluster : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>
    {
        public SuggestedQuestionsCluster() { }
        public string ClusterHead { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion> SuggestedQuestions { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynonymAssets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>
    {
        public SynonymAssets(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations> value) { }
        public System.Uri NextLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations> Value { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets synonymAssets) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WordAlterations : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations>
    {
        public WordAlterations(System.Collections.Generic.IEnumerable<string> alterations) { }
        public System.Collections.Generic.IList<string> Alterations { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class LanguageQuestionAnsweringAuthoringClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClient, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions> AddQuestionAnsweringAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClient, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions> AddQuestionAnsweringAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClient, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions> AddQuestionAnsweringAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
