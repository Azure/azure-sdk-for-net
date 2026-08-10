// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Manages baggage propagation for invocations protocol tracing.
/// W3C trace context propagation is handled automatically by ASP.NET Core;
/// this class sets correlation baggage on the current Activity so downstream
/// spans inherit invocation/session IDs.
/// </summary>
internal class InvocationsActivitySource
{
    /// <summary>
    /// The default activity source name (retained for listener registration compatibility).
    /// </summary>
    public const string DefaultName = "Azure.AI.AgentServer.Invocations";

    /// <summary>
    /// Initializes a new instance of <see cref="InvocationsActivitySource"/>.
    /// </summary>
    public InvocationsActivitySource()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="InvocationsActivitySource"/> (for subclass testability).
    /// </summary>
    protected InvocationsActivitySource(string? name)
    {
    }

    /// <summary>
    /// Propagates invocation baggage onto the current <see cref="Activity"/> (the ASP.NET
    /// Core request activity) without creating an additional <c>invoke_agent</c> span.
    /// W3C trace context propagation is handled automatically by ASP.NET Core, so
    /// framework spans are parented directly under the caller's span.
    /// </summary>
    /// <param name="context">The invocation context with resolved IDs.</param>
    /// <param name="headers">The request headers (for x-request-id propagation).</param>
    public virtual void PropagateInvocationBaggage(
        InvocationContext context,
        IHeaderDictionary headers)
    {
        var activity = Activity.Current;
        if (activity is null)
        {
            return;
        }

        // Baggage for downstream correlation (§4.3)
        activity.AddBaggage("azure.ai.agentserver.invocation_id", context.InvocationId);
        activity.AddBaggage("azure.ai.agentserver.session_id", context.SessionId ?? string.Empty);

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
