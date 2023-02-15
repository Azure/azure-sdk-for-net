namespace Azure.Monitor.OpenTelemetry
{
    public static partial class AzureMonitorOpenTelemetryExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAzureMonitorOpenTelemetry(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Azure.Monitor.OpenTelemetry.AzureMonitorOpenTelemetryOptions? options = null) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAzureMonitorOpenTelemetry(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration) { throw null; }
    }
    public partial class AzureMonitorOpenTelemetryOptions
    {
        public AzureMonitorOpenTelemetryOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public bool DisableLogs { get { throw null; } set { } }
        public bool DisableMetrics { get { throw null; } set { } }
        public bool DisableOfflineStorage { get { throw null; } set { } }
        public bool DisableTraces { get { throw null; } set { } }
        public Azure.Monitor.OpenTelemetry.Metrics Metrics { get { throw null; } set { } }
        public string StorageDirectory { get { throw null; } set { } }
        public Azure.Monitor.OpenTelemetry.Traces Traces { get { throw null; } set { } }
    }
    public partial class Metrics
    {
        public Metrics() { }
        public bool DisableAspNetInstrumentation { get { throw null; } set { } }
    }
    public partial class Traces
    {
        public Traces() { }
        public bool DisableAspNetInstrumentation { get { throw null; } set { } }
    }
}
