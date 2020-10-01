namespace OpenTelemetry.Exporter.AzureMonitor
{
    public static partial class AzureMonitorExporterHelperExtensions
    {
        public static OpenTelemetry.Trace.TracerProviderBuilder AddAzureMonitorTraceExporter(this OpenTelemetry.Trace.TracerProviderBuilder builder, System.Action<OpenTelemetry.Exporter.AzureMonitor.AzureMonitorExporterOptions> configure = null) { throw null; }
    }
    public partial class AzureMonitorExporterOptions : Azure.Core.ClientOptions
    {
        public AzureMonitorExporterOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public long MaxTransmissionStorageCapacity { get { throw null; } set { } }
        public string StorageFolder { get { throw null; } set { } }
    }
    public partial class AzureMonitorTraceExporter : OpenTelemetry.Trace.ActivityExporter
    {
        public AzureMonitorTraceExporter(OpenTelemetry.Exporter.AzureMonitor.AzureMonitorExporterOptions options) { }
        public override OpenTelemetry.Trace.ExportResult Export(in OpenTelemetry.Batch<System.Diagnostics.Activity> batch) { throw null; }
    }
}
namespace OpenTelemetry.Exporter.AzureMonitor.Models
{
    public partial class AvailabilityData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
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
    public readonly partial struct ContextTagKeys : System.IEquatable<OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContextTagKeys(string value) { throw null; }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiApplicationVer { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiCloudLocation { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiCloudRole { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiCloudRoleInstance { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiCloudRoleVer { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiDeviceId { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiDeviceLocale { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiDeviceModel { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiDeviceOemName { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiDeviceOsVersion { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiDeviceType { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiInternalAgentVersion { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiInternalNodeName { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiInternalSdkVersion { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiLocationCity { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiLocationCountry { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiLocationIp { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiLocationProvince { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiOperationCorrelationVector { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiOperationId { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiOperationName { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiOperationParentId { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiOperationSyntheticSource { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiSessionId { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiSessionIsFirst { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiUserAccountId { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiUserAuthUserId { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys AiUserId { get { throw null; } }
        public bool Equals(OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys left, OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys right) { throw null; }
        public static implicit operator OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys (string value) { throw null; }
        public static bool operator !=(OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys left, OpenTelemetry.Exporter.AzureMonitor.Models.ContextTagKeys right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataPointType : System.IEquatable<OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataPointType(string value) { throw null; }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType Aggregation { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType Measurement { get { throw null; } }
        public bool Equals(OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType left, OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType right) { throw null; }
        public static implicit operator OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType (string value) { throw null; }
        public static bool operator !=(OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType left, OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
    {
        public MessageData(int version, string message) : base (default(int)) { }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel? SeverityLevel { get { throw null; } set { } }
    }
    public partial class MetricDataPoint
    {
        public MetricDataPoint(string name, double value) { }
        public int? Count { get { throw null; } set { } }
        public OpenTelemetry.Exporter.AzureMonitor.Models.DataPointType? DataPointType { get { throw null; } set { } }
        public double? Max { get { throw null; } set { } }
        public double? Min { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public double? StdDev { get { throw null; } set { } }
        public double Value { get { throw null; } }
    }
    public partial class MetricsData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
    {
        public MetricsData(int version, System.Collections.Generic.IEnumerable<OpenTelemetry.Exporter.AzureMonitor.Models.MetricDataPoint> metrics) : base (default(int)) { }
        public System.Collections.Generic.IList<OpenTelemetry.Exporter.AzureMonitor.Models.MetricDataPoint> Metrics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class MonitorBase
    {
        public MonitorBase() { }
        public OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain BaseData { get { throw null; } set { } }
        public string BaseType { get { throw null; } set { } }
    }
    public partial class MonitorDomain
    {
        public MonitorDomain(int version) { }
        public int Version { get { throw null; } }
    }
    public partial class PageViewData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
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
    public partial class PageViewPerfData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
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
    public partial class RemoteDependencyData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
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
    public partial class RequestData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
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
    public readonly partial struct SeverityLevel : System.IEquatable<OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeverityLevel(string value) { throw null; }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel Critical { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel Error { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel Information { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel Verbose { get { throw null; } }
        public static OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel Warning { get { throw null; } }
        public bool Equals(OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel left, OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel right) { throw null; }
        public static implicit operator OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel (string value) { throw null; }
        public static bool operator !=(OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel left, OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel right) { throw null; }
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
    public partial class TelemetryEventData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
    {
        public TelemetryEventData(int version, string name) : base (default(int)) { }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class TelemetryExceptionData : OpenTelemetry.Exporter.AzureMonitor.Models.MonitorDomain
    {
        public TelemetryExceptionData(int version, System.Collections.Generic.IEnumerable<OpenTelemetry.Exporter.AzureMonitor.Models.TelemetryExceptionDetails> exceptions) : base (default(int)) { }
        public System.Collections.Generic.IList<OpenTelemetry.Exporter.AzureMonitor.Models.TelemetryExceptionDetails> Exceptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> Measurements { get { throw null; } }
        public string ProblemId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public OpenTelemetry.Exporter.AzureMonitor.Models.SeverityLevel? SeverityLevel { get { throw null; } set { } }
    }
    public partial class TelemetryExceptionDetails
    {
        public TelemetryExceptionDetails(string message) { }
        public bool? HasFullStack { get { throw null; } set { } }
        public int? Id { get { throw null; } set { } }
        public string Message { get { throw null; } }
        public int? OuterId { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenTelemetry.Exporter.AzureMonitor.Models.StackFrame> ParsedStack { get { throw null; } }
        public string Stack { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
    }
    public partial class TelemetryItem
    {
        public TelemetryItem(string name, string time) { }
        public OpenTelemetry.Exporter.AzureMonitor.Models.MonitorBase Data { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<OpenTelemetry.Exporter.AzureMonitor.Models.TelemetryErrorDetails> Errors { get { throw null; } }
        public int? ItemsAccepted { get { throw null; } }
        public int? ItemsReceived { get { throw null; } }
    }
}
