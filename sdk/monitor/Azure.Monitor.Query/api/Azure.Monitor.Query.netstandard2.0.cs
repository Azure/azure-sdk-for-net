namespace Azure.Monitor.Query
{
    public partial class LogsBatchQuery
    {
        public LogsBatchQuery() { }
        public virtual string AddWorkspaceQuery(string workspaceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogsQueryAudience : System.IEquatable<Azure.Monitor.Query.LogsQueryAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogsQueryAudience(string value) { throw null; }
        public static Azure.Monitor.Query.LogsQueryAudience AzureChina { get { throw null; } }
        public static Azure.Monitor.Query.LogsQueryAudience AzureGovernment { get { throw null; } }
        public static Azure.Monitor.Query.LogsQueryAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.LogsQueryAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.LogsQueryAudience left, Azure.Monitor.Query.LogsQueryAudience right) { throw null; }
        public static implicit operator Azure.Monitor.Query.LogsQueryAudience (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.LogsQueryAudience left, Azure.Monitor.Query.LogsQueryAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsQueryClient
    {
        protected LogsQueryClient() { }
        public LogsQueryClient(Azure.Core.TokenCredential credential) { }
        public LogsQueryClient(Azure.Core.TokenCredential credential, Azure.Monitor.Query.LogsQueryClientOptions options) { }
        public LogsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LogsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.LogsQueryClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public static string CreateQuery(System.FormattableString query) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.LogsBatchQueryResultCollection> QueryBatch(Azure.Monitor.Query.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.LogsBatchQueryResultCollection>> QueryBatchAsync(Azure.Monitor.Query.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult> QueryResource(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult>> QueryResourceAsync(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<T>>> QueryResourceAsync<T>(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<T>> QueryResource<T>(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult> QueryWorkspace(string workspaceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult>> QueryWorkspaceAsync(string workspaceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<T>>> QueryWorkspaceAsync<T>(string workspaceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<T>> QueryWorkspace<T>(string workspaceId, string query, Azure.Monitor.Query.QueryTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsQueryClientOptions : Azure.Core.ClientOptions
    {
        public LogsQueryClientOptions(Azure.Monitor.Query.LogsQueryClientOptions.ServiceVersion version = Azure.Monitor.Query.LogsQueryClientOptions.ServiceVersion.V1) { }
        public Azure.Monitor.Query.LogsQueryAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
    public partial class LogsQueryOptions
    {
        public LogsQueryOptions() { }
        public System.Collections.Generic.IList<string> AdditionalWorkspaces { get { throw null; } }
        public bool AllowPartialErrors { get { throw null; } set { } }
        public bool IncludeStatistics { get { throw null; } set { } }
        public bool IncludeVisualization { get { throw null; } set { } }
        public System.TimeSpan? ServerTimeout { get { throw null; } set { } }
    }
    public partial class MetricsBatchQueryClient
    {
        protected MetricsBatchQueryClient() { }
        public MetricsBatchQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.MetricsBatchQueryClientOptions options = null) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.Monitor.Query.Models.MetricsBatchResult> QueryBatch(System.Collections.Generic.List<string> resourceIds, System.Collections.Generic.List<string> metricNames, string metricNamespace, Azure.Monitor.Query.MetricsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.MetricsBatchResult>> QueryBatchAsync(System.Collections.Generic.List<string> resourceIds, System.Collections.Generic.List<string> metricNames, string metricNamespace, Azure.Monitor.Query.MetricsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricsBatchQueryClientOptions : Azure.Core.ClientOptions
    {
        public MetricsBatchQueryClientOptions(Azure.Monitor.Query.MetricsBatchQueryClientOptions.ServiceVersion version = Azure.Monitor.Query.MetricsBatchQueryClientOptions.ServiceVersion.V2023_05_01_PREVIEW) { }
        public enum ServiceVersion
        {
            V2023_05_01_PREVIEW = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsQueryAudience : System.IEquatable<Azure.Monitor.Query.MetricsQueryAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricsQueryAudience(string value) { throw null; }
        public static Azure.Monitor.Query.MetricsQueryAudience AzureChina { get { throw null; } }
        public static Azure.Monitor.Query.MetricsQueryAudience AzureGovernment { get { throw null; } }
        public static Azure.Monitor.Query.MetricsQueryAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.MetricsQueryAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.MetricsQueryAudience left, Azure.Monitor.Query.MetricsQueryAudience right) { throw null; }
        public static implicit operator Azure.Monitor.Query.MetricsQueryAudience (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.MetricsQueryAudience left, Azure.Monitor.Query.MetricsQueryAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsQueryClient
    {
        protected MetricsQueryClient() { }
        public MetricsQueryClient(Azure.Core.TokenCredential credential) { }
        public MetricsQueryClient(Azure.Core.TokenCredential credential, Azure.Monitor.Query.MetricsQueryClientOptions options) { }
        public MetricsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.MetricsQueryClientOptions options = null) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Pageable<Azure.Monitor.Query.Models.MetricDefinition> GetMetricDefinitions(string resourceId, string metricsNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Monitor.Query.Models.MetricDefinition> GetMetricDefinitionsAsync(string resourceId, string metricsNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Monitor.Query.Models.MetricNamespace> GetMetricNamespaces(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Monitor.Query.Models.MetricNamespace> GetMetricNamespacesAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.MetricsQueryResult> QueryResource(string resourceId, System.Collections.Generic.IEnumerable<string> metrics, Azure.Monitor.Query.MetricsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.MetricsQueryResult>> QueryResourceAsync(string resourceId, System.Collections.Generic.IEnumerable<string> metrics, Azure.Monitor.Query.MetricsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricsQueryClientOptions : Azure.Core.ClientOptions
    {
        public MetricsQueryClientOptions(Azure.Monitor.Query.MetricsQueryClientOptions.ServiceVersion version = Azure.Monitor.Query.MetricsQueryClientOptions.ServiceVersion.V2018_01_01) { }
        public Azure.Monitor.Query.MetricsQueryAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2018_01_01 = 1,
        }
    }
    public partial class MetricsQueryOptions
    {
        public MetricsQueryOptions() { }
        public System.Collections.Generic.IList<Azure.Monitor.Query.Models.MetricAggregationType> Aggregations { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Granularity { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public Azure.Monitor.Query.QueryTimeRange? TimeRange { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryTimeRange : System.IEquatable<Azure.Monitor.Query.QueryTimeRange>
    {
        public QueryTimeRange(System.DateTimeOffset start, System.DateTimeOffset end) { throw null; }
        public QueryTimeRange(System.DateTimeOffset start, System.TimeSpan duration) { throw null; }
        public QueryTimeRange(System.TimeSpan duration) { throw null; }
        public QueryTimeRange(System.TimeSpan duration, System.DateTimeOffset end) { throw null; }
        public static Azure.Monitor.Query.QueryTimeRange All { get { throw null; } }
        public System.TimeSpan Duration { get { throw null; } }
        public System.DateTimeOffset? End { get { throw null; } }
        public System.DateTimeOffset? Start { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.QueryTimeRange other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.QueryTimeRange left, Azure.Monitor.Query.QueryTimeRange right) { throw null; }
        public static implicit operator Azure.Monitor.Query.QueryTimeRange (System.TimeSpan timeSpan) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.QueryTimeRange left, Azure.Monitor.Query.QueryTimeRange right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Monitor.Query.Models
{
    public partial class LogsBatchQueryResult : Azure.Monitor.Query.Models.LogsQueryResult
    {
        internal LogsBatchQueryResult() { }
        public string Id { get { throw null; } }
    }
    public partial class LogsBatchQueryResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.Monitor.Query.Models.LogsBatchQueryResult>
    {
        internal LogsBatchQueryResultCollection() : base (default(System.Collections.Generic.IList<Azure.Monitor.Query.Models.LogsBatchQueryResult>)) { }
        public Azure.Monitor.Query.Models.LogsBatchQueryResult GetResult(string queryId) { throw null; }
        public System.Collections.Generic.IReadOnlyList<T> GetResult<T>(string queryId) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogsColumnType : System.IEquatable<Azure.Monitor.Query.Models.LogsColumnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogsColumnType(string value) { throw null; }
        public static Azure.Monitor.Query.Models.LogsColumnType Bool { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Datetime { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Decimal { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Dynamic { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Guid { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Int { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Long { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Real { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType String { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogsColumnType Timespan { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Models.LogsColumnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Models.LogsColumnType left, Azure.Monitor.Query.Models.LogsColumnType right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Models.LogsColumnType (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Models.LogsColumnType left, Azure.Monitor.Query.Models.LogsColumnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsQueryResult
    {
        internal LogsQueryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsTable> AllTables { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Monitor.Query.Models.LogsQueryResultStatus Status { get { throw null; } }
        public Azure.Monitor.Query.Models.LogsTable Table { get { throw null; } }
        public System.BinaryData GetStatistics() { throw null; }
        public System.BinaryData GetVisualization() { throw null; }
    }
    public enum LogsQueryResultStatus
    {
        Success = 0,
        PartialFailure = 1,
        Failure = 2,
    }
    public partial class LogsTable
    {
        internal LogsTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsTableColumn> Columns { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsTableRow> Rows { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class LogsTableColumn
    {
        internal LogsTableColumn() { }
        public string Name { get { throw null; } }
        public Azure.Monitor.Query.Models.LogsColumnType Type { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class LogsTableRow : System.Collections.Generic.IEnumerable<object>, System.Collections.Generic.IReadOnlyCollection<object>, System.Collections.Generic.IReadOnlyList<object>, System.Collections.IEnumerable
    {
        internal LogsTableRow() { }
        public int Count { get { throw null; } }
        public object this[int index] { get { throw null; } }
        public object this[string name] { get { throw null; } }
        public bool? GetBoolean(int index) { throw null; }
        public bool? GetBoolean(string name) { throw null; }
        public System.DateTimeOffset? GetDateTimeOffset(int index) { throw null; }
        public System.DateTimeOffset? GetDateTimeOffset(string name) { throw null; }
        public decimal? GetDecimal(int index) { throw null; }
        public decimal? GetDecimal(string name) { throw null; }
        public double? GetDouble(int index) { throw null; }
        public double? GetDouble(string name) { throw null; }
        public System.BinaryData GetDynamic(int index) { throw null; }
        public System.BinaryData GetDynamic(string name) { throw null; }
        public System.Guid? GetGuid(int index) { throw null; }
        public System.Guid? GetGuid(string name) { throw null; }
        public int? GetInt32(int index) { throw null; }
        public int? GetInt32(string name) { throw null; }
        public long? GetInt64(int index) { throw null; }
        public long? GetInt64(string name) { throw null; }
        public string GetString(int index) { throw null; }
        public string GetString(string name) { throw null; }
        public System.TimeSpan? GetTimeSpan(int index) { throw null; }
        public System.TimeSpan? GetTimeSpan(string name) { throw null; }
        System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public override string ToString() { throw null; }
    }
    public enum MetricAggregationType
    {
        None = 0,
        Average = 1,
        Count = 2,
        Minimum = 3,
        Maximum = 4,
        Total = 5,
    }
    public partial class MetricAvailability
    {
        internal MetricAvailability() { }
        public System.TimeSpan? Granularity { get { throw null; } }
        public System.TimeSpan? Retention { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricClass : System.IEquatable<Azure.Monitor.Query.Models.MetricClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricClass(string value) { throw null; }
        public static Azure.Monitor.Query.Models.MetricClass Availability { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricClass Errors { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricClass Latency { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricClass Saturation { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricClass Transactions { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Models.MetricClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Models.MetricClass left, Azure.Monitor.Query.Models.MetricClass right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Models.MetricClass (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Models.MetricClass left, Azure.Monitor.Query.Models.MetricClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricDefinition
    {
        internal MetricDefinition() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDimensionRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.Monitor.Query.Models.MetricClass? MetricClass { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.Monitor.Query.Models.MetricAggregationType? PrimaryAggregationType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricAggregationType> SupportedAggregationTypes { get { throw null; } }
        public Azure.Monitor.Query.Models.MetricUnit? Unit { get { throw null; } }
    }
    public partial class MetricNamespace
    {
        internal MetricNamespace() { }
        public Azure.Monitor.Query.Models.MetricNamespaceClassification? Classification { get { throw null; } }
        public string FullyQualifiedName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricNamespaceClassification : System.IEquatable<Azure.Monitor.Query.Models.MetricNamespaceClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricNamespaceClassification(string value) { throw null; }
        public static Azure.Monitor.Query.Models.MetricNamespaceClassification Custom { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricNamespaceClassification Platform { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricNamespaceClassification QualityOfService { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Models.MetricNamespaceClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Models.MetricNamespaceClassification left, Azure.Monitor.Query.Models.MetricNamespaceClassification right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Models.MetricNamespaceClassification (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Models.MetricNamespaceClassification left, Azure.Monitor.Query.Models.MetricNamespaceClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricResult
    {
        internal MetricResult() { }
        public string Description { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricTimeSeriesElement> TimeSeries { get { throw null; } }
        public Azure.Monitor.Query.Models.MetricUnit Unit { get { throw null; } }
    }
    public partial class MetricsBatchResult
    {
        internal MetricsBatchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricsBatchResultValues> Values { get { throw null; } }
    }
    public partial class MetricsBatchResultValues
    {
        internal MetricsBatchResultValues() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.TimeSpan? Interval { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricResult> Metrics { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.AzureLocation ResourceRegion { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class MetricsQueryResult
    {
        internal MetricsQueryResult() { }
        public int? Cost { get { throw null; } }
        public System.TimeSpan? Granularity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricResult> Metrics { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string ResourceRegion { get { throw null; } }
        public Azure.Monitor.Query.QueryTimeRange TimeSpan { get { throw null; } }
        public Azure.Monitor.Query.Models.MetricResult GetMetricByName(string name) { throw null; }
    }
    public partial class MetricTimeSeriesElement
    {
        internal MetricTimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricValue> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricUnit : System.IEquatable<Azure.Monitor.Query.Models.MetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricUnit(string value) { throw null; }
        public static Azure.Monitor.Query.Models.MetricUnit BitsPerSecond { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit Bytes { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit ByteSeconds { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit Cores { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit Count { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit CountPerSecond { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit MilliCores { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit MilliSeconds { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit NanoCores { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit Percent { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit Seconds { get { throw null; } }
        public static Azure.Monitor.Query.Models.MetricUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Models.MetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Models.MetricUnit left, Azure.Monitor.Query.Models.MetricUnit right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Models.MetricUnit (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Models.MetricUnit left, Azure.Monitor.Query.Models.MetricUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricValue
    {
        internal MetricValue() { }
        public double? Average { get { throw null; } }
        public double? Count { get { throw null; } }
        public double? Maximum { get { throw null; } }
        public double? Minimum { get { throw null; } }
        public System.DateTimeOffset TimeStamp { get { throw null; } }
        public double? Total { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public static partial class MonitorQueryModelFactory
    {
        public static Azure.Monitor.Query.Models.LogsQueryResult LogsQueryResult(System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsTable> allTables, System.BinaryData statistics, System.BinaryData visualization, System.BinaryData error) { throw null; }
        public static Azure.Monitor.Query.Models.LogsTable LogsTable(string name, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Models.LogsTableColumn> columns, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Models.LogsTableRow> rows) { throw null; }
        public static Azure.Monitor.Query.Models.LogsTableColumn LogsTableColumn(string name = null, Azure.Monitor.Query.Models.LogsColumnType type = default(Azure.Monitor.Query.Models.LogsColumnType)) { throw null; }
        public static Azure.Monitor.Query.Models.LogsTableRow LogsTableRow(System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Models.LogsTableColumn> columns, System.Collections.Generic.IEnumerable<object> values) { throw null; }
        public static Azure.Monitor.Query.Models.MetricAvailability MetricAvailability(System.TimeSpan? granularity = default(System.TimeSpan?), System.TimeSpan? retention = default(System.TimeSpan?)) { throw null; }
        public static Azure.Monitor.Query.Models.MetricResult MetricResult(string id, string resourceType, string name, Azure.Monitor.Query.Models.MetricUnit unit, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Models.MetricTimeSeriesElement> timeSeries) { throw null; }
        public static Azure.Monitor.Query.Models.MetricsBatchResult MetricsBatchResult(System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Models.MetricsBatchResultValues> values = null) { throw null; }
        public static Azure.Monitor.Query.Models.MetricsBatchResultValues MetricsBatchResultValues(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset endTime = default(System.DateTimeOffset), System.TimeSpan? interval = default(System.TimeSpan?), string @namespace = null, Azure.Core.AzureLocation resourceRegion = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier resourceId = null, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Models.MetricResult> metrics = null) { throw null; }
        public static Azure.Monitor.Query.Models.MetricsQueryResult MetricsQueryResult(int? cost, string timespan, System.TimeSpan? granularity, string @namespace, string resourceRegion, System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricResult> metrics) { throw null; }
        public static Azure.Monitor.Query.Models.MetricTimeSeriesElement MetricTimeSeriesElement(System.Collections.Generic.IReadOnlyDictionary<string, string> metadataValues, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Models.MetricValue> values) { throw null; }
        public static Azure.Monitor.Query.Models.MetricValue MetricValue(System.DateTimeOffset timeStamp = default(System.DateTimeOffset), double? average = default(double?), double? minimum = default(double?), double? maximum = default(double?), double? total = default(double?), double? count = default(double?)) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class LogsQueryClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.LogsQueryClient, Azure.Monitor.Query.LogsQueryClientOptions> AddLogsQueryClient<TBuilder>(this TBuilder builder) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.LogsQueryClient, Azure.Monitor.Query.LogsQueryClientOptions> AddLogsQueryClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.LogsQueryClient, Azure.Monitor.Query.LogsQueryClientOptions> AddLogsQueryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public static partial class MetricsQueryClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.MetricsQueryClient, Azure.Monitor.Query.MetricsQueryClientOptions> AddMetricsQueryClient<TBuilder>(this TBuilder builder) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.MetricsQueryClient, Azure.Monitor.Query.MetricsQueryClientOptions> AddMetricsQueryClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.MetricsQueryClient, Azure.Monitor.Query.MetricsQueryClientOptions> AddMetricsQueryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
