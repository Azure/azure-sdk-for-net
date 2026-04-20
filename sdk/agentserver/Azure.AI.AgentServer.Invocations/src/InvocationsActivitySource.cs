// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Manages <see cref="ActivitySource"/> for invocations protocol tracing.
/// Follows the same DI-friendly, virtual-for-testability pattern as
/// <c>ResponsesActivitySource</c>.
/// </summary>
internal class InvocationsActivitySource
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
    /// Builds the span display name following the pattern in §4.1 of the invocation protocol spec:
    /// <c>invoke_agent {Name}:{Version}</c>, <c>invoke_agent {Name}</c>, or <c>invoke_agent</c>.
    /// </summary>
    private static string BuildSpanDisplayName(string? agentName, string? agentVersion)
    {
        if (!string.IsNullOrEmpty(agentName) && !string.IsNullOrEmpty(agentVersion))
        {
            return $"invoke_agent {agentName}:{agentVersion}";
        }

        if (!string.IsNullOrEmpty(agentName))
        {
            return $"invoke_agent {agentName}";
        }

        return "invoke_agent";
    }

    /// <summary>
    /// Builds the <c>gen_ai.agent.id</c> value:
    /// <c>{Name}:{Version}</c>, <c>{Name}</c>, or empty string when agent info is unavailable.
    /// </summary>
    private static string BuildAgentId(string? agentName, string? agentVersion)
    {
        if (!string.IsNullOrEmpty(agentName) && !string.IsNullOrEmpty(agentVersion))
        {
            return $"{agentName}:{agentVersion}";
        }

        if (!string.IsNullOrEmpty(agentName))
        {
            return agentName;
        }

        return string.Empty;
    }

    /// <summary>
    /// Starts a tracing span for a <c>POST /invocations</c> request.
    /// Sets GenAI semantic convention tags and baggage keys per the invocation protocol spec §4.
    /// </summary>
    /// <param name="context">The invocation context with resolved IDs.</param>
    /// <param name="headers">The request headers (for trace propagation).</param>
    /// <returns>An <see cref="Activity"/> if a listener is registered, otherwise <c>null</c>.</returns>
    public virtual Activity? StartInvocationActivity(
        InvocationContext context,
        IHeaderDictionary headers)
    {
        var agentName = FoundryEnvironment.AgentName;
        var agentVersion = FoundryEnvironment.AgentVersion;

        var activity = _activitySource.StartActivity(
            BuildSpanDisplayName(agentName, agentVersion),
            ActivityKind.Server);

        if (activity is null)
        {
            return null;
        }

        // Identity & GenAI convention tags (§4.2)
        activity.SetTag("service.name", "azure.ai.agentserver");
        activity.SetTag("gen_ai.provider.name", "AzureAI Hosted Agents");
        activity.SetTag("gen_ai.operation.name", "invoke_agent");
        activity.SetTag("gen_ai.response.id", context.InvocationId);
        activity.SetTag("gen_ai.agent.id", BuildAgentId(agentName, agentVersion));

        if (!string.IsNullOrEmpty(context.SessionId))
        {
            activity.SetTag("microsoft.session.id", context.SessionId);
        }

        if (!string.IsNullOrEmpty(agentName))
        {
            activity.SetTag("gen_ai.agent.name", agentName);
        }

        if (!string.IsNullOrEmpty(agentVersion))
        {
            activity.SetTag("gen_ai.agent.version", agentVersion);
        }

        // Namespaced tags (§4.2)
        activity.SetTag("azure.ai.agentserver.invocations.invocation_id", context.InvocationId);
        activity.SetTag("azure.ai.agentserver.invocations.session_id", context.SessionId ?? string.Empty);
        activity.SetTag("microsoft.foundry.project.id", FoundryEnvironment.ProjectArmId ?? string.Empty);

        // Baggage for downstream correlation (§4.3)
        activity.SetBaggage("azure.ai.agentserver.invocation_id", context.InvocationId);
        activity.SetBaggage("azure.ai.agentserver.session_id", context.SessionId ?? string.Empty);

        // x-request-id propagation (if present in headers)
        if (headers.TryGetValue("x-request-id", out var requestId))
        {
            var requestIdStr = requestId.ToString();
            if (!string.IsNullOrEmpty(requestIdStr))
            {
                activity.SetTag("azure.ai.agentserver.x-request-id",
                    requestIdStr.Length > 256 ? requestIdStr[..256] : requestIdStr);
                activity.SetBaggage("x-request-id",
                    requestIdStr.Length > 256 ? requestIdStr[..256] : requestIdStr);
            }
        }

        return activity;
    }
}
