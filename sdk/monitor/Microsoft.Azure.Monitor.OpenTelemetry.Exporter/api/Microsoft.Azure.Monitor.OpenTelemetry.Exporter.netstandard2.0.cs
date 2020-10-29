namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter
{
    public static partial class AzureMonitorExporterHelperExtensions
    {
        public static OpenTelemetry.Trace.TracerProviderBuilder AddAzureMonitorTraceExporter(this OpenTelemetry.Trace.TracerProviderBuilder builder, System.Action<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions> configure = null) { throw null; }
    }
    public partial class AzureMonitorExporterOptions : Azure.Core.ClientOptions
    {
        public AzureMonitorExporterOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public long MaxTransmissionStorageCapacity { get { throw null; } set { } }
        public string StorageFolder { get { throw null; } set { } }
    }
    public partial class AzureMonitorTraceExporter : OpenTelemetry.BaseExporter<System.Diagnostics.Activity>
    {
        public AzureMonitorTraceExporter(Microsoft.Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions options) { }
        public override OpenTelemetry.ExportResult Export(in OpenTelemetry.Batch<System.Diagnostics.Activity> batch) { throw null; }
    }
}
namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models
{
    public partial class AvailabilityData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public AvailabilityData(int version, string id, string name, string duration, bool success) : base (default(int)) { }
        public string Duration { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Message { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string RunLocation { get { throw null; } set { } }
        public bool Success { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataPointType : System.IEquatable<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataPointType(string value) { throw null; }
        public static Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType Aggregation { get { throw null; } }
        public static Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType Measurement { get { throw null; } }
        public bool Equals(Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType left, Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType right) { throw null; }
        public static implicit operator Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType (string value) { throw null; }
        public static bool operator !=(Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType left, Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public MessageData(int version, string message) : base (default(int)) { }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel? SeverityLevel { get { throw null; } set { } }
    }
    public partial class MetricDataPoint
    {
        public MetricDataPoint(string name, double value) { }
        public int? Count { get { throw null; } set { } }
        public Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.DataPointType? DataPointType { get { throw null; } set { } }
        public double? Max { get { throw null; } set { } }
        public double? Min { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public double? StdDev { get { throw null; } set { } }
        public double Value { get { throw null; } }
    }
    public partial class MetricsData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public MetricsData(int version, System.Collections.Generic.IEnumerable<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MetricDataPoint> metrics) : base (default(int)) { }
        public System.Collections.Generic.IList<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MetricDataPoint> Metrics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class MonitorBase
    {
        public MonitorBase() { }
        public Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain BaseData { get { throw null; } set { } }
        public string BaseType { get { throw null; } set { } }
    }
    public partial class MonitorDomain
    {
        public MonitorDomain(int version) { }
        public int Version { get { throw null; } }
    }
    public partial class PageViewData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public PageViewData(int version, string id, string name) : base (default(int)) { }
        public string Duration { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ReferredUri { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    public partial class PageViewPerfData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public PageViewPerfData(int version, string id, string name) : base (default(int)) { }
        public string DomProcessing { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Name { get { throw null; } }
        public string NetworkConnect { get { throw null; } set { } }
        public string PerfTotal { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ReceivedResponse { get { throw null; } set { } }
        public string SentRequest { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    public partial class RemoteDependencyData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public RemoteDependencyData(int version, string name, string duration) : base (default(int)) { }
        public string Data { get { throw null; } set { } }
        public string Duration { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ResultCode { get { throw null; } set { } }
        public bool? Success { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class RequestData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public RequestData(int version, string id, string duration, bool success, string responseCode) : base (default(int)) { }
        public string Duration { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ResponseCode { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public bool Success { get { throw null; } }
        public string Url { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeverityLevel : System.IEquatable<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeverityLevel(string value) { throw null; }
        public static Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel Critical { get { throw null; } }
        public static Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel Error { get { throw null; } }
        public static Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel Information { get { throw null; } }
        public static Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel Verbose { get { throw null; } }
        public static Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel Warning { get { throw null; } }
        public bool Equals(Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel left, Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel right) { throw null; }
        public static implicit operator Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel (string value) { throw null; }
        public static bool operator !=(Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel left, Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StackFrame
    {
        public StackFrame(int level, string method) { }
        public string Assembly { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public int Level { get { throw null; } }
        public int? Line { get { throw null; } set { } }
        public string Method { get { throw null; } }
    }
    public partial class TelemetryErrorDetails
    {
        internal TelemetryErrorDetails() { }
        public int? Index { get { throw null; } }
        public string Message { get { throw null; } }
        public int? StatusCode { get { throw null; } }
    }
    public partial class TelemetryEventData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public TelemetryEventData(int version, string name) : base (default(int)) { }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class TelemetryExceptionData : Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorDomain
    {
        public TelemetryExceptionData(int version, System.Collections.Generic.IEnumerable<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.TelemetryExceptionDetails> exceptions) : base (default(int)) { }
        public System.Collections.Generic.IList<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.TelemetryExceptionDetails> Exceptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string ProblemId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.SeverityLevel? SeverityLevel { get { throw null; } set { } }
    }
    public partial class TelemetryExceptionDetails
    {
        public TelemetryExceptionDetails(string message) { }
        public bool? HasFullStack { get { throw null; } set { } }
        public int? Id { get { throw null; } set { } }
        public string Message { get { throw null; } }
        public int? OuterId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.StackFrame> ParsedStack { get { throw null; } }
        public string Stack { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
    }
    public partial class TelemetryItem
    {
        public TelemetryItem(string name, string time) { }
        public Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.MonitorBase Data { get { throw null; } set { } }
        public string InstrumentationKey { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public float? SampleRate { get { throw null; } set { } }
        public string Sequence { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Time { get { throw null; } }
        public int? Version { get { throw null; } set { } }
    }
    public partial class TrackResponse
    {
        internal TrackResponse() { }
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models.TelemetryErrorDetails> Errors { get { throw null; } }
        public int? ItemsAccepted { get { throw null; } }
        public int? ItemsReceived { get { throw null; } }
    }
}
