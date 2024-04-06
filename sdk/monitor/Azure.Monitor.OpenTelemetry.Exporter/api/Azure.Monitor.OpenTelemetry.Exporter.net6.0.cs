namespace Azure.Monitor.OpenTelemetry.Exporter
{
    public static partial class AzureMonitorExporterExtensions
    {
        public static OpenTelemetry.Logs.OpenTelemetryLoggerOptions AddAzureMonitorLogExporter(this OpenTelemetry.Logs.OpenTelemetryLoggerOptions loggerOptions, System.Action<Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions> configure = null, Azure.Core.TokenCredential credential = null) { throw null; }
        public static OpenTelemetry.Metrics.MeterProviderBuilder AddAzureMonitorMetricExporter(this OpenTelemetry.Metrics.MeterProviderBuilder builder, System.Action<Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions> configure = null, Azure.Core.TokenCredential credential = null, string name = null) { throw null; }
        public static OpenTelemetry.Trace.TracerProviderBuilder AddAzureMonitorTraceExporter(this OpenTelemetry.Trace.TracerProviderBuilder builder, System.Action<Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions> configure = null, Azure.Core.TokenCredential credential = null, string name = null) { throw null; }
    }
    public partial class AzureMonitorExporterOptions : Azure.Core.ClientOptions
    {
        public AzureMonitorExporterOptions() { }
        public AzureMonitorExporterOptions(Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions.ServiceVersion version = Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions.ServiceVersion.v2_1) { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.TokenCredential Credential { get { throw null; } set { } }
        public bool DisableOfflineStorage { get { throw null; } set { } }
        public float SamplingRatio { get { throw null; } set { } }
        public string StorageDirectory { get { throw null; } set { } }
        public Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions.ServiceVersion Version { get { throw null; } set { } }
        public enum ServiceVersion
        {
            v2_1 = 1,
        }
    }
    public sealed partial class AzureMonitorLogExporter : OpenTelemetry.BaseExporter<OpenTelemetry.Logs.LogRecord>
    {
        public AzureMonitorLogExporter(Azure.Monitor.OpenTelemetry.Exporter.AzureMonitorExporterOptions options) { }
        protected override void Dispose(bool disposing) { }
        public override OpenTelemetry.ExportResult Export(in OpenTelemetry.Batch<OpenTelemetry.Logs.LogRecord> batch) { throw null; }
    }
}
