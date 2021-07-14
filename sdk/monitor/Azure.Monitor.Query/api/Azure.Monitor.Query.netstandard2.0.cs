namespace Azure.Monitor.Query
{
    public partial class LogsBatchQuery
    {
        public LogsBatchQuery() { }
        public virtual string AddQuery(string workspace, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null) { throw null; }
    }
    public partial class LogsQueryClient
    {
        protected LogsQueryClient() { }
        public LogsQueryClient(Azure.Core.TokenCredential credential) { }
        public LogsQueryClient(Azure.Core.TokenCredential credential, Azure.Monitor.Query.LogsQueryClientOptions options) { }
        public LogsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LogsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.LogsQueryClientOptions options) { }
        public static string CreateQuery(System.FormattableString filter) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult> Query(string workspaceId, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult>> QueryAsync(string workspaceId, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<T>>> QueryAsync<T>(string workspaceId, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.LogsBatchQueryResults> QueryBatch(Azure.Monitor.Query.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.LogsBatchQueryResults>> QueryBatchAsync(Azure.Monitor.Query.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<T>> Query<T>(string workspaceId, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsQueryClientOptions : Azure.Core.ClientOptions
    {
        public LogsQueryClientOptions(Azure.Monitor.Query.LogsQueryClientOptions.ServiceVersion version = Azure.Monitor.Query.LogsQueryClientOptions.ServiceVersion.V1) { }
        public string AuthenticationScope { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1 = 0,
        }
    }
    public partial class LogsQueryOptions
    {
        public LogsQueryOptions() { }
        public System.Collections.Generic.IList<string> AdditionalWorkspaces { get { throw null; } }
        public bool IncludeStatistics { get { throw null; } set { } }
        public bool IncludeVisualization { get { throw null; } set { } }
        public System.TimeSpan? ServerTimeout { get { throw null; } set { } }
    }
    public partial class MetricsQueryClient
    {
        protected MetricsQueryClient() { }
        public MetricsQueryClient(Azure.Core.TokenCredential credential) { }
        public MetricsQueryClient(Azure.Core.TokenCredential credential, Azure.Monitor.Query.MetricsQueryClientOptions options) { }
        public MetricsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.MetricsQueryClientOptions options = null) { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricNamespace>> GetMetricNamespaces(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricNamespace>>> GetMetricNamespacesAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricDefinition>> GetMetrics(string resourceId, string metricsNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricDefinition>>> GetMetricsAsync(string resourceId, string metricsNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.MetricQueryResult> Query(string resourceId, System.Collections.Generic.IEnumerable<string> metrics, Azure.Monitor.Query.MetricsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.MetricQueryResult>> QueryAsync(string resourceId, System.Collections.Generic.IEnumerable<string> metrics, Azure.Monitor.Query.MetricsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricsQueryClientOptions : Azure.Core.ClientOptions
    {
        public MetricsQueryClientOptions(Azure.Monitor.Query.MetricsQueryClientOptions.ServiceVersion version = Azure.Monitor.Query.MetricsQueryClientOptions.ServiceVersion.V2018_01_01) { }
        public enum ServiceVersion
        {
            V2018_01_01 = 0,
        }
    }
    public partial class MetricsQueryOptions
    {
        public MetricsQueryOptions() { }
        public System.Collections.Generic.IList<Azure.Monitor.Query.Models.MetricAggregationType> Aggregations { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public Azure.Core.DateTimeRange? TimeSpan { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
}
namespace Azure.Monitor.Query.Models
{
    public partial class LogsBatchQueryResult : Azure.Monitor.Query.Models.LogsQueryResult
    {
        internal LogsBatchQueryResult() { }
        public bool HasFailed { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class LogsBatchQueryResults
    {
        internal LogsBatchQueryResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsBatchQueryResult> Results { get { throw null; } }
        public Azure.Monitor.Query.Models.LogsQueryResult GetResult(string queryId) { throw null; }
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
        public Azure.Core.ResponseError Error { get { throw null; } }
        public Azure.Monitor.Query.Models.LogsQueryResultTable PrimaryTable { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultTable> Tables { get { throw null; } }
        public System.BinaryData GetStatistics() { throw null; }
        public System.BinaryData GetVisualization() { throw null; }
    }
    public partial class LogsQueryResultColumn
    {
        internal LogsQueryResultColumn() { }
        public string Name { get { throw null; } }
        public Azure.Monitor.Query.Models.LogsColumnType Type { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class LogsQueryResultRow
    {
        internal LogsQueryResultRow() { }
        public int Count { get { throw null; } }
        public object this[int index] { get { throw null; } }
        public object this[string name] { get { throw null; } }
        public bool GetBoolean(int index) { throw null; }
        public bool GetBoolean(string name) { throw null; }
        public System.DateTimeOffset GetDateTimeOffset(int index) { throw null; }
        public System.DateTimeOffset GetDateTimeOffset(string name) { throw null; }
        public decimal GetDecimal(int index) { throw null; }
        public decimal GetDecimal(string name) { throw null; }
        public double GetDouble(int index) { throw null; }
        public double GetDouble(string name) { throw null; }
        public System.BinaryData GetDynamic(int index) { throw null; }
        public System.BinaryData GetDynamic(string name) { throw null; }
        public System.Guid GetGuid(int index) { throw null; }
        public System.Guid GetGuid(string name) { throw null; }
        public int GetInt32(int index) { throw null; }
        public int GetInt32(string name) { throw null; }
        public long GetInt64(int index) { throw null; }
        public long GetInt64(string name) { throw null; }
        public object GetObject(int index) { throw null; }
        public object GetObject(string name) { throw null; }
        public string GetString(int index) { throw null; }
        public string GetString(string name) { throw null; }
        public System.TimeSpan GetTimeSpan(int index) { throw null; }
        public System.TimeSpan GetTimeSpan(string name) { throw null; }
        public bool IsNull(int index) { throw null; }
        public bool IsNull(string name) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsQueryResultTable
    {
        internal LogsQueryResultTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultColumn> Columns { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultRow> Rows { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<T> Deserialize<T>() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Metric
    {
        internal Metric() { }
        public string DisplayDescription { get { throw null; } }
        public Azure.Core.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.TimeSeriesElement> TimeSeries { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.Monitor.Query.Models.MetricUnit Unit { get { throw null; } }
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
        public System.TimeSpan? Retention { get { throw null; } }
        public System.TimeSpan? TimeGrain { get { throw null; } }
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
        public Azure.Monitor.Query.Models.NamespaceClassification? Classification { get { throw null; } }
        public string FullyQualifiedName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class MetricQueryResult
    {
        internal MetricQueryResult() { }
        public int? Cost { get { throw null; } }
        public System.TimeSpan? Interval { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.Metric> Metrics { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string ResourceRegion { get { throw null; } }
        public Azure.Core.DateTimeRange TimeSpan { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NamespaceClassification : System.IEquatable<Azure.Monitor.Query.Models.NamespaceClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NamespaceClassification(string value) { throw null; }
        public static Azure.Monitor.Query.Models.NamespaceClassification Custom { get { throw null; } }
        public static Azure.Monitor.Query.Models.NamespaceClassification Platform { get { throw null; } }
        public static Azure.Monitor.Query.Models.NamespaceClassification Qos { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Models.NamespaceClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Models.NamespaceClassification left, Azure.Monitor.Query.Models.NamespaceClassification right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Models.NamespaceClassification (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Models.NamespaceClassification left, Azure.Monitor.Query.Models.NamespaceClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class QueryModelFactory
    {
        public static Azure.Monitor.Query.Models.LogsQueryResultColumn LogsQueryResultColumn(string name = null, Azure.Monitor.Query.Models.LogsColumnType type = default(Azure.Monitor.Query.Models.LogsColumnType)) { throw null; }
        public static Azure.Monitor.Query.Models.MetricAvailability MetricAvailability(System.TimeSpan? timeGrain = default(System.TimeSpan?), System.TimeSpan? retention = default(System.TimeSpan?)) { throw null; }
        public static Azure.Monitor.Query.Models.MetricValue MetricValue(System.DateTimeOffset timeStamp = default(System.DateTimeOffset), double? average = default(double?), double? minimum = default(double?), double? maximum = default(double?), double? total = default(double?), double? count = default(double?)) { throw null; }
    }
    public partial class TimeSeriesElement
    {
        internal TimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
    }
}
