namespace Azure.ResourceManager.ResourceGraph
{
    public static partial class ResourceGraphExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.Models.QueryResponse> Resources(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.QueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.QueryResponse>> ResourcesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.QueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.BinaryData> ResourcesHistory(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> ResourcesHistoryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceGraph.Models
{
    public enum AuthorizationScopeFilter
    {
        AtScopeAndBelow = 0,
        AtScopeAndAbove = 1,
        AtScopeExact = 2,
        AtScopeAboveAndBelow = 3,
    }
    public partial class DateTimeInterval
    {
        public DateTimeInterval(System.DateTimeOffset start, System.DateTimeOffset end) { }
        public System.DateTimeOffset End { get { throw null; } }
        public System.DateTimeOffset Start { get { throw null; } }
    }
    public partial class ErrorDetails
    {
        internal ErrorDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public abstract partial class Facet
    {
        protected Facet(string expression) { }
        public string Expression { get { throw null; } }
    }
    public partial class FacetError : Azure.ResourceManager.ResourceGraph.Models.Facet
    {
        internal FacetError() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.ErrorDetails> Errors { get { throw null; } }
    }
    public partial class FacetRequest
    {
        public FacetRequest(string expression) { }
        public string Expression { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions Options { get { throw null; } set { } }
    }
    public partial class FacetRequestOptions
    {
        public FacetRequestOptions() { }
        public string Filter { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder? SortOrder { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class FacetResult : Azure.ResourceManager.ResourceGraph.Models.Facet
    {
        internal FacetResult() : base (default(string)) { }
        public int Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public long TotalRecords { get { throw null; } }
    }
    public enum FacetSortOrder
    {
        Asc = 0,
        Desc = 1,
    }
    public partial class QueryContent
    {
        public QueryContent(string query) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.FacetRequest> Facets { get { throw null; } }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.QueryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
    }
    public partial class QueryRequestOptions
    {
        public QueryRequestOptions() { }
        public bool? AllowPartialScopes { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter? AuthorizationScopeFilter { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class QueryResponse
    {
        internal QueryResponse() { }
        public long Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.Facet> Facets { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultTruncated ResultTruncated { get { throw null; } }
        public string SkipToken { get { throw null; } }
        public long TotalRecords { get { throw null; } }
    }
    public partial class ResourcesHistoryContent
    {
        public ResourcesHistoryContent() { }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
    }
    public partial class ResourcesHistoryRequestOptions
    {
        public ResourcesHistoryRequestOptions() { }
        public Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval Interval { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public enum ResultFormat
    {
        Table = 0,
        ObjectArray = 1,
    }
    public enum ResultTruncated
    {
        True = 0,
        False = 1,
    }
}
