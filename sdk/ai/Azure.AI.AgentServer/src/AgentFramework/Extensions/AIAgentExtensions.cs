using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Responses.Invocation;

using Microsoft.Agents.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.AgentFramework.Extensions;

public static class AIAgentExtensions
{
    public static Task RunAIAgentAsync(this AIAgent agent, IServiceProvider sp, string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services => services.AddSingleton(agent).AddSingleton<IAgentInvocation, AIAgentInvocation>(),
            LoggerFactory: GetLoggerFactory(sp),
            TelemetrySourceName: telemetrySourceName));
    }

    public static Task RunAIAgentAsync(this AIAgent agent, ILoggerFactory? loggerFactory = null,
        string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services => services.AddSingleton(agent).AddSingleton<IAgentInvocation, AIAgentInvocation>(),
            LoggerFactory: loggerFactory == null ? null : () => loggerFactory,
            TelemetrySourceName: telemetrySourceName));
    }

    public static Task RunAIAgentAsync(this IServiceProvider sp, AIAgent? agent = null,
        string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services =>
            {
                if (sp.GetService<IAgentInvocation>() == null)
                {
                    services.AddSingleton(agent ?? sp.GetRequiredService<AIAgent>()).AddSingleton<AIAgentInvocation>();
                }
                else
                {
                    services.AddSingleton(sp.GetRequiredService<IAgentInvocation>());
                }
            },
            LoggerFactory: GetLoggerFactory(sp),
            TelemetrySourceName: telemetrySourceName));
    }

    private static Func<ILoggerFactory>? GetLoggerFactory(IServiceProvider sp)
    {
        return sp.GetService<ILoggerFactory>() == null ? null : sp.GetRequiredService<ILoggerFactory>;
    }
}
