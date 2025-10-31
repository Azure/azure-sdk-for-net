namespace Azure.Search.Documents
{
    public partial class AutocompleteOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.AutocompleteOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.AutocompleteOptions>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.AutocompleteOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.AutocompleteOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.AutocompleteOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.AutocompleteOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.AutocompleteOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.AutocompleteOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.AutocompleteOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetDocumentAsync<T>(string key, string querySourceAuthorization, bool? enabledElevatedRead = default(bool?), Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<long> GetDocumentCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<long>> GetDocumentCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetDocument<T>(string key, Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetDocument<T>(string key, string querySourceAuthorization, bool? enabledElevatedRead = default(bool?), Azure.Search.Documents.GetDocumentOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> IndexDocumentsAsync<T>(Azure.Search.Documents.Models.IndexDocumentsBatch<T> batch, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> IndexDocuments<T>(Azure.Search.Documents.Models.IndexDocumentsBatch<T> batch, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> MergeDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> MergeDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> MergeOrUploadDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> MergeOrUploadDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(Azure.Search.Documents.SearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(string searchText, string querySourceAuthorization, bool? enableElevatedRead, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SearchResults<T>>> SearchAsync<T>(string searchText, System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> typeInfo, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(Azure.Search.Documents.SearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(string searchText, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(string searchText, string querySourceAuthorization, bool? enableElevatedRead, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SearchResults<T>> Search<T>(string searchText, System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> typeInfo, Azure.Search.Documents.SearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>>> SuggestAsync<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.SuggestResults<T>> Suggest<T>(string searchText, string suggesterName, Azure.Search.Documents.SuggestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult>> UploadDocumentsAsync<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Models.IndexDocumentsResult> UploadDocuments<T>(System.Collections.Generic.IEnumerable<T> documents, Azure.Search.Documents.IndexDocumentsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchClientOptions : Azure.Core.ClientOptions
    {
        public SearchClientOptions(Azure.Search.Documents.SearchClientOptions.ServiceVersion version = Azure.Search.Documents.SearchClientOptions.ServiceVersion.V2025_11_01_Preview) { }
        public Azure.Search.Documents.SearchAudience? Audience { get { throw null; } set { } }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public Azure.Search.Documents.SearchClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_06_30 = 1,
            V2023_11_01 = 2,
            V2024_07_01 = 3,
            V2025_09_01 = 4,
            V2025_11_01_Preview = 5,
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
    public partial class SearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.SearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SearchOptions>
    {
        public SearchOptions() { }
        public Azure.Search.Documents.Models.QueryDebugMode? Debug { get { throw null; } set { } }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.SearchOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.SearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.SearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.SearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuggestOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.SuggestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SuggestOptions>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.SuggestOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.SuggestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.SuggestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.SuggestOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SuggestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SuggestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.SuggestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeBase> CreateKnowledgeBase(Azure.Search.Documents.Indexes.Models.KnowledgeBase KnowledgeBase, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeBase>> CreateKnowledgeBaseAsync(Azure.Search.Documents.Indexes.Models.KnowledgeBase KnowledgeBase, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSource> CreateKnowledgeSource(Azure.Search.Documents.Indexes.Models.KnowledgeSource knowledgeSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSource>> CreateKnowledgeSourceAsync(Azure.Search.Documents.Indexes.Models.KnowledgeSource knowledgeSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias> CreateOrUpdateAlias(string aliasName, Azure.Search.Documents.Indexes.Models.SearchAlias alias, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchAlias>> CreateOrUpdateAliasAsync(string aliasName, Azure.Search.Documents.Indexes.Models.SearchAlias alias, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex> CreateOrUpdateIndex(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool allowIndexDowntime = false, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.SearchIndex>> CreateOrUpdateIndexAsync(Azure.Search.Documents.Indexes.Models.SearchIndex index, bool allowIndexDowntime = false, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeBase> CreateOrUpdateKnowledgeBase(Azure.Search.Documents.Indexes.Models.KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeBase>> CreateOrUpdateKnowledgeBaseAsync(Azure.Search.Documents.Indexes.Models.KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSource> CreateOrUpdateKnowledgeSource(Azure.Search.Documents.Indexes.Models.KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSource>> CreateOrUpdateKnowledgeSourceAsync(Azure.Search.Documents.Indexes.Models.KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response DeleteKnowledgeBase(Azure.Search.Documents.Indexes.Models.KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteKnowledgeBase(string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKnowledgeBaseAsync(Azure.Search.Documents.Indexes.Models.KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKnowledgeBaseAsync(string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteKnowledgeSource(Azure.Search.Documents.Indexes.Models.KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteKnowledgeSource(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKnowledgeSourceAsync(Azure.Search.Documents.Indexes.Models.KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKnowledgeSourceAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeBase> GetKnowledgeBase(string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeBase>> GetKnowledgeBaseAsync(string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Search.Documents.Indexes.Models.KnowledgeBase> GetKnowledgeBases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Search.Documents.Indexes.Models.KnowledgeBase> GetKnowledgeBasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSource> GetKnowledgeSource(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSource>> GetKnowledgeSourceAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Search.Documents.Indexes.Models.KnowledgeSource> GetKnowledgeSources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Search.Documents.Indexes.Models.KnowledgeSource> GetKnowledgeSourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus> GetKnowledgeSourceStatus(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>> GetKnowledgeSourceStatusAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response Resync(string indexerName, Azure.Search.Documents.Models.IndexerResyncBody indexerResync, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResyncAsync(string indexerName, Azure.Search.Documents.Models.IndexerResyncBody indexerResync, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string PermissionFilter { get { throw null; } set { } }
        public bool? SensitivityLabel { get { throw null; } set { } }
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
        public static Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName CohereEmbedV4 { get { throw null; } }
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
    public partial class AIServices : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServices>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServices>
    {
        public AIServices(System.Uri uri) { }
        public string ApiKey { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServices System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServices>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServices>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServices System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServices>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServices>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServices>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIServicesAccountIdentity : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity>
    {
        public AIServicesAccountIdentity(string subdomainUrl) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public string SubdomainUrl { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIServicesAccountKey : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountKey>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountKey>
    {
        public AIServicesAccountKey(string key, string subdomainUrl) { }
        public string Key { get { throw null; } set { } }
        public string SubdomainUrl { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesAccountKey System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesAccountKey System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesAccountKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIServicesVisionParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters>
    {
        public AIServicesVisionParameters(string modelVersion, System.Uri resourceUri) { }
        public string ApiKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthIdentity { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIServicesVisionVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer>
    {
        public AIServicesVisionVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.AIServicesVisionParameters AIServicesVisionParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AIServicesVisionVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzedTokenInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>
    {
        internal AnalyzedTokenInfo() { }
        public int EndOffset { get { throw null; } }
        public int Position { get { throw null; } }
        public int StartOffset { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions>
    {
        public AnalyzeTextOptions(string text) { }
        public AnalyzeTextOptions(string text, Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName analyzerName) { }
        public AnalyzeTextOptions(string text, Azure.Search.Documents.Indexes.Models.LexicalTokenizerName tokenizerName) { }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? AnalyzerName { get { throw null; } }
        public System.Collections.Generic.IList<string> CharFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalNormalizerName? NormalizerName { get { throw null; } set { } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilterName> TokenFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalTokenizerName? TokenizerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AsciiFoldingTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter>
    {
        public AsciiFoldingTokenFilter(string name) { }
        public bool? PreserveOriginal { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AsciiFoldingTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobKnowledgeSource : Azure.Search.Documents.Indexes.Models.KnowledgeSource, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource>
    {
        public AzureBlobKnowledgeSource(string name, Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters azureBlobParameters) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters AzureBlobParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobKnowledgeSourceParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters>
    {
        public AzureBlobKnowledgeSourceParameters(string connectionString, string containerName) { }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CreatedResources { get { throw null; } }
        public string FolderPath { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters IngestionParameters { get { throw null; } set { } }
        public bool? IsAdlsGen2 { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMachineLearningParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters>
    {
        public AzureMachineLearningParameters(System.Uri scoringUri) { }
        public string AuthenticationKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.AIFoundryModelCatalogName? ModelName { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public System.Uri ScoringUri { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMachineLearningSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill>
    {
        public AzureMachineLearningSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Core.ResourceIdentifier resourceId, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { }
        public AzureMachineLearningSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, System.Uri scoringUri, string authenticationKey = null) { }
        public string AuthenticationKey { get { throw null; } }
        public int? DegreeOfParallelism { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.Uri ScoringUri { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMachineLearningVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer>
    {
        public AzureMachineLearningVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.AzureMachineLearningParameters AMLParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureMachineLearningVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureOpenAIEmbeddingSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill>
    {
        public AzureOpenAIEmbeddingSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string ApiKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthenticationIdentity { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public int? Dimensions { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName? ModelName { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIEmbeddingSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureOpenAIModelName : System.IEquatable<Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureOpenAIModelName(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt41 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt41Mini { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt41Nano { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt4O { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt4OMini { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt5 { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt5Mini { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName Gpt5Nano { get { throw null; } }
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
    public partial class AzureOpenAITokenizerParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters>
    {
        public AzureOpenAITokenizerParameters() { }
        public System.Collections.Generic.IList<string> AllowedSpecialTokens { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SplitSkillEncoderModelName? EncoderModelName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureOpenAIVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer>
    {
        public AzureOpenAIVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureOpenAIVectorizerParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters>
    {
        public AzureOpenAIVectorizerParameters() { }
        public string ApiKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthenticationIdentity { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIModelName? ModelName { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BinaryQuantizationCompression : Azure.Search.Documents.Indexes.Models.VectorSearchCompression, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression>
    {
        public BinaryQuantizationCompression(string compressionName) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BinaryQuantizationCompression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BM25Similarity : Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.BM25Similarity>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BM25Similarity>
    {
        public BM25Similarity() { }
        public double? B { get { throw null; } set { } }
        public double? K1 { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.BM25Similarity System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.BM25Similarity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.BM25Similarity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.BM25Similarity System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BM25Similarity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BM25Similarity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.BM25Similarity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CharFilter : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CharFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CharFilter>
    {
        internal CharFilter() { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CharFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CharFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CharFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CharFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CharFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CharFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CharFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatCompletionExtraParametersBehavior : System.IEquatable<Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatCompletionExtraParametersBehavior(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior Drop { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior Error { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior PassThrough { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior left, Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior left, Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatCompletionResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat>
    {
        public ChatCompletionResponseFormat() { }
        public Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties ChatCompletionSchemaProperties { get { throw null; } set { } }
        public Azure.Search.Documents.Models.ChatCompletionResponseFormatType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionSchema : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSchema>
    {
        public ChatCompletionSchema() { }
        public bool? AdditionalProperties { get { throw null; } set { } }
        public string Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Required { get { throw null; } }
        public string Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ChatCompletionSchema System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ChatCompletionSchema System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionSkill : Azure.Search.Documents.Indexes.Models.WebApiSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSkill>
    {
        public ChatCompletionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, string uri) : base (default(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>), default(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>), default(string)) { }
        public string ApiKey { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.CommonModelParameters CommonModelParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> ExtraParameters { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.ChatCompletionExtraParametersBehavior? ExtraParametersBehavior { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.ChatCompletionResponseFormat ResponseFormat { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ChatCompletionSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ChatCompletionSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ChatCompletionSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CjkBigramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter>
    {
        public CjkBigramTokenFilter(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilterScripts> IgnoreScripts { get { throw null; } }
        public bool? OutputUnigrams { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CjkBigramTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CjkBigramTokenFilterScripts
    {
        Han = 0,
        Hiragana = 1,
        Katakana = 2,
        Hangul = 3,
    }
    public partial class ClassicSimilarity : Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ClassicSimilarity>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicSimilarity>
    {
        public ClassicSimilarity() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ClassicSimilarity System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ClassicSimilarity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ClassicSimilarity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ClassicSimilarity System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicSimilarity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicSimilarity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicSimilarity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassicTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ClassicTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicTokenizer>
    {
        public ClassicTokenizer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ClassicTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ClassicTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ClassicTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ClassicTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ClassicTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesAccount : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount>
    {
        internal CognitiveServicesAccount() { }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesAccountKey : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey>
    {
        public CognitiveServicesAccountKey(string key) { }
        public string Key { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CognitiveServicesAccountKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommonGramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter>
    {
        public CommonGramTokenFilter(string name, System.Collections.Generic.IEnumerable<string> commonWords) { }
        public System.Collections.Generic.IList<string> CommonWords { get { throw null; } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? UseQueryMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonGramTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommonModelParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CommonModelParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonModelParameters>
    {
        public CommonModelParameters() { }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public int? Seed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stop { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CommonModelParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CommonModelParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CommonModelParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CommonModelParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonModelParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonModelParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CommonModelParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompletedSynchronizationState : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState>
    {
        internal CompletedSynchronizationState() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public int ItemsSkipped { get { throw null; } }
        public int ItemsUpdatesFailed { get { throw null; } }
        public int ItemsUpdatesProcessed { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComplexField : Azure.Search.Documents.Indexes.Models.SearchFieldTemplate
    {
        public ComplexField(string name, bool collection = false) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchFieldTemplate> Fields { get { throw null; } }
    }
    public partial class ConditionalSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ConditionalSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ConditionalSkill>
    {
        public ConditionalSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ConditionalSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ConditionalSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ConditionalSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ConditionalSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ConditionalSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ConditionalSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ConditionalSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentUnderstandingSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill>
    {
        public ContentUnderstandingSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties ChunkingProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions> ExtractionOptions { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentUnderstandingSkillChunkingProperties : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties>
    {
        public ContentUnderstandingSkillChunkingProperties() { }
        public int? MaximumLength { get { throw null; } set { } }
        public int? OverlapLength { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit? Unit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentUnderstandingSkillChunkingUnit : System.IEquatable<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentUnderstandingSkillChunkingUnit(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit Characters { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit left, Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit left, Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillChunkingUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentUnderstandingSkillExtractionOptions : System.IEquatable<Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentUnderstandingSkillExtractionOptions(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions Images { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions LocationMetadata { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions left, Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions left, Azure.Search.Documents.Indexes.Models.ContentUnderstandingSkillExtractionOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CorsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CorsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CorsOptions>
    {
        public CorsOptions(System.Collections.Generic.IEnumerable<string> allowedOrigins) { }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public long? MaxAgeInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CorsOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CorsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CorsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CorsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CorsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CorsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CorsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomAnalyzer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomAnalyzer>
    {
        public CustomAnalyzer(string name, Azure.Search.Documents.Indexes.Models.LexicalTokenizerName tokenizerName) { }
        public System.Collections.Generic.IList<string> CharFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilterName> TokenFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.LexicalTokenizerName TokenizerName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomAnalyzer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomAnalyzer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomAnalyzer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomAnalyzer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomAnalyzer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomAnalyzer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomAnalyzer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntity : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntity>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomEntity System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomEntity System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityAlias : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntityAlias>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityAlias>
    {
        public CustomEntityAlias(string text) { }
        public bool? AccentSensitive { get { throw null; } set { } }
        public bool? CaseSensitive { get { throw null; } set { } }
        public int? FuzzyEditDistance { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomEntityAlias System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntityAlias>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntityAlias>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomEntityAlias System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityAlias>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityAlias>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityAlias>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityLookupSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill>
    {
        public CustomEntityLookupSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public System.Uri EntitiesDefinitionUri { get { throw null; } set { } }
        public bool? GlobalDefaultAccentSensitive { get { throw null; } set { } }
        public bool? GlobalDefaultCaseSensitive { get { throw null; } set { } }
        public int? GlobalDefaultFuzzyEditDistance { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CustomEntity> InlineEntitiesDefinition { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomEntityLookupSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CustomNormalizer : Azure.Search.Documents.Indexes.Models.LexicalNormalizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomNormalizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomNormalizer>
    {
        public CustomNormalizer(string name) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CharFilterName> CharFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilterName> TokenFilters { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomNormalizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomNormalizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.CustomNormalizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.CustomNormalizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomNormalizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomNormalizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.CustomNormalizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataChangeDetectionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy>
    {
        internal DataChangeDetectionPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDeletionDetectionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy>
    {
        internal DataDeletionDetectionPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultCognitiveServicesAccount : Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount>
    {
        public DefaultCognitiveServicesAccount() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DefaultCognitiveServicesAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DictionaryDecompounderTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter>
    {
        public DictionaryDecompounderTokenFilter(string name, System.Collections.Generic.IEnumerable<string> wordList) { }
        public int? MaxSubwordSize { get { throw null; } set { } }
        public int? MinSubwordSize { get { throw null; } set { } }
        public int? MinWordSize { get { throw null; } set { } }
        public bool? OnlyLongestMatch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> WordList { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DictionaryDecompounderTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DistanceScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DistanceScoringFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringFunction>
    {
        public DistanceScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.DistanceScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.DistanceScoringParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DistanceScoringFunction System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DistanceScoringFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DistanceScoringFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DistanceScoringFunction System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DistanceScoringParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DistanceScoringParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringParameters>
    {
        public DistanceScoringParameters(string referencePointParameter, double boostingDistance) { }
        public double BoostingDistance { get { throw null; } set { } }
        public string ReferencePointParameter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DistanceScoringParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DistanceScoringParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DistanceScoringParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DistanceScoringParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DistanceScoringParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentExtractionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill>
    {
        public DocumentExtractionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public System.Collections.Generic.IDictionary<string, object> Configuration { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerDataToExtract? DataToExtract { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.BlobIndexerParsingMode? ParsingMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentExtractionSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentIntelligenceLayoutSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill>
    {
        public DocumentIntelligenceLayoutSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties ChunkingProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions> ExtractionOptions { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillMarkdownHeaderDepth? MarkdownHeaderDepth { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat? OutputFormat { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputMode? OutputMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentIntelligenceLayoutSkillChunkingProperties : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties>
    {
        public DocumentIntelligenceLayoutSkillChunkingProperties() { }
        public int? MaximumLength { get { throw null; } set { } }
        public int? OverlapLength { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit? Unit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentIntelligenceLayoutSkillChunkingUnit : System.IEquatable<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentIntelligenceLayoutSkillChunkingUnit(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit Characters { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillChunkingUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentIntelligenceLayoutSkillExtractionOptions : System.IEquatable<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentIntelligenceLayoutSkillExtractionOptions(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions Images { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions LocationMetadata { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillExtractionOptions right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct DocumentIntelligenceLayoutSkillOutputFormat : System.IEquatable<Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentIntelligenceLayoutSkillOutputFormat(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat Markdown { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat Text { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat left, Azure.Search.Documents.Indexes.Models.DocumentIntelligenceLayoutSkillOutputFormat right) { throw null; }
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
    public partial class EdgeNGramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter>
    {
        public EdgeNGramTokenFilter(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilterSide? Side { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum EdgeNGramTokenFilterSide
    {
        Front = 0,
        Back = 1,
    }
    public partial class EdgeNGramTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer>
    {
        public EdgeNGramTokenizer(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenCharacterKind> TokenChars { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EdgeNGramTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElisionTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ElisionTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ElisionTokenFilter>
    {
        public ElisionTokenFilter(string name) { }
        public System.Collections.Generic.IList<string> Articles { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ElisionTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ElisionTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ElisionTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ElisionTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ElisionTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ElisionTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ElisionTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EntityLinkingSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EntityLinkingSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityLinkingSkill>
    {
        public EntityLinkingSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string DefaultLanguageCode { get { throw null; } set { } }
        public double? MinimumPrecision { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EntityLinkingSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EntityLinkingSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EntityLinkingSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EntityLinkingSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityLinkingSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityLinkingSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityLinkingSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityRecognitionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public EntityRecognitionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public EntityRecognitionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill.SkillVersion skillVersion) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.EntityCategory> Categories { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.EntityRecognitionSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? IncludeTypelessEntities { get { throw null; } set { } }
        public double? MinimumPrecision { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.EntityRecognitionSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExhaustiveKnnAlgorithmConfiguration : Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration>
    {
        public ExhaustiveKnnAlgorithmConfiguration(string name) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnAlgorithmConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExhaustiveKnnParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters>
    {
        public ExhaustiveKnnParameters() { }
        public Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric? Metric { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ExhaustiveKnnParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FieldMapping : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FieldMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMapping>
    {
        public FieldMapping(string sourceFieldName) { }
        public Azure.Search.Documents.Indexes.Models.FieldMappingFunction MappingFunction { get { throw null; } set { } }
        public string SourceFieldName { get { throw null; } set { } }
        public string TargetFieldName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FieldMapping System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FieldMappingFunction : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FieldMappingFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMappingFunction>
    {
        public FieldMappingFunction(string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FieldMappingFunction System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FieldMappingFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FieldMappingFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FieldMappingFunction System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMappingFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMappingFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FieldMappingFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FreshnessScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction>
    {
        public FreshnessScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FreshnessScoringParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters>
    {
        public FreshnessScoringParameters(System.TimeSpan boostingDuration) { }
        public System.TimeSpan BoostingDuration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.FreshnessScoringParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HighWaterMarkChangeDetectionPolicy : Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy>
    {
        public HighWaterMarkChangeDetectionPolicy(string highWaterMarkColumnName) { }
        public string HighWaterMarkColumnName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HighWaterMarkChangeDetectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HnswAlgorithmConfiguration : Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration>
    {
        public HnswAlgorithmConfiguration(string name) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.HnswParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswAlgorithmConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HnswParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HnswParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswParameters>
    {
        public HnswParameters() { }
        public int? EfConstruction { get { throw null; } set { } }
        public int? EfSearch { get { throw null; } set { } }
        public int? M { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmMetric? Metric { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.HnswParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HnswParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.HnswParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.HnswParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.HnswParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageAnalysisSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill>
    {
        public ImageAnalysisSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.ImageAnalysisSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ImageDetail> Details { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VisualFeature> VisualFeatures { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ImageAnalysisSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class IndexedOneLakeKnowledgeSource : Azure.Search.Documents.Indexes.Models.KnowledgeSource, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource>
    {
        public IndexedOneLakeKnowledgeSource(string name, Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters indexedOneLakeParameters) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters IndexedOneLakeParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexedOneLakeKnowledgeSourceParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters>
    {
        public IndexedOneLakeKnowledgeSourceParameters(string fabricWorkspaceId, string lakehouseId) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CreatedResources { get { throw null; } }
        public string FabricWorkspaceId { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters IngestionParameters { get { throw null; } set { } }
        public string LakehouseId { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexedSharePointKnowledgeSource : Azure.Search.Documents.Indexes.Models.KnowledgeSource, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource>
    {
        public IndexedSharePointKnowledgeSource(string name, Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters indexedSharePointParameters) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters IndexedSharePointParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexedSharePointKnowledgeSourceParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters>
    {
        public IndexedSharePointKnowledgeSourceParameters(string connectionString, Azure.Search.Documents.Models.IndexedSharePointContainerName containerName) { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Search.Documents.Models.IndexedSharePointContainerName ContainerName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CreatedResources { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters IngestionParameters { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class IndexerExecutionResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult>
    {
        internal IndexerExecutionResult() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerError> Errors { get { throw null; } }
        public int FailedItemCount { get { throw null; } }
        public string FinalTrackingState { get { throw null; } }
        public string InitialTrackingState { get { throw null; } }
        public int ItemCount { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexingMode? Mode { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus Status { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail? StatusDetail { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexerExecutionResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexerExecutionResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail Resync { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexerPermissionOption : System.IEquatable<Azure.Search.Documents.Indexes.Models.IndexerPermissionOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexerPermissionOption(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerPermissionOption GroupIds { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.IndexerPermissionOption RbacScope { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.IndexerPermissionOption UserIds { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.IndexerPermissionOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.IndexerPermissionOption left, Azure.Search.Documents.Indexes.Models.IndexerPermissionOption right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.IndexerPermissionOption (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.IndexerPermissionOption left, Azure.Search.Documents.Indexes.Models.IndexerPermissionOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexerResyncOption : System.IEquatable<Azure.Search.Documents.Indexes.Models.IndexerResyncOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexerResyncOption(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerResyncOption Permissions { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.IndexerResyncOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.IndexerResyncOption left, Azure.Search.Documents.Indexes.Models.IndexerResyncOption right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.IndexerResyncOption (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.IndexerResyncOption left, Azure.Search.Documents.Indexes.Models.IndexerResyncOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexerRuntime : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerRuntime>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerRuntime>
    {
        internal IndexerRuntime() { }
        public System.DateTimeOffset BeginningTime { get { throw null; } }
        public System.DateTimeOffset EndingTime { get { throw null; } }
        public long? RemainingSeconds { get { throw null; } }
        public long UsedSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexerRuntime System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerRuntime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerRuntime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexerRuntime System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerRuntime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerRuntime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerRuntime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexerState : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerState>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerState>
    {
        internal IndexerState() { }
        public string AllDocsFinalTrackingState { get { throw null; } }
        public string AllDocsInitialTrackingState { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerChangeTrackingState ChangeTrackingState { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexingMode? Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResetDataSourceDocumentIds { get { throw null; } }
        public string ResetDocsFinalTrackingState { get { throw null; } }
        public string ResetDocsInitialTrackingState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResetDocumentKeys { get { throw null; } }
        public string ResyncFinalTrackingState { get { throw null; } }
        public string ResyncInitialTrackingState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexerState System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexerState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexerState System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexerState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Search.Documents.Indexes.Models.IndexingMode IndexingResync { get { throw null; } }
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
    public partial class IndexingParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParameters>
    {
        public IndexingParameters() { }
        public int? BatchSize { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IDictionary<string, object> Configuration { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration IndexingParametersConfiguration { get { throw null; } set { } }
        public int? MaxFailedItems { get { throw null; } set { } }
        public int? MaxFailedItemsPerBatch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexingParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexingParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexingParametersConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration>, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public bool Remove(string key) { throw null; }
        Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingParametersConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class IndexingSchedule : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingSchedule>
    {
        public IndexingSchedule(System.TimeSpan interval) { }
        public System.TimeSpan Interval { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexingSchedule System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexingSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexingSchedule System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexingSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class IndexStatisticsSummary : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary>
    {
        internal IndexStatisticsSummary() { }
        public long DocumentCount { get { throw null; } }
        public string Name { get { throw null; } }
        public long StorageSize { get { throw null; } }
        public long VectorIndexSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputFieldMappingEntry : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>
    {
        public InputFieldMappingEntry(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string SourceContext { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeepTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeepTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeepTokenFilter>
    {
        public KeepTokenFilter(string name, System.Collections.Generic.IEnumerable<string> keepWords) { }
        public System.Collections.Generic.IList<string> KeepWords { get { throw null; } }
        public bool? LowerCaseKeepWords { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeepTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeepTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeepTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeepTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeepTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeepTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeepTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseExtractionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill>
    {
        public KeyPhraseExtractionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public int? MaxKeyPhraseCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeyPhraseExtractionSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class KeywordMarkerTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter>
    {
        public KeywordMarkerTokenFilter(string name, System.Collections.Generic.IEnumerable<string> keywords) { }
        public bool? IgnoreCase { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordMarkerTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeywordTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeywordTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordTokenizer>
    {
        public KeywordTokenizer(string name) { }
        public int? BufferSize { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeywordTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeywordTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KeywordTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KeywordTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KeywordTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBase : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBase>
    {
        public KnowledgeBase(string name, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference> knowledgeSources) { }
        public string AnswerInstructions { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference> KnowledgeSources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel> Models { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode? OutputMode { get { throw null; } set { } }
        public string RetrievalInstructions { get { throw null; } set { } }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort RetrievalReasoningEffort { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeBase System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeBase System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAzureOpenAIModel : Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel>
    {
        public KnowledgeBaseAzureOpenAIModel(Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters azureOpenAIParameters) { }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters AzureOpenAIParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseAzureOpenAIModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeBaseModel : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel>
    {
        protected KnowledgeBaseModel() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeBaseModelKind : System.IEquatable<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeBaseModelKind(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind AzureOpenAI { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind left, Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind left, Azure.Search.Documents.Indexes.Models.KnowledgeBaseModelKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class KnowledgeSource : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSource>
    {
        protected KnowledgeSource(string name) { }
        public string Description { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeSourceAzureOpenAIVectorizer : Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer>
    {
        public KnowledgeSourceAzureOpenAIVectorizer() { }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAIVectorizerParameters AzureOpenAIParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceAzureOpenAIVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeSourceIngestionParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters>
    {
        public KnowledgeSourceIngestionParameters() { }
        public Azure.Search.Documents.Indexes.Models.AIServices AiServices { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel ChatCompletionModel { get { throw null; } set { } }
        public Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode? ContentExtractionMode { get { throw null; } set { } }
        public bool? DisableImageVerbalization { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer EmbeddingModel { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption> IngestionPermissionOptions { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.IndexingSchedule IngestionSchedule { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeSourceReference : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference>
    {
        public KnowledgeSourceReference(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeSourceStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics>
    {
        internal KnowledgeSourceStatistics() { }
        public int AverageItemsProcessedPerSynchronization { get { throw null; } }
        public string AverageSynchronizationDuration { get { throw null; } }
        public int TotalSynchronization { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeSourceStatus : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>
    {
        internal KnowledgeSourceStatus() { }
        public Azure.Search.Documents.Indexes.Models.SynchronizationState CurrentSynchronizationState { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState LastSynchronizationState { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics Statistics { get { throw null; } }
        public string SynchronizationInterval { get { throw null; } }
        public Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus SynchronizationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeSourceVectorizer : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer>
    {
        protected KnowledgeSourceVectorizer() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeSourceVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeStore : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStore>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStore>
    {
        public KnowledgeStore(string storageConnectionString, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection> projections) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection> Projections { get { throw null; } }
        public string StorageConnectionString { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStore System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStore System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeStoreFileProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector>
    {
        public KnowledgeStoreFileProjectionSelector(string storageContainer) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeStoreObjectProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector>
    {
        public KnowledgeStoreObjectProjectionSelector(string storageContainer) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeStoreProjection : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection>
    {
        public KnowledgeStoreProjection() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreFileProjectionSelector> Files { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreObjectProjectionSelector> Objects { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector> Tables { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeStoreProjectionSelector : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector>
    {
        public KnowledgeStoreProjectionSelector() { }
        public string GeneratedKeyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Inputs { get { throw null; } }
        public string ReferenceKeyName { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string SourceContext { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeStoreStorageProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector>
    {
        public KnowledgeStoreStorageProjectionSelector(string storageContainer) { }
        public string StorageContainer { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreStorageProjectionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeStoreTableProjectionSelector : Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector>
    {
        public KnowledgeStoreTableProjectionSelector(string tableName) { }
        public string TableName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.KnowledgeStoreTableProjectionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill>
    {
        public LanguageDetectionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string DefaultCountryHint { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LanguageDetectionSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LengthTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LengthTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LengthTokenFilter>
    {
        public LengthTokenFilter(string name) { }
        public int? MaxLength { get { throw null; } set { } }
        public int? MinLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LengthTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LengthTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LengthTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LengthTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LengthTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LengthTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LengthTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LexicalAnalyzer : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer>
    {
        internal LexicalAnalyzer() { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LexicalAnalyzer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LexicalAnalyzer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LexicalNormalizer : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalNormalizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalNormalizer>
    {
        public LexicalNormalizer(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LexicalNormalizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalNormalizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalNormalizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LexicalNormalizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalNormalizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalNormalizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalNormalizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LexicalTokenizer : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalTokenizer>
    {
        internal LexicalTokenizer() { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LexicalTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LexicalTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LexicalTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LexicalTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LimitTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LimitTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LimitTokenFilter>
    {
        public LimitTokenFilter(string name) { }
        public bool? ConsumeAllTokens { get { throw null; } set { } }
        public int? MaxTokenCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LimitTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LimitTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LimitTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LimitTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LimitTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LimitTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LimitTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListIndexStatsSummary : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>
    {
        internal ListIndexStatsSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary> IndexesStatistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LuceneStandardAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer>
    {
        public LuceneStandardAnalyzer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardAnalyzer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LuceneStandardTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer>
    {
        public LuceneStandardTokenizer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.LuceneStandardTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MagnitudeScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction>
    {
        public MagnitudeScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MagnitudeScoringParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters>
    {
        public MagnitudeScoringParameters(double boostingRangeStart, double boostingRangeEnd) { }
        public double BoostingRangeEnd { get { throw null; } set { } }
        public double BoostingRangeStart { get { throw null; } set { } }
        public bool? ShouldBoostBeyondRangeByConstant { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MagnitudeScoringParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MappingCharFilter : Azure.Search.Documents.Indexes.Models.CharFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MappingCharFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MappingCharFilter>
    {
        public MappingCharFilter(string name, System.Collections.Generic.IEnumerable<string> mappings) { }
        public System.Collections.Generic.IList<string> Mappings { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MappingCharFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MappingCharFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MappingCharFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MappingCharFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MappingCharFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MappingCharFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MappingCharFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MergeSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MergeSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MergeSkill>
    {
        public MergeSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string InsertPostTag { get { throw null; } set { } }
        public string InsertPreTag { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MergeSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MergeSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MergeSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MergeSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MergeSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MergeSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MergeSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftLanguageStemmingTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer>
    {
        public MicrosoftLanguageStemmingTokenizer(string name) { }
        public bool? IsSearchTokenizer { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.MicrosoftStemmingTokenizerLanguage? Language { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageStemmingTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftLanguageTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer>
    {
        public MicrosoftLanguageTokenizer(string name) { }
        public bool? IsSearchTokenizer { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.MicrosoftTokenizerLanguage? Language { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.MicrosoftLanguageTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NativeBlobSoftDeleteDeletionDetectionPolicy : Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy>
    {
        public NativeBlobSoftDeleteDeletionDetectionPolicy() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NativeBlobSoftDeleteDeletionDetectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NGramTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NGramTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenFilter>
    {
        public NGramTokenFilter(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.NGramTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NGramTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NGramTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.NGramTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NGramTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NGramTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenizer>
    {
        public NGramTokenizer(string name) { }
        public int? MaxGram { get { throw null; } set { } }
        public int? MinGram { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenCharacterKind> TokenChars { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.NGramTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NGramTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.NGramTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.NGramTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.NGramTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OcrSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.OcrSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OcrSkill>
    {
        public OcrSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.OcrSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.OcrLineEnding? LineEnding { get { throw null; } set { } }
        public bool? ShouldDetectOrientation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.OcrSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.OcrSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.OcrSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.OcrSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OcrSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OcrSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OcrSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OutputFieldMappingEntry : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>
    {
        public OutputFieldMappingEntry(string name) { }
        public string Name { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PathHierarchyTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer>
    {
        public PathHierarchyTokenizer(string name) { }
        public char? Delimiter { get { throw null; } set { } }
        public int? MaxTokenLength { get { throw null; } set { } }
        public int? NumberOfTokensToSkip { get { throw null; } set { } }
        public char? Replacement { get { throw null; } set { } }
        public bool? ReverseTokenOrder { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PathHierarchyTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatternAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternAnalyzer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternAnalyzer>
    {
        public PatternAnalyzer(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.RegexFlag> Flags { get { throw null; } }
        public bool? LowerCaseTerms { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternAnalyzer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternAnalyzer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternAnalyzer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternAnalyzer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternAnalyzer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternAnalyzer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternAnalyzer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatternCaptureTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter>
    {
        public PatternCaptureTokenFilter(string name, System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        public bool? PreserveOriginal { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternCaptureTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatternReplaceCharFilter : Azure.Search.Documents.Indexes.Models.CharFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter>
    {
        public PatternReplaceCharFilter(string name, string pattern, string replacement) { }
        public string Pattern { get { throw null; } set { } }
        public string Replacement { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceCharFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatternReplaceTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter>
    {
        public PatternReplaceTokenFilter(string name, string pattern, string replacement) { }
        public string Pattern { get { throw null; } set { } }
        public string Replacement { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternReplaceTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatternTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternTokenizer>
    {
        public PatternTokenizer(string name) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.RegexFlag> Flags { get { throw null; } }
        public int? Group { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PatternTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PatternTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PatternTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PermissionFilter : System.IEquatable<Azure.Search.Documents.Indexes.Models.PermissionFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PermissionFilter(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.PermissionFilter GroupIds { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.PermissionFilter RbacScope { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.PermissionFilter UserIds { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.PermissionFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.PermissionFilter left, Azure.Search.Documents.Indexes.Models.PermissionFilter right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.PermissionFilter (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.PermissionFilter left, Azure.Search.Documents.Indexes.Models.PermissionFilter right) { throw null; }
        public override string ToString() { throw null; }
        public static partial class Values
        {
            public const string GroupIds = "groupIds";
            public const string RbacScope = "rbacScope";
            public const string UserIds = "userIds";
        }
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
    public partial class PhoneticTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter>
    {
        public PhoneticTokenFilter(string name) { }
        public Azure.Search.Documents.Indexes.Models.PhoneticEncoder? Encoder { get { throw null; } set { } }
        public bool? ReplaceOriginalTokens { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PhoneticTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiDetectionSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PiiDetectionSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PiiDetectionSkill>
    {
        public PiiDetectionSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public string DefaultLanguageCode { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string Mask { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.PiiDetectionSkillMaskingMode? MaskingMode { get { throw null; } set { } }
        public double? MinPrecision { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PiiCategories { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PiiDetectionSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PiiDetectionSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.PiiDetectionSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.PiiDetectionSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PiiDetectionSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PiiDetectionSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.PiiDetectionSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct RankingOrder : System.IEquatable<Azure.Search.Documents.Indexes.Models.RankingOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RankingOrder(string value) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.RankingOrder BoostedRerankerScore { get { throw null; } }
        public static Azure.Search.Documents.Indexes.Models.RankingOrder ReRankerScore { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Indexes.Models.RankingOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Indexes.Models.RankingOrder left, Azure.Search.Documents.Indexes.Models.RankingOrder right) { throw null; }
        public static implicit operator Azure.Search.Documents.Indexes.Models.RankingOrder (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Indexes.Models.RankingOrder left, Azure.Search.Documents.Indexes.Models.RankingOrder right) { throw null; }
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
    public partial class RemoteSharePointKnowledgeSource : Azure.Search.Documents.Indexes.Models.KnowledgeSource, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource>
    {
        public RemoteSharePointKnowledgeSource(string name, Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters remoteSharePointParameters) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters RemoteSharePointParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSharePointKnowledgeSourceParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters>
    {
        public RemoteSharePointKnowledgeSourceParameters() { }
        public string ContainerTypeId { get { throw null; } set { } }
        public string FilterExpression { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceMetadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RemoteSharePointKnowledgeSourceParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RescoringOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RescoringOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RescoringOptions>
    {
        public RescoringOptions() { }
        public double? DefaultOversampling { get { throw null; } set { } }
        public bool? EnableRescoring { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.VectorSearchCompressionRescoreStorageMethod? RescoreStorageMethod { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.RescoringOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RescoringOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.RescoringOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.RescoringOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RescoringOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RescoringOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.RescoringOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalarQuantizationCompression : Azure.Search.Documents.Indexes.Models.VectorSearchCompression, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression>
    {
        public ScalarQuantizationCompression(string compressionName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationCompression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalarQuantizationParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters>
    {
        public ScalarQuantizationParameters() { }
        public Azure.Search.Documents.Indexes.Models.VectorSearchCompressionTarget? QuantizedDataType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScalarQuantizationParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScoringFunction : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScoringFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringFunction>
    {
        internal ScoringFunction() { }
        public double Boost { get { throw null; } set { } }
        public string FieldName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.ScoringFunctionInterpolation? Interpolation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScoringFunction System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScoringFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScoringFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScoringFunction System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ScoringFunctionAggregation
    {
        Sum = 0,
        Average = 1,
        Minimum = 2,
        Maximum = 3,
        FirstMatching = 4,
        Product = 5,
    }
    public enum ScoringFunctionInterpolation
    {
        Linear = 0,
        Constant = 1,
        Quadratic = 2,
        Logarithmic = 3,
    }
    public partial class ScoringProfile : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScoringProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringProfile>
    {
        public ScoringProfile(string name) { }
        public Azure.Search.Documents.Indexes.Models.ScoringFunctionAggregation? FunctionAggregation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ScoringFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextWeights TextWeights { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScoringProfile System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScoringProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ScoringProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ScoringProfile System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ScoringProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchableField : Azure.Search.Documents.Indexes.Models.SimpleField
    {
        public SearchableField(string name, bool collection = false) : base (default(string), default(Azure.Search.Documents.Indexes.Models.SearchFieldDataType)) { }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? AnalyzerName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? IndexAnalyzerName { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? SearchAnalyzerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SynonymMapNames { get { throw null; } }
    }
    public partial class SearchAlias : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchAlias>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchAlias>
    {
        public SearchAlias(string name, System.Collections.Generic.IEnumerable<string> indexes) { }
        public SearchAlias(string name, string index) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<string> Indexes { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchAlias System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchAlias>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchAlias>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchAlias System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchAlias>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchAlias>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchAlias>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchField : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchField>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchField>
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
        public Azure.Search.Documents.Indexes.Models.PermissionFilter? PermissionFilter { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? SearchAnalyzerName { get { throw null; } set { } }
        public bool? SensitivityLabel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SynonymMapNames { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchFieldDataType Type { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.VectorEncodingFormat? VectorEncodingFormat { get { throw null; } set { } }
        public int? VectorSearchDimensions { get { throw null; } set { } }
        public string VectorSearchProfileName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchField System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchField System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SearchIndex : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndex>
    {
        public SearchIndex(string name) { }
        public SearchIndex(string name, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchField> fields) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer> Analyzers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CharFilter> CharFilters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.CorsOptions CorsOptions { get { throw null; } set { } }
        public string DefaultScoringProfile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchField> Fields { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalNormalizer> Normalizers { get { throw null; } }
        public Azure.Search.Documents.Models.SearchIndexPermissionFilterOption? PermissionFilterOption { get { throw null; } set { } }
        public bool? PurviewEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ScoringProfile> ScoringProfiles { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SemanticSearch SemanticSearch { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm Similarity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchSuggester> Suggesters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilter> TokenFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalTokenizer> Tokenizers { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.VectorSearch VectorSearch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndex System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexer : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexer>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerCache : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerCache>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerCache>
    {
        public SearchIndexerCache() { }
        public bool? EnableReprocessing { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public void SetStorageConnectionString(string storageConnectionString) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerCache System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerCache>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerCache>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerCache System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerCache>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerCache>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerCache>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerDataContainer : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer>
    {
        public SearchIndexerDataContainer(string name) { }
        public string Name { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SearchIndexerDataIdentity : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity>
    {
        public SearchIndexerDataIdentity() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerDataNoneIdentity : Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity>
    {
        public SearchIndexerDataNoneIdentity() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataNoneIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerDataSourceConnection : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>
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
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.IndexerPermissionOption> IndexerPermissionOptions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string SubType { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType SharePoint { get { throw null; } }
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
    public partial class SearchIndexerDataUserAssignedIdentity : Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity>
    {
        public SearchIndexerDataUserAssignedIdentity(Azure.Core.ResourceIdentifier userAssignedIdentity) { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerDataUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerError : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerError>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerError>
    {
        internal SearchIndexerError() { }
        public string Details { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Key { get { throw null; } }
        public string Name { get { throw null; } }
        public int StatusCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerError System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerError System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerIndexProjection : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection>
    {
        public SearchIndexerIndexProjection(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector> selectors) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector> Selectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerIndexProjectionSelector : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector>
    {
        public SearchIndexerIndexProjectionSelector(string targetIndexName, string parentKeyFieldName, string sourceContext, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> mappings) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Mappings { get { throw null; } }
        public string ParentKeyFieldName { get { throw null; } set { } }
        public string SourceContext { get { throw null; } set { } }
        public string TargetIndexName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerIndexProjectionsParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters>
    {
        public SearchIndexerIndexProjectionsParameters() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexProjectionMode? ProjectionMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerIndexProjectionsParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerKnowledgeStoreParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters>
    {
        public SearchIndexerKnowledgeStoreParameters() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public bool? SynthesizeGeneratedKeyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerKnowledgeStoreParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerLimits : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerLimits>
    {
        internal SearchIndexerLimits() { }
        public long? MaxDocumentContentCharactersToExtract { get { throw null; } }
        public long? MaxDocumentExtractionSize { get { throw null; } }
        public System.TimeSpan? MaxRunTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerLimits System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerLimits System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerSkill : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill>
    {
        internal SearchIndexerSkill() { }
        public string Context { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> Outputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerSkillset : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerSkillset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerStatus : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>
    {
        internal SearchIndexerStatus() { }
        public Azure.Search.Documents.Indexes.Models.IndexerState CurrentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> ExecutionHistory { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerExecutionResult LastResult { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerLimits Limits { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerRuntime Runtime { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.IndexerStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerStatus System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerStatus System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexerWarning : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning>
    {
        internal SearchIndexerWarning() { }
        public string Details { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public string Key { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerWarning System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexerWarning System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexFieldReference : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference>
    {
        public SearchIndexFieldReference(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexKnowledgeSource : Azure.Search.Documents.Indexes.Models.KnowledgeSource, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource>
    {
        public SearchIndexKnowledgeSource(string name, Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters searchIndexParameters) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters SearchIndexParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexKnowledgeSourceParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters>
    {
        public SearchIndexKnowledgeSourceParameters(string searchIndexName) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference> SearchFields { get { throw null; } }
        public string SearchIndexName { get { throw null; } set { } }
        public string SemanticConfigurationName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference> SourceDataFields { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>
    {
        internal SearchIndexStatistics() { }
        public long DocumentCount { get { throw null; } }
        public long StorageSize { get { throw null; } }
        public long VectorIndexSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexStatistics System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchIndexStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchIndexStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchResourceCounter : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchResourceCounter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceCounter>
    {
        internal SearchResourceCounter() { }
        public long? Quota { get { throw null; } }
        public long Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchResourceCounter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchResourceCounter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchResourceCounter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchResourceCounter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceCounter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceCounter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceCounter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchResourceEncryptionKey : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey>
    {
        public SearchResourceEncryptionKey(string keyName, string keyVersion, string vaultUri) { }
        public SearchResourceEncryptionKey(System.Uri vaultUri, string keyName, string keyVersion) { }
        public string ApplicationId { get { throw null; } set { } }
        public string ApplicationSecret { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity Identity { get { throw null; } set { } }
        public string KeyName { get { throw null; } }
        public string KeyVersion { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceCounters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceCounters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceCounters>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchServiceCounters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceCounters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceCounters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchServiceCounters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceCounters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceCounters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceCounters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceLimits : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceLimits>
    {
        internal SearchServiceLimits() { }
        public int? MaxComplexCollectionFieldsPerIndex { get { throw null; } }
        public int? MaxComplexObjectsInCollectionsPerDocument { get { throw null; } }
        public long? MaxCumulativeIndexerRuntimeSeconds { get { throw null; } }
        public int? MaxFieldNestingDepthPerIndex { get { throw null; } }
        public int? MaxFieldsPerIndex { get { throw null; } }
        public long? MaxStoragePerIndexInBytes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchServiceLimits System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchServiceLimits System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>
    {
        internal SearchServiceStatistics() { }
        public Azure.Search.Documents.Indexes.Models.SearchServiceCounters Counters { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime IndexersRuntime { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SearchServiceLimits Limits { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchServiceStatistics System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchServiceStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchServiceStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchSuggester : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchSuggester>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchSuggester>
    {
        public SearchSuggester(string name, System.Collections.Generic.IEnumerable<string> sourceFields) { }
        public SearchSuggester(string name, params string[] sourceFields) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFields { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchSuggester System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchSuggester>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SearchSuggester>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SearchSuggester System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchSuggester>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchSuggester>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SearchSuggester>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticConfiguration>
    {
        public SemanticConfiguration(string name, Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields prioritizedFields) { }
        public bool? FlightingOptIn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields PrioritizedFields { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.RankingOrder? RankingOrder { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticField : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticField>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticField>
    {
        public SemanticField(string fieldName) { }
        public string FieldName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticField System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticField System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticPrioritizedFields : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields>
    {
        public SemanticPrioritizedFields() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SemanticField> ContentFields { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SemanticField> KeywordsFields { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.SemanticField TitleField { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticPrioritizedFields>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SemanticSearch : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticSearch>
    {
        public SemanticSearch() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SemanticConfiguration> Configurations { get { throw null; } }
        public string DefaultConfigurationName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticSearch System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SemanticSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SemanticSearch System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SemanticSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SentimentSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SentimentSkill>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SentimentSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public SentimentSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Search.Documents.Indexes.Models.SentimentSkill.SkillVersion skillVersion) { }
        public Azure.Search.Documents.Indexes.Models.SentimentSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public bool? IncludeOpinionMining { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SentimentSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SentimentSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SentimentSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SentimentSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SentimentSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SentimentSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SentimentSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ServiceIndexersRuntime : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime>
    {
        internal ServiceIndexersRuntime() { }
        public System.DateTimeOffset BeginningTime { get { throw null; } }
        public System.DateTimeOffset EndingTime { get { throw null; } }
        public long? RemainingSeconds { get { throw null; } }
        public long UsedSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShaperSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ShaperSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShaperSkill>
    {
        public ShaperSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ShaperSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ShaperSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ShaperSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ShaperSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShaperSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShaperSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShaperSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShingleTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ShingleTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShingleTokenFilter>
    {
        public ShingleTokenFilter(string name) { }
        public string FilterToken { get { throw null; } set { } }
        public int? MaxShingleSize { get { throw null; } set { } }
        public int? MinShingleSize { get { throw null; } set { } }
        public bool? OutputUnigrams { get { throw null; } set { } }
        public bool? OutputUnigramsIfNoShingles { get { throw null; } set { } }
        public string TokenSeparator { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ShingleTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ShingleTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.ShingleTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.ShingleTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShingleTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShingleTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.ShingleTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimilarityAlgorithm : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm>
    {
        internal SimilarityAlgorithm() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.Search.Documents.Indexes.Models.PermissionFilter? PermissionFilter { get { throw null; } set { } }
        public bool? SensitivityLabel { get { throw null; } set { } }
    }
    public partial class SnowballTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SnowballTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SnowballTokenFilter>
    {
        public SnowballTokenFilter(string name, Azure.Search.Documents.Indexes.Models.SnowballTokenFilterLanguage language) { }
        public Azure.Search.Documents.Indexes.Models.SnowballTokenFilterLanguage Language { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SnowballTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SnowballTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SnowballTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SnowballTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SnowballTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SnowballTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SnowballTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SoftDeleteColumnDeletionDetectionPolicy : Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy>
    {
        public SoftDeleteColumnDeletionDetectionPolicy() { }
        public string SoftDeleteColumnName { get { throw null; } set { } }
        public string SoftDeleteMarkerValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SoftDeleteColumnDeletionDetectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SplitSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SplitSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SplitSkill>
    {
        public SplitSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { }
        public Azure.Search.Documents.Indexes.Models.AzureOpenAITokenizerParameters AzureOpenAITokenizerParameters { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SplitSkillLanguage? DefaultLanguageCode { get { throw null; } set { } }
        public int? MaximumPageLength { get { throw null; } set { } }
        public int? MaximumPagesToTake { get { throw null; } set { } }
        public int? PageOverlapLength { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextSplitMode? TextSplitMode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.SplitSkillUnit? Unit { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SplitSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SplitSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SplitSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SplitSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SplitSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SplitSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SplitSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SqlIntegratedChangeTrackingPolicy : Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy>
    {
        public SqlIntegratedChangeTrackingPolicy() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SqlIntegratedChangeTrackingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StemmerOverrideTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter>
    {
        public StemmerOverrideTokenFilter(string name, System.Collections.Generic.IEnumerable<string> rules) { }
        public System.Collections.Generic.IList<string> Rules { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerOverrideTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StemmerTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StemmerTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerTokenFilter>
    {
        public StemmerTokenFilter(string name, Azure.Search.Documents.Indexes.Models.StemmerTokenFilterLanguage language) { }
        public Azure.Search.Documents.Indexes.Models.StemmerTokenFilterLanguage Language { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StemmerTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StemmerTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StemmerTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StemmerTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StemmerTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StopAnalyzer : Azure.Search.Documents.Indexes.Models.LexicalAnalyzer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StopAnalyzer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopAnalyzer>
    {
        public StopAnalyzer(string name) { }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StopAnalyzer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StopAnalyzer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StopAnalyzer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StopAnalyzer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopAnalyzer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopAnalyzer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopAnalyzer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StopwordsTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter>
    {
        public StopwordsTokenFilter(string name) { }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? RemoveTrailingStopWords { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stopwords { get { throw null; } }
        public Azure.Search.Documents.Indexes.Models.StopwordsList? StopwordsList { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.StopwordsTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynchronizationState : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynchronizationState>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynchronizationState>
    {
        internal SynchronizationState() { }
        public int ItemsSkipped { get { throw null; } }
        public int ItemsUpdatesFailed { get { throw null; } }
        public int ItemsUpdatesProcessed { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SynchronizationState System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynchronizationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynchronizationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SynchronizationState System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynchronizationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynchronizationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynchronizationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynonymMap : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynonymMap>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymMap>
    {
        public SynonymMap(string name, System.IO.TextReader reader) { }
        public SynonymMap(string name, string synonyms) { }
        public Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey EncryptionKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Synonyms { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SynonymMap System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynonymMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynonymMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SynonymMap System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynonymTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynonymTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymTokenFilter>
    {
        public SynonymTokenFilter(string name, System.Collections.Generic.IEnumerable<string> synonyms) { }
        public bool? Expand { get { throw null; } set { } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Synonyms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SynonymTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynonymTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.SynonymTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.SynonymTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.SynonymTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TagScoringFunction : Azure.Search.Documents.Indexes.Models.ScoringFunction, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TagScoringFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringFunction>
    {
        public TagScoringFunction(string fieldName, double boost, Azure.Search.Documents.Indexes.Models.TagScoringParameters parameters) { }
        public Azure.Search.Documents.Indexes.Models.TagScoringParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TagScoringFunction System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TagScoringFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TagScoringFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TagScoringFunction System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TagScoringParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TagScoringParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringParameters>
    {
        public TagScoringParameters(string tagsParameter) { }
        public string TagsParameter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TagScoringParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TagScoringParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TagScoringParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TagScoringParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TagScoringParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TextTranslationSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TextTranslationSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextTranslationSkill>
    {
        public TextTranslationSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage defaultToLanguageCode) { }
        public Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage? DefaultFromLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage DefaultToLanguageCode { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.TextTranslationSkillLanguage? SuggestedFrom { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TextTranslationSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TextTranslationSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TextTranslationSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TextTranslationSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextTranslationSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextTranslationSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextTranslationSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TextWeights : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TextWeights>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextWeights>
    {
        public TextWeights(System.Collections.Generic.IDictionary<string, double> weights) { }
        public System.Collections.Generic.IDictionary<string, double> Weights { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TextWeights System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TextWeights>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TextWeights>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TextWeights System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextWeights>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextWeights>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TextWeights>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TokenCharacterKind
    {
        Letter = 0,
        Digit = 1,
        Whitespace = 2,
        Punctuation = 3,
        Symbol = 4,
    }
    public partial class TokenFilter : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TokenFilter>
    {
        internal TokenFilter() { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TruncateTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TruncateTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TruncateTokenFilter>
    {
        public TruncateTokenFilter(string name) { }
        public int? Length { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TruncateTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TruncateTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.TruncateTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.TruncateTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TruncateTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TruncateTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.TruncateTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UaxUrlEmailTokenizer : Azure.Search.Documents.Indexes.Models.LexicalTokenizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer>
    {
        public UaxUrlEmailTokenizer(string name) { }
        public int? MaxTokenLength { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UaxUrlEmailTokenizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UniqueTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.UniqueTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UniqueTokenFilter>
    {
        public UniqueTokenFilter(string name) { }
        public bool? OnlyOnSamePosition { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.UniqueTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.UniqueTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.UniqueTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.UniqueTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UniqueTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UniqueTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.UniqueTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VectorSearch : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearch>
    {
        public VectorSearch() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration> Algorithms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchCompression> Compressions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchProfile> Profiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer> Vectorizers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearch System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearch System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorSearchAlgorithmConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration>
    {
        protected VectorSearchAlgorithmConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchAlgorithmConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class VectorSearchCompression : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchCompression>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchCompression>
    {
        protected VectorSearchCompression(string compressionName) { }
        public string CompressionName { get { throw null; } }
        public double? DefaultOversampling { get { throw null; } set { } }
        public bool? RerankWithOriginalVectors { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.RescoringOptions RescoringOptions { get { throw null; } set { } }
        public int? TruncationDimension { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchCompression System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchCompression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchCompression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchCompression System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchCompression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchCompression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchCompression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VectorSearchProfile : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchProfile>
    {
        public VectorSearchProfile(string name, string algorithmConfigurationName) { }
        public string AlgorithmConfigurationName { get { throw null; } set { } }
        public string CompressionName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string VectorizerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchProfile System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchProfile System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorSearchVectorizer : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer>
    {
        protected VectorSearchVectorizer(string vectorizerName) { }
        public string VectorizerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VisionVectorizeSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill>
    {
        public VisionVectorizeSkill(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs, string modelVersion) { }
        public string ModelVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.VisionVectorizeSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WebApiSkill : Azure.Search.Documents.Indexes.Models.SearchIndexerSkill, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiSkill>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebApiSkill System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebApiSkill System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebApiVectorizer : Azure.Search.Documents.Indexes.Models.VectorSearchVectorizer, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizer>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizer>
    {
        public WebApiVectorizer(string vectorizerName) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters Parameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebApiVectorizer System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebApiVectorizer System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebApiVectorizerParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters>
    {
        public WebApiVectorizerParameters() { }
        public Azure.Search.Documents.Indexes.Models.SearchIndexerDataIdentity AuthIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AuthResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> HttpHeaders { get { throw null; } }
        public string HttpMethod { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebApiVectorizerParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebKnowledgeSource : Azure.Search.Documents.Indexes.Models.KnowledgeSource, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSource>
    {
        public WebKnowledgeSource(string name) : base (default(string)) { }
        public Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters WebParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebKnowledgeSourceDomain : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain>
    {
        public WebKnowledgeSourceDomain(string address) { }
        public string Address { get { throw null; } set { } }
        public bool? IncludeSubpages { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebKnowledgeSourceDomains : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains>
    {
        public WebKnowledgeSourceDomains() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain> AllowedDomains { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomain> BlockedDomains { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebKnowledgeSourceParameters : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters>
    {
        public WebKnowledgeSourceParameters() { }
        public Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceDomains Domains { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WebKnowledgeSourceParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WordDelimiterTokenFilter : Azure.Search.Documents.Indexes.Models.TokenFilter, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Indexes.Models.WordDelimiterTokenFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.Search.Documents.KnowledgeBases
{
    public partial class KnowledgeBaseRetrievalClient
    {
        protected KnowledgeBaseRetrievalClient() { }
        public KnowledgeBaseRetrievalClient(System.Uri endpoint, string knowledgeBaseName, Azure.AzureKeyCredential credential) { }
        public KnowledgeBaseRetrievalClient(System.Uri endpoint, string knowledgeBaseName, Azure.AzureKeyCredential credential, Azure.Search.Documents.SearchClientOptions options) { }
        public KnowledgeBaseRetrievalClient(System.Uri endpoint, string knowledgeBaseName, Azure.Core.TokenCredential tokenCredential) { }
        public KnowledgeBaseRetrievalClient(System.Uri endpoint, string knowledgeBaseName, Azure.Core.TokenCredential tokenCredential, Azure.Search.Documents.SearchClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string KnowledgeBaseName { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse> Retrieve(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest retrievalRequest, string xMsQuerySourceAuthorization = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>> RetrieveAsync(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest retrievalRequest, string xMsQuerySourceAuthorization = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Search.Documents.KnowledgeBases.Models
{
    public partial class AzureBlobKnowledgeSourceParams : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams>
    {
        public AzureBlobKnowledgeSourceParams(string knowledgeSourceName) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.AzureBlobKnowledgeSourceParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexedOneLakeKnowledgeSourceParams : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams>
    {
        public IndexedOneLakeKnowledgeSourceParams(string knowledgeSourceName) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexedSharePointKnowledgeSourceParams : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams>
    {
        public IndexedSharePointKnowledgeSourceParams(string knowledgeSourceName) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeBaseActivityRecord : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord>
    {
        protected KnowledgeBaseActivityRecord(int id) { }
        public int? ElapsedMs { get { throw null; } }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail Error { get { throw null; } }
        public int Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAgenticReasoningActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord>
    {
        internal KnowledgeBaseAgenticReasoningActivityRecord() : base (default(int)) { }
        public int? ReasoningTokens { get { throw null; } }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort RetrievalReasoningEffort { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAzureBlobActivityArguments : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments>
    {
        internal KnowledgeBaseAzureBlobActivityArguments() { }
        public string Search { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAzureBlobActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord>
    {
        internal KnowledgeBaseAzureBlobActivityRecord() { }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments AzureBlobArguments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAzureBlobReference : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference>
    {
        internal KnowledgeBaseAzureBlobReference() : base (default(string), default(int)) { }
        public string BlobUrl { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseErrorAdditionalInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo>
    {
        internal KnowledgeBaseErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail>
    {
        internal KnowledgeBaseErrorDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseIndexedOneLakeActivityArguments : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments>
    {
        internal KnowledgeBaseIndexedOneLakeActivityArguments() { }
        public string Search { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseIndexedOneLakeActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord>
    {
        internal KnowledgeBaseIndexedOneLakeActivityRecord() { }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments IndexedOneLakeArguments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseIndexedOneLakeReference : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference>
    {
        internal KnowledgeBaseIndexedOneLakeReference() : base (default(string), default(int)) { }
        public string DocUrl { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseIndexedSharePointActivityArguments : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments>
    {
        internal KnowledgeBaseIndexedSharePointActivityArguments() { }
        public string Search { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseIndexedSharePointActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord>
    {
        internal KnowledgeBaseIndexedSharePointActivityRecord() { }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments IndexedSharePointArguments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseIndexedSharePointReference : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference>
    {
        internal KnowledgeBaseIndexedSharePointReference() : base (default(string), default(int)) { }
        public string DocUrl { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseMessage : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage>
    {
        public KnowledgeBaseMessage(System.Collections.Generic.IEnumerable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent> content) { }
        public System.Collections.Generic.IList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent> Content { get { throw null; } }
        public string Role { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeBaseMessageContent : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent>
    {
        protected KnowledgeBaseMessageContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeBaseMessageContentType : System.IEquatable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeBaseMessageContentType(string value) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType Image { get { throw null; } }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType Text { get { throw null; } }
        public bool Equals(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType right) { throw null; }
        public static implicit operator Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KnowledgeBaseMessageImageContent : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent>
    {
        public KnowledgeBaseMessageImageContent(Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage image) { }
        public Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage Image { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseMessageTextContent : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent>
    {
        public KnowledgeBaseMessageTextContent(string text) { }
        public string Text { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseModelAnswerSynthesisActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord>
    {
        internal KnowledgeBaseModelAnswerSynthesisActivityRecord() : base (default(int)) { }
        public int? InputTokens { get { throw null; } }
        public int? OutputTokens { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseModelQueryPlanningActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord>
    {
        internal KnowledgeBaseModelQueryPlanningActivityRecord() : base (default(int)) { }
        public int? InputTokens { get { throw null; } }
        public int? OutputTokens { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeBaseReference : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference>
    {
        protected KnowledgeBaseReference(string id, int activitySource) { }
        public int ActivitySource { get { throw null; } }
        public string Id { get { throw null; } }
        public float? RerankerScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> SourceData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseRemoteSharePointActivityArguments : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments>
    {
        internal KnowledgeBaseRemoteSharePointActivityArguments() { }
        public string FilterExpressionAddOn { get { throw null; } }
        public string Search { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseRemoteSharePointActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord>
    {
        internal KnowledgeBaseRemoteSharePointActivityRecord() { }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments RemoteSharePointArguments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseRemoteSharePointReference : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference>
    {
        internal KnowledgeBaseRemoteSharePointReference() : base (default(string), default(int)) { }
        public Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo SearchSensitivityLabelInfo { get { throw null; } }
        public System.Uri WebUrl { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseRetrievalActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord>
    {
        internal KnowledgeBaseRetrievalActivityRecord() : base (default(int)) { }
        public int? Count { get { throw null; } }
        public string KnowledgeSourceName { get { throw null; } }
        public System.DateTimeOffset? QueryTime { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseRetrievalRequest : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest>
    {
        public KnowledgeBaseRetrievalRequest() { }
        public bool? IncludeActivity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent> Intents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams> KnowledgeSourceParams { get { throw null; } }
        public int? MaxOutputSize { get { throw null; } set { } }
        public int? MaxRuntimeInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage> Messages { get { throw null; } }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode? OutputMode { get { throw null; } set { } }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort RetrievalReasoningEffort { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseRetrievalResponse : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>
    {
        internal KnowledgeBaseRetrievalResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord> Activity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference> References { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage> Response { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseSearchIndexActivityArguments : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments>
    {
        internal KnowledgeBaseSearchIndexActivityArguments() { }
        public string Filter { get { throw null; } }
        public string Search { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference> SearchFields { get { throw null; } }
        public string SemanticConfigurationName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference> SourceDataFields { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseSearchIndexActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord>
    {
        internal KnowledgeBaseSearchIndexActivityRecord() { }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments SearchIndexArguments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseSearchIndexReference : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference>
    {
        internal KnowledgeBaseSearchIndexReference() : base (default(string), default(int)) { }
        public string DocKey { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseWebActivityArguments : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments>
    {
        internal KnowledgeBaseWebActivityArguments() { }
        public int? Count { get { throw null; } }
        public string Freshness { get { throw null; } }
        public string Language { get { throw null; } }
        public string Market { get { throw null; } }
        public string Search { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseWebActivityRecord : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord>
    {
        internal KnowledgeBaseWebActivityRecord() { }
        public Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments WebArguments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseWebReference : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference>
    {
        internal KnowledgeBaseWebReference() : base (default(string), default(int)) { }
        public string Title { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeRetrievalIntent : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent>
    {
        protected KnowledgeRetrievalIntent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeRetrievalIntentType : System.IEquatable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeRetrievalIntentType(string value) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType Semantic { get { throw null; } }
        public bool Equals(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType right) { throw null; }
        public static implicit operator Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KnowledgeRetrievalLowReasoningEffort : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort>
    {
        public KnowledgeRetrievalLowReasoningEffort() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalLowReasoningEffort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeRetrievalMediumReasoningEffort : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort>
    {
        public KnowledgeRetrievalMediumReasoningEffort() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMediumReasoningEffort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeRetrievalMinimalReasoningEffort : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort>
    {
        public KnowledgeRetrievalMinimalReasoningEffort() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalMinimalReasoningEffort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeRetrievalOutputMode : System.IEquatable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeRetrievalOutputMode(string value) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode AnswerSynthesis { get { throw null; } }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode ExtractiveData { get { throw null; } }
        public bool Equals(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class KnowledgeRetrievalReasoningEffort : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort>
    {
        protected KnowledgeRetrievalReasoningEffort() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeRetrievalReasoningEffortKind : System.IEquatable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeRetrievalReasoningEffortKind(string value) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind Low { get { throw null; } }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind Medium { get { throw null; } }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind Minimal { get { throw null; } }
        public bool Equals(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind right) { throw null; }
        public static implicit operator Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind left, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffortKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KnowledgeRetrievalSemanticIntent : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalIntent, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent>
    {
        public KnowledgeRetrievalSemanticIntent(string search) { }
        public string Search { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeSourceParams : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams>
    {
        protected KnowledgeSourceParams(string knowledgeSourceName) { }
        public bool? AlwaysQuerySource { get { throw null; } set { } }
        public bool? IncludeReferences { get { throw null; } set { } }
        public bool? IncludeReferenceSourceData { get { throw null; } set { } }
        public string KnowledgeSourceName { get { throw null; } }
        public float? RerankerThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteSharePointKnowledgeSourceParams : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams>
    {
        public RemoteSharePointKnowledgeSourceParams(string knowledgeSourceName) : base (default(string)) { }
        public string FilterExpressionAddOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchIndexKnowledgeSourceParams : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams>
    {
        public SearchIndexKnowledgeSourceParams(string knowledgeSourceName) : base (default(string)) { }
        public string FilterAddOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SearchIndexKnowledgeSourceParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharePointSensitivityLabelInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo>
    {
        internal SharePointSensitivityLabelInfo() { }
        public string Color { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsEncrypted { get { throw null; } }
        public int? Priority { get { throw null; } }
        public string SensitivityLabelId { get { throw null; } }
        public string Tooltip { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebKnowledgeSourceParams : Azure.Search.Documents.KnowledgeBases.Models.KnowledgeSourceParams, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams>
    {
        public WebKnowledgeSourceParams(string knowledgeSourceName) : base (default(string)) { }
        public int? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.KnowledgeBases.Models.WebKnowledgeSourceParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.Search.Documents.Models
{
    public partial class AutocompleteItem : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.AutocompleteItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteItem>
    {
        internal AutocompleteItem() { }
        public string QueryPlusText { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.AutocompleteItem System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.AutocompleteItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.AutocompleteItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.AutocompleteItem System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AutocompleteMode
    {
        OneTerm = 0,
        TwoTerms = 1,
        OneTermWithContext = 2,
    }
    public partial class AutocompleteResults : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.AutocompleteResults>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteResults>
    {
        internal AutocompleteResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.AutocompleteItem> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.AutocompleteResults System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.AutocompleteResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.AutocompleteResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.AutocompleteResults System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.AutocompleteResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionResponseFormatJsonSchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties>
    {
        public ChatCompletionResponseFormatJsonSchemaProperties() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Search.Documents.Indexes.Models.ChatCompletionSchema Schema { get { throw null; } set { } }
        public bool? Strict { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ChatCompletionResponseFormatJsonSchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatCompletionResponseFormatType : System.IEquatable<Azure.Search.Documents.Models.ChatCompletionResponseFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatCompletionResponseFormatType(string value) { throw null; }
        public static Azure.Search.Documents.Models.ChatCompletionResponseFormatType JsonObject { get { throw null; } }
        public static Azure.Search.Documents.Models.ChatCompletionResponseFormatType JsonSchema { get { throw null; } }
        public static Azure.Search.Documents.Models.ChatCompletionResponseFormatType Text { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.ChatCompletionResponseFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.ChatCompletionResponseFormatType left, Azure.Search.Documents.Models.ChatCompletionResponseFormatType right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.ChatCompletionResponseFormatType (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.ChatCompletionResponseFormatType left, Azure.Search.Documents.Models.ChatCompletionResponseFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DebugInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.DebugInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DebugInfo>
    {
        internal DebugInfo() { }
        public Azure.Search.Documents.Models.QueryRewritesDebugInfo QueryRewrites { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.DebugInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.DebugInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.DebugInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.DebugInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DebugInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DebugInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DebugInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentDebugInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.DocumentDebugInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DocumentDebugInfo>
    {
        internal DocumentDebugInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>> InnerHits { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticDebugInfo Semantic { get { throw null; } }
        public Azure.Search.Documents.Models.VectorsDebugInfo Vectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.DocumentDebugInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.DocumentDebugInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.DocumentDebugInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.DocumentDebugInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DocumentDebugInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DocumentDebugInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.DocumentDebugInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.FacetResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.FacetResult>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal FacetResult() { }
        public double? Avg { get { throw null; } }
        public long? Cardinality { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> Facets { get { throw null; } }
        public Azure.Search.Documents.Models.FacetType FacetType { get { throw null; } }
        public object From { get { throw null; } }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public double? Max { get { throw null; } }
        public double? Min { get { throw null; } }
        public double? Sum { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public object To { get { throw null; } }
        public object Value { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public Azure.Search.Documents.Models.RangeFacetResult<T> AsRangeFacetResult<T>() where T : struct { throw null; }
        public Azure.Search.Documents.Models.ValueFacetResult<T> AsValueFacetResult<T>() { throw null; }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.FacetResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.FacetResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.FacetResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.FacetResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.FacetResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.FacetResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.FacetResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public enum FacetType
    {
        Value = 0,
        Range = 1,
        Sum = 2,
        Average = 3,
        Minimum = 4,
        Maximum = 5,
        Cardinality = 6,
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
    public partial class HybridSearch : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.HybridSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.HybridSearch>
    {
        public HybridSearch() { }
        public Azure.Search.Documents.Models.HybridCountAndFacetMode? CountAndFacetMode { get { throw null; } set { } }
        public int? MaxTextRecallSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.HybridSearch System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.HybridSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.HybridSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.HybridSearch System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.HybridSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.HybridSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.HybridSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class IndexDocumentsResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexDocumentsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexDocumentsResult>
    {
        internal IndexDocumentsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.IndexingResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.IndexDocumentsResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexDocumentsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexDocumentsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.IndexDocumentsResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexDocumentsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexDocumentsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexDocumentsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexedSharePointContainerName : System.IEquatable<Azure.Search.Documents.Models.IndexedSharePointContainerName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexedSharePointContainerName(string value) { throw null; }
        public static Azure.Search.Documents.Models.IndexedSharePointContainerName AllSiteLibraries { get { throw null; } }
        public static Azure.Search.Documents.Models.IndexedSharePointContainerName DefaultSiteLibrary { get { throw null; } }
        public static Azure.Search.Documents.Models.IndexedSharePointContainerName UseQuery { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.IndexedSharePointContainerName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.IndexedSharePointContainerName left, Azure.Search.Documents.Models.IndexedSharePointContainerName right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.IndexedSharePointContainerName (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.IndexedSharePointContainerName left, Azure.Search.Documents.Models.IndexedSharePointContainerName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexerResyncBody : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexerResyncBody>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexerResyncBody>
    {
        public IndexerResyncBody() { }
        public System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.IndexerResyncOption> Options { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.IndexerResyncBody System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexerResyncBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexerResyncBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.IndexerResyncBody System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexerResyncBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexerResyncBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexerResyncBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexingResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexingResult>
    {
        internal IndexingResult() { }
        public string ErrorMessage { get { throw null; } }
        public string Key { get { throw null; } }
        public int Status { get { throw null; } }
        public bool Succeeded { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.IndexingResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.IndexingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.IndexingResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.IndexingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseMessageImageContentImage : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage>
    {
        public KnowledgeBaseMessageImageContentImage(System.Uri url) { }
        public System.Uri Url { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.KnowledgeBaseMessageImageContentImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeSourceContentExtractionMode : System.IEquatable<Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeSourceContentExtractionMode(string value) { throw null; }
        public static Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode Minimal { get { throw null; } }
        public static Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode Standard { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode left, Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode left, Azure.Search.Documents.Models.KnowledgeSourceContentExtractionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeSourceIngestionPermissionOption : System.IEquatable<Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeSourceIngestionPermissionOption(string value) { throw null; }
        public static Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption GroupIds { get { throw null; } }
        public static Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption RbacScope { get { throw null; } }
        public static Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption UserIds { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption left, Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption left, Azure.Search.Documents.Models.KnowledgeSourceIngestionPermissionOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnowledgeSourceSynchronizationStatus : System.IEquatable<Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnowledgeSourceSynchronizationStatus(string value) { throw null; }
        public static Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus Active { get { throw null; } }
        public static Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus Creating { get { throw null; } }
        public static Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus Deleting { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus left, Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus left, Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryAnswer
    {
        public QueryAnswer(Azure.Search.Documents.Models.QueryAnswerType answerType) { }
        public Azure.Search.Documents.Models.QueryAnswerType AnswerType { get { throw null; } }
        public int? Count { get { throw null; } set { } }
        public int? MaxCharLength { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
    }
    public partial class QueryAnswerResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryAnswerResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryAnswerResult>
    {
        internal QueryAnswerResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Highlights { get { throw null; } }
        public string Key { get { throw null; } }
        public double? Score { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryAnswerResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryAnswerResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryAnswerResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryAnswerResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryAnswerResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryAnswerResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryAnswerResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class QueryCaptionResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryCaptionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryCaptionResult>
    {
        internal QueryCaptionResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Highlights { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryCaptionResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryCaptionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryCaptionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryCaptionResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryCaptionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryCaptionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryCaptionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Search.Documents.Models.QueryDebugMode InnerHits { get { throw null; } }
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
    public partial class QueryResultDocumentInnerHit : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>
    {
        internal QueryResultDocumentInnerHit() { }
        public long? Ordinal { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, Azure.Search.Documents.Models.SingleVectorFieldResult>> Vectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentInnerHit System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentInnerHit System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryResultDocumentRerankerInput : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentRerankerInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentRerankerInput>
    {
        internal QueryResultDocumentRerankerInput() { }
        public string Content { get { throw null; } }
        public string Keywords { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentRerankerInput System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentRerankerInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentRerankerInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentRerankerInput System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentRerankerInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentRerankerInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentRerankerInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryResultDocumentSemanticField : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentSemanticField>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSemanticField>
    {
        internal QueryResultDocumentSemanticField() { }
        public string Name { get { throw null; } }
        public Azure.Search.Documents.Models.SemanticFieldState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentSemanticField System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentSemanticField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentSemanticField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentSemanticField System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSemanticField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSemanticField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSemanticField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryResultDocumentSubscores : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentSubscores>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSubscores>
    {
        internal QueryResultDocumentSubscores() { }
        public double? DocumentBoost { get { throw null; } }
        public Azure.Search.Documents.Models.TextResult Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, Azure.Search.Documents.Models.SingleVectorFieldResult>> Vectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentSubscores System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentSubscores>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryResultDocumentSubscores>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryResultDocumentSubscores System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSubscores>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSubscores>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryResultDocumentSubscores>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryRewrites
    {
        public QueryRewrites(Azure.Search.Documents.Models.QueryRewritesType rewritesType) { }
        public int? Count { get { throw null; } set { } }
        public Azure.Search.Documents.Models.QueryRewritesType RewritesType { get { throw null; } }
    }
    public partial class QueryRewritesDebugInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryRewritesDebugInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesDebugInfo>
    {
        internal QueryRewritesDebugInfo() { }
        public Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo> Vectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryRewritesDebugInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryRewritesDebugInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryRewritesDebugInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryRewritesDebugInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesDebugInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesDebugInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesDebugInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class QueryRewritesValuesDebugInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo>
    {
        internal QueryRewritesValuesDebugInfo() { }
        public string InputQuery { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Rewrites { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResetDocumentOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ResetDocumentOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetDocumentOptions>
    {
        public ResetDocumentOptions() { }
        public System.Collections.Generic.IList<string> DataSourceDocumentIds { get { throw null; } }
        public System.Collections.Generic.IList<string> DocumentKeys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.ResetDocumentOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ResetDocumentOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ResetDocumentOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.ResetDocumentOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetDocumentOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetDocumentOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetDocumentOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResetSkillsOptions : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ResetSkillsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetSkillsOptions>
    {
        public ResetSkillsOptions() { }
        public System.Collections.Generic.IList<string> SkillNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.ResetSkillsOptions System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ResetSkillsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.ResetSkillsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.ResetSkillsOptions System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetSkillsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetSkillsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.ResetSkillsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchIndexPermissionFilterOption : System.IEquatable<Azure.Search.Documents.Models.SearchIndexPermissionFilterOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchIndexPermissionFilterOption(string value) { throw null; }
        public static Azure.Search.Documents.Models.SearchIndexPermissionFilterOption Disabled { get { throw null; } }
        public static Azure.Search.Documents.Models.SearchIndexPermissionFilterOption Enabled { get { throw null; } }
        public bool Equals(Azure.Search.Documents.Models.SearchIndexPermissionFilterOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Search.Documents.Models.SearchIndexPermissionFilterOption left, Azure.Search.Documents.Models.SearchIndexPermissionFilterOption right) { throw null; }
        public static implicit operator Azure.Search.Documents.Models.SearchIndexPermissionFilterOption (string value) { throw null; }
        public static bool operator !=(Azure.Search.Documents.Models.SearchIndexPermissionFilterOption left, Azure.Search.Documents.Models.SearchIndexPermissionFilterOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SearchMode
    {
        Any = 0,
        All = 1,
    }
    public static partial class SearchModelFactory
    {
        public static Azure.Search.Documents.Indexes.Models.AnalyzedTokenInfo AnalyzedTokenInfo(string token, int startOffset, int endOffset, int position) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.AnalyzeTextOptions AnalyzeTextOptions(string text = null, Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName? analyzerName = default(Azure.Search.Documents.Indexes.Models.LexicalAnalyzerName?), Azure.Search.Documents.Indexes.Models.LexicalTokenizerName? tokenizerName = default(Azure.Search.Documents.Indexes.Models.LexicalTokenizerName?), Azure.Search.Documents.Indexes.Models.LexicalNormalizerName? normalizerName = default(Azure.Search.Documents.Indexes.Models.LexicalNormalizerName?), System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.TokenFilterName> tokenFilters = null, System.Collections.Generic.IEnumerable<string> charFilters = null) { throw null; }
        public static Azure.Search.Documents.Models.AutocompleteItem AutocompleteItem(string text, string queryPlusText) { throw null; }
        public static Azure.Search.Documents.Models.AutocompleteResults AutocompleteResults(double? coverage = default(double?), System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.AutocompleteItem> results = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.AutocompleteResults AutocompleteResults(double? coverage, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.AutocompleteItem> results) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.KnowledgeSource AzureBlobKnowledgeSource(string name = null, string description = null, string kind = null, string eTag = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null, Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters azureBlobParameters = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.AzureBlobKnowledgeSourceParameters AzureBlobKnowledgeSourceParameters(string connectionString = null, string containerName = null, string folderPath = null, bool? isAdlsGen2 = default(bool?), Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters ingestionParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> createdResources = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CharFilter CharFilter(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CognitiveServicesAccount CognitiveServicesAccount(string oDataType, string description) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState CompletedSynchronizationState(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset endTime = default(System.DateTimeOffset), int itemsUpdatesProcessed = 0, int itemsUpdatesFailed = 0, int itemsSkipped = 0) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy DataChangeDetectionPolicy(string oDataType) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy DataDeletionDetectionPolicy(string oDataType) { throw null; }
        public static Azure.Search.Documents.Models.DebugInfo DebugInfo(Azure.Search.Documents.Models.QueryRewritesDebugInfo queryRewrites = null) { throw null; }
        public static Azure.Search.Documents.Models.DocumentDebugInfo DocumentDebugInfo(Azure.Search.Documents.Models.SemanticDebugInfo semantic = null, Azure.Search.Documents.Models.VectorsDebugInfo vectors = null, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.QueryResultDocumentInnerHit>> innerHits = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.DocumentDebugInfo DocumentDebugInfo(Azure.Search.Documents.Models.VectorsDebugInfo vectors) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.FacetResult FacetResult(long? count = default(long?), System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.FacetResult FacetResult(long? count = default(long?), double? avg = default(double?), double? min = default(double?), double? max = default(double?), double? sum = default(double?), long? cardinality = default(long?), System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Search.Documents.Models.FacetResult>> facets = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.IndexDocumentsResult IndexDocumentsResult(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.IndexingResult> results) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexedOneLakeKnowledgeSourceParameters IndexedOneLakeKnowledgeSourceParameters(string fabricWorkspaceId = null, string lakehouseId = null, string targetPath = null, Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters ingestionParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> createdResources = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexedSharePointKnowledgeSourceParameters IndexedSharePointKnowledgeSourceParameters(string connectionString = null, Azure.Search.Documents.Models.IndexedSharePointContainerName containerName = default(Azure.Search.Documents.Models.IndexedSharePointContainerName), string query = null, Azure.Search.Documents.Indexes.Models.KnowledgeSourceIngestionParameters ingestionParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> createdResources = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerChangeTrackingState IndexerChangeTrackingState(string allDocumentsInitialState, string allDocumentsFinalState, string resetDocumentsInitialState, string resetDocumentsFinalState) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionResult IndexerExecutionResult(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus status = Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus.TransientFailure, Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail? statusDetail = default(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatusDetail?), Azure.Search.Documents.Indexes.Models.IndexingMode? mode = default(Azure.Search.Documents.Indexes.Models.IndexingMode?), string errorMessage = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerError> errors = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> warnings = null, int itemCount = 0, int failedItemCount = 0, string initialTrackingState = null, string finalTrackingState = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionResult IndexerExecutionResult(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus status = Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus.TransientFailure, string errorMessage = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerError> errors = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> warnings = null, int itemCount = 0, int failedItemCount = 0, string initialTrackingState = null, string finalTrackingState = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.IndexerExecutionResult IndexerExecutionResult(Azure.Search.Documents.Indexes.Models.IndexerExecutionStatus status, string errorMessage, System.DateTimeOffset? startTime, System.DateTimeOffset? endTime, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerError> errors, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.SearchIndexerWarning> warnings, int itemCount, int failedItemCount, string initialTrackingState, string finalTrackingState) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerRuntime IndexerRuntime(long usedSeconds = (long)0, long? remainingSeconds = default(long?), System.DateTimeOffset beginningTime = default(System.DateTimeOffset), System.DateTimeOffset endingTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerState IndexerState(Azure.Search.Documents.Indexes.Models.IndexingMode? mode = default(Azure.Search.Documents.Indexes.Models.IndexingMode?), string allDocumentsInitialChangeTrackingState = null, string allDocumentsFinalChangeTrackingState = null, string resetDocumentsInitialChangeTrackingState = null, string resetDocumentsFinalChangeTrackingState = null, System.Collections.Generic.IEnumerable<string> resetDocumentKeys = null, System.Collections.Generic.IEnumerable<string> resetDataSourceDocumentIds = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexerState IndexerState(Azure.Search.Documents.Indexes.Models.IndexingMode? mode = default(Azure.Search.Documents.Indexes.Models.IndexingMode?), string allDocsInitialTrackingState = null, string allDocsFinalTrackingState = null, string resetDocsInitialTrackingState = null, string resetDocsFinalTrackingState = null, System.Collections.Generic.IEnumerable<string> resetDocumentKeys = null, System.Collections.Generic.IEnumerable<string> resetDataSourceDocumentIds = null, string resyncInitialTrackingState = null, string resyncFinalTrackingState = null) { throw null; }
        public static Azure.Search.Documents.Models.IndexingResult IndexingResult(string key, string errorMessage, bool succeeded, int status) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary IndexStatisticsSummary(string name = null, long documentCount = (long)0, long storageSize = (long)0, long vectorIndexSize = (long)0) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.KnowledgeBase KnowledgeBase(string name = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.KnowledgeSourceReference> knowledgeSources = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.KnowledgeBaseModel> models = null, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = null, Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode? outputMode = default(Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalOutputMode?), string eTag = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, string description = null, string retrievalInstructions = null, string answerInstructions = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord KnowledgeBaseActivityRecord(int id = 0, string type = null, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord KnowledgeBaseAgenticReasoningActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, int? reasoningTokens = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments KnowledgeBaseAzureBlobActivityArguments(string search = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord KnowledgeBaseAzureBlobActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, string knowledgeSourceName = null, System.DateTimeOffset? queryTime = default(System.DateTimeOffset?), int? count = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityArguments azureBlobArguments = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseAzureBlobReference KnowledgeBaseAzureBlobReference(string id = null, int activitySource = 0, System.Collections.Generic.IReadOnlyDictionary<string, object> sourceData = null, float? rerankerScore = default(float?), string blobUrl = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo KnowledgeBaseErrorAdditionalInfo(string type = null, object info = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail KnowledgeBaseErrorDetail(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail> details = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments KnowledgeBaseIndexedOneLakeActivityArguments(string search = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord KnowledgeBaseIndexedOneLakeActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, string knowledgeSourceName = null, System.DateTimeOffset? queryTime = default(System.DateTimeOffset?), int? count = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityArguments indexedOneLakeArguments = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference KnowledgeBaseIndexedOneLakeReference(string id = null, int activitySource = 0, System.Collections.Generic.IReadOnlyDictionary<string, object> sourceData = null, float? rerankerScore = default(float?), string docUrl = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments KnowledgeBaseIndexedSharePointActivityArguments(string search = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord KnowledgeBaseIndexedSharePointActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, string knowledgeSourceName = null, System.DateTimeOffset? queryTime = default(System.DateTimeOffset?), int? count = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityArguments indexedSharePointArguments = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference KnowledgeBaseIndexedSharePointReference(string id = null, int activitySource = 0, System.Collections.Generic.IReadOnlyDictionary<string, object> sourceData = null, float? rerankerScore = default(float?), string docUrl = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelAnswerSynthesisActivityRecord KnowledgeBaseModelAnswerSynthesisActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, int? inputTokens = default(int?), int? outputTokens = default(int?)) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseModelQueryPlanningActivityRecord KnowledgeBaseModelQueryPlanningActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, int? inputTokens = default(int?), int? outputTokens = default(int?)) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference KnowledgeBaseReference(string type = null, string id = null, int activitySource = 0, System.Collections.Generic.IReadOnlyDictionary<string, object> sourceData = null, float? rerankerScore = default(float?)) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments KnowledgeBaseRemoteSharePointActivityArguments(string search = null, string filterExpressionAddOn = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityRecord KnowledgeBaseRemoteSharePointActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, string knowledgeSourceName = null, System.DateTimeOffset? queryTime = default(System.DateTimeOffset?), int? count = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointActivityArguments remoteSharePointArguments = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRemoteSharePointReference KnowledgeBaseRemoteSharePointReference(string id = null, int activitySource = 0, System.Collections.Generic.IReadOnlyDictionary<string, object> sourceData = null, float? rerankerScore = default(float?), System.Uri webUrl = null, Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo searchSensitivityLabelInfo = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalActivityRecord KnowledgeBaseRetrievalActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, string knowledgeSourceName = null, System.DateTimeOffset? queryTime = default(System.DateTimeOffset?), int? count = default(int?)) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseRetrievalResponse KnowledgeBaseRetrievalResponse(System.Collections.Generic.IEnumerable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseMessage> response = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseActivityRecord> activity = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseReference> references = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments KnowledgeBaseSearchIndexActivityArguments(string search = null, string filter = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference> sourceDataFields = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.SearchIndexFieldReference> searchFields = null, string semanticConfigurationName = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord KnowledgeBaseSearchIndexActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, string knowledgeSourceName = null, System.DateTimeOffset? queryTime = default(System.DateTimeOffset?), int? count = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments searchIndexArguments = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseSearchIndexReference KnowledgeBaseSearchIndexReference(string id = null, int activitySource = 0, System.Collections.Generic.IReadOnlyDictionary<string, object> sourceData = null, float? rerankerScore = default(float?), string docKey = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments KnowledgeBaseWebActivityArguments(string search = null, string language = null, string market = null, int? count = default(int?), string freshness = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityRecord KnowledgeBaseWebActivityRecord(int id = 0, int? elapsedMs = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseErrorDetail error = null, string knowledgeSourceName = null, System.DateTimeOffset? queryTime = default(System.DateTimeOffset?), int? count = default(int?), Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebActivityArguments webArguments = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeBaseWebReference KnowledgeBaseWebReference(string id = null, int activitySource = 0, System.Collections.Generic.IReadOnlyDictionary<string, object> sourceData = null, float? rerankerScore = default(float?), System.Uri url = null, string title = null) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.KnowledgeRetrievalSemanticIntent KnowledgeRetrievalSemanticIntent(string search = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics KnowledgeSourceStatistics(int totalSynchronization = 0, string averageSynchronizationDuration = null, int averageItemsProcessedPerSynchronization = 0) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatus KnowledgeSourceStatus(Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus synchronizationStatus = default(Azure.Search.Documents.Models.KnowledgeSourceSynchronizationStatus), string synchronizationInterval = null, Azure.Search.Documents.Indexes.Models.SynchronizationState currentSynchronizationState = null, Azure.Search.Documents.Indexes.Models.CompletedSynchronizationState lastSynchronizationState = null, Azure.Search.Documents.Indexes.Models.KnowledgeSourceStatistics statistics = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalAnalyzer LexicalAnalyzer(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.LexicalTokenizer LexicalTokenizer(string oDataType, string name) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ListIndexStatsSummary ListIndexStatsSummary(System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.IndexStatisticsSummary> indexesStatistics = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryAnswerResult QueryAnswerResult(double? score = default(double?), string key = null, string text = null, string highlights = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryCaptionResult QueryCaptionResult(string text = null, string highlights = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryResultDocumentInnerHit QueryResultDocumentInnerHit(long? ordinal = default(long?), System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, Azure.Search.Documents.Models.SingleVectorFieldResult>> vectors = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryResultDocumentRerankerInput QueryResultDocumentRerankerInput(string title = null, string content = null, string keywords = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryResultDocumentSemanticField QueryResultDocumentSemanticField(string name = null, Azure.Search.Documents.Models.SemanticFieldState? state = default(Azure.Search.Documents.Models.SemanticFieldState?)) { throw null; }
        public static Azure.Search.Documents.Models.QueryResultDocumentSubscores QueryResultDocumentSubscores(Azure.Search.Documents.Models.TextResult text = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, Azure.Search.Documents.Models.SingleVectorFieldResult>> vectors = null, double? documentBoost = default(double?)) { throw null; }
        public static Azure.Search.Documents.Models.QueryRewritesDebugInfo QueryRewritesDebugInfo(Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo text = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo> vectors = null) { throw null; }
        public static Azure.Search.Documents.Models.QueryRewritesValuesDebugInfo QueryRewritesValuesDebugInfo(string inputQuery = null, System.Collections.Generic.IEnumerable<string> rewrites = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ScoringFunction ScoringFunction(string type, string fieldName, double boost, Azure.Search.Documents.Indexes.Models.ScoringFunctionInterpolation? interpolation) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchAlias SearchAlias(string name = null, System.Collections.Generic.IList<string> indexes = null, string etag = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndex SearchIndex(string name = null, string description = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchField> fields = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ScoringProfile> scoringProfiles = null, string defaultScoringProfile = null, Azure.Search.Documents.Indexes.Models.CorsOptions corsOptions = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchSuggester> suggesters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer> analyzers = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalTokenizer> tokenizers = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilter> tokenFilters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CharFilter> charFilters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalNormalizer> normalizers = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm similarity = null, Azure.Search.Documents.Indexes.Models.SemanticSearch semanticSearch = null, Azure.Search.Documents.Indexes.Models.VectorSearch vectorSearch = null, Azure.Search.Documents.Models.SearchIndexPermissionFilterOption permissionFilterOption = default(Azure.Search.Documents.Models.SearchIndexPermissionFilterOption), string etag = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndex SearchIndex(string name = null, string description = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchField> fields = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.ScoringProfile> scoringProfiles = null, string defaultScoringProfile = null, Azure.Search.Documents.Indexes.Models.CorsOptions corsOptions = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.SearchSuggester> suggesters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalAnalyzer> analyzers = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalTokenizer> tokenizers = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.TokenFilter> tokenFilters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.CharFilter> charFilters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.LexicalNormalizer> normalizers = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm similarity = null, Azure.Search.Documents.Indexes.Models.SemanticSearch semanticSearch = null, Azure.Search.Documents.Indexes.Models.VectorSearch vectorSearch = null, string etag = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexer SearchIndexer(string name = null, string description = null, string dataSourceName = null, string skillsetName = null, string targetIndexName = null, Azure.Search.Documents.Indexes.Models.IndexingSchedule schedule = null, Azure.Search.Documents.Indexes.Models.IndexingParameters parameters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.FieldMapping> fieldMappings = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.FieldMapping> outputFieldMappings = null, bool? isDisabled = default(bool?), string etag = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, Azure.Search.Documents.Indexes.Models.SearchIndexerCache cache = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndexer SearchIndexer(string name = null, string description = null, string dataSourceName = null, string skillsetName = null, string targetIndexName = null, Azure.Search.Documents.Indexes.Models.IndexingSchedule schedule = null, Azure.Search.Documents.Indexes.Models.IndexingParameters parameters = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.FieldMapping> fieldMappings = null, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.FieldMapping> outputFieldMappings = null, bool? isDisabled = default(bool?), string etag = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceConnection SearchIndexerDataSourceConnection(string name = null, string description = null, Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType type = default(Azure.Search.Documents.Indexes.Models.SearchIndexerDataSourceType), string connectionString = null, Azure.Search.Documents.Indexes.Models.SearchIndexerDataContainer container = null, Azure.Search.Documents.Indexes.Models.DataChangeDetectionPolicy dataChangeDetectionPolicy = null, Azure.Search.Documents.Indexes.Models.DataDeletionDetectionPolicy dataDeletionDetectionPolicy = null, string etag = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerError SearchIndexerError(string key, string errorMessage, int statusCode, string name, string details, string documentationLink) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerLimits SearchIndexerLimits(System.TimeSpan? maxRunTime, long? maxDocumentExtractionSize, long? maxDocumentContentCharactersToExtract) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerSkill SearchIndexerSkill(string oDataType, string name, string description, string context, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.InputFieldMappingEntry> inputs, System.Collections.Generic.IList<Azure.Search.Documents.Indexes.Models.OutputFieldMappingEntry> outputs) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(Azure.Search.Documents.Indexes.Models.IndexerStatus status = Azure.Search.Documents.Indexes.Models.IndexerStatus.Unknown, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory = null, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(Azure.Search.Documents.Indexes.Models.IndexerStatus status, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(string name = null, Azure.Search.Documents.Indexes.Models.IndexerStatus status = Azure.Search.Documents.Indexes.Models.IndexerStatus.Unknown, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory = null, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(string name = null, Azure.Search.Documents.Indexes.Models.IndexerStatus status = Azure.Search.Documents.Indexes.Models.IndexerStatus.Unknown, Azure.Search.Documents.Indexes.Models.IndexerRuntime runtime = null, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory = null, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerStatus SearchIndexerStatus(string name = null, Azure.Search.Documents.Indexes.Models.IndexerStatus status = Azure.Search.Documents.Indexes.Models.IndexerStatus.Unknown, Azure.Search.Documents.Indexes.Models.IndexerRuntime runtime = null, Azure.Search.Documents.Indexes.Models.IndexerExecutionResult lastResult = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Indexes.Models.IndexerExecutionResult> executionHistory = null, Azure.Search.Documents.Indexes.Models.SearchIndexerLimits limits = null, Azure.Search.Documents.Indexes.Models.IndexerState currentState = null) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchIndexerWarning SearchIndexerWarning(string key, string message, string name, string details, string documentationLink) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.KnowledgeSource SearchIndexKnowledgeSource(string name = null, string description = null, string kind = null, string eTag = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null, Azure.Search.Documents.Indexes.Models.SearchIndexKnowledgeSourceParameters searchIndexParameters = null) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Indexes.Models.SearchServiceLimits SearchServiceLimits(int? maxFieldsPerIndex, int? maxFieldNestingDepthPerIndex, int? maxComplexCollectionFieldsPerIndex, int? maxComplexObjectsInCollectionsPerDocument, long? maxStoragePerIndexInBytes) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceLimits SearchServiceLimits(int? maxFieldsPerIndex = default(int?), int? maxFieldNestingDepthPerIndex = default(int?), int? maxComplexCollectionFieldsPerIndex = default(int?), int? maxComplexObjectsInCollectionsPerDocument = default(int?), long? maxStoragePerIndexInBytes = default(long?), long? maxCumulativeIndexerRuntimeSeconds = default(long?)) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceStatistics SearchServiceStatistics(Azure.Search.Documents.Indexes.Models.SearchServiceCounters counters, Azure.Search.Documents.Indexes.Models.SearchServiceLimits limits) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SearchServiceStatistics SearchServiceStatistics(Azure.Search.Documents.Indexes.Models.SearchServiceCounters counters = null, Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime indexersRuntime = null, Azure.Search.Documents.Indexes.Models.SearchServiceLimits limits = null) { throw null; }
        public static Azure.Search.Documents.Models.SearchSuggestion<T> SearchSuggestion<T>(T document, string text) { throw null; }
        public static Azure.Search.Documents.Models.SemanticDebugInfo SemanticDebugInfo(Azure.Search.Documents.Models.QueryResultDocumentSemanticField titleField = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> contentFields = null, System.Collections.Generic.IEnumerable<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> keywordFields = null, Azure.Search.Documents.Models.QueryResultDocumentRerankerInput rerankerInput = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.SemanticSearchResult SemanticSearchResult(double? rerankerScore, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryCaptionResult> captions) { throw null; }
        public static Azure.Search.Documents.Models.SemanticSearchResult SemanticSearchResult(double? rerankerScore, double? rerankerBoostedScore, System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryCaptionResult> captions) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Search.Documents.Models.SemanticSearchResults SemanticSearchResults(System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryAnswerResult> answers, Azure.Search.Documents.Models.SemanticErrorReason? errorReason, Azure.Search.Documents.Models.SemanticSearchResultsType? resultsType) { throw null; }
        public static Azure.Search.Documents.Models.SemanticSearchResults SemanticSearchResults(System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryAnswerResult> answers, Azure.Search.Documents.Models.SemanticErrorReason? errorReason, Azure.Search.Documents.Models.SemanticSearchResultsType? resultsType, Azure.Search.Documents.Models.SemanticQueryRewritesResultType? semanticQueryRewritesResultType) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.ServiceIndexersRuntime ServiceIndexersRuntime(long usedSeconds = (long)0, long? remainingSeconds = default(long?), System.DateTimeOffset beginningTime = default(System.DateTimeOffset), System.DateTimeOffset endingTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Search.Documents.KnowledgeBases.Models.SharePointSensitivityLabelInfo SharePointSensitivityLabelInfo(string displayName = null, string sensitivityLabelId = null, string tooltip = null, int? priority = default(int?), string color = null, bool? isEncrypted = default(bool?)) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SimilarityAlgorithm SimilarityAlgorithm(string oDataType) { throw null; }
        public static Azure.Search.Documents.Models.SingleVectorFieldResult SingleVectorFieldResult(double? searchScore = default(double?), double? vectorSimilarity = default(double?)) { throw null; }
        public static Azure.Search.Documents.Models.SuggestResults<T> SuggestResults<T>(System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchSuggestion<T>> results, double? coverage) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SynchronizationState SynchronizationState(System.DateTimeOffset startTime = default(System.DateTimeOffset), int itemsUpdatesProcessed = 0, int itemsUpdatesFailed = 0, int itemsSkipped = 0) { throw null; }
        public static Azure.Search.Documents.Indexes.Models.SynonymMap SynonymMap(string name = null, string format = null, string synonyms = null, Azure.Search.Documents.Indexes.Models.SearchResourceEncryptionKey encryptionKey = null, string etag = null, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData = null) { throw null; }
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
    public abstract partial class SearchResults<T>
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
    public partial class SearchScoreThreshold : Azure.Search.Documents.Models.VectorThreshold, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SearchScoreThreshold>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SearchScoreThreshold>
    {
        public SearchScoreThreshold(double value) { }
        public double Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.SearchScoreThreshold System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SearchScoreThreshold>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SearchScoreThreshold>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.SearchScoreThreshold System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SearchScoreThreshold>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SearchScoreThreshold>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SearchScoreThreshold>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchSuggestion<T>
    {
        internal SearchSuggestion() { }
        public T Document { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class SemanticDebugInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SemanticDebugInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SemanticDebugInfo>
    {
        internal SemanticDebugInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> ContentFields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.QueryResultDocumentSemanticField> KeywordFields { get { throw null; } }
        public Azure.Search.Documents.Models.QueryResultDocumentRerankerInput RerankerInput { get { throw null; } }
        public Azure.Search.Documents.Models.QueryResultDocumentSemanticField TitleField { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.SemanticDebugInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SemanticDebugInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SemanticDebugInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.SemanticDebugInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SemanticDebugInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SemanticDebugInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SemanticDebugInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public double? RerankerBoostedScore { get { throw null; } }
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
    public partial class SingleVectorFieldResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SingleVectorFieldResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SingleVectorFieldResult>
    {
        internal SingleVectorFieldResult() { }
        public double? SearchScore { get { throw null; } }
        public double? VectorSimilarity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.SingleVectorFieldResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SingleVectorFieldResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.SingleVectorFieldResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.SingleVectorFieldResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SingleVectorFieldResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SingleVectorFieldResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.SingleVectorFieldResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuggestResults<T>
    {
        internal SuggestResults() { }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Search.Documents.Models.SearchSuggestion<T>> Results { get { throw null; } }
    }
    public partial class TextResult : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.TextResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.TextResult>
    {
        internal TextResult() { }
        public double? SearchScore { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.TextResult System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.TextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.TextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.TextResult System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.TextResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.TextResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.TextResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Search.Documents.Models.VectorFilterMode StrictPostFilter { get { throw null; } }
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
    public partial class VectorizableImageBinaryQuery : Azure.Search.Documents.Models.VectorQuery, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableImageBinaryQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageBinaryQuery>
    {
        public VectorizableImageBinaryQuery() { }
        public string Base64Image { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizableImageBinaryQuery System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableImageBinaryQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableImageBinaryQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizableImageBinaryQuery System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageBinaryQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageBinaryQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageBinaryQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorizableImageUrlQuery : Azure.Search.Documents.Models.VectorQuery, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableImageUrlQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageUrlQuery>
    {
        public VectorizableImageUrlQuery() { }
        public System.Uri Url { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizableImageUrlQuery System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableImageUrlQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableImageUrlQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizableImageUrlQuery System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageUrlQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageUrlQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableImageUrlQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorizableTextQuery : Azure.Search.Documents.Models.VectorQuery, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableTextQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableTextQuery>
    {
        public VectorizableTextQuery(string text) { }
        public Azure.Search.Documents.Models.QueryRewritesType? QueryRewrites { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizableTextQuery System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableTextQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizableTextQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizableTextQuery System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableTextQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableTextQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizableTextQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorizedQuery : Azure.Search.Documents.Models.VectorQuery, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizedQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizedQuery>
    {
        public VectorizedQuery(System.ReadOnlyMemory<float> vector) { }
        public System.ReadOnlyMemory<float> Vector { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizedQuery System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizedQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorizedQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorizedQuery System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizedQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizedQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorizedQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorQuery : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorQuery>
    {
        protected VectorQuery() { }
        public bool? Exhaustive { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Fields { get { throw null; } }
        public string FilterOverride { get { throw null; } set { } }
        public int? KNearestNeighborsCount { get { throw null; } set { } }
        public double? Oversampling { get { throw null; } set { } }
        public int? PerDocumentVectorLimit { get { throw null; } set { } }
        public Azure.Search.Documents.Models.VectorThreshold Threshold { get { throw null; } set { } }
        public float? Weight { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorQuery System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorQuery System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorsDebugInfo : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorsDebugInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorsDebugInfo>
    {
        internal VectorsDebugInfo() { }
        public Azure.Search.Documents.Models.QueryResultDocumentSubscores Subscores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorsDebugInfo System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorsDebugInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorsDebugInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorsDebugInfo System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorsDebugInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorsDebugInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorsDebugInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorSearchOptions
    {
        public VectorSearchOptions() { }
        public Azure.Search.Documents.Models.VectorFilterMode? FilterMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Search.Documents.Models.VectorQuery> Queries { get { throw null; } }
    }
    public partial class VectorSimilarityThreshold : Azure.Search.Documents.Models.VectorThreshold, System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorSimilarityThreshold>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorSimilarityThreshold>
    {
        public VectorSimilarityThreshold(double value) { }
        public double Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorSimilarityThreshold System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorSimilarityThreshold>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorSimilarityThreshold>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorSimilarityThreshold System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorSimilarityThreshold>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorSimilarityThreshold>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorSimilarityThreshold>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorThreshold : System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorThreshold>, System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorThreshold>
    {
        protected VectorThreshold() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorThreshold System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorThreshold>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Search.Documents.Models.VectorThreshold>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Search.Documents.Models.VectorThreshold System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorThreshold>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorThreshold>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Search.Documents.Models.VectorThreshold>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
