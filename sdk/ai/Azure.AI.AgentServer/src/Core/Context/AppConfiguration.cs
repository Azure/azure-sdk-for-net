using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Configuration settings for the agent server application, bound from environment variables.
/// </summary>
public record AppConfiguration
{
    /// <summary>
    /// Gets the port number for the application server. Defaults to 8088.
    /// </summary>
    [ConfigurationKeyName("DEFAULT_AD_PORT")]
    public int Port { get; init; } = 8088;

    /// <summary>
    /// Gets a value indicating whether Application Insights is enabled. Defaults to true.
    /// </summary>
    [ConfigurationKeyName("AGENT_APP_INSIGHTS_ENABLED")]
    public bool AppInsightsEnabled { get; init; } = true;

    /// <summary>
    /// Gets the Application Insights connection string.
    /// </summary>
    [ConfigurationKeyName("AGENT_APP_INSIGHTS_CONNECTION_STRING")]
    public string AppInsightsConnectionString { get; init; } = "";

    /// <summary>
    /// Gets the OpenTelemetry exporter endpoint.
    /// </summary>
    [ConfigurationKeyName("OTEL_EXPORTER_ENDPOINT")]
    public string OpenTelemetryExporterEndpoint { get; init; } = "";

    /// <summary>
    /// Gets the Azure tenant ID.
    /// </summary>
    [ConfigurationKeyName("AZURE_TENANT_ID")]
    public string TenantId { get; init; } = "";

    /// <summary>
    /// Gets the Azure subscription ID.
    /// </summary>
    [ConfigurationKeyName("AGENT_SUBSCRIPTION_ID")]
    public string SubscriptionId { get; init; } = "";

    /// <summary>
    /// Gets the Azure resource group name.
    /// </summary>
    [ConfigurationKeyName("AGENT_RESOURCE_GROUP")]
    public string ResourceGroup { get; init; } = "";

    /// <summary>
    /// Gets the Foundry project information.
    /// </summary>
    [ConfigurationKeyName("AGENT_PROJECT_NAME")]
    public FoundryProjectInfo? FoundryProjectInfo { get; init; }

    /// <summary>
    /// Gets the log level for the application. Defaults to Information.
    /// </summary>
    [ConfigurationKeyName("AGENT_LOG_LEVEL")]
    public LogLevel LogLevel { get; init; } = LogLevel.Information;
}
