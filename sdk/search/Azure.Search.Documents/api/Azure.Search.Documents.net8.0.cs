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
    public partial class AzureSearchDocumentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureSearchDocumentsContext() { }
        public static Azure.Search.Documents.AzureSearchDocumentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchAudience : System.IEquatable<Azure.Search.Documents.SearchAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchAudience(string value) { throw null; }
        public static Azure.Search.Documents.SearchAudience AzureChina { get { throw null; } }
        public static Azure.Search.Documents.SearchAudience AzureGovernment { get { throw null; } }
        public static Azure.Search.Documents.SearchAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Search.Documents.SearchAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.SearchAudience left, Azure.Search.Documents.SearchAudience right) { throw null; }
        public static implicit operator Azure.Search.Documents.SearchAudience (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.SearchAudience left, Azure.Search.Documents.SearchAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchClient
    {
        protected SearchClient() { }
        public SearchClient(System.Uri endpoint, string indexName, Azure.AzureKeyCredential credential) { }
        public SearchClient(System.Uri endpoint, string indexName, Azure.AzureKeyCredential credential, Azure.Search.Documents.SearchClientOptions options) { }
        public SearchClient(System.Uri endpoint, string indexName, Azure.Core.TokenCredential tokenCredential) { }
        public SearchClient(System.Uri endpoint, string indexName, Azure.Core.TokenCredential tokenCredential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string IndexName { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<Azure.Search.Documents.Models.AutocompleteResults> Autocomplete(string searchText, string suggesterName, Azure.Search.Documents.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.AutocompleteResults>> AutocompleteAsync(string searchText, string suggesterName, Azure.Search.Documents.AutocompleteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(Azure.Search.Documents.SearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(Azure.Search.Documents.SearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>>> SuggestAsync<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>> Suggest<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> UploadDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> UploadDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchClientOptions : Azure.Core.ClientOptions
    {
        public SearchClientOptions(Azure.Search.Documents.SearchClientOptions.ServiceVersion version = Azure.Search.Documents.SearchClientOptions.ServiceVersion.V2025_03_01_Preview) { }
        public Azure.Search.Documents.SearchAudience? Audience { get { throw null; } set { } }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public Azure.Search.Documents.SearchClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_06_30 = 1,
            V2023_11_01 = 2,
            V2024_07_01 = 3,
            V2025_03_01_Preview = 4,
        }
    }
    public static partial class SearchExtensions
    {
        public static Azure.Search.Documents.SearchClient GetSearchClient(this System.ClientModel.Primitives.ClientConnectionProvider provider, string indexName) { throw null; }
        public static Azure.Search.Documents.Indexes.SearchIndexClient GetSearchIndexClient(this System.ClientModel.Primitives.ClientConnectionProvider provider) { throw null; }
        public static Azure.Search.Documents.Indexes.SearchIndexerClient GetSearchIndexerClient(this System.ClientModel.Primitives.ClientConnectionProvider provider) { throw null; }
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
        public int MaxRetriesPerIndexAction { get { throw null; } set { } }
        public System.TimeSpan MaxThrottlingDelay { get { throw null; } set { } }
        public System.TimeSpan ThrottlingDelay { get { throw null; } set { } }
    }
    public partial class SearchIndexingBufferedSender<T> : System.IAsyncDisposable, System.IDisposable
    {
        protected SearchIndexingBufferedSender() { }
        public SearchIndexingBufferedSender(Azure.Search.Documents.SearchClient searchClient, Azure.Search.Documents.SearchIndexingBufferedSenderOptions<T> options = null) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string IndexName { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Search.Documents.Models.IndexActionEventArgs<T>> ActionAdded { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Search.Documents.Models.IndexActionCompletedEventArgs<T>> ActionCompleted { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Search.Documents.Models.IndexActionFailedEventArgs<T>> ActionFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Search.Documents.Models.IndexActionEventArgs<T>> ActionSent { add { } remove { } }
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
        protected internal virtual System.Threading.Tasks.Task OnActionAddedAsync(Azure.Search.Documents.Models.IndexDocumentsAction<T> action, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnActionCompletedAsync(Azure.Search.Documents.Models.IndexDocumentsAction<T> action, Azure.Search.Documents.Models.IndexingResult result, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnActionFailedAsync(Azure.Search.Documents.Models.IndexDocumentsAction<T> action, Azure.Search.Documents.Models.IndexingResult result, System.Exception exception, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnActionSentAsync(Azure.Search.Documents.Models.IndexDocumentsAction<T> action, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public Azure.Search.Documents.Models.HybridSearch HybridSearch { get { throw null; } set { } }
        public bool? IncludeTotalCount { get { throw null; } set { } }
        public double? MinimumCoverage { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OrderBy { get { throw null; } }
        public Azure.Search.Documents.Models.QueryLanguage? QueryLanguage { get { throw null; } set { } }
        public Azure.Search.Documents.Models.QuerySpellerType? QuerySpeller { get { throw null; } set { } }
        public Azure.Search.Documents.Models.SearchQueryType? QueryType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScoringParameters { get { throw null; } }
        public string ScoringProfile { get { throw null; } set { } }
        public Azure.Search.Documents.Models.ScoringStatistics? ScoringStatistics { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchFields { get { throw null; } }
        public Azure.Search.Documents.Models.SearchMode? SearchMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Select { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticSearchOptions SemanticSearch { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public Azure.Search.Documents.Models.VectorSearchOptions VectorSearch { get { throw null; } set { } }
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
        public SearchIndexClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential) { }
        public SearchIndexClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>> AnalyzeText(string indexName, Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>>> AnalyzeTextAsync(string indexName, Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias> CreateAlias(Azure.Search.Documents.Indexes.Models.SearchAlias alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias>> CreateAliasAsync(Azure.Search.Documents.Indexes.Models.SearchAlias alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex> CreateIndex(Azure.Search.Documents.Indexes.Models.SearchIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex>> CreateIndexAsync(Azure.Search.Documents.Indexes.Models.SearchIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias> CreateOrUpdateAlias(string aliasName, Azure.Search.Documents.Indexes.Models.SearchAlias alias, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias>> CreateOrUpdateAliasAsync(string aliasName, Azure.Search.Documents.Indexes.Models.SearchAlias alias, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex> CreateOrUpdateIndex(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool allowIndexDowntime = false, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex>> CreateOrUpdateIndexAsync(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool allowIndexDowntime = false, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap> CreateOrUpdateSynonymMap(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap>> CreateOrUpdateSynonymMapAsync(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap> CreateSynonymMap(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SynonymMap>> CreateSynonymMapAsync(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAlias(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAliasAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIndex(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIndex(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIndexAsync(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIndexAsync(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSynonymMap(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSynonymMap(string synonymMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSynonymMapAsync(Azure.Search.Documents.Indexes.Models.SynonymMap synonymMap, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSynonymMapAsync(string synonymMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias> GetAlias(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias>> GetAliasAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Search.Documents.Indexes.Models.SearchAlias> GetAliases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Search.Documents.Indexes.Models.SearchAlias> GetAliasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex> GetIndex(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex>> GetIndexAsync(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Search.Documents.Indexes.Models.SearchIndex> GetIndexes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Search.Documents.Indexes.Models.SearchIndex> GetIndexesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetIndexNames(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetIndexNamesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics> GetIndexStatistics(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>> GetIndexStatisticsAsync(string indexName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary> GetIndexStatsSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>> GetIndexStatsSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public SearchIndexerClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential) { }
        public SearchIndexerClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual string ServiceName { get { throw null; } }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection> CreateDataSourceConnection(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>> CreateDataSourceConnectionAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer> CreateIndexer(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer>> CreateIndexerAsync(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection> CreateOrUpdateDataSourceConnection(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged = false, bool? ignoreCacheResetRequirements = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection> CreateOrUpdateDataSourceConnection(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>> CreateOrUpdateDataSourceConnectionAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged = false, bool? ignoreCacheResetRequirements = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>> CreateOrUpdateDataSourceConnectionAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection dataSourceConnection, bool onlyIfUnchanged, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer> CreateOrUpdateIndexer(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged, bool disableCacheReprocessingChangeDetection, bool ignoreCacheResetRequirements, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer> CreateOrUpdateIndexer(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged = false, bool? ignoreCacheResetRequirements = default(bool?), bool? disableCacheReprocessingChangeDetection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer> CreateOrUpdateIndexer(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer>> CreateOrUpdateIndexerAsync(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged, bool disableCacheReprocessingChangeDetection, bool ignoreCacheResetRequirements, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer>> CreateOrUpdateIndexerAsync(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged = false, bool? ignoreCacheResetRequirements = default(bool?), bool? disableCacheReprocessingChangeDetection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexer>> CreateOrUpdateIndexerAsync(Azure.Search.Documents.Indexes.Models.SearchIndexer indexer, bool onlyIfUnchanged, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset> CreateOrUpdateSkillset(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged, bool disableCacheReprocessingChangeDetection, bool ignoreCacheResetRequirements, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset> CreateOrUpdateSkillset(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged = false, bool? ignoreCacheResetRequirements = default(bool?), bool? disableCacheReprocessingChangeDetection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset> CreateOrUpdateSkillset(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged, bool disableCacheReprocessingChangeDetection, bool ignoreCacheResetRequirements, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged = false, bool? ignoreCacheResetRequirements = default(bool?), bool? disableCacheReprocessingChangeDetection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset skillset, bool onlyIfUnchanged, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public virtual Azure.Response ResetDocuments(string indexerName, bool? overwrite = default(bool?), Azure.Search.Documents.Models.ResetDocumentOptions resetDocumentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetDocumentsAsync(string indexerName, bool? overwrite = default(bool?), Azure.Search.Documents.Models.ResetDocumentOptions resetDocumentOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetIndexer(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetIndexerAsync(string indexerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetSkills(string skillsetName, Azure.Search.Documents.Models.ResetSkillsOptions resetSkillsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetSkillsAsync(string skillsetName, Azure.Search.Documents.Models.ResetSkillsOptions resetSkillsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string NormalizerName { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
    public partial class VectorSearchFieldAttribute : System.Attribute
    {
        public VectorSearchFieldAttribute() { }
        public bool IsHidden { get { throw null; } set { } }
        public bool IsStored { get { throw null; } set { } }
        public string VectorEncodingFormat { get { throw null; } set { } }
        public int VectorSearchDimensions { get { throw null; } set { } }
        public string VectorSearchProfileName { get { throw null; } set { } }
    }
}
namespace Azure.Search.Documents.Indexes.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIFoundryModelCatalogName : System.IEquatable<Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIFoundryModelCatalogName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName CohereEmbedV3English { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName CohereEmbedV3Multilingual { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName FacebookDinoV2ImageEmbeddingsViTBase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName FacebookDinoV2ImageEmbeddingsViTGiant { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName OpenAIClipImageTextEmbeddingsVitBasePatch32 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName OpenAIClipImageTextEmbeddingsViTLargePatch14336 { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName left, Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName left, Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AIServicesAccountIdentity : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount
    {
        public AIServicesAccountIdentity(string subdomainUrl) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public string SubdomainUrl { get { throw null; } set { } }
    }
    public partial class AIServicesAccountKey : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount
    {
        public AIServicesAccountKey(string key, string subdomainUrl) { }
        public string Key { get { throw null; } set { } }
        public string SubdomainUrl { get { throw null; } set { } }
    }
    public partial class AIServicesVisionParameters
    {
        public AIServicesVisionParameters(string modelVersion, System.Uri resourceUri) { }
        public string ApiKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthIdentity { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
    }
    public partial class AIServicesVisionVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer
    {
        public AIServicesVisionVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters AIServicesVisionParameters { get { throw null; } set { } }
    }
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
        public AnalyzeTextOptions(string text, Azure.Search.Documents.Indexes.Models.LexicalNormalizerName normalizerName) { }
        public AnalyzeTextOptions(string text, Azure.Search.Documents.Indexes.Models.LexicalTokenizerName tokenizerName) { }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? AnalyzerName { get { throw null; } }
        public System.Collections.Generic.IList<string> CharFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalNormalizerName? NormalizerName { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilterName> TokenFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalTokenizerName? TokenizerName { get { throw null; } }
    }
    public partial class AsciiFoldingTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter
    {
        public AsciiFoldingTokenFilter(string name) { }
        public bool? PreserveOriginal { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningParameters
    {
        public AzureMachineLearningParameters(System.Uri scoringUri) { }
        public string AuthenticationKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName? ModelName { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public System.Uri ScoringUri { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public AzureMachineLearningSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Core.ResourceIdentifier resourceId, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { }
        public AzureMachineLearningSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, System.Uri scoringUri, string authenticationKey = null) { }
        public string AuthenticationKey { get { throw null; } }
        public int? DegreeOfParallelism { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.Uri ScoringUri { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer
    {
        public AzureMachineLearningVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters AMLParameters { get { throw null; } set { } }
    }
    public partial class AzureOpenAIEmbeddingSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public AzureOpenAIEmbeddingSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string ApiKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthenticationIdentity { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public int? Dimensions { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName? ModelName { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureOpenAIModelName : System.IEquatable<Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureOpenAIModelName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName TextEmbedding3Large { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName TextEmbedding3Small { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName TextEmbeddingAda002 { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName left, Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName left, Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureOpenAITokenizerParameters
    {
        public AzureOpenAITokenizerParameters() { }
        public System.Collections.Generic.IList<string> AllowedSpecialTokens { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName? EncoderModelName { get { throw null; } set { } }
    }
    public partial class AzureOpenAIVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer
    {
        public AzureOpenAIVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters Parameters { get { throw null; } set { } }
    }
    public partial class AzureOpenAIVectorizerParameters
    {
        public AzureOpenAIVectorizerParameters() { }
        public string ApiKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthenticationIdentity { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName? ModelName { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
    }
    public partial class BinaryQuantizationCompression : Azure.Search.Documents.Indexes.Models.VectorSearchCompression
    {
        public BinaryQuantizationCompression(string compressionName) : base (default(string)) { }
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
        public static Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode Markdown { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CharFilterName : System.IEquatable<Azure.Search.Documents.Indexes.Models.CharFilterName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CharFilterName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CharFilterName HtmlStrip { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.CharFilterName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.CharFilterName left, Azure.Search.Documents.Indexes.Models.CharFilterName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.CharFilterName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.CharFilterName left, Azure.Search.Documents.Indexes.Models.CharFilterName right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CustomEntity
    {
        public CustomEntity(string name) { }
        public bool? AccentSensitive { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CustomEntityAlias> Aliases { get { throw null; } }
        public bool? CaseSensitive { get { throw null; } set { } }
        public bool? DefaultAccentSensitive { get { throw null; } set { } }
        public bool? DefaultCaseSensitive { get { throw null; } set { } }
        public int? DefaultFuzzyEditDistance { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public int? FuzzyEditDistance { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Subtype { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class CustomEntityAlias
    {
        public CustomEntityAlias(string text) { }
        public bool? AccentSensitive { get { throw null; } set { } }
        public bool? CaseSensitive { get { throw null; } set { } }
        public int? FuzzyEditDistance { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    public partial class CustomEntityLookupSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public CustomEntityLookupSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public System.Uri EntitiesDefinitionUri { get { throw null; } set { } }
        public bool? GlobalDefaultAccentSensitive { get { throw null; } set { } }
        public bool? GlobalDefaultCaseSensitive { get { throw null; } set { } }
        public int? GlobalDefaultFuzzyEditDistance { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CustomEntity> InlineEntitiesDefinition { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomEntityLookupSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomEntityLookupSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage Pt { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage left, Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage left, Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomNormalizer : Azure.Search.Documents.Indexes.Models.LexicalNormalizer
    {
        public CustomNormalizer(string name) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CharFilterName> CharFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilterName> TokenFilters { get { throw null; } }
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
    public partial class DocumentExtractionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public DocumentExtractionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public System.Collections.Generic.IDictionary<string, object> Configuration { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract? DataToExtract { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode? ParsingMode { get { throw null; } set { } }
    }
    public partial class DocumentIntelligenceLayoutSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public DocumentIntelligenceLayoutSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth? MarkdownHeaderDepth { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode? OutputMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentIntelligenceLayoutSkillMarkdownHeaderDepth : System.IEquatable<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentIntelligenceLayoutSkillMarkdownHeaderDepth(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth H1 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth H2 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth H3 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth H4 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth H5 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth H6 { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentIntelligenceLayoutSkillOutputMode : System.IEquatable<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentIntelligenceLayoutSkillOutputMode(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode OneToMany { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class EntityLinkingSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public EntityLinkingSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string DefaultLanguageCode { get { throw null; } set { } }
        public double? MinimumPrecision { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
    }
    public partial class EntityRecognitionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public EntityRecognitionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public EntityRecognitionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion skillVersion) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.EntityCategory> Categories { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? IncludeTypelessEntities { get { throw null; } set { } }
        public double? MinimumPrecision { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct SkillVersion : System.IEquatable<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion>
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public SkillVersion(string value) { throw null; }
            public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion Latest { get { throw null; } }
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion V1 { get { throw null; } }
            public static Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion V3 { get { throw null; } }
            public bool Equals(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion other) { throw null; }
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public override bool Equals(object obj) { throw null; }
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public override int GetHashCode() { throw null; }
            public static bool operator ==(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion right) { throw null; }
            public static bool operator >=(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion right) { throw null; }
            public static implicit operator Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion (string value) { throw null; }
            public static bool operator !=(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion right) { throw null; }
            public static bool operator <=(Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion right) { throw null; }
            public override string ToString() { throw null; }
        }
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
    public partial class ExhaustiveKnnAlgorithmConfiguration : Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration
    {
        public ExhaustiveKnnAlgorithmConfiguration(string name) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters Parameters { get { throw null; } set { } }
    }
    public partial class ExhaustiveKnnParameters
    {
        public ExhaustiveKnnParameters() { }
        public Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric? Metric { get { throw null; } set { } }
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
    public partial class HnswAlgorithmConfiguration : Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration
    {
        public HnswAlgorithmConfiguration(string name) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.HnswParameters Parameters { get { throw null; } set { } }
    }
    public partial class HnswParameters
    {
        public HnswParameters() { }
        public int? EfConstruction { get { throw null; } set { } }
        public int? EfSearch { get { throw null; } set { } }
        public int? M { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric? Metric { get { throw null; } set { } }
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
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Az { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Bg { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Bs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ca { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Cy { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Et { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Eu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ga { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Gl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage He { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Hi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Hr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Id { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Kk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Lt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Lv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Mk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ms { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Prs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage PtBR { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage PtPT { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ro { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Sk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Sl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage SrCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage SrLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Th { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Uk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Vi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage Zh { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage ZhHant { get { throw null; } }
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
    public partial class IndexerChangeTrackingState
    {
        internal IndexerChangeTrackingState() { }
        public string AllDocumentsFinalState { get { throw null; } }
        public string AllDocumentsInitialState { get { throw null; } }
        public string ResetDocumentsFinalState { get { throw null; } }
        public string ResetDocumentsInitialState { get { throw null; } }
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
        public Azure.Search.Documents.Indexes.Models.IndexerState CurrentState { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerError> Errors { get { throw null; } }
        public int FailedItemCount { get { throw null; } }
        public string FinalTrackingState { get { throw null; } }
        public string InitialTrackingState { get { throw null; } }
        public int ItemCount { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus Status { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail? StatusDetail { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> Warnings { get { throw null; } }
    }
    public enum IndexerExecutionStatus
    {
        TransientFailure = 0,
        Success = 1,
        InProgress = 2,
        Reset = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexerExecutionStatusDetail : System.IEquatable<Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexerExecutionStatusDetail(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail ResetDocs { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail left, Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail left, Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexerState
    {
        internal IndexerState() { }
        public Azure.Search.Documents.Indexes.Models.IndexerChangeTrackingState ChangeTrackingState { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexingMode? Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResetDataSourceDocumentIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResetDocumentKeys { get { throw null; } }
    }
    public enum IndexerStatus
    {
        Unknown = 0,
        Error = 1,
        Running = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexingMode : System.IEquatable<Azure.Search.Documents.Indexes.Models.IndexingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexingMode(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexingMode AllDocuments { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.IndexingMode ResetDocuments { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.IndexingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.IndexingMode left, Azure.Search.Documents.Indexes.Models.IndexingMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.IndexingMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.IndexingMode left, Azure.Search.Documents.Indexes.Models.IndexingMode right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth? MarkdownHeaderDepth { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode? MarkdownParsingSubmode { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexProjectionMode : System.IEquatable<Azure.Search.Documents.Indexes.Models.IndexProjectionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexProjectionMode(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexProjectionMode IncludeIndexingParentDocuments { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.IndexProjectionMode SkipIndexingParentDocuments { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.IndexProjectionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.IndexProjectionMode left, Azure.Search.Documents.Indexes.Models.IndexProjectionMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.IndexProjectionMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.IndexProjectionMode left, Azure.Search.Documents.Indexes.Models.IndexProjectionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexStatisticsSummary
    {
        internal IndexStatisticsSummary() { }
        public long DocumentCount { get { throw null; } }
        public string Name { get { throw null; } }
        public long StorageSize { get { throw null; } }
        public long VectorIndexSize { get { throw null; } }
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
    public partial class KnowledgeStore
    {
        public KnowledgeStore(string storageConnectionString, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection> projections) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection> Projections { get { throw null; } }
        public string StorageConnectionString { get { throw null; } set { } }
    }
    public partial class KnowledgeStoreFileProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector
    {
        public KnowledgeStoreFileProjectionSelector(string storageContainer) : base (default(string)) { }
    }
    public partial class KnowledgeStoreObjectProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector
    {
        public KnowledgeStoreObjectProjectionSelector(string storageContainer) : base (default(string)) { }
    }
    public partial class KnowledgeStoreProjection
    {
        public KnowledgeStoreProjection() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector> Files { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector> Objects { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector> Tables { get { throw null; } }
    }
    public partial class KnowledgeStoreProjectionSelector
    {
        public KnowledgeStoreProjectionSelector() { }
        public string GeneratedKeyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Inputs { get { throw null; } }
        public string ReferenceKeyName { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string SourceContext { get { throw null; } set { } }
    }
    public partial class KnowledgeStoreStorageProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector
    {
        public KnowledgeStoreStorageProjectionSelector(string storageContainer) { }
        public string StorageContainer { get { throw null; } set { } }
    }
    public partial class KnowledgeStoreTableProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector
    {
        public KnowledgeStoreTableProjectionSelector(string tableName) { }
        public string TableName { get { throw null; } set { } }
    }
    public partial class LanguageDetectionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public LanguageDetectionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string DefaultCountryHint { get { throw null; } set { } }
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
    public partial class LexicalNormalizer
    {
        public LexicalNormalizer(string name) { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LexicalNormalizerName : System.IEquatable<Azure.Search.Documents.Indexes.Models.LexicalNormalizerName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LexicalNormalizerName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalNormalizerName AsciiFolding { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalNormalizerName Elision { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalNormalizerName Lowercase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalNormalizerName Standard { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.LexicalNormalizerName Uppercase { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.LexicalNormalizerName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.LexicalNormalizerName left, Azure.Search.Documents.Indexes.Models.LexicalNormalizerName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.LexicalNormalizerName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.LexicalNormalizerName left, Azure.Search.Documents.Indexes.Models.LexicalNormalizerName right) { throw null; }
        public override string ToString() { throw null; }
        public static partial class Values
        {
            public const string AsciiFolding = "asciifolding";
            public const string Elision = "elision";
            public const string Lowercase = "lowercase";
            public const string Standard = "standard";
            public const string Uppercase = "uppercase";
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
    public partial class ListIndexStatsSummary
    {
        internal ListIndexStatsSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary> IndexesStatistics { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarkdownHeaderDepth : System.IEquatable<Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarkdownHeaderDepth(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth H1 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth H2 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth H3 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth H4 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth H5 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth H6 { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth left, Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth left, Azure.Search.Documents.Indexes.Models.MarkdownHeaderDepth right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarkdownParsingSubmode : System.IEquatable<Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarkdownParsingSubmode(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode OneToMany { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode OneToOne { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode left, Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode left, Azure.Search.Documents.Indexes.Models.MarkdownParsingSubmode right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class NativeBlobSoftDeleteDeletionDetectionPolicy : Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy
    {
        public NativeBlobSoftDeleteDeletionDetectionPolicy() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OcrLineEnding : System.IEquatable<Azure.Search.Documents.Indexes.Models.OcrLineEnding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OcrLineEnding(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.OcrLineEnding CarriageReturn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrLineEnding CarriageReturnLineFeed { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrLineEnding LineFeed { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrLineEnding Space { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.OcrLineEnding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.OcrLineEnding left, Azure.Search.Documents.Indexes.Models.OcrLineEnding right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.OcrLineEnding (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.OcrLineEnding left, Azure.Search.Documents.Indexes.Models.OcrLineEnding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OcrSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public OcrSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.OcrSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.OcrLineEnding? LineEnding { get { throw null; } set { } }
        public bool? ShouldDetectOrientation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OcrSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.OcrSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OcrSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Af { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Anp { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ar { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ast { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Awa { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Az { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Be { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage BeCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage BeLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bfy { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bfz { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bg { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bgc { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bho { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bns { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Br { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bra { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Brx { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Bua { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ca { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ceb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ch { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage CnrCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage CnrLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Co { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Crh { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Csb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Cy { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Dhi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Doi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Dsb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage El { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Et { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Eu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fa { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fil { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fj { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fo { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fur { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Fy { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ga { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Gag { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Gd { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Gil { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Gl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Gon { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Gv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Gvr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Haw { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hlb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hne { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hni { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hoc { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hsb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ht { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ia { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Id { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Is { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Iu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Jns { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Jv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kaa { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage KaaCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kac { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kea { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kfq { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kha { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage KkCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage KkLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Klr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kmj { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kos { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kpy { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Krc { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ksh { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage KuArab { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage KuLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kum { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Kw { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ky { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage La { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Lb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Lkt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Lt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Mi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Mn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Mr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ms { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Mt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Mww { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Myv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Nap { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ne { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Niu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage No { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Nog { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Oc { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Os { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Pa { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Prs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ps { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Quc { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Rab { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Rm { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ro { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sa { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sat { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sck { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sco { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sm { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sma { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sme { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Smj { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Smn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sms { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage So { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sq { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage SrCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage SrLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Srx { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Sw { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Tet { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Tg { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Thf { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Tk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage To { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Tt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Tyv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ug { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Unk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Ur { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Uz { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage UzArab { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage UzCyrl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Vo { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Wae { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Xnr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Xsr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Yua { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Za { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage ZhHans { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage ZhHant { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.OcrSkillLanguage Zu { get { throw null; } }
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
    public partial class PiiDetectionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public PiiDetectionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string DefaultLanguageCode { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string Mask { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode? MaskingMode { get { throw null; } set { } }
        public double? MinPrecision { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PiiCategories { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiDetectionSkillMaskingMode : System.IEquatable<Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiDetectionSkillMaskingMode(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode None { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode Replace { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode left, Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode left, Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class RescoringOptions
    {
        public RescoringOptions() { }
        public double? DefaultOversampling { get { throw null; } set { } }
        public bool? EnableRescoring { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod? RescoreStorageMethod { get { throw null; } set { } }
    }
    public partial class ScalarQuantizationCompression : Azure.Search.Documents.Indexes.Models.VectorSearchCompression
    {
        public ScalarQuantizationCompression(string compressionName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters Parameters { get { throw null; } set { } }
    }
    public partial class ScalarQuantizationParameters
    {
        public ScalarQuantizationParameters() { }
        public Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget? QuantizedDataType { get { throw null; } set { } }
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
    public partial class SearchAlias
    {
        public SearchAlias(string name, System.Collections.Generic.IEnumerable<string> indexes) { }
        public SearchAlias(string name, string index) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<string> Indexes { get { throw null; } }
        public string Name { get { throw null; } set { } }
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
        public bool? IsStored { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalNormalizerName? NormalizerName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? SearchAnalyzerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SynonymMapNames { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchFieldDataType Type { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.VectorEncodingFormat? VectorEncodingFormat { get { throw null; } set { } }
        public int? VectorSearchDimensions { get { throw null; } set { } }
        public string VectorSearchProfileName { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchFieldDataType : System.IEquatable<Azure.Search.Documents.Indexes.Models.SearchFieldDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchFieldDataType(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Boolean { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Byte { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Complex { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType DateTimeOffset { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Double { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType GeographyPoint { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Half { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Int16 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Int32 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Int64 { get { throw null; } }
        public bool IsCollection { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType SByte { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchFieldDataType Single { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalNormalizer> Normalizers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ScoringProfile> ScoringProfiles { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SemanticSearch SemanticSearch { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm Similarity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchSuggester> Suggesters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilter> TokenFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalTokenizer> Tokenizers { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.VectorSearch VectorSearch { get { throw null; } set { } }
    }
    public partial class SearchIndexer
    {
        public SearchIndexer(string name, string dataSourceName, string targetIndexName) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerCache Cache { get { throw null; } set { } }
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
    public partial class SearchIndexerCache
    {
        public SearchIndexerCache() { }
        public bool? EnableReprocessing { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public void SetStorageConnectionString(string storageConnectionString) { }
    }
    public partial class SearchIndexerDataContainer
    {
        public SearchIndexerDataContainer(string name) { }
        public string Name { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public abstract partial class SearchIndexerDataIdentity
    {
        public SearchIndexerDataIdentity() { }
    }
    public partial class SearchIndexerDataNoneIdentity : Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity
    {
        public SearchIndexerDataNoneIdentity() { }
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
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchIndexerDataSourceType : System.IEquatable<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchIndexerDataSourceType(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType AdlsGen2 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType AzureBlob { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType AzureSql { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType AzureTable { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType CosmosDb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType MySql { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType OneLake { get { throw null; } }
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
    public partial class SearchIndexerDataUserAssignedIdentity : Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity
    {
        public SearchIndexerDataUserAssignedIdentity(Azure.Core.ResourceIdentifier userAssignedIdentity) { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
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
    public partial class SearchIndexerIndexProjection
    {
        public SearchIndexerIndexProjection(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector> selectors) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector> Selectors { get { throw null; } }
    }
    public partial class SearchIndexerIndexProjectionSelector
    {
        public SearchIndexerIndexProjectionSelector(string targetIndexName, string parentKeyFieldName, string sourceContext, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> mappings) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Mappings { get { throw null; } }
        public string ParentKeyFieldName { get { throw null; } set { } }
        public string SourceContext { get { throw null; } set { } }
        public string TargetIndexName { get { throw null; } set { } }
    }
    public partial class SearchIndexerIndexProjectionsParameters
    {
        public SearchIndexerIndexProjectionsParameters() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexProjectionMode? ProjectionMode { get { throw null; } set { } }
    }
    public partial class SearchIndexerKnowledgeStoreParameters
    {
        public SearchIndexerKnowledgeStoreParameters() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public bool? SynthesizeGeneratedKeyName { get { throw null; } set { } }
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
        public Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection IndexProjection { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.KnowledgeStore KnowledgeStore { get { throw null; } set { } }
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
        public long VectorIndexSize { get { throw null; } }
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
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public string KeyName { get { throw null; } }
        public string KeyVersion { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
    }
    public partial class SearchServiceCounters
    {
        internal SearchServiceCounters() { }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter AliasCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter DataSourceCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter DocumentCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter IndexCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter IndexerCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter SkillsetCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter StorageSizeCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter SynonymMapCounter { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceCounter VectorIndexSizeCounter { get { throw null; } }
    }
    public partial class SearchServiceLimits
    {
        internal SearchServiceLimits() { }
        public int? MaxComplexCollectionFieldsPerIndex { get { throw null; } }
        public int? MaxComplexObjectsInCollectionsPerDocument { get { throw null; } }
        public int? MaxFieldNestingDepthPerIndex { get { throw null; } }
        public int? MaxFieldsPerIndex { get { throw null; } }
        public long? MaxStoragePerIndexInBytes { get { throw null; } }
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
    public partial class SemanticConfiguration
    {
        public SemanticConfiguration(string name, Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields prioritizedFields) { }
        public bool? FlightingOptIn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields PrioritizedFields { get { throw null; } set { } }
    }
    public partial class SemanticField
    {
        public SemanticField(string fieldName) { }
        public string FieldName { get { throw null; } set { } }
    }
    public partial class SemanticPrioritizedFields
    {
        public SemanticPrioritizedFields() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SemanticField> ContentFields { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SemanticField> KeywordsFields { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SemanticField TitleField { get { throw null; } set { } }
    }
    public partial class SemanticSearch
    {
        public SemanticSearch() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SemanticConfiguration> Configurations { get { throw null; } }
        public string DefaultConfigurationName { get { throw null; } set { } }
    }
    public partial class SentimentSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SentimentSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public SentimentSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion skillVersion) { }
        public Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? IncludeOpinionMining { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct SkillVersion : System.IEquatable<Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion>
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public SkillVersion(string value) { throw null; }
            public static Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion Latest { get { throw null; } }
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion V1 { get { throw null; } }
            public static Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion V3 { get { throw null; } }
            public bool Equals(Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion other) { throw null; }
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public override bool Equals(object obj) { throw null; }
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public override int GetHashCode() { throw null; }
            public static bool operator ==(Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion right) { throw null; }
            public static bool operator >=(Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion right) { throw null; }
            public static implicit operator Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion (string value) { throw null; }
            public static bool operator !=(Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion right) { throw null; }
            public static bool operator <=(Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion left, Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion right) { throw null; }
            public override string ToString() { throw null; }
        }
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
        public Azure.Search.Documents.Indexes.Models.LexicalNormalizerName? NormalizerName { get { throw null; } set { } }
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
        public Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters AzureOpenAITokenizerParameters { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SplitSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public int? MaximumPageLength { get { throw null; } set { } }
        public int? MaximumPagesToTake { get { throw null; } set { } }
        public int? PageOverlapLength { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextSplitMode? TextSplitMode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SplitSkillUnit? Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SplitSkillEncoderModelName : System.IEquatable<Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SplitSkillEncoderModelName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName CL100KBase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName P50KBase { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName P50KEdit { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName R50KBase { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName left, Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName left, Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SplitSkillLanguage : System.IEquatable<Azure.Search.Documents.Indexes.Models.SplitSkillLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SplitSkillLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Am { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Bs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Cs { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Da { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage De { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage En { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Es { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Et { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Fi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Fr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage He { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Hi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Hr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Id { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Is { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Lv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage PtBr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Ru { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Sk { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Sl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Sr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Sv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Tr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Ur { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillLanguage Zh { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SplitSkillUnit : System.IEquatable<Azure.Search.Documents.Indexes.Models.SplitSkillUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SplitSkillUnit(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillUnit AzureOpenAITokens { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.SplitSkillUnit Characters { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.SplitSkillUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.SplitSkillUnit left, Azure.Search.Documents.Indexes.Models.SplitSkillUnit right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.SplitSkillUnit (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.SplitSkillUnit left, Azure.Search.Documents.Indexes.Models.SplitSkillUnit right) { throw null; }
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
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ga { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage He { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Hi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Hr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ht { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Hu { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Id { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Is { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage It { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ja { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Kn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ko { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Lt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Lv { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Mg { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Mi { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ml { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Ms { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Mt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Mww { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Nb { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Nl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Otq { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Pa { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Pl { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage Pt { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage PtBr { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage PtPT { get { throw null; } }
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
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage TlhLatn { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage TlhPiqd { get { throw null; } }
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
    public readonly partial struct VectorEncodingFormat : System.IEquatable<Azure.Search.Documents.Indexes.Models.VectorEncodingFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorEncodingFormat(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.VectorEncodingFormat PackedBit { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.VectorEncodingFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.VectorEncodingFormat left, Azure.Search.Documents.Indexes.Models.VectorEncodingFormat right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.VectorEncodingFormat (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.VectorEncodingFormat left, Azure.Search.Documents.Indexes.Models.VectorEncodingFormat right) { throw null; }
        public override string ToString() { throw null; }
        public static partial class Values
        {
            public const string PackedBit = "packedBit";
        }
    }
    public partial class VectorSearch
    {
        public VectorSearch() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration> Algorithms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchCompression> Compressions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchProfile> Profiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer> Vectorizers { get { throw null; } }
    }
    public abstract partial class VectorSearchAlgorithmConfiguration
    {
        protected VectorSearchAlgorithmConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorSearchAlgorithmMetric : System.IEquatable<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorSearchAlgorithmMetric(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric Cosine { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric DotProduct { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric Euclidean { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric Hamming { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric left, Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric left, Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class VectorSearchCompression
    {
        protected VectorSearchCompression(string compressionName) { }
        public string CompressionName { get { throw null; } }
        public double? DefaultOversampling { get { throw null; } set { } }
        public bool? RerankWithOriginalVectors { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.RescoringOptions RescoringOptions { get { throw null; } set { } }
        public int? TruncationDimension { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorSearchCompressionRescoreStorageMethod : System.IEquatable<Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorSearchCompressionRescoreStorageMethod(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod DiscardOriginals { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod PreserveOriginals { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod left, Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod left, Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorSearchCompressionTarget : System.IEquatable<Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorSearchCompressionTarget(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget Int8 { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget left, Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget left, Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorSearchField : Azure.Search.Documents.Indexes.Models.SearchFieldTemplate
    {
        public VectorSearchField(string name, int vectorSearchDimensions, string vectorSearchProfileName) { }
        public bool IsHidden { get { throw null; } set { } }
        public bool? IsStored { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.VectorEncodingFormat? VectorEncodingFormat { get { throw null; } set { } }
        public int VectorSearchDimensions { get { throw null; } set { } }
        public string VectorSearchProfileName { get { throw null; } set { } }
    }
    public partial class VectorSearchProfile
    {
        public VectorSearchProfile(string name, string algorithmConfigurationName) { }
        public string AlgorithmConfigurationName { get { throw null; } set { } }
        public string CompressionName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string VectorizerName { get { throw null; } set { } }
    }
    public abstract partial class VectorSearchVectorizer
    {
        protected VectorSearchVectorizer(string vectorizerName) { }
        public string VectorizerName { get { throw null; } }
    }
    public partial class VisionVectorizeSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill
    {
        public VisionVectorizeSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, string modelVersion) { }
        public string ModelVersion { get { throw null; } set { } }
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
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AuthResourceId { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public int? DegreeOfParallelism { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> HttpHeaders { get { throw null; } }
        public string HttpMethod { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public partial class WebApiVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer
    {
        public WebApiVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters Parameters { get { throw null; } set { } }
    }
    public partial class WebApiVectorizerParameters
    {
        public WebApiVectorizerParameters() { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AuthResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> HttpHeaders { get { throw null; } }
        public string HttpMethod { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
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
    public partial class DebugInfo
    {
        internal DebugInfo() { }
        public Azure.Search.Documents.Models.QueryRewritesDebugInfo QueryRewrites { get { throw null; } }
    }
    public partial class DocumentDebugInfo
    {
        internal DocumentDebugInfo() { }
        public Azure.Search.Documents.Models.SemanticDebugInfo Semantic { get { throw null; } }
        public Azure.Search.Documents.Models.VectorsDebugInfo Vectors { get { throw null; } }
    }
    public partial class FacetResult : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal FacetResult() { }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> Facets { get { throw null; } }
        public Azure.Search.Documents.Models.FacetType FacetType { get { throw null; } }
        public object From { get { throw null; } }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public double? Sum { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridCountAndFacetMode : System.IEquatable<Azure.Search.Documents.Models.HybridCountAndFacetMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridCountAndFacetMode(string value) { throw null; }
        public static Azure.Search.Documents.Models.HybridCountAndFacetMode CountAllResults { get { throw null; } }
        public static Azure.Search.Documents.Models.HybridCountAndFacetMode CountRetrievableResults { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.HybridCountAndFacetMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.HybridCountAndFacetMode left, Azure.Search.Documents.Models.HybridCountAndFacetMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.HybridCountAndFacetMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.HybridCountAndFacetMode left, Azure.Search.Documents.Models.HybridCountAndFacetMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridSearch
    {
        public HybridSearch() { }
        public Azure.Search.Documents.Models.HybridCountAndFacetMode? CountAndFacetMode { get { throw null; } set { } }
        public int? MaxTextRecallSize { get { throw null; } set { } }
    }
    public partial class IndexActionCompletedEventArgs<T> : Azure.Search.Documents.Models.IndexActionEventArgs<T>
    {
        public IndexActionCompletedEventArgs(Azure.Search.Documents.SearchIndexingBufferedSender<T> sender, Azure.Search.Documents.Models.IndexDocumentsAction<T> action, Azure.Search.Documents.Models.IndexingResult result, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(Azure.Search.Documents.SearchIndexingBufferedSender<T>), default(Azure.Search.Documents.Models.IndexDocumentsAction<T>), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Search.Documents.Models.IndexingResult Result { get { throw null; } }
    }
    public partial class IndexActionEventArgs<T> : Azure.SyncAsyncEventArgs
    {
        public IndexActionEventArgs(Azure.Search.Documents.SearchIndexingBufferedSender<T> sender, Azure.Search.Documents.Models.IndexDocumentsAction<T> action, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Search.Documents.Models.IndexDocumentsAction<T> Action { get { throw null; } }
        public Azure.Search.Documents.SearchIndexingBufferedSender<T> Sender { get { throw null; } }
    }
    public partial class IndexActionFailedEventArgs<T> : Azure.Search.Documents.Models.IndexActionEventArgs<T>
    {
        public IndexActionFailedEventArgs(Azure.Search.Documents.SearchIndexingBufferedSender<T> sender, Azure.Search.Documents.Models.IndexDocumentsAction<T> action, Azure.Search.Documents.Models.IndexingResult result, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(Azure.Search.Documents.SearchIndexingBufferedSender<T>), default(Azure.Search.Documents.Models.IndexDocumentsAction<T>), default(bool), default(System.Threading.CancellationToken)) { }
        public System.Exception Exception { get { throw null; } }
        public Azure.Search.Documents.Models.IndexingResult Result { get { throw null; } }
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
    public partial class QueryAnswer
    {
        public QueryAnswer(Azure.Search.Documents.Models.QueryAnswerType answerType) { }
        public Azure.Search.Documents.Models.QueryAnswerType AnswerType { get { throw null; } }
        public int? Count { get { throw null; } set { } }
        public int? MaxCharLength { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
    }
    public partial class QueryAnswerResult
    {
        internal QueryAnswerResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Highlights { get { throw null; } }
        public string Key { get { throw null; } }
        public double? Score { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryAnswerType : System.IEquatable<Azure.Search.Documents.Models.QueryAnswerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryAnswerType(string value) { throw null; }
        public static Azure.Search.Documents.Models.QueryAnswerType Extractive { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryAnswerType None { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.QueryAnswerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.QueryAnswerType left, Azure.Search.Documents.Models.QueryAnswerType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.QueryAnswerType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.QueryAnswerType left, Azure.Search.Documents.Models.QueryAnswerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryCaption
    {
        public QueryCaption(Azure.Search.Documents.Models.QueryCaptionType captionType) { }
        public Azure.Search.Documents.Models.QueryCaptionType CaptionType { get { throw null; } }
        public bool HighlightEnabled { get { throw null; } set { } }
        public int? MaxCharLength { get { throw null; } set { } }
    }
    public partial class QueryCaptionResult
    {
        internal QueryCaptionResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Highlights { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryCaptionType : System.IEquatable<Azure.Search.Documents.Models.QueryCaptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryCaptionType(string value) { throw null; }
        public static Azure.Search.Documents.Models.QueryCaptionType Extractive { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryCaptionType None { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.QueryCaptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.QueryCaptionType left, Azure.Search.Documents.Models.QueryCaptionType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.QueryCaptionType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.QueryCaptionType left, Azure.Search.Documents.Models.QueryCaptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryDebugMode : System.IEquatable<Azure.Search.Documents.Models.QueryDebugMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryDebugMode(string value) { throw null; }
        public static Azure.Search.Documents.Models.QueryDebugMode All { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryDebugMode Disabled { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryDebugMode QueryRewrites { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryDebugMode Semantic { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryDebugMode Vector { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.QueryDebugMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.QueryDebugMode left, Azure.Search.Documents.Models.QueryDebugMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.QueryDebugMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.QueryDebugMode left, Azure.Search.Documents.Models.QueryDebugMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryLanguage : System.IEquatable<Azure.Search.Documents.Models.QueryLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryLanguage(string value) { throw null; }
        public static Azure.Search.Documents.Models.QueryLanguage ArEg { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ArJo { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ArKw { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ArMa { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ArSa { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage BgBg { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage BnIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage CaEs { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage CsCz { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage DaDk { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage DeDe { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ElGr { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EnAu { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EnCa { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EnGb { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EnIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EnUs { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EsEs { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EsMx { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EtEe { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage EuEs { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage FaAe { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage FiFi { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage FrCa { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage FrFr { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage GaIe { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage GlEs { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage GuIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage HeIl { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage HiIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage HrBa { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage HrHr { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage HuHu { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage HyAm { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage IdId { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage IsIs { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ItIt { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage JaJp { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage KnIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage KoKr { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage LtLt { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage LvLv { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage MlIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage MrIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage MsBn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage MsMy { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage NbNo { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage NlBe { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage NlNl { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage None { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage NoNo { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage PaIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage PlPl { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage PtBr { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage PtPt { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage RoRo { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage RuRu { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage SkSk { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage SlSl { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage SrBa { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage SrMe { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage SrRs { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage SvSe { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage TaIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage TeIn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ThTh { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage TrTr { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage UkUa { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage UrPk { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ViVn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ZhCn { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryLanguage ZhTw { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.QueryLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.QueryLanguage left, Azure.Search.Documents.Models.QueryLanguage right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.QueryLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.QueryLanguage left, Azure.Search.Documents.Models.QueryLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryResultDocumentRerankerInput
    {
        internal QueryResultDocumentRerankerInput() { }
        public string Content { get { throw null; } }
        public string Keywords { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class QueryResultDocumentSemanticField
    {
        internal QueryResultDocumentSemanticField() { }
        public string Name { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticFieldState? State { get { throw null; } }
    }
    public partial class QueryResultDocumentSubscores
    {
        internal QueryResultDocumentSubscores() { }
        public double? DocumentBoost { get { throw null; } }
        public Azure.Search.Documents.Models.TextResult Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, Azure.Search.Documents.Models.SingleVectorFieldResult>> Vectors { get { throw null; } }
    }
    public partial class QueryRewrites
    {
        public QueryRewrites(Azure.Search.Documents.Models.QueryRewritesType rewritesType) { }
        public int? Count { get { throw null; } set { } }
        public Azure.Search.Documents.Models.QueryRewritesType RewritesType { get { throw null; } }
    }
    public partial class QueryRewritesDebugInfo
    {
        internal QueryRewritesDebugInfo() { }
        public Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo> Vectors { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryRewritesType : System.IEquatable<Azure.Search.Documents.Models.QueryRewritesType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryRewritesType(string value) { throw null; }
        public static Azure.Search.Documents.Models.QueryRewritesType Generative { get { throw null; } }
        public static Azure.Search.Documents.Models.QueryRewritesType None { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.QueryRewritesType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.QueryRewritesType left, Azure.Search.Documents.Models.QueryRewritesType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.QueryRewritesType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.QueryRewritesType left, Azure.Search.Documents.Models.QueryRewritesType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryRewritesValuesDebugInfo
    {
        internal QueryRewritesValuesDebugInfo() { }
        public string InputQuery { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Rewrites { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuerySpellerType : System.IEquatable<Azure.Search.Documents.Models.QuerySpellerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuerySpellerType(string value) { throw null; }
        public static Azure.Search.Documents.Models.QuerySpellerType Lexicon { get { throw null; } }
        public static Azure.Search.Documents.Models.QuerySpellerType None { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.QuerySpellerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.QuerySpellerType left, Azure.Search.Documents.Models.QuerySpellerType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.QuerySpellerType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.QuerySpellerType left, Azure.Search.Documents.Models.QuerySpellerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RangeFacetResult<T> where T : struct
    {
        public RangeFacetResult(long count, T? from, T? to) { }
        public long Count { get { throw null; } }
        public T? From { get { throw null; } }
        public T? To { get { throw null; } }
    }
    public partial class ResetDocumentOptions
    {
        public ResetDocumentOptions() { }
        public System.Collections.Generic.IList<string> DataSourceDocumentIds { get { throw null; } }
        public System.Collections.Generic.IList<string> DocumentKeys { get { throw null; } }
    }
    public partial class ResetSkillsOptions
    {
        public ResetSkillsOptions() { }
        public System.Collections.Generic.IList<string> SkillNames { get { throw null; } }
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
        public Azure.Core.GeoJson.GeoPoint GetPoint(string key) { throw null; }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPoint> GetPointCollection(string key) { throw null; }
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
        public static Azure.Search.Documents.Models.AutocompleteResults AutocompleteResults(double? coverage = default(double?), System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.AutocompleteItem> results = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.AutocompleteResults AutocompleteResults(double? coverage, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.AutocompleteItem> results) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CharFilter CharFilter(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount CognitiveServicesAccount(string oDataType, string description) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy DataChangeDetectionPolicy(string oDataType) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy DataDeletionDetectionPolicy(string oDataType) { throw null; }
        public static Azure.Search.Documents.Models.DebugInfo DebugInfo(Azure.Search.Documents.Models.QueryRewritesDebugInfo queryRewrites = null) { throw null; }
        public static Azure.Search.Documents.Models.DocumentDebugInfo DocumentDebugInfo(Azure.Search.Documents.Models.SemanticDebugInfo semantic = null, Azure.Search.Documents.Models.VectorsDebugInfo vectors = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.FacetResult FacetResult(long? count = default(long?), System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.FacetResult FacetResult(long? count = default(long?), double? sum = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> facets = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsResult IndexDocumentsResult(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.IndexingResult> results) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerChangeTrackingState IndexerChangeTrackingState(string allDocumentsInitialState, string allDocumentsFinalState, string resetDocumentsInitialState, string resetDocumentsFinalState) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionResult IndexerExecutionResult(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus status = Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus.TransientFailure, Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail? statusDetail = default(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail?), Azure.Search.Documents.Indexes.Models.IndexerState currentState = null, string errorMessage = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerError> errors = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> warnings = null, int itemCount = 0, int failedItemCount = 0, string initialTrackingState = null, string finalTrackingState = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionResult IndexerExecutionResult(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus status = Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus.TransientFailure, string errorMessage = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerError> errors = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> warnings = null, int itemCount = 0, int failedItemCount = 0, string initialTrackingState = null, string finalTrackingState = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionResult IndexerExecutionResult(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus status, string errorMessage, System.DateTimeOffset? startTime, System.DateTimeOffset? endTime, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerError> errors, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> warnings, int itemCount, int failedItemCount, string initialTrackingState, string finalTrackingState) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerState IndexerState(Azure.Search.Documents.Indexes.Models.IndexingMode? mode = default(Azure.Search.Documents.Indexes.Models.IndexingMode?), string allDocumentsInitialChangeTrackingState = null, string allDocumentsFinalChangeTrackingState = null, string resetDocumentsInitialChangeTrackingState = null, string resetDocumentsFinalChangeTrackingState = null, System.Collections.Generic.IEnumerable<string> resetDocumentKeys = null, System.Collections.Generic.IEnumerable<string> resetDataSourceDocumentIds = null) { throw null; }
        public static Azure.Search.Documents.Models.IndexingResult IndexingResult(string key, string errorMessage, bool succeeded, int status) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary IndexStatisticsSummary(string name = null, long documentCount = (long)0, long storageSize = (long)0, long vectorIndexSize = (long)0) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzer LexicalAnalyzer(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizer LexicalTokenizer(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary ListIndexStatsSummary(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary> indexesStatistics = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryAnswerResult QueryAnswerResult(double? score = default(double?), string key = null, string text = null, string highlights = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryCaptionResult QueryCaptionResult(string text = null, string highlights = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryResultDocumentRerankerInput QueryResultDocumentRerankerInput(string title = null, string content = null, string keywords = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryResultDocumentSemanticField QueryResultDocumentSemanticField(string name = null, Azure.Search.Documents.Models.SemanticFieldState? state = default(Azure.Search.Documents.Models.SemanticFieldState?)) { throw null; }
        public static Azure.Search.Documents.Models.QueryResultDocumentSubscores QueryResultDocumentSubscores(Azure.Search.Documents.Models.TextResult text = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, Azure.Search.Documents.Models.SingleVectorFieldResult>> vectors = null, double? documentBoost = default(double?)) { throw null; }
        public static Azure.Search.Documents.Models.QueryRewritesDebugInfo QueryRewritesDebugInfo(Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo text = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo> vectors = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo QueryRewritesValuesDebugInfo(string inputQuery = null, System.Collections.Generic.IEnumerable<string> rewrites = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ScoringFunction ScoringFunction(string type, string fieldName, double boost, Azure.Search.Documents.Indexes.Models.ScoringFunctionInterpolation? interpolation) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerError SearchIndexerError(string key, string errorMessage, int statusCode, string name, string details, string documentationLink) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerLimits SearchIndexerLimits(System.TimeSpan? maxRunTime, long? maxDocumentExtractionSize, long? maxDocumentContentCharactersToExtract) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerSkill SearchIndexerSkill(string oDataType, string name, string description, string context, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(Azure.Search.Documents.Indexes.Models.IndexerStatus status = Azure.Search.Documents.Indexes.Models.IndexerStatus.Unknown, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory = null, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(Azure.Search.Documents.Indexes.Models.IndexerStatus status, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerWarning SearchIndexerWarning(string key, string message, string name, string details, string documentationLink) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndexStatistics SearchIndexStatistics(long documentCount, long storageSize) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexStatistics SearchIndexStatistics(long documentCount = (long)0, long storageSize = (long)0, long vectorIndexSize = (long)0) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchResourceCounter SearchResourceCounter(long usage, long? quota) { throw null; }
        public static Azure.Search.Documents.Models.SearchResultsPage<T> SearchResultsPage<T>(Azure.Search.Documents.Models.SearchResults<T> results) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.SearchResults<T> SearchResults<T>(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchResult<T>> values, long? totalCount, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> facets, double? coverage, Azure.Response rawResponse) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.SearchResults<T> SearchResults<T>(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchResult<T>> values, long? totalCount, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> facets, double? coverage, Azure.Response rawResponse, Azure.Search.Documents.Models.SemanticSearchResults semanticSearch) { throw null; }
        public static Azure.Search.Documents.Models.SearchResults<T> SearchResults<T>(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.SearchResult<T>> values, long? totalCount, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> facets, double? coverage, Azure.Response rawResponse, Azure.Search.Documents.Models.SemanticSearchResults semanticSearch, Azure.Search.Documents.Models.DebugInfo debugInfo) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.SearchResult<T> SearchResult<T>(T document, double? score, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> highlights) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.SearchResult<T> SearchResult<T>(T document, double? score, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> highlights, Azure.Search.Documents.Models.SemanticSearchResult semanticSearch) { throw null; }
        public static Azure.Search.Documents.Models.SearchResult<T> SearchResult<T>(T document, double? score, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> highlights, Azure.Search.Documents.Models.SemanticSearchResult semanticSearch, Azure.Search.Documents.Models.DocumentDebugInfo documentDebugInfo) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchServiceCounters SearchServiceCounters(Azure.Search.Documents.Indexes.Models.SearchResourceCounter documentCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexerCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter dataSourceCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter storageSizeCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter synonymMapCounter) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchServiceCounters SearchServiceCounters(Azure.Search.Documents.Indexes.Models.SearchResourceCounter documentCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexerCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter dataSourceCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter storageSizeCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter synonymMapCounter, Azure.Search.Documents.Indexes.Models.SearchResourceCounter skillsetCounter) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchServiceCounters SearchServiceCounters(Azure.Search.Documents.Indexes.Models.SearchResourceCounter documentCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexerCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter dataSourceCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter storageSizeCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter synonymMapCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter skillsetCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter vectorIndexSizeCounter = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceCounters SearchServiceCounters(Azure.Search.Documents.Indexes.Models.SearchResourceCounter aliasCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter documentCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter indexerCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter dataSourceCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter storageSizeCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter synonymMapCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter skillsetCounter = null, Azure.Search.Documents.Indexes.Models.SearchResourceCounter vectorIndexSizeCounter = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchServiceLimits SearchServiceLimits(int? maxFieldsPerIndex, int? maxFieldNestingDepthPerIndex, int? maxComplexCollectionFieldsPerIndex, int? maxComplexObjectsInCollectionsPerDocument) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceLimits SearchServiceLimits(int? maxFieldsPerIndex = default(int?), int? maxFieldNestingDepthPerIndex = default(int?), int? maxComplexCollectionFieldsPerIndex = default(int?), int? maxComplexObjectsInCollectionsPerDocument = default(int?), long? maxStoragePerIndexInBytes = default(long?)) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceStatistics SearchServiceStatistics(Azure.Search.Documents.Indexes.Models.SearchServiceCounters counters, Azure.Search.Documents.Indexes.Models.SearchServiceLimits limits) { throw null; }
        public static Azure.Search.Documents.Models.SearchSuggestion<T> SearchSuggestion<T>(T document, string text) { throw null; }
        public static Azure.Search.Documents.Models.SemanticDebugInfo SemanticDebugInfo(Azure.Search.Documents.Models.QueryResultDocumentSemanticField titleField = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> contentFields = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> keywordFields = null, Azure.Search.Documents.Models.QueryResultDocumentRerankerInput rerankerInput = null) { throw null; }
        public static Azure.Search.Documents.Models.SemanticSearchResult SemanticSearchResult(double? rerankerScore, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryCaptionResult> captions) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.SemanticSearchResults SemanticSearchResults(System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryAnswerResult> answers, Azure.Search.Documents.Models.SemanticErrorReason? errorReason, Azure.Search.Documents.Models.SemanticSearchResultsType? resultsType) { throw null; }
        public static Azure.Search.Documents.Models.SemanticSearchResults SemanticSearchResults(System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryAnswerResult> answers, Azure.Search.Documents.Models.SemanticErrorReason? errorReason, Azure.Search.Documents.Models.SemanticSearchResultsType? resultsType, Azure.Search.Documents.Models.SemanticQueryRewritesResultType? semanticQueryRewritesResultType) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm SimilarityAlgorithm(string oDataType) { throw null; }
        public static Azure.Search.Documents.Models.SingleVectorFieldResult SingleVectorFieldResult(double? searchScore = default(double?), double? vectorSimilarity = default(double?)) { throw null; }
        public static Azure.Search.Documents.Models.SuggestResults<T> SuggestResults<T>(System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchSuggestion<T>> results, double? coverage) { throw null; }
        public static Azure.Search.Documents.Models.TextResult TextResult(double? searchScore = default(double?)) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.TokenFilter TokenFilter(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Models.VectorsDebugInfo VectorsDebugInfo(Azure.Search.Documents.Models.QueryResultDocumentSubscores subscores = null) { throw null; }
    }
    public enum SearchQueryType
    {
        Simple = 0,
        Full = 1,
        Semantic = 2,
    }
    public partial class SearchResultsPage<T> : Azure.Page<Azure.Search.Documents.Models.SearchResult<T>>
    {
        internal SearchResultsPage() { }
        public override string ContinuationToken { get { throw null; } }
        public double? Coverage { get { throw null; } }
        public Azure.Search.Documents.Models.DebugInfo DebugInfo { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> Facets { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticSearchResults SemanticSearch { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public override System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchResult<T>> Values { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
    }
    public partial class SearchResults<T>
    {
        internal SearchResults() { }
        public double? Coverage { get { throw null; } }
        public Azure.Search.Documents.Models.DebugInfo DebugInfo { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> Facets { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticSearchResults SemanticSearch { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public Azure.Pageable<Azure.Search.Documents.Models.SearchResult<T>> GetResults() { throw null; }
        public Azure.AsyncPageable<Azure.Search.Documents.Models.SearchResult<T>> GetResultsAsync() { throw null; }
    }
    public partial class SearchResult<T>
    {
        internal SearchResult() { }
        public T Document { get { throw null; } }
        public Azure.Search.Documents.Models.DocumentDebugInfo DocumentDebugInfo { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Highlights { get { throw null; } }
        public double? Score { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticSearchResult SemanticSearch { get { throw null; } }
    }
    public partial class SearchScoreThreshold : Azure.Search.Documents.Models.VectorThreshold
    {
        public SearchScoreThreshold(double value) { }
        public double Value { get { throw null; } set { } }
    }
    public partial class SearchSuggestion<T>
    {
        internal SearchSuggestion() { }
        public T Document { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class SemanticDebugInfo
    {
        internal SemanticDebugInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> ContentFields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> KeywordFields { get { throw null; } }
        public Azure.Search.Documents.Models.QueryResultDocumentRerankerInput RerankerInput { get { throw null; } }
        public Azure.Search.Documents.Models.QueryResultDocumentSemanticField TitleField { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SemanticErrorMode : System.IEquatable<Azure.Search.Documents.Models.SemanticErrorMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SemanticErrorMode(string value) { throw null; }
        public static Azure.Search.Documents.Models.SemanticErrorMode Fail { get { throw null; } }
        public static Azure.Search.Documents.Models.SemanticErrorMode Partial { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SemanticErrorMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SemanticErrorMode left, Azure.Search.Documents.Models.SemanticErrorMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SemanticErrorMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SemanticErrorMode left, Azure.Search.Documents.Models.SemanticErrorMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SemanticErrorReason : System.IEquatable<Azure.Search.Documents.Models.SemanticErrorReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SemanticErrorReason(string value) { throw null; }
        public static Azure.Search.Documents.Models.SemanticErrorReason CapacityOverloaded { get { throw null; } }
        public static Azure.Search.Documents.Models.SemanticErrorReason MaxWaitExceeded { get { throw null; } }
        public static Azure.Search.Documents.Models.SemanticErrorReason Transient { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SemanticErrorReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SemanticErrorReason left, Azure.Search.Documents.Models.SemanticErrorReason right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SemanticErrorReason (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SemanticErrorReason left, Azure.Search.Documents.Models.SemanticErrorReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SemanticFieldState : System.IEquatable<Azure.Search.Documents.Models.SemanticFieldState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SemanticFieldState(string value) { throw null; }
        public static Azure.Search.Documents.Models.SemanticFieldState Partial { get { throw null; } }
        public static Azure.Search.Documents.Models.SemanticFieldState Unused { get { throw null; } }
        public static Azure.Search.Documents.Models.SemanticFieldState Used { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SemanticFieldState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SemanticFieldState left, Azure.Search.Documents.Models.SemanticFieldState right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SemanticFieldState (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SemanticFieldState left, Azure.Search.Documents.Models.SemanticFieldState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SemanticQueryRewritesResultType : System.IEquatable<Azure.Search.Documents.Models.SemanticQueryRewritesResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SemanticQueryRewritesResultType(string value) { throw null; }
        public static Azure.Search.Documents.Models.SemanticQueryRewritesResultType OriginalQueryOnly { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SemanticQueryRewritesResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SemanticQueryRewritesResultType left, Azure.Search.Documents.Models.SemanticQueryRewritesResultType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SemanticQueryRewritesResultType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SemanticQueryRewritesResultType left, Azure.Search.Documents.Models.SemanticQueryRewritesResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SemanticSearchOptions
    {
        public SemanticSearchOptions() { }
        public Azure.Search.Documents.Models.QueryDebugMode? Debug { get { throw null; } set { } }
        public Azure.Search.Documents.Models.SemanticErrorMode? ErrorMode { get { throw null; } set { } }
        public System.TimeSpan? MaxWait { get { throw null; } set { } }
        public Azure.Search.Documents.Models.QueryAnswer QueryAnswer { get { throw null; } set { } }
        public Azure.Search.Documents.Models.QueryCaption QueryCaption { get { throw null; } set { } }
        public Azure.Search.Documents.Models.QueryRewrites QueryRewrites { get { throw null; } set { } }
        public string SemanticConfigurationName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SemanticFields { get { throw null; } }
        public string SemanticQuery { get { throw null; } set { } }
    }
    public partial class SemanticSearchResult
    {
        public SemanticSearchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryCaptionResult> Captions { get { throw null; } }
        public double? RerankerScore { get { throw null; } }
    }
    public partial class SemanticSearchResults
    {
        public SemanticSearchResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryAnswerResult> Answers { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticErrorReason? ErrorReason { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticSearchResultsType? ResultsType { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticQueryRewritesResultType? SemanticQueryRewritesResultType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SemanticSearchResultsType : System.IEquatable<Azure.Search.Documents.Models.SemanticSearchResultsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SemanticSearchResultsType(string value) { throw null; }
        public static Azure.Search.Documents.Models.SemanticSearchResultsType BaseResults { get { throw null; } }
        public static Azure.Search.Documents.Models.SemanticSearchResultsType RerankedResults { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SemanticSearchResultsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SemanticSearchResultsType left, Azure.Search.Documents.Models.SemanticSearchResultsType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SemanticSearchResultsType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SemanticSearchResultsType left, Azure.Search.Documents.Models.SemanticSearchResultsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SingleVectorFieldResult
    {
        internal SingleVectorFieldResult() { }
        public double? SearchScore { get { throw null; } }
        public double? VectorSimilarity { get { throw null; } }
    }
    public partial class SuggestResults<T>
    {
        internal SuggestResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchSuggestion<T>> Results { get { throw null; } }
    }
    public partial class TextResult
    {
        internal TextResult() { }
        public double? SearchScore { get { throw null; } }
    }
    public partial class ValueFacetResult<T>
    {
        public ValueFacetResult(long count, T value) { }
        public long Count { get { throw null; } }
        public T Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorFilterMode : System.IEquatable<Azure.Search.Documents.Models.VectorFilterMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorFilterMode(string value) { throw null; }
        public static Azure.Search.Documents.Models.VectorFilterMode PostFilter { get { throw null; } }
        public static Azure.Search.Documents.Models.VectorFilterMode PreFilter { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.VectorFilterMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.VectorFilterMode left, Azure.Search.Documents.Models.VectorFilterMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.VectorFilterMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.VectorFilterMode left, Azure.Search.Documents.Models.VectorFilterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorizableImageBinaryQuery : Azure.Search.Documents.Models.VectorQuery
    {
        public VectorizableImageBinaryQuery() { }
        public string Base64Image { get { throw null; } set { } }
    }
    public partial class VectorizableImageUrlQuery : Azure.Search.Documents.Models.VectorQuery
    {
        public VectorizableImageUrlQuery() { }
        public System.Uri Url { get { throw null; } set { } }
    }
    public partial class VectorizableTextQuery : Azure.Search.Documents.Models.VectorQuery
    {
        public VectorizableTextQuery(string text) { }
        public Azure.Search.Documents.Models.QueryRewritesType? QueryRewrites { get { throw null; } set { } }
        public string Text { get { throw null; } }
    }
    public partial class VectorizedQuery : Azure.Search.Documents.Models.VectorQuery
    {
        public VectorizedQuery(System.ReadOnlyMemory<float> vector) { }
        public System.ReadOnlyMemory<float> Vector { get { throw null; } }
    }
    public abstract partial class VectorQuery
    {
        protected VectorQuery() { }
        public bool? Exhaustive { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Fields { get { throw null; } }
        public string FilterOverride { get { throw null; } set { } }
        public int? KNearestNeighborsCount { get { throw null; } set { } }
        public double? Oversampling { get { throw null; } set { } }
        public Azure.Search.Documents.Models.VectorThreshold Threshold { get { throw null; } set { } }
        public float? Weight { get { throw null; } set { } }
    }
    public partial class VectorsDebugInfo
    {
        internal VectorsDebugInfo() { }
        public Azure.Search.Documents.Models.QueryResultDocumentSubscores Subscores { get { throw null; } }
    }
    public partial class VectorSearchOptions
    {
        public VectorSearchOptions() { }
        public Azure.Search.Documents.Models.VectorFilterMode? FilterMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.VectorQuery> Queries { get { throw null; } }
    }
    public partial class VectorSimilarityThreshold : Azure.Search.Documents.Models.VectorThreshold
    {
        public VectorSimilarityThreshold(double value) { }
        public double Value { get { throw null; } set { } }
    }
    public abstract partial class VectorThreshold
    {
        protected VectorThreshold() { }
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
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Search.Documents.Indexes.SearchIndexerClient, Azure.Search.Documents.SearchClientOptions> AddSearchIndexerClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Search.Documents.Indexes.SearchIndexerClient, Azure.Search.Documents.SearchClientOptions> AddSearchIndexerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
