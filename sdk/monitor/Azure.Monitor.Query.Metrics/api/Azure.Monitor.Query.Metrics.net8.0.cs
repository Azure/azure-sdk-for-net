namespace Azure.Monitor.Query.Metrics
{
    public partial class AzureMonitorQueryMetricsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMonitorQueryMetricsContext() { }
        public static Azure.Monitor.Query.Metrics.AzureMonitorQueryMetricsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MetricsClient
    {
        protected MetricsClient() { }
        public MetricsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public MetricsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.Metrics.MetricsClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult> QueryResources(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds, System.Collections.Generic.IEnumerable<string> metricNames, string metricNamespace, Azure.Monitor.Query.Metrics.MetricsQueryResourcesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>> QueryResourcesAsync(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds, System.Collections.Generic.IEnumerable<string> metricNames, string metricNamespace, Azure.Monitor.Query.Metrics.MetricsQueryResourcesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsClientAudience : System.IEquatable<Azure.Monitor.Query.Metrics.MetricsClientAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricsClientAudience(string value) { throw null; }
        public static Azure.Monitor.Query.Metrics.MetricsClientAudience AzureChina { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.MetricsClientAudience AzureGovernment { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.MetricsClientAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Metrics.MetricsClientAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Metrics.MetricsClientAudience left, Azure.Monitor.Query.Metrics.MetricsClientAudience right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Metrics.MetricsClientAudience (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Metrics.MetricsClientAudience left, Azure.Monitor.Query.Metrics.MetricsClientAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsClientOptions : Azure.Core.ClientOptions
    {
        public MetricsClientOptions(Azure.Monitor.Query.Metrics.MetricsClientOptions.ServiceVersion version = Azure.Monitor.Query.Metrics.MetricsClientOptions.ServiceVersion.V2024_02_01) { }
        public Azure.Monitor.Query.Metrics.MetricsClientAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2024_02_01 = 1,
        }
    }
    public partial class MetricsQueryResourcesOptions
    {
        public MetricsQueryResourcesOptions() { }
        public System.Collections.Generic.IList<string> Aggregations { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Granularity { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RollUpBy { get { throw null; } }
        public int? Size { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Monitor.Query.Metrics.MetricsQueryTimeRange? TimeRange { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsQueryTimeRange : System.IEquatable<Azure.Monitor.Query.Metrics.MetricsQueryTimeRange>
    {
        private readonly int _dummyPrimitive;
        public MetricsQueryTimeRange(System.DateTimeOffset start, System.DateTimeOffset end) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public MetricsQueryTimeRange(System.DateTimeOffset start, System.TimeSpan duration) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public MetricsQueryTimeRange(System.TimeSpan duration) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public MetricsQueryTimeRange(System.TimeSpan duration, System.DateTimeOffset end) { throw null; }
        public static Azure.Monitor.Query.Metrics.MetricsQueryTimeRange All { get { throw null; } }
        public System.TimeSpan Duration { get { throw null; } }
        public System.DateTimeOffset? End { get { throw null; } }
        public System.DateTimeOffset? Start { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Metrics.MetricsQueryTimeRange other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Metrics.MetricsQueryTimeRange left, Azure.Monitor.Query.Metrics.MetricsQueryTimeRange right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Metrics.MetricsQueryTimeRange (System.TimeSpan timeSpan) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Metrics.MetricsQueryTimeRange left, Azure.Monitor.Query.Metrics.MetricsQueryTimeRange right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Monitor.Query.Metrics.Models
{
    public partial class MetricResult : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricResult>
    {
        internal MetricResult() { }
        public string Description { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement> TimeSeries { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.Monitor.Query.Metrics.Models.MetricUnit Unit { get { throw null; } }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Metrics.Models.MetricResult System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Metrics.Models.MetricResult System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class MetricsQueryModelFactory
    {
        public static Azure.Monitor.Query.Metrics.Models.MetricResult MetricResult(string id, string resourceType, string name, Azure.Monitor.Query.Metrics.Models.MetricUnit unit, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement> timeSeries) { throw null; }
        public static Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult MetricsQueryResourcesResult(System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult> values = null) { throw null; }
        public static Azure.Monitor.Query.Metrics.Models.MetricsQueryResult MetricsQueryResult(string startTime = null, string endTime = null, string granularity = null, string @namespace = null, string resourceRegion = null, string resourceId = null, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Metrics.Models.MetricResult> metrics = null) { throw null; }
        public static Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement MetricTimeSeriesElement(System.Collections.Generic.IReadOnlyDictionary<string, string> metadataValues, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Metrics.Models.MetricValue> values) { throw null; }
        public static Azure.Monitor.Query.Metrics.Models.MetricValue MetricValue(System.DateTimeOffset timeStamp = default(System.DateTimeOffset), double? average = default(double?), double? minimum = default(double?), double? maximum = default(double?), double? total = default(double?), double? count = default(double?)) { throw null; }
    }
    public partial class MetricsQueryResourcesResult : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>
    {
        internal MetricsQueryResourcesResult() { }
        public System.Collections.Generic.IList<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult> Values { get { throw null; } }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult (Azure.Response result) { throw null; }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResourcesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricsQueryResult : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult>
    {
        internal MetricsQueryResult() { }
        public string Granularity { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Monitor.Query.Metrics.Models.MetricResult> Metrics { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string ResourceRegion { get { throw null; } }
        public Azure.Monitor.Query.Metrics.MetricsQueryTimeRange TimeSpan { get { throw null; } }
        public Azure.Monitor.Query.Metrics.Models.MetricResult GetMetricByName(string name) { throw null; }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricsQueryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricsQueryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Metrics.Models.MetricsQueryResult System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Metrics.Models.MetricsQueryResult System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricsQueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricTimeSeriesElement : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement>
    {
        internal MetricTimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Monitor.Query.Metrics.Models.MetricValue> Values { get { throw null; } }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricTimeSeriesElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricUnit : System.IEquatable<Azure.Monitor.Query.Metrics.Models.MetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricUnit(string value) { throw null; }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit BitsPerSecond { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit Bytes { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit ByteSeconds { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit Cores { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit Count { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit CountPerSecond { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit MilliCores { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit MilliSeconds { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit NanoCores { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit Percent { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit Seconds { get { throw null; } }
        public static Azure.Monitor.Query.Metrics.Models.MetricUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Metrics.Models.MetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Metrics.Models.MetricUnit left, Azure.Monitor.Query.Metrics.Models.MetricUnit right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Metrics.Models.MetricUnit (string value) { throw null; }
        public static implicit operator Azure.Monitor.Query.Metrics.Models.MetricUnit? (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Metrics.Models.MetricUnit left, Azure.Monitor.Query.Metrics.Models.MetricUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricValue : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricValue>
    {
        internal MetricValue() { }
        public double? Average { get { throw null; } }
        public double? Count { get { throw null; } }
        public double? Maximum { get { throw null; } }
        public double? Minimum { get { throw null; } }
        public System.DateTimeOffset TimeStamp { get { throw null; } }
        public double? Total { get { throw null; } }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Monitor.Query.Metrics.Models.MetricValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Metrics.Models.MetricValue System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Metrics.Models.MetricValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Metrics.Models.MetricValue System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Metrics.Models.MetricValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class QueryMetricsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.Metrics.MetricsClient, Azure.Monitor.Query.Metrics.MetricsClientOptions> AddMetricsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.Metrics.MetricsClient, Azure.Monitor.Query.Metrics.MetricsClientOptions> AddMetricsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
