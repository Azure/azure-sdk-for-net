namespace Azure.AI.TextAnalytics
{
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
    public readonly partial struct CategorizedEntity
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.EntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int GraphemeLength { get { throw null; } }
        public int GraphemeOffset { get { throw null; } }
        public string SubCategory { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DetectedLanguage
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string Iso6391Name { get { throw null; } }
        public string Name { get { throw null; } }
        public double Score { get { throw null; } }
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
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityCategory : System.IEquatable<Azure.AI.TextAnalytics.EntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
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
    public partial class ExtractKeyPhrasesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal ExtractKeyPhrasesResult() { }
        public System.Collections.Generic.IReadOnlyCollection<string> KeyPhrases { get { throw null; } }
    }
    public partial class ExtractKeyPhrasesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.ExtractKeyPhrasesResult>
    {
        internal ExtractKeyPhrasesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.ExtractKeyPhrasesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedEntity
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string DataSource { get { throw null; } }
        public string DataSourceEntityId { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.LinkedEntityMatch> Matches { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedEntityMatch
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public double ConfidenceScore { get { throw null; } }
        public int GraphemeLength { get { throw null; } }
        public int GraphemeOffset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class RecognizeEntitiesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal RecognizeEntitiesResult() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.CategorizedEntity> Entities { get { throw null; } }
    }
    public partial class RecognizeEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeEntitiesResult>
    {
        internal RecognizeEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.RecognizeEntitiesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    public partial class RecognizeLinkedEntitiesResult : Azure.AI.TextAnalytics.TextAnalyticsResult
    {
        internal RecognizeLinkedEntitiesResult() { }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.LinkedEntity> Entities { get { throw null; } }
    }
    public partial class RecognizeLinkedEntitiesResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult>
    {
        internal RecognizeLinkedEntitiesResultCollection() : base (default(System.Collections.Generic.IList<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResult>)) { }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentBatchStatistics Statistics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SentenceSentiment
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Azure.AI.TextAnalytics.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public int GraphemeLength { get { throw null; } }
        public int GraphemeOffset { get { throw null; } }
        public Azure.AI.TextAnalytics.TextSentiment Sentiment { get { throw null; } }
    }
    public partial class SentimentConfidenceScores
    {
        internal SentimentConfidenceScores() { }
        public double Negative { get { throw null; } }
        public double Neutral { get { throw null; } }
        public double Positive { get { throw null; } }
    }
    public partial class TextAnalyticsClient
    {
        protected TextAnalyticsClient() { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.TextAnalytics.TextAnalyticsClientOptions options) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.TextAnalytics.TextAnalyticsClientOptions options) { }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DocumentSentiment> AnalyzeSentiment(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DocumentSentiment>> AnalyzeSentimentAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DetectedLanguage> DetectLanguage(string document, string countryHint = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DetectedLanguage>> DetectLanguageAsync(string document, string countryHint = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection> DetectLanguageBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.DetectLanguageInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection> DetectLanguageBatch(System.Collections.Generic.IEnumerable<string> documents, string countryHint = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection>> DetectLanguageBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.DetectLanguageInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.DetectLanguageResultCollection>> DetectLanguageBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string countryHint = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyCollection<string>> ExtractKeyPhrases(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyCollection<string>>> ExtractKeyPhrasesAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.CategorizedEntity>> RecognizeEntities(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.CategorizedEntity>>> RecognizeEntitiesAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.LinkedEntity>> RecognizeLinkedEntities(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.LinkedEntity>>> RecognizeLinkedEntitiesAsync(string document, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(System.Collections.Generic.IEnumerable<Azure.AI.TextAnalytics.TextDocumentInput> documents, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.TextAnalytics.RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(System.Collections.Generic.IEnumerable<string> documents, string language = null, Azure.AI.TextAnalytics.TextAnalyticsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class TextAnalyticsClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalyticsClientOptions(Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion version = Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion.V3_0_preview_1) { }
        public string DefaultCountryHint { get { throw null; } set { } }
        public string DefaultLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V3_0_preview_1 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct TextAnalyticsError
    {
        private object _dummy;
        private int _dummyPrimitive;
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class TextAnalyticsInput
    {
        internal TextAnalyticsInput() { }
        public string Id { get { throw null; } }
        public string Text { get { throw null; } }
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
        public bool HasWarnings { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.TextAnalytics.TextDocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.AI.TextAnalytics.TextAnalyticsWarning> Warnings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct TextAnalyticsWarning
    {
        private object _dummy;
        private int _dummyPrimitive;
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
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
        public int GraphemeCount { get { throw null; } }
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
