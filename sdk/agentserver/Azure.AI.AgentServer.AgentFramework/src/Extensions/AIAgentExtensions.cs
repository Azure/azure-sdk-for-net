// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.Core;

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
    /// Runs an AI agent asynchronously with Foundry-backed conversation history hydration.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="credential">The token credential used to access Foundry conversations.</param>
    /// <param name="projectEndpoint">Optional Foundry project endpoint. Defaults to AZURE_AI_PROJECT_ENDPOINT.</param>
    /// <param name="loggerFactory">Optional logger factory for creating loggers.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <param name="threadRepository">Optional thread repository. When provided, it overrides auto-hydration repository creation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(
        this AIAgent agent,
        TokenCredential credential,
        Uri? projectEndpoint = null,
        ILoggerFactory? loggerFactory = null,
        string telemetrySourceName = "Agents",
        IAgentThreadRepository? threadRepository = null)
    {
        ArgumentNullException.ThrowIfNull(agent);
        ArgumentNullException.ThrowIfNull(credential);

        var effectiveThreadRepository =
            threadRepository ?? FoundryConversationThreadRepositoryFactory.Create(credential, projectEndpoint);
        return agent.RunAIAgentAsync(
            loggerFactory: loggerFactory,
            telemetrySourceName: telemetrySourceName,
            threadRepository: effectiveThreadRepository);
    }

    /// <summary>
    /// Runs an AI agent asynchronously using the provided service provider.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <param name="threadRepository">Optional agent thread repository for managing agent threads.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this AIAgent agent, IServiceProvider sp, string telemetrySourceName = "Agents",
        IAgentThreadRepository? threadRepository = null)
    {
        var effectiveThreadRepository =
            threadRepository ?? FoundryConversationThreadRepositoryFactory.CreateWithDefaultCredential();

        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services =>
            {
                services.AddSingleton(agent)
                    .AddSingleton<IAgentInvocation, AIAgentInvocation>();
                if (effectiveThreadRepository != null)
                {
                    services.AddSingleton<IAgentThreadRepository>(effectiveThreadRepository);
                }
            },
            LoggerFactory: GetLoggerFactory(sp),
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs an AI agent asynchronously with an optional logger factory.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="loggerFactory">Optional logger factory for creating loggers.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <param name="threadRepository">Optional agent thread repository for managing agent threads.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this AIAgent agent, ILoggerFactory? loggerFactory = null,
        string telemetrySourceName = "Agents", IAgentThreadRepository? threadRepository = null)
    {
        var effectiveThreadRepository =
            threadRepository ?? FoundryConversationThreadRepositoryFactory.CreateWithDefaultCredential();

        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services =>
            {
                services.AddSingleton(agent).AddSingleton<IAgentInvocation, AIAgentInvocation>();
                if (effectiveThreadRepository != null)
                {
                    services.AddSingleton<IAgentThreadRepository>(effectiveThreadRepository);
                }
            },
            LoggerFactory: loggerFactory == null ? null : () => loggerFactory,
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs an AI agent asynchronously using the service provider's dependencies.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="agent">Optional AI agent to run. If null, retrieves from service provider.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <param name="threadRepository">Optional agent thread repository for managing agent threads.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this IServiceProvider sp, AIAgent? agent = null,
        string telemetrySourceName = "Agents", IAgentThreadRepository? threadRepository = null)
    {
        var effectiveThreadRepository =
            threadRepository ?? FoundryConversationThreadRepositoryFactory.CreateWithDefaultCredential();

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
                if (effectiveThreadRepository != null)
                {
                    services.AddSingleton<IAgentThreadRepository>(effectiveThreadRepository);
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
