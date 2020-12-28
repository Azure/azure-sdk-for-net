namespace Azure.Search.Documents
{
    public partial class AutocompleteOptions
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
    public partial class GetDocumentOptions
    {
        public GetDocumentOptions() { }
        public System.Collections.Generic.IList<string> SelectedFields { get { throw null; } }
    }
    public partial class IndexDocumentsOptions
    {
        public IndexDocumentsOptions() { }
        public bool ThrowOnAnyError { get { throw null; } set { } }
    }
    public partial class SearchClient
    {
        protected SearchClient() { }
        public SearchClient(System.Uri endpoint, string indexName, Azure.AzureKeyCredential credential) { }
        public SearchClient(System.Uri endpoint, string indexName, Azure.AzureKeyCredential credential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string IndexName { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<Azure.Search.Documents.Models.AutocompleteResults> Autocomplete(string searchText, string suggesterName, Azure.Search.Documents.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.AutocompleteResults>> AutocompleteAsync(string searchText, string suggesterName, Azure.Search.Documents.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Search.Documents.SearchIndexingBufferedSender<T> CreateIndexingBufferedSender<T>(Azure.Search.Documents.SearchIndexingBufferedSenderOptions<T> options = null) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> DeleteDocuments(string keyName, System.Collections.Generic.IEnumerable<string> keyValues, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> DeleteDocumentsAsync(string keyName, System.Collections.Generic.IEnumerable<string> keyValues, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> DeleteDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> DeleteDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetDocumentAsync<T>(string key, Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<long> GetDocumentCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<long>> GetDocumentCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetDocument<T>(string key, Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> IndexDocumentsAsync<T>(Azure.Search.Documents.Models.IndexDocumentsBatch<T> batch, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> IndexDocuments<T>(Azure.Search.Documents.Models.IndexDocumentsBatch<T> batch, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> MergeDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> MergeDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> MergeOrUploadDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> MergeOrUploadDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>>> SuggestAsync<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>> Suggest<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> UploadDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> UploadDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchClientOptions : Azure.Core.ClientOptions
    {
        public SearchClientOptions(Azure.Search.Documents.SearchClientOptions.ServiceVersion version = Azure.Search.Documents.SearchClientOptions.ServiceVersion.V2020_06_30) { }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public Azure.Search.Documents.SearchClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_06_30 = 1,
        }
    }
    public static partial class SearchFilter
    {
        public static string Create(System.FormattableString filter) { throw null; }
        public static string Create(System.FormattableString filter, System.IFormatProvider formatProvider) { throw null; }
    }
    public static partial class SearchIndexingBufferedSenderExtensions
    {
        public static void DeleteDocuments(this Azure.Search.Documents.SearchIndexingBufferedSender<Azure.Search.Documents.Models.SearchDocument> indexer, string keyFieldName, System.Collections.Generic.IEnumerable<string> documentKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public static System.Threading.Tasks.Task DeleteDocumentsAsync(this Azure.Search.Documents.SearchIndexingBufferedSender<Azure.Search.Documents.Models.SearchDocument> indexer, string keyFieldName, System.Collections.Generic.IEnumerable<string> documentKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchIndexingBufferedSenderOptions<T>
    {
        public SearchIndexingBufferedSenderOptions() { }
        public bool AutoFlush { get { throw null; } set { } }
        public System.TimeSpan? AutoFlushInterval { get { throw null; } set { } }
        public System.Threading.CancellationToken FlushCancellationToken { get { throw null; } set { } }
        public int? InitialBatchActionCount { get { throw null; } set { } }
        public System.Func<T, string> KeyFieldAccessor { get { throw null; } set { } }
        public int MaxRetries { get { throw null; } set { } }
        public System.TimeSpan MaxRetryDelay { get { throw null; } set { } }
        public System.TimeSpan RetryDelay { get { throw null; } set { } }
    }
    public partial class SearchIndexingBufferedSender<T> : System.IAsyncDisposable, System.IDisposable
    {
        protected SearchIndexingBufferedSender() { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string IndexName { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public event System.Func<Azure.Search.Documents.Models.IndexDocumentsAction<T>, System.Threading.CancellationToken, System.Threading.Tasks.Task> ActionAddedAsync { add { } remove { } }
        public event System.Func<Azure.Search.Documents.Models.IndexDocumentsAction<T>, Azure.Search.Documents.Models.IndexingResult, System.Threading.CancellationToken, System.Threading.Tasks.Task> ActionCompletedAsync { add { } remove { } }
        public event System.Func<Azure.Search.Documents.Models.IndexDocumentsAction<T>, Azure.Search.Documents.Models.IndexingResult, System.Exception, System.Threading.CancellationToken, System.Threading.Tasks.Task> ActionFailedAsync { add { } remove { } }
        public event System.Func<Azure.Search.Documents.Models.IndexDocumentsAction<T>, System.Threading.CancellationToken, System.Threading.Tasks.Task> ActionSentAsync { add { } remove { } }
        public virtual void DeleteDocuments(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task DeleteDocumentsAsync(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        ~SearchIndexingBufferedSender() { }
        public void Flush(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void IndexDocuments(Azure.Search.Documents.Models.IndexDocumentsBatch<T> batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task IndexDocumentsAsync(Azure.Search.Documents.Models.IndexDocumentsBatch<T> batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void MergeDocuments(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task MergeDocumentsAsync(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void MergeOrUploadDocuments(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task MergeOrUploadDocumentsAsync(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Threading.Tasks.ValueTask System.IAsyncDisposable.DisposeAsync() { throw null; }
        void System.IDisposable.Dispose() { }
        public virtual void UploadDocuments(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task UploadDocumentsAsync(System.Collections.Generic.IEnumerable<T> documents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchOptions
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
        public Azure.Search.Documents.Models.ScoringStatistics? ScoringStatistics { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchFields { get { throw null; } }
        public Azure.Search.Documents.Models.SearchMode? SearchMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Select { get { throw null; } }
        public string SessionId { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
    }
    public partial class SuggestOptions
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
namespace Azure.Search.Documents.Indexes
{
    public partial class FieldBuilder
    {
        public FieldBuilder() { }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchField> Build(System.Type modelType) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
    public partial class FieldBuilderIgnoreAttribute : System.Attribute
    {
        public FieldBuilderIgnoreAttribute() { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
    public partial class SearchableFieldAttribute : Azure.Search.Documents.Indexes.SimpleFieldAttribute
    {
        public SearchableFieldAttribute() { }
        public string AnalyzerName { get { throw null; } set { } }
        public string IndexAnalyzerName { get { throw null; } set { } }
        public string SearchAnalyzerName { get { throw null; } set { } }
        public string[] SynonymMapNames { get { throw null; } set { } }
    }
    public partial class SearchIndexClient
    {
        protected SearchIndexClient() { }
        public SearchIndexClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public SearchIndexClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>> AnalyzeText(string indexName, Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>>> AnalyzeTextAsync(string indexName, Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex> CreateIndex(Azure.Search.Documents.Indexes.Models.SearchIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex>> CreateIndexAsync(Azure.Search.Documents.Indexes.Models.SearchIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex> CreateOrUpdateIndex(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool allowIndexDowntime = false, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex>> CreateOrUpdateIndexAsync(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool allowIndexDowntime = false, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap> CreateOrUpdateSynonymMap(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap>> CreateOrUpdateSynonymMapAsync(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap> CreateSynonymMap(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap>> CreateSynonymMapAsync(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIndex(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIndex(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIndexAsync(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIndexAsync(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSynonymMap(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSynonymMap(string synonymMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSynonymMapAsync(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSynonymMapAsync(string synonymMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex> GetIndex(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex>> GetIndexAsync(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Search.Documents.Indexes.Models.SearchIndex> GetIndexes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Search.Documents.Indexes.Models.SearchIndex> GetIndexesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetIndexNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetIndexNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics> GetIndexStatistics(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>> GetIndexStatisticsAsync(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Search.Documents.SearchClient GetSearchClient(string indexName) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics> GetServiceStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>> GetServiceStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap> GetSynonymMap(string synonymMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap>> GetSynonymMapAsync(string synonymMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetSynonymMapNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetSynonymMapNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SynonymMap>> GetSynonymMaps(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SynonymMap>>> GetSynonymMapsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchIndexerClient
    {
        protected SearchIndexerClient() { }
        public SearchIndexerClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public SearchIndexerClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection> CreateDataSourceConnection(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>> CreateDataSourceConnectionAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer> CreateIndexer(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer>> CreateIndexerAsync(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection> CreateOrUpdateDataSourceConnection(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>> CreateOrUpdateDataSourceConnectionAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer> CreateOrUpdateIndexer(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer>> CreateOrUpdateIndexerAsync(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset> CreateOrUpdateSkillset(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset> CreateSkillset(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>> CreateSkillsetAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDataSourceConnection(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDataSourceConnection(string dataSourceConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataSourceConnectionAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataSourceConnectionAsync(string dataSourceConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIndexer(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIndexer(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIndexerAsync(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIndexerAsync(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSkillset(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSkillset(string skillsetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSkillsetAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSkillsetAsync(string skillsetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection> GetDataSourceConnection(string dataSourceConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>> GetDataSourceConnectionAsync(string dataSourceConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetDataSourceConnectionNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetDataSourceConnectionNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>> GetDataSourceConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>>> GetDataSourceConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer> GetIndexer(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer>> GetIndexerAsync(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetIndexerNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetIndexerNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexer>> GetIndexers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexer>>> GetIndexersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus> GetIndexerStatus(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>> GetIndexerStatusAsync(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset> GetSkillset(string skillsetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>> GetSkillsetAsync(string skillsetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetSkillsetNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetSkillsetNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>> GetSkillsets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>>> GetSkillsetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetIndexer(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetIndexerAsync(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunIndexer(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunIndexerAsync(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
    public partial class SimpleFieldAttribute : System.Attribute
    {
        public SimpleFieldAttribute() { }
        public bool IsFacetable { get { throw null; } set { } }
        public bool IsFilterable { get { throw null; } set { } }
        public bool IsHidden { get { throw null; } set { } }
        public bool IsKey { get { throw null; } set { } }
        public bool IsSortable { get { throw null; } set { } }
    }
}
namespace Azure.Search.Documents.Indexes.Models
{
    public partial class AnalyzedTokenInfo
    {
        internal AnalyzedTokenInfo() { }
        public int EndOffset { get { throw null; } }
        public int Position { get { throw null; } }
        public int StartOffset { get { throw null; } }
        public string Token { get { throw null; } }
    }
    public partial class AnalyzeTextOptions
    {
        public AnalyzeTextOptions(string text) { }
        public AnalyzeTextOptions(string text, Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName analyzerName) { }
        public AnalyzeTextOptions(string text, Azure.Search.Documents.Indexes.Models.LexicalTokenizerName tokenizerName) { }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? AnalyzerName { get { throw null; } }
        public System.Collections.Generic.IList<string> CharFilters { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilterName> TokenFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalTokenizerName? TokenizerName { get { throw null; } }
    }
    public partial class AsciiFoldingTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public AsciiFoldingTokenFilter(string name) { }
        public bool? PreserveOriginal { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobIndexerDataToExtract : System.IEquatable<Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobIndexerDataToExtract(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract AllMetadata { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract ContentAndMetadata { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract StorageMetadata { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract left, Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract left, Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobIndexerImageAction : System.IEquatable<Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobIndexerImageAction(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction GenerateNormalizedImagePerPage { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction GenerateNormalizedImages { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction None { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction left, Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction left, Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobIndexerParsingMode : System.IEquatable<Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobIndexerParsingMode(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode Default { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode DelimitedText { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode Json { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode JsonArray { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode JsonLines { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode Text { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode left, Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode left, Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobIndexerPdfTextRotationAlgorithm : System.IEquatable<Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobIndexerPdfTextRotationAlgorithm(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm DetectAngles { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm None { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm left, Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm left, Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BM25Similarity : Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm
    {
        public BM25Similarity() { }
        public double? B { get { throw null; } set { } }
        public double? K1 { get { throw null; } set { } }
    }
    public partial class CharFilter
    {
        internal CharFilter() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class CjkBigramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public CjkBigramTokenFilter(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilterScripts> IgnoreScripts { get { throw null; } }
        public bool? OutputUnigrams { get { throw null; } set { } }
    }
    public enum CjkBigramTokenFilterScripts
    {
        Han = 0,
        Hiragana = 1,
        Katakana = 2,
        Hangul = 3,
    }
    public partial class ClassicSimilarity : Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm
    {
        public ClassicSimilarity() { }
    }
    public partial class ClassicTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public ClassicTokenizer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class CognitiveServicesAccount
    {
        internal CognitiveServicesAccount() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class CognitiveServicesAccountKey : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount
    {
        public CognitiveServicesAccountKey(string key) { }
        public string Key { get { throw null; } set { } }
    }
    public partial class CommonGramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public CommonGramTokenFilter(string name, System.Collections.Generic.IEnumerable<string> commonWords) { }
        public System.Collections.Generic.IList<string> CommonWords { get { throw null; } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? UseQueryMode { get { throw null; } set { } }
    }
    public partial class ComplexField : Azure.Search.Documents.Indexes.Models.SearchFieldTemplate
    {
        public ComplexField(string name, bool collection = false) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchFieldTemplate> Fields { get { throw null; } }
    }
    public partial class ConditionalSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public ConditionalSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
    }
    public partial class CorsOptions
    {
        public CorsOptions(System.Collections.Generic.IEnumerable<string> allowedOrigins) { }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public long? MaxAgeInSeconds { get { throw null; } set { } }
    }
    public partial class CustomAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer
    {
        public CustomAnalyzer(string name, Azure.Search.Documents.Indexes.Models.LexicalTokenizerName tokenizerName) { }
        public System.Collections.Generic.IList<string> CharFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilterName> TokenFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalTokenizerName TokenizerName { get { throw null; } set { } }
    }
    public partial class DataChangeDetectionPolicy
    {
        internal DataChangeDetectionPolicy() { }
    }
    public partial class DataDeletionDetectionPolicy
    {
        internal DataDeletionDetectionPolicy() { }
    }
    public partial class DefaultCognitiveServicesAccount : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount
    {
        public DefaultCognitiveServicesAccount() { }
    }
    public partial class DictionaryDecompounderTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public DictionaryDecompounderTokenFilter(string name, System.Collections.Generic.IEnumerable<string> wordList) { }
        public int? MaxSubwordSize { get { throw null; } set { } }
        public int? MinSubwordSize { get { throw null; } set { } }
        public int? MinWordSize { get { throw null; } set { } }
        public bool? OnlyLongestMatch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> WordList { get { throw null; } }
    }
    public partial class DistanceScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction
    {
        public DistanceScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.DistanceScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.DistanceScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class DistanceScoringParameters
    {
        public DistanceScoringParameters(string referencePointParameter, double boostingDistance) { }
        public double BoostingDistance { get { throw null; } set { } }
        public string ReferencePointParameter { get { throw null; } set { } }
    }
    public partial class EdgeNGramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public EdgeNGramTokenFilter(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilterSide? Side { get { throw null; } set { } }
    }
    public enum EdgeNGramTokenFilterSide
    {
        Front = 0,
        Back = 1,
    }
    public partial class EdgeNGramTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public EdgeNGramTokenizer(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenCharacterKind> TokenChars { get { throw null; } }
    }
    public partial class ElisionTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public ElisionTokenFilter(string name) { }
        public System.Collections.Generic.IList<string> Articles { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityCategory : System.IEquatable<Azure.Search.Documents.Indexes.Models.EntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityCategory(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.EntityCategory Datetime { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityCategory Email { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityCategory Location { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityCategory Organization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityCategory Person { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityCategory Quantity { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityCategory Url { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.EntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.EntityCategory left, Azure.Search.Documents.Indexes.Models.EntityCategory right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.EntityCategory (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.EntityCategory left, Azure.Search.Documents.Indexes.Models.EntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityRecognitionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public EntityRecognitionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.EntityCategory> Categories { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? IncludeTypelessEntities { get { throw null; } set { } }
        public double? MinimumPrecision { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityRecognitionSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityRecognitionSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage No { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage PtBR { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage PtPT { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage ZhHant { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage left, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage left, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FieldMapping
    {
        public FieldMapping(string sourceFieldName) { }
        public Azure.Search.Documents.Indexes.Models.FieldMappingFunction MappingFunction { get { throw null; } set { } }
        public string SourceFieldName { get { throw null; } set { } }
        public string TargetFieldName { get { throw null; } set { } }
    }
    public partial class FieldMappingFunction
    {
        public FieldMappingFunction(string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
    }
    public partial class FreshnessScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction
    {
        public FreshnessScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class FreshnessScoringParameters
    {
        public FreshnessScoringParameters(System.TimeSpan boostingDuration) { }
        public System.TimeSpan BoostingDuration { get { throw null; } set { } }
    }
    public partial class HighWaterMarkChangeDetectionPolicy : Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy
    {
        public HighWaterMarkChangeDetectionPolicy(string highWaterMarkColumnName) { }
        public string HighWaterMarkColumnName { get { throw null; } set { } }
    }
    public partial class ImageAnalysisSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public ImageAnalysisSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ImageDetail> Details { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VisualFeature> VisualFeatures { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageAnalysisSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageAnalysisSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Zh { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage left, Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage left, Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageDetail : System.IEquatable<Azure.Search.Documents.Indexes.Models.ImageDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageDetail(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ImageDetail Celebrities { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageDetail Landmarks { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.ImageDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.ImageDetail left, Azure.Search.Documents.Indexes.Models.ImageDetail right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.ImageDetail (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.ImageDetail left, Azure.Search.Documents.Indexes.Models.ImageDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexerExecutionEnvironment : System.IEquatable<Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexerExecutionEnvironment(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment Private { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment Standard { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment left, Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment left, Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexerExecutionResult
    {
        internal IndexerExecutionResult() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerError> Errors { get { throw null; } }
        public int FailedItemCount { get { throw null; } }
        public string FinalTrackingState { get { throw null; } }
        public string InitialTrackingState { get { throw null; } }
        public int ItemCount { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> Warnings { get { throw null; } }
    }
    public enum IndexerExecutionStatus
    {
        TransientFailure = 0,
        Success = 1,
        InProgress = 2,
        Reset = 3,
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IDictionary<string, object> Configuration { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration IndexingParametersConfiguration { get { throw null; } set { } }
        public int? MaxFailedItems { get { throw null; } set { } }
        public int? MaxFailedItemsPerBatch { get { throw null; } set { } }
    }
    public partial class IndexingParametersConfiguration : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public IndexingParametersConfiguration() { }
        public bool? AllowSkillsetToReadFileData { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract? DataToExtract { get { throw null; } set { } }
        public string DelimitedTextDelimiter { get { throw null; } set { } }
        public string DelimitedTextHeaders { get { throw null; } set { } }
        public string DocumentRoot { get { throw null; } set { } }
        public string ExcludedFileNameExtensions { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionEnvironment? ExecutionEnvironment { get { throw null; } set { } }
        public bool? FailOnUnprocessableDocument { get { throw null; } set { } }
        public bool? FailOnUnsupportedContentType { get { throw null; } set { } }
        public bool? FirstLineContainsHeaders { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerImageAction? ImageAction { get { throw null; } set { } }
        public string IndexedFileNameExtensions { get { throw null; } set { } }
        public bool? IndexStorageMetadataOnlyForOversizedDocuments { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode? ParsingMode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerPdfTextRotationAlgorithm? PdfTextRotationAlgorithm { get { throw null; } set { } }
        public System.TimeSpan? QueryTimeout { get { throw null; } set { } }
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
    public partial class IndexingSchedule
    {
        public IndexingSchedule(System.TimeSpan interval) { }
        public System.TimeSpan Interval { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
    }
    public partial class InputFieldMappingEntry
    {
        public InputFieldMappingEntry(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string SourceContext { get { throw null; } set { } }
    }
    public partial class KeepTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public KeepTokenFilter(string name, System.Collections.Generic.IEnumerable<string> keepWords) { }
        public System.Collections.Generic.IList<string> KeepWords { get { throw null; } }
        public bool? LowerCaseKeepWords { get { throw null; } set { } }
    }
    public partial class KeyPhraseExtractionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public KeyPhraseExtractionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public int? MaxKeyPhraseCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyPhraseExtractionSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyPhraseExtractionSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage No { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage PtBR { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage PtPT { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage Sv { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage left, Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage left, Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeywordMarkerTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public KeywordMarkerTokenFilter(string name, System.Collections.Generic.IEnumerable<string> keywords) { }
        public bool? IgnoreCase { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
    }
    public partial class KeywordTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public KeywordTokenizer(string name) { }
        public int? BufferSize { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class LanguageDetectionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public LanguageDetectionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
    }
    public partial class LengthTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public LengthTokenFilter(string name) { }
        public int? MaxLength { get { throw null; } set { } }
        public int? MinLength { get { throw null; } set { } }
    }
    public partial class LexicalAnalyzer
    {
        internal LexicalAnalyzer() { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LexicalAnalyzerName : System.IEquatable<Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LexicalAnalyzerName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ArLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ArMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName BgLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName BgMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName BnMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName CaLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName CaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName CsLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName CsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName DaLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName DaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName DeLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName DeMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ElLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ElMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName EnLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName EnMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName EsLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName EsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName EtMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName EuLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName FaLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName FiLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName FiMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName FrLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName FrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName GaLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName GlLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName GuMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName HeMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName HiLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName HiMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName HrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName HuLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName HuMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName HyLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName IdLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName IdMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName IsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ItLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ItMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName JaLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName JaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName Keyword { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName KnMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName KoLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName KoMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName LtMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName LvLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName LvMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName MlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName MrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName MsMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName NbMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName NlLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName NlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName NoLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName PaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName Pattern { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName PlLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName PlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName PtBrLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName PtBrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName PtPtLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName PtPtMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName RoLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName RoMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName RuLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName RuMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName Simple { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName SkMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName SlMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName SrCyrillicMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName SrLatinMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName StandardAsciiFoldingLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName StandardLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName Stop { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName SvLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName SvMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName TaMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName TeMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ThLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ThMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName TrLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName TrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName UkMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName UrMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ViMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName Whitespace { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ZhHansLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ZhHansMicrosoft { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ZhHantLucene { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName ZhHantMicrosoft { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName left, Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName left, Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName right) { throw null; }
        public override string ToString() { throw null; }
        public static partial class Values
        {
            public const string ArLucene = "ar.lucene";
            public const string ArMicrosoft = "ar.microsoft";
            public const string BgLucene = "bg.lucene";
            public const string BgMicrosoft = "bg.microsoft";
            public const string BnMicrosoft = "bn.microsoft";
            public const string CaLucene = "ca.lucene";
            public const string CaMicrosoft = "ca.microsoft";
            public const string CsLucene = "cs.lucene";
            public const string CsMicrosoft = "cs.microsoft";
            public const string DaLucene = "da.lucene";
            public const string DaMicrosoft = "da.microsoft";
            public const string DeLucene = "de.lucene";
            public const string DeMicrosoft = "de.microsoft";
            public const string ElLucene = "el.lucene";
            public const string ElMicrosoft = "el.microsoft";
            public const string EnLucene = "en.lucene";
            public const string EnMicrosoft = "en.microsoft";
            public const string EsLucene = "es.lucene";
            public const string EsMicrosoft = "es.microsoft";
            public const string EtMicrosoft = "et.microsoft";
            public const string EuLucene = "eu.lucene";
            public const string FaLucene = "fa.lucene";
            public const string FiLucene = "fi.lucene";
            public const string FiMicrosoft = "fi.microsoft";
            public const string FrLucene = "fr.lucene";
            public const string FrMicrosoft = "fr.microsoft";
            public const string GaLucene = "ga.lucene";
            public const string GlLucene = "gl.lucene";
            public const string GuMicrosoft = "gu.microsoft";
            public const string HeMicrosoft = "he.microsoft";
            public const string HiLucene = "hi.lucene";
            public const string HiMicrosoft = "hi.microsoft";
            public const string HrMicrosoft = "hr.microsoft";
            public const string HuLucene = "hu.lucene";
            public const string HuMicrosoft = "hu.microsoft";
            public const string HyLucene = "hy.lucene";
            public const string IdLucene = "id.lucene";
            public const string IdMicrosoft = "id.microsoft";
            public const string IsMicrosoft = "is.microsoft";
            public const string ItLucene = "it.lucene";
            public const string ItMicrosoft = "it.microsoft";
            public const string JaLucene = "ja.lucene";
            public const string JaMicrosoft = "ja.microsoft";
            public const string Keyword = "keyword";
            public const string KnMicrosoft = "kn.microsoft";
            public const string KoLucene = "ko.lucene";
            public const string KoMicrosoft = "ko.microsoft";
            public const string LtMicrosoft = "lt.microsoft";
            public const string LvLucene = "lv.lucene";
            public const string LvMicrosoft = "lv.microsoft";
            public const string MlMicrosoft = "ml.microsoft";
            public const string MrMicrosoft = "mr.microsoft";
            public const string MsMicrosoft = "ms.microsoft";
            public const string NbMicrosoft = "nb.microsoft";
            public const string NlLucene = "nl.lucene";
            public const string NlMicrosoft = "nl.microsoft";
            public const string NoLucene = "no.lucene";
            public const string PaMicrosoft = "pa.microsoft";
            public const string Pattern = "pattern";
            public const string PlLucene = "pl.lucene";
            public const string PlMicrosoft = "pl.microsoft";
            public const string PtBrLucene = "pt-BR.lucene";
            public const string PtBrMicrosoft = "pt-BR.microsoft";
            public const string PtPtLucene = "pt-PT.lucene";
            public const string PtPtMicrosoft = "pt-PT.microsoft";
            public const string RoLucene = "ro.lucene";
            public const string RoMicrosoft = "ro.microsoft";
            public const string RuLucene = "ru.lucene";
            public const string RuMicrosoft = "ru.microsoft";
            public const string Simple = "simple";
            public const string SkMicrosoft = "sk.microsoft";
            public const string SlMicrosoft = "sl.microsoft";
            public const string SrCyrillicMicrosoft = "sr-cyrillic.microsoft";
            public const string SrLatinMicrosoft = "sr-latin.microsoft";
            public const string StandardAsciiFoldingLucene = "standardasciifolding.lucene";
            public const string StandardLucene = "standard.lucene";
            public const string Stop = "stop";
            public const string SvLucene = "sv.lucene";
            public const string SvMicrosoft = "sv.microsoft";
            public const string TaMicrosoft = "ta.microsoft";
            public const string TeMicrosoft = "te.microsoft";
            public const string ThLucene = "th.lucene";
            public const string ThMicrosoft = "th.microsoft";
            public const string TrLucene = "tr.lucene";
            public const string TrMicrosoft = "tr.microsoft";
            public const string UkMicrosoft = "uk.microsoft";
            public const string UrMicrosoft = "ur.microsoft";
            public const string ViMicrosoft = "vi.microsoft";
            public const string Whitespace = "whitespace";
            public const string ZhHansLucene = "zh-Hans.lucene";
            public const string ZhHansMicrosoft = "zh-Hans.microsoft";
            public const string ZhHantLucene = "zh-Hant.lucene";
            public const string ZhHantMicrosoft = "zh-Hant.microsoft";
        }
    }
    public partial class LexicalTokenizer
    {
        internal LexicalTokenizer() { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LexicalTokenizerName : System.IEquatable<Azure.Search.Documents.Indexes.Models.LexicalTokenizerName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LexicalTokenizerName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName Classic { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName EdgeNGram { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName Keyword { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName Letter { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName Lowercase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName MicrosoftLanguageStemmingTokenizer { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName MicrosoftLanguageTokenizer { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName NGram { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName PathHierarchy { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName Pattern { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName Standard { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName UaxUrlEmail { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizerName Whitespace { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.LexicalTokenizerName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.LexicalTokenizerName left, Azure.Search.Documents.Indexes.Models.LexicalTokenizerName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.LexicalTokenizerName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.LexicalTokenizerName left, Azure.Search.Documents.Indexes.Models.LexicalTokenizerName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LimitTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public LimitTokenFilter(string name) { }
        public bool? ConsumeAllTokens { get { throw null; } set { } }
        public int? MaxTokenCount { get { throw null; } set { } }
    }
    public partial class LuceneStandardAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer
    {
        public LuceneStandardAnalyzer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
    }
    public partial class LuceneStandardTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public LuceneStandardTokenizer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class MagnitudeScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction
    {
        public MagnitudeScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class MagnitudeScoringParameters
    {
        public MagnitudeScoringParameters(double boostingRangeStart, double boostingRangeEnd) { }
        public double BoostingRangeEnd { get { throw null; } set { } }
        public double BoostingRangeStart { get { throw null; } set { } }
        public bool? ShouldBoostBeyondRangeByConstant { get { throw null; } set { } }
    }
    public partial class MappingCharFilter : Azure.Search.Documents.Indexes.Models.CharFilter
    {
        public MappingCharFilter(string name, System.Collections.Generic.IEnumerable<string> mappings) { }
        public System.Collections.Generic.IList<string> Mappings { get { throw null; } }
    }
    public partial class MergeSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public MergeSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string InsertPostTag { get { throw null; } set { } }
        public string InsertPreTag { get { throw null; } set { } }
    }
    public partial class MicrosoftLanguageStemmingTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public MicrosoftLanguageStemmingTokenizer(string name) { }
        public bool? IsSearchTokenizer { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.MicrosoftStemmingTokenizerLanguage? Language { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class MicrosoftLanguageTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public MicrosoftLanguageTokenizer(string name) { }
        public bool? IsSearchTokenizer { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.MicrosoftTokenizerLanguage? Language { get { throw null; } set { } }
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
    public partial class NGramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public NGramTokenFilter(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
    }
    public partial class NGramTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public NGramTokenizer(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenCharacterKind> TokenChars { get { throw null; } }
    }
    public partial class OcrSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public OcrSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.OcrSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? ShouldDetectOrientation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OcrSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.OcrSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OcrSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ro { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage SrCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage SrLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage ZhHant { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.OcrSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.OcrSkillLanguage left, Azure.Search.Documents.Indexes.Models.OcrSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.OcrSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.OcrSkillLanguage left, Azure.Search.Documents.Indexes.Models.OcrSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputFieldMappingEntry
    {
        public OutputFieldMappingEntry(string name) { }
        public string Name { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    public partial class PathHierarchyTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public PathHierarchyTokenizer(string name) { }
        public char? Delimiter { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
        public int? NumberOfTokensToSkip { get { throw null; } set { } }
        public char? Replacement { get { throw null; } set { } }
        public bool? ReverseTokenOrder { get { throw null; } set { } }
    }
    public partial class PatternAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer
    {
        public PatternAnalyzer(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.RegexFlag> Flags { get { throw null; } }
        public bool? LowerCaseTerms { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
    }
    public partial class PatternCaptureTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public PatternCaptureTokenFilter(string name, System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        public bool? PreserveOriginal { get { throw null; } set { } }
    }
    public partial class PatternReplaceCharFilter : Azure.Search.Documents.Indexes.Models.CharFilter
    {
        public PatternReplaceCharFilter(string name, string pattern, string replacement) { }
        public string Pattern { get { throw null; } set { } }
        public string Replacement { get { throw null; } set { } }
    }
    public partial class PatternReplaceTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public PatternReplaceTokenFilter(string name, string pattern, string replacement) { }
        public string Pattern { get { throw null; } set { } }
        public string Replacement { get { throw null; } set { } }
    }
    public partial class PatternTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public PatternTokenizer(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.RegexFlag> Flags { get { throw null; } }
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
    public partial class PhoneticTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public PhoneticTokenFilter(string name) { }
        public Azure.Search.Documents.Indexes.Models.PhoneticEncoder? Encoder { get { throw null; } set { } }
        public bool? ReplaceOriginalTokens { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegexFlag : System.IEquatable<Azure.Search.Documents.Indexes.Models.RegexFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegexFlag(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag CanonEq { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag CaseInsensitive { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag Comments { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag DotAll { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag Literal { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag Multiline { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag UnicodeCase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RegexFlag UnixLines { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.RegexFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.RegexFlag left, Azure.Search.Documents.Indexes.Models.RegexFlag right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.RegexFlag (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.RegexFlag left, Azure.Search.Documents.Indexes.Models.RegexFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScoringFunction
    {
        internal ScoringFunction() { }
        public double Boost { get { throw null; } set { } }
        public string FieldName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.ScoringFunctionInterpolation? Interpolation { get { throw null; } set { } }
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
        public ScoringProfile(string name) { }
        public Azure.Search.Documents.Indexes.Models.ScoringFunctionAggregation? FunctionAggregation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ScoringFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextWeights TextWeights { get { throw null; } set { } }
    }
    public partial class SearchableField : Azure.Search.Documents.Indexes.Models.SimpleField
    {
        public SearchableField(string name, bool collection = false) : base (default(string), default(Azure.Search.Documents.Indexes.Models.SearchFieldDataType)) { }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? AnalyzerName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? IndexAnalyzerName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? SearchAnalyzerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SynonymMapNames { get { throw null; } }
    }
    public partial class SearchField
    {
        public SearchField(string name, Azure.Search.Documents.Indexes.Models.SearchFieldDataType type) { }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? AnalyzerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchField> Fields { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? IndexAnalyzerName { get { throw null; } set { } }
        public bool? IsFacetable { get { throw null; } set { } }
        public bool? IsFilterable { get { throw null; } set { } }
        public bool? IsHidden { get { throw null; } set { } }
        public bool? IsKey { get { throw null; } set { } }
        public bool? IsSearchable { get { throw null; } set { } }
        public bool? IsSortable { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? SearchAnalyzerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SynonymMapNames { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchFieldDataType Type { get { throw null; } }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchFieldDataType : System.IEquatable<Azure.Search.Documents.Indexes.Models.SearchFieldDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchFieldDataType(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Boolean { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Complex { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType DateTimeOffset { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Double { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType GeographyPoint { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Int32 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Int64 { get { throw null; } }
        public bool IsCollection { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType String { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Collection(Azure.Search.Documents.Indexes.Models.SearchFieldDataType type) { throw null; }
        public bool Equals(Azure.Search.Documents.Indexes.Models.SearchFieldDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.SearchFieldDataType left, Azure.Search.Documents.Indexes.Models.SearchFieldDataType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.SearchFieldDataType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.SearchFieldDataType left, Azure.Search.Documents.Indexes.Models.SearchFieldDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SearchFieldTemplate
    {
        internal SearchFieldTemplate() { }
        public string Name { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchFieldDataType Type { get { throw null; } }
        public static implicit operator Azure.Search.Documents.Indexes.Models.SearchField (Azure.Search.Documents.Indexes.Models.SearchFieldTemplate value) { throw null; }
    }
    public partial class SearchIndex
    {
        public SearchIndex(string name) { }
        public SearchIndex(string name, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchField> fields) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer> Analyzers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CharFilter> CharFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.CorsOptions CorsOptions { get { throw null; } set { } }
        public string DefaultScoringProfile { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchField> Fields { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ScoringProfile> ScoringProfiles { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm Similarity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchSuggester> Suggesters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilter> TokenFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalTokenizer> Tokenizers { get { throw null; } }
    }
    public partial class SearchIndexer
    {
        public SearchIndexer(string name, string dataSourceName, string targetIndexName) { }
        public string DataSourceName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.FieldMapping> FieldMappings { get { throw null; } }
        public bool? IsDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.FieldMapping> OutputFieldMappings { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexingParameters Parameters { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.IndexingSchedule Schedule { get { throw null; } set { } }
        public string SkillsetName { get { throw null; } set { } }
        public string TargetIndexName { get { throw null; } set { } }
    }
    public partial class SearchIndexerDataContainer
    {
        public SearchIndexerDataContainer(string name) { }
        public string Name { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class SearchIndexerDataSourceConnection
    {
        public SearchIndexerDataSourceConnection(string name, Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType type, string connectionString, Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer container) { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer Container { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy DataChangeDetectionPolicy { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy DataDeletionDetectionPolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchIndexerDataSourceType : System.IEquatable<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchIndexerDataSourceType(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType AzureBlob { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType AzureSql { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType AzureTable { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType CosmosDb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType MySql { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType left, Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType left, Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchIndexerError
    {
        internal SearchIndexerError() { }
        public string Details { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Key { get { throw null; } }
        public string Name { get { throw null; } }
        public int StatusCode { get { throw null; } }
    }
    public partial class SearchIndexerLimits
    {
        internal SearchIndexerLimits() { }
        public long? MaxDocumentContentCharactersToExtract { get { throw null; } }
        public long? MaxDocumentExtractionSize { get { throw null; } }
        public System.TimeSpan? MaxRunTime { get { throw null; } }
    }
    public partial class SearchIndexerSkill
    {
        internal SearchIndexerSkill() { }
        public string Context { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> Outputs { get { throw null; } }
    }
    public partial class SearchIndexerSkillset
    {
        public SearchIndexerSkillset(string name, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill> skills) { }
        public Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount CognitiveServicesAccount { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill> Skills { get { throw null; } }
    }
    public partial class SearchIndexerStatus
    {
        internal SearchIndexerStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> ExecutionHistory { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionResult LastResult { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerLimits Limits { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerStatus Status { get { throw null; } }
    }
    public partial class SearchIndexerWarning
    {
        internal SearchIndexerWarning() { }
        public string Details { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public string Key { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SearchIndexStatistics
    {
        internal SearchIndexStatistics() { }
        public long DocumentCount { get { throw null; } }
        public long StorageSize { get { throw null; } }
    }
    public partial class SearchResourceCounter
    {
        internal SearchResourceCounter() { }
        public long? Quota { get { throw null; } }
        public long Usage { get { throw null; } }
    }
    public partial class SearchResourceEncryptionKey
    {
        public SearchResourceEncryptionKey(System.Uri vaultUri, string keyName, string keyVersion) { }
        public string ApplicationId { get { throw null; } set { } }
        public string ApplicationSecret { get { throw null; } set { } }
        public string KeyName { get { throw null; } }
        public string KeyVersion { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
    }
    public partial class SearchServiceCounters
    {
        internal SearchServiceCounters() { }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter DataSourceCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter DocumentCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter IndexCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter IndexerCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter StorageSizeCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter SynonymMapCounter { get { throw null; } }
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
        public Azure.Search.Documents.Indexes.Models.SearchServiceCounters Counters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchServiceLimits Limits { get { throw null; } }
    }
    public partial class SearchSuggester
    {
        public SearchSuggester(string name, System.Collections.Generic.IEnumerable<string> sourceFields) { }
        public SearchSuggester(string name, params string[] sourceFields) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFields { get { throw null; } }
    }
    public partial class SentimentSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public SentimentSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SentimentSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SentimentSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage No { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage PtPT { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage Tr { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage left, Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage left, Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShaperSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public ShaperSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
    }
    public partial class ShingleTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public ShingleTokenFilter(string name) { }
        public string FilterToken { get { throw null; } set { } }
        public int? MaxShingleSize { get { throw null; } set { } }
        public int? MinShingleSize { get { throw null; } set { } }
        public bool? OutputUnigrams { get { throw null; } set { } }
        public bool? OutputUnigramsIfNoShingles { get { throw null; } set { } }
        public string TokenSeparator { get { throw null; } set { } }
    }
    public partial class SimilarityAlgorithm
    {
        internal SimilarityAlgorithm() { }
    }
    public partial class SimpleField : Azure.Search.Documents.Indexes.Models.SearchFieldTemplate
    {
        public SimpleField(string name, Azure.Search.Documents.Indexes.Models.SearchFieldDataType type) { }
        public bool IsFacetable { get { throw null; } set { } }
        public bool IsFilterable { get { throw null; } set { } }
        public bool IsHidden { get { throw null; } set { } }
        public bool IsKey { get { throw null; } set { } }
        public bool IsSortable { get { throw null; } set { } }
    }
    public partial class SnowballTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public SnowballTokenFilter(string name, Azure.Search.Documents.Indexes.Models.SnowballTokenFilterLanguage language) { }
        public Azure.Search.Documents.Indexes.Models.SnowballTokenFilterLanguage Language { get { throw null; } set { } }
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
    public partial class SoftDeleteColumnDeletionDetectionPolicy : Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy
    {
        public SoftDeleteColumnDeletionDetectionPolicy() { }
        public string SoftDeleteColumnName { get { throw null; } set { } }
        public string SoftDeleteMarkerValue { get { throw null; } set { } }
    }
    public partial class SplitSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public SplitSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.SplitSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public int? MaximumPageLength { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextSplitMode? TextSplitMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SplitSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.SplitSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SplitSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Pt { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.SplitSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.SplitSkillLanguage left, Azure.Search.Documents.Indexes.Models.SplitSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.SplitSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.SplitSkillLanguage left, Azure.Search.Documents.Indexes.Models.SplitSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlIntegratedChangeTrackingPolicy : Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy
    {
        public SqlIntegratedChangeTrackingPolicy() { }
    }
    public partial class StemmerOverrideTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public StemmerOverrideTokenFilter(string name, System.Collections.Generic.IEnumerable<string> rules) { }
        public System.Collections.Generic.IList<string> Rules { get { throw null; } }
    }
    public partial class StemmerTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public StemmerTokenFilter(string name, Azure.Search.Documents.Indexes.Models.StemmerTokenFilterLanguage language) { }
        public Azure.Search.Documents.Indexes.Models.StemmerTokenFilterLanguage Language { get { throw null; } set { } }
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
    public partial class StopAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer
    {
        public StopAnalyzer(string name) { }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
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
    public partial class StopwordsTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public StopwordsTokenFilter(string name) { }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? RemoveTrailingStopWords { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.StopwordsList? StopwordsList { get { throw null; } set { } }
    }
    public partial class SynonymMap
    {
        public SynonymMap(string name, System.IO.TextReader reader) { }
        public SynonymMap(string name, string synonyms) { }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Synonyms { get { throw null; } set { } }
    }
    public partial class SynonymTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public SynonymTokenFilter(string name, System.Collections.Generic.IEnumerable<string> synonyms) { }
        public bool? Expand { get { throw null; } set { } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Synonyms { get { throw null; } }
    }
    public partial class TagScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction
    {
        public TagScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.TagScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.TagScoringParameters Parameters { get { throw null; } set { } }
    }
    public partial class TagScoringParameters
    {
        public TagScoringParameters(string tagsParameter) { }
        public string TagsParameter { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextSplitMode : System.IEquatable<Azure.Search.Documents.Indexes.Models.TextSplitMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextSplitMode(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.TextSplitMode Pages { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextSplitMode Sentences { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.TextSplitMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.TextSplitMode left, Azure.Search.Documents.Indexes.Models.TextSplitMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.TextSplitMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.TextSplitMode left, Azure.Search.Documents.Indexes.Models.TextSplitMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextTranslationSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public TextTranslationSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage defaultToLanguageCode) { }
        public Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage? DefaultFromLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage DefaultToLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage? SuggestedFrom { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextTranslationSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextTranslationSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Af { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Bg { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Bn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Bs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ca { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Cy { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Et { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Fa { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Fil { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Fj { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage He { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Hi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Hr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ht { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Id { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Is { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Lt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Lv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Mg { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ms { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Mt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Mww { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Otq { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ro { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Sk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Sl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Sm { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage SrCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage SrLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Sw { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ta { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Te { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Th { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Tlh { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage To { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ty { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Uk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ur { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Vi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Yua { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Yue { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage ZhHant { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage left, Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage left, Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextWeights
    {
        public TextWeights(System.Collections.Generic.IDictionary<string, double> weights) { }
        public System.Collections.Generic.IDictionary<string, double> Weights { get { throw null; } }
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
        internal TokenFilter() { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TokenFilterName : System.IEquatable<Azure.Search.Documents.Indexes.Models.TokenFilterName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TokenFilterName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Apostrophe { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName ArabicNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName AsciiFolding { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName CjkBigram { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName CjkWidth { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Classic { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName CommonGram { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName EdgeNGram { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Elision { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName GermanNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName HindiNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName IndicNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName KeywordRepeat { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName KStem { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Length { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Limit { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Lowercase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName NGram { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName PersianNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Phonetic { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName PorterStem { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Reverse { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName ScandinavianFoldingNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName ScandinavianNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Shingle { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Snowball { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName SoraniNormalization { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Stemmer { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Stopwords { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Trim { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Truncate { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Unique { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName Uppercase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TokenFilterName WordDelimiter { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.TokenFilterName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.TokenFilterName left, Azure.Search.Documents.Indexes.Models.TokenFilterName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.TokenFilterName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.TokenFilterName left, Azure.Search.Documents.Indexes.Models.TokenFilterName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TruncateTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public TruncateTokenFilter(string name) { }
        public int? Length { get { throw null; } set { } }
    }
    public partial class UaxUrlEmailTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer
    {
        public UaxUrlEmailTokenizer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
    }
    public partial class UniqueTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public UniqueTokenFilter(string name) { }
        public bool? OnlyOnSamePosition { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VisualFeature : System.IEquatable<Azure.Search.Documents.Indexes.Models.VisualFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VisualFeature(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.VisualFeature Adult { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VisualFeature Brands { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VisualFeature Categories { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VisualFeature Description { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VisualFeature Faces { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VisualFeature Objects { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VisualFeature Tags { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.VisualFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.VisualFeature left, Azure.Search.Documents.Indexes.Models.VisualFeature right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.VisualFeature (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.VisualFeature left, Azure.Search.Documents.Indexes.Models.VisualFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebApiSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public WebApiSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, string uri) { }
        public int? BatchSize { get { throw null; } set { } }
        public int? DegreeOfParallelism { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> HttpHeaders { get { throw null; } }
        public string HttpMethod { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public partial class WordDelimiterTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public WordDelimiterTokenFilter(string name) { }
        public bool? CatenateAll { get { throw null; } set { } }
        public bool? CatenateNumbers { get { throw null; } set { } }
        public bool? CatenateWords { get { throw null; } set { } }
        public bool? GenerateNumberParts { get { throw null; } set { } }
        public bool? GenerateWordParts { get { throw null; } set { } }
        public bool? PreserveOriginal { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtectedWords { get { throw null; } }
        public bool? SplitOnCaseChange { get { throw null; } set { } }
        public bool? SplitOnNumerics { get { throw null; } set { } }
        public bool? StemEnglishPossessive { get { throw null; } set { } }
    }
}
namespace Azure.Search.Documents.Models
{
    public partial class AutocompleteItem
    {
        internal AutocompleteItem() { }
        public string QueryPlusText { get { throw null; } }
        public string Text { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.AutocompleteItem> Results { get { throw null; } }
    }
    public partial class FacetResult : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal FacetResult() { }
        public long? Count { get { throw null; } }
        public Azure.Search.Documents.Models.FacetType FacetType { get { throw null; } }
        public object From { get { throw null; } }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public object To { get { throw null; } }
        public object Value { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public Azure.Search.Documents.Models.RangeFacetResult<T> AsRangeFacetResult<T>() where T : struct { throw null; }
        public Azure.Search.Documents.Models.ValueFacetResult<T> AsValueFacetResult<T>() { throw null; }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public enum FacetType
    {
        Value = 0,
        Range = 1,
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
        public static Azure.Search.Documents.Models.IndexDocumentsAction<Azure.Search.Documents.Models.SearchDocument> Delete(string keyName, string keyValue) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<T> Delete<T>(T document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<T> MergeOrUpload<T>(T document) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsAction<T> Merge<T>(T document) { throw null; }
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
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<Azure.Search.Documents.Models.SearchDocument> Delete(string keyName, System.Collections.Generic.IEnumerable<string> keyValues) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> Delete<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> MergeOrUpload<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsBatch<T> Merge<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.IndexingResult> Results { get { throw null; } }
    }
    public partial class IndexingResult
    {
        internal IndexingResult() { }
        public string ErrorMessage { get { throw null; } }
        public string Key { get { throw null; } }
        public int Status { get { throw null; } }
        public bool Succeeded { get { throw null; } }
    }
    public partial class RangeFacetResult<T> where T : struct
    {
        public RangeFacetResult(long count, T? from, T? to) { }
        public long Count { get { throw null; } }
        public T? From { get { throw null; } }
        public T? To { get { throw null; } }
    }
    public enum ScoringStatistics
    {
        Local = 0,
        Global = 1,
    }
    public partial class SearchDocument : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public SearchDocument() { }
        public SearchDocument(System.Collections.Generic.IDictionary<string, object> values) { }
        public int Count { get { throw null; } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        System.Collections.Generic.ICollection<object> System.Collections.Generic.IDictionary<System.String,System.Object>.Values { get { throw null; } }
        public void Add(string key, object value) { }
        public void Clear() { }
        public bool ContainsKey(string key) { throw null; }
        public bool? GetBoolean(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<bool> GetBooleanCollection(string key) { throw null; }
        public System.DateTimeOffset? GetDateTimeOffset(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> GetDateTimeOffsetCollection(string key) { throw null; }
        public double? GetDouble(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<double> GetDoubleCollection(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public int? GetInt32(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<int> GetInt32Collection(string key) { throw null; }
        public long? GetInt64(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<long> GetInt64Collection(string key) { throw null; }
        public Azure.Search.Documents.Models.SearchDocument GetObject(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchDocument> GetObjectCollection(string key) { throw null; }
        public string GetString(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<string> GetStringCollection(string key) { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> item) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public override string ToString() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public enum SearchMode
    {
        Any = 0,
        All = 1,
    }
    public static partial class SearchModelFactory
    {
        public static Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo AnalyzedTokenInfo(string token, int startOffset, int endOffset, int position) { throw null; }
        public static Azure.Search.Documents.Models.AutocompleteItem AutocompleteItem(string text, string queryPlusText) { throw null; }
        public static Azure.Search.Documents.Models.AutocompleteResults AutocompleteResults(double? coverage, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.AutocompleteItem> results) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CharFilter CharFilter(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount CognitiveServicesAccount(string oDataType, string description) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy DataChangeDetectionPolicy(string oDataType) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy DataDeletionDetectionPolicy(string oDataType) { throw null; }
        public static Azure.Search.Documents.Models.FacetResult FacetResult(long? count, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsResult IndexDocumentsResult(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.IndexingResult> results) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionResult IndexerExecutionResult(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus status, string errorMessage, System.DateTimeOffset? startTime, System.DateTimeOffset? endTime, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerError> errors, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> warnings, int itemCount, int failedItemCount, string initialTrackingState, string finalTrackingState) { throw null; }
        public static Azure.Search.Documents.Models.IndexingResult IndexingResult(string key, string errorMessage, bool succeeded, int status) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzer LexicalAnalyzer(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizer LexicalTokenizer(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ScoringFunction ScoringFunction(string type, string fieldName, double boost, Azure.Search.Documents.Indexes.Models.ScoringFunctionInterpolation? interpolation) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerError SearchIndexerError(string key, string errorMessage, int statusCode, string name, string details, string documentationLink) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerLimits SearchIndexerLimits(System.TimeSpan? maxRunTime, long? maxDocumentExtractionSize, long? maxDocumentContentCharactersToExtract) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerSkill SearchIndexerSkill(string oDataType, string name, string description, string context, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(Azure.Search.Documents.Indexes.Models.IndexerStatus status, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerWarning SearchIndexerWarning(string key, string message, string name, string details, string documentationLink) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexStatistics SearchIndexStatistics(long documentCount, long storageSize) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchResourceCounter SearchResourceCounter(long usage, long? quota) { throw null; }
        public static Azure.Search.Documents.Models.SearchResultsPage<T> SearchResultsPage<T>(Azure.Search.Documents.Models.SearchResults<T> results) { throw null; }
        public static Azure.Search.Documents.Models.SearchResults<T> SearchResults<T>(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchResult<T>> values, long? totalCount, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> facets, double? coverage, Azure.Response rawResponse) { throw null; }
        public static Azure.Search.Documents.Models.SearchResult<T> SearchResult<T>(T document, double? score, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> highlights) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceCounters SearchServiceCounters(Azure.Search.Documents.Indexes.Models.SearchResourceCounter documentCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexerCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter dataSourceCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter storageSizeCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter synonymMapCounter) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceLimits SearchServiceLimits(int? maxFieldsPerIndex, int? maxFieldNestingDepthPerIndex, int? maxComplexCollectionFieldsPerIndex, int? maxComplexObjectsInCollectionsPerDocument) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceStatistics SearchServiceStatistics(Azure.Search.Documents.Indexes.Models.SearchServiceCounters counters, Azure.Search.Documents.Indexes.Models.SearchServiceLimits limits) { throw null; }
        public static Azure.Search.Documents.Models.SearchSuggestion<T> SearchSuggestion<T>(T document, string text) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm SimilarityAlgorithm(string oDataType) { throw null; }
        public static Azure.Search.Documents.Models.SuggestResults<T> SuggestResults<T>(System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchSuggestion<T>> results, double? coverage) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.TokenFilter TokenFilter(string oDataType, string name) { throw null; }
    }
    public enum SearchQueryType
    {
        Simple = 0,
        Full = 1,
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
    public partial class SearchSuggestion<T>
    {
        internal SearchSuggestion() { }
        public T Document { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class SuggestResults<T>
    {
        internal SuggestResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchSuggestion<T>> Results { get { throw null; } }
    }
    public partial class ValueFacetResult<T>
    {
        public ValueFacetResult(long count, T value) { }
        public long Count { get { throw null; } }
        public T Value { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class SearchClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Search.Documents.SearchClient, Azure.Search.Documents.SearchClientOptions> AddSearchClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string indexName, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Search.Documents.SearchClient, Azure.Search.Documents.SearchClientOptions> AddSearchClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Search.Documents.Indexes.SearchIndexClient, Azure.Search.Documents.SearchClientOptions> AddSearchIndexClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Search.Documents.Indexes.SearchIndexClient, Azure.Search.Documents.SearchClientOptions> AddSearchIndexClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
