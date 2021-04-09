namespace Azure.Monitory.Query
{
    public partial class LogsBatchQuery
    {
        protected LogsBatchQuery() { }
        public virtual string AddQuery(string workspaceId, string query) { throw null; }
        public virtual Azure.Response<Azure.Monitory.Query.Models.LogsBatchQueryResult> Submit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitory.Query.Models.LogsBatchQueryResult>> SubmitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsClient
    {
        protected LogsClient() { }
        public LogsClient(Azure.Core.TokenCredential credential) { }
        public LogsClient(Azure.Core.TokenCredential credential, Azure.Monitory.Query.LogsClientOptions options) { }
        public virtual Azure.Monitory.Query.LogsBatchQuery CreateBatchQuery() { throw null; }
        public virtual Azure.Response<Azure.Monitory.Query.Models.LogsQueryResult> Query(string workspaceId, string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitory.Query.Models.LogsQueryResult>> QueryAsync(string workspaceId, string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsClientOptions : Azure.Core.ClientOptions
    {
        public LogsClientOptions(Azure.Monitory.Query.LogsClientOptions.ServiceVersion version = Azure.Monitory.Query.LogsClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 0,
        }
    }
    public partial class MetricsClient
    {
        protected MetricsClient() { }
        public MetricsClient(Azure.Core.TokenCredential credential) { }
        public MetricsClient(Azure.Core.TokenCredential credential, Azure.Monitory.Query.MetricsClientOptions options) { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetricNamespace>> GetMetricNamespaces(string resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetricNamespace>>> GetMetricNamespacesAsync(string resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetricDefinition>> GetMetrics(string resource, string metricsNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetricDefinition>>> GetMetricsAsync(string resource, string metricsNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitory.Query.Models.MetricQueryResult> Query(string resource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.TimeSpan interval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitory.Query.Models.MetricQueryResult>> QueryAsync(string resource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.TimeSpan interval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricsClientOptions : Azure.Core.ClientOptions
    {
        public MetricsClientOptions(Azure.Monitory.Query.MetricsClientOptions.ServiceVersion version = Azure.Monitory.Query.MetricsClientOptions.ServiceVersion.V2018_01_01) { }
        public enum ServiceVersion
        {
            V2018_01_01 = 0,
        }
    }
}
namespace Azure.Monitory.Query.Models
{
    public partial class LocalizableString
    {
        internal LocalizableString() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        public static implicit operator string (Azure.Monitory.Query.Models.LocalizableString localizableString) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsBatchQueryResult
    {
        internal LogsBatchQueryResult() { }
        public Azure.Monitory.Query.Models.LogsQueryResult GetResult(string queryId) { throw null; }
    }
    public partial class LogsQueryResult
    {
        internal LogsQueryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.LogsQueryResultTable> Tables { get { throw null; } }
    }
    public partial class LogsQueryResultColumn
    {
        internal LogsQueryResultColumn() { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class LogsQueryResultTable
    {
        internal LogsQueryResultTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.LogsQueryResultColumn> Columns { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<string>> Rows { get { throw null; } }
    }
    public partial class MetadataValue
    {
        internal MetadataValue() { }
        public Azure.Monitory.Query.Models.LocalizableString Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class Metric
    {
        internal Metric() { }
        public string Id { get { throw null; } }
        public Azure.Monitory.Query.Models.LocalizableString Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.TimeSeriesElement> Timeseries { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.Monitory.Query.Models.MetricUnit Unit { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.LocalizableString> Dimensions { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDimensionRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.Monitory.Query.Models.LocalizableString Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.Monitory.Query.Models.MetricAggregationType? PrimaryAggregationType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetricAggregationType> SupportedAggregationTypes { get { throw null; } }
        public Azure.Monitory.Query.Models.MetricUnit? Unit { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.Metric> Metrics { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Resourceregion { get { throw null; } }
        public string Timespan { get { throw null; } }
    }
    public enum MetricUnit
    {
        Count = 0,
        Bytes = 1,
        Seconds = 2,
        CountPerSecond = 3,
        BytesPerSecond = 4,
        Percent = 5,
        MilliSeconds = 6,
        ByteSeconds = 7,
        Unspecified = 8,
        Cores = 9,
        MilliCores = 10,
        NanoCores = 11,
        BitsPerSecond = 12,
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
    }
    public partial class TimeSeriesElement
    {
        internal TimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitory.Query.Models.MetadataValue> Metadatavalues { get { throw null; } }
    }
}
