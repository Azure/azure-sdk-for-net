// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Responses.Invocation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.AgentFramework.Extensions;

/// <summary>
/// Provides extension methods for running workflow-based AI agents in the agent server framework.
/// </summary>
public static class WorkflowAgentExtensions
{
    /// <summary>
    /// Runs a workflow-based AI agent asynchronously using the provided service provider.
    /// </summary>
    /// <param name="workflowAgentFactory">the workflow agent factory</param>
    /// <param name="sp">the service provider</param>
    /// <param name="telemetrySourceName">the telemetry source name</param>
    /// <param name="threadRepository">Optional thread repository for managing agent threads</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task RunWorkflowAgentAsync(
        this IWorkflowAgentFactory workflowAgentFactory,
        IServiceProvider sp, string telemetrySourceName = "Agents",
        IAgentThreadRepository? threadRepository = null)
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services =>
            {
                services.AddSingleton(workflowAgentFactory)
                    .AddSingleton<IAgentInvocation, WorkflowAgentInvocation>();
                if (threadRepository != null)
                {
                    services.AddSingleton<IAgentThreadRepository>(threadRepository);
                }
            },
            LoggerFactory: GetLoggerFactory(sp),
            TelemetrySourceName: telemetrySourceName)
            );
    }

    /// <summary>
    /// Runs a workflow-based AI agent asynchronously using the provided service provider.
    /// </summary>
    /// <param name="workflowAgentFactory">the workflow agent factory.</param>
    /// <param name="loggerFactory">Optional logger factory for creating loggers.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <param name="threadRepository">Optional thread repository for managing agent threads</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunWorkflowAgentAsync(
        this IWorkflowAgentFactory workflowAgentFactory,
        ILoggerFactory? loggerFactory = null,
        string telemetrySourceName = "Agents",
        IAgentThreadRepository? threadRepository = null)
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services =>
            {
                services.AddSingleton(workflowAgentFactory)
                    .AddSingleton<IAgentInvocation, WorkflowAgentInvocation>();
                if (threadRepository != null)
                {
                    services.AddSingleton<IAgentThreadRepository>(threadRepository);
                }
            },
            LoggerFactory: loggerFactory == null ? null : () => loggerFactory,
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs a workflow-based AI agent asynchronously using the provided service provider.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="workflowAgentFactory">Optional IWorkflowAgentFactory. If null, retrieves from service provider.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <param name="threadRepository">Optional thread repository for managing agent threads</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunWorkflowAgentAsync(
            this IServiceProvider sp,
            IWorkflowAgentFactory? workflowAgentFactory = null,
            string telemetrySourceName = "Agents",
            IAgentThreadRepository? threadRepository = null)
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services =>
            {
                if (sp.GetService<IAgentInvocation>() == null)
                {
                    services.AddSingleton(workflowAgentFactory ?? sp.GetRequiredService<IWorkflowAgentFactory>()).AddSingleton<WorkflowAgentInvocation>();
                }
                else
                {
                    services.AddSingleton(sp.GetRequiredService<IAgentInvocation>());
                }
                if (threadRepository != null)
                {
                    services.AddSingleton<IAgentThreadRepository>(threadRepository);
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
