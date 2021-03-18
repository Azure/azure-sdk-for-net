namespace Azure.AI.TextAnalytics
{
    public partial class AnalyzeBatchActionsOperation : Azure.AI.TextAnalytics.PageableOperation<Azure.AI.TextAnalytics.AnalyzeBatchActionsResult>
    {
        public AnalyzeBatchActionsOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public int ActionsFailed { get { throw null; } }
        public int ActionsInProgress { get { throw null; } }
        public int ActionsSucceeded { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        public int TotalActions { get { throw null; } }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeBatchActionsResult> Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.AnalyzeBatchActionsResult> GetValues() { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeBatchActionsResult> GetValuesAsync() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeBatchActionsResult>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeBatchActionsResult>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalyzeBatchActionsOptions
    {
        public AnalyzeBatchActionsOptions() { }
        public bool IncludeStatistics { get { throw null; } set { } }
    }
    public partial class AnalyzeBatchActionsResult
    {
        internal AnalyzeBatchActionsResult() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.ExtractKeyPhrasesActionResult> ExtractKeyPhrasesActionsResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeEntitiesActionResult> RecognizeEntitiesActionsResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesActionResult> RecognizeLinkedEntitiesActionsResults { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizePiiEntitiesActionResult> RecognizePiiEntitiesActionsResults { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class AnalyzeHealthcareEntitiesOperation : Azure.AI.TextAnalytics.PageableOperation<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection>
    {
        public AnalyzeHealthcareEntitiesOperation(string operationId, Azure.AI.TextAnalytics.TextAnalyticsClient client) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.TextAnalytics.TextAnalyticsOperationStatus Status { get { throw null; } }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection> Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Pageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection> GetValues() { throw null; }
        public override Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection> GetValuesAsync() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection>>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AsyncPageable<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesResultCollection>>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalyzeHealthcareEntitiesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public AnalyzeHealthcareEntitiesOptions() { }
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
    public partial class ExtractKeyPhrasesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionDetails
    {
        internal ExtractKeyPhrasesActionResult() { }
        public Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection Result { get { throw null; } }
    }
    public partial class ExtractKeyPhrasesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public ExtractKeyPhrasesOptions() { }
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
        public string Category { get { throw null; } }
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
    }
    public partial class HealthcareEntityRelation
    {
        internal HealthcareEntityRelation() { }
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
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfBodyStructure { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DirectionOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType DosageOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType FormOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType FrequencyOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType FrequencyOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType QualifierOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType RelationOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType RouteOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfEvent { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfMedication { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType TimeOfTreatment { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType UnitOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType UnitOfExamination { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ValueOfCondition { get { throw null; } }
        public static Azure.AI.TextAnalytics.HealthcareEntityRelationType ValueOfExamination { get { throw null; } }
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
    public abstract partial class PageableOperation<T> : Azure.Operation<Azure.AsyncPageable<T>> where T : notnull
    {
        protected PageableOperation() { }
        public override Azure.AsyncPageable<T> Value { get { throw null; } }
        public abstract Azure.Pageable<T> GetValues();
        public abstract Azure.AsyncPageable<T> GetValuesAsync();
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
    public enum PiiEntityDomainType
    {
        ProtectedHealthInformation = 0,
    }
    public partial class RecognizeEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionDetails
    {
        internal RecognizeEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection Result { get { throw null; } }
    }
    public partial class RecognizeEntitiesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public RecognizeEntitiesOptions() { }
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
    public partial class RecognizeLinkedEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionDetails
    {
        internal RecognizeLinkedEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection Result { get { throw null; } }
    }
    public partial class RecognizeLinkedEntitiesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public RecognizeLinkedEntitiesOptions() { }
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
    public partial class RecognizePiiEntitiesActionResult : Azure.AI.TextAnalytics.TextAnalyticsActionDetails
    {
        internal RecognizePiiEntitiesActionResult() { }
        public Azure.AI.TextAnalytics.RecognizePiiEntitiesResultCollection Result { get { throw null; } }
    }
    public partial class RecognizePiiEntitiesOptions : Azure.AI.TextAnalytics.TextAnalyticsRequestOptions
    {
        public RecognizePiiEntitiesOptions() { }
        public System.Collections.Generic.IList<Azure.AI.TextAnalytics.PiiEntityCategory> CategoriesFilter { get { throw null; } }
        public Azure.AI.TextAnalytics.PiiEntityDomainType? DomainFilter { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.TextAnalytics.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.TextAnalytics.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.TextAnalytics.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.TextAnalytics.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.TextAnalytics.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.TextAnalytics.StringIndexType left, Azure.AI.TextAnalytics.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.TextAnalytics.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.TextAnalytics.StringIndexType left, Azure.AI.TextAnalytics.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class TextAnalyticsActionDetails
    {
        internal TextAnalyticsActionDetails() { }
        public System.DateTimeOffset CompletedOn { get { throw null; } }
        public Azure.AI.TextAnalytics.TextAnalyticsError Error { get { throw null; } }
        public bool HasError { get { throw null; } }
    }
    public partial class TextAnalyticsActions
    {
        public TextAnalyticsActions() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.ExtractKeyPhrasesOptions> ExtractKeyPhrasesOptions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeEntitiesOptions> RecognizeEntitiesOptions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesOptions> RecognizeLinkedEntitiesOptions { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.RecognizePiiEntitiesOptions> RecognizePiiEntitiesOptions { get { throw null; } set { } }
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
        public virtual Azure.AI.TextAnalytics.AnalyzeBatchActionsOperation StartAnalyzeBatchActions(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, Azure.AI.TextAnalytics.AnalyzeBatchActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeBatchActionsOperation StartAnalyzeBatchActions(System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, string language = null, Azure.AI.TextAnalytics.AnalyzeBatchActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeBatchActionsOperation> StartAnalyzeBatchActionsAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, Azure.AI.TextAnalytics.AnalyzeBatchActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeBatchActionsOperation> StartAnalyzeBatchActionsAsync(System.Collections.Generic.IEnumerable<string> documents, Azure.AI.TextAnalytics.TextAnalyticsActions actions, string language = null, Azure.AI.TextAnalytics.AnalyzeBatchActionsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.AnalyzeHealthcareEntitiesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class TextAnalyticsClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalyticsClientOptions(Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion version = Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion.V3_1_Preview_4) { }
        public string DefaultCountryHint { get { throw null; } set { } }
        public string DefaultLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V3_0 = 1,
            V3_1_Preview_4 = 2,
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
        public static Azure.AI.TextAnalytics.AssessmentSentiment AssessmentSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, double positiveScore, double negativeScore, string text, bool isNegated, int offset, int length) { throw null; }
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
        public static Azure.AI.TextAnalytics.LinkedEntityMatch LinkedEntityMatch(string text, double score, int offset, int length) { throw null; }
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
        public static Azure.AI.TextAnalytics.SentenceOpinion SentenceOpinion(Azure.AI.TextAnalytics.TargetSentiment target, System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.AssessmentSentiment> assessments) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AI.TextAnalytics.SentenceSentiment SentenceSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore) { throw null; }
        public static Azure.AI.TextAnalytics.SentenceSentiment SentenceSentiment(Azure.AI.TextAnalytics.TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore, int offset, int length, System.Collections.Generic.IReadOnlyList<Azure.AI.TextAnalytics.SentenceOpinion> opinions) { throw null; }
        public static Azure.AI.TextAnalytics.SentimentConfidenceScores SentimentConfidenceScores(double positiveScore, double neutralScore, double negativeScore) { throw null; }
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
        public static Azure.AI.TextAnalytics.TextAnalyticsOperationStatus PartiallySucceeded { get { throw null; } }
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
        public bool IncludeStatistics { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.TextAnalytics.StringIndexType StringIndexType { get { throw null; } set { } }
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
