using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Configuration options for the agent server application.
/// </summary>
/// <param name="ConfigureServices">Action to configure application services.</param>
/// <param name="LoggerFactory">Optional factory for creating loggers.</param>
/// <param name="TelemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
public record ApplicationOptions(
    Action<IServiceCollection> ConfigureServices,
    Func<ILoggerFactory>? LoggerFactory = null,
    string TelemetrySourceName = "Agents")
{
}
