using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Context;

public record ApplicationOptions(
    Action<IServiceCollection> ConfigureServices,
    Func<ILoggerFactory>? LoggerFactory = null,
    string TelemetrySourceName = "Agents")
{
}
