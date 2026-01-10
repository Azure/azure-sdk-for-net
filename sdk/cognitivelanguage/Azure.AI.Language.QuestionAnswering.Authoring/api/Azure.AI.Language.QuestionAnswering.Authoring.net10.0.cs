namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    public partial class ActiveLearningFeedback : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>
    {
        public ActiveLearningFeedback() { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord> Records { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ActiveLearningFeedback>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AILanguageQuestionAnsweringAuthoringModelFactory
    {
        public static Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord ImportQnaRecord(int id = 0, string answer = null, string source = null, System.Collections.Generic.IEnumerable<string> questions = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog dialog = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> activeLearningSuggestionClusters = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), string sourceDisplayName = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile KnowledgeBaseFile(string contentType = null, string filename = null, System.BinaryData contents = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment ProjectDeployment(string deploymentName = null, System.DateTimeOffset? lastDeployed = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState ProjectDeploymentJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError QuestionAnsweringAuthoringError(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode code = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> details = null, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel innerError = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState QuestionAnsweringAuthoringExportJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdated = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> errors = null, string resultUrl = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState QuestionAnsweringAuthoringImportJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel QuestionAnsweringAuthoringInnerErrorModel(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode code = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> details = null, string target = null, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState QuestionAnsweringAuthoringProjectDeletionJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord QuestionAnsweringAuthoringSourceRecord(string displayName = null, string source = null, System.Uri sourceUri = null, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind sourceKind = default(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind), Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind? contentStructureKind = default(Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind?), System.DateTimeOffset? lastUpdatedDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState QuestionAnsweringAuthoringUpdateQnasJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState QuestionAnsweringAuthoringUpdateSourcesJobState(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), string jobId = null, System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus status = default(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject QuestionAnsweringProject(string projectName = null, string description = null, string language = null, bool? isMultilingualResource = default(bool?), Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings settings = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedDateTime = default(System.DateTimeOffset?), bool? isConfiguredSemanticRankingEnabled = default(bool?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord RetrieveQnaRecord(int id = 0, string answer = null, string source = null, System.Collections.Generic.IEnumerable<string> questions = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog dialog = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> activeLearningSuggestionClusters = null, System.DateTimeOffset? lastUpdatedDateTime = default(System.DateTimeOffset?)) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.FeedbackRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileFormat : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.FileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileFormat(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.FileFormat Excel { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.FileFormat Json { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.FileFormat Tsv { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.FileFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.FileFormat left, Azure.AI.Language.QuestionAnswering.Authoring.FileFormat right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.FileFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.FileFormat left, Azure.AI.Language.QuestionAnswering.Authoring.FileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImportFiles : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles>
    {
        public ImportFiles(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile> files) { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile> Files { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportJobOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>
    {
        public ImportJobOptions() { }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets Assets { get { throw null; } set { } }
        public System.Uri FileUri { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject Metadata { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportQnaRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>
    {
        public ImportQnaRecord(int id) { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> ActiveLearningSuggestionClusters { get { throw null; } }
        public string Answer { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog Dialog { get { throw null; } set { } }
        public int Id { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string SourceDisplayName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile>
    {
        public KnowledgeBaseFile(System.BinaryData contents) { }
        public System.BinaryData Contents { get { throw null; } }
        public string ContentType { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeBaseSourceKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeBaseSourceKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind File { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind Url { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind left, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind left, Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>
    {
        internal ProjectDeployment() { }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset? LastDeployed { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeploymentJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>
    {
        internal ProjectDeploymentJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>
    {
        public ProjectSettings() { }
        public string DefaultAnswer { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringAssets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringAssets>
    {
        public QuestionAnsweringAuthoringAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.ImportQnaRecord> Qnas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups> Synonyms { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.FileFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.FileFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, string format, string assetKind, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.FileFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.FileFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, string format, string assetKind, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetDeleteStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState> GetDeleteStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeleteStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>> GetDeleteStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment> GetDeployments(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeployStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState> GetDeployStatus(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeployStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.ProjectDeploymentJobState>> GetDeployStatusAsync(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject> GetProjects(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject> GetProjectsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetQnas(string projectName, int? maxCount, int? skip, int? maxpagesize, string source, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord> GetQnas(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string source = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetQnasAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, string source, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord> GetQnasAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string source = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSources(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord> GetSources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSourcesAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord> GetSourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSynonyms(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups> GetSynonyms(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSynonymsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups> GetSynonymsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUpdateQnasStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState> GetUpdateQnasStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateQnasStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>> GetUpdateQnasStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUpdateSourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState> GetUpdateSourcesStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateSourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>> GetUpdateSourcesStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions body = null, Azure.AI.Language.QuestionAnswering.Authoring.FileFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.FileFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string format = null, string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ImportJobOptions body = null, Azure.AI.Language.QuestionAnswering.Authoring.FileFormat? format = default(Azure.AI.Language.QuestionAnswering.Authoring.FileFormat?), Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string format = null, string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation ImportFromFiles(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles body, Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation ImportFromFiles(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string contentType, string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportFromFilesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.QuestionAnswering.Authoring.ImportFiles body, Azure.AI.Language.QuestionAnswering.Authoring.AssetKind? assetKind = default(Azure.AI.Language.QuestionAnswering.Authoring.AssetKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class QuestionAnsweringAuthoringDialog : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog>
    {
        public QuestionAnsweringAuthoringDialog() { }
        public bool? IsContextOnly { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt> Prompts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError>
    {
        internal QuestionAnsweringAuthoringError() { }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> Details { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionAnsweringAuthoringErrorCode : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionAnsweringAuthoringErrorCode(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode AzureCognitiveSearchIndexLimitReached { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode AzureCognitiveSearchIndexNotFound { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode Conflict { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode Forbidden { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode NotFound { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode OperationNotFound { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode ProjectNotFound { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode QuotaExceeded { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode Timeout { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode TooManyRequests { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode Unauthorized { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode Warning { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringAuthoringExportJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringExportJobState>
    {
        internal QuestionAnsweringAuthoringExportJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdated { get { throw null; } }
        public string ResultUrl { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringImportJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionAnsweringAuthoringInnerErrorCode : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionAnsweringAuthoringInnerErrorCode(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode EmptyRequest { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode ExtractionFailure { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode InvalidCountryHint { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode InvalidDocument { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode InvalidDocumentBatch { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode InvalidParameterValue { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode InvalidRequestBodyFormat { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode KnowledgeBaseNotFound { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode MissingInputDocuments { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode ModelVersionIncorrect { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode UnsupportedLanguageCode { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringAuthoringInnerErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel>
    {
        internal QuestionAnsweringAuthoringInnerErrorModel() { }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Details { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringInnerErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionAnsweringAuthoringJobStatus : System.IEquatable<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionAnsweringAuthoringJobStatus(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Cancelling { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Failed { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus NotStarted { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Running { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus left, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringAuthoringProjectDeletionJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>
    {
        internal QuestionAnsweringAuthoringProjectDeletionJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringProjectDeletionJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt>
    {
        public QuestionAnsweringAuthoringPrompt() { }
        public int? DisplayOrder { get { throw null; } set { } }
        public string DisplayText { get { throw null; } set { } }
        public int? QnaId { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord QnaRecord { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord>
    {
        public QuestionAnsweringAuthoringRecord(int id) { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> ActiveLearningSuggestionClusters { get { throw null; } }
        public string Answer { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog Dialog { get { throw null; } set { } }
        public int Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringSourceRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord>
    {
        internal QuestionAnsweringAuthoringSourceRecord() { }
        public Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind? ContentStructureKind { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedDateTime { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.KnowledgeBaseSourceKind SourceKind { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringSourceRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringAuthoringUpdateQnasJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateQnasJobState>
    {
        internal QuestionAnsweringAuthoringUpdateQnasJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringJobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringUpdateSourcesJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuestionAnsweringProject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>
    {
        public QuestionAnsweringProject() { }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsConfiguredSemanticRankingEnabled { get { throw null; } set { } }
        public bool? IsMultilingualResource { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public System.DateTimeOffset? LastDeployedDateTime { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.ProjectSettings Settings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RetrieveQnaRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.RetrieveQnaRecord>
    {
        internal RetrieveQnaRecord() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster> ActiveLearningSuggestionClusters { get { throw null; } }
        public string Answer { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringDialog Dialog { get { throw null; } }
        public int Id { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind left, Azure.AI.Language.QuestionAnswering.Authoring.SourceContentStructureKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SuggestedQuestion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestion>
    {
        public SuggestedQuestion() { }
        public int? AutoSuggestedCount { get { throw null; } set { } }
        public string Question { get { throw null; } set { } }
        public int? UserSuggestedCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SuggestedQuestionsCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynonymAssets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>
    {
        public SynonymAssets(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups> value) { }
        public System.Uri NextLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.SynonymAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WordAlterationsGroups : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups>
    {
        public WordAlterationsGroups(System.Collections.Generic.IEnumerable<string> alterations) { }
        public System.Collections.Generic.IList<string> Alterations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Authoring.WordAlterationsGroups>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AILanguageQuestionAnsweringAuthoringClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClient, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions> AddQuestionAnsweringAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClient, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions> AddQuestionAnsweringAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClient, Azure.AI.Language.QuestionAnswering.Authoring.QuestionAnsweringAuthoringClientOptions> AddQuestionAnsweringAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
