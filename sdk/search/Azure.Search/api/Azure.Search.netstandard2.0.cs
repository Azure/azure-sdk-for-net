namespace Azure.Search
{
    public partial class AutocompleteOptions : Azure.Search.SearchRequestOptions
    {
        public AutocompleteOptions() { }
        public string Filter { get { throw null; } set { } }
        public string HighlightPostTag { get { throw null; } set { } }
        public string HighlightPreTag { get { throw null; } set { } }
        public double? MinimumCoverage { get { throw null; } set { } }
        public Azure.Search.Models.AutocompleteMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchFields { get { throw null; } }
        public int? Size { get { throw null; } set { } }
        public bool? UseFuzzyMatching { get { throw null; } set { } }
    }
    public partial class GetDocumentOptions : Azure.Search.SearchRequestOptions
    {
        public GetDocumentOptions() { }
        public System.Collections.Generic.IList<string> SelectedFields { get { throw null; } }
    }
    public partial class IndexDocumentsOptions : Azure.Search.SearchRequestOptions
    {
        public IndexDocumentsOptions() { }
        public bool ThrowOnAnyError { get { throw null; } set { } }
    }
    public partial class SearchApiKeyCredential
    {
        public SearchApiKeyCredential(string apiKey) { }
        public void Refresh(string apiKey) { }
    }
    public partial class SearchClientOptions : Azure.Core.ClientOptions
    {
        public SearchClientOptions(Azure.Search.SearchClientOptions.ServiceVersion version = Azure.Search.SearchClientOptions.ServiceVersion.V2019_05_06_Preview) { }
        public Azure.Search.SearchClientOptions.ServiceVersion Version { get { throw null; } }
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
        public SearchIndexClient(System.Uri endpoint, string indexName, Azure.Search.SearchApiKeyCredential credential) { }
        public SearchIndexClient(System.Uri endpoint, string indexName, Azure.Search.SearchApiKeyCredential credential, Azure.Search.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string IndexName { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<Azure.Search.Models.AutocompleteResults> Autocomplete(string searchText, string suggesterName, Azure.Search.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.AutocompleteResults>> AutocompleteAsync(string searchText, string suggesterName, Azure.Search.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.SearchDocument> GetDocument(string key, Azure.Search.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.SearchDocument>> GetDocumentAsync(string key, Azure.Search.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetDocumentAsync<T>(string key, Azure.Search.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<long> GetDocumentCount(Azure.Search.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<long>> GetDocumentCountAsync(Azure.Search.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetDocument<T>(string key, Azure.Search.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.IndexDocumentsResult> IndexDocuments(Azure.Search.Models.IndexDocumentsBatch<Azure.Search.Models.SearchDocument> documents, Azure.Search.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.IndexDocumentsResult>> IndexDocumentsAsync(Azure.Search.Models.IndexDocumentsBatch<Azure.Search.Models.SearchDocument> documents, Azure.Search.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.IndexDocumentsResult>> IndexDocumentsAsync<T>(Azure.Search.Models.IndexDocumentsBatch<T> documents, Azure.Search.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.IndexDocumentsResult> IndexDocuments<T>(Azure.Search.Models.IndexDocumentsBatch<T> documents, Azure.Search.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.SearchResults<Azure.Search.Models.SearchDocument>> Search(string searchText, Azure.Search.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.SearchResults<Azure.Search.Models.SearchDocument>>> SearchAsync(string searchText, Azure.Search.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.SearchResults<T>>> SearchAsync<T>(string searchText, Azure.Search.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.SearchResults<T>> Search<T>(string searchText, Azure.Search.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.SuggestResults<Azure.Search.Models.SearchDocument>> Suggest(string searchText, string suggesterName, Azure.Search.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.SuggestResults<Azure.Search.Models.SearchDocument>>> SuggestAsync(string searchText, string suggesterName, Azure.Search.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.SuggestResults<T>>> SuggestAsync<T>(string searchText, string suggesterName, Azure.Search.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.SuggestResults<T>> Suggest<T>(string searchText, string suggesterName, Azure.Search.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchOptions : Azure.Search.SearchRequestOptions
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
        public Azure.Search.Models.SearchQueryType? QueryType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScoringParameters { get { throw null; } }
        public string ScoringProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchFields { get { throw null; } }
        public Azure.Search.Models.SearchMode? SearchMode { get { throw null; } set { } }
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
        public SearchServiceClient(System.Uri endpoint, Azure.Search.SearchApiKeyCredential credential) { }
        public SearchServiceClient(System.Uri endpoint, Azure.Search.SearchApiKeyCredential credential, Azure.Search.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Search.SearchIndexClient GetSearchIndexClient(string indexName) { throw null; }
        public virtual Azure.Response<Azure.Search.Models.SearchServiceStatistics> GetStatistics(Azure.Search.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Models.SearchServiceStatistics>> GetStatisticsAsync(Azure.Search.SearchRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SuggestOptions : Azure.Search.SearchRequestOptions
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
namespace Azure.Search.Models
{
    public enum AutocompleteMode
    {
        OneTerm = 0,
        TwoTerms = 1,
        OneTermWithContext = 2,
    }
    public partial class AutocompleteResults
    {
        public AutocompleteResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Models.Autocompletion> Results { get { throw null; } }
    }
    public partial class Autocompletion
    {
        public Autocompletion() { }
        public string QueryPlusText { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class FacetResult : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public FacetResult() { }
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
    public enum IndexActionType
    {
        Upload = 0,
        Merge = 1,
        MergeOrUpload = 2,
        Delete = 3,
    }
    public static partial class IndexDocumentsAction
    {
        public static Azure.Search.Models.IndexDocumentsAction<Azure.Search.Models.SearchDocument> Delete(Azure.Search.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<Azure.Search.Models.SearchDocument> Delete(string keyName, string keyValue) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<T> Delete<T>(T document) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<Azure.Search.Models.SearchDocument> Merge(Azure.Search.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<Azure.Search.Models.SearchDocument> MergeOrUpload(Azure.Search.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<T> MergeOrUpload<T>(T document) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<T> Merge<T>(T document) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<Azure.Search.Models.SearchDocument> Upload(Azure.Search.Models.SearchDocument document) { throw null; }
        public static Azure.Search.Models.IndexDocumentsAction<T> Upload<T>(T document) { throw null; }
    }
    public partial class IndexDocumentsAction<T>
    {
        public IndexDocumentsAction(Azure.Search.Models.IndexActionType type, T doc) { }
        public Azure.Search.Models.IndexActionType ActionType { get { throw null; } }
        public T Document { get { throw null; } }
    }
    public static partial class IndexDocumentsBatch
    {
        public static Azure.Search.Models.IndexDocumentsBatch<T> Create<T>(params Azure.Search.Models.IndexDocumentsAction<T>[] actions) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<Azure.Search.Models.SearchDocument> Delete(System.Collections.Generic.IEnumerable<Azure.Search.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<Azure.Search.Models.SearchDocument> Delete(string keyName, System.Collections.Generic.IEnumerable<string> keyValues) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<T> Delete<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<Azure.Search.Models.SearchDocument> Merge(System.Collections.Generic.IEnumerable<Azure.Search.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<Azure.Search.Models.SearchDocument> MergeOrUpload(System.Collections.Generic.IEnumerable<Azure.Search.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<T> MergeOrUpload<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<T> Merge<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<Azure.Search.Models.SearchDocument> Upload(System.Collections.Generic.IEnumerable<Azure.Search.Models.SearchDocument> documents) { throw null; }
        public static Azure.Search.Models.IndexDocumentsBatch<T> Upload<T>(System.Collections.Generic.IEnumerable<T> documents) { throw null; }
    }
    public partial class IndexDocumentsBatch<T>
    {
        public IndexDocumentsBatch() { }
        public System.Collections.Generic.IList<Azure.Search.Models.IndexDocumentsAction<T>> Actions { get { throw null; } }
    }
    public partial class IndexDocumentsResult
    {
        public IndexDocumentsResult() { }
        public System.Collections.Generic.IList<Azure.Search.Models.IndexingResult> Results { get { throw null; } }
    }
    public partial class IndexingResult
    {
        public IndexingResult() { }
        public string ErrorMessage { get { throw null; } }
        public string Key { get { throw null; } }
        public int Status { get { throw null; } }
        public bool Succeeded { get { throw null; } }
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
    public enum SearchMode
    {
        Any = 0,
        All = 1,
    }
    public enum SearchQueryType
    {
        Simple = 0,
        Full = 1,
    }
    public partial class SearchResourceCounter
    {
        public SearchResourceCounter() { }
        public long? Quota { get { throw null; } set { } }
        public long Usage { get { throw null; } set { } }
    }
    public partial class SearchResultsPage<T> : Azure.Page<Azure.Search.Models.SearchResult<T>>
    {
        internal SearchResultsPage() { }
        public override string ContinuationToken { get { throw null; } }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Models.FacetResult>> Facets { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.Search.Models.SearchResult<T>> Values { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
    }
    public partial class SearchResults<T>
    {
        internal SearchResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Models.FacetResult>> Facets { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public Azure.Pageable<Azure.Search.Models.SearchResult<T>> GetResults() { throw null; }
        public Azure.AsyncPageable<Azure.Search.Models.SearchResult<T>> GetResultsAsync() { throw null; }
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
        public SearchServiceCounters() { }
        public Azure.Search.Models.SearchResourceCounter DataSourceCounter { get { throw null; } set { } }
        public Azure.Search.Models.SearchResourceCounter DocumentCounter { get { throw null; } set { } }
        public Azure.Search.Models.SearchResourceCounter IndexCounter { get { throw null; } set { } }
        public Azure.Search.Models.SearchResourceCounter IndexerCounter { get { throw null; } set { } }
        public Azure.Search.Models.SearchResourceCounter SkillsetCounter { get { throw null; } set { } }
        public Azure.Search.Models.SearchResourceCounter StorageSizeCounter { get { throw null; } set { } }
        public Azure.Search.Models.SearchResourceCounter SynonymMapCounter { get { throw null; } set { } }
    }
    public partial class SearchServiceLimits
    {
        public SearchServiceLimits() { }
        public int? MaxComplexCollectionFieldsPerIndex { get { throw null; } set { } }
        public int? MaxComplexObjectsInCollectionsPerDocument { get { throw null; } set { } }
        public int? MaxFieldNestingDepthPerIndex { get { throw null; } set { } }
        public int? MaxFieldsPerIndex { get { throw null; } set { } }
    }
    public partial class SearchServiceStatistics
    {
        public SearchServiceStatistics() { }
        public Azure.Search.Models.SearchServiceCounters Counters { get { throw null; } set { } }
        public Azure.Search.Models.SearchServiceLimits Limits { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.Search.Models.SearchSuggestion<T>> Results { get { throw null; } }
    }
}
