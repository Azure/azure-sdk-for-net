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
        public virtual Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult> Query(string workspace, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.LogsQueryResult>> QueryAsync(string workspace, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<T>>> QueryAsync<T>(string workspace, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Models.LogsBatchQueryResult> QueryBatch(Azure.Monitor.Query.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Models.LogsBatchQueryResult>> QueryBatchAsync(Azure.Monitor.Query.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<T>> Query<T>(string workspace, string query, Azure.Core.DateTimeRange timeRange, Azure.Monitor.Query.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public MetricsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public MetricsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.MetricsQueryClientOptions options) { }
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
    public static partial class QueryModelFactory
    {
        public static Azure.Monitor.Query.Models.LogsQueryResult LogsQueryResult(System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultTable> tables = null, System.Text.Json.JsonElement Statistics = default(System.Text.Json.JsonElement), System.Text.Json.JsonElement Visualization = default(System.Text.Json.JsonElement)) { throw null; }
        public static Azure.Monitor.Query.Models.LogsQueryResultColumn LogsQueryResultColumn(string name = null, Azure.Monitor.Query.Models.LogColumnTypes type = default(Azure.Monitor.Query.Models.LogColumnTypes)) { throw null; }
        public static Azure.Monitor.Query.Models.LogsQueryResultTable LogsQueryResultTable(string name = null, System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultColumn> columns = null, System.Text.Json.JsonElement internalRows = default(System.Text.Json.JsonElement)) { throw null; }
        public static Azure.Monitor.Query.Models.MetricAvailability MetricAvailability(System.TimeSpan? timeGrain = default(System.TimeSpan?), System.TimeSpan? retention = default(System.TimeSpan?)) { throw null; }
        public static Azure.Monitor.Query.Models.MetricQueryResult MetricQueryResult(int? cost = default(int?), string Timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string @namespace = null, string resourceRegion = null, System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.Metric> metrics = null) { throw null; }
        public static Azure.Monitor.Query.Models.MetricValue MetricValue(System.DateTimeOffset timeStamp = default(System.DateTimeOffset), double? average = default(double?), double? minimum = default(double?), double? maximum = default(double?), double? total = default(double?), double? count = default(double?)) { throw null; }
    }
}
namespace Azure.Monitor.Query.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogColumnTypes : System.IEquatable<Azure.Monitor.Query.Models.LogColumnTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogColumnTypes(string value) { throw null; }
        public static Azure.Monitor.Query.Models.LogColumnTypes Bool { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogColumnTypes Datetime { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogColumnTypes Dynamic { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogColumnTypes Int { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogColumnTypes Long { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogColumnTypes Real { get { throw null; } }
        public static Azure.Monitor.Query.Models.LogColumnTypes String { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Models.LogColumnTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Models.LogColumnTypes left, Azure.Monitor.Query.Models.LogColumnTypes right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Models.LogColumnTypes (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Models.LogColumnTypes left, Azure.Monitor.Query.Models.LogColumnTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsBatchQueryResult
    {
        internal LogsBatchQueryResult() { }
        public Azure.Monitor.Query.Models.LogsQueryResult GetResult(string queryId) { throw null; }
        public System.Collections.Generic.IReadOnlyList<T> GetResult<T>(string queryId) { throw null; }
    }
    public partial class LogsQueryResult
    {
        internal LogsQueryResult() { }
        public Azure.Monitor.Query.Models.LogsQueryResultTable PrimaryTable { get { throw null; } }
        public System.BinaryData Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultTable> Tables { get { throw null; } }
        public System.BinaryData Visualization { get { throw null; } }
    }
    public partial class LogsQueryResultColumn
    {
        internal LogsQueryResultColumn() { }
        public string Name { get { throw null; } }
        public Azure.Monitor.Query.Models.LogColumnTypes Type { get { throw null; } }
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
    }
    public partial class LogsQueryResultTable
    {
        internal LogsQueryResultTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultColumn> Columns { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.LogsQueryResultRow> Rows { get { throw null; } }
    }
    public partial class Metric
    {
        internal Metric() { }
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
    public partial class MetricDefinition
    {
        internal MetricDefinition() { }
        public System.Collections.Generic.IReadOnlyList<string> Dimensions { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDimensionRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
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
    public partial class TimeSeriesElement
    {
        internal TimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Models.MetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
    }
}
