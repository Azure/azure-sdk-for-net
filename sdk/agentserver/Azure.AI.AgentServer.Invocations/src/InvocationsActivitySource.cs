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
    /// <returns>The normalized correlation baggage applied to the current activity, when one exists.</returns>
    public virtual InvocationCorrelationBaggage PropagateInvocationBaggage(
        InvocationContext context,
        IHeaderDictionary headers)
    {
        var baggage = InvocationCorrelationBaggage.Create(context, headers);
        var activity = Activity.Current;
        if (activity is null)
        {
            return baggage;
        }

        activity.AddBaggage("azure.ai.agentserver.invocation_id", baggage.InvocationId);
        activity.AddBaggage("azure.ai.agentserver.session_id", baggage.SessionId);
        if (baggage.RequestId is not null)
        {
            activity.AddBaggage(PlatformHeaders.RequestId, baggage.RequestId);
        }
        return baggage;
    }
}

internal readonly record struct InvocationCorrelationBaggage(
    string? InvocationId,
    string? SessionId,
    string? RequestId)
{
    internal void AddStartTags(ActivityTagsCollection tags)
    {
        // Processors run synchronously during StartActivity. Seed only the sanctioned
        // enrichment attribute here; ApplyBaggage handles downstream propagation.
        if (!string.IsNullOrWhiteSpace(SessionId))
        {
            tags["microsoft.session.id"] = SessionId;
        }
    }

    internal static InvocationCorrelationBaggage Create(
        InvocationContext context,
        IHeaderDictionary headers)
    {
        string? requestId = null;
        if (headers.TryGetValue(PlatformHeaders.RequestId, out var requestIdValues))
        {
            var value = requestIdValues.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                requestId = value.Length > 256 ? value[..256] : value;
            }
        }

        return new(context.InvocationId, context.SessionId ?? string.Empty, requestId);
    }
}
