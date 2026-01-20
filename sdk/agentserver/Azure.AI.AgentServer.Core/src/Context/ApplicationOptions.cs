// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Runtime;
using Azure.AI.AgentServer.Core.Tools.Runtime.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Configuration options for the agent server application.
/// </summary>
/// <param name="ConfigureServices">Action to configure application services.</param>
/// <param name="LoggerFactory">Optional factory for creating loggers.</param>
/// <param name="TelemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
/// <param name="ToolRuntime">
/// Optional tool runtime for accessing and invoking tools. If not provided, the application
/// will check if IFoundryToolRuntime is registered in the service collection.
/// </param>
/// <param name="UserProvider">
/// Optional user provider for resolving user context. If not provided, defaults to
/// <see cref="AsyncLocalUserProvider"/> which reads from AsyncLocal storage set by middleware.
/// </param>
/// <param name="AgentTools">
/// Optional collection of agent tool definitions to include in agent run contexts.
/// Tools can be FoundryTool instances or dictionary-based facades.
/// </param>
public record ApplicationOptions(
    Action<IServiceCollection> ConfigureServices,
    Func<ILoggerFactory>? LoggerFactory = null,
    string TelemetrySourceName = "Agents",
    IFoundryToolRuntime? ToolRuntime = null,
    IUserProvider? UserProvider = null,
    IEnumerable<object>? AgentTools = null)
{
}
