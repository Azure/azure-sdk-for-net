// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Responses.Invocation;

using Microsoft.Agents.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.AgentFramework.Extensions;

/// <summary>
/// Provides extension methods for running AI agents in the agent server framework.
/// </summary>
public static class AIAgentExtensions
{
    /// <summary>
    /// Runs an AI agent asynchronously using the provided service provider.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this AIAgent agent, IServiceProvider sp, string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services => services.AddSingleton(agent).AddSingleton<IAgentInvocation, AIAgentInvocation>(),
            LoggerFactory: GetLoggerFactory(sp),
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs an AI agent asynchronously with an optional logger factory.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="loggerFactory">Optional logger factory for creating loggers.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this AIAgent agent, ILoggerFactory? loggerFactory = null,
        string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services => services.AddSingleton(agent).AddSingleton<IAgentInvocation, AIAgentInvocation>(),
            LoggerFactory: loggerFactory == null ? null : () => loggerFactory,
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs an AI agent asynchronously using the service provider's dependencies.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="agent">Optional AI agent to run. If null, retrieves from service provider.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
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
