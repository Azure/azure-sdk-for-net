namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    public partial class AzureMonitorOptions : Azure.Core.ClientOptions
    {
        public AzureMonitorOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.TokenCredential Credential { get { throw null; } set { } }
        public bool DisableOfflineStorage { get { throw null; } set { } }
        public bool EnableLiveMetrics { get { throw null; } set { } }
        public bool EnableTraceBasedLogsSampler { get { throw null; } set { } }
        public float SamplingRatio { get { throw null; } set { } }
        public string StorageDirectory { get { throw null; } set { } }
        public double? TracesPerSecond { get { throw null; } set { } }
    }
    public static partial class OpenTelemetryBuilderExtensions
    {
        public static OpenTelemetry.OpenTelemetryBuilder UseAzureMonitor(this OpenTelemetry.OpenTelemetryBuilder builder) { throw null; }
        public static OpenTelemetry.OpenTelemetryBuilder UseAzureMonitor(this OpenTelemetry.OpenTelemetryBuilder builder, System.Action<Azure.Monitor.OpenTelemetry.AspNetCore.AzureMonitorOptions> configureAzureMonitor) { throw null; }
    }
}
