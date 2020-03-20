namespace Azure.Search.Documents
{
    public partial class AutocompleteOptions : Azure.Search.Documents.SearchRequestOptions
    {
        public AutocompleteOptions() { }
        public string Filter { get { throw null; } set { } }
        public string HighlightPostTag { get { throw null; } set { } }
        public string HighlightPreTag { get { throw null; } set { } }
        public double? MinimumCoverage { get { throw null; } set { } }
        public Azure.Search.Documents.Models.AutocompleteMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchFields { get { throw null; } }
        public int? Size { get { throw null; } set { } }
        public bool? UseFuzzyMatching { get { throw null; } set { } }
    }
    public partial class GetDocumentOptions : Azure.Search.Documents.SearchRequestOptions
    {
        public GetDocumentOptions() { }
        public System.Collections.Generic.IList<string> SelectedFields { get { throw null; } }
    }
    public partial class IndexDocumentsOptions : Azure.Search.Documents.SearchRequestOptions
    {
        public IndexDocumentsOptions() { }
        public bool ThrowOnAnyError { get { throw null; } set { } }
    }
    public partial class SearchClientOptions : Azure.Core.ClientOptions
    {
        public SearchClientOptions(Azure.Search.Documents.SearchClientOptions.ServiceVersion version = Azure.Search.Documents.SearchClientOptions.ServiceVersion.V2019_05_06_Preview) { }
        public Azure.Search.Documents.SearchClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2019_05_06_Preview = 1,
        }
    }
    public static partial class SearchFilter
    {
        public static string Create(System.FormattableString filter) { throw null; }
        public static string Create(System.FormattableString filter, System.IFormatProvider formatProvider) { throw null; }
    }
    public partial class SearchIndexClient
    {
        protected SearchIndexClient() { }
        public SearchIndexClient(System.Uri endpoint, string indexName, Azure.AzureKeyCredential credential) { }
        public SearchIndexClient(System.Uri endpoint, string indexName, Azure.AzureKeyCredential credential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string IndexName { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<Azure.Search.Documents.Models.AutocompleteResults> Autocomplete(string searchText, string suggesterName, Azure.Search.Documents.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.AutocompleteResults>> AutocompleteAsync(string searchText, string suggesterName, Azure.Search.Documents.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchDocument> GetDocument(string key, Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchDocument>> GetDocumentAsync(string key, Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetDocumentAsync<T>(string key, Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<long> GetDocumentCount(Azure.Search.Documents.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<long>> GetDocumentCountAsync(Azure.Search.Documents.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetDocument<T>(string key, Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> IndexDocuments(Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> IndexDocumentsAsync(Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> IndexDocumentsAsync<T>(Azure.Search.Documents.Models.IndexDocumentsBatch<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> IndexDocuments<T>(Azure.Search.Documents.Models.IndexDocumentsBatch<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<Azure.Search.Documents.Models.SearchDocument>> Search(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<Azure.Search.Documents.Models.SearchDocument>>> SearchAsync(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SuggestResults<Azure.Search.Documents.Models.SearchDocument>> Suggest(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SuggestResults<Azure.Search.Documents.Models.SearchDocument>>> SuggestAsync(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>>> SuggestAsync<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>> Suggest<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchOptions : Azure.Search.Documents.SearchRequestOptions
    {
        public SearchOptions() { }
        public System.Collections.Generic.IList<string> Facets { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HighlightFields { get { throw null; } }
        public string HighlightPostTag { get { throw null; } set { } }
        public string HighlightPreTag { get { throw null; } set { } }
        public bool? IncludeTotalCount { get { throw null; } set { } }
        public double? MinimumCoverage { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OrderBy { get { throw null; } }
        public Azure.Search.Documents.Models.SearchQueryType? QueryType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScoringParameters { get { throw null; } }
        public string ScoringProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchFields { get { throw null; } }
        public Azure.Search.Documents.Models.SearchMode? SearchMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Select { get { throw null; } }
        public int? Size { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
    }
    public partial class SearchRequestOptions
    {
        public SearchRequestOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
    }
    public partial class SearchServiceClient
    {
        protected SearchServiceClient() { }
        public SearchServiceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public SearchServiceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Search.Documents.SearchIndexClient GetSearchIndexClient(string indexName) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchServiceStatistics> GetStatistics(Azure.Search.Documents.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchServiceStatistics>> GetStatisticsAsync(Azure.Search.Documents.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SuggestOptions : Azure.Search.Documents.SearchRequestOptions
    {
        public SuggestOptions() { }
        public string Filter { get { throw null; } set { } }
        public string HighlightPostTag { get { throw null; } set { } }
        public string HighlightPreTag { get { throw null; } set { } }
        public double? MinimumCoverage { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OrderBy { get { throw null; } }
        public System.Collections.Generic.IList<string> SearchFields { get { throw null; } }
        public System.Collections.Generic.IList<string> Select { get { throw null; } }
        public int? Size { get { throw null; } set { } }
        public bool? UseFuzzyMatching { get { throw null; } set { } }
    }
}
namespace Azure.Search.Documents.Models
{
    public partial class Analyzer
    {
        public Analyzer() { }
        public string Name { get { throw null; } set { } }
        public string ODataType { get { throw null; } }
    }
    public partial class AnalyzeRequest
    {
        public AnalyzeRequest() { }
        public Azure.Search.Documents.Models.AnalyzerName? Analyzer { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CharFilters { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.TokenFilterName> TokenFilters { get { throw null; } set { } }
        public Azure.Search.Documents.Models.TokenizerName? Tokenizer { get { throw null; } set { } }
    }
    public partial class AnalyzeResult
    {
        internal AnalyzeResult() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.TokenInfo> Tokens { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzerName : System.IEquatable<Azure.Search.Documents.Models.AnalyzerName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzerName(string value) { throw null; }
        public static Azure.Search.Documents.Models.AnalyzerName ArLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ArMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName BgLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName BgMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName BnMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName CaLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName CaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName CsLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName CsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName DaLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName DaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName DeLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName DeMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ElLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ElMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName EnLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName EnMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName EsLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName EsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName EtMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName EuLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName FaLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName FiLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName FiMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName FrLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName FrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName GaLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName GlLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName GuMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName HeMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName HiLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName HiMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName HrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName HuLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName HuMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName HyLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName IdLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName IdMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName IsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ItLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ItMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName JaLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName JaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName Keyword { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName KnMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName KoLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName KoMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName LtMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName LvLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName LvMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName MlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName MrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName MsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName NbMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName NlLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName NlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName NoLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName PaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName Pattern { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName PlLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName PlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName PtBRLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName PtBRMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName PtLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName PtMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName RoLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName RoMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName RuLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName RuMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName Simple { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName SkMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName SlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName SrCyrillicMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName SrLatinMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName StandardasciifoldingLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName StandardLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName Stop { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName SvLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName SvMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName TaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName TeMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ThLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ThMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName TrLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName TrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName UkMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName UrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ViMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName Whitespace { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ZhHansLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ZhHansMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ZhHantLucene { get { throw null; } }
        public static Azure.Search.Documents.Models.AnalyzerName ZhHantMicrosoft { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.AnalyzerName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.AnalyzerName left, Azure.Search.Documents.Models.AnalyzerName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.AnalyzerName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.AnalyzerName left, Azure.Search.Documents.Models.AnalyzerName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AsciiFoldingTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public AsciiFoldingTokenFilter() { }
        public bool? PreserveOriginal { get { throw null; } set { } }
    }
    public enum AutocompleteMode
    {
        OneTerm = 0,
        TwoTerms = 1,
        OneTermWithContext = 2,
    }
    public partial class AutocompleteResults
    {
        internal AutocompleteResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.Autocompletion> Results { get { throw null; } }
    }
    public partial class Autocompletion
    {
        internal Autocompletion() { }
        public string QueryPlusText { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class AzureActiveDirectoryApplicationCredentials
    {
        public AzureActiveDirectoryApplicationCredentials() { }
        public string ApplicationId { get { throw null; } set { } }
        public string ApplicationSecret { get { throw null; } set { } }
    }
    public partial class CharFilter
    {
        public CharFilter() { }
        public string Name { get { throw null; } set { } }
        public string ODataType { get { throw null; } }
    }
    public partial class CjkBigramTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public CjkBigramTokenFilter() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.CjkBigramTokenFilterScripts> IgnoreScripts { get { throw null; } set { } }
        public bool? OutputUnigrams { get { throw null; } set { } }
    }
    public enum CjkBigramTokenFilterScripts
    {
        Han = 0,
        Hiragana = 1,
        Katakana = 2,
        Hangul = 3,
    }
    public partial class ClassicTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public ClassicTokenizer() { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class CognitiveServicesAccount
    {
        public CognitiveServicesAccount() { }
        public string Description { get { throw null; } set { } }
        public string ODataType { get { throw null; } }
    }
    public partial class CognitiveServicesAccountKey : Azure.Search.Documents.Models.CognitiveServicesAccount
    {
        public CognitiveServicesAccountKey() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class CommonGramTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public CommonGramTokenFilter() { }
        public System.Collections.Generic.IList<string> CommonWords { get { throw null; } set { } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? UseQueryMode { get { throw null; } set { } }
    }
    public partial class ConditionalSkill : Azure.Search.Documents.Models.Skill
    {
        public ConditionalSkill() { }
    }
    public partial class CorsOptions
    {
        public CorsOptions() { }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } set { } }
        public long? MaxAgeInSeconds { get { throw null; } set { } }
    }
    public partial class CustomAnalyzer : Azure.Search.Documents.Models.Analyzer
    {
        public CustomAnalyzer() { }
        public System.Collections.Generic.IList<string> CharFilters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.TokenFilterName> TokenFilters { get { throw null; } set { } }
        public Azure.Search.Documents.Models.TokenizerName Tokenizer { get { throw null; } set { } }
    }
    public partial class DataChangeDetectionPolicy
    {
        public DataChangeDetectionPolicy() { }
        public string ODataType { get { throw null; } }
    }
    public partial class DataContainer
    {
        public DataContainer() { }
        public string Name { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class DataDeletionDetectionPolicy
    {
        public DataDeletionDetectionPolicy() { }
        public string ODataType { get { throw null; } }
    }
    public partial class DataSource
    {
        public DataSource() { }
        public Azure.Search.Documents.Models.DataContainer Container { get { throw null; } set { } }
        public Azure.Search.Documents.Models.DataSourceCredentials Credentials { get { throw null; } set { } }
        public Azure.Search.Documents.Models.DataChangeDetectionPolicy DataChangeDetectionPolicy { get { throw null; } set { } }
        public Azure.Search.Documents.Models.DataDeletionDetectionPolicy DataDeletionDetectionPolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Models.DataSourceType Type { get { throw null; } set { } }
    }
    public partial class DataSourceCredentials
    {
        public DataSourceCredentials() { }
        public string ConnectionString { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSourceType : System.IEquatable<Azure.Search.Documents.Models.DataSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSourceType(string value) { throw null; }
        public static Azure.Search.Documents.Models.DataSourceType AzureBlob { get { throw null; } }
        public static Azure.Search.Documents.Models.DataSourceType AzureSql { get { throw null; } }
        public static Azure.Search.Documents.Models.DataSourceType AzureTable { get { throw null; } }
        public static Azure.Search.Documents.Models.DataSourceType CosmosDb { get { throw null; } }
        public static Azure.Search.Documents.Models.DataSourceType MySql { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.DataSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.DataSourceType left, Azure.Search.Documents.Models.DataSourceType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.DataSourceType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.DataSourceType left, Azure.Search.Documents.Models.DataSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataType : System.IEquatable<Azure.Search.Documents.Models.DataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataType(string value) { throw null; }
        public static Azure.Search.Documents.Models.DataType EdmBoolean { get { throw null; } }
        public static Azure.Search.Documents.Models.DataType EdmComplexType { get { throw null; } }
        public static Azure.Search.Documents.Models.DataType EdmDateTimeOffset { get { throw null; } }
        public static Azure.Search.Documents.Models.DataType EdmDouble { get { throw null; } }
        public static Azure.Search.Documents.Models.DataType EdmGeographyPoint { get { throw null; } }
        public static Azure.Search.Documents.Models.DataType EdmInt32 { get { throw null; } }
        public static Azure.Search.Documents.Models.DataType EdmInt64 { get { throw null; } }
        public static Azure.Search.Documents.Models.DataType EdmString { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.DataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.DataType left, Azure.Search.Documents.Models.DataType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.DataType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.DataType left, Azure.Search.Documents.Models.DataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DefaultCognitiveServicesAccount : Azure.Search.Documents.Models.CognitiveServicesAccount
    {
        public DefaultCognitiveServicesAccount() { }
    }
    public partial class DictionaryDecompounderTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public DictionaryDecompounderTokenFilter() { }
        public int? MaxSubwordSize { get { throw null; } set { } }
        public int? MinSubwordSize { get { throw null; } set { } }
        public int? MinWordSize { get { throw null; } set { } }
        public bool? OnlyLongestMatch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> WordList { get { throw null; } set { } }
    }
    public partial class DistanceScoringFunction : Azure.Search.Documents.Models.ScoringFunction
    {
        public DistanceScoringFunction() { }
        public Azure.Search.Documents.Models.DistanceScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class DistanceScoringParameters
    {
        public DistanceScoringParameters() { }
        public double BoostingDistance { get { throw null; } set { } }
        public string ReferencePointParameter { get { throw null; } set { } }
    }
    public partial class EdgeNGramTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public EdgeNGramTokenFilter() { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public Azure.Search.Documents.Models.EdgeNGramTokenFilterSide? Side { get { throw null; } set { } }
    }
    public enum EdgeNGramTokenFilterSide
    {
        Front = 0,
        Back = 1,
    }
    public partial class EdgeNGramTokenFilterV2 : Azure.Search.Documents.Models.TokenFilter
    {
        public EdgeNGramTokenFilterV2() { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public Azure.Search.Documents.Models.EdgeNGramTokenFilterSide? Side { get { throw null; } set { } }
    }
    public partial class EdgeNGramTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public EdgeNGramTokenizer() { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.TokenCharacterKind> TokenChars { get { throw null; } set { } }
    }
    public partial class ElisionTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public ElisionTokenFilter() { }
        public System.Collections.Generic.IList<string> Articles { get { throw null; } set { } }
    }
    public partial class EncryptionKey
    {
        public EncryptionKey() { }
        public Azure.Search.Documents.Models.AzureActiveDirectoryApplicationCredentials AccessCredentials { get { throw null; } set { } }
        public string KeyVaultKeyName { get { throw null; } set { } }
        public string KeyVaultKeyVersion { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
    }
    public enum EntityCategory
    {
        Location = 0,
        Organization = 1,
        Person = 2,
        Quantity = 3,
        Datetime = 4,
        Url = 5,
        Email = 6,
    }
    public partial class EntityRecognitionSkill : Azure.Search.Documents.Models.Skill
    {
        public EntityRecognitionSkill() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.EntityCategory> Categories { get { throw null; } set { } }
        public Azure.Search.Documents.Models.EntityRecognitionSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? IncludeTypelessEntities { get { throw null; } set { } }
        public double? MinimumPrecision { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityRecognitionSkillLanguage : System.IEquatable<Azure.Search.Documents.Models.EntityRecognitionSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityRecognitionSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage No { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage PtBR { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Models.EntityRecognitionSkillLanguage ZhHant { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.EntityRecognitionSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.EntityRecognitionSkillLanguage left, Azure.Search.Documents.Models.EntityRecognitionSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.EntityRecognitionSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.EntityRecognitionSkillLanguage left, Azure.Search.Documents.Models.EntityRecognitionSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FacetResult : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        internal FacetResult() { }
        public long? Count { get { throw null; } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class FieldMapping
    {
        public FieldMapping() { }
        public Azure.Search.Documents.Models.FieldMappingFunction MappingFunction { get { throw null; } set { } }
        public string SourceFieldName { get { throw null; } set { } }
        public string TargetFieldName { get { throw null; } set { } }
    }
    public partial class FieldMappingFunction
    {
        public FieldMappingFunction() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } set { } }
    }
    public partial class FreshnessScoringFunction : Azure.Search.Documents.Models.ScoringFunction
    {
        public FreshnessScoringFunction() { }
        public Azure.Search.Documents.Models.FreshnessScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class FreshnessScoringParameters
    {
        public FreshnessScoringParameters() { }
        public System.TimeSpan BoostingDuration { get { throw null; } set { } }
    }
    public partial class GetIndexStatisticsResult
    {
        internal GetIndexStatisticsResult() { }
        public long DocumentCount { get { throw null; } }
        public long StorageSize { get { throw null; } }
    }
    public partial class HighWaterMarkChangeDetectionPolicy : Azure.Search.Documents.Models.DataChangeDetectionPolicy
    {
        public HighWaterMarkChangeDetectionPolicy() { }
        public string HighWaterMarkColumnName { get { throw null; } set { } }
    }
    public partial class ImageAnalysisSkill : Azure.Search.Documents.Models.Skill
    {
        public ImageAnalysisSkill() { }
        public Azure.Search.Documents.Models.ImageAnalysisSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.ImageDetail> Details { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.VisualFeature> VisualFeatures { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageAnalysisSkillLanguage : System.IEquatable<Azure.Search.Documents.Models.ImageAnalysisSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageAnalysisSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.ImageAnalysisSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Models.ImageAnalysisSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Models.ImageAnalysisSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Models.ImageAnalysisSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Models.ImageAnalysisSkillLanguage Zh { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.ImageAnalysisSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.ImageAnalysisSkillLanguage left, Azure.Search.Documents.Models.ImageAnalysisSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.ImageAnalysisSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.ImageAnalysisSkillLanguage left, Azure.Search.Documents.Models.ImageAnalysisSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ImageDetail
    {
        Celebrities = 0,
        Landmarks = 1,
    }
    public enum IndexActionType
    {
        Upload = 0,
        Merge = 1,
        MergeOrUpload = 2,
        Delete = 3,
    }
    public static partial class IndexDocumentsAction
    {
        public static Azure.Search.Documents.Models.IndexDocumentsAction<Azure.Search.Documents.Models.SearchDocument> Delete(Azure.Search.Documents.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<Azure.Search.Documents.Models.SearchDocument> Delete(string keyName, string keyValue) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<T> Delete<T>(T document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<Azure.Search.Documents.Models.SearchDocument> Merge(Azure.Search.Documents.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<Azure.Search.Documents.Models.SearchDocument> MergeOrUpload(Azure.Search.Documents.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<T> MergeOrUpload<T>(T document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<T> Merge<T>(T document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<Azure.Search.Documents.Models.SearchDocument> Upload(Azure.Search.Documents.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<T> Upload<T>(T document) { throw null; }
    }
    public partial class IndexDocumentsAction<T>
    {
        public IndexDocumentsAction(Azure.Search.Documents.Models.IndexActionType type, T doc) { }
        public Azure.Search.Documents.Models.IndexActionType ActionType { get { throw null; } }
        public T Document { get { throw null; } }
    }
    public static partial class IndexDocumentsBatch
    {
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> Create<T>(params Azure.Search.Documents.Models.IndexDocumentsAction<T>[] actions) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> Delete(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> Delete(string keyName, System.Collections.Generic.IEnumerable<string> keyValues) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> Delete<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> Merge(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> MergeOrUpload(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> MergeOrUpload<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> Merge<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> Upload(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> Upload<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
    }
    public partial class IndexDocumentsBatch<T>
    {
        public IndexDocumentsBatch() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.IndexDocumentsAction<T>> Actions { get { throw null; } }
    }
    public partial class IndexDocumentsResult
    {
        internal IndexDocumentsResult() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.IndexingResult> Results { get { throw null; } }
    }
    public partial class IndexerExecutionInfo
    {
        internal IndexerExecutionInfo() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.IndexerExecutionResult> ExecutionHistory { get { throw null; } }
        public Azure.Search.Documents.Models.IndexerExecutionResult LastResult { get { throw null; } }
        public Azure.Search.Documents.Models.IndexerLimits Limits { get { throw null; } }
        public Azure.Search.Documents.Models.IndexerStatus Status { get { throw null; } }
    }
    public partial class IndexerExecutionResult
    {
        internal IndexerExecutionResult() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.ItemError> Errors { get { throw null; } }
        public int FailedItemCount { get { throw null; } }
        public string FinalTrackingState { get { throw null; } }
        public string InitialTrackingState { get { throw null; } }
        public int ItemCount { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Search.Documents.Models.IndexerExecutionStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.ItemWarning> Warnings { get { throw null; } }
    }
    public enum IndexerExecutionStatus
    {
        TransientFailure = 0,
        Success = 1,
        InProgress = 2,
        Reset = 3,
    }
    public partial class IndexerLimits
    {
        internal IndexerLimits() { }
        public long? MaxDocumentContentCharactersToExtract { get { throw null; } }
        public long? MaxDocumentExtractionSize { get { throw null; } }
        public System.TimeSpan? MaxRunTime { get { throw null; } }
    }
    public enum IndexerStatus
    {
        Unknown = 0,
        Error = 1,
        Running = 2,
    }
    public partial class IndexingParameters
    {
        public IndexingParameters() { }
        public int? BatchSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Configuration { get { throw null; } set { } }
        public int? MaxFailedItems { get { throw null; } set { } }
        public int? MaxFailedItemsPerBatch { get { throw null; } set { } }
    }
    public partial class IndexingResult
    {
        internal IndexingResult() { }
        public string ErrorMessage { get { throw null; } }
        public string Key { get { throw null; } }
        public int Status { get { throw null; } }
        public bool Succeeded { get { throw null; } }
    }
    public partial class IndexingSchedule
    {
        public IndexingSchedule() { }
        public System.TimeSpan Interval { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
    }
    public partial class InputFieldMappingEntry
    {
        public InputFieldMappingEntry() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.InputFieldMappingEntry> Inputs { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string SourceContext { get { throw null; } set { } }
    }
    public partial class ItemError
    {
        internal ItemError() { }
        public string Details { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Key { get { throw null; } }
        public string Name { get { throw null; } }
        public int StatusCode { get { throw null; } }
    }
    public partial class ItemWarning
    {
        internal ItemWarning() { }
        public string Details { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public string Key { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class KeepTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public KeepTokenFilter() { }
        public System.Collections.Generic.IList<string> KeepWords { get { throw null; } set { } }
        public bool? LowerCaseKeepWords { get { throw null; } set { } }
    }
    public partial class KeyPhraseExtractionSkill : Azure.Search.Documents.Models.Skill
    {
        public KeyPhraseExtractionSkill() { }
        public Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public int? MaxKeyPhraseCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyPhraseExtractionSkillLanguage : System.IEquatable<Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyPhraseExtractionSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage No { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage PtBR { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage Sv { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage left, Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage left, Azure.Search.Documents.Models.KeyPhraseExtractionSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeywordMarkerTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public KeywordMarkerTokenFilter() { }
        public bool? IgnoreCase { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } set { } }
    }
    public partial class KeywordTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public KeywordTokenizer() { }
        public int? BufferSize { get { throw null; } set { } }
    }
    public partial class KeywordTokenizerV2 : Azure.Search.Documents.Models.Tokenizer
    {
        public KeywordTokenizerV2() { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class LanguageDetectionSkill : Azure.Search.Documents.Models.Skill
    {
        public LanguageDetectionSkill() { }
    }
    public partial class LengthTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public LengthTokenFilter() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
    }
    public partial class LimitTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public LimitTokenFilter() { }
        public bool? ConsumeAllTokens { get { throw null; } set { } }
        public int? MaxTokenCount { get { throw null; } set { } }
    }
    public partial class ListSynonymMapsResult
    {
        internal ListSynonymMapsResult() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.SynonymMap> SynonymMaps { get { throw null; } }
    }
    public partial class MagnitudeScoringFunction : Azure.Search.Documents.Models.ScoringFunction
    {
        public MagnitudeScoringFunction() { }
        public Azure.Search.Documents.Models.MagnitudeScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class MagnitudeScoringParameters
    {
        public MagnitudeScoringParameters() { }
        public double BoostingRangeEnd { get { throw null; } set { } }
        public double BoostingRangeStart { get { throw null; } set { } }
        public bool? ShouldBoostBeyondRangeByConstant { get { throw null; } set { } }
    }
    public partial class MappingCharFilter : Azure.Search.Documents.Models.CharFilter
    {
        public MappingCharFilter() { }
        public System.Collections.Generic.IList<string> Mappings { get { throw null; } set { } }
    }
    public partial class MergeSkill : Azure.Search.Documents.Models.Skill
    {
        public MergeSkill() { }
        public string InsertPostTag { get { throw null; } set { } }
        public string InsertPreTag { get { throw null; } set { } }
    }
    public partial class MicrosoftLanguageStemmingTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public MicrosoftLanguageStemmingTokenizer() { }
        public bool? IsSearchTokenizer { get { throw null; } set { } }
        public Azure.Search.Documents.Models.MicrosoftStemmingTokenizerLanguage? Language { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class MicrosoftLanguageTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public MicrosoftLanguageTokenizer() { }
        public bool? IsSearchTokenizer { get { throw null; } set { } }
        public Azure.Search.Documents.Models.MicrosoftTokenizerLanguage? Language { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public enum MicrosoftStemmingTokenizerLanguage
    {
        Arabic = 0,
        Bangla = 1,
        Bulgarian = 2,
        Catalan = 3,
        Croatian = 4,
        Czech = 5,
        Danish = 6,
        Dutch = 7,
        English = 8,
        Estonian = 9,
        Finnish = 10,
        French = 11,
        German = 12,
        Greek = 13,
        Gujarati = 14,
        Hebrew = 15,
        Hindi = 16,
        Hungarian = 17,
        Icelandic = 18,
        Indonesian = 19,
        Italian = 20,
        Kannada = 21,
        Latvian = 22,
        Lithuanian = 23,
        Malay = 24,
        Malayalam = 25,
        Marathi = 26,
        NorwegianBokmaal = 27,
        Polish = 28,
        Portuguese = 29,
        PortugueseBrazilian = 30,
        Punjabi = 31,
        Romanian = 32,
        Russian = 33,
        SerbianCyrillic = 34,
        SerbianLatin = 35,
        Slovak = 36,
        Slovenian = 37,
        Spanish = 38,
        Swedish = 39,
        Tamil = 40,
        Telugu = 41,
        Turkish = 42,
        Ukrainian = 43,
        Urdu = 44,
    }
    public enum MicrosoftTokenizerLanguage
    {
        Bangla = 0,
        Bulgarian = 1,
        Catalan = 2,
        ChineseSimplified = 3,
        ChineseTraditional = 4,
        Croatian = 5,
        Czech = 6,
        Danish = 7,
        Dutch = 8,
        English = 9,
        French = 10,
        German = 11,
        Greek = 12,
        Gujarati = 13,
        Hindi = 14,
        Icelandic = 15,
        Indonesian = 16,
        Italian = 17,
        Japanese = 18,
        Kannada = 19,
        Korean = 20,
        Malay = 21,
        Malayalam = 22,
        Marathi = 23,
        NorwegianBokmaal = 24,
        Polish = 25,
        Portuguese = 26,
        PortugueseBrazilian = 27,
        Punjabi = 28,
        Romanian = 29,
        Russian = 30,
        SerbianCyrillic = 31,
        SerbianLatin = 32,
        Slovenian = 33,
        Spanish = 34,
        Swedish = 35,
        Tamil = 36,
        Telugu = 37,
        Thai = 38,
        Ukrainian = 39,
        Urdu = 40,
        Vietnamese = 41,
    }
    public partial class NGramTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public NGramTokenFilter() { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
    }
    public partial class NGramTokenFilterV2 : Azure.Search.Documents.Models.TokenFilter
    {
        public NGramTokenFilterV2() { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
    }
    public partial class NGramTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public NGramTokenizer() { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.TokenCharacterKind> TokenChars { get { throw null; } set { } }
    }
    public partial class OcrSkill : Azure.Search.Documents.Models.Skill
    {
        public OcrSkill() { }
        public Azure.Search.Documents.Models.OcrSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? ShouldDetectOrientation { get { throw null; } set { } }
        public Azure.Search.Documents.Models.TextExtractionAlgorithm? TextExtractionAlgorithm { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OcrSkillLanguage : System.IEquatable<Azure.Search.Documents.Models.OcrSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OcrSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Ro { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Sk { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage SrCyrl { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage SrLatn { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Models.OcrSkillLanguage ZhHant { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.OcrSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.OcrSkillLanguage left, Azure.Search.Documents.Models.OcrSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.OcrSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.OcrSkillLanguage left, Azure.Search.Documents.Models.OcrSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputFieldMappingEntry
    {
        public OutputFieldMappingEntry() { }
        public string Name { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    public partial class PathHierarchyTokenizerV2 : Azure.Search.Documents.Models.Tokenizer
    {
        public PathHierarchyTokenizerV2() { }
        public char? Delimiter { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
        public int? NumberOfTokensToSkip { get { throw null; } set { } }
        public char? Replacement { get { throw null; } set { } }
        public bool? ReverseTokenOrder { get { throw null; } set { } }
    }
    public partial class PatternAnalyzer : Azure.Search.Documents.Models.Analyzer
    {
        public PatternAnalyzer() { }
        public Azure.Search.Documents.Models.RegexFlags? Flags { get { throw null; } set { } }
        public bool? LowerCaseTerms { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } set { } }
    }
    public partial class PatternCaptureTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public PatternCaptureTokenFilter() { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } set { } }
        public bool? PreserveOriginal { get { throw null; } set { } }
    }
    public partial class PatternReplaceCharFilter : Azure.Search.Documents.Models.CharFilter
    {
        public PatternReplaceCharFilter() { }
        public string Pattern { get { throw null; } set { } }
        public string Replacement { get { throw null; } set { } }
    }
    public partial class PatternReplaceTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public PatternReplaceTokenFilter() { }
        public string Pattern { get { throw null; } set { } }
        public string Replacement { get { throw null; } set { } }
    }
    public partial class PatternTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public PatternTokenizer() { }
        public Azure.Search.Documents.Models.RegexFlags? Flags { get { throw null; } set { } }
        public int? Group { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
    }
    public enum PhoneticEncoder
    {
        Metaphone = 0,
        DoubleMetaphone = 1,
        Soundex = 2,
        RefinedSoundex = 3,
        Caverphone1 = 4,
        Caverphone2 = 5,
        Cologne = 6,
        Nysiis = 7,
        KoelnerPhonetik = 8,
        HaasePhonetik = 9,
        BeiderMorse = 10,
    }
    public partial class PhoneticTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public PhoneticTokenFilter() { }
        public Azure.Search.Documents.Models.PhoneticEncoder? Encoder { get { throw null; } set { } }
        public bool? ReplaceOriginalTokens { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegexFlags : System.IEquatable<Azure.Search.Documents.Models.RegexFlags>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegexFlags(string value) { throw null; }
        public static Azure.Search.Documents.Models.RegexFlags CanonEQ { get { throw null; } }
        public static Azure.Search.Documents.Models.RegexFlags CaseInsensitive { get { throw null; } }
        public static Azure.Search.Documents.Models.RegexFlags Comments { get { throw null; } }
        public static Azure.Search.Documents.Models.RegexFlags Dotall { get { throw null; } }
        public static Azure.Search.Documents.Models.RegexFlags Literal { get { throw null; } }
        public static Azure.Search.Documents.Models.RegexFlags Multiline { get { throw null; } }
        public static Azure.Search.Documents.Models.RegexFlags UnicodeCase { get { throw null; } }
        public static Azure.Search.Documents.Models.RegexFlags UnixLines { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.RegexFlags other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.RegexFlags left, Azure.Search.Documents.Models.RegexFlags right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.RegexFlags (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.RegexFlags left, Azure.Search.Documents.Models.RegexFlags right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScoringFunction
    {
        public ScoringFunction() { }
        public double Boost { get { throw null; } set { } }
        public string FieldName { get { throw null; } set { } }
        public Azure.Search.Documents.Models.ScoringFunctionInterpolation? Interpolation { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public enum ScoringFunctionAggregation
    {
        Sum = 0,
        Average = 1,
        Minimum = 2,
        Maximum = 3,
        FirstMatching = 4,
    }
    public enum ScoringFunctionInterpolation
    {
        Linear = 0,
        Constant = 1,
        Quadratic = 2,
        Logarithmic = 3,
    }
    public partial class ScoringProfile
    {
        public ScoringProfile() { }
        public Azure.Search.Documents.Models.ScoringFunctionAggregation? FunctionAggregation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.ScoringFunction> Functions { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Models.TextWeights TextWeights { get { throw null; } set { } }
    }
    public partial class SearchDocument : System.Dynamic.DynamicObject, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public SearchDocument() { }
        public SearchDocument(System.Collections.Generic.IDictionary<string, object> values) { }
        public int Count { get { throw null; } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public void Clear() { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> item) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public override string ToString() { throw null; }
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result) { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
        public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value) { throw null; }
    }
    public partial class SearchField
    {
        public SearchField() { }
        public Azure.Search.Documents.Models.AnalyzerName? Analyzer { get { throw null; } set { } }
        public bool? Facetable { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.SearchField> Fields { get { throw null; } set { } }
        public bool? Filterable { get { throw null; } set { } }
        public Azure.Search.Documents.Models.AnalyzerName? IndexAnalyzer { get { throw null; } set { } }
        public bool? Key { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? Retrievable { get { throw null; } set { } }
        public bool? Searchable { get { throw null; } set { } }
        public Azure.Search.Documents.Models.AnalyzerName? SearchAnalyzer { get { throw null; } set { } }
        public bool? Sortable { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SynonymMaps { get { throw null; } set { } }
        public Azure.Search.Documents.Models.DataType Type { get { throw null; } set { } }
    }
    public partial class SearchIndex
    {
        public SearchIndex() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.Analyzer> Analyzers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.CharFilter> CharFilters { get { throw null; } set { } }
        public Azure.Search.Documents.Models.CorsOptions CorsOptions { get { throw null; } set { } }
        public string DefaultScoringProfile { get { throw null; } set { } }
        public Azure.Search.Documents.Models.EncryptionKey EncryptionKey { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.SearchField> Fields { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.ScoringProfile> ScoringProfiles { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.Suggester> Suggesters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.TokenFilter> TokenFilters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.Tokenizer> Tokenizers { get { throw null; } set { } }
    }
    public partial class SearchIndexer
    {
        public SearchIndexer() { }
        public string DataSourceName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.FieldMapping> FieldMappings { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.FieldMapping> OutputFieldMappings { get { throw null; } set { } }
        public Azure.Search.Documents.Models.IndexingParameters Parameters { get { throw null; } set { } }
        public Azure.Search.Documents.Models.IndexingSchedule Schedule { get { throw null; } set { } }
        public string SkillsetName { get { throw null; } set { } }
        public string TargetIndexName { get { throw null; } set { } }
    }
    public enum SearchMode
    {
        Any = 0,
        All = 1,
        AnalyzingInfixMatching = 2,
    }
    public enum SearchQueryType
    {
        Simple = 0,
        Full = 1,
    }
    public partial class SearchResourceCounter
    {
        internal SearchResourceCounter() { }
        public long? Quota { get { throw null; } }
        public long Usage { get { throw null; } }
    }
    public partial class SearchResultsPage<T> : Azure.Page<Azure.Search.Documents.Models.SearchResult<T>>
    {
        internal SearchResultsPage() { }
        public override string ContinuationToken { get { throw null; } }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> Facets { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchResult<T>> Values { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
    }
    public partial class SearchResults<T>
    {
        internal SearchResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> Facets { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public Azure.Pageable<Azure.Search.Documents.Models.SearchResult<T>> GetResults() { throw null; }
        public Azure.AsyncPageable<Azure.Search.Documents.Models.SearchResult<T>> GetResultsAsync() { throw null; }
    }
    public partial class SearchResult<T>
    {
        internal SearchResult() { }
        public T Document { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Highlights { get { throw null; } }
        public double? Score { get { throw null; } }
    }
    public partial class SearchServiceCounters
    {
        internal SearchServiceCounters() { }
        public Azure.Search.Documents.Models.SearchResourceCounter DataSourceCounter { get { throw null; } }
        public Azure.Search.Documents.Models.SearchResourceCounter DocumentCounter { get { throw null; } }
        public Azure.Search.Documents.Models.SearchResourceCounter IndexCounter { get { throw null; } }
        public Azure.Search.Documents.Models.SearchResourceCounter IndexerCounter { get { throw null; } }
        public Azure.Search.Documents.Models.SearchResourceCounter SkillsetCounter { get { throw null; } }
        public Azure.Search.Documents.Models.SearchResourceCounter StorageSizeCounter { get { throw null; } }
        public Azure.Search.Documents.Models.SearchResourceCounter SynonymMapCounter { get { throw null; } }
    }
    public partial class SearchServiceLimits
    {
        internal SearchServiceLimits() { }
        public int? MaxComplexCollectionFieldsPerIndex { get { throw null; } }
        public int? MaxComplexObjectsInCollectionsPerDocument { get { throw null; } }
        public int? MaxFieldNestingDepthPerIndex { get { throw null; } }
        public int? MaxFieldsPerIndex { get { throw null; } }
    }
    public partial class SearchServiceStatistics
    {
        internal SearchServiceStatistics() { }
        public Azure.Search.Documents.Models.SearchServiceCounters Counters { get { throw null; } }
        public Azure.Search.Documents.Models.SearchServiceLimits Limits { get { throw null; } }
    }
    public partial class SearchSuggestion<T>
    {
        internal SearchSuggestion() { }
        public T Document { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class SentimentSkill : Azure.Search.Documents.Models.Skill
    {
        public SentimentSkill() { }
        public Azure.Search.Documents.Models.SentimentSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SentimentSkillLanguage : System.IEquatable<Azure.Search.Documents.Models.SentimentSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SentimentSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage No { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Models.SentimentSkillLanguage Tr { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SentimentSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SentimentSkillLanguage left, Azure.Search.Documents.Models.SentimentSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SentimentSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SentimentSkillLanguage left, Azure.Search.Documents.Models.SentimentSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShaperSkill : Azure.Search.Documents.Models.Skill
    {
        public ShaperSkill() { }
    }
    public partial class ShingleTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public ShingleTokenFilter() { }
        public string FilterToken { get { throw null; } set { } }
        public int? MaxShingleSize { get { throw null; } set { } }
        public int? MinShingleSize { get { throw null; } set { } }
        public bool? OutputUnigrams { get { throw null; } set { } }
        public bool? OutputUnigramsIfNoShingles { get { throw null; } set { } }
        public string TokenSeparator { get { throw null; } set { } }
    }
    public partial class Skill
    {
        public Skill() { }
        public string Context { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.InputFieldMappingEntry> Inputs { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ODataType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.OutputFieldMappingEntry> Outputs { get { throw null; } set { } }
    }
    public partial class Skillset
    {
        public Skillset() { }
        public Azure.Search.Documents.Models.CognitiveServicesAccount CognitiveServicesAccount { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.Skill> Skills { get { throw null; } set { } }
    }
    public partial class SnowballTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public SnowballTokenFilter() { }
        public Azure.Search.Documents.Models.SnowballTokenFilterLanguage Language { get { throw null; } set { } }
    }
    public enum SnowballTokenFilterLanguage
    {
        Armenian = 0,
        Basque = 1,
        Catalan = 2,
        Danish = 3,
        Dutch = 4,
        English = 5,
        Finnish = 6,
        French = 7,
        German = 8,
        German2 = 9,
        Hungarian = 10,
        Italian = 11,
        Kp = 12,
        Lovins = 13,
        Norwegian = 14,
        Porter = 15,
        Portuguese = 16,
        Romanian = 17,
        Russian = 18,
        Spanish = 19,
        Swedish = 20,
        Turkish = 21,
    }
    public partial class SoftDeleteColumnDeletionDetectionPolicy : Azure.Search.Documents.Models.DataDeletionDetectionPolicy
    {
        public SoftDeleteColumnDeletionDetectionPolicy() { }
        public string SoftDeleteColumnName { get { throw null; } set { } }
        public string SoftDeleteMarkerValue { get { throw null; } set { } }
    }
    public partial class SplitSkill : Azure.Search.Documents.Models.Skill
    {
        public SplitSkill() { }
        public Azure.Search.Documents.Models.SplitSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public int? MaximumPageLength { get { throw null; } set { } }
        public Azure.Search.Documents.Models.TextSplitMode? TextSplitMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SplitSkillLanguage : System.IEquatable<Azure.Search.Documents.Models.SplitSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SplitSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.SplitSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Models.SplitSkillLanguage Pt { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SplitSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SplitSkillLanguage left, Azure.Search.Documents.Models.SplitSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SplitSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SplitSkillLanguage left, Azure.Search.Documents.Models.SplitSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlIntegratedChangeTrackingPolicy : Azure.Search.Documents.Models.DataChangeDetectionPolicy
    {
        public SqlIntegratedChangeTrackingPolicy() { }
    }
    public partial class StandardAnalyzer : Azure.Search.Documents.Models.Analyzer
    {
        public StandardAnalyzer() { }
        public int? MaxTokenLength { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } set { } }
    }
    public partial class StandardTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public StandardTokenizer() { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class StandardTokenizerV2 : Azure.Search.Documents.Models.Tokenizer
    {
        public StandardTokenizerV2() { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class StemmerOverrideTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public StemmerOverrideTokenFilter() { }
        public System.Collections.Generic.IList<string> Rules { get { throw null; } set { } }
    }
    public partial class StemmerTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public StemmerTokenFilter() { }
        public Azure.Search.Documents.Models.StemmerTokenFilterLanguage Language { get { throw null; } set { } }
    }
    public enum StemmerTokenFilterLanguage
    {
        Arabic = 0,
        Armenian = 1,
        Basque = 2,
        Brazilian = 3,
        Bulgarian = 4,
        Catalan = 5,
        Czech = 6,
        Danish = 7,
        Dutch = 8,
        DutchKp = 9,
        English = 10,
        LightEnglish = 11,
        MinimalEnglish = 12,
        PossessiveEnglish = 13,
        Porter2 = 14,
        Lovins = 15,
        Finnish = 16,
        LightFinnish = 17,
        French = 18,
        LightFrench = 19,
        MinimalFrench = 20,
        Galician = 21,
        MinimalGalician = 22,
        German = 23,
        German2 = 24,
        LightGerman = 25,
        MinimalGerman = 26,
        Greek = 27,
        Hindi = 28,
        Hungarian = 29,
        LightHungarian = 30,
        Indonesian = 31,
        Irish = 32,
        Italian = 33,
        LightItalian = 34,
        Sorani = 35,
        Latvian = 36,
        Norwegian = 37,
        LightNorwegian = 38,
        MinimalNorwegian = 39,
        LightNynorsk = 40,
        MinimalNynorsk = 41,
        Portuguese = 42,
        LightPortuguese = 43,
        MinimalPortuguese = 44,
        PortugueseRslp = 45,
        Romanian = 46,
        Russian = 47,
        LightRussian = 48,
        Spanish = 49,
        LightSpanish = 50,
        Swedish = 51,
        LightSwedish = 52,
        Turkish = 53,
    }
    public partial class StopAnalyzer : Azure.Search.Documents.Models.Analyzer
    {
        public StopAnalyzer() { }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } set { } }
    }
    public enum StopwordsList
    {
        Arabic = 0,
        Armenian = 1,
        Basque = 2,
        Brazilian = 3,
        Bulgarian = 4,
        Catalan = 5,
        Czech = 6,
        Danish = 7,
        Dutch = 8,
        English = 9,
        Finnish = 10,
        French = 11,
        Galician = 12,
        German = 13,
        Greek = 14,
        Hindi = 15,
        Hungarian = 16,
        Indonesian = 17,
        Irish = 18,
        Italian = 19,
        Latvian = 20,
        Norwegian = 21,
        Persian = 22,
        Portuguese = 23,
        Romanian = 24,
        Russian = 25,
        Sorani = 26,
        Spanish = 27,
        Swedish = 28,
        Thai = 29,
        Turkish = 30,
    }
    public partial class StopwordsTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public StopwordsTokenFilter() { }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? RemoveTrailingStopWords { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } set { } }
        public Azure.Search.Documents.Models.StopwordsList? StopwordsList { get { throw null; } set { } }
    }
    public partial class Suggester
    {
        public Suggester() { }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Models.SearchMode SearchMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFields { get { throw null; } set { } }
    }
    public partial class SuggestResults<T>
    {
        internal SuggestResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.SearchSuggestion<T>> Results { get { throw null; } }
    }
    public partial class SynonymMap
    {
        public SynonymMap() { }
        public Azure.Search.Documents.Models.EncryptionKey EncryptionKey { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public string Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Synonyms { get { throw null; } set { } }
    }
    public partial class SynonymTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public SynonymTokenFilter() { }
        public bool? Expand { get { throw null; } set { } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Synonyms { get { throw null; } set { } }
    }
    public partial class TagScoringFunction : Azure.Search.Documents.Models.ScoringFunction
    {
        public TagScoringFunction() { }
        public Azure.Search.Documents.Models.TagScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class TagScoringParameters
    {
        public TagScoringParameters() { }
        public string TagsParameter { get { throw null; } set { } }
    }
    public enum TextExtractionAlgorithm
    {
        Printed = 0,
        Handwritten = 1,
    }
    public enum TextSplitMode
    {
        Pages = 0,
        Sentences = 1,
    }
    public partial class TextTranslationSkill : Azure.Search.Documents.Models.Skill
    {
        public TextTranslationSkill() { }
        public Azure.Search.Documents.Models.TextTranslationSkillLanguage? DefaultFromLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Models.TextTranslationSkillLanguage DefaultToLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Models.TextTranslationSkillLanguage? SuggestedFrom { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextTranslationSkillLanguage : System.IEquatable<Azure.Search.Documents.Models.TextTranslationSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextTranslationSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Af { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Bg { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Bn { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Bs { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ca { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Cy { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Et { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Fa { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Fil { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Fj { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage He { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Hi { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Hr { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ht { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Id { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Is { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Lt { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Lv { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Mg { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ms { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Mt { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Mww { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Otq { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ro { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Sk { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Sl { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Sm { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage SrCyrl { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage SrLatn { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Sw { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ta { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Te { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Th { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Tlh { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage To { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ty { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Uk { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Ur { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Vi { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Yua { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage Yue { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Models.TextTranslationSkillLanguage ZhHant { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.TextTranslationSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.TextTranslationSkillLanguage left, Azure.Search.Documents.Models.TextTranslationSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.TextTranslationSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.TextTranslationSkillLanguage left, Azure.Search.Documents.Models.TextTranslationSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextWeights
    {
        public TextWeights() { }
        public System.Collections.Generic.IDictionary<string, double> Weights { get { throw null; } set { } }
    }
    public enum TokenCharacterKind
    {
        Letter = 0,
        Digit = 1,
        Whitespace = 2,
        Punctuation = 3,
        Symbol = 4,
    }
    public partial class TokenFilter
    {
        public TokenFilter() { }
        public string Name { get { throw null; } set { } }
        public string ODataType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TokenFilterName : System.IEquatable<Azure.Search.Documents.Models.TokenFilterName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TokenFilterName(string value) { throw null; }
        public static Azure.Search.Documents.Models.TokenFilterName Apostrophe { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName ArabicNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName AsciiFolding { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName CjkBigram { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName CjkWidth { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Classic { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName CommonGram { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName EdgeNGram { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Elision { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName GermanNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName HindiNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName IndicNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName KeywordRepeat { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName KStem { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Length { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Limit { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Lowercase { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName NGram { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName PersianNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Phonetic { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName PorterStem { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Reverse { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName ScandinavianFoldingNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName ScandinavianNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Shingle { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Snowball { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName SoraniNormalization { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Stemmer { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Stopwords { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Trim { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Truncate { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Unique { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName Uppercase { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenFilterName WordDelimiter { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.TokenFilterName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.TokenFilterName left, Azure.Search.Documents.Models.TokenFilterName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.TokenFilterName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.TokenFilterName left, Azure.Search.Documents.Models.TokenFilterName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TokenInfo
    {
        internal TokenInfo() { }
        public int EndOffset { get { throw null; } }
        public int Position { get { throw null; } }
        public int StartOffset { get { throw null; } }
        public string Token { get { throw null; } }
    }
    public partial class Tokenizer
    {
        public Tokenizer() { }
        public string Name { get { throw null; } set { } }
        public string ODataType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TokenizerName : System.IEquatable<Azure.Search.Documents.Models.TokenizerName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TokenizerName(string value) { throw null; }
        public static Azure.Search.Documents.Models.TokenizerName Classic { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName EdgeNGram { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName Keyword { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName Letter { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName Lowercase { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName MicrosoftLanguageStemmingTokenizer { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName MicrosoftLanguageTokenizer { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName NGram { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName PathHierarchy { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName Pattern { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName Standard { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName UaxUrlEmail { get { throw null; } }
        public static Azure.Search.Documents.Models.TokenizerName Whitespace { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.TokenizerName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.TokenizerName left, Azure.Search.Documents.Models.TokenizerName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.TokenizerName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.TokenizerName left, Azure.Search.Documents.Models.TokenizerName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TruncateTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public TruncateTokenFilter() { }
        public int? Length { get { throw null; } set { } }
    }
    public partial class UaxUrlEmailTokenizer : Azure.Search.Documents.Models.Tokenizer
    {
        public UaxUrlEmailTokenizer() { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class UniqueTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public UniqueTokenFilter() { }
        public bool? OnlyOnSamePosition { get { throw null; } set { } }
    }
    public enum VisualFeature
    {
        Adult = 0,
        Brands = 1,
        Categories = 2,
        Description = 3,
        Faces = 4,
        Objects = 5,
        Tags = 6,
    }
    public partial class WebApiSkill : Azure.Search.Documents.Models.Skill
    {
        public WebApiSkill() { }
        public int? BatchSize { get { throw null; } set { } }
        public int? DegreeOfParallelism { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> HttpHeaders { get { throw null; } set { } }
        public string HttpMethod { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public partial class WordDelimiterTokenFilter : Azure.Search.Documents.Models.TokenFilter
    {
        public WordDelimiterTokenFilter() { }
        public bool? CatenateAll { get { throw null; } set { } }
        public bool? CatenateNumbers { get { throw null; } set { } }
        public bool? CatenateWords { get { throw null; } set { } }
        public bool? GenerateNumberParts { get { throw null; } set { } }
        public bool? GenerateWordParts { get { throw null; } set { } }
        public bool? PreserveOriginal { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtectedWords { get { throw null; } set { } }
        public bool? SplitOnCaseChange { get { throw null; } set { } }
        public bool? SplitOnNumerics { get { throw null; } set { } }
        public bool? StemEnglishPossessive { get { throw null; } set { } }
    }
}
