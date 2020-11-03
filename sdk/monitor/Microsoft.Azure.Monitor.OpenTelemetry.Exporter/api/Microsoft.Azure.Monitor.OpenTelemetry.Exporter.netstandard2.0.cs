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
