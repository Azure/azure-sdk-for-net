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
        public bool DisableOfflineStorage { get { throw null; } set { } }
        public bool EnableLogs { get { throw null; } set { } }
        public bool EnableMetrics { get { throw null; } set { } }
        public bool EnableTraces { get { throw null; } set { } }
        public string StorageDirectory { get { throw null; } set { } }
    }
}
