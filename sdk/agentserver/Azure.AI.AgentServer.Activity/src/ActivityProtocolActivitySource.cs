// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Manages baggage propagation and span attribute tagging for Activity protocol tracing.
/// W3C trace context propagation is handled automatically by ASP.NET Core;
/// this class sets correlation baggage and gen_ai semantic convention attributes
/// on the current Activity so downstream spans inherit activity/session IDs.
/// </summary>
internal class ActivityProtocolActivitySource
{
    /// <summary>
    /// The default activity source name (retained for listener registration compatibility).
    /// </summary>
    public const string DefaultName = "Azure.AI.AgentServer.Activity";

    // Span attribute keys
    internal const string AttrSpanSessionId = "azure.ai.agentserver.activity.session_id";
    internal const string AttrSpanProtocol = "azure.ai.agentserver.activity.protocol";

    /// <summary>
    /// Initializes a new instance of <see cref="ActivityProtocolActivitySource"/>.
    /// </summary>
    public ActivityProtocolActivitySource()
    {
    }

    /// <summary>
    /// Propagates activity baggage and sets gen_ai semantic convention attributes
    /// on the current <see cref="System.Diagnostics.Activity"/> (the ASP.NET Core request activity).
    /// </summary>
    /// <param name="activityId">The sanitized inbound activity id.</param>
    /// <param name="sessionId">The resolved session id.</param>
    /// <param name="conversationId">The resolved conversation id, if any.</param>
    /// <param name="headers">The request headers (for x-request-id propagation).</param>
    public virtual void PropagateActivityBaggage(
        string activityId,
        string sessionId,
        string? conversationId,
        IHeaderDictionary headers)
    {
        var activity = System.Diagnostics.Activity.Current;
        if (activity is null)
        {
            return;
        }

        // Baggage for downstream correlation
        activity.AddBaggage("azure.ai.agentserver.activity_id", activityId);
        activity.AddBaggage("azure.ai.agentserver.session_id", sessionId ?? string.Empty);
        activity.AddBaggage("azure.ai.agentserver.protocol", "activity");

        // gen_ai semantic convention span attributes
        activity.SetTag("service.name", "azure.ai.agentserver");
        activity.SetTag("gen_ai.provider.name", "AzureAI Hosted Agents");
        activity.SetTag("gen_ai.operation.name", "handle_activity");

        // Agent identity from Foundry environment
        var agentName = FoundryEnvironment.AgentName;
        var agentVersion = FoundryEnvironment.AgentVersion;
        string agentId;
        if (!string.IsNullOrEmpty(agentName) && !string.IsNullOrEmpty(agentVersion))
        {
            agentId = $"{agentName}:{agentVersion}";
        }
        else if (!string.IsNullOrEmpty(agentName))
        {
            agentId = agentName;
        }
        else
        {
            agentId = FoundryEnvironment.AgentInstanceClientId ?? string.Empty;
        }

        activity.SetTag("gen_ai.agent.id", agentId);
        if (!string.IsNullOrEmpty(agentName))
        {
            activity.SetTag("gen_ai.agent.name", agentName);
        }

        if (!string.IsNullOrEmpty(agentVersion))
        {
            activity.SetTag("gen_ai.agent.version", agentVersion);
        }

        if (!string.IsNullOrEmpty(sessionId))
        {
            activity.SetTag("gen_ai.conversation.id", sessionId);
        }

        // Activity protocol-specific span attributes
        activity.SetTag(AttrSpanSessionId, sessionId ?? string.Empty);
        activity.SetTag(AttrSpanProtocol, "activity");
        activity.SetTag("microsoft.foundry.project.id", FoundryEnvironment.ProjectArmId ?? string.Empty);

        // Conversation ID from context
        if (!string.IsNullOrEmpty(conversationId))
        {
            activity.SetTag("azure.ai.agentserver.activity.conversation_id", conversationId);
        }

        // x-request-id propagation (if present in headers)
        if (headers.TryGetValue(PlatformHeaders.RequestId, out var requestId))
        {
            var requestIdStr = requestId.ToString();
            if (!string.IsNullOrEmpty(requestIdStr))
            {
                activity.AddBaggage(PlatformHeaders.RequestId,
                    requestIdStr.Length > 256 ? requestIdStr[..256] : requestIdStr);
            }
        }
    }
}
