namespace Azure.AI.TextAnalytics
{
    public partial class AbstractiveSummarizeAction
    {
        public AbstractiveSummarizeAction() { }
        public AbstractiveSummarizeAction(Azure.AI.TextAnalytics.AbstractiveSummarizeOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public int? SentenceCount { get { throw null; } set { } }
    }
    public partial class AbstractiveSummarizeActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal AbstractiveSummarizeActionResult() { }
        public Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class AbstractiveSummarizeOperation : Azure.PageableOperation<Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection>
    {
        protected AbstractiveSummarizeOperation() { }
        public AbstractiveSummarizeOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public virtual System.DateTimeOffset CreatedOn { get { throw null; } }
        public virtual string DisplayName { get { throw null; } }
        public virtual System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual System.DateTimeOffset LastModified { get { throw null; } }
        public virtual Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AbstractiveSummarizeOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public AbstractiveSummarizeOptions() { }
        public string DisplayName { get { throw null; } set { } }
        public int? SentenceCount { get { throw null; } set { } }
    }
    public partial class AbstractiveSummarizeResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal AbstractiveSummarizeResult() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AbstractiveSummary> Summaries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class AbstractiveSummarizeResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.AbstractiveSummarizeResult>
    {
        internal AbstractiveSummarizeResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.AbstractiveSummarizeResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AbstractiveSummary
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AbstractiveSummaryContext> Contexts { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AbstractiveSummaryContext
    {
        private readonly int _dummyPrimitive;
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
    }
    public partial class AnalyzeActionsOperation : Azure.PageableOperation<Azure.AI.TextAnalytics.AnalyzeActionsResult>
    {
        protected AnalyzeActionsOperation() { }
        public AnalyzeActionsOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public virtual int ActionsFailed { get { throw null; } }
        public virtual int ActionsInProgress { get { throw null; } }
        public virtual int ActionsSucceeded { get { throw null; } }
        public virtual int ActionsTotal { get { throw null; } }
        public virtual System.DateTimeOffset CreatedOn { get { throw null; } }
        public virtual string DisplayName { get { throw null; } }
        public virtual System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual System.DateTimeOffset LastModified { get { throw null; } }
        public virtual Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeActionsResult> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.AnalyzeActionsResult> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeActionsResult> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeActionsResult>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeActionsResult>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalyzeActionsOptions
    {
        public AnalyzeActionsOptions() { }
        public bool? IncludeStatistics { get { throw null; } set { } }
    }
    public partial class AnalyzeActionsResult
    {
        internal AnalyzeActionsResult() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AbstractiveSummarizeActionResult> AbstractiveSummarizeResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesActionResult> AnalyzeHealthcareEntitiesResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AnalyzeSentimentActionResult> AnalyzeSentimentResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.ExtractiveSummarizeActionResult> ExtractiveSummarizeResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult> ExtractKeyPhrasesResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.MultiLabelClassifyActionResult> MultiLabelClassifyResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult> RecognizeCustomEntitiesResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeEntitiesActionResult> RecognizeEntitiesResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult> RecognizeLinkedEntitiesResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult> RecognizePiiEntitiesResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.SingleLabelClassifyActionResult> SingleLabelClassifyResults { get { throw null; } }
    }
    public partial class AnalyzeHealthcareEntitiesAction
    {
        public AnalyzeHealthcareEntitiesAction() { }
        public AnalyzeHealthcareEntitiesAction(Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class AnalyzeHealthcareEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal AnalyzeHealthcareEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class AnalyzeHealthcareEntitiesOperation : Azure.PageableOperation<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection>
    {
        protected AnalyzeHealthcareEntitiesOperation() { }
        public AnalyzeHealthcareEntitiesOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public virtual System.DateTimeOffset CreatedOn { get { throw null; } }
        public virtual string DisplayName { get { throw null; } }
        public virtual System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual System.DateTimeOffset LastModified { get { throw null; } }
        public virtual Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalyzeHealthcareEntitiesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public AnalyzeHealthcareEntitiesOptions() { }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class AnalyzeHealthcareEntitiesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal AnalyzeHealthcareEntitiesResult() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.HealthcareEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.HealthcareEntityRelation> EntityRelations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class AnalyzeHealthcareEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResult>
    {
        internal AnalyzeHealthcareEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class AnalyzeSentimentAction
    {
        public AnalyzeSentimentAction() { }
        public AnalyzeSentimentAction(Azure.AI.TextAnalytics.AnalyzeSentimentOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public bool? IncludeOpinionMining { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class AnalyzeSentimentActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal AnalyzeSentimentActionResult() { }
        public Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class AnalyzeSentimentOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public AnalyzeSentimentOptions() { }
        public bool? IncludeOpinionMining { get { throw null; } set { } }
    }
    public partial class AnalyzeSentimentResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal AnalyzeSentimentResult() { }
        public Azure.AI.TextAnalytics.DocumentSentiment DocumentSentiment { get { throw null; } }
    }
    public partial class AnalyzeSentimentResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.AnalyzeSentimentResult>
    {
        internal AnalyzeSentimentResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.AnalyzeSentimentResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSentiment
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public bool IsNegated { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class AzureAITextAnalyticsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAITextAnalyticsContext() { }
        public static Azure.AI.TextAnalytics.AzureAITextAnalyticsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategorizedEntity
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.EntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string SubCategory { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class CategorizedEntityCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.CategorizedEntity>
    {
        internal CategorizedEntityCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.CategorizedEntity>)) { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClassificationCategory
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
    }
    public partial class ClassificationCategoryCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.ClassificationCategory>
    {
        internal ClassificationCategoryCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.ClassificationCategory>)) { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class ClassifyDocumentOperation : Azure.PageableOperation<Azure.AI.TextAnalytics.ClassifyDocumentResultCollection>
    {
        protected ClassifyDocumentOperation() { }
        public ClassifyDocumentOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public virtual System.DateTimeOffset CreatedOn { get { throw null; } }
        public virtual string DisplayName { get { throw null; } }
        public virtual System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual System.DateTimeOffset LastModified { get { throw null; } }
        public virtual Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.ClassifyDocumentResultCollection> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.ClassifyDocumentResultCollection> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.ClassifyDocumentResultCollection> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.ClassifyDocumentResultCollection>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.ClassifyDocumentResultCollection>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClassifyDocumentResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal ClassifyDocumentResult() { }
        public Azure.AI.TextAnalytics.ClassificationCategoryCollection ClassificationCategories { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class ClassifyDocumentResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.ClassifyDocumentResult>
    {
        internal ClassifyDocumentResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.ClassifyDocumentResult>)) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DetectedLanguage
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public double ConfidenceScore { get { throw null; } }
        public string Iso6391Name { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class DetectLanguageInput : Azure.AI.TextAnalytics.TextAnalyticsInput
    {
        public const string None = "";
        public DetectLanguageInput(string id, string text) { }
        public string CountryHint { get { throw null; } set { } }
    }
    public partial class DetectLanguageResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal DetectLanguageResult() { }
        public Azure.AI.TextAnalytics.DetectedLanguage PrimaryLanguage { get { throw null; } }
    }
    public partial class DetectLanguageResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.DetectLanguageResult>
    {
        internal DetectLanguageResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.DetectLanguageResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class DocumentSentiment
    {
        internal DocumentSentiment() { }
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.SentenceSentiment> Sentences { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public enum EntityAssociation
    {
        Subject = 0,
        Other = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityCategory : System.IEquatable<Azure.AI.TextAnalytics.EntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Address;
        public static readonly Azure.AI.TextAnalytics.EntityCategory DateTime;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Email;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Event;
        public static readonly Azure.AI.TextAnalytics.EntityCategory IPAddress;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Location;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Organization;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Person;
        public static readonly Azure.AI.TextAnalytics.EntityCategory PersonType;
        public static readonly Azure.AI.TextAnalytics.EntityCategory PhoneNumber;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Product;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Quantity;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Skill;
        public static readonly Azure.AI.TextAnalytics.EntityCategory Url;
        public bool Equals(Azure.AI.TextAnalytics.EntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.EntityCategory left, Azure.AI.TextAnalytics.EntityCategory right) { throw null; }
        public static explicit operator string (Azure.AI.TextAnalytics.EntityCategory category) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.EntityCategory (string category) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.EntityCategory left, Azure.AI.TextAnalytics.EntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EntityCertainty
    {
        Positive = 0,
        PositivePossible = 1,
        NeutralPossible = 2,
        NegativePossible = 3,
        Negative = 4,
    }
    public enum EntityConditionality
    {
        Hypothetical = 0,
        Conditional = 1,
    }
    public partial class EntityDataSource
    {
        internal EntityDataSource() { }
        public string EntityId { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ExtractiveSummarizeAction
    {
        public ExtractiveSummarizeAction() { }
        public ExtractiveSummarizeAction(Azure.AI.TextAnalytics.ExtractiveSummarizeOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public int? MaxSentenceCount { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder? OrderBy { get { throw null; } set { } }
    }
    public partial class ExtractiveSummarizeActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal ExtractiveSummarizeActionResult() { }
        public Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class ExtractiveSummarizeOperation : Azure.PageableOperation<Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection>
    {
        protected ExtractiveSummarizeOperation() { }
        public ExtractiveSummarizeOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public virtual System.DateTimeOffset CreatedOn { get { throw null; } }
        public virtual string DisplayName { get { throw null; } }
        public virtual System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual System.DateTimeOffset LastModified { get { throw null; } }
        public virtual Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtractiveSummarizeOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public ExtractiveSummarizeOptions() { }
        public string DisplayName { get { throw null; } set { } }
        public int? MaxSentenceCount { get { throw null; } set { } }
        public Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder? OrderBy { get { throw null; } set { } }
    }
    public partial class ExtractiveSummarizeResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal ExtractiveSummarizeResult() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.ExtractiveSummarySentence> Sentences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class ExtractiveSummarizeResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.ExtractiveSummarizeResult>
    {
        internal ExtractiveSummarizeResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.ExtractiveSummarizeResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtractiveSummarySentence
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public double RankScore { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtractiveSummarySentencesOrder : System.IEquatable<Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtractiveSummarySentencesOrder(string value) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder Offset { get { throw null; } }
        public static Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder Rank { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder left, Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder left, Azure.AI.TextAnalytics.ExtractiveSummarySentencesOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtractKeyPhrasesAction
    {
        public ExtractKeyPhrasesAction() { }
        public ExtractKeyPhrasesAction(Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class ExtractKeyPhrasesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal ExtractKeyPhrasesActionResult() { }
        public Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class ExtractKeyPhrasesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal ExtractKeyPhrasesResult() { }
        public Azure.AI.TextAnalytics.KeyPhraseCollection KeyPhrases { get { throw null; } }
    }
    public partial class ExtractKeyPhrasesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.ExtractKeyPhrasesResult>
    {
        internal ExtractKeyPhrasesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.ExtractKeyPhrasesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class HealthcareEntity
    {
        internal HealthcareEntity() { }
        public Azure.AI.TextAnalytics.HealthcareEntityAssertion Assertion { get { throw null; } }
        public Azure.AI.TextAnalytics.HealthcareEntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.EntityDataSource> DataSources { get { throw null; } }
        public int Length { get { throw null; } }
        public string NormalizedText { get { throw null; } }
        public int Offset { get { throw null; } }
        public string SubCategory { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class HealthcareEntityAssertion
    {
        internal HealthcareEntityAssertion() { }
        public Azure.AI.TextAnalytics.EntityAssociation? Association { get { throw null; } }
        public Azure.AI.TextAnalytics.EntityCertainty? Certainty { get { throw null; } }
        public Azure.AI.TextAnalytics.EntityConditionality? Conditionality { get { throw null; } }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareEntityCategory : System.IEquatable<Azure.AI.TextAnalytics.HealthcareEntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareEntityCategory(string value) { throw null; }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory AdministrativeEvent { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Age { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory AGE { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Allergen { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory BodyStructure { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory CareEnvironment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory ConditionQualifier { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory ConditionScale { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Course { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Date { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Diagnosis { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Direction { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Dosage { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Employment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Ethnicity { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory ExaminationName { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Expression { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory FamilyRelation { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Frequency { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Gender { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory GeneOrProtein { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory GeneORProtein { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory HealthcareProfession { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory LivingStatus { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory MeasurementUnit { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory MeasurementValue { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory MedicationClass { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory MedicationForm { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory MedicationName { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory MedicationRoute { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory MutationType { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory RelationalOperator { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory SubstanceUse { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory SubstanceUseAmount { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory SymptomOrSign { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory SymptomORSign { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Time { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory TreatmentName { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityCategory Variant { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.HealthcareEntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.HealthcareEntityCategory left, Azure.AI.TextAnalytics.HealthcareEntityCategory right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.HealthcareEntityCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.HealthcareEntityCategory left, Azure.AI.TextAnalytics.HealthcareEntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareEntityRelation
    {
        internal HealthcareEntityRelation() { }
        public double? ConfidenceScore { get { throw null; } }
        public Azure.AI.TextAnalytics.HealthcareEntityRelationType RelationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.HealthcareEntityRelationRole> Roles { get { throw null; } }
    }
    public partial class HealthcareEntityRelationRole
    {
        internal HealthcareEntityRelationRole() { }
        public Azure.AI.TextAnalytics.HealthcareEntity Entity { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareEntityRelationType : System.IEquatable<Azure.AI.TextAnalytics.HealthcareEntityRelationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareEntityRelationType(string value) { throw null; }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType Abbreviation { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType BodySiteOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType BodySiteOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType CourseOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType CourseOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType CourseOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType CourseOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfBodyStructure { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DosageOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ExaminationFindsCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ExpressionOfGene { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ExpressionOfVariant { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType FormOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType FrequencyOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType FrequencyOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType FrequencyOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType MutationTypeOfGene { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType MutationTypeOfVariant { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType QualifierOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType RelationOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType RouteOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ScaleOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfEvent { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType UnitOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType UnitOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ValueOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ValueOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType VariantOfGene { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.HealthcareEntityRelationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.HealthcareEntityRelationType left, Azure.AI.TextAnalytics.HealthcareEntityRelationType right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.HealthcareEntityRelationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.HealthcareEntityRelationType left, Azure.AI.TextAnalytics.HealthcareEntityRelationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyPhraseCollection : System.Collections.ObjectModel.ReadOnlyCollection<string>
    {
        internal KeyPhraseCollection() : base (default(System.Collections.Generic.IList<string>)) { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedEntity
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string BingEntitySearchApiId { get { throw null; } }
        public string DataSource { get { throw null; } }
        public string DataSourceEntityId { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.LinkedEntityMatch> Matches { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class LinkedEntityCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.LinkedEntity>
    {
        internal LinkedEntityCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.LinkedEntity>)) { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedEntityMatch
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class MultiLabelClassifyAction
    {
        public MultiLabelClassifyAction(string projectName, string deploymentName) { }
        public string ActionName { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
    }
    public partial class MultiLabelClassifyActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal MultiLabelClassifyActionResult() { }
        public Azure.AI.TextAnalytics.ClassifyDocumentResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class MultiLabelClassifyOptions
    {
        public MultiLabelClassifyOptions() { }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IncludeStatistics { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiEntity
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.PiiEntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string SubCategory { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiEntityCategory : System.IEquatable<Azure.AI.TextAnalytics.PiiEntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiEntityCategory(string value) { throw null; }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ABARoutingNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Address { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Age { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory All { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ARNationalIdentityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ATIdentityCard { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ATTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ATValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AUBankAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AUBusinessNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AUCompanyNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AUDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AUMedicalAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AUPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AUTaxFileNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureDocumentDBAuthKey { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureIaasDatabaseConnectionAndSQLString { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureIoTConnectionString { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzurePublishSettingPassword { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureRedisCacheString { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureSAS { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureServiceBusString { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureStorageAccountGeneric { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory AzureStorageAccountKey { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory BENationalNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory BENationalNumberV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory BEValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory BGUniformCivilNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory BrcpfNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory BRLegalEntityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory BRNationalIdrg { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CABankAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CADriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CAHealthServiceNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CAPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CAPersonalHealthIdentification { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CASocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CHSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CLIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CNResidentIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CreditCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CYIdentityCard { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CYTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CZPersonalIdentityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory CZPersonalIdentityV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Date { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DEDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Default { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DEIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DEPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DETaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DEValueAddedNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DKPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DKPersonalIdentificationV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory DrugEnforcementAgencyNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EEPersonalIdentificationCode { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Email { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Esdni { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ESSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ESTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EUDebitCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EUDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EugpsCoordinates { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EUNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EUPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EUSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory EUTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FIEuropeanHealthNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FINationalID { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FINationalIDV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FIPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FRDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FRHealthInsuranceNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FRNationalID { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FRPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FRSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FRTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory FRValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory GRNationalIDCard { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory GRNationalIDV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory GRTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HKIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HRIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HRNationalIDNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HRPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HRPersonalIdentificationOIBNumberV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HUPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HUTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory HUValueAddedNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory IDIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory IEPersonalPublicServiceNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory IEPersonalPublicServiceNumberV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ILBankAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ILNationalID { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory INPermanentAccount { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory InternationalBankingAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory INUniqueIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory IPAddress { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ITDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ITFiscalCode { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ITValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPBankAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPMyNumberCorporate { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPMyNumberPersonal { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPResidenceCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory JPSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory KRResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory LTPersonalCode { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory LUNationalIdentificationNumberNatural { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory LUNationalIdentificationNumberNonNatural { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory LVPersonalCode { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory MTIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory MTTaxIDNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory MYIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NLCitizensServiceNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NLCitizensServiceNumberV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NLTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NLValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NOIdentityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NZBankAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NZDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NZInlandRevenueNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NZMinistryOfHealthNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory NZSocialWelfareNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Organization { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory Person { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PhoneNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PHUnifiedMultiPurposeIDNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PLIdentityCard { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PLNationalID { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PLNationalIDV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PLPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PlregonNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PLTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PTCitizenCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PTCitizenCardNumberV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory PTTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ROPersonalNumericalCode { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory RUPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory RUPassportNumberInternational { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SANationalID { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SENationalID { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SENationalIDV2 { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SEPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SETaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SGNationalRegistrationIdentityCardNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SITaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SIUniqueMasterCitizenNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SKPersonalNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SQLServerConnectionString { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory SwiftCode { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory THPopulationIdentificationCode { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory TRNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory TWNationalID { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory TWPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory TWResidentCertificate { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UAPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UAPassportNumberInternational { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UKDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UKElectoralRollNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UKNationalHealthNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UKNationalInsuranceNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UKUniqueTaxpayerNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory URL { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory USBankAccountNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory USDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory USIndividualTaxpayerIdentification { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory USSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory UsukPassportNumber { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiEntityCategory ZAIdentificationNumber { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.PiiEntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.PiiEntityCategory left, Azure.AI.TextAnalytics.PiiEntityCategory right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.PiiEntityCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.PiiEntityCategory left, Azure.AI.TextAnalytics.PiiEntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PiiEntityCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.PiiEntity>
    {
        internal PiiEntityCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.PiiEntity>)) { }
        public string RedactedText { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public enum PiiEntityDomain
    {
        None = 0,
        ProtectedHealthInformation = 1,
    }
    public partial class RecognizeCustomEntitiesAction
    {
        public RecognizeCustomEntitiesAction(string projectName, string deploymentName) { }
        public string ActionName { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
    }
    public partial class RecognizeCustomEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal RecognizeCustomEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class RecognizeCustomEntitiesOperation : Azure.PageableOperation<Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection>
    {
        protected RecognizeCustomEntitiesOperation() { }
        public RecognizeCustomEntitiesOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public virtual System.DateTimeOffset CreatedOn { get { throw null; } }
        public virtual string DisplayName { get { throw null; } }
        public virtual System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual System.DateTimeOffset LastModified { get { throw null; } }
        public virtual Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecognizeCustomEntitiesOptions
    {
        public RecognizeCustomEntitiesOptions() { }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IncludeStatistics { get { throw null; } set { } }
    }
    public partial class RecognizeCustomEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeEntitiesResult>
    {
        internal RecognizeCustomEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.RecognizeEntitiesResult>)) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class RecognizeEntitiesAction
    {
        public RecognizeEntitiesAction() { }
        public RecognizeEntitiesAction(Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class RecognizeEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal RecognizeEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class RecognizeEntitiesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal RecognizeEntitiesResult() { }
        public Azure.AI.TextAnalytics.CategorizedEntityCollection Entities { get { throw null; } }
    }
    public partial class RecognizeEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeEntitiesResult>
    {
        internal RecognizeEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.RecognizeEntitiesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class RecognizeLinkedEntitiesAction
    {
        public RecognizeLinkedEntitiesAction() { }
        public RecognizeLinkedEntitiesAction(Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class RecognizeLinkedEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal RecognizeLinkedEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class RecognizeLinkedEntitiesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal RecognizeLinkedEntitiesResult() { }
        public Azure.AI.TextAnalytics.LinkedEntityCollection Entities { get { throw null; } }
    }
    public partial class RecognizeLinkedEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult>
    {
        internal RecognizeLinkedEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class RecognizePiiEntitiesAction
    {
        public RecognizePiiEntitiesAction() { }
        public RecognizePiiEntitiesAction(Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions options) { }
        public string ActionName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.TextAnalytics.PiiEntityCategory> CategoriesFilter { get { throw null; } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public Azure.AI.TextAnalytics.PiiEntityDomain DomainFilter { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class RecognizePiiEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal RecognizePiiEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class RecognizePiiEntitiesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public RecognizePiiEntitiesOptions() { }
        public System.Collections.Generic.IList<Azure.AI.TextAnalytics.PiiEntityCategory> CategoriesFilter { get { throw null; } }
        public Azure.AI.TextAnalytics.PiiEntityDomain DomainFilter { get { throw null; } set { } }
    }
    public partial class RecognizePiiEntitiesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal RecognizePiiEntitiesResult() { }
        public Azure.AI.TextAnalytics.PiiEntityCollection Entities { get { throw null; } }
    }
    public partial class RecognizePiiEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.RecognizePiiEntitiesResult>
    {
        internal RecognizePiiEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.RecognizePiiEntitiesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SentenceOpinion
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AssessmentSentiment> Assessments { get { throw null; } }
        public Azure.AI.TextAnalytics.TargetSentiment Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SentenceSentiment
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.SentenceOpinion> Opinions { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class SentimentConfidenceScores
    {
        internal SentimentConfidenceScores() { }
        public double Negative { get { throw null; } }
        public double Neutral { get { throw null; } }
        public double Positive { get { throw null; } }
    }
    public partial class SingleLabelClassifyAction
    {
        public SingleLabelClassifyAction(string projectName, string deploymentName) { }
        public string ActionName { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
    }
    public partial class SingleLabelClassifyActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionResult
    {
        internal SingleLabelClassifyActionResult() { }
        public Azure.AI.TextAnalytics.ClassifyDocumentResultCollection DocumentsResults { get { throw null; } }
    }
    public partial class SingleLabelClassifyOptions
    {
        public SingleLabelClassifyOptions() { }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IncludeStatistics { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetSentiment
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class TextAnalyticsActionResult
    {
        internal TextAnalyticsActionResult() { }
        public string ActionName { get { throw null; } }
        public System.DateTimeOffset CompletedOn { get { throw null; } }
        public Azure.AI.TextAnalytics.TextAnalyticsError Error { get { throw null; } }
        public bool HasError { get { throw null; } }
    }
    public partial class TextAnalyticsActions
    {
        public TextAnalyticsActions() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AbstractiveSummarizeAction> AbstractiveSummarizeActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesAction> AnalyzeHealthcareEntitiesActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.AnalyzeSentimentAction> AnalyzeSentimentActions { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.ExtractiveSummarizeAction> ExtractiveSummarizeActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.ExtractKeyPhrasesAction> ExtractKeyPhrasesActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.MultiLabelClassifyAction> MultiLabelClassifyActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeCustomEntitiesAction> RecognizeCustomEntitiesActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeEntitiesAction> RecognizeEntitiesActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesAction> RecognizeLinkedEntitiesActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizePiiEntitiesAction> RecognizePiiEntitiesActions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.SingleLabelClassifyAction> SingleLabelClassifyActions { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnalyticsAudience : System.IEquatable<Azure.AI.TextAnalytics.TextAnalyticsAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAnalyticsAudience(string value) { throw null; }
        public static Azure.AI.TextAnalytics.TextAnalyticsAudience AzureChina { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.TextAnalyticsAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.TextAnalyticsAudience left, Azure.AI.TextAnalytics.TextAnalyticsAudience right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.TextAnalyticsAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.TextAnalyticsAudience left, Azure.AI.TextAnalytics.TextAnalyticsAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnalyticsClient
    {
        protected TextAnalyticsClient() { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.TextAnalytics.TextAnalyticsClientOptions options) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.TextAnalytics.TextAnalyticsClientOptions options) { }
        public virtual Azure.AI.TextAnalytics.AbstractiveSummarizeOperation AbstractiveSummarize(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AbstractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AbstractiveSummarizeOperation AbstractiveSummarize(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AbstractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AbstractiveSummarizeOperation> AbstractiveSummarizeAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AbstractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AbstractiveSummarizeOperation> AbstractiveSummarizeAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AbstractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeActionsOperation AnalyzeActions(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeActionsOperation AnalyzeActions(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, string language = null, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeActionsOperation> AnalyzeActionsAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeActionsOperation> AnalyzeActionsAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, string language = null, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation AnalyzeHealthcareEntities(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation AnalyzeHealthcareEntities(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation> AnalyzeHealthcareEntitiesAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation> AnalyzeHealthcareEntitiesAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DocumentSentiment> AnalyzeSentiment(string document, string language = null, Azure.AI.TextAnalytics.AnalyzeSentimentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.AI.TextAnalytics.DocumentSentiment> AnalyzeSentiment(string document, string language, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DocumentSentiment>> AnalyzeSentimentAsync(string document, string language = null, Azure.AI.TextAnalytics.AnalyzeSentimentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DocumentSentiment>> AnalyzeSentimentAsync(string document, string language, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeSentimentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeSentimentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(System.Collections.Generic.IEnumerable<string> documents, string language, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeSentimentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeSentimentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DetectedLanguage> DetectLanguage(string document, string countryHint = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DetectedLanguage>> DetectLanguageAsync(string document, string countryHint = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection> DetectLanguageBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.DetectLanguageInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection> DetectLanguageBatch(System.Collections.Generic.IEnumerable<string> documents, string countryHint = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection>> DetectLanguageBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.DetectLanguageInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection>> DetectLanguageBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string countryHint = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.AI.TextAnalytics.ExtractiveSummarizeOperation ExtractiveSummarize(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.ExtractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.ExtractiveSummarizeOperation ExtractiveSummarize(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.ExtractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ExtractiveSummarizeOperation> ExtractiveSummarizeAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.ExtractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ExtractiveSummarizeOperation> ExtractiveSummarizeAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.ExtractiveSummarizeOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.KeyPhraseCollection> ExtractKeyPhrases(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation MultiLabelClassify(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation MultiLabelClassify(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> MultiLabelClassifyAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> MultiLabelClassifyAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation RecognizeCustomEntities(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation RecognizeCustomEntities(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation> RecognizeCustomEntitiesAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation> RecognizeCustomEntitiesAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.CategorizedEntityCollection> RecognizeEntities(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.CategorizedEntityCollection>> RecognizeEntitiesAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.LinkedEntityCollection> RecognizeLinkedEntities(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.LinkedEntityCollection>> RecognizeLinkedEntitiesAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.PiiEntityCollection> RecognizePiiEntities(string document, string language = null, Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.PiiEntityCollection>> RecognizePiiEntitiesAsync(string document, string language = null, Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation SingleLabelClassify(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation SingleLabelClassify(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> SingleLabelClassifyAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> SingleLabelClassifyAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.AnalyzeActionsOperation StartAnalyzeActions(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.AnalyzeActionsOperation StartAnalyzeActions(System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, string language = null, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeActionsOperation> StartAnalyzeActionsAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeActionsOperation> StartAnalyzeActionsAsync(System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, string language = null, Azure.AI.TextAnalytics.AnalyzeActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation StartMultiLabelClassify(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation StartMultiLabelClassify(System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> StartMultiLabelClassifyAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> StartMultiLabelClassifyAsync(System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.MultiLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.RecognizeCustomEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation StartSingleLabelClassify(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AI.TextAnalytics.ClassifyDocumentOperation StartSingleLabelClassify(System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> StartSingleLabelClassifyAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, string projectName, string deploymentName, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.ClassifyDocumentOperation> StartSingleLabelClassifyAsync(System.Collections.Generic.IEnumerable<string> documents, string projectName, string deploymentName, string language = null, Azure.AI.TextAnalytics.SingleLabelClassifyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class TextAnalyticsClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalyticsClientOptions(Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion version = Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion.V2023_04_01) { }
        public Azure.AI.TextAnalytics.TextAnalyticsAudience? Audience { get { throw null; } set { } }
        public string DefaultCountryHint { get { throw null; } set { } }
        public string DefaultLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V3_0 = 1,
            V3_1 = 2,
            V2022_05_01 = 3,
            V2023_04_01 = 4,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnalyticsError
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.TextAnalyticsErrorCode ErrorCode { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnalyticsErrorCode : System.IEquatable<Azure.AI.TextAnalytics.TextAnalyticsErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly string EmptyRequest;
        public static readonly string InternalServerError;
        public static readonly string InvalidArgument;
        public static readonly string InvalidCountryHint;
        public static readonly string InvalidDocument;
        public static readonly string InvalidDocumentBatch;
        public static readonly string InvalidParameterValue;
        public static readonly string InvalidRequest;
        public static readonly string InvalidRequestBodyFormat;
        public static readonly string MissingInputRecords;
        public static readonly string ModelVersionIncorrect;
        public static readonly string NotFound;
        public static readonly string ServiceUnavailable;
        public static readonly string UnsupportedLanguageCode;
        public bool Equals(Azure.AI.TextAnalytics.TextAnalyticsErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.TextAnalyticsErrorCode left, Azure.AI.TextAnalytics.TextAnalyticsErrorCode right) { throw null; }
        public static explicit operator string (Azure.AI.TextAnalytics.TextAnalyticsErrorCode errorCode) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.TextAnalyticsErrorCode (string errorCode) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.TextAnalyticsErrorCode left, Azure.AI.TextAnalytics.TextAnalyticsErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnalyticsInput
    {
        internal TextAnalyticsInput() { }
        public string Id { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public static partial class TextAnalyticsModelFactory
    {
        public static Azure.AI.TextAnalytics.AbstractiveSummarizeActionResult AbstractiveSummarizeActionResult(Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.AbstractiveSummarizeActionResult AbstractiveSummarizeActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.AbstractiveSummarizeResult AbstractiveSummarizeResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AbstractiveSummary> summaries, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.AbstractiveSummarizeResult AbstractiveSummarizeResult(string id, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.AbstractiveSummarizeResultCollection AbstractiveSummarizeResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AbstractiveSummarizeResult> results, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.AbstractiveSummary AbstractiveSummary(string text, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AbstractiveSummaryContext> contexts) { throw null; }
        public static Azure.AI.TextAnalytics.AbstractiveSummaryContext AbstractiveSummaryContext(int offset, int length) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.AnalyzeActionsResult AnalyzeActionsResult(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResult, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeEntitiesActionResult> recognizeEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionsResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeSentimentActionResult> analyzeSentimentActionsResults) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.AnalyzeActionsResult AnalyzeActionsResult(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeEntitiesActionResult> recognizeEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeSentimentActionResult> analyzeSentimentActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.SingleLabelClassifyActionResult> singleLabelClassifyActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.MultiLabelClassifyActionResult> multiLabelClassifyActionResults) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.AnalyzeActionsResult AnalyzeActionsResult(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeEntitiesActionResult> recognizeEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeSentimentActionResult> analyzeSentimentActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.SingleLabelClassifyActionResult> singleLabelClassifyActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.MultiLabelClassifyActionResult> multiLabelClassifyActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeActionsResult AnalyzeActionsResult(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeEntitiesActionResult> recognizeEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeSentimentActionResult> analyzeSentimentActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.SingleLabelClassifyActionResult> singleLabelClassifyActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.MultiLabelClassifyActionResult> multiLabelClassifyActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractiveSummarizeActionResult> extractiveSummarizeActionResults, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AbstractiveSummarizeActionResult> abstractiveSummarizeActionResults) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesActionResult AnalyzeHealthcareEntitiesActionResult(Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesActionResult AnalyzeHealthcareEntitiesActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResult AnalyzeHealthcareEntitiesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.HealthcareEntity> healthcareEntities, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.HealthcareEntityRelation> entityRelations, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResult AnalyzeHealthcareEntitiesResult(string id, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection AnalyzeHealthcareEntitiesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.AnalyzeSentimentActionResult AnalyzeSentimentActionResult(Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeSentimentActionResult AnalyzeSentimentActionResult(Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.AnalyzeSentimentActionResult AnalyzeSentimentActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeSentimentActionResult AnalyzeSentimentActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeSentimentResult AnalyzeSentimentResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeSentimentResult AnalyzeSentimentResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.DocumentSentiment documentSentiment) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection AnalyzeSentimentResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeSentimentResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.AssessmentSentiment AssessmentSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, double positiveScore, double negativeScore, string text, bool isNegated, int offset, int length) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.CategorizedEntity CategorizedEntity(string text, string category, string subCategory, double score) { throw null; }
        public static Azure.AI.TextAnalytics.CategorizedEntity CategorizedEntity(string text, string category, string subCategory, double score, int offset, int length) { throw null; }
        public static Azure.AI.TextAnalytics.CategorizedEntityCollection CategorizedEntityCollection(System.Collections.Generic.IList<Azure.AI.TextAnalytics.CategorizedEntity> entities, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.ClassificationCategory ClassificationCategory(string category, double confidenceScore) { throw null; }
        public static Azure.AI.TextAnalytics.ClassificationCategoryCollection ClassificationCategoryCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ClassificationCategory> classificationList, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings) { throw null; }
        public static Azure.AI.TextAnalytics.ClassifyDocumentResult ClassifyDocumentResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.ClassifyDocumentResult ClassifyDocumentResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.ClassificationCategoryCollection documentClassificationCollection, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.ClassifyDocumentResultCollection ClassifyDocumentResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ClassifyDocumentResult> classificationResultList, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string projectName, string deploymentName) { throw null; }
        public static Azure.AI.TextAnalytics.DetectedLanguage DetectedLanguage(string name, string iso6391Name, double confidenceScore, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.DetectLanguageResult DetectLanguageResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.DetectLanguageResult DetectLanguageResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.DetectedLanguage detectedLanguage) { throw null; }
        public static Azure.AI.TextAnalytics.DetectLanguageResultCollection DetectLanguageResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.DetectLanguageResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.DocumentSentiment DocumentSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, double positiveScore, double neutralScore, double negativeScore, System.Collections.Generic.List<Azure.AI.TextAnalytics.SentenceSentiment> sentenceSentiments, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.EntityDataSource EntityDataSource(string name = null, string entityId = null) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractiveSummarizeActionResult ExtractiveSummarizeActionResult(Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractiveSummarizeActionResult ExtractiveSummarizeActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractiveSummarizeResult ExtractiveSummarizeResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractiveSummarySentence> sentences, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractiveSummarizeResult ExtractiveSummarizeResult(string id, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractiveSummarizeResultCollection ExtractiveSummarizeResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractiveSummarizeResult> results, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractiveSummarySentence ExtractiveSummarySentence(string text, double rankScore, int offset, int length) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult ExtractKeyPhrasesActionResult(Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult ExtractKeyPhrasesActionResult(Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult ExtractKeyPhrasesActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult ExtractKeyPhrasesActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesResult ExtractKeyPhrasesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesResult ExtractKeyPhrasesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.KeyPhraseCollection keyPhrases) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection ExtractKeyPhrasesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractKeyPhrasesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.HealthcareEntity HealthcareEntity(string text, string category, int offset, int length, double confidenceScore) { throw null; }
        public static Azure.AI.TextAnalytics.HealthcareEntityAssertion HealthcareEntityAssertion(Azure.AI.TextAnalytics.EntityConditionality? conditionality = default(Azure.AI.TextAnalytics.EntityConditionality?), Azure.AI.TextAnalytics.EntityCertainty? certainty = default(Azure.AI.TextAnalytics.EntityCertainty?), Azure.AI.TextAnalytics.EntityAssociation? association = default(Azure.AI.TextAnalytics.EntityAssociation?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.HealthcareEntityRelation HealthcareEntityRelation(Azure.AI.TextAnalytics.HealthcareEntityRelationType relationType, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.HealthcareEntityRelationRole> roles) { throw null; }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelation HealthcareEntityRelation(Azure.AI.TextAnalytics.HealthcareEntityRelationType relationType, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.HealthcareEntityRelationRole> roles, double? confidenceScore) { throw null; }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationRole HealthcareEntityRelationRole(string text, string category, int offset, int length, double confidenceScore, string entityName) { throw null; }
        public static Azure.AI.TextAnalytics.KeyPhraseCollection KeyPhraseCollection(System.Collections.Generic.IList<string> keyPhrases, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.LinkedEntity LinkedEntity(string name, string dataSourceEntityId, string language, string dataSource, System.Uri url, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.LinkedEntityMatch> matches) { throw null; }
        public static Azure.AI.TextAnalytics.LinkedEntity LinkedEntity(string name, string dataSourceEntityId, string language, string dataSource, System.Uri url, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.LinkedEntityMatch> matches, string bingEntitySearchApiId) { throw null; }
        public static Azure.AI.TextAnalytics.LinkedEntityCollection LinkedEntityCollection(System.Collections.Generic.IList<Azure.AI.TextAnalytics.LinkedEntity> entities, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.LinkedEntityMatch LinkedEntityMatch(string text, double score) { throw null; }
        public static Azure.AI.TextAnalytics.LinkedEntityMatch LinkedEntityMatch(string text, double score, int offset, int length) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.MultiLabelClassifyActionResult MultiLabelClassifyActionResult(Azure.AI.TextAnalytics.ClassifyDocumentResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.MultiLabelClassifyActionResult MultiLabelClassifyActionResult(Azure.AI.TextAnalytics.ClassifyDocumentResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.MultiLabelClassifyActionResult MultiLabelClassifyActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.MultiLabelClassifyActionResult MultiLabelClassifyActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.PiiEntity PiiEntity(string text, string category, string subCategory, double score, int offset, int length) { throw null; }
        public static Azure.AI.TextAnalytics.PiiEntityCollection PiiEntityCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.PiiEntity> entities, string redactedText, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult RecognizeCustomEntitiesActionResult(Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult RecognizeCustomEntitiesActionResult(Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult RecognizeCustomEntitiesActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeCustomEntitiesActionResult RecognizeCustomEntitiesActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeCustomEntitiesResultCollection RecognizeCustomEntitiesResultCollection(System.Collections.Generic.IList<Azure.AI.TextAnalytics.RecognizeEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string projectName, string deploymentName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizeEntitiesActionResult RecognizeEntitiesActionResult(Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesActionResult RecognizeEntitiesActionResult(Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizeEntitiesActionResult RecognizeEntitiesActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesActionResult RecognizeEntitiesActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesResult RecognizeEntitiesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesResult RecognizeEntitiesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.CategorizedEntityCollection entities) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection RecognizeEntitiesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult RecognizeLinkedEntitiesActionResult(Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult RecognizeLinkedEntitiesActionResult(Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult RecognizeLinkedEntitiesActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult RecognizeLinkedEntitiesActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult RecognizeLinkedEntitiesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult RecognizeLinkedEntitiesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.LinkedEntityCollection linkedEntities) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection RecognizeLinkedEntitiesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult RecognizePiiEntitiesActionResult(Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult RecognizePiiEntitiesActionResult(Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult RecognizePiiEntitiesActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult RecognizePiiEntitiesActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesResult RecognizePiiEntitiesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesResult RecognizePiiEntitiesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.PiiEntityCollection entities) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection RecognizePiiEntitiesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizePiiEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.SentenceOpinion SentenceOpinion(Azure.AI.TextAnalytics.TargetSentiment target, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AssessmentSentiment> assessments) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.SentenceSentiment SentenceSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore) { throw null; }
        public static Azure.AI.TextAnalytics.SentenceSentiment SentenceSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore, int offset, int length, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.SentenceOpinion> opinions) { throw null; }
        public static Azure.AI.TextAnalytics.SentimentConfidenceScores SentimentConfidenceScores(double positiveScore, double neutralScore, double negativeScore) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.SingleLabelClassifyActionResult SingleLabelClassifyActionResult(Azure.AI.TextAnalytics.ClassifyDocumentResultCollection result, System.DateTimeOffset completedOn) { throw null; }
        public static Azure.AI.TextAnalytics.SingleLabelClassifyActionResult SingleLabelClassifyActionResult(Azure.AI.TextAnalytics.ClassifyDocumentResultCollection result, string actionName, System.DateTimeOffset completedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.SingleLabelClassifyActionResult SingleLabelClassifyActionResult(System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.SingleLabelClassifyActionResult SingleLabelClassifyActionResult(string actionName, System.DateTimeOffset completedOn, string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.TargetSentiment TargetSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double negativeScore, int offset, int length) { throw null; }
        public static Azure.AI.TextAnalytics.TextAnalyticsError TextAnalyticsError(string code, string message, string target = null) { throw null; }
        public static Azure.AI.TextAnalytics.TextAnalyticsWarning TextAnalyticsWarning(string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.TextDocumentBatchStatistics TextDocumentBatchStatistics(int documentCount, int validDocumentCount, int invalidDocumentCount, long transactionCount) { throw null; }
        public static Azure.AI.TextAnalytics.TextDocumentStatistics TextDocumentStatistics(int characterCount, int transactionCount) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnalyticsOperationStatus : System.IEquatable<Azure.AI.TextAnalytics.TextAnalyticsOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAnalyticsOperationStatus(string value) { throw null; }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Cancelled { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Cancelling { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Failed { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Rejected { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Running { get { throw null; } }
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.TextAnalyticsOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.TextAnalyticsOperationStatus left, Azure.AI.TextAnalytics.TextAnalyticsOperationStatus right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.TextAnalyticsOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.TextAnalyticsOperationStatus left, Azure.AI.TextAnalytics.TextAnalyticsOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnalyticsRequestOptions
    {
        public TextAnalyticsRequestOptions() { }
        public bool? DisableServiceLogs { get { throw null; } set { } }
        public bool IncludeStatistics { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class TextAnalyticsResult
    {
        internal TextAnalyticsResult() { }
        public Azure.AI.TextAnalytics.TextAnalyticsError Error { get { throw null; } }
        public bool HasError { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnalyticsWarning
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string Message { get { throw null; } }
        public Azure.AI.TextAnalytics.TextAnalyticsWarningCode WarningCode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnalyticsWarningCode : System.IEquatable<Azure.AI.TextAnalytics.TextAnalyticsWarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly string DocumentTruncated;
        public static readonly string LongWordsInDocument;
        public bool Equals(Azure.AI.TextAnalytics.TextAnalyticsWarningCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.TextAnalyticsWarningCode left, Azure.AI.TextAnalytics.TextAnalyticsWarningCode right) { throw null; }
        public static explicit operator string (Azure.AI.TextAnalytics.TextAnalyticsWarningCode warningCode) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.TextAnalyticsWarningCode (string warningCode) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.TextAnalyticsWarningCode left, Azure.AI.TextAnalytics.TextAnalyticsWarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextDocumentBatchStatistics
    {
        internal TextDocumentBatchStatistics() { }
        public int DocumentCount { get { throw null; } }
        public int InvalidDocumentCount { get { throw null; } }
        public long TransactionCount { get { throw null; } }
        public int ValidDocumentCount { get { throw null; } }
    }
    public partial class TextDocumentInput : Azure.AI.TextAnalytics.TextAnalyticsInput
    {
        public TextDocumentInput(string id, string text) { }
        public string Language { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextDocumentStatistics
    {
        private readonly int _dummyPrimitive;
        public int CharacterCount { get { throw null; } }
        public int TransactionCount { get { throw null; } }
    }
    public enum TextSentiment
    {
        Positive = 0,
        Neutral = 1,
        Negative = 2,
        Mixed = 3,
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class TextAnalyticsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.TextAnalytics.TextAnalyticsClient, Azure.AI.TextAnalytics.TextAnalyticsClientOptions> AddTextAnalyticsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.TextAnalytics.TextAnalyticsClient, Azure.AI.TextAnalytics.TextAnalyticsClientOptions> AddTextAnalyticsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.TextAnalytics.TextAnalyticsClient, Azure.AI.TextAnalytics.TextAnalyticsClientOptions> AddTextAnalyticsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
