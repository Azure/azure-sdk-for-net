namespace Azure.Monitor.OpenTelemetry
{
    public static partial class AzureMonitorExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAzureMonitor(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAzureMonitor(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Azure.Monitor.OpenTelemetry.AzureMonitorOptions options) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAzureMonitor(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.Monitor.OpenTelemetry.AzureMonitorOptions> configureAzureMonitor) { throw null; }
    }
    public partial class AzureMonitorOptions
    {
        public AzureMonitorOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.TokenCredential Credential { get { throw null; } set { } }
        public bool DisableOfflineStorage { get { throw null; } set { } }
        public bool EnableLogs { get { throw null; } set { } }
        public bool EnableMetrics { get { throw null; } set { } }
        public bool EnableTraces { get { throw null; } set { } }
        public string StorageDirectory { get { throw null; } set { } }
    }
}
