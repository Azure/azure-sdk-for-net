using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Context;

/**
 * Binds env vars
 */
public record AppConfiguration
{
    [ConfigurationKeyName("DEFAULT_AD_PORT")]
    public int Port { get; init; } = 8088;

    [ConfigurationKeyName("AGENT_APP_INSIGHTS_ENABLED")]
    public bool AppInsightsEnabled { get; init; } = true;

    [ConfigurationKeyName("AGENT_APP_INSIGHTS_CONNECTION_STRING")]
    public string AppInsightsConnectionString { get; init; } = "";

    [ConfigurationKeyName("OTEL_EXPORTER_ENDPOINT")]
    public string OpenTelemetryExporterEndpoint { get; init; } = "";

    [ConfigurationKeyName("AZURE_TENANT_ID")]
    public string TenantId { get; init; } = "";

    [ConfigurationKeyName("AGENT_SUBSCRIPTION_ID")]
    public string SubscriptionId { get; init; } = "";

    [ConfigurationKeyName("AGENT_RESOURCE_GROUP")]
    public string ResourceGroup { get; init; } = "";

    [ConfigurationKeyName("AGENT_PROJECT_NAME")]
    public FoundryProjectInfo? FoundryProjectInfo { get; init; }

    [ConfigurationKeyName("AGENT_LOG_LEVEL")]
    public LogLevel LogLevel { get; init; } = LogLevel.Information;
}
