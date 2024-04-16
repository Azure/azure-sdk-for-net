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
