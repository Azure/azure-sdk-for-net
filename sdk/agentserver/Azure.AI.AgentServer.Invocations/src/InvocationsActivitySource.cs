// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Hosting;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Manages <see cref="ActivitySource"/> for invocations protocol tracing.
/// Follows the same DI-friendly, virtual-for-testability pattern as
/// <c>ResponsesActivitySource</c>.
/// </summary>
public class InvocationsActivitySource
{
    /// <summary>
    /// The default activity source name.
    /// </summary>
    public const string DefaultName = "Azure.AI.AgentServer.Invocations";

    private readonly ActivitySource _activitySource;

    /// <summary>
    /// Initializes a new instance of <see cref="InvocationsActivitySource"/> with the default name.
    /// </summary>
    public InvocationsActivitySource()
        : this(DefaultName)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="InvocationsActivitySource"/> with a custom name.
    /// </summary>
    /// <param name="name">The activity source name. Pass <c>null</c> to use the default.</param>
    protected InvocationsActivitySource(string? name)
    {
        _activitySource = new ActivitySource(name ?? DefaultName);
    }

    /// <summary>
    /// Starts a tracing span for a <c>POST /invocations</c> request.
    /// Sets GenAI semantic convention tags and baggage keys.
    /// </summary>
    /// <param name="context">The invocation context with resolved IDs.</param>
    /// <param name="headers">The request headers (for trace propagation).</param>
    /// <returns>An <see cref="Activity"/> if a listener is registered, otherwise <c>null</c>.</returns>
    public virtual Activity? StartInvocationActivity(
        InvocationContext context,
        IHeaderDictionary headers)
    {
        var agentName = FoundryEnvironment.AgentName ?? "unknown";
        var agentVersion = FoundryEnvironment.AgentVersion ?? "unknown";

        var activity = _activitySource.StartActivity(
            $"invoke_agent {agentName}:{agentVersion}",
            ActivityKind.Server);

        if (activity is null)
        {
            return null;
        }

        // GenAI semantic conventions
        activity.SetTag("gen_ai.system", "azure.ai.agentserver");
        activity.SetTag("gen_ai.operation.name", "invoke_agent");

        // Azure-namespaced identity tags
        activity.SetTag("azure.ai.agentserver.agent.name", agentName);
        activity.SetTag("azure.ai.agentserver.agent.version", agentVersion);
        activity.SetTag("azure.ai.agentserver.invocation.id", context.InvocationId);
        activity.SetTag("azure.ai.agentserver.session.id", context.SessionId);

        // Baggage for downstream correlation
        activity.SetBaggage("invocation_id", context.InvocationId);
        activity.SetBaggage("session_id", context.SessionId);

        // x-request-id propagation (if present in headers)
        if (headers.TryGetValue("x-request-id", out var requestId))
        {
            var requestIdStr = requestId.ToString();
            if (!string.IsNullOrEmpty(requestIdStr))
            {
                activity.SetTag("azure.ai.agentserver.x-request-id",
                    requestIdStr.Length > 256 ? requestIdStr[..256] : requestIdStr);
                activity.SetBaggage("x-request-id", requestIdStr);
            }
        }

        return activity;
    }
}
