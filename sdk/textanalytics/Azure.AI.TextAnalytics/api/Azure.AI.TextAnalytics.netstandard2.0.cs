namespace Azure.AI.TextAnalytics
{
    public partial class AnalyzeOperation : Azure.Operation<Azure.AI.TextAnalytics.AnalyzeOperationResult>
    {
        public AnalyzeOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.TextAnalytics.AnalyzeOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.TextAnalytics.AnalyzeOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.TextAnalytics.AnalyzeOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalyzeOperationOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public AnalyzeOperationOptions() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.AI.TextAnalytics.EntitiesTaskParameters EntitiesTaskParameters { get { throw null; } set { } }
        public Azure.AI.TextAnalytics.KeyPhrasesTaskParameters KeyPhrasesTaskParameters { get { throw null; } set { } }
        public Azure.AI.TextAnalytics.PiiTaskParameters PiiTaskParameters { get { throw null; } set { } }
    }
    public partial class AnalyzeOperationResult
    {
        internal AnalyzeOperationResult() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.TextAnalyticsError> Errors { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
        public Azure.AI.TextAnalytics.JobStatus Status { get { throw null; } }
        public Azure.AI.TextAnalytics.AnalyzeTasks Tasks { get { throw null; } }
    }
    public partial class AnalyzeSentimentOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public AnalyzeSentimentOptions() { }
        public bool IncludeOpinionMining { get { throw null; } set { } }
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
    public partial class AnalyzeTasks
    {
        internal AnalyzeTasks() { }
        public int Completed { get { throw null; } }
        public Azure.AI.TextAnalytics.TasksStateTasksDetails Details { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.EntityRecognitionPiiTasksItem> EntityRecognitionPiiTasks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.EntityRecognitionTasksItem> EntityRecognitionTasks { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.KeyPhraseExtractionTasksItem> KeyPhraseExtractionTasks { get { throw null; } }
        public int Total { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AspectSentiment
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategorizedEntity
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.EntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
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
    public partial class DocumentHealthcareResult
    {
        internal DocumentHealthcareResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.HealthcareEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.HealthcareRelation> Relations { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentStatistics? Statistics { get { throw null; } }
        public Azure.AI.TextAnalytics.TextAnalyticsError TextAnalyticsError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class DocumentSentiment
    {
        internal DocumentSentiment() { }
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.SentenceSentiment> Sentences { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class EntitiesTask
    {
        public EntitiesTask() { }
        public Azure.AI.TextAnalytics.EntitiesTaskParameters Parameters { get { throw null; } set { } }
    }
    public partial class EntitiesTaskParameters
    {
        public EntitiesTaskParameters() { }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class Entity
    {
        internal Entity() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
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
    public partial class EntityRecognitionPiiTasksItem : Azure.AI.TextAnalytics.TaskState
    {
        internal EntityRecognitionPiiTasksItem() { }
        public Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection Results { get { throw null; } }
    }
    public partial class EntityRecognitionTasksItem : Azure.AI.TextAnalytics.TaskState
    {
        internal EntityRecognitionTasksItem() { }
        public Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection Results { get { throw null; } }
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
    public partial class HealthcareEntity : Azure.AI.TextAnalytics.Entity
    {
        internal HealthcareEntity() { }
        public bool IsNegated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.HealthcareEntityLink> Links { get { throw null; } }
    }
    public partial class HealthcareEntityLink
    {
        internal HealthcareEntityLink() { }
        public string DataSource { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class HealthcareOperation : Azure.Operation<Azure.AI.TextAnalytics.RecognizeHealthcareEntitiesResultCollection>
    {
        public HealthcareOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.TextAnalytics.RecognizeHealthcareEntitiesResultCollection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.TextAnalytics.RecognizeHealthcareEntitiesResultCollection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.TextAnalytics.RecognizeHealthcareEntitiesResultCollection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthcareOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public HealthcareOptions() { }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class HealthcareRelation
    {
        internal HealthcareRelation() { }
        public bool Bidirectional { get { throw null; } }
        public string RelationType { get { throw null; } }
        public Azure.AI.TextAnalytics.HealthcareEntity Source { get { throw null; } }
        public Azure.AI.TextAnalytics.HealthcareEntity Target { get { throw null; } }
    }
    public partial class JobManifestTasks
    {
        public JobManifestTasks() { }
        public System.Collections.Generic.IList<Azure.AI.TextAnalytics.PiiTask> EntityRecognitionPiiTasks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.TextAnalytics.EntitiesTask> EntityRecognitionTasks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.TextAnalytics.KeyPhrasesTask> KeyPhraseExtractionTasks { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.AI.TextAnalytics.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.AI.TextAnalytics.JobStatus Cancelled { get { throw null; } }
        public static Azure.AI.TextAnalytics.JobStatus Cancelling { get { throw null; } }
        public static Azure.AI.TextAnalytics.JobStatus Failed { get { throw null; } }
        public static Azure.AI.TextAnalytics.JobStatus NotStarted { get { throw null; } }
        public static Azure.AI.TextAnalytics.JobStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.TextAnalytics.JobStatus Rejected { get { throw null; } }
        public static Azure.AI.TextAnalytics.JobStatus Running { get { throw null; } }
        public static Azure.AI.TextAnalytics.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.JobStatus left, Azure.AI.TextAnalytics.JobStatus right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.JobStatus left, Azure.AI.TextAnalytics.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyPhraseCollection : System.Collections.ObjectModel.ReadOnlyCollection<string>
    {
        internal KeyPhraseCollection() : base (default(System.Collections.Generic.IList<string>)) { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public partial class KeyPhraseExtractionTasksItem : Azure.AI.TextAnalytics.TaskState
    {
        internal KeyPhraseExtractionTasksItem() { }
        public Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection Results { get { throw null; } }
    }
    public partial class KeyPhrasesTask
    {
        public KeyPhrasesTask() { }
        public Azure.AI.TextAnalytics.KeyPhrasesTaskParameters Parameters { get { throw null; } set { } }
    }
    public partial class KeyPhrasesTaskParameters
    {
        public KeyPhrasesTaskParameters() { }
        public string ModelVersion { get { throw null; } set { } }
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
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MinedOpinion
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.AspectSentiment Aspect { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.OpinionSentiment> Opinions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpinionSentiment
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public bool IsNegated { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiEntity
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.EntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Offset { get { throw null; } }
        public string SubCategory { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class PiiEntityCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.PiiEntity>
    {
        internal PiiEntityCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.PiiEntity>)) { }
        public string RedactedText { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    public enum PiiEntityDomainType
    {
        ProtectedHealthInformation = 0,
    }
    public partial class PiiTask
    {
        public PiiTask() { }
        public Azure.AI.TextAnalytics.PiiTaskParameters Parameters { get { throw null; } set { } }
    }
    public partial class PiiTaskParameters
    {
        public PiiTaskParameters() { }
        public Azure.AI.TextAnalytics.PiiTaskParametersDomain? Domain { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiTaskParametersDomain : System.IEquatable<Azure.AI.TextAnalytics.PiiTaskParametersDomain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiTaskParametersDomain(string value) { throw null; }
        public static Azure.AI.TextAnalytics.PiiTaskParametersDomain None { get { throw null; } }
        public static Azure.AI.TextAnalytics.PiiTaskParametersDomain Phi { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.PiiTaskParametersDomain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.PiiTaskParametersDomain left, Azure.AI.TextAnalytics.PiiTaskParametersDomain right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.PiiTaskParametersDomain (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.PiiTaskParametersDomain left, Azure.AI.TextAnalytics.PiiTaskParametersDomain right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class RecognizeHealthcareEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.DocumentHealthcareResult>
    {
        internal RecognizeHealthcareEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.DocumentHealthcareResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
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
    public partial class RecognizePiiEntitiesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public RecognizePiiEntitiesOptions() { }
        public Azure.AI.TextAnalytics.PiiEntityDomainType DomainFilter { get { throw null; } set { } }
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
    public readonly partial struct SentenceSentiment
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.MinedOpinion> MinedOpinions { get { throw null; } }
        public int Offset { get { throw null; } }
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
    public partial class TasksStateTasksDetails : Azure.AI.TextAnalytics.TaskState
    {
        internal TasksStateTasksDetails() { }
    }
    public partial class TaskState
    {
        internal TaskState() { }
        public System.DateTimeOffset LastUpdateDateTime { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.TextAnalytics.JobStatus Status { get { throw null; } }
    }
    public partial class TextAnalyticsClient
    {
        protected TextAnalyticsClient() { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.TextAnalytics.TextAnalyticsClientOptions options) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.TextAnalytics.TextAnalyticsClientOptions options) { }
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
        public virtual Azure.Response<Azure.AI.TextAnalytics.KeyPhraseCollection> ExtractKeyPhrases(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.TextAnalytics.DocumentHealthcareResult> GetHealthcareEntities(Azure.AI.TextAnalytics.HealthcareOperation operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.AI.TextAnalytics.AnalyzeOperation StartAnalyzeOperationBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeOperationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeOperation StartAnalyzeOperationBatch(System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.AnalyzeOperationOptions options, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeOperation> StartAnalyzeOperationBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeOperationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeOperation> StartAnalyzeOperationBatchAsync(System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.AnalyzeOperationOptions options, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual string StartCancelHealthJob(Azure.AI.TextAnalytics.HealthcareOperation operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<string> StartCancelHealthJobAsync(Azure.AI.TextAnalytics.HealthcareOperation operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.HealthcareOperation StartHealthcare(string document, string language = null, Azure.AI.TextAnalytics.HealthcareOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.HealthcareOperation> StartHealthcareAsync(string document, string language = null, Azure.AI.TextAnalytics.HealthcareOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.HealthcareOperation StartHealthcareBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.HealthcareOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.HealthcareOperation StartHealthcareBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.HealthcareOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.HealthcareOperation> StartHealthcareBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.HealthcareOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.HealthcareOperation> StartHealthcareBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.HealthcareOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class TextAnalyticsClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalyticsClientOptions(Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion version = Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion.V3_1_Preview_3) { }
        public string DefaultCountryHint { get { throw null; } set { } }
        public string DefaultLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V3_0 = 1,
            V3_1_Preview_3 = 2,
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
        public static Azure.AI.TextAnalytics.AnalyzeSentimentResult AnalyzeSentimentResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeSentimentResult AnalyzeSentimentResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.DocumentSentiment documentSentiment) { throw null; }
        public static Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection AnalyzeSentimentResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.AnalyzeSentimentResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.AspectSentiment AspectSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double negativeScore, int offset) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.CategorizedEntity CategorizedEntity(string text, string category, string subCategory, double score) { throw null; }
        public static Azure.AI.TextAnalytics.CategorizedEntity CategorizedEntity(string text, string category, string subCategory, double score, int offset) { throw null; }
        public static Azure.AI.TextAnalytics.CategorizedEntityCollection CategorizedEntityCollection(System.Collections.Generic.IList<Azure.AI.TextAnalytics.CategorizedEntity> entities, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.DetectedLanguage DetectedLanguage(string name, string iso6391Name, double confidenceScore, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.DetectLanguageResult DetectLanguageResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.DetectLanguageResult DetectLanguageResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.DetectedLanguage detectedLanguage) { throw null; }
        public static Azure.AI.TextAnalytics.DetectLanguageResultCollection DetectLanguageResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.DetectLanguageResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.DocumentSentiment DocumentSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, double positiveScore, double neutralScore, double negativeScore, System.Collections.Generic.List<Azure.AI.TextAnalytics.SentenceSentiment> sentenceSentiments, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesResult ExtractKeyPhrasesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesResult ExtractKeyPhrasesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.KeyPhraseCollection keyPhrases) { throw null; }
        public static Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection ExtractKeyPhrasesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.ExtractKeyPhrasesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.KeyPhraseCollection KeyPhraseCollection(System.Collections.Generic.IList<string> keyPhrases, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.LinkedEntity LinkedEntity(string name, string dataSourceEntityId, string language, string dataSource, System.Uri url, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.LinkedEntityMatch> matches) { throw null; }
        public static Azure.AI.TextAnalytics.LinkedEntity LinkedEntity(string name, string dataSourceEntityId, string language, string dataSource, System.Uri url, System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.LinkedEntityMatch> matches, string bingEntitySearchApiId) { throw null; }
        public static Azure.AI.TextAnalytics.LinkedEntityCollection LinkedEntityCollection(System.Collections.Generic.IList<Azure.AI.TextAnalytics.LinkedEntity> entities, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.LinkedEntityMatch LinkedEntityMatch(string text, double score) { throw null; }
        public static Azure.AI.TextAnalytics.LinkedEntityMatch LinkedEntityMatch(string text, double score, int offset) { throw null; }
        public static Azure.AI.TextAnalytics.MinedOpinion MinedOpinion(Azure.AI.TextAnalytics.AspectSentiment aspect, System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.OpinionSentiment> opinions) { throw null; }
        public static Azure.AI.TextAnalytics.OpinionSentiment OpinionSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, double positiveScore, double negativeScore, string text, bool isNegated, int offset) { throw null; }
        public static Azure.AI.TextAnalytics.PiiEntity PiiEntity(string text, string category, string subCategory, double score, int offset) { throw null; }
        public static Azure.AI.TextAnalytics.PiiEntityCollection PiiEntityCollection(System.Collections.Generic.IList<Azure.AI.TextAnalytics.PiiEntity> entities, string redactedText, System.Collections.Generic.IList<Azure.AI.TextAnalytics.TextAnalyticsWarning> warnings = null) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesResult RecognizeEntitiesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesResult RecognizeEntitiesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.CategorizedEntityCollection entities) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection RecognizeEntitiesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult RecognizeLinkedEntitiesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult RecognizeLinkedEntitiesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.LinkedEntityCollection linkedEntities) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection RecognizeLinkedEntitiesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesResult RecognizePiiEntitiesResult(string id, Azure.AI.TextAnalytics.TextAnalyticsError error) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesResult RecognizePiiEntitiesResult(string id, Azure.AI.TextAnalytics.TextDocumentStatistics statistics, Azure.AI.TextAnalytics.PiiEntityCollection entities) { throw null; }
        public static Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection RecognizePiiEntitiesResultCollection(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.RecognizePiiEntitiesResult> list, Azure.AI.TextAnalytics.TextDocumentBatchStatistics statistics, string modelVersion) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.SentenceSentiment SentenceSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore) { throw null; }
        public static Azure.AI.TextAnalytics.SentenceSentiment SentenceSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore, int offset, System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.MinedOpinion> minedOpinions) { throw null; }
        public static Azure.AI.TextAnalytics.SentimentConfidenceScores SentimentConfidenceScores(double positiveScore, double neutralScore, double negativeScore) { throw null; }
        public static Azure.AI.TextAnalytics.TextAnalyticsError TextAnalyticsError(string code, string message, string target = null) { throw null; }
        public static Azure.AI.TextAnalytics.TextAnalyticsWarning TextAnalyticsWarning(string code, string message) { throw null; }
        public static Azure.AI.TextAnalytics.TextDocumentBatchStatistics TextDocumentBatchStatistics(int documentCount, int validDocumentCount, int invalidDocumentCount, long transactionCount) { throw null; }
        public static Azure.AI.TextAnalytics.TextDocumentStatistics TextDocumentStatistics(int characterCount, int transactionCount) { throw null; }
    }
    public partial class TextAnalyticsRequestOptions
    {
        public TextAnalyticsRequestOptions() { }
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
