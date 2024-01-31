namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    public partial class LiveMetricsExporterOptions : Azure.Core.ClientOptions
    {
        public LiveMetricsExporterOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.TokenCredential Credential { get { throw null; } set { } }
        public bool EnableLiveMetrics { get { throw null; } set { } }
    }
    public static partial class LiveMetricsExtensions
    {
        public static OpenTelemetry.Trace.TracerProviderBuilder AddLiveMetrics(this OpenTelemetry.Trace.TracerProviderBuilder builder, System.Action<Azure.Monitor.OpenTelemetry.LiveMetrics.LiveMetricsExporterOptions> configure = null, string name = null) { throw null; }
    }
}
namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DerivedMetricInfoAggregation : System.IEquatable<Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DerivedMetricInfoAggregation(string value) { throw null; }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation Avg { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation Max { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation Min { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation Sum { get { throw null; } }
        public bool Equals(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation right) { throw null; }
        public static implicit operator Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DerivedMetricInfoAggregation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFilterConjunctionGroupInfoTelemetryType : System.IEquatable<Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFilterConjunctionGroupInfoTelemetryType(string value) { throw null; }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType Dependency { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType Event { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType Exception { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType Metric { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType PerformanceCounter { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType Request { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType Trace { get { throw null; } }
        public bool Equals(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType right) { throw null; }
        public static implicit operator Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentFilterConjunctionGroupInfoTelemetryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentIngressDocumentType : System.IEquatable<Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentIngressDocumentType(string value) { throw null; }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType Event { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType Exception { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType RemoteDependency { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType Request { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType Trace { get { throw null; } }
        public bool Equals(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType right) { throw null; }
        public static implicit operator Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.DocumentIngressDocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterInfoPredicate : System.IEquatable<Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterInfoPredicate(string value) { throw null; }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate Contains { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate DoesNotContain { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate Equal { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate GreaterThan { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate GreaterThanOrEqual { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate LessThan { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate LessThanOrEqual { get { throw null; } }
        public static Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate NotEqual { get { throw null; } }
        public bool Equals(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate right) { throw null; }
        public static implicit operator Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate left, Azure.Monitor.OpenTelemetry.LiveMetrics.Models.FilterInfoPredicate right) { throw null; }
        public override string ToString() { throw null; }
    }
}
