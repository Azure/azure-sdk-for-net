namespace Azure.ResourceManager.ResourceGraph
{
    public static partial class ResourceGraphExtensions
    {
        public static Azure.Response<System.BinaryData> GetResourceHistory(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourceHistoryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult> GetResources(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>> GetResourcesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceGraph.Mocking
{
    public partial class MockableResourceGraphTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphTenantResource() { }
        public virtual Azure.Response<System.BinaryData> GetResourceHistory(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourceHistoryAsync(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult> GetResources(Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>> GetResourcesAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceGraph.Models
{
    public static partial class ArmResourceGraphModelFactory
    {
        public static Azure.ResourceManager.ResourceGraph.Models.Facet Facet(string expression = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetError FacetError(string expression = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails> errors = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails FacetErrorDetails(string code = null, string message = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetRequest FacetRequest(string expression = null, Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions options = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetResult FacetResult(string expression = null, long totalRecords = (long)0, int count = 0, System.BinaryData data = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent ResourceQueryContent(System.Collections.Generic.IEnumerable<string> subscriptions = null, System.Collections.Generic.IEnumerable<string> managementGroups = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions options = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.FacetRequest> facets = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult ResourceQueryResult(long totalRecords = (long)0, long count = (long)0, Azure.ResourceManager.ResourceGraph.Models.ResultTruncated resultTruncated = Azure.ResourceManager.ResourceGraph.Models.ResultTruncated.True, string skipToken = null, System.BinaryData data = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.Facet> facets = null) { throw null; }
    }
    public enum AuthorizationScopeFilter
    {
        AtScopeAndBelow = 0,
        AtScopeAndAbove = 1,
        AtScopeExact = 2,
        AtScopeAboveAndBelow = 3,
    }
    public partial class DateTimeInterval : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>
    {
        public DateTimeInterval(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Facet : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> _serializedAdditionalRawData;
        protected Facet(string expression) { }
        public string Expression { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.Facet System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.Facet System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetError : Azure.ResourceManager.ResourceGraph.Models.Facet, System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>
    {
        internal FacetError() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails> Errors { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.FacetError System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetError System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetErrorDetails : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>
    {
        internal FacetErrorDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetRequest : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>
    {
        public FacetRequest(string expression) { }
        public string Expression { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions Options { get { throw null; } set { } }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequest System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequest System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetRequestOptions : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>
    {
        public FacetRequestOptions() { }
        public string Filter { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder? SortOrder { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetResult : Azure.ResourceManager.ResourceGraph.Models.Facet, System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>
    {
        internal FacetResult() : base (default(string)) { }
        public int Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public long TotalRecords { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.FacetResult System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetResult System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FacetSortOrder
    {
        Asc = 0,
        Desc = 1,
    }
    public partial class ResourceQueryContent : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>
    {
        public ResourceQueryContent(string query) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.FacetRequest> Facets { get { throw null; } }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryRequestOptions : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>
    {
        public ResourceQueryRequestOptions() { }
        public bool? AllowPartialScopes { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter? AuthorizationScopeFilter { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryResult : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>
    {
        internal ResourceQueryResult() { }
        public long Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.Facet> Facets { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultTruncated ResultTruncated { get { throw null; } }
        public string SkipToken { get { throw null; } }
        public long TotalRecords { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesHistoryContent : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>
    {
        public ResourcesHistoryContent() { }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesHistoryRequestOptions : System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>, System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>
    {
        public ResourcesHistoryRequestOptions() { }
        public Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval Interval { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.Net.ClientModel.Core.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.Net.ClientModel.Core.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
